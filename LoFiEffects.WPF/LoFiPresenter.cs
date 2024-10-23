using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoFiEffects.WPF
{
    /// <summary>
    /// Provides a control for presenting content at a reduced fidelity.
    /// </summary>
    public class LoFiPresenter : ContentControl, IDisposable
    {
        #region Fields

        /// <summary>
        /// Get the ContentPresenter used to present the contents of the control.
        /// </summary>
        private ContentPresenter? Presenter => GetTemplateChild("PART_PRESENTER") as ContentPresenter;

        /// <summary>
        /// Get the LoFiMask used to mask the contents of the Presenter.
        /// </summary>
        private LoFiMask? Mask => GetTemplateChild("PART_MASK") as LoFiMask;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the strength of the reduction. This is a dependency property.
        /// </summary>
        public double Reduction
        {
            get { return (double)GetValue(ReductionProperty); }
            set { SetValue(ReductionProperty, value); }
        }

        /// <summary>
        /// Get or set the number of frames per second the mask updates at. This is a dependency property.
        /// </summary>
        public uint FramesPerSecond
        {
            get { return (uint)GetValue(FramesPerSecondProperty); }
            set { SetValue(FramesPerSecondProperty, value); }
        }

        /// <summary>
        /// Get or set the mask background color. This is a dependency property.
        /// </summary>
        public Color? MaskBackgroundColor
        {
            get { return (Color?)GetValue(MaskBackgroundColorProperty); }
            set { SetValue(MaskBackgroundColorProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the LoFiPresenter.Reduction property.
        /// </summary>
        public static readonly DependencyProperty ReductionProperty = DependencyProperty.Register(nameof(Reduction), typeof(double), typeof(LoFiPresenter), new PropertyMetadata(2d, OnReductionPropertyChanged));

        /// <summary>
        /// Identifies the LoFiPresenter.FramesPerSecond property.
        /// </summary>
        public static readonly DependencyProperty FramesPerSecondProperty = DependencyProperty.Register(nameof(FramesPerSecond), typeof(uint), typeof(LoFiPresenter), new PropertyMetadata((uint)30, OnFramesPerSecondPropertyChanged));

        /// <summary>
        /// Identifies the LoFiPresenter.MaskBackgroundColor property.
        /// </summary>
        public static readonly DependencyProperty MaskBackgroundColorProperty = DependencyProperty.Register(nameof(MaskBackgroundColor), typeof(Color?), typeof(LoFiPresenter), new PropertyMetadata(OnMaskBackgroundColorPropertyChanged));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LoFiPresenter class.
        /// </summary>
        public LoFiPresenter()
        {
            Template = CreateTemplate();
            
            Loaded += (_, _) =>
            {
                var mask = Mask;

                if (mask != null)
                {
                    mask.Source = Content as FrameworkElement;
                    mask.Reduction = Reduction;
                    mask.FramesPerSecond = FramesPerSecond;
                }
            };
            
            Unloaded += (_, _) =>
            {
                var mask = Mask;

                if (mask != null)
                    mask.Source = null;
            };
        }

        #endregion

        #region Overrides of ContentControl

        /// <summary>
        /// Called when the <see cref="P:System.Windows.Controls.ContentControl.Content" /> property changes.
        /// </summary>
        /// <param name="oldContent">The old value of the <see cref="P:System.Windows.Controls.ContentControl.Content" /> property.</param>
        /// <param name="newContent">The new value of the <see cref="P:System.Windows.Controls.ContentControl.Content" /> property.</param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            if (Presenter != null)
                Presenter.Content = newContent;

            if (Mask != null)
                Mask.Source = newContent as FrameworkElement;
        }

        #endregion

        #region StaticMethods

        private static ControlTemplate CreateTemplate()
        {
            var template = new ControlTemplate(typeof(LoFiPresenter));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter))
            {
                Name = "PART_PRESENTER"
            };

            var mask = new FrameworkElementFactory(typeof(LoFiMask))
            {
                Name = "PART_MASK"
            };

            var grid = new FrameworkElementFactory(typeof(Grid));
            grid.AppendChild(contentPresenter);
            grid.AppendChild(mask);

            template.VisualTree = grid;

            return template;
        }

        private static void OnReductionPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as LoFiPresenter;
            var mask = control?.Mask;

            if (mask == null)
                return;

            mask.Reduction = (double)args.NewValue;
            mask.Visibility = mask.Reduction > 1.0 ? Visibility.Visible : Visibility.Hidden;
        }

        private static void OnFramesPerSecondPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as LoFiPresenter;
            var mask = control?.Mask;

            if (mask == null)
                return;

            mask.FramesPerSecond = (uint)args.NewValue;
        }

        private static void OnMaskBackgroundColorPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as LoFiPresenter;
            var mask = control?.Mask;

            if (mask == null)
                return;

            mask.BackgroundColor = (Color?)args.NewValue;
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Mask?.Dispose();
        }

        #endregion
    }
}
