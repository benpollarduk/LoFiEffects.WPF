using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a degrade shader effect.
    /// </summary>
    public class DegradeEffect : SpecklingEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Degrade.ps") };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DegradeEffect class.
        /// </summary>
        public DegradeEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(DensityProperty);
            UpdateShaderValue(IntensityProperty);
            UpdateShaderValue(OffsetProperty);
            UpdateShaderValue(RenderOverTransparentDoubleProperty);
        }

        #endregion
    }
}
