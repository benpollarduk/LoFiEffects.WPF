using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LoFiEffects.WPF
{
    /// <summary>
    /// Provides a control that acts a mask to provide a frame rate reduction effect.
    /// </summary>
    internal class FrameRateReductionMask : UserControl, IDisposable
    {
        #region Constants

        /// <summary>
        /// Get the minimum frames per second.
        /// </summary>
        private const int MinimumFramesPerSecond = 0;

        /// <summary>
        /// Get the maximum frames per second.
        /// </summary>
        private const int MaximumFramesPerSecond = 60;

        #endregion

        #region Fields

        private FrameworkElement? source;
        private uint framesPerSecond = MaximumFramesPerSecond;
        private bool isRendering;
        private RenderTargetBitmap? bitmap;
        private long lastRenderTime;
        private int delayBetweenFrames;
        private readonly VisualBrush visualBrush = new();
        private readonly DrawingVisual drawingVisual = new();
        private readonly Point topLeft = new(0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the source for the mask. This is a dependency property.
        /// </summary>
        public FrameworkElement? Source
        {
            get { return source; }
            set
            {
                source = value;
                RunIfNeeded();
            }
        }

        /// <summary>
        /// Get or set the number of frames per second the mask updates at. This is a dependency property.
        /// </summary>
        public uint FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                framesPerSecond = value;
                RunIfNeeded();
            }
        }

        /// <summary>
        /// Get or set mask background. This is a dependency property.
        /// </summary>
        public Brush MaskBackground { get; set; } = new SolidColorBrush(Colors.Transparent);

        #endregion

        #region ConstructionDestruction

        /// <summary>
        /// Initializes a new instance of the FrameRateReductionMask class.
        /// </summary>
        public FrameRateReductionMask()
        {
            IsHitTestVisible = false;
        }

        ~FrameRateReductionMask()
        {
            Dispose();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Run the effect, if needed.
        /// </summary>
        private void RunIfNeeded()
        {
            if (Source != null && FramesPerSecond >= MinimumFramesPerSecond && FramesPerSecond < MaximumFramesPerSecond)
                Start();
            else
                Stop();
        }

        /// <summary>
        /// Request a render operation of the mask.
        /// </summary>
        private void RequestRender()
        {
            try
            {
                isRendering = true;
                lastRenderTime = Environment.TickCount;

                if (Source == null)
                    return;

                // ensure that rendering is possible with the current sizes
                if (double.IsNaN(ActualWidth) ||
                    double.IsNaN(ActualHeight))
                    return;

                // get size
                Size size = new(ActualWidth, ActualHeight);

                // check if the bitmap can be reused, if not create it
                if (bitmap == null || bitmap.PixelWidth != (int)size.Width || bitmap.PixelHeight != (int)size.Height)
                    bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

                // clear visual
                drawingVisual.Children.Clear();

                // render the source at the reduced size
                using (var context = drawingVisual.RenderOpen())
                {
                    // draw the background
                    context.DrawRectangle(MaskBackground, null, new Rect(topLeft, size));

                    // set visual
                    visualBrush.Visual = Source;

                    // draw the source content on top of the background
                    context.DrawRectangle(visualBrush, null, new Rect(topLeft, size));
                }

                // render the visual in the bitmap
                bitmap.Render(drawingVisual);

                // render the lo-fi bitmap as the background of the mask
                Background = new ImageBrush(bitmap);
            }
            catch (TaskCanceledException)
            {
                // these can occur if the timer is stopped during a render
            }
            catch (ObjectDisposedException)
            {
                // these can occur if the timer is disposed during a render
            }
            finally
            {
                isRendering = false;
            }
        }

        /// <summary>
        /// Start processing updates.
        /// </summary>
        private void Start()
        {
            Stop();
            delayBetweenFrames = (int)(1000 / FramesPerSecond);
            
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            SizeChanged += FrameRateReductionMask_SizeChanged;
        }

        /// <summary>
        /// Stop processing updates.
        /// </summary>
        private void Stop()
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            SizeChanged -= FrameRateReductionMask_SizeChanged;

            if (bitmap != null)
                bitmap = null;

            Background = null;
        }

        #endregion

        #region EventHandlers

        private void CompositionTarget_Rendering(object? sender, EventArgs e)
        {
            if (isRendering)
                return;

            if (Environment.TickCount - lastRenderTime < delayBetweenFrames)
                return;
            
            RequestRender();
        }

        private void FrameRateReductionMask_SizeChanged(object ? sender, EventArgs e)
        {
            RequestRender();
        }

        #endregion

        #region IDisposable
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Stop();

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
