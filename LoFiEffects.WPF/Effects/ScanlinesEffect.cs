using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a scanlines shader effect.
    /// </summary>
    public class ScanlinesEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/Scanlines.ps") };

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
        /// Get or set the x spacing between scan lines. This is a dependency property.
        /// </summary>
        public double XSpacing
        {
            get { return (double)GetValue(XSpacingProperty); }
            set { SetValue(XSpacingProperty, value); }
        }

        /// <summary>
        /// Get or set the y spacing between scan lines. This is a dependency property.
        /// </summary>
        public double YSpacing
        {
            get { return (double)GetValue(YSpacingProperty); }
            set { SetValue(YSpacingProperty, value); }
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
        /// Identifies the ScanlinesEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(ScanlinesEffect), 0);

        /// <summary>
        /// Identifies the ScanlinesEffect.XSpacing property.
        /// </summary>
        public static readonly DependencyProperty XSpacingProperty = DependencyProperty.Register("XSpacing", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the ScanlinesEffect.YSpacing property.
        /// </summary>
        public static readonly DependencyProperty YSpacingProperty = DependencyProperty.Register("YSpacing", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(8.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the ScanlinesEffect.TextureWidth property.
        /// </summary>
        public static readonly DependencyProperty TextureWidthProperty = DependencyProperty.Register("TextureWidth", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Identifies the ScanlinesEffect.TextureHeight property.
        /// </summary>
        public static readonly DependencyProperty TextureHeightProperty = DependencyProperty.Register("TextureHeight", typeof(double), typeof(ScanlinesEffect), new UIPropertyMetadata(500.0, PixelShaderConstantCallback(3)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ScanlinesEffect class.
        /// </summary>
        public ScanlinesEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(XSpacingProperty);
            UpdateShaderValue(YSpacingProperty);
            UpdateShaderValue(TextureWidthProperty);
            UpdateShaderValue(TextureHeightProperty);
        }

        #endregion
    }
}
