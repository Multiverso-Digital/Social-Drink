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
    public partial class FS_Foto : PhoneApplicationPage
    {


        public int conta = 0;
        public int pegando = 0;


        public class  FotoFS
        {
            public string img_user { set;  get; }
            public string img_place { set; get; }
            public string name_foto { set; get; }
            public string name_user { set; get; }
            public string data { set; get; }

        }

        public static List<FotoFS> ListaFotoFS = new List<FotoFS>();




        
        public FS_Foto()
        {
            InitializeComponent();


            try
            {

                tLocal.Text = App.LocName;
                conta = App.ResultFS.response.venue.photos.count;

                if (conta <= 2)
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
            PegaFS(pegando);
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





        private void PegaFS(int qtd)
        {


            ligadesliga_tray(true, Localization.ms125);
            ligadesliga_busy(true);

            try
            {
                WebClient getFS = new WebClient();
                getFS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(getFS_DownloadStringCompleted);
                getFS.DownloadStringAsync(new Uri(App.LocRefe + "/photos?group=venue&limit=2&offset="+qtd.ToString()+"&client_id=WYVK3C5JYYSKWLYKMHZFQUAGZYXRBAFXMLARQHLJBFFC05IX&client_secret=GJO5FLB20ZI03LLYBEBST55NI5OMLPG4IRIHXRBPLYB1S4M3&v=20121116"));

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.fsserver);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false);    

                return;
            }

        }


        void getFS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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



           


                var ResultFS = JsonConvert.DeserializeObject<App.RootObjectFS>(e.Result);

                ListaFotoFS.Clear();

                for (int i = 0; i <= ResultFS.response.photos.items.Count - 1; i++)
                {

                    var resto = ResultFS.response.photos.items[i];

                    double timestamp = Convert.ToDouble(resto.createdAt);
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    dateTime = dateTime.AddSeconds(timestamp);


                    ListaFotoFS.Add(new FotoFS() { data = (pegando + i).ToString() + "    " + dateTime.ToString(), name_foto = resto.source.name, img_place = resto.prefix + "280x280" + resto.suffix, name_user = resto.user.firstName, img_user = resto.user.photo.prefix + "50x50" + resto.user.photo.suffix });




                }


                listBox.ItemsSource = ListaFotoFS.ToList();



            }

            catch (Exception ex)
            {


                MessageBox.Show(Localization.fsserver);
                return;
            }




            ligadesliga_tray(false, "");
            ligadesliga_busy(false);    





        }




/*
        public void PegaFotos()
        {


            ListaFotoFS.Clear();

            for (int i = 0; i <= App.ResultFS.response.venue.photos.groups.Count - 1; i++)
            {

                var resto = App.ResultFS.response.venue.photos.groups[i].items.ToList();

                for (int h = 0; h <= resto.Count - 1; h++)
                {

                    ListaFotoFS.Add(new FotoFS() { name_foto = resto[h].source.name, img_place = resto[h].prefix + "280x280" + resto[h].suffix, name_user = resto[h].user.firstName, img_user = resto[h].user.photo.prefix + "50x50" + resto[h].user.photo.suffix });
  
                }


            }
            

            listBox.ItemsSource = ListaFotoFS.ToList();


        }

        private void listBox_RefreshRequested(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

          



            


        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        */


        private void Start_Click(object sender, EventArgs e)
        {
            pegando = 1;
            PegaFS(pegando);
        }

        private void End_click(object sender, EventArgs e)
        {
            pegando = conta - 2;
            PegaFS(pegando);

        }

        private void next_click(object sender, EventArgs e)
        {
            pegando = pegando + 2;
            if (pegando >= conta)
            {

                pegando = 1;

            }
            else
            {
                PegaFS(pegando);

            }
        }

        private void prior_click(object sender, EventArgs e)
        {
            pegando = pegando - 2;
            if (pegando <= 2)
            {

                pegando = 1;

            }
            else
            {
                PegaFS(pegando);

            }
        }

        private void listBox_RefreshRequested(object sender, EventArgs e)
        {

        }








    }
}