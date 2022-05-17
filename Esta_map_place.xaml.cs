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
using PushpinClusterer;

namespace Social_Drink
{
    public partial class Esta_map_place : PhoneApplicationPage
    {
        BuddyClient client = new BuddyClient(Constants.AppName, Constants.AppPass);

        AuthenticatedUser user = null;

        List<CheckInLocation> check = new List<CheckInLocation>();
        List<MyGeoObject> pins = new List<MyGeoObject>();
        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };



        public Esta_map_place()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {



            Executa_Check();
            
            
          

        }





        public void Executa_Check()
        {



            pins.Clear();

            string latx = Convert.ToString(App.LocLat, CultureInfo.InvariantCulture);
            string lonx = Convert.ToString(App.LocLon, CultureInfo.InvariantCulture);
            var laty = latx.Replace(",", ".");
            var lony = lonx.Replace(",", ".");
            string monta = "%<A0_local>%";



          

            try
            {
                client.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(User_CheckIn);
                client.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "50", monta, "", "-1", "0", "99999", "1", "DESC", "true");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LigaDesligaProgress(false, "");
                return;
            }

        }




        void User_CheckIn(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {

            int achou_i1  = 0;
            int achou_f1 = 0;
            int achou_i2 = 0;
            int achou_f2 = 0;

            string localx = "";
            string paisx = "";




            if (e.Error == null)
            {

                if (e.Result != null)
                {


                    for (int i = 0; i < e.Result.Count; i++)
                    {

                        achou_i1 = e.Result[i].MetaKey.IndexOf("<A0_local>");
                        achou_f1 = e.Result[i].MetaKey.IndexOf("</A0_local>");
                        achou_i2 = e.Result[i].MetaKey.IndexOf("<A0_pais>");
                        achou_f2 = e.Result[i].MetaKey.IndexOf("</A0_pais>");



                        localx = e.Result[i].MetaKey.Substring(achou_i1 + 10, achou_f1 - (achou_i1 + 10));
                        paisx = e.Result[i].MetaKey.Substring(achou_i2 + 9, achou_f2 - (achou_i2 + 9));



                        pins.Add(new MyGeoObject() { Coordinate = new GeoCoordinate(Convert.ToDouble(e.Result[i].MetaLatitude, CultureInfo.InvariantCulture), Convert.ToDouble(e.Result[i].MetaLongitude, CultureInfo.InvariantCulture)), Country = paisx, Name = localx });

                    }


                    MostraMapa();

                }



            }
            else
            {
                MessageBox.Show(e.Error.ToString());

            }




        }
        
        
        
        
        
        
        private void PegaCheckin()
        {


            client.LoginAsync((result, state) =>
            {
                if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                else
                {
                    user = result;

                   



               




                    user.GetCheckInsAsync((p1, ex1) =>
                    {

                        


                        if (ex1.Completed == true)
                        {

                            check = p1;


                            if (check  != null)
                            {


                                MostraMapa();



                            }
                            else
                            {
                                //MessageBox.Show("Já existe" + x.Key);
                            }



                        }

                    } );

                    //}, Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture), App.LocName);
                }









            }, App.Conf[0].UserToken);






        }








        private void MostraMapa()
        {

/*
            List<MyGeoObject> pins = new List<MyGeoObject>();
            
            foreach (CheckInLocation x in check)
            {


                string lat = x.Latitude.ToString(CultureInfo.InvariantCulture);
                string lon = x.Longitude.ToString(CultureInfo.InvariantCulture);

            float latx = Convert.ToSingle(lat, CultureInfo.InvariantCulture);
            float lonx = Convert.ToSingle(lon, CultureInfo.InvariantCulture); 

                
                
                if ((latx > -90) && (latx < 90) && (lonx > -90) && (lonx < 90))
                {

                    pins.Add(new MyGeoObject() { Country = "", Name = x.PlaceName, Coordinate = new GeoCoordinate(x.Latitude, x.Longitude) });

                }
            }
            */



            if (pins.Count > 0)
            {

                int zoom = 5;

                map1.SetView(pins[pins.Count - 1].Coordinate, zoom);


                map1.ZoomBarVisibility = System.Windows.Visibility.Visible;


                var clusterer = new PushpinClusterer<MyGeoObject>(map1, pins, 50);
                pushPinModelsLayer.DataContext = clusterer;
            }
          
        }








        public void LigaDesligaBuzy(bool valor)
        {
            this.busyIndicator.IsRunning = valor;
        }

        public void LigaDesligaProgress(bool valor, string texto)
        {
            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }

       

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new AerialMode();
        }

        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            map1.Mode = new RoadMode();
        }

    }
}