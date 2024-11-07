using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoFiEffects.WPF
{
    /// <summary>
    /// Provides a control for presenting content at a reduced frame rate.
    /// </summary>
    public class FrameRateReductionPresenter : ContentControl
    {
        #region Fields

        /// <summary>
        /// Get the ContentPresenter used to present the contents of the control.
        /// </summary>
        private ContentPresenter? Presenter => GetTemplateChild("PART_PRESENTER") as ContentPresenter;

        /// <summary>
        /// Get the LoFiMask used to mask the contents of the Presenter.
        /// </summary>
        private FrameRateReductionMask? Mask => GetTemplateChild("PART_MASK") as FrameRateReductionMask;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the number of frames per second the mask updates at. This is a dependency property.
        /// </summary>
        public uint FramesPerSecond
        {
            get { return (uint)GetValue(FramesPerSecondProperty); }
            set { SetValue(FramesPerSecondProperty, value); }
        }

        /// <summary>
        /// Get or set the mask background. This is a dependency property.
        /// </summary>
        public Brush MaskBackground
        {
            get { return (Brush)GetValue(MaskBackgroundProperty); }
            set { SetValue(MaskBackgroundProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the FrameRateReductionPresenter.FramesPerSecond property.
        /// </summary>
        public static readonly DependencyProperty FramesPerSecondProperty = DependencyProperty.Register(nameof(FramesPerSecond), typeof(uint), typeof(FrameRateReductionPresenter), new PropertyMetadata((uint)30, OnFramesPerSecondPropertyChanged));

        /// <summary>
        /// Identifies the FrameRateReductionPresenter.MaskBackground property.
        /// </summary>
        public static readonly DependencyProperty MaskBackgroundProperty = DependencyProperty.Register(nameof(MaskBackground), typeof(Brush), typeof(FrameRateReductionPresenter), new PropertyMetadata(new SolidColorBrush(Colors.Transparent), OnMaskBackgroundPropertyChanged));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the FrameRateReductionPresenter class.
        /// </summary>
        public FrameRateReductionPresenter()
        {
            Template = CreateTemplate();
            
            Loaded += (_, _) =>
            {
                var mask = Mask;

                if (mask != null)
                {
                    mask.Source = Content as FrameworkElement;
                    mask.FramesPerSecond = FramesPerSecond;
                    mask.MaskBackground = MaskBackground;
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
        /// Called when the System.Windows.Controls.ContentControl.Content property changes.
        /// </summary>
        /// <param name="oldContent">The old value of the System.Windows.Controls.ContentControl.Content property.</param>
        /// <param name="newContent">The new value of the System.Windows.Controls.ContentControl.Content property.</param>
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
            var template = new ControlTemplate(typeof(FrameRateReductionPresenter));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter))
            {
                Name = "PART_PRESENTER"
            };

            var mask = new FrameworkElementFactory(typeof(FrameRateReductionMask))
            {
                Name = "PART_MASK"
            };

            var grid = new FrameworkElementFactory(typeof(Grid));
            grid.AppendChild(contentPresenter);
            grid.AppendChild(mask);

            template.VisualTree = grid;

            return template;
        }

        private static void OnFramesPerSecondPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as FrameRateReductionPresenter;
            var mask = control?.Mask;

            if (mask == null)
                return;

            mask.FramesPerSecond = (uint)args.NewValue;
        }

        private static void OnMaskBackgroundPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var control = obj as FrameRateReductionPresenter;
            var mask = control?.Mask;

            if (mask == null)
                return;

            mask.MaskBackground = (Brush)args.NewValue;
        }

        #endregion
    }
}
