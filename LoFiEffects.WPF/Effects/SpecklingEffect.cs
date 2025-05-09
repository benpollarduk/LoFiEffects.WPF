﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LoFiEffects.WPF.Effects
{
    /// <summary>
    /// Represents a speckling shader effect.
    /// </summary>
    public abstract class SpecklingEffect : ShaderEffect
    {
        #region Properties

        /// <summary>
        /// Get or set the input. This is a dependency property.
        /// </summary>
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>
        /// Get or set the density. Higher values will produce more speckling. This is a dependency property.
        /// </summary>
        public double Density
        {
            get { return (double)GetValue(DensityProperty); }
            set { SetValue(DensityProperty, value); }
        }

        /// <summary>
        /// Get or set the intensity. Higher values will produce more intense speckling. This is a dependency property.
        /// </summary>
        public double Intensity
        {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }

        /// <summary>
        /// Get or set the offset. This value can modified to produce different speckling patterns. This is a dependency property.
        /// </summary>
        public double Offset
        {
            get { return (double)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        /// <summary>
        /// Get or set if the effect should be rendered over transparency. This is a dependency property.
        /// </summary>
        public bool RenderOverTransparent
        {
            get { return (bool)GetValue(RenderOverTransparentProperty); }
            set { SetValue(RenderOverTransparentProperty, value); }
        }

        /// <summary>
        /// Get or set if the effect should be rendered over transparency. This is a dependency property.
        /// </summary>
        protected double RenderOverTransparentDouble
        {
            get { return (double)GetValue(RenderOverTransparentDoubleProperty); }
            set { SetValue(RenderOverTransparentDoubleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the SpecklingEffect.Input property.
        /// </summary>
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(SpecklingEffect), 0);

        /// <summary>
        /// Identifies the SpecklingEffect.Density property.
        /// </summary>
        public static readonly DependencyProperty DensityProperty = DependencyProperty.Register("Density", typeof(double), typeof(SpecklingEffect), new UIPropertyMetadata(0.3, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Identifies the SpecklingEffect.Intensity property.
        /// </summary>
        public static readonly DependencyProperty IntensityProperty = DependencyProperty.Register("Intensity", typeof(double), typeof(SpecklingEffect), new UIPropertyMetadata(0.8, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Identifies the SpecklingEffect.Offset property.
        /// </summary>
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(double), typeof(SpecklingEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Identifies the SpecklingEffect.RenderOverTransparent property.
        /// </summary>
        public static readonly DependencyProperty RenderOverTransparentProperty = DependencyProperty.Register("RenderOverTransparent", typeof(bool), typeof(SpecklingEffect), new PropertyMetadata(false, new PropertyChangedCallback(OnRenderOverTransparentPropertyChanged)));

        /// <summary>
        /// Identifies the SpecklingEffect.RenderOverTransparentDouble property.
        /// </summary>
        public static readonly DependencyProperty RenderOverTransparentDoubleProperty = DependencyProperty.Register("RenderOverTransparentDouble", typeof(double), typeof(SpecklingEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(3)));

        #endregion

        #region StaticMethods

        private static void OnRenderOverTransparentPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var degrade = obj as SpecklingEffect;

            if (degrade == null)
                return;

            degrade.RenderOverTransparentDouble = (bool)args.NewValue ? 1.0 : 0.0;
        }

        #endregion
    }
}
