using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using System.Globalization;
using System.Threading;
using System.Device.Location;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.IO;
using System.Windows.Resources;
using System.Text;
using Microsoft.Phone;
using Microsoft.Phone.Controls.Maps;




namespace Social_Drink
{
    public partial class add_local : PhoneApplicationPage
    {
       
        GeoCoordinateWatcher gcw;
       
        BitmapImage imgSource;


        string pais = null;
        string cida = null;
        string iconw = null;

   //     GeocodeServiceClient geocodeService = null;
        private static List<local> Locais = new List<local>();

      

        public int AjusteHorizontal = 0;
        public int Inicia = 0;
        public int loop = 0;

        double latitude = 0;
        double longitude = 0;
        bool JaExiste = false;

        int conta = 0;
        bool podepegar = false;

        string latx = "";
        string lonx = "";


 //       String ApplicationId = "ApIlk15OooGYg6FY_vklyYbcEjeg9kwIILFZKux6s7JZXT5tSo9k066YfZOImtuy";




        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = "GPS acessing. Waiting!..."
        };






        public add_local()
        {
            InitializeComponent();
            if (App.LatCel != null)
            {

                eLat.Text = "0";
                eLon.Text = "0";
            }
            else
            {
                eLat.Text = "0";
                eLon.Text = "0";
                App.LatCel = "0";
                App.LonCel = "0";



            }


           
            



          //  App.CatCod = "450";
          //  App.CatSel = "Bars";

          





            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_save.ToString();

            eSel.Header = Localization.nov_loc_sel;



            busyIndicator.Content = Localization.busyIndicator;
     //       LoadLandMarkList(App.latitude, App.longitude);




            //pega_lista();
           
        }





        public class local
        {
            public string DisplayName { get; set; } 
            public string Ende { get; set; }
            public string Cida { get; set; }
            public string UF { get; set; }
            public string Pais { get; set; }
            public string CEP  { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
            public string Fone { get; set; } 
        }





        public void ligadesliga_tray(bool valor, string texto)
        {
            
            


            this.Dispatcher.BeginInvoke(() => { progress1.IsVisible = valor; });
            this.Dispatcher.BeginInvoke(() => { progress1.IsIndeterminate = valor; });
            this.Dispatcher.BeginInvoke(() => { progress1.Text = texto; });
            this.Dispatcher.BeginInvoke(() => { SystemTray.SetProgressIndicator(this, progress1); });

            

            




        }


        private void eNomelocal_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }




 /*       


        private void MakeGeocodeRequest(GeoCoordinate localizacao)
        {

            string Results = "";

            try
            {
                ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();

                // Set the credentials using a valid Bing Maps key
                reverseGeocodeRequest.Credentials = new Credentials();
                reverseGeocodeRequest.Credentials.ApplicationId = ApplicationId;
                reverseGeocodeRequest.Location = localizacao;


                GeocodeServiceClient geocodeService = new GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
                geocodeService.ReverseGeocodeCompleted += new EventHandler<ReverseGeocodeCompletedEventArgs>(geocodeService_ReverseGeocodeCompleted);
                geocodeService.ReverseGeocodeAsync(reverseGeocodeRequest);
            }

            catch (Exception ex)
              {
               Results = "An exception occurred: " + ex.Message;
              }

            



        }


        private void geocodeService_ReverseGeocodeCompleted(object sender, ReverseGeocodeCompletedEventArgs e)
        {
            GeocodeResponse geocodeResponse = e.Result;

            Pushpin pin1 = new Pushpin();

            Locais.Clear();
            
            if (geocodeResponse.Results.Count > 0)
            {

             


                for (int i = 0; i < geocodeResponse.Results.Count; i++)
                {

                    Locais.Add(new local() { DisplayName = geocodeResponse.Results[i].DisplayName, Ende = geocodeResponse.Results[i].Address.AddressLine, Cida = geocodeResponse.Results[i].Address.Locality, Pais = geocodeResponse.Results[i].Address.CountryRegion, CEP = geocodeResponse.Results[i].Address.PostalCode, UF = geocodeResponse.Results[i].Address.AdminDistrict, Lat = geocodeResponse.Results[i].Locations[0].Latitude, Lon = geocodeResponse.Results[i].Locations[0].Longitude });

           


                    pin1.Content += ("DisplayName: " + geocodeResponse.Results[i].DisplayName) + System.Environment.NewLine;
                    pin1.Content += ("Address.AddressLine: " + geocodeResponse.Results[i].Address.AddressLine) + System.Environment.NewLine;
                    pin1.Content += ("Address.AdminDistrict: " + geocodeResponse.Results[i].Address.AdminDistrict) + System.Environment.NewLine;
                    pin1.Content += ("Address.CountryRegion: " + geocodeResponse.Results[i].Address.CountryRegion) + System.Environment.NewLine;
                    pin1.Content += ("Address.Locality: " + geocodeResponse.Results[i].Address.Locality) + System.Environment.NewLine;
                    pin1.Content += ("Address.PostalCode: " + geocodeResponse.Results[i].Address.PostalCode) + System.Environment.NewLine;
                    pin1.Content += ("EntityType: " + geocodeResponse.Results[i].EntityType.ToString()) + System.Environment.NewLine;
                    pin1.Content += ("EntityType: " + geocodeResponse.Results[i].Locations[0].Latitude.ToString()) + System.Environment.NewLine;
                    pin1.Content += ("EntityType: " + geocodeResponse.Results[i].Locations[0].Longitude.ToString()) + System.Environment.NewLine;

                      
                  

                }
            }
            else
            {
                pin1.Content = "No result, fault: " + geocodeResponse.ResponseSummary.FaultReason + System.Environment.NewLine;
            }


        }

     */   


        /*


        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //this.SaveState(e);      

        }






        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            if (App.Confirmou == true)
            {

                eNomelocal.Text = App.LocName;
                eAddress.Text   = App.LocAddress;
                App.LocLat = App.LocLatG;
                App.LocLon = App.LocLonG;

             //   eLat.Text = "Lat: " + App.LocLat;
            //    eLon.Text = "Lon: " + App.LocLon; 

                eNomelocal.IsReadOnly = true;
                eAddress.IsReadOnly = true;


            }

            if ((App.CatSel != null) && (App.CatCod != null))
            {
               
                ApplicationBar.IsVisible = true;
            }
            else
            {

            }
                        

            base.OnNavigatedTo(e);

        }


        */

        public void ligadesliga_busy(bool valor)
        {

            this.Dispatcher.BeginInvoke(() => { this.busyIndicator.IsRunning = valor; });
            
        }

        /*
        public void ligadesliga_tray(bool valor, string texto)
        {
            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }
        */

        /*

        public void pega_lista()
        {
            if (gcw != null)
                gcw.Stop();
            if (gcw == null)
                gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            gcw.MovementThreshold = 0;

            gcw.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(gcw_StatusChanged);
            gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
            podepegar = false;
            Inicia = 0;
            AjusteHorizontal = 0;
            loop = 0;
            gcw.Start();
        }

        void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:


                    if (gcw.Permission == GeoPositionPermission.Denied)
                    {
                        MessageBox.Show(Localization.m10.ToString());
                    }
                    else
                    {
                        MessageBox.Show(Localization.m10.ToString());
                    }




                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    podepegar = false;
                    break;



                case GeoPositionStatus.Initializing:

                    podepegar = true;
                    break;


                case GeoPositionStatus.NoData:

                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    MessageBox.Show(Localization.m12.ToString());
                    podepegar = false;
                    break;
                case GeoPositionStatus.Ready:
                    podepegar = true;
                    break;

            }
        }


        
*/

        /*


        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {






            Inicia = Inicia + 1;

            if (Inicia > 20)
            {
                gcw.Stop();
                ligadesliga_busy(false);
                ligadesliga_tray(false, " ");
                ApplicationBar.IsVisible = true;
                MessageBox.Show(Localization.m13.ToString());
                NavigationService.GoBack();
            }


            if (podepegar == true)
            {

                if (e.Position.Location.IsUnknown)
                {

                    MessageBox.Show(Localization.m14.ToString());

                    return;
                }


                if (e.Position.Location.HorizontalAccuracy > AjusteHorizontal)
                {
                    if ((Inicia == 5) | (Inicia == 10) | (Inicia == 15))
                    {
                        if (Inicia == 5)
                        {
                            AjusteHorizontal = AjusteHorizontal + 500;
                        }

                        if (Inicia == 10)
                        {
                            AjusteHorizontal = AjusteHorizontal + 3500;
                        }


                        if (Inicia == 15)
                        {
                            AjusteHorizontal = AjusteHorizontal + 4000;
                        }

                        gcw.Stop();
                        gcw.Start();

                    }


                    loop = loop + 1;
                    if (loop > 2)
                    {
                        ligadesliga_tray(true, Localization.m15.ToString() + " " + AjusteHorizontal);
                        Thread.Sleep(1000);
                        ligadesliga_tray(true, Localization.m16.ToString() + " " + AjusteHorizontal);
                    }
                    else
                    {
                        ligadesliga_tray(true, Localization.m17.ToString() + " " + AjusteHorizontal.ToString());
                    }


                    AjusteHorizontal = AjusteHorizontal + 50;


                    if (AjusteHorizontal > 5000)
                    {
                        gcw.Stop();
                        ligadesliga_busy(false);
                        ligadesliga_tray(false, " ");
                        ApplicationBar.IsVisible = true;
                        MessageBox.Show(Localization.m13.ToString());
                        NavigationService.GoBack();
                    }

                    return;
                } 
                








                progress1.IsVisible = true;
                progress1.IsIndeterminate = true;
                progress1.Text = "Lat: " + e.Position.Location.Latitude.ToString() + " Lon: " + e.Position.Location.Longitude.ToString();
                SystemTray.SetProgressIndicator(this, progress1);


                latitude = e.Position.Location.Latitude;
                longitude = e.Position.Location.Longitude;


                if (e.Position.Location.IsUnknown)
                {
                    latitude = 0;
                    longitude = 0;
                }

              
                latx = latitude.ToString().Replace(",", ".");
                lonx = longitude.ToString().Replace(",", ".");
                App.LocLat = latx;
                App.LocLon = lonx;
                progress1.Text = "Lat: " + latx + " Lon: " + lonx;
                progress1.IsVisible = true;

            //    eLat.Text = "Lat: "+App.LocLat;
            //    eLon.Text = "Lon: "+App.LocLon; 

                gcw.Stop();


                App.latitude = latitude;
                App.longitude = longitude;
                LoadLandMarkList(latitude, longitude);
            }
            else
            {
                latitude = 0;
                longitude = 0;
            }




        }


         * 
         * 
         * 
         */
 



        private void eCategoria_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            progress1.IsVisible = false;
            progress1.IsIndeterminate = false;
            progress1.Text = "";
            SystemTray.SetProgressIndicator(this, progress1);
            NavigationService.Navigate(new Uri("/categoria.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Save_Button(object sender, EventArgs e)
        {



          //  pegaGeo(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));




            if (eNomelocal.Text.Trim().Length == 0) {
                MessageBox.Show(Localization.ms50.ToString());
                return;
            }

          

            if (eAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show(Localization.ms52.ToString());
                return;
            }


            if (eSel.SelectedItem.ToString() == "Select")
            {
                MessageBox.Show(Localization.ms51.ToString());
                return;
            }


            App.Passou = true;



            App.LocName = eNomelocal.Text.Trim();
            


            if (eAddress.Text.Trim().Length > 0)
            {
                App.LocAddress = eAddress.Text.Trim();
            }


            if (eSel.SelectedItem.ToString() == "bar") { iconw = "/images/G_bar.png"; }
            if (eSel.SelectedItem.ToString() == "bakery") { iconw = "/images/G_bakery.png"; }
            if (eSel.SelectedItem.ToString() == "cafe") { iconw = "/images/G_cafe.png"; }
            if (eSel.SelectedItem.ToString() == "food") { iconw = "/images/G_food.png"; }
            if (eSel.SelectedItem.ToString() == "restaurant") { iconw = "/images/G_restaurant.png"; }
            if (eSel.SelectedItem.ToString() == "night_club") { iconw = "/images/G_night_club.png"; }



            

            var sCoord = App.LocCel;
            var eCoord = new GeoCoordinate(Convert.ToDouble(App.LatCel, CultureInfo.InvariantCulture), Convert.ToDouble(App.LonCel, CultureInfo.InvariantCulture));

            double distancia;
            if (eCoord.Latitude != 0)
            {
                 distancia = sCoord.GetDistanceTo(eCoord);
            }
            else
            {
                 distancia = 0;

            }



            string final = String.Format("{0:0,0}", distancia) + " m" + " " + eSel.SelectedItem.ToString();


            if (App.Conf[0].NET == false)
            {
                App.LocaisUsu.Add(new App.locais() { idlocal = App.LocName, name = App.LocName, address = App.LocAddress, latitude = "0", longitude = "0", tipo = eSel.SelectedItem.ToString(), icon = iconw, distancia = distancia, distStr = final });
                App.adicionou = true;
            }
            else
            {

                App.LocaisUsu.Add(new App.locais() { idlocal = App.LocName, name = App.LocName, address = App.LocAddress, latitude = "0", longitude = "0", tipo = eSel.SelectedItem.ToString(), icon = iconw, distancia = distancia, distStr = final });
                App.adicionou = true;
           }


            if (NavigationService.CanGoBack == true) {

                NavigationService.GoBack();
            }



        //    ve_se_existe(App.LocLat, App.LocLon);


         //   if  (JaExiste == false) {

         //   pega_Local_Nomes(App.LocLat, App.LocLon);
       //     }

         //   cria_album();
         //   gravafoto();






        }


/*
        public void ve_se_existe(string latitude, string longitude)
        {

            if ((latitude == null) && (longitude == null))
            {

                return;
            }


            ligadesliga_tray(true, Localization.ms53.ToString());


            var laty = latitude.Replace(",", ".");
            var lony = longitude.Replace(",", ".");


            int catw = Convert.ToInt32(App.CatCod);


            try
            {
                JaExiste = false;
                client.Service.GeoLocation_Location_SearchCompleted += new EventHandler<Buddy.BuddyService.GeoLocation_Location_SearchCompletedEventArgs>(verifica_local);
                client.Service.GeoLocation_Location_SearchAsync(Constants.AppName, Constants.AppPass, App.UserToken,"5000", laty, lony, "10", eNomelocal.Text.Trim(),"");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
            }

        }


        */

        /*

        void verifica_local(object sender, Buddy.BuddyService.GeoLocation_Location_SearchCompletedEventArgs e)
        {



            if (e.Error != null)
            {
                MessageBox.Show(Localization.ms54.ToString());
                ligadesliga_tray(false, "");
                return;
            }

            
            
            
            
            if (e.Result.Count > 0)
            {


                string testa = e.Result[0].Name;
                string testa1 = e.Result[0].GeoID;
                string testL = e.Result[0].Latitude;
                string testD = e.Result[0].Longitude;
                //string userIDx = App.Usu[0].ID;


                MessageBox.Show(Localization.ms59.ToString());
                ligadesliga_tray(false, "");
                JaExiste = true;




            }
            else
            {

                pega_Local_Nomes(App.LocLat, App.LocLon);

            }




        }


        */


















/*


        public void pega_Local_Nomes(string latitude, string longitude)
        {

            if ((latitude == null) && (longitude == null))
            {

                return;
            }


            ligadesliga_tray(true, Localization.ms53.ToString());


            var laty = latitude.Replace(",", ".");
            var lony = longitude.Replace(",", ".");


            int catw = Convert.ToInt32(App.CatCod);


            try
            {
                client.Service.GeoLocation_Location_AddCompleted += new EventHandler<Buddy.BuddyService.GeoLocation_Location_AddCompletedEventArgs>(pega_local);
                client.Service.GeoLocation_Location_AddAsync(Constants.AppName, Constants.AppPass, App.UserToken, laty, lony, eNomelocal.Text.Trim(), App.LocAddress, cida, App.LocUF, App.LocCEP, pais, App.LocFone, "", "", catw.ToString(), "", "");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
            }

        }



        /*


        void pega_local(object sender, Buddy.BuddyService.GeoLocation_Location_AddCompletedEventArgs e)
        {

            
            
            if (e.Error != null)
            {
                MessageBox.Show(Localization.ms54.ToString());
                ligadesliga_tray(false, "");
                return;
            }

            if (e.Result != null)
            {
                 App.LocID = e.Result;



                // photo_envia();
                
                
                
                ligadesliga_tray(false, "");
                 MessageBox.Show(Localization.ms55.ToString());
                 App.addUser = true;

                 //App.Local.Add(new App.locais() { name = eNomelocal.Text.Trim(), address = App.LocAddress, longitude = latitude, latitude = longitude, AppTagData = e.Result[i].AppTagData, CategoryID = e.Result[i].CategoryID, CategoryName = e.Result[i].CategoryName, City = e.Result[i].City, DistanceInKilometers = monta, DistanceInMeters = e.Result[i].DistanceInMeters, DistanceInMiles = e.Result[i].DistanceInMiles, DistanceInYards = e.Result[i].DistanceInYards, GeoID = e.Result[i].GeoID, PostalState = e.Result[i].PostalState, PostalZip = e.Result[i].PostalZip, Region = e.Result[i].Region, ShortID = e.Result[i].ShortID, Telephone = e.Result[i].Telephone, UserTagData = e.Result[i].UserTagData, Website = e.Result[i].WebSite, img = App.img_emp });

/*
                if (NavigationService.CanGoBack == true) {
                
                    NavigationService.GoBack();
                }
                */

            //}
       // }


/*

        public void cria_album()
        {


            if ((App.LocFotoFileName0 == null) &
                 (App.LocFotoFileName1 == null) &
                 (App.LocFotoFileName2 == null) &
                 (App.LocFotoFileName3 == null))
            {
                MessageBox.Show(Localization.ms55.ToString());
                return;
            }

            ve_se_existe_album();
        }





        public void ve_se_existe_album()
        {


            try
            {

                client.Service.Pictures_PhotoAlbum_GetFromAlbumNameCompleted += new EventHandler<Buddy.BuddyService.Pictures_PhotoAlbum_GetFromAlbumNameCompletedEventArgs>(ve_album);
                client.Service.Pictures_PhotoAlbum_GetFromAlbumNameAsync(Constants.AppName, Constants.AppPass, App.UserToken, App.UserID, App.LocID);
                // NavigationService.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
            }

        }

        void ve_album(object sender, Buddy.BuddyService.Pictures_PhotoAlbum_GetFromAlbumNameCompletedEventArgs e)
        {


            if (e.Error != null)
            {
                MessageBox.Show("Error during add New Album. Try later.");
                return;
            }

            if (e.Result != null)
            {


                if (e.Result.Count > 0)
                {
                   // App.LocIDAlbum = e.Result[0].AlbumID;
                    photo_envia();
                }
                else
                {
                    if (e.Result.Count == 0)
                    {
                        cria_album_novo();
                    }

                }
            }
            else
            {

            }




        }













/*


           public void cria_album_novo()
           {


            try
            {

                client.Service.Pictures_PhotoAlbum_CreateCompleted += new EventHandler<Buddy.BuddyService.Pictures_PhotoAlbum_CreateCompletedEventArgs>(pega_album);
                client.Service.Pictures_PhotoAlbum_CreateAsync(Constants.AppName, Constants.AppPass, App.UserToken, App.LocID, "1", "", "");
               // NavigationService.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
            }
           
        }

        void pega_album(object sender,Buddy.BuddyService.Pictures_PhotoAlbum_CreateCompletedEventArgs e)
        {


            if (e.Error != null)
            {
                MessageBox.Show("Error during add New Album. Try later.");
                return;
            }

            if (e.Result != null)
            {
                //App.LocIDAlbum = e.Result;
                photo_envia();
            }
        }


        */





/*
        public void gravafoto()
        {

            try
            {

                client.Service.Pictures_Photo_AddCompleted += new EventHandler<Buddy.BuddyService.Pictures_Photo_AddCompletedEventArgs>(pega_foto);
                client.Service.Pictures_Photo_AddAsync(Constants.AppName, Constants.AppPass, App.UserToken, byteArray0, App.LocIDAlbum, "", App.LocLat, App.LocLon, "", "");
                NavigationService.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
            }

        }






       

        void pega_foto(object sender, Buddy.BuddyService.Pictures_Photo_AddCompletedEventArgs e)
        {





        }

        */


/*

        void pegaGeo(double latitude, double longitude)
        {


            latx = latitude.ToString().Replace(",", ".");
            lonx = longitude.ToString().Replace(",", ".");
            App.LocLat = latx;
            App.LocLon = lonx;
            progress1.Text = "Lat: " + latx + " Lon: " + lonx;
            progress1.IsVisible = true;




            //  string url = "https://maps.googleapis.com/maps/api/place/search/xml?location=-23.209489822,-47.309302330&radius=500&types=&name=&sensor=false&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

           // string url = "https://maps.googleapis.com/maps/api/place/search/xml?location=" + latx + "," + lonx + "&radius=500&types=&name=&sensor=true&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

            string url = "http://api.geonames.org/findNearbyPlaceName?lat=" + latx + "&lng=" + lonx + "&username=abreuretto";



            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(geo_Completed);
            xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
        }//end of funt


        void geo_Completed(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                //App.LocalG.Clear();

                XElement xmlDataStill = XElement.Parse(e.Result);
                conta = 0;
                foreach (var item in xmlDataStill.Descendants("geoname"))
                {

                  //  string latitude = (string)item.Element("geometry").Element("location").Element("lat").Value;

                    pais = (string)item.Element("countryName").Value;
                    cida = (string)item.Element("toponymName").Value;

                }
                   
               
                this.busyIndicator.IsRunning = false;
                ApplicationBar.IsVisible = true;
                progress1.IsVisible = false;

            }
            else
            {
                MessageBox.Show(Localization.m02.ToString());
            }

        }//end of funt

        








































        void LoadLandMarkList(double latitude, double longitude)
        {


            latx = latitude.ToString().Replace(",", ".");
            lonx = longitude.ToString().Replace(",", ".");
            App.LocLat = latx;
            App.LocLon = lonx;
            progress1.Text = "Lat: " + latx + " Lon: " + lonx;
            progress1.IsVisible = true;

          
            
            
            //  string url = "https://maps.googleapis.com/maps/api/place/search/xml?location=-23.209489822,-47.309302330&radius=500&types=&name=&sensor=false&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

            string url = "https://maps.googleapis.com/maps/api/place/search/xml?location=" + latx + "," + lonx + "&radius=500&types=&name=&sensor=true&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(LoadLandMarkList_Completed);
            xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
        }//end of funt

        void LoadLandMarkList_Completed(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                App.LocalG.Clear();

                XElement xmlDataStill = XElement.Parse(e.Result);
                conta = 0;
                foreach (var item in xmlDataStill.Descendants("result"))
                {


                    string name = (string)item.Element("name").Value;
                    string address = (string)item.Element("vicinity").Value;
                    string latitude = (string)item.Element("geometry").Element("location").Element("lat").Value;
                    string longitude = (string)item.Element("geometry").Element("location").Element("lng").Value;
                    string icon = (string)item.Element("icon").Value;
                    string reference = (string)item.Element("reference").Value;
                    string id = (string)item.Element("id").Value;
                    
                    App.LocalG.Add(new App.locaisG() { name = name, address = address, longitude = longitude, latitude = latitude, icon = icon, reference = reference, id = id });
                    conta++;
                }
                if (conta == 0)
                {
                    MessageBox.Show(Localization.m18.ToString());
                }
                else
                {
                    List<App.locaisG> sorte = new List<App.locaisG>();
                    sorte = App.LocalG;
                    var sortex = (from x in sorte
                                  orderby x.name ascending
                                  select x).ToList();
                }



                this.busyIndicator.IsRunning = false;
                ApplicationBar.IsVisible = true;
                progress1.IsVisible = false;
            }
            else
            {
                MessageBox.Show(Localization.m02.ToString());
            }

        }//end of funt

        











        
        private void Cancel_Button(object sender, EventArgs e)
        {

            eNomelocal.Text = "";
            App.LocName = "";
            eAddress.Text = "";
            App.LocAddress = "";
            App.LocLatG = "";
            App.LocLonG = "";
            eNomelocal.IsReadOnly = false;
            eAddress.IsReadOnly = false;
            App.Confirmou = false;
            
            
            NavigationService.GoBack();
        }

        private void jumpList_ItemTap(object sender, ListBoxItemTapEventArgs e)
        {


        }




        private void Camera_Button(object sender, EventArgs e)
        {


           



            //carrega();
        }

        private void Atualiza_Button(object sender, EventArgs e)
        {
            pega_lista();

        }

        private void button_nov_loc_address_Click(object sender, RoutedEventArgs e)
        {
            App.MostraGoogle = 0;
            this.NavigationService.Navigate(new Uri("/add_local_google.xaml", UriKind.RelativeOrAbsolute)); 
        }



/*

        private void carrega()
        {
            PhotoChooserTask photo = new PhotoChooserTask();
            photo.Completed += new EventHandler<PhotoResult>(selectphoto_Completed);
            photo.ShowCamera = true;
            photo.Show();

        }


        void selectphoto_Completed(object sender, PhotoResult e)
        {


            /*


            if (e.TaskResult == TaskResult.OK)
            {

                BinaryReader reader = new BinaryReader(e.ChosenPhoto);

                if ((e.OriginalFileName == App.LocFotoFileName0) |
                (e.OriginalFileName == App.LocFotoFileName1) |
                (e.OriginalFileName == App.LocFotoFileName2) |
                (e.OriginalFileName == App.LocFotoFileName3))
                {
                    return;
                } 



                if (img0.Source == null)
                {

                  
                        BitmapImage image = new BitmapImage();
                        image.SetSource(e.ChosenPhoto);
                        this.imgSource = image;
                        byteArray0 = ImageToByteArray(imgSource);
                        string fileName = e.OriginalFileName;
                        img0.Source = image;
                        App.LocFotoFileName0 = e.OriginalFileName;
                  

                    return;
                   
                }

                if (img1.Source == null)
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(e.ChosenPhoto);
                    this.imgSource = image;
                    byteArray1 = ImageToByteArray(imgSource);
                    string fileName = e.OriginalFileName;
                    img1.Source = image;
                    App.LocFotoFileName1 = e.OriginalFileName;
                    return;
                }

                if (img2.Source == null)
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(e.ChosenPhoto);
                    this.imgSource = image;
                    byteArray2 = ImageToByteArray(imgSource);
                    string fileName = e.OriginalFileName;
                    img2.Source = image;
                    App.LocFotoFileName2 = e.OriginalFileName;
                    return;
                }


                if (img3.Source == null)
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(e.ChosenPhoto);
                    this.imgSource = image;
                    byteArray3 = ImageToByteArray(imgSource);
                    string fileName = e.OriginalFileName;
                    img3.Source = image;
                    App.LocFotoFileName3 = e.OriginalFileName;
                    return;
                }


               

                






            }
             * 
             * 
             * 
             */ 
        



        /*

        public static byte[] ImageToByteArray(BitmapSource bitmapSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                WriteableBitmap writableBitmap = new WriteableBitmap(bitmapSource);
                System.Windows.Media.Imaging.Extensions.SaveJpeg(writableBitmap, stream, bitmapSource.PixelWidth, bitmapSource.PixelHeight, 0, 100);
                return stream.ToArray();
            }
        }


        private void ImageTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int selectedImageId = int.Parse((string)(sender as FrameworkElement).Tag);
        }







        private void img0_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {


            /*



            ControlTemplate imageTemplate = (ControlTemplate)this.Resources["ImageTemplate"];

            RadMessageBox.Show(Localization.ms56.ToString(), MessageBoxButtons.YesNo, Localization.ms57.ToString(), Localization.ms56.ToString(), closedHandler: (args) =>
               
           
             {        
       
                Button clickedButton = args.ClickedButton;
                 if ((clickedButton.Content.ToString() == "yes")  && (args.IsCheckBoxChecked == true)) 
                 
                 
                 {
                     int selectedImageId = int.Parse((string)(sender as FrameworkElement).Tag);
                     if (selectedImageId == 0)
                     {
                         img0.Source = null;
                     }

                     if (selectedImageId == 1)
                     {
                         img1.Source = null;
                     }

                     if (selectedImageId == 2)
                     {
                         img2.Source = null;
                     }

                     if (selectedImageId == 3)
                     {
                         img3.Source = null;
                     }



                 }





            }            
            );

            
            */
               


        


/*


        public void photo_envia()
        {

           // ligadesliga_busy(true);
           // ligadesliga_tray(true, "send images...");

            Picture pic = null;








            if (byteArray0 != null)
            {

                ligadesliga_busy(true);
                ligadesliga_tray(true, "send image 1...");
                user.PhotoAlbums.CreateAsync((r, ex) =>
            {
                album = r;
                album.AddPictureAsync((p, ex2) =>
                {
                    if (p != null)
                    {
                        pic = p;
                        ListaP.Add(p);
                        user.VirtualAlbums.CreateAsync((r1, ex1) =>
                        {
                            Valbum = r1;
                            Valbum.AddPictureBatchAsync((p1, ex4) =>
                            {
                                if (p1 != null)
                                {
                                    byteArray0 = null;
                                    ligadesliga_busy(false);
                                    ligadesliga_tray(false, "");
                                }
                            }, ListaP);
                        }, App.LocID);
                    }

                }, byteArray0, App.LocName);
            }, App.LocID);
            }







            if (byteArray1 != null)
            {

                user.PhotoAlbums.CreateAsync((r, ex) =>
                {

                    album = r;

                    album.AddPictureAsync((p, ex2) =>
                    {
                        if (p != null)
                        {
                            pic = p;
                            ListaP.Add(p);
                         //   ligadesliga_tray(true, "send image 2...");
                        }

                    }, byteArray1, App.LocName);


                }, App.LocID);

            }


            if (byteArray2 != null)
            {

                user.PhotoAlbums.CreateAsync((r, ex) =>
                {

                    album = r;

                    album.AddPictureAsync((p, ex2) =>
                    {
                        if (p != null)
                        {
                            pic = p;
                            ListaP.Add(p);
                           // ligadesliga_tray(true, "send image 3...");
                        }

                    }, byteArray2, App.LocName);


                }, App.LocID);

            }


            if (byteArray3 != null)
            {

                user.PhotoAlbums.CreateAsync((r, ex) =>
                {

                    album = r;

                    album.AddPictureAsync((p, ex2) =>
                    {
                        if (p != null)
                        {
                            pic = p;
                            ListaP.Add(p);
                         //   ligadesliga_tray(true, "send image 4...");
                        }

                    }, byteArray3, App.LocName);


                }, App.LocID);

            }


            //ligadesliga_tray(true, "send image 4...");


            /*
            user.VirtualAlbums.CreateAsync((r, ex) =>
            {

                Valbum = r;

                Valbum.AddPictureBatchAsync((p, ex2) =>
                {
                    if (p != null)
                    {
                        
                    }

                }, ListaP);


            }, App.LocID);
           


           // ligadesliga_busy(false);
           // ligadesliga_tray(false, "");
            






      









        string PhotoStreamToBase64(Stream PhotoStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            PhotoStream.CopyTo(memoryStream);
            byte[] result = memoryStream.ToArray();

            string base64img = System.Convert.ToBase64String(result);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < base64img.Length; i += 32766)
            {
                sb.Append(Uri.EscapeDataString(base64img.Substring(i, Math.Min(32766, base64img.Length - i))));
            }

            return sb.ToString();
        }

 * 
 * 
 * 
 */ 




        private void eAddress_TextInputUpdate(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void eAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void eNomelocal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void eAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void eFone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
        }





       


    }
}