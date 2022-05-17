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
using System.Xml.Linq;
using Microsoft.Phone.Shell;
using System.Device.Location;
using WP_SocialDrink;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;
//using Telerik.Examples.WP.MessageBox;
using RestSharp;
using System.Threading;
using Buddy;
using System.Net.NetworkInformation;
//using Microsoft.Phone.Tasks;
using Spring.Rest.Client;
using Microsoft.Phone.Net.NetworkInformation;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Info;
using System.ComponentModel;
using System.Windows.Threading;







namespace Social_Drink
{
    public partial class MainPage : PhoneApplicationPage
    {


        DispatcherTimer dt = new DispatcherTimer();

        BuddyClient client = new BuddyClient(Constants.AppName, Constants.AppPass);
        IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
        public GeoCoordinateWatcher gcw;
        public GeoPositionAccuracy accuracy = GeoPositionAccuracy.High;
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
        public bool jaexiste = false;

        private List<Place> places;
        public class Meta
        {
            public int code { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string formattedPhone { get; set; }
            public string twitter { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int distance { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string cc { get; set; }
            public string postalCode { get; set; }
            public string crossStreet { get; set; }
        }

        public class Stats
        {
            public int checkinsCount { get; set; }
            public int usersCount { get; set; }
            public int tipCount { get; set; }
        }

        public class Likes
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class Specials
        {
            public int count { get; set; }
            public List<object> items { get; set; }
        }

        public class HereNow
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public List<Categories> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            public Likes likes { get; set; }
            public Specials specials { get; set; }
            public HereNow hereNow { get; set; }
            public string referralId { get; set; }
        }

        public class Response
        {
            public List<Venue> venues { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public Response response { get; set; }
        }



        public class Categories
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
            //{ "id": "4bf58dd8d48988d1ca941735", "name": "Pizza Place", "pluralName": "Pizza Places", "shortName": "Pizza", "icon": { "prefix": "https://foursquare.com/img/categories_v2/food/pizza_", "mapPrefix": "https://foursquare.com/img/categories_map/food/pizza", "suffix": ".png" }, "primary": true }

        }


        public class Icon
        {
            public string prefix { get; set; }
            public string mapPrefix { get; set; }
            public string suffix { get; set; }

        }
        public class locais
        {
            public string name { get; set; }
            public string address { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string idlocal { get; set; }
            public string reference { get; set; }
            public string icon { get; set; }
            public string tipo { get; set; }
            public string img { get; set; }
            public string pais { get; set; }
            public string cida { get; set; }
            public double distancia { get; set; }
            public string distStr { get; set; }
            public double rating { get; set; }
            public int checkin { get; set; }
            public string imgrat { get; set; }




        }

        public static List<locais> LocaisG = new List<locais>();
        public static List<locais> LocaisN = new List<locais>();
        public static List<locais> LocaisF = new List<locais>();




        private BackgroundWorker backgroundWorker;
        private BackgroundWorker backgroundWorker1;


        


        public MainPage()
        {
           
            
            InitializeComponent();

            ligadesliga_busy(true); 



            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_placenew.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_refresh.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).Text = Localization.b_map.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).Text = Localization.b_sobre.ToString();


            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.m499.ToString();
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[1]).Text = Localization.m504.ToString(); 
           

            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[2]).Text = Localization.m500.ToString();
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[3]).Text = Localization.m501.ToString();
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[4]).Text = Localization.m502.ToString();
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[5]).Text = Localization.m503.ToString();

            ApplicationBar.IsMenuEnabled = false;


            b_update.Content = Localization.b_update.ToString();
            P2Main.Header = Localization.P2Main.ToString();
            P4Main.Header = Localization.P4Main.ToString();
            P3Main.Header = Localization.P3Main.ToString();
            LOCALI.Header = Localization.LOCALI_Header.ToString();
            ms130.Visibility = Visibility.Collapsed;

            P1Main.Header = Localization.m80.ToString();




            if (store.FileExists("configuracao.xml"))
            {
                App.Conf = GravaIS.IsolatedStorageCacheManager<List<App.configuracao>>.Retrieve("configuracao.xml");
                App.wRadius = App.Conf[0].GoogleRadius;
                App.wHorizontal = App.Conf[0].HorizontalAjuste;
                App.Aceito = App.Conf[0].Aceito;
                App.som = App.Conf[0].SOM;
                App.aviso = App.Conf[0].AVISO;
                App.net = App.Conf[0].NET;
                slider1.Value = App.wRadius/1000;
            }
            else
            {
                App.wRadius = 5000;
                App.wHorizontal = 500;
                App.Conf.Add(new App.configuracao() { GoogleRadius = 5000, HorizontalAjuste = 500, AVISO = false, SOM = true, NET = true, Aceito = 9, conta_trial = 0 });
                byte[] uniqueId = (byte[])DeviceExtendedProperties.GetValue("DeviceUniqueId");
                App.Conf[0].DeviceID = BitConverter.ToString(uniqueId);
                App.Conf[0].Gravou_no_Server = false;
            }




            App.Conf[0].Idioma = CultureInfo.CurrentCulture.Name;
            App.Conf[0].DeviceNome = Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString();
            App.Conf[0].NET = true;




            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();





            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();


            if (LOCALI.IsChecked == true)
            {

                LOCALI.Content = Localization.Ligado.ToString();

            }
            else
            {
                LOCALI.Content = Localization.Desligado.ToString();
            }

            
            eRadius.Value     = App.Conf[0].GoogleRadius;
            eHorizontal.Value = App.Conf[0].HorizontalAjuste;

            if (App.Conf[0].EmailUsu != null)
            {
                eEmail.Text = App.Conf[0].EmailUsu;
            }


            this.Loaded +=new RoutedEventHandler(MainPage_Loaded);
        }




        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {       
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (store.FileExists("locaisgoogle.xml"))
            {
                App.LocaisGoogle = GravaIS.IsolatedStorageCacheManager<List<App.locais>>.Retrieve("locaisgoogle.xml");

            }
        }



        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            
            
            
            if (store.FileExists("locaisusu.xml"))
            {
                App.LocaisUsu = GravaIS.IsolatedStorageCacheManager<List<App.locais>>.Retrieve("locaisusu.xml");
            }
            


        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {




            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_placenew.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_refresh.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).Text = Localization.b_map.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).Text = Localization.b_sobre.ToString();
            b_update.Content = Localization.b_update.ToString();
            P2Main.Header = Localization.P2Main.ToString();
            P4Main.Header = Localization.P4Main.ToString();
            P3Main.Header = Localization.P3Main.ToString();
            LOCALI.Header = Localization.LOCALI_Header.ToString();

            P1Main.Header = Localization.m80.ToString();
            ligadesliga_tray(true, Localization.m15.ToString() + " " + AjusteHorizontal);
            
    

            if (App.ListaShot.Count > 10)
            {


                PivotGeral.SelectedIndex = 3;


                var result = MessageBox.Show(Localization.m129.ToString(), Localization.m128.ToString(), MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    
                   
                    button1_Click_1(null, null);

                };
                

            }

           



        




            if (App.Passou == true)
            {

                if (App.LocaisGoogle.Count != App.LandMarkPositionArray.Length) 
                
                
                {

                    App.LandMarkPositionArraySalva.CopyTo(App.LandMarkPositionArray, 0);

                }



                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                return;
            }

            if (App.Conf[0].Aceito == 5)
            {

                MostraAceito();
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                PivotGeral.SelectedIndex = 2;
                return;
            }


            if (App.Conf[0].Aceito != 1)
            {

                MostraAceito();
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                PivotGeral.SelectedIndex = 2;
                return;

            }



            if ((!Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()))
            {
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                MessageBox.Show(Localization.m85.ToString());
                MessageBox.Show(Localization.m86.ToString());
                P1Main.Header = Localization.m79.ToString();
                App.Conf[0].NET = false;
                PegaLocUsu();
                return;
            }




            if (App.Conf[0].EmailUsu == null)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                PivotGeral.SelectedIndex = 2;
                return;
            }


            if (eEmail.Text.Trim().Length == 0)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m06.ToString());
                return;
            }

            if (isEmail(eEmail.Text.Trim()) == false)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m06.ToString());
                return;
            }        
            


            PivotGeral.SelectedIndex = 0;
            P1Main.Header = Localization.m80.ToString();
            ligadesliga_busy(true);
            ligadesliga_tray(true, Localization.ms122.ToString());
            startLocationService();




            if (App.Conf[0].UserToken == null)
            {
                App.Conf[0].EmailUsu = eEmail.Text.Trim();
                ligadesliga_busy(true);
                ligadesliga_tray(true, Localization.ms121);
                GravanoServer();
                PivotGeral.SelectedIndex = 0;
            }


        }


        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail.Trim();
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void MostraAceito()
        {

            var result = MessageBox.Show(Localization.m78.ToString(), Localization.m77.ToString(), MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                App.Aceito = 1;
                App.Conf[0].Aceito = 1;
            }
            else
            {
                App.Aceito = 5;
                App.Conf[0].Aceito = 5;
                this.Dispatcher.BeginInvoke(() => {

                    if (NavigationService.CanGoBack == true)
                    {
                        NavigationService.GoBack();
                    }
                
                });
                return;
            }
      
        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);




            /*


            if (((Application.Current as App).IsTrial == true) && (App.TrialCancel == true ))
            {
                lb2.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = false;
                slider1.Visibility = Visibility.Collapsed;
                App.Passou = true;
                P2Main.Visibility = Visibility.Collapsed;
                P3Main.Visibility = Visibility.Collapsed;
                P4Main.Visibility = Visibility.Collapsed;
                return;
            }


            

            if ((Application.Current as App).IsTrial)
            {
                if (App.Conf[0].conta_trial > 2) 
                {
                    lb2.Visibility = Visibility.Collapsed;
                    ApplicationBar.IsVisible = false;
                    this.NavigationService.Navigate(new Uri("/Trial.xaml", UriKind.RelativeOrAbsolute));
                    return;
                } 
            }
            else
            {

                lb2.Visibility = Visibility.Visible;
                ApplicationBar.IsVisible = true;

            }
            */


            if ((App.Passou == true) &&  (App.adicionou == true))
            {

                Atualiza_Button(null, null);
                App.adicionou = false;

            }





            if (App.SaiEnvia != false)
            {
                App.SaiEnvia = false;
                PivotGeral.SelectedIndex = 0;
            }




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
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = !valor;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = !valor;

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






        public void startLocationService()
        {


            ligadesliga_busy(true);
            podepegar = false;
            gcw = new GeoCoordinateWatcher(accuracy);
            gcw.MovementThreshold = 500;
            gcw.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(gcw_StatusChanged);
            gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
            Inicia = 0;
           // AjusteHorizontal = Convert.ToInt32(App.wHorizontal);
            loop = 0;
            gcw.Start();

        }


        void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {

            Deployment.Current.Dispatcher.BeginInvoke(() => myStatusChanged(e));
        }

        void myStatusChanged(GeoPositionStatusChangedEventArgs e)
        {


            try

            {

            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:


                    if (gcw.Permission == GeoPositionPermission.Denied)
                    {
                        MessageBox.Show(Localization.m10.ToString());
                        App.Conf[0].NET = false;
                    }
                    else
                    {
                        MessageBox.Show(Localization.m10.ToString());
                        App.Conf[0].NET = false;
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

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }//end of funt



        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => myPositionChanged(e));
        }


        void myPositionChanged(GeoPositionChangedEventArgs<GeoCoordinate> e)
        {


            try
            {
                
                App.LocCel = e.Position.Location;
                App.LatCel = e.Position.Location.Latitude.ToString(CultureInfo.InvariantCulture);
                App.LonCel = e.Position.Location.Longitude.ToString(CultureInfo.InvariantCulture);
                latx = App.LatCel.ToString().Replace(",", ".");
                lonx = App.LonCel.ToString().Replace(",", ".");
                App.zeraMapa();
                App.zeraMapaSalva();


              //  App.LocCel.Latitude = -23.603318;
              //  App.LocCel.Longitude = -46.665974;





                PegaLocUsu();

                   


                if (App.LocaisGoogle.Count > 0) 
                {




                if (App.LocaisGoogle[0].latitude != "0"){
                var eCoord = new GeoCoordinate(Convert.ToDouble(App.LocaisGoogle[0].latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocaisGoogle[0].longitude, CultureInfo.InvariantCulture));
                var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude , CultureInfo.InvariantCulture));
                 distancia  = sCoord.GetDistanceTo(eCoord);
                 distanciax = Convert.ToDouble(distancia, CultureInfo.InvariantCulture);


                

                 if (distancia < 500)
                 {

                     

                     //gcw.Stop();
                     mostraLB();
                     return;
                 }




                } 
                    
            

                    
                }





                App.LocaisGoogle.Clear();


                PegaNokia(App.LocCel);
                //Thread.Sleep(3000);

                PegaGoogle(App.LocCel); 
                
                PegaFS();
                //Thread.Sleep(3000);
                
                
               
                //Thread.Sleep(3000);
                
                


              
                dt.Interval = TimeSpan.FromSeconds(10);
                dt.Tick += new EventHandler(dt_Tick);
                dt.Start();


                //gcw.Stop();

             }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                
            }
                



                


/*


            }
            else
            {


            }

            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }
            */

        }//end of funt







        void dt_Tick(object sender, EventArgs e)
        {

            if ((nokiaTerminou == true) && (googleTerminou == true) && (FSTerminou == true))
            {
                dt.Stop();
                mostraLB();
                
            }



        }






        private void PegaLocUsu()
        {


            ligadesliga_busy(true);



            //App.LocaisGoogle.Clear();


            foreach (App.locais x in App.LocaisUsu)
            {

                latx = x.latitude.ToString().Replace(",", ".");
                lonx = x.longitude.ToString().Replace(",", ".");


                if ((latx == "0") && (lonx == "0"))
                {
                    App.LocaisGoogle.Add(new App.locais() { name = x.name, address = x.address, longitude = latx, latitude = lonx, icon = x.icon, idlocal = x.idlocal, tipo = x.tipo, distancia = x.distancia, distStr = x.distStr });
                  
                    //App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(latx, CultureInfo.InvariantCulture), Convert.ToDouble(lonx, CultureInfo.InvariantCulture)), Country = pais, Name = x.name });
                }



            }



            if ((App.Conf[0].NET == false) && (App.LocaisGoogle.Count == 0))
            {

               // MessageBox.Show(Localization.m85.ToString());
               // MessageBox.Show(Localization.m86.ToString());


                NavigationService.Navigate(new Uri("/add_local.xaml", UriKind.RelativeOrAbsolute));

            }


            if ((!Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) || (App.Conf[0].NET == false))
            {
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                List<App.locais> sorte = new List<App.locais>();
                sorte = App.LocaisGoogle;
                var sortex = (from x in sorte
                              // where x.distancia < 501
                              orderby x.distancia ascending
                              select x).ToList();
                lb2.ItemsSource = sortex;
                return; 
            } 
            

           



           // PegaNokia(App.LocCel);

        }








        private void PegaNokia(GeoCoordinate Loc)

        {
            nokiaTerminou = false;
            ligadesliga_tray(true, Localization.ms123);
            ligadesliga_busy(true);

            LocaisN.Clear();

            try
            {
                latx = Loc.Latitude.ToString().Replace(",", ".");
                lonx = Loc.Longitude.ToString().Replace(",", ".");
                string url = "http://demo.places.nlp.nokia.com/places/v1/discover/explore?at=" + latx + "," + lonx + "&tf=plain&pretty=y&size=20&app_id=al3SR82BNt_apHzbF-b9&app_code=oEW8ZxpiQU7lsr2XkYZAjg&cat=food-drink,hostel,accommodation,hotel,casino,dance-night-club,coffee-tea,bar-pub,snacks-fast-food,restaurant,eat-drink";
                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.GET);
                client.ExecuteAsync<RestRequest>(request, (response) =>
                {
                    places = this.ParsePlaces(response.Content);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.nokiaserver);
                nokiaTerminou = true;
                return;
            }


        }


        public List<Place> ParsePlaces(string json)
        {

            
            List<Place> places = new List<Place>();

                if (json == string.Empty)
                {
            
                    nokiaTerminou = true;
                    return places;

                }

            JToken jToken;
            JToken jToken2;
            try
            {

                jToken = JObject.Parse(json)["results"]["items"];
                jToken2 = JObject.Parse(json)["search"]["context"]["location"]["address"];
            }
           catch (Exception ex)
            {
                MessageBox.Show(Localization.nokiaserver);
                nokiaTerminou = true;
                return places;
            }



                if (jToken == null)
                {
                    nokiaTerminou = true;
                    return places;
                }


                IList<JToken> jlList;

                try
                {
                    jlList = jToken.Children().ToList();
                }
                catch
                {
                    nokiaTerminou = true;
                    return places;
                }


                Search place2 = JsonConvert.DeserializeObject<Search>(jToken2.ToString());

                try
                {
                    place2 = JsonConvert.DeserializeObject<Search>(jToken2.ToString());
                }
                catch
                {
                    nokiaTerminou = true;
                    return places;
                }



                try
                {
                    cida = place2.city;
                }
                catch
                {
                    cida = "";
                }


                try
                {
                    pais = place2.country;
                }
                catch
                {
                    pais = "";
                }

                if (cida.Length > 0)
                {
                    App.Localoutro = cida + ", " + pais;
                    App.LocCity = cida;
                    App.LocPais = pais;
                }
                

                LandMarkCount = 0;

                foreach (JToken token in jlList)
                {

                    Place place = JsonConvert.DeserializeObject<Place>(token.ToString());
                    
                    
                    
                    if (place.type == "urn:nlp-types:place")
                    {


                        IList<JToken> jTokenListPosition;

                        try
                        {
                            jTokenListPosition = token["position"].ToList();
                        }
                        catch
                        {
                            jTokenListPosition = null;
                        }
                        
                        
                        GeoCoordinate position = new GeoCoordinate();
                        try
                        {
                            
                            position.Latitude = double.Parse(jTokenListPosition[0].ToString());
                            position.Longitude = double.Parse(jTokenListPosition[1].ToString());
                            place.position = position;
                        }
                        catch
                        {
                            position.Latitude = 0;
                            position.Longitude = 0;
                            place.position = position;
                        }



                        try
                        {
                            distanciax = Convert.ToDouble(place.distance, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            distanciax = 0;
                        }


                        string nome = "";

                        try
                        {
                            nome = place.title;
                        }
                        catch
                        {
                            nome = "";
                        }


                        string ende = "";

                        try
                        {
                            ende = place.vicinity;
                        }
                        catch
                        {
                            ende = "";
                        }


                        try
                        {
                            latx = position.Latitude.ToString(CultureInfo.InvariantCulture);
                            lonx = position.Longitude.ToString(CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            latx = "";
                            lonx = "";
                        }


                        try
                        {
                            tipox = place.category.id;
                        }
                        catch
                        {
                            tipox = "no category";
                        }


                        try
                        {
                            icon = place.icon;
                        }
                        catch
                        {
                            icon = "";
                        }


                        double rating = 0;

                        try
                        {
                            rating = place.averageRating;
                        }
                        catch
                        {
                            rating = 0;
                        }


                        string final = "";


                        try
                        {
                            final = String.Format("{0:0.000}", distanciax / 1000) + " Km    " + String.Format("{0:0.000}", ((distanciax * 0.000621371))) + " Miles";
                        }
                        catch
                        {
                            final = "";
                        }



                        string ID = "";
                        try
                        {
                           ID = place.id.ToString();
                        }
                        catch
                        {
                            ID = "";
                        }
                        
                        
                        
                        string imgx = "";
                        achou = false;


                        string reference = "";

                        try
                        {
                            reference = place.href;
                        }
                        catch
                        {
                            reference = "";
                        }



                        LocaisN.Add(new locais() { imgrat="images/especial.png", rating=rating, name = nome, address = ende, longitude = lonx, latitude = latx, icon = icon, reference = reference, idlocal = ID, tipo = tipox, img = imgx, distancia = distanciax, distStr = final + "           " + tipox, pais = pais, cida = cida });

                      
                    }

                }

                nokiaTerminou = true;

         




                nokiaTerminou = true;
                return places;

            }

           














       

















        public void PegaGoogle(GeoCoordinate Loc)
        {

            googleTerminou = false;
            ligadesliga_tray(true, Localization.ms124);
            ligadesliga_busy(true);
            LocaisG.Clear();
            

            try
            {

            latx = Loc.Latitude.ToString().Replace(",", ".");
            lonx = Loc.Longitude.ToString().Replace(",", ".");
            string url = "";
            //url = "https://maps.googleapis.com/maps/api/place/search/xml?location=" + latx + "," + lonx + "&radius=" + App.Conf[0].GoogleRadius.ToString() + "&sensor=true&types=bakery|bar|cafe|casino|convenience_store|food|grocery_or_supermarket|liquor_store|night_club|restaurant&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

            url = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + latx + "," + lonx + "&radius=" + App.wRadius.ToString() + "&sensor=true&types=airport|bakery|bar|bowling_alley|cafe|casino|convenience_store|food|night_club|restaurant&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";
            
            
            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(PegaGoogle_Completed);
            xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.googleserver);
                googleTerminou = true;
                return;
            }





        }//end of funt

        void PegaGoogle_Completed(object sender, DownloadStringCompletedEventArgs e)
        {



            try
            {
                if (e.Error != null)
                {

                    MessageBox.Show(Localization.googleserver);
                    googleTerminou = true;
                    return;

                }
            }
             catch (Exception ex)
             {
                 MessageBox.Show(Localization.googleserver);
                googleTerminou = true;
                return;
             }
            
            
             XElement xmlDataStill;

            try
            {
             xmlDataStill = XElement.Parse(e.Result);
            }
            catch (Exception ex)
             {
                 MessageBox.Show(Localization.googleserver);
                googleTerminou = true;
                return;
             }



                conta = 0;
                LandMarkCount1 = 0;
                
                
                
                foreach (var item in xmlDataStill.Descendants("result"))
                {
                    string name ="";
                    try
                    {
                    name = (string)item.Element("name").Value;
                    }
                    catch
                    {
                    name = "";
                    }
                    
                    string address ="";
                    try
                    {
                    address = (string)item.Element("vicinity").Value;
                    }
                    catch
                    {
                    address ="";
                    }
                    
                    string latitude ="";
                    string longitude ="";

                    try
                    {
                    latitude = (string)item.Element("geometry").Element("location").Element("lat").Value;
                    longitude = (string)item.Element("geometry").Element("location").Element("lng").Value;
                    }
                    catch
                    {
                    latitude ="";
                    longitude="";
                    }
                    
                    
                    try
                    {
                    icon = (string)item.Element("icon").Value;
                    }
                    catch
                    {
                    icon ="";
                    }


                    double rating = 0;

                    try
                    {
                        rating = Convert.ToDouble((string)item.Element("rating").Value);
                    }
                    catch
                    {
                        rating = 0;
                    }

                    

                    if (icon == "")
                    {

                        icon = "/images/default.png";
                    }

                    string id ="";
                    try
                    {
                    id = (string)item.Element("id").Value;
                    }
                    catch
                    {
                    id="";
                    }

                    try
                    {
                     tipox = (string)item.Element("type").Value;
                    }
                    catch
                    {
                    tipox = "no category";
                    }

                    string imgx = "";

                    if (
                       (tipox != "bakery") &&
                       (tipox != "bar") &&
                       (tipox != "cafe") &&
                       (tipox != "casino") &&
                       (tipox != "convenience_store") &&
                       (tipox != "liquor_store") &&
                       (tipox != "grocery_or_supermarket") &&
                       (tipox != "night_club") &&
                       (tipox != "restaurant") &&
                       (tipox != "food"))
                    {
                        imgx = "/images/G_establishment.png";

                    }
                    else
                    {
                        imgx = "/images/G_" + tipox + ".png";

                    }


                    string reference = "";

                    try
                    {
                        reference = "https://maps.googleapis.com/maps/api/place/details/json?reference=" + (string)item.Element("reference").Value;
                    }
                    catch
                    {
                        reference = "";
                    }


                    try
                    {
                        var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude, CultureInfo.InvariantCulture));
                        var eCoord = new GeoCoordinate(Convert.ToDouble(latitude, CultureInfo.InvariantCulture), Convert.ToDouble(longitude, CultureInfo.InvariantCulture));
                        distancia = sCoord.GetDistanceTo(eCoord);
                        distanciax = Convert.ToDouble(distancia, CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        distanciax = 0;
                    }


                    string final = "";

                    try
                    {

                        final = String.Format("{0:0.000}", distanciax / 1000) + " Km    " + String.Format("{0:0.000}", ((distanciax * 0.000621371))) + " Miles";
                    }
                    catch
                    {
                        final = "";
                    }




                    LocaisG.Add(new locais() { imgrat = "images/especial.png", rating = rating, name = name, address = address, longitude = longitude, latitude = latitude, icon = icon, reference = reference, idlocal = id, tipo = tipox, img = imgx, distancia = distanciax, distStr = final + "           " + tipox });

       

                      conta++;

                    }





                googleTerminou = true;
               
                



            
           
               
           


        }//end of funt



        public void CompletaGoogle()
        {

            
            ligadesliga_busy(false);
            ligadesliga_tray(false, "");
   
            
            


        }



        public void pegaGeo(string latx, string lonx)
        {



            try
            {


                //string url = "http://api.geonames.org/findNearbyPlaceName?lat=" + latx + "&lng=" + lonx + "&username=abreuretto&fclass=A";

                string url = "http://api.geonames.org/findNearby?lat=" + latx + "&lng=" + lonx + "&fclass=A&username=abreuretto";


                WebClient xmlClient = new WebClient();
                xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(geo_Completed);
                xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }








        }//end of funt


        void geo_Completed(object sender, DownloadStringCompletedEventArgs e)
        {





            try
            {




                if (e.Error == null)
                {
                    //App.LocalG.Clear();

                    XElement xmlDataStill = XElement.Parse(e.Result);
                    conta = 0;
                    foreach (var item in xmlDataStill.Descendants("geoname"))
                    {

                        try
                        {

                            pais = (string)item.Element("countryName").Value;
                            cida = (string)item.Element("toponymName").Value;
                           // App.LocCity = cida;
                           // App.LocPais = pais;

                        }
                        catch
                        {
                           // App.LocCity = " ";
                           // App.LocPais = " ";
                        }



                    }
                }
                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                }


            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }



        }//end of funt










        private void PegaFS()
        {

            FSTerminou = false;           
            ligadesliga_tray(true, Localization.ms125); 
            ligadesliga_busy(true);
            LocaisF.Clear();

            try

            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri("https://api.foursquare.com/v2/venues/search?ll=" + latx + "," + lonx + "&query=pub, restaurant, diner, pizza, burger, steak, fast-food, sandwich, bar&client_id=WYVK3C5JYYSKWLYKMHZFQUAGZYXRBAFXMLARQHLJBFFC05IX&client_secret=GJO5FLB20ZI03LLYBEBST55NI5OMLPG4IRIHXRBPLYB1S4M3&v=20120813&radius=" + App.wRadius.ToString()));
            
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                FSTerminou = true;    
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
                    FSTerminou = true;
                    return;
                }

            }
                catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                FSTerminou = true;
                return;
            }

            var resul=JsonConvert.DeserializeObject<RootObject>(e.Result);

            try
            {
            resul = JsonConvert.DeserializeObject<RootObject>(e.Result);
            }
                catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                FSTerminou = true;
                return;
            }




                LandMarkCount2 = 0;

                for (int i = 0; i < resul.response.venues.Count; i++)
                {
                    
                    string nome ="";
                    try
                    {
                    nome = resul.response.venues[i].name;
                    }
                    catch
                    {
                    nome = "";
                    }
                    
                    string ende ="";
                    
                    try
                    {
                    ende = resul.response.venues[i].location.address;
                    }
                    catch
                    {
                    ende="";
                    }
                    
                    
                    try
                    {
                    latx = resul.response.venues[i].location.lat.ToString(CultureInfo.InvariantCulture);
                    lonx = resul.response.venues[i].location.lng.ToString(CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        latx="";
                        lonx="";
                    }



                    if (resul.response.venues[i].categories.Count > 0)
                    {

                        try
                        {
                        tipox = resul.response.venues[i].categories[0].name;
                        }
                        catch
                        {
                        tipox="no category";
                        }


                        if ((tipox != "Campaign Office") &&
                            (tipox != "College Arts Building") &&
                            (tipox != "Flower Shop") &&
                            (tipox != "Hospital") &&
                            (tipox != "establishment") &&
                            (tipox != "Automotive Shop") &&
                            (tipox != "Design Studio") &&
                            (tipox != "Art Gallery") &&
                            (tipox != "College Engineering Building"))
                        {

                            int tama =0;
                            try
                            {
                            tama = resul.response.venues[i].categories[0].icon.prefix.Length;
                            }
                            catch
                            {
                            tama=0;
                            }

                            try
                            {
                            icon = resul.response.venues[i].categories[0].icon.prefix.Substring(0, tama - 1) + resul.response.venues[i].categories[0].icon.suffix;
                            }
                            catch
                            {
                                icon ="/images/default.png";
                            }
                            

                            try
                            {
                            pais = resul.response.venues[i].location.country;
                            }
                            catch
                            {
                            pais="";
                            }
                            
                            try
                            {
                            cida = resul.response.venues[i].location.city;
                            }
                            catch
                            {
                            cida="";
                            }
                            

                            try
                            {
                            var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude, CultureInfo.InvariantCulture));
                            var eCoord = new GeoCoordinate(Convert.ToDouble(latx, CultureInfo.InvariantCulture), Convert.ToDouble(lonx, CultureInfo.InvariantCulture));
                            distancia = sCoord.GetDistanceTo(eCoord);
                            distanciax = Convert.ToDouble(distancia, CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                            distanciax=0;
                            }
                            
                            string final ="";
                            try
                            {
                            
                            final = String.Format("{0:0.000}", distanciax / 1000) + " Km    " + String.Format("{0:0.000}", ((distanciax * 0.000621371))) + " Miles";
                            }
                            catch
                            {
                            final="";
                            }
                            
                            
                            string ID="";

                            try
                            {
                            ID = resul.response.venues[i].id.ToString();
                            }
                            catch
                            {
                            ID="";
                            }


                            double rating = 0;

                            try
                            {
                            rating = resul.response.venues[i].stats.checkinsCount;
                            }
                            catch
                            {
                            rating =0;
                            }

                            string reference = "https://api.foursquare.com/v2/venues/" + ID; 

                            string imgx = "";
                            achou = false;


                            ligadesliga_tray(true, Localization.ms125);



                            LocaisF.Add(new locais() { imgrat = "images/check.png",  rating = rating, name = nome, address = ende, longitude = lonx, latitude = latx, icon = icon, reference = reference, idlocal = ID, tipo = tipox, img = imgx, distancia = distanciax, distStr = final + "           " + tipox, pais = pais, cida = cida });

                       

                        
                        }
                    }
                    else
                    {
                        tipox = "";
                        icon = "/images/default.png";
                    }

                }

                
                FSTerminou = true;

            
        }









        private bool vesetem(string nome, string latp , string lonp)
        {

            int achou = 0;


            var resulta = (from p in App.LocaisGoogle
             where ((nome == p.name) || ((latp == p.latitude) && (lonp == p.longitude)))
             select p).FirstOrDefault();


            if (resulta != null)
            {
                achou = achou + 1;
            }

            /*
            foreach (App.locais x in App.LocaisGoogle)
            {
                if ((nome == x.name) || ((latp == x.latitude ) && (lonp == x.longitude)))
                {
                    achou = achou + 1;                   
                }
            }
             * 
             * 
             */ 

            if (achou > 0)
            {
                return true;
            }
            else
            {
                return false;
            }





        }


        private void mostraLB()
        {

            //gcw.Stop();

            if (App.Conf[0].UserToken == null) 
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                return;

            }

            LandMarkCount2 = 0;

            foreach (locais x in LocaisN)
            {
                if (vesetem(x.name, x.latitude, x.longitude) == false)
                {

                    if (x.distancia <= slider1.Value * 1000)
                    {

                        App.LocaisGoogle.Add(new App.locais()  {imgrat=x.imgrat, rating=x.rating, name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, idlocal = x.idlocal, tipo = x.tipo, img = x.img, distancia = x.distancia, distStr = x.distStr, pais = x.pais, cida = x.cida, quem=3 });
                        // lb2.ItemsSource = LocaisF.ToList();
                        App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                        App.LandMarkPositionArraySalva.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                        LandMarkCount2++;

                    }
                }
                
            }



           // string[] listaG = new string[] { "establishment", "real_state_agency", "home_goods_store", "city_hall", "locality", "store", "place_of_worship", "museum", "church", "stadium", "sublocality", "lawyer", "Furniture_store" };

            foreach (locais x in LocaisG)
            {

                /*
                int retornog = -1;
                foreach (string h in listaG)
                {
                    if (h == x.tipo)
                    {
                        retornog = 2;
                    }
                }


                if (retornog == -1)
                {

                */

                    if (vesetem(x.name, x.latitude, x.longitude) == false)
                    {

                        if (x.distancia <= slider1.Value * 1000)
                        {

                            App.LocaisGoogle.Add(new App.locais() {imgrat=x.imgrat, rating=x.rating, name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, idlocal = x.idlocal, tipo = x.tipo, img = x.img, distancia = x.distancia, distStr = x.distStr, pais = x.pais, cida = x.cida, quem=2 });
                            // lb2.ItemsSource = LocaisF.ToList();
                            App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                            App.LandMarkPositionArraySalva.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                            LandMarkCount2++;

                        }
                    }
                
            }















            string[] listaF = new string[] {"Salon / Barbershop","Building","General Travel", "Medical Center", "Farmers Market", "Church", "Office", "Cosmetics Shop", "Laundry Service", "Music Venue", "Residential Building (Apartment / Condo)", "Grocery Store" ,"Martial Arts Dojo", "Temple", "Drugstore / Pharmacy", "Electronics Store", "Dance Studio", "Bank", "Light Rail", "Courthouse", "Plaza", "Music Store", "Factory" , "Gym"}; 
            foreach (locais x in LocaisF)
            {

                int retorno = -1;
                foreach (string h in listaF)
                {
                    if (h == x.tipo) 
                    {
                        retorno = 2;
                    }
                }


                if (retorno == -1)
                {



                    if (vesetem(x.name, x.latitude, x.longitude) == false)
                    {




                        if (x.distancia <= slider1.Value * 1000)
                        {

                            App.LocaisGoogle.Add(new App.locais() {imgrat=x.imgrat, rating=x.rating,   name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, idlocal = x.idlocal, tipo = x.tipo, img = x.img, distancia = x.distancia, distStr = x.distStr, pais = x.pais, cida = x.cida, quem=1 });
                           // lb2.ItemsSource = LocaisF.ToList();
                            App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                            App.LandMarkPositionArraySalva.SetValue(new App.RssLandMark() { name = x.name, address = x.address, longitude = x.longitude, latitude = x.latitude, icon = x.icon, reference = x.reference, id = x.idlocal }, LandMarkCount2);
                            LandMarkCount2++;

                        }




                    }
                }
            }


           // LandMarkCount2 = 0;
            

           // LandMarkCount2 = 0;
           







            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;

            var sortex = (from x in sorte
                          // where x.distancia < 501
                          orderby x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;

           
            App.LocaisGoogle = sortex.ToList();
           

           


            ligadesliga_tray(false, "");
            ligadesliga_busy(false);

            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                    ms130.Visibility = Visibility.Visible;
                    ApplicationBar.IsMenuEnabled = true;




                });
            }
            else
            {
                ms130.Visibility = Visibility.Collapsed;
                ApplicationBar.IsMenuEnabled = false;
            }

            if (App.LocCity != null)
            {
                App.Localoutro = App.LocCity + ", " + App.LocPais; 
            }

            


        }















        private void lb2_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            if (lb2.ItemCount > 0)
            {


                ligadesliga_busy(true);



                App.Passou = false;
                App.NaoSoma = false;
                App.Clicou = true;
                App.bebida = null;
                App.marca = null;
                App.locais sele = lb2.SelectedItem as App.locais;


                if ((App.Conf[0].NET == true) && (sele.pais == null))
                {
                    //pegaGeo(sele.latitude.Replace(",", "."), sele.longitude.Replace(",", "."));
                }
                else
                {
                    App.LocPais = sele.pais;
                    App.LocCity = sele.cida;
                }


                App.LocName = sele.name;
                App.LocAddress = sele.address;
                App.LocID = sele.idlocal;
                App.LocLat = sele.latitude;
                App.LocLon = sele.longitude;
                App.LocIcon = sele.icon;
                App.LocImg = sele.img;
                App.LocRefe = sele.reference;
                App.LocTipo = sele.tipo;
                App.LocDist = sele.distStr;
                App.quem = sele.quem;

                this.NavigationService.Navigate(new Uri("/Checkin.xaml", UriKind.RelativeOrAbsolute));
                //ligadesliga_busy(false);




            }




        }

        private void Add_Button(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/add_local.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void Atualiza_Button(object sender, EventArgs e)
        {

           // gcw.Start();


            if ((App.Conf[0].UserToken == null) && (jaexiste == true))
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                return;

            }

            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;



            if (App.Conf[0].NET != false)
            {
                App.LocaisGoogle.Clear();
              
                ligadesliga_busy(true);
                ligadesliga_tray(true, Localization.m15.ToString() + " " + AjusteHorizontal);
                startLocationService();
                PivotGeral.SelectedIndex = 0;
                PegaLocUsu();
            }
            else
            {
                PegaLocUsu();
            }


        }

        private void Edit_Button(object sender, EventArgs e)
        {

        }

        private void sobre_Button(object sender, EventArgs e)
        {

           
            //    NavigationService.Navigate(new Uri("/LoginFB.xaml", UriKind.RelativeOrAbsolute));

            NavigationService.Navigate(new Uri("/Sobre.xaml", UriKind.RelativeOrAbsolute));
            

        }

        private void map_Button(object sender, EventArgs e)
        {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }


            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            NavigationService.Navigate(new Uri("/map_place_geral.xaml", UriKind.RelativeOrAbsolute));
            


        }

        private void eHorizontal_ValueChanged(object sender, Telerik.Windows.Controls.ValueChangedEventArgs<double> e)
        {



            if (e.NewValue != null)
            {
                App.wHorizontal = Convert.ToInt32(e.NewValue);

            }
            


        }

        private void eRadius_ValueChanged(object sender, Telerik.Windows.Controls.ValueChangedEventArgs<double> e)
        {
            
            
            
            
            if (e.NewValue != null)
            {

               // App.wRadius = Convert.ToInt32(e.NewValue);
               // eRadius.Value = App.wRadius;
            }
            
            




        }

        private void Pivot_SizeChanged(object sender, SizeChangedEventArgs e)
        {


            


        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PivotGeral.SelectedIndex == 0)
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;


                if (lb2.ItemCount > 0) 
                {

                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                }
                else
                {
                  ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
                }

            }


            if (PivotGeral.SelectedIndex == 1)
            {


               

                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;

            }

            if (PivotGeral.SelectedIndex == 2)
            {


                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;

               

            }



            if (PivotGeral.SelectedIndex == 3)
            {

                

                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;



            }



        }

        private void eEmail_LostFocus(object sender, RoutedEventArgs e)
        {


            if (eEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show(Localization.m06.ToString());
                return;
            }

            if (isEmail(eEmail.Text.Trim()) == false)
            {
                MessageBox.Show(Localization.m06.ToString());
                return;
            }



           //App.UserEmail = eEmail.Text.Trim();
            App.Conf[0].EmailUsu = eEmail.Text.Trim();
            ligadesliga_busy(true);
            GravanoServer();
            Atualiza_Button(null, null);






            /*

            PivotGeral.SelectedIndex = 0;

            if (App.Conf[0].UserToken != null)
            {
                Atualiza_Button(null, null);
            }
            else
            {
                MainPage_Loaded(null,null);
            }

            /*
            App.LocaisGoogle.Clear();
            App.pins.Clear();
            ligadesliga_tray(true, Localization.m15.ToString() + " " + AjusteHorizontal);
            startLocationService();  
            */

        }

        private void eEmail_GotFocus(object sender, RoutedEventArgs e)
        {

/*
            EmailAddressChooserTask emailAddressChooserTask;
            emailAddressChooserTask = new EmailAddressChooserTask();
            emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
            emailAddressChooserTask.Show();
            */

        }

        void emailAddressChooserTask_Completed(object sender, EmailResult e)
            {

              if (e.TaskResult == TaskResult.OK)
              {
                  

                  eEmail.Text = e.Email.ToString();
                 
                  
                 
              }

            }

        private void eAceito_Click(object sender, RoutedEventArgs e)
        {
            



                    }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AVISO_MUDA(object sender, CheckedChangedEventArgs e)
        {

            



        }

        private void SOM_MUDA(object sender, CheckedChangedEventArgs e)
        {

          

          

        }

        private void NET_MUDA(object sender, CheckedChangedEventArgs e)
        {

             


        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {


            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }
            
            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 0;
                return;
            }

            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }




            NavigationService.Navigate(new Uri("/update_db.xaml", UriKind.RelativeOrAbsolute));

            
        }



        public void pega_usu()
        {


            jaexiste = false;

            try
            {
                client.Service.UserAccount_Profile_RecoverCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_RecoverCompletedEventArgs>(recupera_user);
                client.Service.UserAccount_Profile_RecoverAsync(Constants.AppName, Constants.AppPass, App.Conf[0].EmailUsu, App.Conf[0].DeviceID);
            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }


        void recupera_user(object sender, Buddy.BuddyService.UserAccount_Profile_RecoverCompletedEventArgs e)
        {

            try
            {



                if (e.Result.ToString() == "SecurityFailedBadUserName")
                {
                    MessageBox.Show("Bad UserName!");
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    App.Conf[0].FB_Token = null;
                    jaexiste = true;
                    return;

                }

                if (e.Result.ToString() == "SecurityFailedBadUserPassword")
                {
                    MessageBox.Show("This email belows to another device. Please try another email!");
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    jaexiste = true;
                    App.Conf[0].FB_Token = null;
                    return;

                }

                if ((e.Result.ToString() == "WrongSocketLoginOrPass") |
                (e.Result.ToString() == "ApplicationAPICallDisabledByDeveloper") |
                (e.Result.ToString() == "InvalidApplicationAndUserToken") |
                (e.Result.ToString() == "-1"))
                {

                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    App.Conf[0].FB_Token = null;
                    jaexiste = true;
                    return;

                }


                if (e.Error == null)
                {

                    App.Conf[0].UserToken = e.Result.ToString();
                    App.Conf[0].AVISO = true;
                    

                }
                else
                {
                    MessageBox.Show(Localization.m08.ToString());
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    App.Conf[0].FB_Token = null;
                    jaexiste = true;
                    return;
                }



            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                App.Conf[0].FB_Token = null;
                jaexiste = true;
                return;
            }

            //PegaDados(App.Conf[0].UserToken);


        }









        public void GravanoServer()
        {

            ligadesliga_tray(true, "Creatimg profile...");

           
            try
            {

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.UserAccount_Profile_CreateCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_CreateCompletedEventArgs>(inclui_profile);
                client2.Service.UserAccount_Profile_CreateAsync(Constants.AppName, Constants.AppPass, App.Conf[0].EmailUsu, App.Conf[0].DeviceID, "male", 20, App.Conf[0].EmailUsu, -1, 0, 0, App.Conf[0].EmailUsu, "");
            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }


        void inclui_profile(object sender, Buddy.BuddyService.UserAccount_Profile_CreateCompletedEventArgs e)
        {




            try
            {


                ligadesliga_tray(false, "Response profile...");


            if (e.Error == null)
            {


                if (e.Result.ToString() == "UserNameAlreadyInUse")
                {
                    pega_usu();
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    return;
                }

                string h =  e.Result.ToString().Substring(0,3);
                if (h == "UT-")
                {
                    App.Conf[0].UserToken = e.Result.ToString();
                    App.Conf[0].AVISO = true;
                   // Dispatcher.BeginInvoke(() =>  { Atualiza_Button(null, null); });
                    
                }
            }
            else
            {
                if (e.Error.Message == "UserNameAlreadyInUse")
                {
                    pega_usu();
                    ligadesliga_busy(false);
                    ligadesliga_tray(false, "");
                    return;
                }
                
                
                //MessageBox.Show(Localization.m02.ToString());
                MessageBox.Show(Localization.m85.ToString());
                P1Main.Header = Localization.m79.ToString();
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                //App.Conf[0].NET = false;
                PegaLocUsu();
                return;
            }
            }

            catch (Exception ex)
            {
                ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }








        private void image2_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EstaMenu.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Esta_login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }
            this.NavigationService.Navigate(new Uri("/Esta_drinks.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }
            this.NavigationService.Navigate(new Uri("/Esta_check.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }
            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }

            this.NavigationService.Navigate(new Uri("/Esta_top50.xaml", UriKind.RelativeOrAbsolute));

        }

        private void rectangle5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }

            this.NavigationService.Navigate(new Uri("/Esta_top50_drink.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }


            this.NavigationService.Navigate(new Uri("/EstaMyTrack.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle11_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            /*

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }
            this.NavigationService.Navigate(new Uri("/Mostra_Trofeus.xaml", UriKind.RelativeOrAbsolute));
             * 
             * 
             */ 
        }

        private void border11_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }


            this.NavigationService.Navigate(new Uri("/Esta_top50.xaml", UriKind.RelativeOrAbsolute));
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue != null)
            {
                Double Conv = e.NewValue * 1000;
                App.wRadius = Convert.ToInt32(Conv);
                if (App.Conf.Count > 0)
                {
                    App.Conf[0].GoogleRadius = Convert.ToInt32(Conv);
                }

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

           


           // web1.Navigate("http://www.windowsphone.com/en-US/legal/wp7/windows-phone-privacy-statement");

        }

        private void radToggleSwitch1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (LOCALI != null)
            {
                LOCALI.Content = Localization.Desligado.ToString();
            }

            MessageBox.Show(Localization.m81.ToString());
            NavigationService.GoBack();


        }

        private void NET_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void NET_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void AVISO_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void AVISO_Unchecked(object sender, RoutedEventArgs e)
        {
           
        }

        private void LOCALI_Checked(object sender, RoutedEventArgs e)
        {
            if (LOCALI != null)
            {
                LOCALI.Content = Localization.Ligado.ToString();
            }
        }

      

        private void frases_click(object sender, System.Windows.Input.GestureEventArgs e)
        {
           // this.NavigationService.Navigate(new Uri("/Frases_Inicio.xaml", UriKind.RelativeOrAbsolute));

        }

        private void button1_Click_2(object sender, RoutedEventArgs e)
        {
           // this.NavigationService.Navigate(new Uri("/Frases_Inicio.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rectangle14_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void tap_medals(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            if (App.Conf[0].EmailUsu == null)
            {
                //MessageBox.Show(Localization.m85.ToString());
                PivotGeral.SelectedIndex = 2;
                return;
            }


            this.NavigationService.Navigate(new Uri("/Esta_Slot50.xaml", UriKind.RelativeOrAbsolute));
           
        }

        private void eEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void lb2_Loaded(object sender, RoutedEventArgs e)
        {

            


        }

        private void orderName(object sender, EventArgs e)
        {
            
            lb2.ItemsSource = null;

            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;
            var sortex = (from x in sorte
                          orderby x.name, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true; });
            }

        }

        private void orderDistancia(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;
            var sortex = (from x in sorte
                          orderby x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true; });
            }

        }

        private void orderRating(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;
            var sortex = (from x in sorte
                          orderby x.rating descending, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true; });
            }
        }

        private void orderCategoria(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;
            var sortex = (from x in sorte
                          orderby x.tipo, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true; });
            }
        }

        private void sugestao(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Sugestao.xaml", UriKind.RelativeOrAbsolute));
        }

        private void events(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Eventos.xaml", UriKind.RelativeOrAbsolute));
        }

        private void lb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            



        }

        private void lb2_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }























    }
}