#pragma checksum "C:\VS_2010_PRJs\Social Drink\Social Drink\add_local.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "83E64E3E6ACFC8F4B821F8A5D8DE145D"
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
using Telerik.Windows.Controls;


namespace Social_Drink {
    
    
    public partial class add_local : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox eNomelocal;
        
        internal System.Windows.Controls.TextBlock novloc_nomelocal;
        
        internal Telerik.Windows.Controls.RadBusyIndicator busyIndicator;
        
        internal System.Windows.Controls.TextBox eAddress;
        
        internal System.Windows.Controls.TextBlock nov_loc_ende;
        
        internal Telerik.Windows.Controls.RadListPicker eSel;
        
        internal System.Windows.Controls.TextBlock nov_loc_aviso;
        
        internal System.Windows.Controls.TextBox eLat;
        
        internal System.Windows.Controls.TextBox eLon;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        internal System.Windows.Controls.TextBlock textBlock3;
        
        internal System.Windows.Controls.Button button1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Social%20Drink;component/add_local.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.eNomelocal = ((System.Windows.Controls.TextBox)(this.FindName("eNomelocal")));
            this.novloc_nomelocal = ((System.Windows.Controls.TextBlock)(this.FindName("novloc_nomelocal")));
            this.busyIndicator = ((Telerik.Windows.Controls.RadBusyIndicator)(this.FindName("busyIndicator")));
            this.eAddress = ((System.Windows.Controls.TextBox)(this.FindName("eAddress")));
            this.nov_loc_ende = ((System.Windows.Controls.TextBlock)(this.FindName("nov_loc_ende")));
            this.eSel = ((Telerik.Windows.Controls.RadListPicker)(this.FindName("eSel")));
            this.nov_loc_aviso = ((System.Windows.Controls.TextBlock)(this.FindName("nov_loc_aviso")));
            this.eLat = ((System.Windows.Controls.TextBox)(this.FindName("eLat")));
            this.eLon = ((System.Windows.Controls.TextBox)(this.FindName("eLon")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
            this.textBlock3 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock3")));
            this.button1 = ((System.Windows.Controls.Button)(this.FindName("button1")));
        }
    }
}

