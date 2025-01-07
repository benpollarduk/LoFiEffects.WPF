using LoFiEffects.WPF.Effects;
using System.Windows;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();     
        }

        private void ApplyCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            FrameRateReductionPresenter.Effect = e.Parameter as ShaderEffect;
        }

        private void MugshotImage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var crtEffect = FindResource("CrtEffect") as CrtEffect;

            if (crtEffect != null)
            {
                crtEffect.TextureWidth = e.NewSize.Width;
                crtEffect.TextureHeight = e.NewSize.Height;
            }

            var watercolorEffect = FindResource("WatercolorEffect") as WatercolorEffect;

            if (watercolorEffect != null)
            {
                watercolorEffect.TextureWidth = e.NewSize.Width;
                watercolorEffect.TextureHeight = e.NewSize.Height;
            }
        }
    }
}