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
using System.Windows.Media.Imaging;
using Microsoft.Expression.Interactivity.Layout;
using System.Windows.Interactivity;

namespace Social_Drink
{


       
        



    public partial class Frases_Inicio_07 : PhoneApplicationPage
    {

        int conta = 0;

        public class KarakaLista2
        {
            public string NomePacote { get; set; }
            public string IDPacote { get; set; }
            public string data { get; set; }
            public string icon { get; set; }
        }

        public static List<KarakaLista2> ListaKarakaGeral2 = new List<KarakaLista2>();
        
        public Frases_Inicio_07()
        {


            

            InitializeComponent();
            

            

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            foreach (App.KarakaLista x in App.ListaKarakaGeral)
            {
                ListaKarakaGeral2.Add(new KarakaLista2() { NomePacote = x.NomePacote, data = x.data, icon = "/images/FB_frase.png" });

            }


            lb3.ItemsSource = ListaKarakaGeral2.ToList();




        }






        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {





 
        }

        private void text_sel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
           
            
            
        }

        private void text_sel_LostFocus(object sender, RoutedEventArgs e)
        {
            

           


        }

        private void image5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void image6_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void image6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void img_copo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
              

        private void img_copo_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            
        }

        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Frases_Inicio_08.xaml", UriKind.RelativeOrAbsolute));

        }

        

       


    }
}