using LoFiEffects.WPF.Effects;
using System.Windows;

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