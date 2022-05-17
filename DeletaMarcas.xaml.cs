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
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Social_Drink
{
    public partial class DeletaMarcas : PhoneApplicationPage
    {

    
        public DeletaMarcas()
        {
            InitializeComponent();

          

            pegaBebida();
        }



        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public void pegaBebida()
        {






            try
            {




              //  busyIndicator.Content = Localization.busyIndicator;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_delete.ToString();
                RadJumpList1.ItemsSource = null;


                RadJumpList1.ItemsSource = App.ListaMarcas.ToList();

               

                /*


             

                                string monta = App.bebida;


                                if (App.bebida == "Caipirinha vodka")
                                {

                                    monta = "Vodka";
                                }

                                if (App.bebida == "Caipirinha cachaça")
                                {
                                    monta = "Cachaça";
                                }

                                if (App.bebida == "Chopp")
                                {
                                    monta = "Beer";
                                }




                                string arquivo = "SampleData/" + monta + ".xml"; ;



                                XDocument loadedData = XDocument.Load(arquivo);
                                var data = from query in loadedData.Descendants("Beer")
                                           select new App.Marcas
                                           {
                                               Nome = (string)query.Element("Nome")


                                           };


                                App.ListaMarcas = data.ToList();


                                foreach (App.OMarcas w in App.LOutras)
                                {
                                    if (w.Bebida == App.bebida)
                                    {
                                        App.ListaMarcas.Add(new App.Marcas() { Nome = w.Nome, img = w.img });
                                    }

                                }



               

                                var ListaOK = App.ListaMarcas.Except(App.ListaDelete);





                                foreach (App.Marcas x in App.ListaMarcas)
                                {
                                    string ima = App.img.Replace(".png", "_03.png");
                                    x.img = ima;
                                }



                                RadJumpList1.ItemsSource = App.ListaMarcas.ToList();



                                string[] lista = new string[App.ListaMarcas.Count];


                                for (int i = 0; i < App.ListaMarcas.Count; i++)
                                {

                                    lista[i] = App.ListaMarcas[i].Nome.ToString();
                                }







                                listBox2.ItemsSource = lista.ToArray();





                                RadJumpList1.SelectionChanged += List_SelectionChanged;



                                ApplicationBar.IsVisible = true;
         

         



                                */


            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }




                




        }

        private void RadJumpList1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {

        }

        private void Add_Button(object sender, EventArgs e)
        {

        }

        private void Del_Button(object sender, EventArgs e)
        {

        }







        private void cbAll_Click(object sender, RoutedEventArgs e)
        {
            
            
            
           if (RadJumpList1.ItemCount < 2) {return;} 
            
            
            
            
            
            
            
            
            
            if (cbAll.IsChecked == true)
            {



                this.RadJumpList1.CheckedItems.CheckAll();


            }
            else
            {
                this.RadJumpList1.CheckedItems.UncheckRange(0, RadJumpList1.ItemCount);
            }
        }

        private void Grava_Button(object sender, EventArgs e)
        {


            if (RadJumpList1.CheckedItems.Count == RadJumpList1.ItemCount)
            {

                MessageBox.Show("You cannot delete all items. Please uncheck one item!");
                return;

            }


            if (RadJumpList1.ItemCount < 2) { return; } 




            for (int i = 0; i <= RadJumpList1.CheckedItems.Count-1; i++)
            {


                App.Marcas task = RadJumpList1.CheckedItems[i] as App.Marcas;


                bool Tem = false;

                foreach (App.OMarcas x in App.LDelete)
                {
                    if (x.Nome.Trim().ToUpper() == task.Nome.Trim().ToUpper())
                    {
                        Tem = true;
                    }
                }



                if (Tem == false)
                {
                    App.LDelete.Add(new App.OMarcas { Bebida = App.bebida, img = task.img, Nome = task.Nome });
                    App.ListaDelete.Add(new App.Marcas { Nome = task.Nome, img = task.img });

                }


            }


            RadJumpList1.ItemsSource = null;
            List<App.Marcas> ListaOK = new List<App.Marcas>();
            foreach (App.Marcas x in App.ListaMarcas)
            {
                bool tem = false;
                foreach (App.OMarcas y in App.LDelete)
                {

                    

                    if ((x.Nome == y.Nome) && (App.bebida == y.Bebida))
                    {
                        tem = true;
                    }


                }

                if (tem == false) 
                {
                
                ListaOK.Add(new App.Marcas() { Nome = x.Nome, img = x.img });


                  }


            }


            App.ListaMarcas = ListaOK.ToList();
            RadJumpList1.ItemsSource = App.ListaMarcas.ToList();


            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }




        }



    }
}