﻿using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StackOverflowAnswers.Wpf
{
    public class HeatMapViewModel
    {
        public List<double> HeatMapSeries { get; set; } = new List<double>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9
        };
    }

    /// <summary>
    /// Interaction logic for LiveChartsFormatting.xaml
    /// </summary>
    public partial class LiveChartsFormatting : Window
    {

        public LiveChartsFormatting()
        {
            InitializeComponent();

            var r = new Random();

            Values = new ChartValues<HeatPoint>
            {
                //X means sales man
                //Y is the day
 
                //"Jeremy Swanson"
                new HeatPoint(0, 0, r.Next(0, 10)),
                new HeatPoint(0, 1, r.Next(0, 10)),
                new HeatPoint(0, 2, r.Next(0, 10)),
                new HeatPoint(0, 3, r.Next(0, 10)),
                new HeatPoint(0, 4, r.Next(0, 10)),
                new HeatPoint(0, 5, r.Next(0, 10)),
                new HeatPoint(0, 6, r.Next(0, 10)),
 
                //"Lorena Hoffman"
                new HeatPoint(1, 0, r.Next(0, 10)),
                new HeatPoint(1, 1, r.Next(0, 10)),
                new HeatPoint(1, 2, r.Next(0, 10)),
                new HeatPoint(1, 3, r.Next(0, 10)),
                new HeatPoint(1, 4, r.Next(0, 10)),
                new HeatPoint(1, 5, r.Next(0, 10)),
                new HeatPoint(1, 6, r.Next(0, 10)),
 
                //"Robyn Williamson"
                new HeatPoint(2, 0, r.Next(0, 10)),
                new HeatPoint(2, 1, r.Next(0, 10)),
                new HeatPoint(2, 2, r.Next(0, 10)),
                new HeatPoint(2, 3, r.Next(0, 10)),
                new HeatPoint(2, 4, r.Next(0, 10)),
                new HeatPoint(2, 5, r.Next(0, 10)),
                new HeatPoint(2, 6, r.Next(0, 10)),
 
                //"Carole Haynes"
                new HeatPoint(3, 0, r.Next(0, 10)),
                new HeatPoint(3, 1, r.Next(0, 10)),
                new HeatPoint(3, 2, r.Next(0, 10)),
                new HeatPoint(3, 3, r.Next(0, 10)),
                new HeatPoint(3, 4, r.Next(0, 10)),
                new HeatPoint(3, 5, r.Next(0, 10)),
                new HeatPoint(3, 6, r.Next(0, 10)),
 
                //"Essie Nelson"
                new HeatPoint(4, 0, r.Next(0, 10)),
                new HeatPoint(4, 1, r.Next(0, 10)),
                new HeatPoint(4, 2, r.Next(0, 10)),
                new HeatPoint(4, 3, r.Next(0, 10)),
                new HeatPoint(4, 4, r.Next(0, 10)),
                new HeatPoint(4, 5, r.Next(0, 10)),
                new HeatPoint(4, 6, r.Next(0, 10))
            };

            Days = new[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            SalesMan = new[]
            {
                "Jeremy Swanson",
                "Lorena Hoffman",
                "Robyn Williamson",
                "Carole Haynes",
                "Essie Nelson"
            };

            DataContext = this;
        }

        public ChartValues<HeatPoint> Values { get; set; }
        public string[] Days { get; set; }
        public string[] SalesMan { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            foreach (var chartValue in Values)
            {
                chartValue.Weight = r.Next(0, 10);
            }
        }
    }
}
