﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace deletepls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int g = 10;
        public double x = 0;
        public double y = 0;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            x += 5;
            y = function(x, 70, 45);

            label1.Content = x.ToString() + ", " + y.ToString();

            Canvas.SetLeft(jim, x);
            Canvas.SetBottom(jim, y);
        }

        public double function(double x, double u, double angle)
        {
            double radians = (Math.PI/180)*angle;

            double y = x * Math.Tan(radians) - ((g * Math.Pow(x, 2)) / (2 * Math.Pow(u, 2) * Math.Pow(Math.Cos(radians), 2)));

            return y;
        }
    }
}
