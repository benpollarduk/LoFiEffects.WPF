using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a chromatic aberration shader effect.
    /// </summary>
    public class ChromaticAberrationEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/ChromaticAberration.ps") };

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
        /// The <see cref="DependencyProperty"/> for the <see cref="Input"/> property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ChromaticAberrationEffect), 0);

        /// <summary>
        /// The <see cref="DependencyProperty"/> for the <see cref="Intensity"/> property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(ChromaticAberrationEffect), new UIPropertyMetadata(2.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// The <see cref="DependencyProperty"/> for the <see cref="TextureWidth"/> property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(ChromaticAberrationEffect), new UIPropertyMetadata(800.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// The <see cref="DependencyProperty"/> for the <see cref="TextureHeight"/> property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(ChromaticAberrationEffect), new UIPropertyMetadata(600.0, PixelShaderConstantCallback(2)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChromaticAberrationEffect"/> class.
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