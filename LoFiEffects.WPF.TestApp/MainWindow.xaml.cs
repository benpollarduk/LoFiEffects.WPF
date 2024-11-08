using LoFiEffects.WPF.Effects;
using System.Windows;
using System.Windows.Media;
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

        private void SetScanlineColorCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var effect = FindResource("ScanlinesEffect") as ScanlinesEffect;
            
            if (effect != null)
                effect.ScanlineColor = (Color)e.Parameter;
        }
    }
}