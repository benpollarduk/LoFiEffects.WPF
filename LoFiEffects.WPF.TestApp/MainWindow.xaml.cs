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
            MugshotImage.Effect = e.Parameter as ShaderEffect;
        }

        private void MugshotImage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var effect = FindResource("CrtEffect") as CrtEffect;

            if (effect == null)
                return;

            effect.TextureWidth = e.NewSize.Width;
            effect.TextureHeight = e.NewSize.Height;
        }
    }
}