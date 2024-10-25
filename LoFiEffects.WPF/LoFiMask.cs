using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LoFiEffects.WPF
{
    /// <summary>
    /// Provides a Control that acts a mask to provide a lo-fi effect.
    /// </summary>
    internal class LoFiMask : UserControl, IDisposable
    {
        #region Fields

        private FrameworkElement? source;
        private double reduction = 2;
        private uint framesPerSecond = 60;
        private bool isRendering;
        private RenderTargetBitmap? bitmap;
        private long lastRenderTime;
        private int delayBetweenFrames;
        private Color? maskColor;

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
                Start();
            }
        }

        /// <summary>
        /// Get or set the strength of the reduction. This is a dependency property.
        /// </summary>
        public double Reduction
        {
            get { return reduction; }
            set
            {
                reduction = value;
                AdjustScalingMode();
                Start();
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
                Start();
            }
        }

        /// <summary>
        /// Get or set the mask color. This is a dependency property.
        /// </summary>
        public Color? MaskColor
        {
            get { return maskColor; }
            set
            {
                maskColor = value;
                Start();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LoFiMask class.
        /// </summary>
        public LoFiMask()
        {
            IsHitTestVisible = false;

            AdjustScalingMode();

            // render whenever the size changes
            SizeChanged += (_, _) => RequestRender();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adjust the scaling mode for this control based on the reduction value. Values > 1 will use BitmapScalingMode.NearestNeighbor for a pixelated effect,
        /// values <= 1 will use BitmapScalingMode.HighQuality for a smooth effect.
        /// </summary>
        private void AdjustScalingMode()
        {
            RenderOptions.SetBitmapScalingMode(this, Reduction > 1 ? BitmapScalingMode.NearestNeighbor : BitmapScalingMode.HighQuality);
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

                // calculate the reduced size
                var reductionSize = new Size(Source.ActualWidth / Reduction, Source.ActualHeight / Reduction);

                // ensure that rendering is possible with the current sizes
                if (double.IsNaN(ActualWidth) ||
                    double.IsNaN(ActualHeight) ||
                    double.IsNaN(reductionSize.Width) ||
                    double.IsNaN(reductionSize.Height))
                    return;

                // check if the bitmap can be reused, if not create it
                if (bitmap == null || bitmap.PixelWidth != (int)reductionSize.Width || bitmap.PixelHeight != (int)reductionSize.Height)
                    bitmap = new RenderTargetBitmap((int)reductionSize.Width, (int)reductionSize.Height, 96, 96, PixelFormats.Pbgra32);

                // create a visual to host the lo-fi visual
                var drawingVisual = new DrawingVisual();

                // render the source at the reduced size
                using (var context = drawingVisual.RenderOpen())
                {
                    // if a background color has been specified draw it
                    if (MaskColor.HasValue)
                        context.DrawRectangle(new SolidColorBrush(MaskColor.Value), null, new Rect(new Point(), reductionSize));

                    // draw the source content on top of the background
                    context.DrawRectangle(new VisualBrush(Source), null, new Rect(new Point(), reductionSize));
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
        }

        /// <summary>
        /// Stop processing updates.
        /// </summary>
        private void Stop()
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
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

        #endregion

        #region IDisposable
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Stop();
        }

        #endregion
    }
}
