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
using System.IO.IsolatedStorage;
//using Newtonsoft.Json.Schema;
using System.Windows.Media.Imaging;

namespace Social_Drink
{
    public partial class Mostra_Trofeus : PhoneApplicationPage
    {
        public Mostra_Trofeus()
        {
            InitializeComponent();
            App.Passou = true;
        }

        private void Captura_Click(object sender, EventArgs e)
        {
            //Capture the screen and set it to the internal picture box
            WriteableBitmap bmp = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
            bmp.Render(this, null);
            bmp.Invalidate();
            this.image1.Source = bmp;


            App.ImgTela = new Image();
            App.ImgTela.Source = this.image1.Source;


            

            String tempJPEG = "tela01.jpg";

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }
                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(tempJPEG);

               Extensions.SaveJpeg(bmp, fileStream, bmp.PixelWidth, bmp.PixelHeight, 0, 85);
                //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                fileStream.Close();
            }



            

            NavigationService.Navigate(new Uri("/Mostra_Foto_Tela.xaml", UriKind.RelativeOrAbsolute));
           


            
            
            
            //Set a new background
            
            /*
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(NextImage, UriKind.Relative));
            ContentGrid.Background = brush;
            */


        

        }
    }
}