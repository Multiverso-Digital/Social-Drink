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
using Microsoft.Phone.Controls.Maps;

namespace Social_Drink
{
    public partial class EstaMyTrackPlace : PhoneApplicationPage
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



        public static List<UserDrinksGroup> ListaDrinks = new List<UserDrinksGroup>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();
        public static ObservableCollection<UserDrinksGroup> ListaDrinksGroup = new ObservableCollection<UserDrinksGroup>();

        double TotalU { get; set; }
        double TotalD { get; set; }



        public EstaMyTrackPlace()
        {
            InitializeComponent();

           // ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_map.ToString();
            p311header.Header = Localization.p311header.ToString();
           // p321header.Header = Localization.p321header.ToString();

            tLocal.Text = App.LocNomMap;



            





            App.Passou = true;


            if (App.Conf[0].NET == false) {
                MessageBox.Show(Localization.m85.ToString());
                return;}

            ListaUser();
        }

        private void ListaUser()
        {
            //string monta = "<A3>" + App.LocName;
            busyIndicator.IsRunning = true;
            string monta = "%<A1_local>" + App.LocNomMap+ "%";



            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.MetaData_UserMetaDataValue_SearchCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs>(Get_UserMeta_Drinks);
                client1.Service.MetaData_UserMetaDataValue_SearchAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, "-1", "-1", "-1", "150", monta, "", "-1", "1", "0", "true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Get_UserMeta_Drinks(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs e)
        {


           // App.pins.Clear();
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

            if (e.Error == null)
            {


                if (e.Result != null)
                {
                    if (e.Result.Count == 0)
                    {
                        eTotal.Text = "Total: 0";
                        busyIndicator.IsRunning = false;
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
                           

                            TotalU = TotalU + 1;


                            ListaDrinksApp.Add(new UserDrinks() { localU = localx, dataU = datax, bebidaU = bebidax, marcaU = marcax, img = imgx});

  
                            var loc = (from p in ListaDrinks
                                         where ((p.bebidaU == bebidax)  && (p.marcaU == marcax))
                                         select p).FirstOrDefault();

                            if (loc == null)
                            {
                                ListaDrinks.Add(new UserDrinksGroup() { img = imgx, data = datax, bebidaU = bebidax, marcaU = marcax });
                            }
                            else
                            {
                                foreach (UserDrinksGroup x in ListaDrinks)
                                {
                                    if (Convert.ToDateTime(loc.data, CultureInfo.InvariantCulture) > Convert.ToDateTime(x.data, CultureInfo.InvariantCulture))
                                    {
                                        x.data = loc.data;
                                    } 
                                }
                            }
                            

                            
                        }


                        List<UserDrinksGroup> fra = new List<UserDrinksGroup>();
                        fra = ListaDrinks;
                        var resu = (from x in fra
                                    orderby  x.bebidaU ascending, x.marcaU ascending
                                    select x).ToList();


                       // App.pins.Clear();
                       // App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(App.LocLatMap, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLonMap, CultureInfo.InvariantCulture)), Country = " ", Name = App.LocNomMap });

                        lb2.ItemsSource = resu.ToArray();
                        eTotal.Text = "Total: "+resu.Count.ToString();
                        busyIndicator.IsRunning = false;

                        


                       
                    }



                }
            }


            busyIndicator.IsRunning = false;
        }

        private void Add_Button(object sender, EventArgs e)
        {

        }

        private void Atualiza_Button(object sender, EventArgs e)
        {

        }

        private void map_Button(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tap_lb2(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
            
            /*
            UserDrinks sele = lb2.SelectedItem as UserDrinks;
            App.LocLatMap = sele.lat;
            App.LocLonMap = sele.lon;
            App.LocNomMap = sele.localU;
            App.LocName = sele.localU;
            this.NavigationService.Navigate(new Uri("/CheckinDet.xaml", UriKind.RelativeOrAbsolute));
            */
         



        }

        private void double_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            /*

            UserDrinks sele = lb2.SelectedItem as UserDrinks;

            App.LocLatMap = sele.lat;
            App.LocLonMap = sele.lon;
            App.LocNomMap = sele.localU;

            this.NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
             */
        }




        private void tap_lb3(object sender, System.Windows.Input.GestureEventArgs e)
        {

            /*
            UserDrinksGroup sele = lb3.SelectedItem as UserDrinksGroup;         
           
            App.bebida = sele.bebidaU;

            this.NavigationService.Navigate(new Uri("/Esta_Beb_Det.xaml", UriKind.RelativeOrAbsolute));
            */

            
        }


    }
}