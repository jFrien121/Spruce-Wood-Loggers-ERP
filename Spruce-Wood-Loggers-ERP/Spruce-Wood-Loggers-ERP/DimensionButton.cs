using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

/**
 * DimensionButton
 * Custom Button class to allow buttons in the grid to
 * hold properties for thickness, width, and height
 */

namespace Spruce_Wood_Loggers_ERP
{
    public class DimensionButton : Button
    {

        public double CutThickness
        {
            get => (double)GetValue(CutThicknessProperty);
            set => SetValue(CutThicknessProperty, value);
        }

        public static readonly DependencyProperty CutThicknessProperty =
            DependencyProperty.Register(
                nameof(CutThickness),
                typeof(double),
                typeof(DimensionButton),
                new PropertyMetadata(0.0));

        public double CutWidth
        {
            get => (double)GetValue(CutWidthProperty);
            set => SetValue(CutWidthProperty, value);
        }

        public static readonly DependencyProperty CutWidthProperty =
            DependencyProperty.Register(
                nameof(CutWidth),
                typeof(double),
                typeof(DimensionButton),
                new PropertyMetadata(0.0));

        public double CutLength
        {
            get => (double)GetValue(CutLengthProperty);
            set => SetValue(CutLengthProperty, value);
        }

        public static readonly DependencyProperty CutLengthProperty =
            DependencyProperty.Register(
                nameof(CutLength),
                typeof(double),
                typeof(DimensionButton),
                new PropertyMetadata(0.0));
    }
}
