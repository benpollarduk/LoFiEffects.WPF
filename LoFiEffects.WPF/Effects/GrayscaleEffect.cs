using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a grayscale shader effect.
    /// </summary>
    public class GrayscaleEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource("Effects/Shaders/Grayscale.ps") };

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

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the GrayscaleEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GrayscaleEffect class.
        /// </summary>
        public GrayscaleEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
        }

        #endregion
    }
}
