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
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Controls.Maps;

namespace Social_Drink
{
    public partial class Messages_SMS : PhoneApplicationPage
    {


        string link = "";


        public Messages_SMS()
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




        }



    




    
    


    


  
       

        private void eSMS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();

            }
        }

       

       



       




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumberChooserTask PhoneNrChooserTask = new PhoneNumberChooserTask();

            PhoneNrChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

            PhoneNrChooserTask.Show();
        }

            void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
            {

              if (e.TaskResult == TaskResult.OK)
              {
                  

                  eSMS.Text = e.PhoneNumber.ToString();
                  tSMS.Text = Localization.ms48.ToString() + e.DisplayName.ToString();

                  
                 
              }

            }

           

            private void Button_SMS(object sender, EventArgs e)
            {
                if (eSMS.Text.Trim().Length == 0)
                {

                    MessageBox.Show(Localization.ms47.ToString());
                    return;
                }




                SmsComposeTask composeSMS = new SmsComposeTask();
                composeSMS.Body = App.FBMens + "Map place: " + App.FBUrl + Environment.NewLine + " Photo drink: " + App.LinkFoto;
                composeSMS.To = eSMS.Text;
                composeSMS.Show();
            }

       
       


    }
}