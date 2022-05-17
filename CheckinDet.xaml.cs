﻿using System;
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
using System.Globalization;

namespace Social_Drink
{
    public partial class CheckinDet : PhoneApplicationPage
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
            public string localU  { get; set; }  
            public string dataU   { get; set; }
            public string img     { get; set; }
            public double mlY     { get; set; }
            public string mlU { get; set; }
            //public string marcaU { get; set; }


        }




        public static List<UserDrinks> ListaDrinks = new List<UserDrinks>();
        public static List<UserDrinks> ListaDrinksApp = new List<UserDrinks>();

        double TotalU { get; set; }
        double TotalD { get; set; }


        public CheckinDet()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            busyIndicator.Content = Localization.busyIndicator;
            p11header.Header = Localization.p11header;
            p12header.Header = Localization.p12header;
            busyIndicator.IsRunning = true;
         eLogou.Text = App.LocName;
        // pegaBebida();
         ListaUser();
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




        private void ListaUser()
        {
            //string monta = "<A3>" + App.LocName;

           string monta = "<A1_local>" + App.LocName + "</A1_local>";

        
            
            try
          {

             BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
              client1.Service.MetaData_UserMetaDataValue_SearchCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs>(Get_UserMeta_Drinks);
              client1.Service.MetaData_UserMetaDataValue_SearchAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, "-1","-1","-1","50",monta,"","-1","0","0","");
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
              return;
          }
          }

        void Get_UserMeta_Drinks(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SearchCompletedEventArgs e)
        {
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




  
            ListaDrinks.Clear();

            TotalU = 0;

            if (e.Error == null)
            {
                if (e.Result.Count == 0)
                {
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

                        double testa = Convert.ToDouble(valorx) / 1000;

   

                        App.pegaimg(bebidax);
                        string imgx = App.img;
                        string ima = imgx.Replace("_00.png", "_03.png");


                      
                        TotalU = TotalU + 1;


                  




                        ListaDrinks.Add(new UserDrinks() { img = ima, dataU = datax, localU = marcax, bebidaU = bebidax });
                       
                    }


                    List<UserDrinks> fra = new List<UserDrinks>();
                    fra = ListaDrinks;
                    var resu = (from x in fra
                                orderby x.dataU descending, x.bebidaU ascending, x.localU ascending
                                select x).ToList();



                    lb2.ItemsSource = resu.ToArray();
                    eTotal.Text =  "drinks: "+ TotalU.ToString();
                    busyIndicator.IsRunning = false;
                }



            }


            busyIndicator.IsRunning = false;
        }




        private void ListaApp()
        {


            // 0 = <i0>local</i0><i01>drinks</i01>
            // 1 = <i1>local</i1><i11>bebida</i11>
            // 2 = <i2>local</i2><i21>bebida</i21><i22>marca</i22>
            // 3 = <i3>local</i3><i31>bebida</i31>
            // 4 = <i4>local</i4><i41>bebida</i41><i42>marca</i42>
            
           // string monta = "%<i3>"  +App.LocName+"%";


           // string chave7 = "<41><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL><PB>" + bebida + "</PB><PM>" + marca + "</PM></41>";

            
            string monta = "<41>%<PL>" + App.LocName + "</PL>%";

            try
            {

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "50", monta, "", "-1", "0", "99999", "1", "DESC", "true");
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
            int achou_i4 = 0;
            int achou_f4 = 0;
            int achou_i5 = 0;
            int achou_f5 = 0;



            string localx = "";
            string bebidax = "";
            string marcax = "";
            string paisx = "";
            string cidax = "";






          
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


                        achou_i1 = e.Result[i].MetaKey.IndexOf("<PL>");
                        achou_f1 = e.Result[i].MetaKey.IndexOf("</PL>");
       
                        achou_i2 = e.Result[i].MetaKey.IndexOf("<PB>");
                        achou_f2 = e.Result[i].MetaKey.IndexOf("</PB>");
       
                        achou_i3 = e.Result[i].MetaKey.IndexOf("<PM>");
                        achou_f3 = e.Result[i].MetaKey.IndexOf("</PM>");

                        achou_i4 = e.Result[i].MetaKey.IndexOf("<PC>");
                        achou_f4 = e.Result[i].MetaKey.IndexOf("</PC>");

                        achou_i5 = e.Result[i].MetaKey.IndexOf("<PP>");
                        achou_f5 = e.Result[i].MetaKey.IndexOf("</PP>");




                        if (achou_i1 != -1)
                        {


                            localx = e.Result[i].MetaKey.Substring(achou_i1 + 4, achou_f1 - (achou_i1 + 4));
                            bebidax = e.Result[i].MetaKey.Substring(achou_i2 + 4, achou_f2 - (achou_i2 + 4));
                            marcax = e.Result[i].MetaKey.Substring(achou_i3 + 4, achou_f3 - (achou_i3 + 4));
                            cidax = e.Result[i].MetaKey.Substring(achou_i4 + 4, achou_f4 - (achou_i4 + 4));
                            paisx = e.Result[i].MetaKey.Substring(achou_i5 + 4, achou_f5 - (achou_i5 + 4));
                   


                            

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


                            string ima = imgx.Replace("_00.png", "_03.png");
                       

                           
                            TotalD = TotalD + 1;


                            double mlx = Convert.ToDouble(e.Result[i].MetaValue)/1000;


                            ListaDrinksApp.Add(new UserDrinks() { img = ima, localU = marcax, bebidaU = bebidax });

                        }



                    }



                    List<UserDrinks> fra1 = new List<UserDrinks>();
                    fra1 = ListaDrinksApp;
                    var resu1 = (from x in fra1
                                orderby x.mlY descending, x.bebidaU ascending, x.localU ascending
                                select x).ToList();



                    lb3.ItemsSource = resu1.ToArray();
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
            if (PivotGeral.SelectedIndex == 0)
            {

                eTotal.Text = Localization.ms40.ToString() +" "+ TotalU.ToString();

            }
            else
            {
                eTotal.Text = Localization.ms41.ToString() +" "+ TotalD.ToString();
            }
        }

        private void tap_lb2(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
        }






    }
}