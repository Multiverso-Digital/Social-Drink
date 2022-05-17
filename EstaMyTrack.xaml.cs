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
using Buddy;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Shell;

namespace Social_Drink
{
    public partial class EstaMyTrack : PhoneApplicationPage
    {


        public class UserDrinks
        {
            public string marcaU { get; set; }
            public string bebidaU { get; set; }
            public string localU { get; set; }
            public string dataU { get; set; }
            public string img { get; set; }
            public double mlY { get; set; }
            public string mlU { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }



        }

        public class UserDrinksGroup
        {
            public string bebidaU { get; set; }
            public string marcaU { get; set; }
            public string img { get; set; }
            public string data { get; set; }
        }

        public class UserDrinksLocal
        {
            public string local { get; set; }
            public string data { get; set; }
            public string img { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
        }

        public static ObservableCollection<UserDrinksLocal> ListaDrinksLocais = new ObservableCollection<UserDrinksLocal>();



        public static List<UserDrinksLocal> ListaDrinks = new List<UserDrinksLocal>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();
        public static ObservableCollection<UserDrinksGroup> ListaDrinksGroup = new ObservableCollection<UserDrinksGroup>();

        double TotalU { get; set; }
        double TotalD { get; set; }
        int LandMarkCount = 0;

        public void LigaDesligaBuzy(bool valor)
        {
            this.busyIndicator.IsRunning = valor;
        }
        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };
        
        
        public void LigaDesligaProgress(bool valor, string texto)
        {
            SystemTray.IsVisible = valor;
            
            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }

        public EstaMyTrack()
        {
            InitializeComponent();

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_map.ToString();
            p111header.Header = Localization.p111header.ToString();
            p121header.Header = Localization.p121header.ToString();
            busyIndicator.Content = Localization.busyIndicator.ToString();

            App.Passou = true;


            if (App.Conf[0].NET == false) {
                MessageBox.Show(Localization.m85.ToString());
                return;}
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            busyIndicator.Content = Localization.busyIndicator.ToString();
            LigaDesligaProgress(false, "Waiting...");
            ListaUser();


        }

            
        






        private void ListaUser()
        {
            //string monta = "<A3>" + App.LocName;
            busyIndicator.IsRunning = true;
            string monta = "%<A1>%";



            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.MetaData_UserMetaDataValue_SearchCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs>(Get_UserMeta_Drinks);
                client1.Service.MetaData_UserMetaDataValue_SearchAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, "-1", "-1", "-1", "150", monta, "", "-1", "1", "0", "true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LigaDesligaProgress(false, "");
                return;
            }
        }

        void Get_UserMeta_Drinks(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs e)
        {



            try
            {




              //  App.pins.Clear();

                App.zeraMapa();

                App.Passou = true;

                int TotLoc = 0;

                int achou_i1 = 0;
                int achou_f1 = 0;
                int achou_i2 = 0;
                int achou_f2 = 0;
                int achou_i3 = 0;
                int achou_f3 = 0;
                int achou_i4 = 0;
                int achou_f4 = 0;


                string localx = "";
                string bebidax = "";
                string marcax = "";
                string datax = "";
                string valorx = "";
                string latx = "";
                string lonx = "";




                // 0 = <i0>local</i0><i01>drinks</i01>
                // 1 = <i1>local</i1><i11>bebida</i11>
                // 2 = <i2>local</i2><i21>bebida</i21><i22>marca</i22>
                // 3 = <i3>local</i3><i31>bebida</i31>
                // 4 = <i4>local</i4><i41>bebida</i41><i42>marca</i42>
                ListaDrinks.Clear();

                TotalU = 0;
                LandMarkCount = 0;
                if (e.Error == null)
                {


                    if (e.Result != null)
                    {
                        if (e.Result.Count == 0)
                        {
                            busyIndicator.IsRunning = false;
                            LigaDesligaProgress(false, "");
                            eTotal2.Text = Localization.m101 + ": " + "0";
                            eTotal.Text = Localization.m103 + ": " + "0";
                            
                        }
                        else
                        {
                            for (int i = 0; i < e.Result.Count; i++)
                            {


                                achou_i1 = e.Result[i].MetaKey.IndexOf("<A1_local>");
                                achou_f1 = e.Result[i].MetaKey.IndexOf("</A1_local>");
                                achou_i2 = e.Result[i].MetaKey.IndexOf("<A1_bebida>");
                                achou_f2 = e.Result[i].MetaKey.IndexOf("</A1_bebida>");
                                achou_i3 = e.Result[i].MetaKey.IndexOf("<A1_marca>");
                                achou_f3 = e.Result[i].MetaKey.IndexOf("</A1_marca>");
                                achou_i4 = e.Result[i].MetaKey.IndexOf("<A1_data>");
                                achou_f4 = e.Result[i].MetaKey.IndexOf("</A1_data>");


                                localx = e.Result[i].MetaKey.Substring(achou_i1 + 10, achou_f1 - (achou_i1 + 10));
                                bebidax = e.Result[i].MetaKey.Substring(achou_i2 + 11, achou_f2 - (achou_i2 + 11));
                                marcax = e.Result[i].MetaKey.Substring(achou_i3 + 10, achou_f3 - (achou_i3 + 10));
                                datax = e.Result[i].MetaKey.Substring(achou_i4 + 9, achou_f4 - (achou_i4 + 9));
                                valorx = e.Result[i].MetaValue;
                                latx = e.Result[i].MetaLatitude;
                                lonx = e.Result[i].MetaLongitude;

                                double testa = Convert.ToDouble(valorx) / 1000;

                                /*
                                string imgx = "";

                                try
                                {
                                    Bebidas agedTwenty = ListaBebidas.Where<Bebidas>(x => x.Nome == bebidax).Single<Bebidas>();
                                    imgx = agedTwenty.img;
                                }
                                catch (Exception ex)
                                {
                        
                                    imgx = "images/outros01.png";
                            
                                }
                                */

                                App.pegaimg(bebidax);
                                string imgx = App.img;
                                string ima = "images/place.png";

                                TotalU = TotalU + 1;


                                ListaDrinksApp.Add(new UserDrinks() { localU = localx, dataU = datax, bebidaU = bebidax, marcaU = marcax });





                             



                                var loc = (from p in ListaDrinks
                                           where ((p.lat == latx) && (p.lon == lonx))
                                           select p).FirstOrDefault();

                                if (loc == null)
                                {
                                    ListaDrinks.Add(new UserDrinksLocal() { img = ima, data = datax, local = localx, lat = latx, lon = lonx });
                                }
                                else
                                {
                                    foreach (UserDrinksLocal x in ListaDrinks)
                                    {
                                        if (Convert.ToDateTime(loc.data, CultureInfo.InvariantCulture) > Convert.ToDateTime(x.data, CultureInfo.InvariantCulture))
                                        {
                                            x.data = loc.data;
                                        }
                                    }
                                }


                                App.achaNome(localx);

                                if (App.achouNome == false)
                                {

                                    App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = localx, address = null, longitude = lonx, latitude = latx, icon = null, reference = null, id = null }, LandMarkCount);
                                    LandMarkCount++;

                                    
                                    
                                    //App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(latx, CultureInfo.InvariantCulture), Convert.ToDouble(lonx, CultureInfo.InvariantCulture)), Country = " ", Name = localx });
                                    TotLoc = TotLoc + 1;
                                }
                            }


                            List<UserDrinksLocal> fra = new List<UserDrinksLocal>();
                            fra = ListaDrinks;
                            var resu = (from x in fra
                                        orderby x.local ascending, x.data descending
                                        select x).ToList();



                            lb2.ItemsSource = resu.ToArray();
                            eTotal.Text = Localization.m103 + ": " + TotLoc.ToString();
                            busyIndicator.IsRunning = false;
                            

                            bool achou = false;


                            foreach (var g in ListaDrinksApp)
                            {

                                achou = false;

                                foreach (var w in ListaDrinksGroup)
                                {


                                    if (w.bebidaU == g.bebidaU)
                                    {

                                        achou = true;
                                        if (Convert.ToDateTime(g.dataU, CultureInfo.InvariantCulture) > Convert.ToDateTime(w.data, CultureInfo.InvariantCulture))
                                        {
                                            w.data = g.dataU;
                                        }

                                    }



                                }



                                if (achou == false)
                                {
                                    App.pegaimg(g.bebidaU);
                                    ListaDrinksGroup.Add(new UserDrinksGroup() { bebidaU = g.bebidaU, img = App.img, data = g.dataU });

                                }


                            }

                            var resu2 = (from x in ListaDrinksGroup
                                         orderby x.bebidaU ascending, x.data descending
                                         select x).ToList();


                            eTotal2.Text = Localization.m101 + ": " + resu2.Count.ToString();
                            lb3.ItemsSource = resu2.ToArray();
                            LigaDesligaProgress(false, "");
                        }



                    }
                }


                busyIndicator.IsRunning = false;
                LigaDesligaProgress(false, "");

            }
            catch (Exception ex)
            {
                LigaDesligaProgress(false, "");
                //ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }



        }

        private void Add_Button(object sender, EventArgs e)
        {

        }

        private void Atualiza_Button(object sender, EventArgs e)
        {

        }

        private void map_Button(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/map_place_geral.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tap_lb2(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (lb2.ItemCount > 0)
            {


                UserDrinksLocal sele = lb2.SelectedItem as UserDrinksLocal;

                App.LocLatMap = sele.lat;
                App.LocLonMap = sele.lon;
                App.LocNomMap = sele.local;
                App.LocName = sele.local;

          


            this.NavigationService.Navigate(new Uri("/EstaMyTrackPlace.xaml", UriKind.RelativeOrAbsolute));
            }

          //  this.NavigationService.Navigate(new Uri("/CheckinDet.xaml", UriKind.RelativeOrAbsolute));
         
        }

        private void double_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            /*

            UserDrinks sele = lb2.SelectedItem as UserDrinks;

            App.LocLatMap = sele.lat;
            App.LocLonMap = sele.lon;
            App.LocNomMap = sele.localU;

            this.NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
             * 
             */ 
        }




        private void tap_lb3(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (lb3.Items.Count > 0)
            {

                UserDrinksGroup sele = lb3.SelectedItem as UserDrinksGroup;

                App.bebida = sele.bebidaU;

                this.NavigationService.Navigate(new Uri("/Esta_Beb_Det.xaml", UriKind.RelativeOrAbsolute));
            }

            
        }

        private void PivotGeral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (PivotGeral.SelectedIndex == 0)
            {

                if (lb2.ItemCount > 0)
                {
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                }
                else
                {
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                }
            }
            else
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            }


        }


    }
}