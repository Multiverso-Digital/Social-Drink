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


       
        



    public partial class Frases_Inicio_05 : PhoneApplicationPage
    {

        public class Karaka2
        {
            public int seq { get; set; }
            public int tipo { get; set; }
            public string album { get; set; }
            public string foto { get; set; }
            public string videologo { get; set; }
        }
        List<Karaka2> ListaKaraka2 = new List<Karaka2>();
        
        public Frases_Inicio_05()
        {


            

            InitializeComponent();
            

            

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.ListaKaraka[5].foto != null)
            {

                ListaKaraka2.Clear();

                foreach(App.Karaka x in App.ListaKaraka)
                {

                    string logo = x.foto;
                    if (x.tipo == 1)
                    {
                        logo = "/images/FB_frase.png";
                    }
                    if (x.tipo == 4)
                    {
                        logo = x.videologo;
                    }




                    if (x.tipo == 3)
                    {
                        string path = x.foto;
                        var bitmap = new BitmapImage(new Uri(path, UriKind.Absolute));
                        Uri uri = new Uri(path, UriKind.Absolute);
                        logo = uri.AbsoluteUri.ToString(); ;

                    }





                    if (x.foto != "")
                    {
                        ListaKaraka2.Add(new Karaka2() { album = x.album, foto = x.foto, seq = x.seq, tipo = x.tipo, videologo = logo });
                    }
                }

                //ListaKaraka2.RemoveAt(0);


                lb3.ItemsSource = ListaKaraka2.ToList();


                if (App.ListaKaraka[5].tipo == 4)
                {
                   // YouTube.Play(App.ListaKaraka[5].foto);
                }


            }



        }






        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            App.passa_param = 5;

            NavigationService.Navigate(new Uri("/Frases_YouTube.xaml", UriKind.RelativeOrAbsolute));
            lb3.Visibility = Visibility.Visible;


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

        private void image6_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Frases_Inicio_06.xaml", UriKind.RelativeOrAbsolute));

        }

        

       


    }
}