﻿#pragma checksum "D:\University of Louisville\2011 Spring Semester\CECS 440\DisasSurvivApp\Outage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FA920B7B8EDB107C9BC82E96700AB6CF"
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
    
    
    public partial class Outage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.Button newOutButton;
        
        internal System.Windows.Controls.Button checkStatButton;
        
        internal System.Windows.Controls.Button cancelRepButton;
        
        internal System.Windows.Controls.TextBlock currLocField;
        
        internal System.Windows.Controls.ListBox companyList;
        
        internal System.Windows.Controls.TextBlock textBlock1_Copy;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DisasSurvivApp;component/Outage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.newOutButton = ((System.Windows.Controls.Button)(this.FindName("newOutButton")));
            this.checkStatButton = ((System.Windows.Controls.Button)(this.FindName("checkStatButton")));
            this.cancelRepButton = ((System.Windows.Controls.Button)(this.FindName("cancelRepButton")));
            this.currLocField = ((System.Windows.Controls.TextBlock)(this.FindName("currLocField")));
            this.companyList = ((System.Windows.Controls.ListBox)(this.FindName("companyList")));
            this.textBlock1_Copy = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1_Copy")));
        }
    }
}

