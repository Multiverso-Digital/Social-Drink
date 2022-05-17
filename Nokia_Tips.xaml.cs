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
    public partial class Nokia_Tips : PhoneApplicationPage
    {

        public class TipsNokia
        {
            public string img_user { set; get; }
            public string Tip { set; get; }
            public string Nome { set; get; }
            public string Likes { set; get; }
            public string Data { set; get; }

        }

        public static List<TipsNokia> ListaTipsNokia = new List<TipsNokia>();



        public Nokia_Tips()
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

                ListaTipsNokia.Clear();

                for (int i = 0; i <= App.ResultNokia.media.reviews.items.Count - 1; i++)
                {

                    var resto = App.ResultNokia.media.reviews.items[i];





                    ListaTipsNokia.Add(new TipsNokia() { Data = resto.date.ToString(), Nome = resto.user.name + "   " + resto.date.ToString(), img_user = resto.supplier.icon, Tip = resto.description, Likes = resto.rating });




                }


                listBox.ItemsSource = ListaTipsNokia.ToList();

            }
            catch
            {

            }


            ligadesliga_busy(false);
            ligadesliga_tray(false, "");


        }




    }
}