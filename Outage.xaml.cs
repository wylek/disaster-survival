﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DisasSurvivApp
{
    public partial class Outage : PhoneApplicationPage
    {
        public Outage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            currLocField.Text = App.GpsCity1.ToString();
            currLocField.Text += ", " + App.GpsState1.ToString();
        }
    }
}