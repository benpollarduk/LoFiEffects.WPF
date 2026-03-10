using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a BlockDisplacement shader effect.
    /// </summary>
    public class BlockDisplacementEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/BlockDisplacement.ps") };

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
        /// Get or set the Intensity. This is a dependency property.
        /// </summary>
        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }
        /// <summary>
        /// Get or set the Resolution. This is a dependency property.
        /// </summary>
        public double Resolution
        {
            get { return (double)GetValue(ResolutionProperty); }
            set { SetValue(ResolutionProperty, value); }
        }
        /// <summary>
        /// Get or set the Time. This is a dependency property.
        /// </summary>
        public double Time
        {
            get { return (double)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the BlockDisplacementEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(BlockDisplacementEffect), 0);

        /// <summary>
        /// Identifies the BlockDisplacementEffect.Intensity property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(BlockDisplacementEffect), new UIPropertyMetadata(0.1, PixelShaderConstantCallback(0)));
        /// <summary>
        /// Identifies the BlockDisplacementEffect.Resolution property.
        /// </summary>
        public static readonly DependencyProperty ResolutionProperty = DependencyProperty.Register("Resolution", typeof(double), typeof(BlockDisplacementEffect), new UIPropertyMetadata(20.0, PixelShaderConstantCallback(1)));
        /// <summary>
        /// Identifies the BlockDisplacementEffect.Time property.
        /// </summary>
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(double), typeof(BlockDisplacementEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(2)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BlockDisplacementEffect class.
        /// </summary>
        public BlockDisplacementEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(IntensityProperty);
            UpdateShaderValue(ResolutionProperty);
            UpdateShaderValue(TimeProperty);
        }

        #endregion
    }
}