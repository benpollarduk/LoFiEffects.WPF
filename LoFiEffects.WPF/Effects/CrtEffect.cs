using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a cathode ray tube (CRT) shader effect.
    /// </summary>
    public class CrtEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Crt.ps") };

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
        /// Get or set if the scanlines should be rendered. This is a dependency property.
        /// </summary>
        public bool IncludeScanlines
        {
            get { return (bool)GetValue(IncludeScanlinesProperty); }
            set { SetValue(IncludeScanlinesProperty, value); }
        }

        /// <summary>
        /// Get or set if the scanlines should be rendered. This is a dependency property.
        /// </summary>
        protected double IncludeScanlinesDouble
        {
            get { return (double)GetValue(IncludeScanlinesDoubleProperty); }
            set { SetValue(IncludeScanlinesDoubleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the CrtEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(CrtEffect), 0);

        /// <summary>
        /// Identifies the CrtEffect.TextureWidth property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(CrtEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the CrtEffect.TextureHeight property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(CrtEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the CrtEffect.IncludeScanlines property.
        /// </summary>
        public static readonly DependencyProperty IncludeScanlinesProperty = DependencyProperty.Register("IncludeScanlines", typeof(bool), typeof(CrtEffect), new PropertyMetadata(false, new PropertyChangedCallback(OnIncludeScanlinesPropertyChanged)));

        /// <summary>
        /// Identifies the CrtEffect.IncludeScanlines property.
        /// </summary>
        public static readonly DependencyProperty IncludeScanlinesDoubleProperty = DependencyProperty.Register("IncludeScanlinesDouble", typeof(double), typeof(CrtEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(2)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CrtEffect class.
        /// </summary>
        public CrtEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(TextureWidthProperty);
            UpdateShaderValue(TextureHeightProperty);
            UpdateShaderValue(IncludeScanlinesDoubleProperty);
        }

        #endregion

        #region StaticMethods

        private static void OnIncludeScanlinesPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var crt = obj as CrtEffect;

            if (crt == null)
                return;

            crt.IncludeScanlinesDouble = (bool)args.NewValue ? 1.0 : 0.0;
        }

        #endregion
    }
}
