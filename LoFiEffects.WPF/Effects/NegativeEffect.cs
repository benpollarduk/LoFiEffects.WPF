using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a negative shader effect.
    /// </summary>
    public class NegativeEffect : SpecklingEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Negative.ps") };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NegativeEffect class.
        /// </summary>
        public NegativeEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
        }

        #endregion
    }
}
