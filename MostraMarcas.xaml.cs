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
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using Microsoft.Phone.Shell;

namespace Social_Drink
{
    public partial class MostraMarcas : PhoneApplicationPage
    {


  

        
        public MostraMarcas()
        {
            App.PassouMarca = false;
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);  
            
           
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            pegaBebida();
        }






        public void pegaBebida()
        {






            try
            { 




            busyIndicator.Content = Localization.busyIndicator;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_novo.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_delete.ToString();

            RadJumpList1.ItemsSource = null;
            eMarca.SuggestionsSource = null;

            string monta = App.bebida;


            if (App.bebida == "Caipirinha vodka") {

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



            this.busyIndicator.IsRunning = true;

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







            
            foreach (App.Marcas x in App.ListaMarcas){
                string ima = App.img.Replace("_00.png", "_03.png");
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
            eMarca.SuggestionsSource = lista.ToArray();



            busyIndicator.IsRunning = false;
            ApplicationBar.IsVisible = true;
            eMarca.Visibility = Visibility.Visible;


           this.busyIndicator.IsRunning = false;






            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }









        }



        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void radAutoCompleteBox_SuggestionSelected_1(object sender, Telerik.Windows.Controls.SuggestionSelectedEventArgs e)
        {
            listBox2.BringIntoView(e.SelectedSuggestion);
            listBox2.SelectedItem = e.SelectedSuggestion;


            GenericFilterDescriptor<App.Marcas> filtra = new GenericFilterDescriptor<App.Marcas>(delegate(App.Marcas a)
            {

                return a.Nome == e.SelectedSuggestion.ToString();


            });

            this.RadJumpList1.FilterDescriptors.Add(filtra);
        }

        private void radAutoCompleteBox_KeyUp(object sender, KeyEventArgs e)
        {  
            if (e.Key == Key.Enter)
            {        
                this.Focus();
            }
        }

        private void radAutoCompleteBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.RadJumpList1.FilterDescriptors.Clear();
            RadAutoCompleteBox  tb = (RadAutoCompleteBox)sender;
            tb.Background = new SolidColorBrush(Colors.LightGray);
            tb.BorderBrush = new SolidColorBrush(Colors.LightGray);
            tb.SelectionBackground = new SolidColorBrush(Colors.LightGray);
        }

       

        private void RadJumpList1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            if (RadJumpList1.SelectedItem != null)
            {

                App.Marcas task = RadJumpList1.SelectedItem as App.Marcas;
                eMarca.Text = task.Nome;
   
                
            }







            if (eMarca.Text.Trim().Length > 0)
            {




                if (App.bebida == null)
                {

                    MessageBox.Show(Localization.m36.ToString());
                    return;

                }
                else
                {
                    App.PassouMarca = true;
                    App.marca = eMarca.Text;
                    NavigationService.GoBack();
                    
                }
            }
            else
            {

                MessageBox.Show(Localization.m36.ToString());
                return;

            }







        }

        private void OK_Button(object sender, EventArgs e)
        {
            
        }

        private void Add_Button(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewMarca.xaml", UriKind.Relative)); 
        }

        private void Del_Button(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/DeletaMarcas.xaml", UriKind.Relative)); 

            
        }

        private void eMarca_LostFocus(object sender, RoutedEventArgs e)
        {
            RadAutoCompleteBox tb = (RadAutoCompleteBox)sender;
            tb.Background = new SolidColorBrush(Colors.LightGray);
            tb.BorderBrush = new SolidColorBrush(Colors.LightGray);
            tb.SelectionBackground = new SolidColorBrush(Colors.LightGray);
        }


    }
}