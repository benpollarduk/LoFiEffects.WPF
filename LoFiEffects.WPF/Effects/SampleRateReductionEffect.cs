using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a SampleRateReduction shader effect.
    /// </summary>
    public class SampleRateReductionEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/SampleRateReduction.ps") };

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
        /// Get or set the Scale. This is a dependency property.
        /// </summary>
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }
        /// <summary>
        /// Get or set the Jitter. This is a dependency property.
        /// </summary>
        public double Jitter
        {
            get { return (double)GetValue(JitterProperty); }
            set { SetValue(JitterProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the SampleRateReductionEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(SampleRateReductionEffect), 0);

        /// <summary>
        /// Identifies the SampleRateReductionEffect.Scale property.
        /// </summary>
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register("Scale", typeof(double), typeof(SampleRateReductionEffect), new UIPropertyMetadata(50.0, PixelShaderConstantCallback(0)));
        /// <summary>
        /// Identifies the SampleRateReductionEffect.Jitter property.
        /// </summary>
        public static readonly DependencyProperty JitterProperty = DependencyProperty.Register("Jitter", typeof(double), typeof(SampleRateReductionEffect), new UIPropertyMetadata(0.05, PixelShaderConstantCallback(1)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SampleRateReductionEffect class.
        /// </summary>
        public SampleRateReductionEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ScaleProperty);
            UpdateShaderValue(JitterProperty);
        }

        #endregion
    }
}