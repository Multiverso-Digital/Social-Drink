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

namespace Social_Drink
{
    public partial class Eventos : PhoneApplicationPage
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




        }

        public static List<locaisEventos> LocaisEventos = new List<locaisEventos>();







        public Eventos()
        {
            InitializeComponent();
            pegando = 1;
            PegaEvento(pegando);
            App.Passou = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
            PageTitle.Text = Localization.m504;






            ApplicationBar.IsMenuEnabled = false;
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

            
            ligadesliga_tray(true, "get Eventful database information...");
            ligadesliga_busy(true);


            lb2.ItemsSource = null;
            LocaisEventos.Clear();


            try
            {

                latx = App.LocCel.Latitude.ToString().Replace(",", ".");
                lonx = App.LocCel.Longitude.ToString().Replace(",", ".");
                string url = "";
                //url = "https://maps.googleapis.com/maps/api/place/search/xml?location=" + latx + "," + lonx + "&radius=" + App.Conf[0].GoogleRadius.ToString() + "&sensor=true&types=bakery|bar|cafe|casino|convenience_store|food|grocery_or_supermarket|liquor_store|night_club|restaurant&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";

                //url = "https://maps.googleapis.com/maps/api/place/search/xml?location=" + latx + "," + lonx + "&radius=" + App.wRadius.ToString() + "&sensor=true&types=&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4";


               // 23.746682,47.162741&within=100&date=Future

                DateTime dias90 = DateTime.Now.AddMonths(3);
                string data = DateTime.Now.ToString("yyyyMMdd00") + "-" + dias90.ToString("yyyyMMdd00");
                string local = App.Localoutro;


               // local = "São Paulo, Brazil";



                url = "http://api.eventful.com/rest/events/search?app_key=pWZrmN9mRwDwxsRd&location=" + local + "&date=" + data + "&sort_order=date&page_size=50&category=movies_film,music,art,attractions,festivals_parades&page_number=" + qtd.ToString();


               



                WebClient xmlClient = new WebClient();
                xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(PegaEvento_Completed);
                xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.googleserver);
               // googleTerminou = true;
                return;
            }





        }//end of funt





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
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                return;
            }


            XElement xmlDataStill;

                try
                {
                 xmlDataStill = XElement.Parse(e.Result);
                }
                catch (Exception ex)
                {
                MessageBox.Show(Localization.fsserver);
                return;
                }



                var pega = xmlDataStill.ToString();







                int achou1 = pega.IndexOf("<page_count>");
                int achou2 = pega.IndexOf("</page_count>");


                try
                {
                string resto = pega.Substring(achou1 + 12, ((achou2 - achou1) - 12));
                conta = Convert.ToInt32(resto);
                }
            catch
                {
                conta=0;
                }
               



                foreach (var item in xmlDataStill.Descendants("event"))
                {


                    tpage.Text = "pages: " + pegando.ToString() + "/" + conta.ToString();

                    string name="";

                    try
                    {
                    name = (string)item.Element("venue_name").Value;
                    }
                    catch
                    {
                    name ="";
                    }
                    
                    string address="";
                    try
                    {
                    address = (string)item.Element("venue_address").Value;
                    }
                    catch
                    {
                    address ="";
                    }
                    
                    string cidade="";
                    try
                    {
                    cidade = (string)item.Element("city_name").Value;
                    }
                    catch
                    {
                    cidade = "";
                    }
                    
                    string latitude="";
                    string longitude="";
                    try
                    {
                    latitude = (string)item.Element("latitude").Value;
                    longitude = (string)item.Element("longitude").Value;
                    }
                    catch
                    {
                    latitude ="";
                    longitude = "";
                    }
                    
                    
                    
                    string descri ="";
                    
                    try
                    {
                    
                    descri = (string)item.Element("description").Value;
                    }
                    catch
                    {
                    descri ="";
                    }
                    
                    string titulo ="";
                    try
                    {
                    titulo = (string)item.Element("title").Value;
                    }
                    catch
                    {
                    titulo ="";
                    }
                    
                    
                    try
                    {
                    dtinicio = (string)item.Element("start_time").Value;
                    }
                    catch
                    {
                    dtinicio ="";
                    }
                    
                    
                    try
                    {
                    dtfim = (string)item.Element("stop_time").Value;
                    }
                    catch
                    {
                        dtfim="";
                    }
                    
                    string url = "";
                    try
                    {
                    url = (string)item.Element("url").Value;
                    }
                    catch
                    {
                    url="";
                    }
                    
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
                    
                    
                    try
                    {
                    var sCoord = new GeoCoordinate(Convert.ToDouble(App.LocCel.Latitude, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocCel.Longitude, CultureInfo.InvariantCulture));
                    var eCoord = new GeoCoordinate(Convert.ToDouble(latitude, CultureInfo.InvariantCulture), Convert.ToDouble(longitude, CultureInfo.InvariantCulture));
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

                    final = String.Format("{0:0.000}", distanciax / 1000) + " Km      " + String.Format("{0:0.000}", (distanciax / 1000) * 0.621) + " miles            ";
                    }
                    catch
                    {
                    final="";
                    }


                   


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


                    string monta ="";

                    try
                    {
                    monta = "Date: " + dtinix.ToString(CultureInfo.CurrentCulture);
                    }
                    catch
                    {
                    monta ="";
                    }

                    if (errodtfim == false)
                    {
                        monta = monta + "   end: " + dtfimx.ToString();
                    }
                   
                    
                    
                    LocaisEventos.Add(new locaisEventos() { dataini=dtinix,  url=url,  name = name, address = address+" "+cidade, longitude = longitude, latitude = latitude, icon = icon, data = monta, distancia = distanciax, distStr = final + " " + tipox, checkin = checkin, titulo = titulo, descri=descri });
                }


               





                lb2.ItemsSource = LocaisEventos.ToList();

                if (lb2.ItemCount == 0)
                {
                    lb2.EmptyContent = Localization.m505+" "+App.Localoutro;

                }
                else
                {
                    lb2.EmptyContent = " ";


                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;

                    ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.m700.ToString();  //name
                    ((ApplicationBarMenuItem)ApplicationBar.MenuItems[1]).Text = Localization.m701.ToString();  //distancia
                    ((ApplicationBarMenuItem)ApplicationBar.MenuItems[2]).Text = Localization.m702.ToString();  //rating
                    ((ApplicationBarMenuItem)ApplicationBar.MenuItems[3]).Text = Localization.m703.ToString();  //categoria


                    ApplicationBar.IsMenuEnabled = true;

                }

                ligadesliga_tray(false, "");
                ligadesliga_busy(false);



            



        }

        private void lb2_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {

            if (lb2.ItemCount > 0)
            {







                try
                {



                    App.Passou = false;
                    App.Clicou = true;
                    locaisEventos sele = lb2.SelectedItem as locaisEventos;


                


                    App.LocRefe = sele.url;
              

                   
                    WebBrowserTask webbrowser = new WebBrowserTask();
                    webbrowser.URL = sele.url;
                    webbrowser.Show();



              


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
            pegando = conta;
            PegaEvento(pegando);

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
                          orderby x.titulo, x.dataini ascending
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

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.distancia, x.dataini ascending
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

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.dataini, x.distancia ascending
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

            List<locaisEventos> sorte = new List<locaisEventos>();
            sorte = LocaisEventos;
            var sortex = (from x in sorte
                          orderby x.name, x.dataini ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;


            if (lb2.ItemCount > 0)
            {
                Dispatcher.BeginInvoke(() => { ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true; });
            }
        }

    }




}