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
using System.Device.Location;
using System.Globalization;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;
using Buddy;
using Telerik.Windows.Controls;
using Microsoft.Phone.Tasks;
using System.Threading;
//using Telerik.Examples.WP.MessageBox;

namespace Social_Drink
{
    public partial class mapa_ende : PhoneApplicationPage
    {


        GeoCoordinate mapCenter;

        public mapa_ende()
        {
            InitializeComponent();

            eEnde.Text = App.LocAddress;
            eNome.Text = App.LocName;


            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_edit;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_delete;
           
            
            /*
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.m_duplicado;
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[1]).Text = Localization.m_fechado;
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[2]).Text = Localization.m_endereco;
            */

            if (App.LocName == App.LocID)
            {

                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;



            }
            else
            {
                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;


            }


            this.Loaded += new RoutedEventHandler(MainPage_Loaded);  



        }




        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {







            mapCenter = new GeoCoordinate(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));

            Pushpin pin1 = new Pushpin();
            int zoom = 16;
            pin1.Template = this.Resources["pinMyLoc"] as ControlTemplate;
            pin1.Location = mapCenter;
            pin1.FontSize = 12;
            pin1.Content += ("Here");
            map1.Children.Add(pin1);
            map1.Visibility = Visibility.Visible;
            map1.SetView(mapCenter, zoom);



           
            /*
            string realCulture = Thread.CurrentThread.CurrentCulture.Name;
            try
            {
                var directionsTask = new BingMapsDirectionsTask
                {
                    Start = new LabeledMapLocation("You", App.LocCel),
                    End = new LabeledMapLocation(App.LocAddress, mapCenter)                };

                // Switch to en-US culture before launching the task
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                directionsTask.Show();
            }
            catch (Exception error)
            {
               // MessageBox.Show ("Unable to start bing directions task");
                
            }
            finally
            {
                // Switch back to the culture we had before
               // Thread.CurrentThread.CurrentCulture = new CultureInfo(realCulture);
            }

            */


        }






        private void OpenDirectionTo()
        {  
            BingMapsDirectionsTask directionTask = new BingMapsDirectionsTask();
            directionTask.Start = new LabeledMapLocation("You", App.LocCel);
            directionTask.End = new LabeledMapLocation(App.LocName, mapCenter);
            directionTask.Show();
        }










        private void duplicado_Click(object sender, EventArgs e)
        {

            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.GeoLocation_Location_FlagCompleted += new EventHandler<Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs>(Get_Duplicado);
                client1.Service.GeoLocation_Location_FlagAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, App.LocID, "Dupe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        void Get_Duplicado(object sender, Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs e)
        {

            if (e.Error == null)
            {

                MessageBox.Show(Localization.ms60.ToString());
            }

        }










        private void fechado_Click(object sender, EventArgs e)
        {

            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.GeoLocation_Location_FlagCompleted += new EventHandler<Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs>(Get_Fechado);
                client1.Service.GeoLocation_Location_FlagAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, App.LocID, "Gone");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        void Get_Fechado(object sender, Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs e)
        {

            if (e.Error == null)
            {

                MessageBox.Show(Localization.ms60.ToString());
            }

        }




















        private void endereco_Click(object sender, EventArgs e)
        {


            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.GeoLocation_Location_FlagCompleted += new EventHandler<Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs>(Get_Endereco);
                client1.Service.GeoLocation_Location_FlagAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, App.LocID, "MisspelledCurrently");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        void Get_Endereco(object sender, Buddy.BuddyService.GeoLocation_Location_FlagCompletedEventArgs e)
        {

            if (e.Error == null)
            {

                MessageBox.Show(Localization.ms60.ToString());
            }

        }

        private void editar_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/edita_local.xaml", UriKind.RelativeOrAbsolute));
        }



        private void excluir_local()
        {

            
            
            for (int i=0; i < App.LocaisGoogle.Count-1;i++)
            {
            
                if (App.LocaisGoogle[i].name == App.LocName) {
                
                    App.LocaisGoogle.RemoveAt(i);

                }

            }
            
            
            
            



        }





        private void deletar_click(object sender, EventArgs e)
        {
            
            
            RadMessageBox.Show(new CustomHeaderedContentControl[] 

            { 
                new CustomHeaderedContentControl() { Title = "Yes", Message = "Yes. I want do this." },
                new CustomHeaderedContentControl() { Title = "No", Message = "No." },
                
            },
           "Close",
           "Do you want delete this place to " + App.LocName + "?",
           closedHandler: (args) =>
           {
               // ClickedButton will be null in the case when RadMessageBox is closed because the user pressed the hardware back button.
               if (args.ClickedButton == null)
               {
                   return;
               }

               CustomHeaderedContentControl option = (CustomHeaderedContentControl)args.ClickedButton.Content;
               if (option.Title == "Yes")
               {

                   excluir_local();


               }

               if (option.Title == "No")
               {
                   // Delete message.
               }


           });

        }

        private void drinks_click(object sender, EventArgs e)
        {


            App.LocNomMap = App.LocName;
            NavigationService.Navigate(new Uri("/EstaMyTrackPlace.xaml", UriKind.RelativeOrAbsolute));
        }

        private void map1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            OpenDirectionTo();


        }

        private void route_click(object sender, EventArgs e)
        {
            OpenDirectionTo();
        }





    }
}