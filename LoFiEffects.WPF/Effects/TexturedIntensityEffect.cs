using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a textured intensity shader effect.
    /// </summary>
    public abstract class TexturedIntensityEffect : ShaderEffect
    {
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
        /// Get or set the intensity. This is a dependency property.
        /// </summary>
        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        /// <summary>
        /// Get or set the width of the texture. This is a dependency property.
        /// </summary>
        public double TextureWidth
        {
            get { return (double)GetValue(TextureWidthProperty); }
            set { SetValue(TextureWidthProperty, value); }
        }

        /// <summary>
        /// Get or set the height of the texture. This is a dependency property.
        /// </summary>
        public double TextureHeight
        {
            get { return (double)GetValue(TextureHeightProperty); }
            set { SetValue(TextureHeightProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the TexturedIntensityEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(TexturedIntensityEffect), 0);

        /// <summary>
        /// Identifies the TexturedIntensityEffect.Intensity property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(TexturedIntensityEffect), new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the TexturedIntensityEffect.TextureWidth property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(TexturedIntensityEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the TexturedIntensityEffect.TextureHeight property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(TexturedIntensityEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(2)));

        #endregion
    }
}
