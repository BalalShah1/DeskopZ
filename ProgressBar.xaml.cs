﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ProgressBar : UserControl
    {
        public static readonly DependencyProperty IndicatorBrushProperty = DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(ProgressBar));

        public Brush IndicatorBrush
        {
            get { return (Brush)this.GetValue(IndicatorBrushProperty); }
            set { this.SetValue(IndicatorBrushProperty, value); }
        }

        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(ProgressBar));

        public Brush BackgroundBrush
        {
            get { return (Brush)this.GetValue(BackgroundBrushProperty); }
            set { this.SetValue(BackgroundBrushProperty, value); }
        }

        public static readonly DependencyProperty ProgressBrushBrushProperty = DependencyProperty.Register("ProgressBorderBrush", typeof(Brush), typeof(ProgressBar));

        public Brush ProgressBorderBrush
        {
            get { return (Brush)this.GetValue(ProgressBrushBrushProperty); }
            set { this.SetValue(ProgressBrushBrushProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(ProgressBar));

        public int Value
        {
            get { return (int)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }



        public ProgressBar()
        {
            InitializeComponent();
        }
    }

    [ValueConversion(typeof(int), typeof(double))]
    public class ValueToAngle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)(((int)value * 0.01) * 360);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)(((double)value / 360) * 100);
        }
    }
}
