using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a DataCorruptor shader effect.
    /// </summary>
    public class DataCorruptorEffect : ShaderEffect
    {
        #region StaticFields

        private static readonly PixelShader pixelShader = new() { UriSource = UriHelper.FromResource(@"Effects/Shaders/DataCorruptor.ps") };

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
        /// Get or set the Key. This is a dependency property.
        /// </summary>
        public double Key
        {
            get { return (double)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the DataCorruptorEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(DataCorruptorEffect), 0);

        /// <summary>
        /// Identifies the DataCorruptorEffect.Key property.
        /// </summary>
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(double), typeof(DataCorruptorEffect), new UIPropertyMetadata(1.0, PixelShaderConstantCallback(0)));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataCorruptorEffect class.
        /// </summary>
        public DataCorruptorEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(KeyProperty);
        }

        #endregion
    }
}