using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a scanlines shader effect.
    /// </summary>
    public class ScanlinesEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Scanlines.ps") };

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the input. This is a dependency property.
        /// </summary>
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>
        /// Get or set the x spacing between scan lines. This is a dependency property.
        /// </summary>
        public double XSpacing
        {
            get { return (double)GetValue(XSpacingProperty); }
            set { SetValue(XSpacingProperty, value); }
        }

        /// <summary>
        /// Get or set the y spacing between scan lines. This is a dependency property.
        /// </summary>
        public double YSpacing
        {
            get { return (double)GetValue(YSpacingProperty); }
            set { SetValue(YSpacingProperty, value); }
        }

        /// <summary>
        /// Get or set the width of the texture. This is a dependency property.
        /// </summary>
        public double TextureWidth
        {
            get { return (double)GetValue(TextureWidthProperty); }
            set { SetValue(TextureWidthProperty, value); }
        }

        /// <summary>
        /// Get or set the height of the texture. This is a dependency property.
        /// </summary>
        public double TextureHeight
        {
            get { return (double)GetValue(TextureHeightProperty); }
            set { SetValue(TextureHeightProperty, value); }
        }

        /// <summary>
        /// Get or set if the effect should be rendered over transparency. This is a dependency property.
        /// </summary>
        public bool RenderOverTransparent
        {
            get { return (bool)GetValue(RenderOverTransparentProperty); }
            set { SetValue(RenderOverTransparentProperty, value); }
        }

        /// <summary>
        /// Get or set if the effect should be rendered over transparency. This is a dependency property.
        /// </summary>
        protected double RenderOverTransparentDouble
        {
            get { return (double)GetValue(RenderOverTransparentDoubleProperty); }
            set { SetValue(RenderOverTransparentDoubleProperty, value); }
        }

        /// <summary>
        /// Get or set the color of the scanlines. This is a dependency property.
        /// </summary>
        public Color ScanlineColor
        {
            get { return (Color)GetValue(ScanlineColorProperty); }
            set { SetValue(ScanlineColorProperty, value); }
        }

        /// <summary>
        /// Get or set the corner radius. This is a dependency property.
        /// </summary>
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the ScanlinesEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(ScanlinesEffect), 0);

        /// <summary>
        /// Identifies the ScanlinesEffect.XSpacing property.
        /// </summary>
        public static readonly DependencyProperty XSpacingProperty = DependencyProperty.Register("XSpacing", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the ScanlinesEffect.YSpacing property.
        /// </summary>
        public static readonly DependencyProperty YSpacingProperty = DependencyProperty.Register("YSpacing", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(8.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the ScanlinesEffect.TextureWidth property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Identifies the ScanlinesEffect.TextureHeight property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(3)));

        /// <summary>
        /// Identifies the ScanlinesEffect.RenderOverTransparent property.
        /// </summary>
        public static readonly DependencyProperty RenderOverTransparentProperty = DependencyProperty.Register("RenderOverTransparent", typeof(bool), typeof(ScanlinesEffect), new PropertyMetadata(false, new PropertyChangedCallback(OnRenderOverTransparentPropertyChanged)));

        /// <summary>
        /// Identifies the ScanlinesEffect.RenderOverTransparentDouble property.
        /// </summary>
        public static readonly DependencyProperty RenderOverTransparentDoubleProperty = DependencyProperty.Register("RenderOverTransparentDouble", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(4)));

        /// <summary>
        /// Identifies the ScanlinesEffect.ScanlineColor property.
        /// </summary>
        public static readonly DependencyProperty ScanlineColorProperty = DependencyProperty.Register("ScanlineColor", typeof(Color), typeof(ScanlinesEffect), new UIPropertyMetadata(Colors.Black, PixelShaderConstantCallback(5)));

        /// <summary>
        /// Identifies the ScanlinesEffect.CornerRadius property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(1.5, PixelShaderConstantCallback(6)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ScanlinesEffect class.
        /// </summary>
        public ScanlinesEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(XSpacingProperty);
            UpdateShaderValue(YSpacingProperty);
            UpdateShaderValue(TextureWidthProperty);
            UpdateShaderValue(TextureHeightProperty);
            UpdateShaderValue(RenderOverTransparentProperty);
            UpdateShaderValue(ScanlineColorProperty);
            UpdateShaderValue(CornerRadiusProperty);
        }

        #endregion

        #region StaticMethods

        private static void OnRenderOverTransparentPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var scanlines = obj as ScanlinesEffect;

            if (scanlines == null)
                return;

            scanlines.RenderOverTransparentDouble = (bool)args.NewValue ? 1.0 : 0.0;
        }

        #endregion
    }
}
