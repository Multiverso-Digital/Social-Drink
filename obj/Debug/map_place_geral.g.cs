﻿#pragma checksum "C:\VS_2010_PRJs\Social Drink\Social Drink\map_place_geral.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C256C6C27FE74AEF3909DFA314DBAFB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.586
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
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


namespace Social_Drink {
    
    
    public partial class map_place_geral : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal System.Windows.Controls.Border MapView;
        
        internal Microsoft.Phone.Controls.Maps.Map map1;
        
        internal System.Windows.Controls.ProgressBar progressBar;
        
        internal System.Windows.Controls.StackPanel popup;
        
        internal System.Windows.Shapes.Rectangle bg;
        
        internal System.Windows.Controls.TextBlock title_txt;
        
        internal System.Windows.Controls.TextBlock address_txt;
        
        internal System.Windows.Controls.TextBlock dist_txt;
        
        internal System.Windows.Controls.Image image3;
        
        internal System.Windows.Controls.Image image4;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Social%20Drink;component/map_place_geral.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.MapView = ((System.Windows.Controls.Border)(this.FindName("MapView")));
            this.map1 = ((Microsoft.Phone.Controls.Maps.Map)(this.FindName("map1")));
            this.progressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("progressBar")));
            this.popup = ((System.Windows.Controls.StackPanel)(this.FindName("popup")));
            this.bg = ((System.Windows.Shapes.Rectangle)(this.FindName("bg")));
            this.title_txt = ((System.Windows.Controls.TextBlock)(this.FindName("title_txt")));
            this.address_txt = ((System.Windows.Controls.TextBlock)(this.FindName("address_txt")));
            this.dist_txt = ((System.Windows.Controls.TextBlock)(this.FindName("dist_txt")));
            this.image3 = ((System.Windows.Controls.Image)(this.FindName("image3")));
            this.image4 = ((System.Windows.Controls.Image)(this.FindName("image4")));
        }
    }
}

