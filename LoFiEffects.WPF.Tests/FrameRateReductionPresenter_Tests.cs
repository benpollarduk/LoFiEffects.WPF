using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class FrameRateReductionPresenter_Tests
    {
        [STATestMethod]
        public void GivenNewPresenter_WhenSettingContentToButton_ThenNoExceptionThrown()
        {
            var presenter = new FrameRateReductionPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenSettingFramesPerSecondTo10_ThenNoExceptionThrown()
        {
            var presenter = new FrameRateReductionPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.FramesPerSecond = 10;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenSettingMaskBackgroundToWhite_ThenNoExceptionThrown()
        {
            var presenter = new FrameRateReductionPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.MaskBackground = new SolidColorBrush(Colors.White);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenLoadedWithinWindow_ThenNoExceptionThrownWithin1Second()
        {
            var presenter = new FrameRateReductionPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;

                var window = new Window
                {
                    Content = presenter
                };

                var windowClosed = false;

                DispatcherTimer timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };

                timer.Tick += (sender, args) =>
                {
                    window.Close();
                    timer.Stop();
                    windowClosed = true;
                    Dispatcher.ExitAllFrames();
                };

                window.Show();
                timer.Start();

                Dispatcher.Run();

                Assert.IsTrue(windowClosed);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
