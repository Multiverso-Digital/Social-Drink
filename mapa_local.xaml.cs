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
using System.Globalization;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace Social_Drink
{
    public partial class mapa_local : PhoneApplicationPage
    {
        public mapa_local()
        {
            InitializeComponent();





            eNome.Text = App.LocNomMap;
            string latx = App.LocLatMap.ToString().Replace(",", ".");
            string lonx = App.LocLonMap.ToString().Replace(",", ".");

            GeoCoordinate Geo = new GeoCoordinate();
            Geo.Latitude = Convert.ToDouble(latx, CultureInfo.InvariantCulture);
            Geo.Longitude = Convert.ToDouble(lonx, CultureInfo.InvariantCulture);


            Pushpin pin1 = new Pushpin();
            int zoom = 16;
            pin1.Template = this.Resources["pinMyLoc"] as ControlTemplate;
            pin1.Location = Geo;
            pin1.FontSize = 12;
            pin1.Content += ("Here");
            map1.LogoVisibility = Visibility.Collapsed;
            map1.CopyrightVisibility = Visibility.Collapsed;
            map1.Children.Add(pin1);
            map1.Visibility = Visibility.Visible;
            map1.SetView(Geo, zoom);
            pin1.MouseLeftButtonUp += new MouseButtonEventHandler(Pushpin_MouseLeftButtonUp);       }





        void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Phone.Controls.Maps.Pushpin tempPP = new Microsoft.Phone.Controls.Maps.Pushpin();

            tempPP = (Microsoft.Phone.Controls.Maps.Pushpin)sender;

            // you can check the tempPP.Content property

        }

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new RoadMode();
            
        }

        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new AerialMode();
        }

    }
}