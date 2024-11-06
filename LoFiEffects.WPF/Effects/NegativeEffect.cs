using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a Negative shader effect.
    /// </summary>
    public class NegativeEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource("Effects/Shaders/Negative.ps") };

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
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(NegativeEffect), 0);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GrayscaleEffect class.
        /// </summary>
        public NegativeEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
        }

        #endregion
    }
}
