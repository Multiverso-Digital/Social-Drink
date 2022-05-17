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
using System.Xml.Linq;
using Telerik.Windows.Controls;

namespace Social_Drink
{
    public partial class Frases_YouTube : PhoneApplicationPage
    {

        public class YouTubeVideo
        {
            public string Title { get; set; }
            public string VideoImageUrl { get; set; }
            public string VideoId { get; set; }
        }


        public Frases_YouTube()
        {
            InitializeComponent();
            button1_Click(null, null);
        }

        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            YouTubeVideo sele = lb3.SelectedItem as YouTubeVideo;

            string filme = sele.VideoId;
            string url = "http://gdata.youtube.com/feeds/api/videos/";

            string nova = filme.Replace(url, "");

            
            
            App.Filme_Tipo          = 3;
            App.Filme_Title         = sele.Title; 
            App.Filme_VideoImageUrl = sele.VideoImageUrl;
            App.Filme_VideoId       = sele.VideoId;

            App.ListaKaraka[App.passa_param].album = sele.Title;
            App.ListaKaraka[App.passa_param].foto = nova;
            App.ListaKaraka[App.passa_param].tipo = 4;
            App.ListaKaraka[App.passa_param].seq = 5;
            App.ListaKaraka[App.passa_param].videologo = sele.VideoImageUrl;







            MessageBoxResult result =
            MessageBox.Show("Would you like to see your choice?",
            "Message", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.Cancel)
            {

                NavigationService.GoBack();
                
            }
            else
            {
                YouTube.Play(nova);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var wc = new WebClient();
            wc.DownloadStringCompleted += DownloadStringCompleted;
            var searchUri = string.Format(
              "http://gdata.youtube.com/feeds/api/videos?q={0}&format=6",
              HttpUtility.UrlEncode(SearchText.Text));
            wc.DownloadStringAsync(new Uri(searchUri));

        }


        void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var atomns = XNamespace.Get("http://www.w3.org/2005/Atom");
            var medians = XNamespace.Get("http://search.yahoo.com/mrss/");
            var xml = XElement.Parse(e.Result);
            var videos = (
              from entry in xml.Descendants(atomns.GetName("entry"))
              select new YouTubeVideo
              {
                  VideoId = entry.Element(atomns.GetName("id")).Value,
                  VideoImageUrl = (
                    from thumbnail in entry.Descendants(medians.GetName("thumbnail"))
                    where thumbnail.Attribute("height").Value == "360"
                    select thumbnail.Attribute("url").Value).FirstOrDefault(),
                  Title = entry.Element(atomns.GetName("title")).Value
              }).ToArray();
            lb3.ItemsSource = videos;
        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            button1_Click(null, null);

        }

        private void SearchText_LostFocus(object sender, RoutedEventArgs e)
        {
            button1_Click(null, null);
        }

        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }



    }
}