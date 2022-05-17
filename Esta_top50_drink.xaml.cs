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

namespace Social_Drink
{
    public partial class Esta_top50_drink : PhoneApplicationPage
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
            public string bebidaU { get; set; }
            public string marcaU { get; set; }
            public string drinksU { get; set; }  
            public string img     { get; set; }
        }




        public static List<UserDrinks> ListaDrinks = new List<UserDrinks>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();

        double TotalU { get; set; }
        double TotalD { get; set; }


        public Esta_top50_drink()
        {
            InitializeComponent();

            if (App.Conf[0].NET == false) {
                MessageBox.Show(Localization.m85.ToString());
                return; }

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            busyIndicator.Content = Localization.busyIndicator;
         //   p11header.Header = Localization.p11header;
            p12header.Header = Localization.p32header;
            busyIndicator.IsRunning = true;
         eLogou.Text = App.LocName;
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

            string monta = "%<A8>%";

            try
            {

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "50", monta, "", "-1", "0", "9999999", "1", "DESC", "true");
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
          



            string bebidax = "";
            string marcax = "";
       





          
            ListaDrinksApp.Clear();

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


                        achou_i1 = e.Result[i].MetaKey.IndexOf("<A8_bebida>");
                        achou_f1 = e.Result[i].MetaKey.IndexOf("</A8_bebida>");
                        achou_i2 = e.Result[i].MetaKey.IndexOf("<A8_marca>");
                        achou_f2 = e.Result[i].MetaKey.IndexOf("</A8_marca>");
                   





                        if (achou_i1 != -1)
                        {


                            bebidax = e.Result[i].MetaKey.Substring(achou_i1 + 11, achou_f1 - (achou_i1 + 11));
                            marcax = e.Result[i].MetaKey.Substring(achou_i2 + 10, achou_f2 - (achou_i2 + 10));
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


                            long valor = 0;
                            long.TryParse(e.Result[i].MetaValue, out valor);
                            double conta = Convert.ToDouble(valor);
                            string monta = conta.ToString();
                            TotalD = TotalD + conta;


                            ListaDrinksApp.Add(new UserDrinks() { img = imgx, drinksU = "drinks: "+e.Result[i].MetaValue, bebidaU = bebidax, marcaU = marcax });

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

        private void Add_Button(object sender, EventArgs e)
        {

        }

        private void Atualiza_Button(object sender, EventArgs e)
        {

        }

        private void Pivot_LayoutUpdated(object sender, EventArgs e)
        {

            

        }

        private void PivotGeral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }






    }
}