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
using Microsoft.Phone.Shell;
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Controls.Maps;

namespace Social_Drink
{
    public partial class Messages_TW : PhoneApplicationPage
    {


        string link = "";


        public Messages_TW()
        {
            InitializeComponent();

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_sendmessage.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_linkmap.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).Text = Localization.b_linkphoto.ToString();


            this.Loaded += new RoutedEventHandler(MainPage_Loaded); 
    
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            string monta = App.bebida + " " + App.marca;
            eMens.Text = "";
            eMens.Text = Localization.ms43.ToString() + " " + App.LocName + " - " + App.LocAddress + Localization.ms44.ToString();
            eMens.Text += Localization.ms45.ToString() + monta;
            App.FBMens = eMens.Text;







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




                this.image2.Visibility = Visibility.Visible;
                this.image2.Source = App.ImgTela.Source;
                // textBlock1.Visibility = Visibility.Collapsed;
                //image2.Visibility = Visibility.Collapsed;



            }
            else
            {
                this.image2.Visibility = Visibility.Visible;
                // textBlock1.Visibility = Visibility.Visible;
                // image2.Visibility = Visibility.Visible;

            }








            if (App.FBMens.Length > 140)
            {

                App.TWMens = App.FBMens.Substring(0, 140);

            }
            else
            {

                App.TWMens = App.FBMens;
            }


           
        }






        private void tw()
        {


            //MessageBox.Show("Send message?");
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = App.TWMens;
            shareStatusTask.Show();
        }






        private void tw1()
        {
           

            App.TWMens = "SD place: " + App.FBUrl;
            ShareStatusTask shareStatusTask1 = new ShareStatusTask();
            shareStatusTask1.Status = App.TWMens;
            shareStatusTask1.Show();
            

        }

        private void tw2()
        {
           
            App.TWMens = "SD drink: " + App.LinkFoto;
            ShareStatusTask shareStatusTask2 = new ShareStatusTask();
            shareStatusTask2.Status = App.TWMens;
            shareStatusTask2.Show();

        }
            




       





         

          
          

            private void Button_tw1(object sender, EventArgs e)
            {
                tw();
            }

            private void Button_tw2(object sender, EventArgs e)
            {
                tw1();
            }

            private void Button_tw3(object sender, EventArgs e)
            {
                tw2();
            }

       


    }
}