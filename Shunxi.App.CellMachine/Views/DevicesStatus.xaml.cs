﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Shunxi.App.CellMachine.Controls;
using Shunxi.App.CellMachine.ViewModels;
using Shunxi.Business.Enums;
using Shunxi.Business.Logic;
using Shunxi.Business.Logic.Controllers;
using Shunxi.Business.Models;
using Shunxi.Business.Models.cache;
using Shunxi.Common.Log;

namespace Shunxi.App.CellMachine.Views
{
    /// <summary>
    /// DevicesStatus.xaml 的交互逻辑
    /// </summary>
    public partial class DevicesStatus : UserControl
    {
        private DispatcherTimer xTimer;
        public DevicesStatus()
        {
            InitializeComponent();
            this.Loaded += DevicesStatus_Loaded; ;
            this.Unloaded += DevicesStatus_Unloaded; ;
        }

        private void DevicesStatus_Unloaded(object sender, RoutedEventArgs e)
        {
            if (xTimer == null) return;

            xTimer.Stop();
            xTimer.Tick -= XTimer_Tick;
        }

        private void DevicesStatus_Loaded(object sender, RoutedEventArgs e)
        {
            xTimer = new DispatcherTimer();
            xTimer.Interval = TimeSpan.FromSeconds(1);
            xTimer.Tick += XTimer_Tick;
            xTimer.Start();
        }

        private void XTimer_Tick(object sender, object e)
        {
            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ImgLeft_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            rootGd.ColumnDefinitions[0].Width = new GridLength(0D);
           
            imgLeft.Visibility = Visibility.Collapsed;
            imgRight.Visibility = Visibility.Visible;
        }

        private void ImgRight_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            rootGd.ColumnDefinitions[0].Width = new GridLength(210D);
            imgLeft.Visibility = Visibility.Visible;
            imgRight.Visibility = Visibility.Collapsed;
        }

        private void BtnManual_OnClick(object sender, RoutedEventArgs e)
        {
            var manual = new ManualSet();
            manual.ShowDialog();
        }
    }
}
