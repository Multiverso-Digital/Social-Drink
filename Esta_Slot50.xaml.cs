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
using System.Text;
using System.Xml.Linq;
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Shell;

namespace Social_Drink
{
    public partial class Esta_Slot50 : PhoneApplicationPage
    {

        /*
        public class Bebidas
        {
            public string Nome { get; set; }
            public string img { get; set; }
        }


        private static List<Bebidas> ListaBebidas = new List<Bebidas>();
        */




        public class UserDrinks
        {
            public string pais { get; set; }
            public string cida { get; set; }
            public string local  { get; set; }
            public string pontos { get; set; }  
            public string img     { get; set; }
            public string spin { get; set; }
            public string email { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }



        }




        public static List<UserDrinks> ListaDrinks = new List<UserDrinks>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();

        double TotalU { get; set; }
        double TotalD { get; set; }
        int LandMarkCount = 0;


        public Esta_Slot50()
        {
            InitializeComponent();

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_map.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_refresh.ToString();

            p12slotheader.Header = Localization.p12slotheader.ToString();
            

            slider1.Value = 5;

            if (App.Conf[0].NET == false) {
                MessageBox.Show(Localization.m85.ToString());
                return; }

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.Passou = true;
            
            busyIndicator.Content = Localization.busyIndicator;
         //   p11header.Header = Localization.p11header;
            p12slotheader.Header = Localization.p12slotheader;
            busyIndicator.IsRunning = true;
        // eLogou.Text = App.LocName;
        // pegaBebida();
        // ListaUser();
         ListaApp();

        }



        /*

        public void pegaBebida()
        {

            XDocument loadedData = XDocument.Load("SampleData/bebidas.xml");
            var data = from query in loadedData.Descendants("Bebida")
                       select new Bebidas
                       {
                           Nome = (string)query.Element("Nome"),
                           img = (string)query.Element("img"),

                       };
            ListaBebidas = data.ToList();

            string[] lista = new string[ListaBebidas.Count];

            for (int i = 0; i < ListaBebidas.Count; i++)
            {

                lista[i] = ListaBebidas[i].Nome.ToString();
            }

        }

        */




        



        private void ListaApp()
        {


            // 0 = <i0>local</i0><i01>drinks</i01>
            // 1 = <i1>local</i1><i11>bebida</i11>
            // 2 = <i2>local</i2><i21>bebida</i21><i22>marca</i22>
            // 3 = <i3>local</i3><i31>bebida</i31>
            // 4 = <i4>local</i4><i41>bebida</i41><i42>marca</i42>
            
           // string monta = "%<i3>"  +App.LocName+"%";

            string monta = "<88>%";

            try
            {

                int raio = Convert.ToInt32(slider1.Value*1000);

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, raio.ToString(), App.LatCel, App.LonCel, "50", monta, "", "-1", "0", "999999999", "1","DESC", "true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Get_ApplicationMeta_Drinks(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {




            try
            {



                int achou_i1 = 0;
                int achou_f1 = 0;
                int achou_i2 = 0;
                int achou_f2 = 0;
                int achou_i3 = 0;
                int achou_f3 = 0;

                int achou_i4 = 0;
                int achou_f4 = 0;
                int achou_i5 = 0;
                int achou_f5 = 0;
                int achou_i6 = 0;
                int achou_f6 = 0;
                int achou_i7 = 0;
                int achou_f7 = 0;

                string localx = "";
                string paisx = "";
                string cidax = "";
                string lat1 = "";
                string lon1 = "";
                string dista = "";

                string emailx = "";
                string pontosx = "";
                string spinx = "";
                string datax = "";




                ListaDrinksApp.Clear();
                //      App.pins.Clear();
                App.zeraMapa();

                if (e.Error == null)
                {
                    if (e.Result.Count == 0)
                    {

                        busyIndicator.IsRunning = false;

                    }
                    else
                    {
                        TotalD = 0;
                        LandMarkCount = 0;

                        for (int i = 0; i < e.Result.Count; i++)
                        {

                            //        string chave9 = "<6><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL></6>";




                            //  string chave = "<88><pais>" + x.pais + "</pais><cida>" + x.cida + "</cida><email>" + x.email + "</email><pontos>" + x.pontos.ToString() + "</pontos><spin>" + x.spin.ToString() + "</spin><local>" + x.locname + "</local></88>";




                            achou_i1 = e.Result[i].MetaKey.IndexOf("<pais>");
                            achou_f1 = e.Result[i].MetaKey.IndexOf("</pais>");
                            achou_i2 = e.Result[i].MetaKey.IndexOf("<cida>");
                            achou_f2 = e.Result[i].MetaKey.IndexOf("</cida>");
                            achou_i3 = e.Result[i].MetaKey.IndexOf("<email>");
                            achou_f3 = e.Result[i].MetaKey.IndexOf("</email>");
                            achou_i4 = e.Result[i].MetaKey.IndexOf("<pontos>");
                            achou_f4 = e.Result[i].MetaKey.IndexOf("</pontos>");
                            achou_i5 = e.Result[i].MetaKey.IndexOf("<spin>");
                            achou_f5 = e.Result[i].MetaKey.IndexOf("</spin>");
                            achou_i6 = e.Result[i].MetaKey.IndexOf("<local>");
                            achou_f6 = e.Result[i].MetaKey.IndexOf("</local>");
                            achou_i7 = e.Result[i].MetaKey.IndexOf("<data>");
                            achou_f7 = e.Result[i].MetaKey.IndexOf("</data>");


                            lat1 = e.Result[i].MetaLatitude;
                            lon1 = e.Result[i].MetaLongitude;
                            double testa = Convert.ToDouble(e.Result[i].DistanceInKilometers, CultureInfo.InvariantCulture);
                            dista = string.Format("{0:0.000}", testa) + " Km";







                            if (achou_i1 != -1)
                            {


                                paisx = e.Result[i].MetaKey.Substring(achou_i1 + 6, achou_f1 - (achou_i1 + 6));
                                cidax = e.Result[i].MetaKey.Substring(achou_i2 + 6, achou_f2 - (achou_i2 + 6));
                                emailx = e.Result[i].MetaKey.Substring(achou_i3 + 7, achou_f3 - (achou_i3 + 7));
                                pontosx = e.Result[i].MetaKey.Substring(achou_i4 + 8, achou_f4 - (achou_i4 + 8));
                                spinx = e.Result[i].MetaKey.Substring(achou_i5 + 6, achou_f5 - (achou_i5 + 6));
                                localx = e.Result[i].MetaKey.Substring(achou_i6 + 7, achou_f6 - (achou_i6 + 7));

                                if (achou_i7 != -1)
                                {
                                    datax = e.Result[i].MetaKey.Substring(achou_i7 + 6, achou_f7 - (achou_i7 + 6));
                                }

                                ListaDrinksApp.Add(new UserDrinks() { lat = lat1, lon = lon1, img = "/images/medal01.png", local = localx, pais = paisx, cida = cidax, pontos = "Score: " + e.Result[i].MetaValue + "    Spins: " + spinx + "    Date: " + datax, email = emailx, spin = spinx });

                                App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = localx, address = null, longitude = lon1, latitude = lat1, icon = null, reference = null, id = null }, LandMarkCount);
                                LandMarkCount++;

                                //App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(lat1, CultureInfo.InvariantCulture), Convert.ToDouble(lon1, CultureInfo.InvariantCulture)), Country = paisx, Name = localx });



                            }



                        }
                        eTotal.Text = Localization.ms72.ToString() + " " + TotalD.ToString();
                        lb3.ItemsSource = ListaDrinksApp.ToArray();
                        // eTotal.Text = "total doses here: "+TotalD.ToString();
                        busyIndicator.IsRunning = false;

                    }

                    busyIndicator.IsRunning = false;

                }


            }

            catch
            {

                MessageBox.Show(Localization.m02);

            }


        }

        private void Add_Button(object sender, EventArgs e)
        {

        }

        private void Atualiza_Button(object sender, EventArgs e)
        {
            lb3.ItemsSource = null;
            busyIndicator.IsRunning = true;
         //   eLogou.Text = App.LocName;
            ListaApp();
        }

        private void Pivot_LayoutUpdated(object sender, EventArgs e)
        {

            

        }

        private void PivotGeral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            if (lb3.Items.Count > 0)
            {

                UserDrinks sele = lb3.SelectedItem as UserDrinks;
                App.LocLatMap = sele.lat;
                App.LocLonMap = sele.lon;
                App.LocNomMap = sele.local;

                this.NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void map_Button(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/map_place_geral.xaml", UriKind.RelativeOrAbsolute));

        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           

        }






    }
}