using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a noise shader effect.
    /// </summary>
    public class NoiseEffect : SpecklingEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Noise.ps") };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NoiseEffect class.
        /// </summary>
        public NoiseEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(DensityProperty);
            UpdateShaderValue(IntensityProperty);
            UpdateShaderValue(OffsetProperty);
            UpdateShaderValue(RenderOverTransparentProperty);
        }

        #endregion
    }
}
