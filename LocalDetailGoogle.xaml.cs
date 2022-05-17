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
using RestSharp;
using System.Globalization;
using System.IO;
using System.Linq;
//using findfood;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Tasks;


namespace Social_Drink
{
    public partial class LocalDetailGoogle : PhoneApplicationPage
    {

        GeoCoordinate Geo = new GeoCoordinate();

        public bool podepegar = false;
        public int Inicia = 0;
        public int AjusteHorizontal = 100;
        public int loop = 0;
        public int conta = 0;
        public int ind = 0;
        public double distancia = 0;
        public double distanciax = 0;

        public string latx = "";
        public string lonx = "";
        public string pais = "";
        public string cida = "";
        public string espe = "";
        public int checkin = 0;
        public string iconespe = "";
        public string tipox = "";
        public string icon = "";
        public bool achou = false;
        public bool primeira = false;


        public bool nokiaTerminou = false;
        public bool FSTerminou = false;
        public bool googleTerminou = false;




        public int LandMarkCount = 0;
        public int LandMarkCount1 = 0;
        public int LandMarkCount2 = 0;









       








        public LocalDetailGoogle()
        {
            InitializeComponent();


            App.Passou = true;

            ApplicationTitle.Text = App.LocName; 
            
            string latx = App.LocLat.ToString().Replace(",", ".");
            string lonx =  App.LocLon.ToString().Replace(",", ".");

            m900.Visibility = Visibility.Collapsed;
            tfotos.Visibility = Visibility.Collapsed;
            ttips.Visibility = Visibility.Collapsed;
            img_foto.Visibility = Visibility.Collapsed;
            img_tips.Visibility = Visibility.Collapsed;
    
            try
            {

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
                //pin1.MouseLeftButtonUp += new MouseButtonEventHandler(Pushpin_MouseLeftButtonUp);       }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }





            PegaGoogle();
        }



        public ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };



        public void ligadesliga_busy(bool valor)
        {

            busyIndicator.Content = Localization.busyIndicator.ToString();
     //       ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = !valor;
     //       ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = !valor;

            this.busyIndicator.IsRunning = valor;
        }

        public void ligadesliga_tray(bool valor, string texto)
        {

            SystemTray.IsVisible = valor;

            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }


        private void PegaGoogle()
        {

          
            ligadesliga_tray(true, Localization.ms125);
            ligadesliga_busy(true);


        


            try
            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri(App.LocRefe + "&sensor=true&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4"));

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }

        }


        void getFS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {



            try
            {

                if (e.Error != null)
                {
                    MessageBox.Show(Localization.googleserver);
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }



            try
            {
                App.ResultGoogle = JsonConvert.DeserializeObject<App.RootObjectGoogle>(e.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }



            try
            {
                tende.Text = App.LocAddress;
            }
            catch
            {
                tende.Text = "";
            }

            try
            {
                ttel.Text = App.ResultGoogle.result.formatted_phone_number;
            }
            catch
            {
                ttel.Text = "";
            }



            try
            {
                tfotos.Text = App.ResultGoogle.result.photos.Count.ToString();
            }
            catch
            {
                tfotos.Text = "0";
            }


            try
            {

                ttips.Text = App.ResultGoogle.result.reviews.Count.ToString();
            }
            catch
            {
                ttips.Text = "0";
            }



            try
            {
                tuser.Text = App.Checkin.ToString();
            }
            catch
            {
                tuser.Text = "";
            }






            FSTerminou = true;
            ligadesliga_tray(false, "");
            ligadesliga_busy(false);



            if (tfotos.Text != "0")
            {
                tfotos.Visibility = Visibility.Visible;
                img_foto.Visibility = Visibility.Visible;
                m900.Visibility = Visibility.Visible;
            }


            if (ttips.Text != "0")
            {
                img_tips.Visibility = Visibility.Visible;
                ttips.Visibility = Visibility.Visible;
                m900.Visibility = Visibility.Visible;
            }

   

           
    }










        private void img_foto_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (tfotos.Text == "0")
            {

                MessageBox.Show("No photos for this place.");
                return;
            }

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }




            this.NavigationService.Navigate(new Uri("/Google_Foto.xaml", UriKind.RelativeOrAbsolute)); 
        }

        private void img_tips_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (ttips.Text == "0")
            {

                MessageBox.Show("No reviews for this place.");
                return;
            }


            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }




            this.NavigationService.Navigate(new Uri("/Google_Tips.xaml", UriKind.RelativeOrAbsolute)); 

        }

        private void img_especial_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*
            if (tespecial.Text == "0")
            {

                MessageBox.Show("No specials for this place.");
                return;
            }
            */

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }



            this.NavigationService.Navigate(new Uri("/Google_Especial.xaml", UriKind.RelativeOrAbsolute)); 
        }

        private void map1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            OpenDirectionTo();
        }


        private void OpenDirectionTo()
        {


            try
            {

                BingMapsDirectionsTask directionTask = new BingMapsDirectionsTask();

                directionTask.Start = new LabeledMapLocation("You", App.LocCel);
                directionTask.End = new LabeledMapLocation(App.LocName, Geo);
                directionTask.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }

        }


    }
}