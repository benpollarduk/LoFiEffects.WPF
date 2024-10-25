using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class LoFiPresenter_Tests
    {
        [STATestMethod]
        public void GivenNewPresenter_WhenSettingContentToButton_ThenNoExceptionThrown()
        {
            var presenter = new LoFiPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenSettingReductionTo10_ThenNoExceptionThrown()
        {
            var presenter = new LoFiPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.Reduction = 10;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenSettingFramesPerSecondTo10_ThenNoExceptionThrown()
        {
            var presenter = new LoFiPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.FramesPerSecond = 10;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenSettingMaskColorToBlack_ThenNoExceptionThrown()
        {
            var presenter = new LoFiPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.MaskColor = Colors.Black;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenDispose_ThenNoExceptionThrown()
        {
            var presenter = new LoFiPresenter();
            var button = new Button();

            try
            {
                presenter.Content = button;
                presenter.Dispose();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }

        [STATestMethod]
        public void GivenPresenterContainingButton_WhenLoadedWithinWindow_ThenNoExceptionThrownWithin1Second()
        {
            var presenter = new LoFiPresenter();
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
                Assert.Fail($"Expected occurred: {ex.Message}");
            }
        }
    }
}
