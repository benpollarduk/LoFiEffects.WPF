using System;
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
        #region Notes

        /* 
            Based on:
            http://bursjootech.blogspot.co.uk/2008/06/grayscale-effect-pixel-shader-effect-in.html
        */

        #endregion

        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = new Uri(@"pack://application:,,,/LoFiEffects.WPF;component/Effects/Shaders/Posterize.ps") };

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
        /// Get or set the levels. This is a dependency property.
        /// </summary>
        public double Levels
        {
            get { return (double)GetValue(LevelsProperty); }
            set { SetValue(LevelsProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the PosterizeEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(PosterizeEffect), 0);

        /// <summary>
        /// Identifies the PosterizeEffect.Levels property.
        /// </summary>
        public static readonly DependencyProperty LevelsProperty = DependencyProperty.Register("Levels", typeof(double), typeof(PosterizeEffect), new UIPropertyMetadata(10.0, PixelShaderConstantCallback(0), CoerceLevels));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PosterizeEffect class.
        /// </summary>
        public PosterizeEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(LevelsProperty);
        }

        #endregion

        #region StaticMethods

        private static object CoerceLevels(DependencyObject o, object value)
        {
            var effect = (PosterizeEffect)o;
            var newFactor = (double)value;

            if ((newFactor < 0) || (newFactor > 1))
            {
                return effect.Levels;
            }

            return newFactor;
        }

        #endregion
    }
}
