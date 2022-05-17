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
    public partial class LocalDetail : PhoneApplicationPage
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









       








        public LocalDetail()
        {
            InitializeComponent();


            App.Passou = true;

            ApplicationTitle.Text = App.LocName; 
            
            string latx = App.LocLat.ToString().Replace(",", ".");
            string lonx =  App.LocLon.ToString().Replace(",", ".");

                m900.Visibility = Visibility.Collapsed;
                m890.Visibility = Visibility.Collapsed;
                tfotos.Visibility = Visibility.Collapsed;
                ttips.Visibility = Visibility.Collapsed;
                tespecial.Visibility = Visibility.Collapsed;
                img_foto.Visibility = Visibility.Collapsed;
                img_tips.Visibility = Visibility.Collapsed;
                img_especial.Visibility = Visibility.Collapsed;

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
            catch
            {

            }




            PegaFS();
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


        private void PegaFS()
        {

          
            ligadesliga_tray(true, Localization.ms125);
            ligadesliga_busy(true);

            try
            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri(App.LocRefe + "?client_id=WYVK3C5JYYSKWLYKMHZFQUAGZYXRBAFXMLARQHLJBFFC05IX&client_secret=GJO5FLB20ZI03LLYBEBST55NI5OMLPG4IRIHXRBPLYB1S4M3&v=20121116"));

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                this.NavigationService.GoBack();
                

                return;
            }

        }


        void getFS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {



            try
            {

                if (e.Error != null)
                {
                    MessageBox.Show(Localization.fsserver);
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false);
                    this.NavigationService.GoBack();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }





            try
            {
                App.ResultFS = JsonConvert.DeserializeObject<App.RootObject>(e.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }


            try
            {
                tende.Text = App.ResultFS.response.venue.location.address + " " + App.ResultFS.response.venue.location.city;
            }
            catch
            {
                tende.Text = "";
            }


            try
            {
                ttel.Text = App.ResultFS.response.venue.contact.formattedPhone;
            }
            catch
            {
                ttel.Text = "";
            }

           

            try
            {
                trat.Text = App.ResultFS.response.venue.rating.ToString();
            }
            catch
            {
                trat.Text = "";
            }





            try
            {


                if (App.ResultFS.response.venue.photos.count > 0)
                {
                    tfotos.Text = (App.ResultFS.response.venue.photos.count - 1).ToString();
                }
                else
                {
                    tfotos.Text = "0";
                }
            }
            catch
            {
                tfotos.Text = "0";
            }


            try
            {
                if (App.ResultFS.response.venue.tips.count > 0)
                {
                    ttips.Text = (App.ResultFS.response.venue.tips.count - 1).ToString();

                }
                else
                {
                    ttips.Text = "0";
                }
            }
            catch
            {
                ttips.Text = "0";
            }


            


            try
            {


                tespecial.Text = App.ResultFS.response.venue.specials.items.Count.ToString();
            }
            catch
            {
                tespecial.Text = "";
            }














            FSTerminou = true;
            ligadesliga_tray(false, "");
            ligadesliga_busy(false);


            m890.Visibility = Visibility.Visible;


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

            if (tespecial.Text != "0")
            {

                tespecial.Visibility = Visibility.Visible;
                img_especial.Visibility = Visibility.Visible;
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


            this.NavigationService.Navigate(new Uri("/FS_Foto.xaml", UriKind.RelativeOrAbsolute)); 
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

            this.NavigationService.Navigate(new Uri("/FS_Tips.xaml", UriKind.RelativeOrAbsolute)); 

        }

        private void img_especial_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }



            this.NavigationService.Navigate(new Uri("/FS_Especial.xaml", UriKind.RelativeOrAbsolute)); 
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
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }


        }


    }
}