﻿#pragma checksum "D:\University of Louisville\2011 Spring Semester\CECS 440\DisasSurvivApp\SearchFB.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FB904A7890709D1B0CBAEDB6906EA3A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DisasSurvivApp {
    
    
    public partial class SearchFB : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid ContentGrid;
        
        internal System.Windows.Controls.Grid fbUserGrid;
        
        internal System.Windows.Controls.Button btnLogin;
        
        internal System.Windows.Controls.Button btnGetUserData;
        
        internal System.Windows.Controls.Button btnPostToWall;
        
        internal System.Windows.Controls.Button btnShowFriends;
        
        internal System.Windows.Controls.TextBlock txtStatus;
        
        internal System.Windows.Controls.TextBlock txtError;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DisasSurvivApp;component/SearchFB.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.ContentGrid = ((System.Windows.Controls.Grid)(this.FindName("ContentGrid")));
            this.fbUserGrid = ((System.Windows.Controls.Grid)(this.FindName("fbUserGrid")));
            this.btnLogin = ((System.Windows.Controls.Button)(this.FindName("btnLogin")));
            this.btnGetUserData = ((System.Windows.Controls.Button)(this.FindName("btnGetUserData")));
            this.btnPostToWall = ((System.Windows.Controls.Button)(this.FindName("btnPostToWall")));
            this.btnShowFriends = ((System.Windows.Controls.Button)(this.FindName("btnShowFriends")));
            this.txtStatus = ((System.Windows.Controls.TextBlock)(this.FindName("txtStatus")));
            this.txtError = ((System.Windows.Controls.TextBlock)(this.FindName("txtError")));
        }
    }
}
