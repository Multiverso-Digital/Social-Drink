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
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Controls.Maps;

namespace Social_Drink
{
    public partial class Messages_FB : PhoneApplicationPage
    {


        string link = "";


        public Messages_FB()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded); 
    
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            eMens.Text = App.FBMens;



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





            if (App.LinkFoto != null)
            {




                this.image1.Visibility = Visibility.Visible;
                this.image1.Source = App.ImgTela.Source;
               // textBlock1.Visibility = Visibility.Collapsed;
                //image2.Visibility = Visibility.Collapsed;



            }
            else
            {
                this.image1.Visibility = Visibility.Visible;
               // textBlock1.Visibility = Visibility.Visible;
               // image2.Visibility = Visibility.Visible;

            }

            
        }


           

            private void Button_Send(object sender, EventArgs e)
            {
                try
                {
                    ShareLinkTask shareLinkTask = new ShareLinkTask();
                    shareLinkTask.LinkUri = new Uri(App.FBUrl, UriKind.Absolute);
                    shareLinkTask.Title = "Social Drink: Place Map";

                //    shareLinkTask.Message = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" /><title>Social Drink</title></head><html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"/><title>Social Drink</title></head><body><table width=\"64%\" border=\"1\"><tr><td>Social Drink</td></tr><tr><td>Frans Caf&eacute; - Rua Haddock Lobo 586</td></tr><tr><td>S&atilde;o Paulo - Brasil</td></tr><tr><td>Recomendo: Whisky Aberfeldy</td></tr><tr><td><a href=\"http://dev.virtualearth.net/embeddedMap/v1/ajax/aerial?zoomLevel=17&amp;center=-23.557752,-46.661682&amp;pushpins=-23.557752,-46.661682\" target=\"_blank\">Mapa:</a></td></tr><tr><td><a href=\"http://buddyplatform.s3.amazonaws.com/1479540_10_buddy_full.jpg\" target=\"_blank\">Photo:&nbsp;</a></td></tr></table></body></html>";

                    
              //      shareLinkTask.Message = App.FBMens + "Map place: " + App.FBUrl + Environment.NewLine + " Photo drink: " + App.LinkFoto;

                    shareLinkTask.Message = App.FBMens + Environment.NewLine + " Photo drink: " + App.LinkFoto;
            
                    
                    shareLinkTask.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Localization.m02.ToString());
                    return;
                }

            }

       


    }
}