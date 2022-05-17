using System;
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

namespace Social_Drink
{
    public partial class EstaMenu : PhoneApplicationPage
    {
        public EstaMenu()
        {
            InitializeComponent();
        }

        private void rectangle1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_drinks.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_check.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_top50.xaml", UriKind.RelativeOrAbsolute));
           
        }

        private void rectangle5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_top50_drink.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}