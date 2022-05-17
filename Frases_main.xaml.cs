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

namespace Social_Drink
{
    public partial class Frases_main : PhoneApplicationPage
    {

        public class BoardFrases
        {
            public int Tipo { get; set; }
            public string Title { get; set; }
            public string VideoImageUrl { get; set; }
            public string VideoId { get; set; }
        }

        public static List<BoardFrases> ListaBoard = new List<BoardFrases>();



        public Frases_main()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.Filme_Title != null)
            {

                BoardFrases acha = ListaBoard.Where<BoardFrases>(x => x.Title == App.Filme_Title).SingleOrDefault<BoardFrases>();
                if (acha == null)
                {
                    ListaBoard.Add(new BoardFrases() { Tipo=App.Filme_Tipo, Title = App.Filme_Title, VideoId = App.Filme_VideoId, VideoImageUrl = App.Filme_VideoImageUrl });

                }

            }


            lb3.ItemsSource = ListaBoard.ToList();


        }




        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void youtube_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
            
        }

        private void youtube_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Frases_YouTube.xaml", UriKind.RelativeOrAbsolute));
        }

        private void frase_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Frases_Frase.xaml", UriKind.RelativeOrAbsolute));
            
           
        }

        private void frase_image(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Frases_Pega_Imagem.xaml", UriKind.RelativeOrAbsolute)); 
            
            
        }
    }
}