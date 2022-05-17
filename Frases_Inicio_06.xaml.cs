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
using System.Windows.Media.Imaging;
using Microsoft.Expression.Interactivity.Layout;
using System.Windows.Interactivity;

namespace Social_Drink
{


       
        



    public partial class Frases_Inicio_06 : PhoneApplicationPage
    {

        int conta = 0;

        public class Karaka2
        {
            public int seq { get; set; }
            public int tipo { get; set; }
            public string album { get; set; }
            public string foto { get; set; }
            public string videologo { get; set; }
        }
        List<Karaka2> ListaKaraka2 = new List<Karaka2>();
        
        public Frases_Inicio_06()
        {


            

            InitializeComponent();
            

            

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            


            

          



        }






        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


           // NavigationService.Navigate(new Uri("/Frases_YouTube.xaml", UriKind.RelativeOrAbsolute));
         //   lb3.Visibility = Visibility.Visible;


        }

        private void text_sel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void image4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
           
            
            
        }

        private void text_sel_LostFocus(object sender, RoutedEventArgs e)
        {
            

           


        }

        private void image5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void image6_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void image6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void img_copo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            //Storyboard3.Begin();
            /*
            (sender as Image).RenderTransform = new CompositeTransform();
            Storyboard.SetTargetName(Storyboard3, "Tea");
            Storyboard.SetTargetProperty(Storyboard3, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)"));
             */ 
        }
              

        private void img_copo_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


           

            if (eNome.Text.Trim().Length == 0)
            {

                MessageBox.Show("You must complete the Karaka name!");
                return;

            }



            


            int[] exibe = {0,1,1,2,2,3,3,4,4};
            string obj = "";
            
            conta = conta + 1;
            if (conta <= 8)
            {
                obj =  Convert.ToString(exibe[conta]);
                tshow.Text = "showing object " + obj;


                if (App.ListaKaraka[exibe[conta]].foto != null)
                {
                    if (App.ListaKaraka[exibe[conta]].tipo == 1)
                    {
                        text_sel.Visibility = Visibility.Visible;
                        img_sel.Visibility = Visibility.Collapsed;
                        text_sel.Text = App.ListaKaraka[exibe[conta]].foto;

                    }


                    if (App.ListaKaraka[exibe[conta]].tipo == 2)
                    {
                        img_sel.Visibility = Visibility.Visible;
                        text_sel.Visibility = Visibility.Collapsed;
                        string testa = App.ListaKaraka[exibe[conta]].foto;
                        Uri uri1 = new Uri(testa, UriKind.RelativeOrAbsolute);
                        ImageSource imgSource1 = new BitmapImage(uri1);
                        img_sel.Source = imgSource1;

                    }

                    if (App.ListaKaraka[exibe[conta]].tipo == 3)
                    {
                        string path = App.ListaKaraka[exibe[conta]].foto;
                        var bitmap = new BitmapImage(new Uri(path, UriKind.Absolute));
                        img_sel.Source = bitmap;
                        //tconta.Visibility = Visibility.Collapsed;

                    }





                }

            }
            else
            {
               
                tshow.Text = "showing object 5";
                YouTube.Play(App.ListaKaraka[5].foto);
                conta = 0;

            }

        }

        private void image6_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            bool achou = false;

            foreach (App.KarakaLista x in App.ListaKarakaGeral)
            {

                if (x.NomePacote == eNome.Text.Trim())
                {
                    achou = true;
                    x.NomePacote = eNome.Text.Trim();
                    x.Pacote = App.ListaKaraka.ToList();
                    x.data = DateTime.Today.ToString("MM/dd/yyyy");
                }


            }


            if (achou == true)
            {
                //MessageBox.Show("This Karaka name already exists! Try another.");
                //return;
            }
            else
            {
                Guid num = new Guid();
                string nume = num.ToString();
                App.ListaKarakaGeral.Add(new App.KarakaLista() { NomePacote = eNome.Text.Trim(), IDPacote = nume, Pacote = App.ListaKaraka.ToList(), data = DateTime.Today.ToString("MM/dd/yyyy") });

            }



            
            
            
            
            
            
            
            
            
            
            
            
            
            
            NavigationService.Navigate(new Uri("/Frases_Inicio_07.xaml", UriKind.RelativeOrAbsolute));



        }

        private void eNome_LostFocus(object sender, RoutedEventArgs e)
        {
            
            
            
            bool achou = false;
            
            
            foreach (App.KarakaLista x in App.ListaKarakaGeral)
            {

                if (x.NomePacote == eNome.Text.Trim())
                {
                    achou = true;
                }


            }


            if (achou == true)
            {
                MessageBoxResult result =
                      MessageBox.Show("This Karaka name already exists. Would you like to continue?",
                 "Message", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.Cancel)
                {

                    eNome.Focus();

                }
                else
                {
                    //YouTube.Play(nova);
                }
                
            }
            
        }

        private void eNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        

       


    }
}