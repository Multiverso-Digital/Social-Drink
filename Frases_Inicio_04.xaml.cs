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

namespace Social_Drink
{
    public partial class Frases_Inicio_04 : PhoneApplicationPage
    {
        public Frases_Inicio_04()
        {
            InitializeComponent();
            img_sel.Visibility = Visibility.Collapsed;
            text_sel.Visibility = Visibility.Collapsed;

        this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.ListaKaraka[4].foto != null)
            {
                if (App.ListaKaraka[4].tipo == 1)
                {
                    text_sel.Visibility = Visibility.Visible;
                    img_sel.Visibility = Visibility.Collapsed;
                    text_sel.Text = App.ListaKaraka[4].foto;
                    tconta.Visibility = Visibility.Visible;
                }


                if (App.ListaKaraka[4].tipo == 2)
                {
                    img_sel.Visibility = Visibility.Visible;
                    text_sel.Visibility = Visibility.Collapsed;
                    string testa = App.ListaKaraka[4].foto;
                    Uri uri1 = new Uri(testa, UriKind.RelativeOrAbsolute);
                    ImageSource imgSource1 = new BitmapImage(uri1);
                    img_sel.Source = imgSource1;
                    tconta.Visibility = Visibility.Collapsed;
                }

                if (App.ListaKaraka[4].tipo == 3)
                {
                    string path = App.ListaKaraka[4].foto;
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
                App.passa_param = 4;
                NavigationService.Navigate(new Uri("/Frases_Feitas.xaml", UriKind.RelativeOrAbsolute));
            }
            
            
          
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
            App.passa_param = 4;
            NavigationService.Navigate(new Uri("/Frases_Pega_Imagem.xaml", UriKind.RelativeOrAbsolute));
            
            
        }

        private void text_sel_LostFocus(object sender, RoutedEventArgs e)
        {
            text_sel.Foreground = new SolidColorBrush(Colors.Yellow);

            foreach (App.Karaka x in App.ListaKaraka)
            {
                
                if (x.seq == 4)
                {
                    x.foto = text_sel.Text;
                    x.tipo = 1; //Foto Facebook
                }

            }


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
            if (App.ListaKaraka[4].foto != "")
            {

                NavigationService.Navigate(new Uri("/Frases_Inicio_05.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {

                MessageBox.Show("Cannot go to next object if you dont create the object 4");
            }
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            App.ListaKaraka[4].album = App.ListaKaraka[3].album;
            App.ListaKaraka[4].foto = App.ListaKaraka[3].foto;
            App.ListaKaraka[4].tipo = App.ListaKaraka[3].tipo;
            App.ListaKaraka[4].seq = 4;
            MainPage_Loaded(null, null);
        }

        private void text_sel_TextChanged(object sender, TextChangedEventArgs e)
        {
            tconta.Text = text_sel.Text.Length.ToString() + "/200";
        }

        private void mouse_enter(object sender, MouseEventArgs e)
        {
            text_sel.Foreground = new SolidColorBrush(Colors.Black);
        }

        

       


    }
}