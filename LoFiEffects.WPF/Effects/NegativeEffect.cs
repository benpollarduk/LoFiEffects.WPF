using System;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;

namespace LoFiEffects.WPF.Effects
{
    public class NegativeEffect : ShaderEffect
    {
        private static PixelShader _pixelShader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/LoFiEffects.Wpf;component/Effects/Shaders/Negative.ps") };

        public NegativeEffect()
        {
            PixelShader = _pixelShader;

            UpdateShaderValue(InputProperty);
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
    }
}