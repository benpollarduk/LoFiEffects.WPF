using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a vignette shader effect.
    /// </summary>
    public class VignetteEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Vignette.ps") };

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
        /// Get or set the intensity. This is a dependency property.
        /// </summary>
        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// The <see cref="DependencyProperty"/> for the <see cref="Input"/> property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(VignetteEffect), 0);

        /// <summary>
        /// The <see cref="DependencyProperty"/> for the <see cref="Intensity"/> property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(VignetteEffect), new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VignetteEffect"/> class.
        /// </summary>
        public VignetteEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(IntensityProperty);
        }

        #endregion
    }
}