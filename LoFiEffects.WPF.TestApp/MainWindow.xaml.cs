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

            var chromaticAberrationEffect = FindResource("ChromaticAberrationEffect") as ChromaticAberrationEffect;

            if (chromaticAberrationEffect != null)
            {
                chromaticAberrationEffect.TextureWidth = e.NewSize.Width;
                chromaticAberrationEffect.TextureHeight = e.NewSize.Height;
            }
        }

        private void CopyToClipBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MugshotImage.Source is System.Windows.Media.Imaging.BitmapSource bitmapSource)
            {
                int originalWidth = bitmapSource.PixelWidth;
                int originalHeight = bitmapSource.PixelHeight;

                var image = new System.Windows.Controls.Image
                {
                    Source = bitmapSource,
                    Width = originalWidth,
                    Height = originalHeight
                };

                image.Effect = FrameRateReductionPresenter.Effect;
                image.Measure(new Size(originalWidth, originalHeight));
                image.Arrange(new Rect(0, 0, originalWidth, originalHeight));

                var renderTarget = new System.Windows.Media.Imaging.RenderTargetBitmap(
                    originalWidth, originalHeight, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);

                renderTarget.Render(image);
                Clipboard.SetImage(renderTarget);
            }
        }
    }
}