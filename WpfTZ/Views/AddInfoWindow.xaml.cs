﻿using WpfTZ.ViewModels;
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

namespace WpfTZ.Views
{
    /// <summary>
    /// Логика взаимодействия для AddInfoWindow.xaml
    /// </summary>
    public partial class AddInfoWindow : Window
    {
        public AddInfoWindow()
        {
            InitializeComponent();
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
