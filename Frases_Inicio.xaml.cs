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

using System.Xml.Linq;


namespace Social_Drink
{
    public partial class Frases_Inicio : PhoneApplicationPage
    {

       

        public Frases_Inicio()
        {
            InitializeComponent();
            img_sel.Visibility = Visibility.Collapsed;
            text_sel.Visibility = Visibility.Collapsed;

        this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.ListaKaraka[1].foto != null)
            {
                if (App.ListaKaraka[1].tipo == 1)
                {
                    text_sel.Visibility = Visibility.Visible;
                    img_sel.Visibility = Visibility.Collapsed;
                    text_sel.Text = App.ListaKaraka[1].foto;
                    tconta.Visibility = Visibility.Visible;
                }


                if (App.ListaKaraka[1].tipo == 2)
                {
                    img_sel.Visibility = Visibility.Visible;
                    text_sel.Visibility = Visibility.Collapsed;
                    string testa = App.ListaKaraka[1].foto;
                    Uri uri1 = new Uri(testa, UriKind.RelativeOrAbsolute);
                    ImageSource imgSource1 = new BitmapImage(uri1);
                    img_sel.Source = imgSource1;
                    tconta.Visibility = Visibility.Collapsed;
                }

                if (App.ListaKaraka[1].tipo == 3)
                {
                    string path = App.ListaKaraka[1].foto;
                    var bitmap = new BitmapImage(new Uri(path, UriKind.Absolute));
                    img_sel.Source = bitmap;
                    tconta.Visibility = Visibility.Collapsed;

                }

                



            }



        }






        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {



           MessageBoxResult result =
           MessageBox.Show("Would you like a litle help with famous quotes and phrases?",
           "Message", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.Cancel)
            {

            img_sel.Visibility = Visibility.Collapsed;
            text_sel.Visibility = Visibility.Visible;           
            text_sel.Focus();
            

            }
            else
            {
                App.passa_param = 1;
                NavigationService.Navigate(new Uri("/Frases_Feitas.xaml", UriKind.RelativeOrAbsolute));
            }




            
            
            /*
            img_sel.Visibility = Visibility.Collapsed;
            text_sel.Visibility = Visibility.Visible;           
            text_sel.Focus();
            */




        }

        private void text_sel_KeyUp(object sender, KeyEventArgs e)
        {

            tconta.Text = text_sel.Text.Length.ToString() + "/200";
            
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            img_sel.Visibility = Visibility.Visible;
            text_sel.Visibility = Visibility.Collapsed;
            App.passa_param = 1;
            NavigationService.Navigate(new Uri("/Frases_Pega_Imagem.xaml", UriKind.RelativeOrAbsolute));
            
            
        }

        private void text_sel_LostFocus(object sender, RoutedEventArgs e)
        {

            text_sel.Foreground = new SolidColorBrush(Colors.Yellow);
            
            tconta.Text = text_sel.Text.Length.ToString()+"/200";

            foreach (App.Karaka x in App.ListaKaraka)
            {
                
                if (x.seq == 1)
                {
                    x.foto = text_sel.Text;
                    x.tipo = 1; //Foto Facebook
                }

            }


        }

        private void image6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            


            if (App.ListaKaraka[1].foto != "")
            {

                NavigationService.Navigate(new Uri("/Frases_Inicio_02.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {

                MessageBox.Show("Cannot go to next object if you dont create the object 1");
            }
            
        }

        private void text_sel_TextChanged(object sender, TextChangedEventArgs e)
        {
            tconta.Text = text_sel.Text.Length.ToString() + "/200";
        }

        private void text_sel_MouseEnter(object sender, MouseEventArgs e)
        {
            text_sel.Foreground = new SolidColorBrush(Colors.Black);
        }



        

    }
}