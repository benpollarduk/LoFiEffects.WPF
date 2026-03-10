using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a QuantizationNoise shader effect.
    /// </summary>
    public class QuantizationNoiseEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/QuantizationNoise.ps") };

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
        /// Get or set the Levels. This is a dependency property.
        /// </summary>
        public double Levels
        {
            get { return (double)GetValue(LevelsProperty); }
            set { SetValue(LevelsProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the QuantizationNoiseEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(QuantizationNoiseEffect), 0);

        /// <summary>
        /// Identifies the QuantizationNoiseEffect.Levels property.
        /// </summary>
        public static readonly DependencyProperty LevelsProperty = DependencyProperty.Register("Levels", typeof(double), typeof(QuantizationNoiseEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the QuantizationNoiseEffect class.
        /// </summary>
        public QuantizationNoiseEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(LevelsProperty);
        }

        #endregion
    }
}