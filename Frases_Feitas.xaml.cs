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
using System.Threading;
using System.Data.Services.Client; 
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization;


namespace Social_Drink
{
    public partial class Frases_Feitas : PhoneApplicationPage
    {

        public string strTextToTranslate = "";
        public string de = "";
        public string para = "";
       
        public bool primeira = false;


        string clientID = "6b194cc1-4394-4ffb-b955-986d8906bc9c";

        string clientSecret = "GDC+nFdSFJmo5rKWpVutsCgaEi1+EeKbrtavo5Ic68Y="; 




      // https://api.datamarket.azure.com/Data.ashx/Bing/MicrosoftTranslator/v1/Translate?Text=%27meu%20presente%27&To=%27de%27&From=%27pt%27&$top=100




        public class FraseAutor2
        {
            public string frase { get; set; }
            public string frasetradu { get; set; }

            public string autor { get; set; }
            public string icon { get; set; }


        }

        public static List<FraseAutor2> ListaFraseAutor2 = new List<FraseAutor2>();



        public Frases_Feitas()
        {
            InitializeComponent();


            if (App.ListaFraseAutor.Count == 0)
            {

                RadJumpList1.Visibility = Visibility.Collapsed;

            }
            else
            {
                RadJumpList1.ItemsSource = App.ListaFraseAutor.ToList();
                busyIndicator.IsRunning = false;
                RadJumpList1.Visibility = Visibility.Visible;
            }


        }

        private void lb3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            App.FraseAutor sele = RadJumpList1.SelectedItem as App.FraseAutor;


            if (sele != null)
            {
                string frase = sele.frase;

                App.ListaKaraka[App.passa_param].foto = frase;
                App.ListaKaraka[App.passa_param].tipo = 1;
                NavigationService.GoBack();
 

            }


       
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

          
            
            
        }


        void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
       
        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           

        }




      
      





     

        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        public void PegaFrase()
        {

            App.ListaFraseAutor.Clear();
            RadJumpList1.ItemsSource = null;

           
            string url = "";

            url = "http://www.stands4.com/services/v2/quotes.php?uid=2382&tokenid=Xio3NRHLYcE8yz9E&searchtype=SEARCH&query=" + SearchText.Text;


            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(PegaFrase_Completed);
            xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
        }//end of funt

        void PegaFrase_Completed(object sender, DownloadStringCompletedEventArgs e)
        {

            string idiomaTo = App.Conf[0].Idioma.Substring(0, 2);

            
            if (e.Error == null)
            {


                XElement xmlDataStill = XElement.Parse(e.Result);
                foreach (var item in xmlDataStill.Descendants("result"))
                {
                    string frase = (string)item.Element("quote").Value;

                    de = "en";
                    para = idiomaTo;


                    //string frasetradu = resultado.Text;

                    
                    string autor = (string)item.Element("author").Value;
                    string icon = "/images/FB_frase.png";

                    if (frase.Length <= 200) { 

                    App.ListaFraseAutor.Add(new App.FraseAutor() { frase = frase,frasetradu="", autor = autor, icon = icon });

                    }
                }


             

                RadJumpList1.ItemsSource = App.ListaFraseAutor.ToList();
                busyIndicator.IsRunning = false;
                RadJumpList1.Visibility = Visibility.Visible;

                





            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }

        }//end of funt











      




        private void SearchText_LostFocus(object sender, RoutedEventArgs e)
        {

            RadJumpList1.Visibility = Visibility.Collapsed;
            busyIndicator.IsRunning = true;
            RadJumpList1.ItemsSource = null;
         
            PegaFrase();
        
        
        }
   



       

        private void RadJumpList1_ItemTap(object sender, ListBoxItemTapEventArgs e)
        {




        }

        private void resultado_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }



        

        






    }
}