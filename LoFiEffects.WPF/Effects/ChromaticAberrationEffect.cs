using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a chromatic aberration shader effect.
    /// </summary>
    public class ChromaticAberrationEffect : TexturedIntensityEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/ChromaticAberration.ps") };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ChromaticAberrationEffect class.
        /// </summary>
        public ChromaticAberrationEffect()
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