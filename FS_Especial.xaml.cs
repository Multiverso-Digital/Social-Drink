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
using System.Windows.Media.Imaging;




namespace Social_Drink
{
    public partial class FS_Especial : PhoneApplicationPage
    {



        public class EspecialFS
        {
            public string img_icon { set; get; }
            public string tipo { set; get; }
            public string mensagem { set; get; }
            public string descricao { set; get; }
            public string fineprint { set; get; }
            

        }

        public static List<EspecialFS> ListaEspecialFS = new List<EspecialFS>();

        public string img_mayor;





        public FS_Especial()
        {
            InitializeComponent();
            tLocal.Text = App.LocName;


            try
            {

                tnome.Text = App.ResultFS.response.venue.mayor.user.firstName + " " + App.ResultFS.response.venue.mayor.user.lastName;

                img_mayor = App.ResultFS.response.venue.mayor.user.photo.prefix + "64x64" + App.ResultFS.response.venue.mayor.user.photo.suffix;
                Uri uri = new Uri(img_mayor, UriKind.RelativeOrAbsolute);

                ImageSource imgSource = new BitmapImage(uri);

                image1.Source = imgSource;


            }

            catch (Exception ex)
            {


                MessageBox.Show(Localization.fsserver);
                return;
            }





            PegaEspecial();
        }

        public void PegaEspecial()
        {


            try
            {

                ListaEspecialFS.Clear();

                for (int i = 0; i <= App.ResultFS.response.venue.specials.items.Count - 1; i++)
                {

                    var resto = App.ResultFS.response.venue.specials.items[i];


                    ListaEspecialFS.Add(new EspecialFS() { mensagem = resto.message, descricao = resto.description, fineprint = resto.finePrint, img_icon = "http://foursquare.com/img/specials/" + resto.icon + ".png" });




                }


                listBox.ItemsSource = ListaEspecialFS.ToList();

            }
            catch (Exception ex)
            {


                MessageBox.Show(Localization.fsserver);
                return;
            }



        }






    }


    

}