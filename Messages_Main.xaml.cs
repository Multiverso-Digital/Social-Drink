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
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using Buddy;
using System.ComponentModel;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using System.Globalization;

namespace Social_Drink
{
    public partial class Messages_Main : PhoneApplicationPage
    {

        public byte[] byteArray0;
        public List<ViewModel> items = new List<ViewModel>();
        string link = "";
        public class ViewModel
        {


            public string urlF
            {
                get;
                set;
            }

            public string urlT
            {
                get;
                set;
            }


            public BitmapImage bit
            {
                get;
                set;
            }
        }


        private BackgroundWorker backgroundWorker;


        public Messages_Main()
        {
            InitializeComponent();
         //   Uri uri = new Uri("/images/camera.png", UriKind.Relative);
         //   ImageSource imgSource = new BitmapImage(uri);
        //    this.image2.Source = imgSource;
         //   textBlock1.Visibility = Visibility.Visible;
         //   image2.Visibility = Visibility.Visible;
            image1.Source = null;



            GeoCoordinate mapCenter = new GeoCoordinate(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));
            Pushpin pin1 = new Pushpin();
            int zoom = 16;
            pin1.Template = this.Resources["pinMyLoc"] as ControlTemplate;
            pin1.Location = mapCenter;
            pin1.FontSize = 12;
            pin1.Content += ("Here");
            map1.Children.Add(pin1);
            map1.Visibility = Visibility.Visible;
            map1.SetView(mapCenter, zoom);





            this.Loaded += new RoutedEventHandler(MainPage_Loaded); 
    
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.LinkFoto != null)
            {
                link = App.LinkFoto;

            }
            else
            {
                link = "";
            }



            Monta_Mens();
           
        }


        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


          

            // Do nothing here. This method is called when the back ground worker ends its execution.

        }



        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            


        }





        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {







            if (App.LinkFoto != null)
            {



                /*
                Uri uri2 = new Uri(App.LocFotoFileName0, UriKind.Absolute);
                ImageSource imgSource1 = new BitmapImage(uri2);
                this.image1.Source = imgSource1;
                this.image1.Visibility = Visibility.Visible;
                image2.Visibility = Visibility.Collapsed;
                */
                this.image1.Visibility = Visibility.Visible;
                this.image1.Source = App.ImgTela.Source;



            }
            else
            {
                this.image1.Visibility = Visibility.Visible;
             //   textBlock1.Visibility = Visibility.Visible;
                //image2.Visibility = Visibility.Visible;

            }
          


        }







        private void cbSend_Click(object sender, RoutedEventArgs e)
        {
            Monta_Mens();
        }




        private void Monta_Mens()
        {
            string monta = App.bebida + " " + App.marca;
            
            eMens.Text = "";
            
            eMens.Text = Localization.ms42.ToString() + " " + App.LocName + " - " + App.LocAddress + Environment.NewLine;
                
            if (eMais.Text.Trim().Length > 0)
                {
                    eMens.Text += Localization.ms45.ToString() + monta + " " + eMais.Text.Trim() + Environment.NewLine;
                }
                else
                {
                    eMens.Text += Localization.ms45.ToString() + monta+ Environment.NewLine;
                }


                if (eMens.Text.Length > 190)
                {
                    MessageBox.Show(Localization.ms66.ToString());

                }




            App.FBMens = eMens.Text;








        }



        private void Button_Send(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            NavigationService.Navigate(new Uri("/Messages_FB.xaml", UriKind.RelativeOrAbsolute));

                      

        }

        private void Button_SMS(object sender, EventArgs e)
        {

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            NavigationService.Navigate(new Uri("/Messages_SMS.xaml", UriKind.RelativeOrAbsolute));



        }





        public static byte[] ImageToByteArray(BitmapSource bitmapSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                WriteableBitmap writableBitmap = new WriteableBitmap(bitmapSource);
                System.Windows.Media.Imaging.Extensions.SaveJpeg(writableBitmap, stream, bitmapSource.PixelWidth, bitmapSource.PixelHeight, 0, 100);
                return stream.ToArray();
            }
        }










        private void Button_Email(object sender, EventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }

            NavigationService.Navigate(new Uri("/Messages_Email.xaml", UriKind.RelativeOrAbsolute));
            


        }


            private void image2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
            {
                this.NavigationService.Navigate(new Uri("/MostraFotoPlace.xaml", UriKind.RelativeOrAbsolute));
            }

            private void Button_tw(object sender, EventArgs e)
            {

                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show(Localization.m01.ToString());
                    //NavigationService.GoBack();
                    return;
                }

                NavigationService.Navigate(new Uri("/Messages_TW.xaml", UriKind.RelativeOrAbsolute));
            
            }

            private void eMais_KeyUp(object sender, KeyEventArgs e)
            {


                if (e.Key == Key.Enter)
                {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                    this.Focus();
                    Monta_Mens();
                }



               

            }

            private void image1_ImageOpened(object sender, RoutedEventArgs e)
            {

            }

       


    }
}