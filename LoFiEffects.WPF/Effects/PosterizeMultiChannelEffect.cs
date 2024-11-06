using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a multi channel posterize shader effect.
    /// </summary>
    public class PosterizeMultiChannelEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource("Effects/Shaders/PosterizeMultiChannel.ps") };

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
        /// Get or set the steps for the red channel. This is a dependency property.
        /// </summary>
        public double StepsR
        {
            get { return (double)GetValue(StepsRProperty); }
            set { SetValue(StepsRProperty, value); }
        }

        /// <summary>
        /// Get or set the steps for the green channel. This is a dependency property.
        /// </summary>
        public double StepsG
        {
            get { return (double)GetValue(StepsGProperty); }
            set { SetValue(StepsGProperty, value); }
        }

        /// <summary>
        /// Get or set the steps for the blue channel. This is a dependency property.
        /// </summary>
        public double StepsB
        {
            get { return (double)GetValue(StepsBProperty); }
            set { SetValue(StepsBProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the PosterizeEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(PosterizeMultiChannelEffect), 0);

        /// <summary>
        /// Identifies the PosterizeEffect.StepsR property.
        /// </summary>
        public static readonly DependencyProperty StepsRProperty = DependencyProperty.Register("StepsR", typeof(double), typeof(PosterizeMultiChannelEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the PosterizeEffect.StepsG property.
        /// </summary>
        public static readonly DependencyProperty StepsGProperty = DependencyProperty.Register("StepsG", typeof(double), typeof(PosterizeMultiChannelEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the PosterizeEffect.StepsB property.
        /// </summary>
        public static readonly DependencyProperty StepsBProperty = DependencyProperty.Register("StepsB", typeof(double), typeof(PosterizeMultiChannelEffect), new UIPropertyMetadata(4.0, PixelShaderConstantCallback(2)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PosterizeMultiChannelEffect class.
        /// </summary>
        public PosterizeMultiChannelEffect()
        {
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(StepsRProperty);
            UpdateShaderValue(StepsGProperty);
            UpdateShaderValue(StepsBProperty);
        }

        #endregion
    }
}
