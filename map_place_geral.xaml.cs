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
using System.Device.Location;
using System.Globalization;
//using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;
using PushpinClusterer;

namespace Social_Drink
{
    public partial class map_place_geral : PhoneApplicationPage
    {

        private MapLayer pushpinLayer = null;


        double latitude;
        double longitude;
        int LandMarkCount = 0;
        int zoomLevel = 13;
        string LandMarkName = "";
        string LandMarkTitle = "";
        string latx = "";
        string lonx = "";

        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };
        
        
        
        public map_place_geral()
        {
            InitializeComponent();

            LigaDesligaProgress(true, "");
            App.Passou = true;

           // p41header.Header = Localization.m103.ToString();


            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }


            if (pushpinLayer == null)
            {
                pushpinLayer = new MapLayer();
                pushpinLayer.Name = "PushPinLayer";
                map1.Children.Add(pushpinLayer);
            }

            
            //p41header.Header = Localization.p1header;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
           // System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {



            //p41header.Header = Localization.m103.ToString();

            latitude = Convert.ToDouble(App.LatCel, CultureInfo.InvariantCulture);
            longitude = Convert.ToDouble(App.LonCel, CultureInfo.InvariantCulture);
            PlotUserAndLandMarks();
            
            
          

        }






        void PlotUserAndLandMarks()
        {

            //plot user
            Pushpin user = new Pushpin();
            user.Location = new GeoCoordinate(latitude, longitude);
            Image pinImage1 = new Image();


            pinImage1.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/images/taxi2.png", UriKind.Relative));

            map1.Mode = new RoadMode();
            pinImage1.Margin = new Thickness(-69, -52, 0, 0);
           // pinImage1.Opacity = 0.8;
            pinImage1.Stretch = System.Windows.Media.Stretch.None;

            pushpinLayer.AddChild(pinImage1, user.Location);


            map1.SetView(user.Location, zoomLevel);

            //-----------------------------------------------

            //plot landmarks
            for (int i = 0; i < App.LandMarkPositionArray.Length; i++)
            {


                

                App.RssLandMark st = App.LandMarkPositionArray.GetValue(i) as App.RssLandMark;

                if (st != null)
                {

                    if (st.name != null)
                    {

                        Pushpin landMark = new Pushpin();
                        landMark.Location = new GeoCoordinate(Convert.ToDouble(st.latitude, CultureInfo.InvariantCulture), Convert.ToDouble(st.longitude, CultureInfo.InvariantCulture));


                        LandMarkTitle = st.name; 

                        if (st.name.Length > 10)
                        {

                            LandMarkTitle = st.name.Substring(0, 10) + "..";
                        }


                        landMark.Foreground = new SolidColorBrush(Colors.Black);
                        landMark.Background = new SolidColorBrush(Colors.Yellow);
                        landMark.Content = LandMarkTitle;
                        landMark.FontSize = 21;
                        landMark.Opacity = .9;
                        landMark.Tag = i + "";
                        landMark.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(showandMarkDetails_Completed);
                        map1.Children.Add(landMark);
                        LigaDesligaProgress(false, "");
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    break;
                }





            }


            progressBar.IsIndeterminate = false;
            progressBar.Visibility = Visibility.Collapsed;
        }//end of funt

        void showandMarkDetails_Completed(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = Convert.ToInt32((sender as Pushpin).Tag);
            App.RssLandMark st = App.LandMarkPositionArray.GetValue(id) as App.RssLandMark;
            title_txt.Text = st.name;
            address_txt.Text = st.address;
            dist_txt.Text = Localization.ms128 + calcutaleDistance(latitude, longitude, Convert.ToDouble(st.latitude, CultureInfo.InvariantCulture), Convert.ToDouble(st.longitude, CultureInfo.InvariantCulture)) + " " + Localization.ms129;


            popup.Visibility = Visibility.Visible;
            bg.Visibility = Visibility.Visible;

        }//end of funt
        public static string calcutaleDistance(double ulat, double ulon, double lat, double lon)
        {
            var sCoord = new GeoCoordinate(ulat, ulon);
            var eCoord = new GeoCoordinate(lat, lon);

            var R = 6371;
            double lat1 = (sCoord.Latitude) / 180 * Math.PI;
            double lat2 = (eCoord.Latitude) / 180 * Math.PI;

            double lng1 = (sCoord.Longitude) / 180 * Math.PI;
            double lng2 = (eCoord.Longitude) / 180 * Math.PI;

            double dlng = lng2 - lng1;
            double dlat = lat2 - lat1;

            var a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) *
                             Math.Cos(lat2) * Math.Pow(Math.Sin(dlng / 2), 2);
            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));

            var d = R * c;


            return (String.Format("{0:0.00}", d) + " km");
        }//end of funt


        void Close_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {

            popup.Visibility = Visibility.Collapsed;
            bg.Visibility = Visibility.Collapsed;
        }


















        private void MostraMapa()
        {


            /*

            try
            {

                if (App.pins.Count > 0)
                {
                    int zoom = 10;


                    for (int i = 0; i < App.pins.Count; i++)
                    {
                        string latx = ((App.pins[i].Coordinate.Latitude).ToString(CultureInfo.InvariantCulture));
                        string lonx = ((App.pins[i].Coordinate.Longitude).ToString(CultureInfo.InvariantCulture));
                        string laty = latx.Replace(",", ".");
                        string lony = lonx.Replace(",", ".");
                        var sCoord = new GeoCoordinate(Convert.ToDouble(laty, CultureInfo.InvariantCulture), Convert.ToDouble(lony, CultureInfo.InvariantCulture));
                        App.pins[i].Coordinate = sCoord;
                    }

                    map1.SetView(App.pins[App.pins.Count - 1].Coordinate, zoom);
                    map1.ZoomBarVisibility = System.Windows.Visibility.Visible;
                    var clusterer = new PushpinClusterer<MyGeoObject>(map1, App.pins, 1);
        //            pushPinModelsLayer.DataContext = clusterer;
                }

                LigaDesligaProgress(false, "");
                
            }
            catch (Exception ex)
            {
                LigaDesligaProgress(false, "");
                MessageBox.Show(Localization.m02);

            }


            */
        }








        public void LigaDesligaBuzy(bool valor)
        {
        //    this.busyIndicator.IsRunning = valor;
        }





        public void LigaDesligaProgress(bool valor, string texto)
        {
            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }

       

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new RoadMode();
            
        }

        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new AerialMode();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            
        }

    }
}