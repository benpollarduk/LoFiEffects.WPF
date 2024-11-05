using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    public class PosterizeEffect : ShaderEffect
    {
        private static PixelShader _pixelShader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/LoFiEffects.Wpf;component/Resources/Posterize.ps") };

        public PosterizeEffect()
        {
            PixelShader = _pixelShader;
        }
    }
}