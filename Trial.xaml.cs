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
using Microsoft.Phone.Tasks;

namespace Social_Drink
{
    public partial class Trial : PhoneApplicationPage



    {


        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();

        public Trial()
        {
            InitializeComponent();

            // Declare the MarketplaceDetailTask object with page scope
            // so we can access it from event handlers.
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            _marketPlaceDetailTask.Show();




        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            App.TrialCancel = true;
            NavigationService.GoBack();
        }
    }
}