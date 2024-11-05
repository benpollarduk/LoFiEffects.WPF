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

            Effect = new PosterizeEffect();
        }
    }
}