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
using Newtonsoft.Json;

namespace Social_Drink
{
    public partial class FS_Tips : PhoneApplicationPage
    {

        public int conta = 0;
        public int pegando = 0;



        public class TipsFS
        {
            public string img_user { set; get; }
            public string Tip { set; get; }
            public string Nome { set; get; }
            public string Likes { set; get; }
            public string Data { set; get; }

        }

        public static List<TipsFS> ListaTipsFS = new List<TipsFS>();

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

        public FS_Tips()
        {
            InitializeComponent();


            try
            {


                tLocal.Text = App.LocName;




                conta = App.ResultFS.response.venue.tips.count;

                if (conta <= 10)
                {

                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;

                }
                else
                {
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;
                }



            }
            catch (Exception ex)
            {


                MessageBox.Show(Localization.fsserver);
                return;
            }



            pegando = 1;
            PegaTipsFS(pegando);
        }


        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static readonly double MaxUnixSeconds = (DateTime.MaxValue - UnixEpoch).TotalSeconds;

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return unixTimeStamp > MaxUnixSeconds
               ? UnixEpoch.AddMilliseconds(unixTimeStamp)
               : UnixEpoch.AddSeconds(unixTimeStamp);
        }




        private void PegaTipsFS(int qtd)
        {

            ligadesliga_tray(true, Localization.ms125);
            ligadesliga_busy(true);

            try
            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getTipsFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri(App.LocRefe + "/tips?sort=recent&limit=10&offset=" + qtd.ToString() + "&client_id=WYVK3C5JYYSKWLYKMHZFQUAGZYXRBAFXMLARQHLJBFFC05IX&client_secret=GJO5FLB20ZI03LLYBEBST55NI5OMLPG4IRIHXRBPLYB1S4M3&v=20121116"));

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }

        }


        void getTipsFS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {




            try
            {



            if (e.Error != null)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);
                return;
            }



        

                ListaTipsFS.Clear();





                var ResultFS = JsonConvert.DeserializeObject<App.RootObjectFSTips>(e.Result);

                conta = ResultFS.response.tips.count;



                if (conta <= 10)
                {

                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;

                }
                else
                {
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
                    ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;
                }




                for (int i = 0; i <= ResultFS.response.tips.items.Count - 1; i++)
                {

                    var resto = ResultFS.response.tips.items[i];


                    double datay = Convert.ToDouble(resto.createdAt);
                    DateTime datax = UnixTimeStampToDateTime(datay);

                    ListaTipsFS.Add(new TipsFS() { Data = datax.ToString(), Nome = resto.user.firstName + "   " + datax.ToString(), img_user = resto.user.photo.prefix + "50x50" + resto.user.photo.suffix, Tip = resto.text, Likes = resto.likes.count.ToString() });



                }


                listBox.ItemsSource = ListaTipsFS.ToList();

            }

            catch (Exception ex)
            {


                MessageBox.Show(Localization.fsserver);
                return;
            }


            ligadesliga_tray(false, "");
            ligadesliga_busy(false);





        }









        public void PegaTips()
        {


            ListaTipsFS.Clear();

            for (int i = 0; i <= App.ResultFS.response.venue.tips.groups.Count - 1; i++)
            {

                var resto = App.ResultFS.response.venue.tips.groups[i].items.ToList();

                for (int h = 0; h <= resto.Count - 1; h++)
                {

                    double datay = Convert.ToDouble(resto[h].createdAt);
                    DateTime datax = UnixTimeStampToDateTime(datay);

                    ListaTipsFS.Add(new TipsFS() { Data = datax.ToString(), Nome = resto[h].user.firstName + "   " + datax.ToString(), img_user = resto[h].user.photo.prefix + "50x50" + resto[h].user.photo.suffix, Tip = resto[h].text, Likes = resto[h].likes.count.ToString() });

                }


            }


            listBox.ItemsSource = ListaTipsFS.ToList();


        }

        private void Start_Click(object sender, EventArgs e)
        {
            pegando = 1;
            PegaTipsFS(pegando);
        }

        private void End_click(object sender, EventArgs e)
        {
            pegando = conta - 10;
            PegaTipsFS(pegando);

        }

        private void next_click(object sender, EventArgs e)
        {
            pegando = pegando + 10;
            if (pegando >= conta)
            {

                pegando = 1;

            }
            else
            {
                PegaTipsFS(pegando);

            }
        }

        private void prior_click(object sender, EventArgs e)
        {
            pegando = pegando - 10;
            if (pegando <= 10)
            {

                pegando = 1;

            }
            else
            {
                PegaTipsFS(pegando);

            }
        }







    }
}