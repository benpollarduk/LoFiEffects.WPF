using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a posterize shader effect.
    /// </summary>
    public class PosterizeEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Posterize.ps") };

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
        /// Get or set the number of steps to use for the posterization. Higher values will have a less dramatic effect. This is a dependency property.
        /// </summary>
        public double Steps
        {
            get { return (double)GetValue(StepsProperty); }
            set { SetValue(StepsProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the PosterizeEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(PosterizeEffect), 0);

        /// <summary>
        /// Identifies the PosterizeEffect.Steps property.
        /// </summary>
        public static readonly DependencyProperty StepsProperty = DependencyProperty.Register("Steps", typeof(double), typeof(PosterizeEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PosterizeEffect class.
        /// </summary>
        public PosterizeEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(StepsProperty);
        }

        #endregion
    }
}
