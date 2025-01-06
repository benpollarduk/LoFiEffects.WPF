using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a watercolor shader effect.
    /// </summary>
    public class WatercolorEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Watercolor.ps") };

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
        /// Get or set the intensity. Higher values will have a more dramatic effect. This is a dependency property.
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
        /// Identifies the WatercolorEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(WatercolorEffect), 0);

        /// <summary>
        /// Identifies the WatercolorEffect.Intensity property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(WatercolorEffect), new UIPropertyMetadata(0.5d, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the WatercolorEffect.TextureWidth property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(WatercolorEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the WatercolorEffect.TextureHeight property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(WatercolorEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(2)));

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
