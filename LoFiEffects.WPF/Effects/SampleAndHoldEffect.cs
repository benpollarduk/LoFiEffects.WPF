using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a SampleAndHold shader effect.
    /// </summary>
    public class SampleAndHoldEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/SampleAndHold.ps") };

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
        /// Get or set the Intensity. This is a dependency property.
        /// </summary>
        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the SampleAndHoldEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(SampleAndHoldEffect), 0);

        /// <summary>
        /// Identifies the SampleAndHoldEffect.Intensity property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(SampleAndHoldEffect), new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SampleAndHoldEffect class.
        /// </summary>
        public SampleAndHoldEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(IntensityProperty);
        }

        #endregion
    }
}