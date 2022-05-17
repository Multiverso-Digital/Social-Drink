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
    public partial class Google_Foto : PhoneApplicationPage
    {
       
        public class  FotoGoogle
        {
            public string img_user { set;  get; }
            public string img_place { set; get; }
            public string name_foto { set; get; }
            public string name_user { set; get; }
        }

        public static List<FotoGoogle> ListaFotoGoogle = new List<FotoGoogle>();





        public Google_Foto()
        {
            InitializeComponent();
            tLocal.Text = App.LocName;
            ligadesliga_busy(true);
            ligadesliga_tray(true, "Waiting...");
            PegaFotos();
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


        public void PegaFotos()
        {



            try
            {


                ListaFotoGoogle.Clear();

                for (int i = 0; i <= App.ResultGoogle.result.photos.Count - 1; i++)
                {

                    var resto = App.ResultGoogle.result.photos[i].photo_reference.ToList();


                    ListaFotoGoogle.Add(new FotoGoogle() { name_foto = "", img_place = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=280&photoreference=" + App.ResultGoogle.result.photos[i].photo_reference + "&sensor=true&key=AIzaSyDvRzqIPDXqrEeK0One4ZJmbp9Bvfo6xS4", name_user = "Google user", img_user = "" });



                }


                listBox.ItemsSource = ListaFotoGoogle.ToList();

            }
            catch
            {

            }


            ligadesliga_busy(false);
            ligadesliga_tray(false, "");


        }

        private void listBox_RefreshRequested(object sender, EventArgs e)
        {

        }


    }
}