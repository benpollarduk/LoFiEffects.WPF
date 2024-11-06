using System;
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
        #region Notes

        /* 
            Based on:
            http://bursjootech.blogspot.co.uk/2008/06/grayscale-effect-pixel-shader-effect-in.html
        */

        #endregion

        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = new Uri(@"pack://application:,,,/LoFiEffects.WPF;component/Effects/Shaders/Grayscale.ps") };

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
