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
    public partial class Nokia_Foto : PhoneApplicationPage
    {
       
        public class  FotoNokia
        {
            public string img_user { set;  get; }
            public string img_place { set; get; }
            public string name_foto { set; get; }
            public string name_user { set; get; }
        }

        public static List<FotoNokia> ListaFotoNokia = new List<FotoNokia>();





        public Nokia_Foto()
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




                ListaFotoNokia.Clear();

                for (int i = 0; i <= App.ResultNokia.media.images.items.Count - 1; i++)
                {

                    var resto = App.ResultNokia.media.images.items[i];


                    if (resto.src.IndexOf("http://images.travelnow.com") == -1)
                    {

                        ListaFotoNokia.Add(new FotoNokia() { name_foto = resto.supplier.title, img_place = resto.src, name_user = "", img_user = resto.supplier.icon });
                    }


                }


                listBox.ItemsSource = ListaFotoNokia.ToList();

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