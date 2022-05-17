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
    public partial class Esta_top50 : PhoneApplicationPage
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
            public string paisU { get; set; }
            public string cidaU { get; set; }
            public string localU  { get; set; }
            public string drinksU { get; set; }  
            public string img     { get; set; }
            public string distancia { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string bebidaU { get; set; }
            public string marcaU { get; set; }



        }




        public static List<UserDrinks> ListaDrinks = new List<UserDrinks>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();

        double TotalU { get; set; }
        double TotalD { get; set; }

        int LandMarkCount = 0;


        public Esta_top50()
        {
            InitializeComponent();

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_map.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_refresh.ToString();

            p12header.Header = Localization.p12header.ToString();
            p122header.Header = Localization.p122header;
            

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
            p12header.Header = Localization.p22header;
            p122header.Header = Localization.p122header;

            busyIndicator.IsRunning = true;
       //  eLogou.Text = App.LocName;
        // pegaBebida();
        // ListaUser();
         ListaApp();
         ListaMarcas();

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

            string monta = "<6>%";

            try
            {

                int raio = Convert.ToInt32(slider1.Value*1000);

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, raio.ToString(), App.LatCel, App.LonCel, "10", monta, "", "-1", "0", "999999999", "1", "DESC", "true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Get_ApplicationMeta_Drinks(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {




            int achou_i1 = 0;
            int achou_f1 = 0;
            int achou_i2 = 0;
            int achou_f2 = 0;
            int achou_i3 = 0;
            int achou_f3 = 0;
          



            string localx = "";
            string paisx = "";
            string cidax = "";
            string lat1 = "";
            string lon1 = "";
            string dista = "";





          
            ListaDrinksApp.Clear();
            App.zeraMapa();
         //   App.pins.Clear();

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



                        achou_i1 = e.Result[i].MetaKey.IndexOf("<PL>");
                        achou_f1 = e.Result[i].MetaKey.IndexOf("</PL>");
                        achou_i2 = e.Result[i].MetaKey.IndexOf("<PP>");
                        achou_f2 = e.Result[i].MetaKey.IndexOf("</PP>");
                        achou_i3 = e.Result[i].MetaKey.IndexOf("<PC>");
                        achou_f3 = e.Result[i].MetaKey.IndexOf("</PC>");

                        lat1 = e.Result[i].MetaLatitude;
                        lon1 = e.Result[i].MetaLongitude;
                        double testa = Convert.ToDouble(e.Result[i].DistanceInKilometers, CultureInfo.InvariantCulture);
                        dista = string.Format("{0:0.000}", testa)+" Km";




                        if (achou_i1 != -1)
                        {


                            localx = e.Result[i].MetaKey.Substring(achou_i1 + 4, achou_f1 - (achou_i1 + 4));
                            paisx = e.Result[i].MetaKey.Substring(achou_i2 + 4, achou_f2 - (achou_i2 + 4));
                            cidax = e.Result[i].MetaKey.Substring(achou_i3 + 4, achou_f3 - (achou_i3 + 4));
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

                            //App.pegaimg(bebidax);
                            string imgx = "/images/place_icon1.png";


                            long valor = 0;
                            long.TryParse(e.Result[i].MetaValue, out valor);
                            double conta = Convert.ToDouble(valor)/1000;
                            string monta = conta.ToString()+" L";
                            TotalD = TotalD + conta;


                            ListaDrinksApp.Add(new UserDrinks() { img = "/images/estrela01.png", drinksU =  Localization.m101+": " + monta, localU = localx, paisU = paisx, cidaU = cidax, distancia = dista, lat = lat1, lon = lon1 });
                            App.LandMarkPositionArray.SetValue(new App.RssLandMark() { name = localx, address = null, longitude = lon1, latitude = lat1, icon = null, reference = null, id = null }, LandMarkCount);
                            LandMarkCount++;



                            //App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(lat1, CultureInfo.InvariantCulture), Convert.ToDouble(lon1, CultureInfo.InvariantCulture)), Country = "", Name = localx });



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








        private void ListaMarcas()
        {


            // 0 = <i0>local</i0><i01>drinks</i01>
            // 1 = <i1>local</i1><i11>bebida</i11>
            // 2 = <i2>local</i2><i21>bebida</i21><i22>marca</i22>
            // 3 = <i3>local</i3><i31>bebida</i31>
            // 4 = <i4>local</i4><i41>bebida</i41><i42>marca</i42>

            // string monta = "%<i3>"  +App.LocName+"%";

            string monta = "<31>%";


            //   string chave5 = "<31><PP>" + pais + "</PP><PC>" + cida + "</PC><PB>" + bebida + "</PB><PM>" + marca + "</PM></31>";


            try
            {

                int raio = Convert.ToInt32(slider1.Value * 1000);

                BuddyClient client3 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client3.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_Marcas);
                client3.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, raio.ToString(), App.LatCel, App.LonCel, "50", monta, "", "-1", "0", "999999999", "1", "DESC", "true");
               // client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, raio.ToString(), App.LatCel, App.LonCel, "10", monta, "", "-1", "0", "999999999", "1", "DESC", "true");
     
            
            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Get_Marcas(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
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




                string bebidax = "";
                string marcax = "";
                string paisx = "";
                string cidax = "";
                string lat1 = "";
                string lon1 = "";
                string dista = "";






                ListaDrinks.Clear();
                //   App.pins.Clear();

                if (e.Error == null)
                {
                    if (e.Result.Count == 0)
                    {

                        busyIndicator.IsRunning = false;

                    }
                    else
                    {
                        TotalD = 0;

                        for (int i = 0; i < e.Result.Count; i++)
                        {

                            //        string chave9 = "<6><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL></6>";



                            achou_i1 = e.Result[i].MetaKey.IndexOf("<PP>");
                            achou_f1 = e.Result[i].MetaKey.IndexOf("</PP>");
                            achou_i2 = e.Result[i].MetaKey.IndexOf("<PC>");
                            achou_f2 = e.Result[i].MetaKey.IndexOf("</PC>");
                            achou_i3 = e.Result[i].MetaKey.IndexOf("<PB>");
                            achou_f3 = e.Result[i].MetaKey.IndexOf("</PB>");
                            achou_i4 = e.Result[i].MetaKey.IndexOf("<PM>");
                            achou_f4 = e.Result[i].MetaKey.IndexOf("</PM>");


                            lat1 = e.Result[i].MetaLatitude;
                            lon1 = e.Result[i].MetaLongitude;
                            double testa = Convert.ToDouble(e.Result[i].DistanceInKilometers, CultureInfo.InvariantCulture);
                            dista = string.Format("{0:0.000}", testa) + " Km";




                            if (achou_i1 != -1)
                            {



                                paisx = e.Result[i].MetaKey.Substring(achou_i1 + 4, achou_f1 - (achou_i1 + 4));
                                cidax = e.Result[i].MetaKey.Substring(achou_i2 + 4, achou_f2 - (achou_i2 + 4));
                                bebidax = e.Result[i].MetaKey.Substring(achou_i3 + 4, achou_f3 - (achou_i3 + 4));
                                marcax = e.Result[i].MetaKey.Substring(achou_i4 + 4, achou_f4 - (achou_i4 + 4));

                                string imgx = "";

                                try
                                {
                                    App.Bebidas agedTwenty = App.ListaBebidas.Where<App.Bebidas>(x => x.Nome == bebidax).Single<App.Bebidas>();
                                    imgx = agedTwenty.img;
                                }
                                catch (Exception ex)
                                {

                                    imgx = "images/outros01.png";

                                }

                                //App.pegaimg(bebidax);
                                //string imgx = "/images/place_icon1.png";


                                long valor = 0;
                                long.TryParse(e.Result[i].MetaValue, out valor);
                                double conta = Convert.ToDouble(valor) / 1000;
                                string monta = conta.ToString() + " L";
                                TotalD = TotalD + conta;


                                ListaDrinks.Add(new UserDrinks() { img = imgx, drinksU = Localization.m101 + ": " + monta, bebidaU = bebidax, marcaU = marcax, paisU = paisx, cidaU = cidax, distancia = dista, lat = lat1, lon = lon1 });
                                // App.pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(lat1, CultureInfo.InvariantCulture), Convert.ToDouble(lon1, CultureInfo.InvariantCulture)), Country = "", Name = localx });



                            }



                        }
                        //eTotal.Text = Localization.ms72.ToString() + " " + TotalD.ToString();
                        lb4.ItemsSource = ListaDrinks.ToArray();
                        // eTotal.Text = "total doses here: "+TotalD.ToString();
                        busyIndicator.IsRunning = false;

                    }

                    busyIndicator.IsRunning = false;

                }

            }

            catch (Exception ex)
            {
                //LigaDesligaProgress(false, "");
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
            lb3.ItemsSource = null;
            busyIndicator.IsRunning = true;
           // eLogou.Text = App.LocName;
            ListaApp();
        }

        private void Pivot_LayoutUpdated(object sender, EventArgs e)
        {

            

        }

        private void PivotGeral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PivotGeral.SelectedIndex == 0)
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            }
            else
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            }
        }

        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (lb3.Items.Count > 0)
            {

                UserDrinks sele = lb3.SelectedItem as UserDrinks;

                App.LocLatMap = sele.lat;
                App.LocLonMap = sele.lon;
                App.LocNomMap = sele.localU;

                this.NavigationService.Navigate(new Uri("/mapa_local.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void map_Button(object sender, EventArgs e)
        {


            if (lb3.Items.Count > 0)
            {

                NavigationService.Navigate(new Uri("/map_place_geral.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           

        }






    }
}