using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a watercolor shader effect.
    /// </summary>
    public class WatercolorEffect : TexturedIntensityEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Watercolor.ps") };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the WatercolorEffect class.
        /// </summary>
        public WatercolorEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(IntensityProperty);
            UpdateShaderValue(TextureWidthProperty);
            UpdateShaderValue(TextureHeightProperty);
        }

        #endregion
    }
}
