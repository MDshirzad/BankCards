﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        public Data()
        {
            InitializeComponent();
        }
        private void CloseButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Tag != null)
            {
                var data = (this.Tag as DataTable);
                foreach (var item in data.Rows)
                {
                   
                }
            }

        }
    }
}
