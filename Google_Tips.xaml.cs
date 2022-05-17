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
//using findfood;
using Microsoft.Phone.Shell;

namespace Social_Drink
{
    public partial class Google_Tips : PhoneApplicationPage
    {

        public class TipsGoogle
        {
            public string img_user { set; get; }
            public string Tip { set; get; }
            public string Nome { set; get; }
            public string Likes { set; get; }
            public string Data { set; get; }

        }

        public static List<TipsGoogle> ListaTipsGoogle = new List<TipsGoogle>();



        public Google_Tips()
        {
            InitializeComponent();
            tLocal.Text = App.LocName;
            ligadesliga_busy(true);
            ligadesliga_tray(true, "Waiting...");
            PegaTips();
        }




        public ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };

        public void ligadesliga_busy(bool valor)
        {
            busyIndicator.Content = Localization.busyIndicator.ToString();
            this.busyIndicator.IsRunning = valor;
        }

        public void ligadesliga_tray(bool valor, string texto)
        {
            SystemTray.IsVisible = valor;
            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }






        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static readonly double MaxUnixSeconds = (DateTime.MaxValue - UnixEpoch).TotalSeconds;

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return unixTimeStamp > MaxUnixSeconds
               ? UnixEpoch.AddMilliseconds(unixTimeStamp)
               : UnixEpoch.AddSeconds(unixTimeStamp);
        }


        public void PegaTips()
        {
            try
            {

                ListaTipsGoogle.Clear();

                for (int i = 0; i <= App.ResultGoogle.result.reviews.Count - 1; i++)
                {

                    var resto = App.ResultGoogle.result.reviews[i];



                    double datay = Convert.ToDouble(resto.time);
                    DateTime datax = UnixTimeStampToDateTime(datay);

                    ListaTipsGoogle.Add(new TipsGoogle() { Data = datax.ToString(), Nome = resto.author_name, img_user = "images/pensa.png", Tip = resto.text, Likes = resto.aspects[0].rating });




                }


                listBox.ItemsSource = ListaTipsGoogle.ToList();

            }
            catch
            {

            }



            ligadesliga_busy(false);
            ligadesliga_tray(false, "");


        }




    }
}