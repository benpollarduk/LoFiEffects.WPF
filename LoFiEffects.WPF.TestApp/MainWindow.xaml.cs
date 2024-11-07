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

        private void ApplyCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            FrameRateReductionPresenter.Effect = e.Parameter as ShaderEffect;
        }
    }
}