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
    public partial class Frases_UmaFoto : PhoneApplicationPage
    {
        public Frases_UmaFoto()
        {
            InitializeComponent();

            busyIndicator.IsRunning = true;


        

            if (App.passa_param != null)
            {
            
                App.FBAlbumPhoto = App.ListaKaraka[App.passa_param].foto;  
               
                    
                    
        

                string testa = App.FBAlbumPhoto.Replace("_s", "_n");
                App.ListaKaraka[App.passa_param].foto = testa;
                Uri uri1 = new Uri(testa, UriKind.RelativeOrAbsolute);
                ImageSource imgSource1 = new BitmapImage(uri1);
                image1.Source = imgSource1;
                busyIndicator.IsRunning = false;
                button1.Visibility = Visibility.Visible;

            }

/*

            }
            else
            {
                Uri uri1 = new Uri(App.CameraAlbumPhoto, UriKind.RelativeOrAbsolute);
                ImageSource imgSource1 = new BitmapImage(uri1);
                image1.Source = imgSource1;
                busyIndicator.IsRunning = false; 
            }

                */

            
                
                


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            App.PegouFoto = true;
            NavigationService.GoBack();


        }
    }
}