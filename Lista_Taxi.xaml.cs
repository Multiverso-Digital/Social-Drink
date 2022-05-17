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
using System.Globalization;
using Microsoft.Phone.Tasks;
//using findfood;
using Newtonsoft.Json;

namespace Social_Drink
{
    public partial class Lista_Taxi : PhoneApplicationPage
    {
        public string latx { get; set; }
         public string lonx { get; set; }

         public DateTime dtinix;
         public bool errodt = false;
         public DateTime dtfimx;
         public bool errodtfim = false;
         public int pegando = 0;
         public int conta = 0; 



       
         public string pais = "";
         public string cida = "";
         public string espe = "";
         public int checkin = 0;
         public string iconespe = "";
         public string tipox = "";
         public string icon = "";
         public bool achou = false;
         public bool primeira = false;
         public double distancia = 0;
         public double distanciax = 0;
         public string dtinicio = "";
         public string dtfim = "";
          


        public class locaisEventos
        {
            public string name { get; set; }
            public string address { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string titulo { get; set; }
            public string icon { get; set; }
            public string cida { get; set; }
            public double distancia { get; set; }
            public string distStr { get; set; }
            public int checkin { get; set; }
            public string data { get; set; }
            public string descri { get; set; }
            public string url { get; set; }
            public DateTime dataini { get; set; }
            public string foto { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public string idlocal { get; set; }
            public string tipo { get; set; }
            public string img { get; set; }
            public string pais { get; set; }
            public string especial { get; set; }
            public string tips { get; set; }
            public string iconespe { get; set; }
            public string iconrating { get; set; }




        }

        public static List<locaisEventos> LocaisEventos = new List<locaisEventos>();


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




        public Lista_Taxi()
        {
            InitializeComponent();
            pegando = 1;
            PegaEvento(pegando);
            App.Passou = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
            ApplicationBar.IsMenuEnabled = false;
            PageTitle.Text = Localization.m506;



            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.m600.ToString();  //name
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[1]).Text = Localization.m601.ToString();  //distancia
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[2]).Text = Localization.m602.ToString();  //rating
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[3]).Text = Localization.m603.ToString();  //categoria
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[4]).Text = Localization.m604.ToString();  //rating

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



        public void PegaEvento(int qtd)
        {

            latx = App.LocCel.Latitude.ToString().Replace(",", ".");
            lonx = App.LocCel.Longitude.ToString().Replace(",", ".");
            
            ligadesliga_tray(true, Localization.m09);
            ligadesliga_busy(true);
            lb2.ItemsSource = null;
            LocaisEventos.Clear();

            try
            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri("https://api.foursquare.com/v2/venues/search?ll=" + latx + "," + lonx + "&categoryId=4bf58dd8d48988d130951735&limit=50&client_id=WYVK3C5JYYSKWLYKMHZFQUAGZYXRBAFXMLARQHLJBFFC05IX&client_secret=GJO5FLB20ZI03LLYBEBST55NI5OMLPG4IRIHXRBPLYB1S4M3&v=20120321"));
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }

  
        }//end of funt

        void getFS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                if (e.Error != null)
                {
                    MessageBox.Show(Localization.fsserver);
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false);
                    return;
                }

                RootObject resul = JsonConvert.DeserializeObject<RootObject>(e.Result);

                

                for (int i = 0; i < resul.response.venues.Count ; i++)
                {

                    string nome = resul.response.venues[i].name;
                    string ende = resul.response.venues[i].location.address;
                    string tel = resul.response.venues[i].contact.formattedPhone;
                    string tel1 = resul.response.venues[i].contact.phone;

                    latx = resul.response.venues[i].location.lat.ToString(CultureInfo.InvariantCulture);
                    lonx = resul.response.venues[i].location.lng.ToString(CultureInfo.InvariantCulture);

                    if (resul.response.venues[i].categories.Count > 0)
                    {
                        tipox = resul.response.venues[i].categories[0].name.ToLower();
                        icon = resul.response.venues[i].categories[0].icon.prefix + "32.png";
                    }
                    else
                    {
                        icon = "";
                    }



                    pais = resul.response.venues[i].location.country;
                    cida = resul.response.venues[i].location.city;
                    
                     espe = "";
                       
                        checkin = resul.response.venues[i].stats.checkinsCount;

                        double rating = 0;

                        try
                        {
                            //rating = resul.response.venues[i].stats.rating;
                        }
                        catch
                        {
                            rating = 0;
                        }

                    

                       

                       




                        var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude, CultureInfo.InvariantCulture));
                        var eCoord = new GeoCoordinate(Convert.ToDouble(latx, CultureInfo.InvariantCulture), Convert.ToDouble(lonx, CultureInfo.InvariantCulture));
                        distancia = sCoord.GetDistanceTo(eCoord);
                        distanciax = Convert.ToDouble(distancia, CultureInfo.InvariantCulture);
                    
                        string final = String.Format("{0:0.000}", distanciax / 1000) + " Km      " + String.Format("{0:0.000}", (distanciax / 1000) * 0.621) + " miles            ";



                        string reference = "";
                        string imgx = "";
                        achou = false;

                        if (tel1 != null)
                        {
                            LocaisEventos.Add(new locaisEventos() { iconrating = "/images/especial.png", data = tel1 + "   " + tel, titulo = nome, rating = rating, name = nome, address = ende, longitude = lonx, latitude = latx, icon = icon, reference = reference, tipo = tipox, img = imgx, distancia = distanciax, distStr = final + " " + tipox, pais = pais, cida = cida, checkin = checkin, especial = espe, iconespe = iconespe });
                        }

                }


                lb2.ItemsSource = LocaisEventos.ToList();

                if (lb2.ItemCount == 0)
                {
                    lb2.EmptyContent = "no taxi here";

                }
                else
                {
                    lb2.EmptyContent = " ";


                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                    ApplicationBar.IsMenuEnabled = true;

                }

                ligadesliga_tray(false, "");
                ligadesliga_busy(false);

            }

            catch (Exception ex)
            {

                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }
        }






        void PegaEvento_Completed(object sender, DownloadStringCompletedEventArgs e)
        {



            try
            {
                if (e.Error != null)
                {

                    MessageBox.Show(Localization.googleserver);
                 //   googleTerminou = true;
                    return;

                }






                XElement xmlDataStill = XElement.Parse(e.Result);


                var pega = xmlDataStill.ToString();







                int achou1 = pega.IndexOf("<page_count>");
                int achou2 = pega.IndexOf("</page_count>");

                string resto = pega.Substring(achou1 + 12, ((achou2 - achou1) - 12));

                conta = Convert.ToInt32(resto);

               



                foreach (var item in xmlDataStill.Descendants("event"))
                {


                 //   tpage.Text = "pages: " + pegando.ToString() + "/" + conta.ToString();


                    string name = (string)item.Element("venue_name").Value;
                    string address = (string)item.Element("venue_address").Value;
                    string cidade = (string)item.Element("city_name").Value;
                    string latitude = (string)item.Element("latitude").Value;
                    string longitude = (string)item.Element("longitude").Value;
                    string descri = (string)item.Element("description").Value;
                    string titulo = (string)item.Element("title").Value;
                     dtinicio = (string)item.Element("start_time").Value;
                     dtfim = (string)item.Element("stop_time").Value;
                    string url = (string)item.Element("url").Value;
                    string num = "0";


                    try
                    {
                        icon = (string)item.Element("image").Element("medium").Value;
                    }
                    catch
                    {

                        icon = "images/cara.png";
                    }




                    try
                    {
                        num = (string)item.Element("watching_count").Value;
                    }
                    catch
                    {
                        num = "0";
                    }


                    double testa = 0;
                    try
                    {
                        testa = Convert.ToDouble(num);
                    }
                    catch
                    {
                        testa = 0;
                    }

                    checkin = Convert.ToInt32(testa);
                    var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude, CultureInfo.InvariantCulture));
                    var eCoord = new GeoCoordinate(Convert.ToDouble(latitude, CultureInfo.InvariantCulture), Convert.ToDouble(longitude, CultureInfo.InvariantCulture));
                    distancia = sCoord.GetDistanceTo(eCoord);
                    distanciax = Convert.ToDouble(distancia, CultureInfo.InvariantCulture);
                    string final = String.Format("{0:0.000}", distanciax / 1000) + " Km      " + String.Format("{0:0.000}", (distanciax / 1000) * 0.621) + " miles            ";



                   


                    try
                    {
                        dtinix = Convert.ToDateTime(dtinicio);
                    }
                    catch
                    {
                        errodt = true;
                    }


                    

                    try
                    {
                        dtfimx = Convert.ToDateTime(dtfim);
                    }
                    catch
                    {
                        errodtfim = true;
                    }


                    

                    string monta = "Date: " + dtinix.ToString(CultureInfo.CurrentCulture);
                    if (errodtfim == false)
                    {
                        monta = monta + "   end: " + dtfimx.ToString();
                    }
                   
                    
                    
                    LocaisEventos.Add(new locaisEventos() { dataini=dtinix,  url=url,  name = name, address = address+" "+cidade, longitude = longitude, latitude = latitude, icon = icon, data = monta, distancia = distanciax, distStr = final + " " + tipox, checkin = checkin, titulo = titulo, descri=descri });
                }


               





                lb2.ItemsSource = LocaisEventos.ToList();

                if (lb2.ItemCount == 0)
                {
                    lb2.EmptyContent = Localization.tDose;

                }
                else
                {
                    lb2.EmptyContent = " ";


                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                //    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
                //    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                //    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;
                    ApplicationBar.IsMenuEnabled = true;

                }

                ligadesliga_tray(false, "");
                ligadesliga_busy(false);



            }



            catch (Exception ex)
            {
                MessageBox.Show(Localization.googleserver);
                return;
            }




        }

        private void lb2_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {



            return;


            if (lb2.ItemCount > 0)
            {







                try
                {



                    App.Passou = false;
                    App.Clicou = true;
                    locaisEventos sele = lb2.SelectedItem as locaisEventos;
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
                   // App.Checkin = sele.checkin;
                   
                        this.NavigationService.Navigate(new Uri("/LocalDetail.xaml", UriKind.RelativeOrAbsolute));

                }
                catch
                {
                    MessageBox.Show(Localization.m01);

                }









            }

        }//end of funt



        private void Start_Click(object sender, EventArgs e)
        {
            pegando = 1;
            PegaEvento(pegando);
        }

        private void End_click(object sender, EventArgs e)
        {
            
            
            //pegando = conta;
            PegaEvento(1);

        }

        private void next_click(object sender, EventArgs e)
        {
            pegando = pegando + 1;
            if (pegando > conta)
            {

                pegando = conta;

            }
            else
            {
                PegaEvento(pegando);

            }
        }

        private void prior_click(object sender, EventArgs e)
        {
            pegando = pegando - 1;
            if (pegando < 1)
            {

                pegando = 1;

            }
            else
            {
                PegaEvento(pegando);

            }
        }

        private void orderName(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.titulo, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true; });
            }

        }

        private void orderDistancia(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.distancia, x.name ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true; });
            }
        }

        private void orderRating(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.rating descending, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true; });
            }
        }

        private void orderCategoria(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.tipo, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true; });
            }
        }

        private void orderCheckin(object sender, EventArgs e)
        {
            lb2.ItemsSource = null;

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.checkin descending, x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true; });
            }
        }

    }




}