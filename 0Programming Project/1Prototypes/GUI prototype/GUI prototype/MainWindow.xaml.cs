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

namespace GUI_prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int increment = 0;

        public MainWindow()
        {
            InitializeComponent();
            fireButton.Click += clicked;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            messageBox.AppendText(increment.ToString());
            messageBox.ScrollToEnd();
            increment++;
        }
    }
}
