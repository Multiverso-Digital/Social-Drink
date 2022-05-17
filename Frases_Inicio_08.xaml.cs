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
using Facebook;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Social_Drink
{


    


    public partial class Frases_Inicio_08 : PhoneApplicationPage
    {

        int conta = 0;


        public class Amigos
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pic { get; set; }
            public string can_post { get; set; }

        }

        List<Amigos> ListaAmigos = new List<Amigos>();
        







        public class Karaka2
        {
            public int seq { get; set; }
            public int tipo { get; set; }
            public string album { get; set; }
            public string foto { get; set; }
            public string videologo { get; set; }
        }
        List<Karaka2> ListaKaraka2 = new List<Karaka2>();
        
        public Frases_Inicio_08()
        {


            

            InitializeComponent();
            

            

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            FqlSample();
      




            //lb3.ItemsSource = App.ListaKarakaGeral.ToList();




        }


        private void FqlSample()
        {
            var fb = new FacebookClient(App.Conf[0].FB_Token);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var data = (IList<object>)result["data"];
                string json = result.ToString();


                JObject weatherSearch = JObject.Parse(json); 
                IList<JToken> results = weatherSearch["data"].Children().ToList(); 
 
                IList<Amigos> searchResults = new List<Amigos>(); 
                foreach(JToken x in results) 
                { 
                Amigos searchResult = JsonConvert.DeserializeObject<Amigos>(x.ToString()); 
                ListaAmigos.Add(searchResult); 
                } 
           

                // since this is an async callback, make sure to be on the right thread
                // when working with the UI.
                Dispatcher.BeginInvoke(() =>
                {
                    lb3.ItemsSource = ListaAmigos.ToList(); 
                });
            };

            // query to get all the friends
            var query = string.Format("select id, name, pic, can_post from profile where id in(SELECT uid2 FROM friend WHERE uid1 = me())");

            // Note: For windows phone 7, make sure to add [assembly: InternalsVisibleTo("Facebook")] if you are using anonymous objects as parameter.
            fb.GetAsync("fql", new { q = query });
        }







        private void PostToWall_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty("minha"))
            {
                MessageBox.Show("Enter message.");
                return;
            }

            var fb = new FacebookClient(App.Conf[0].FB_Token);

            // make sure to add event handler for PostCompleted.
            fb.PostCompleted += (o, args) =>
            {
                // incase you support cancellation, make sure to check
                // e.Cancelled property first even before checking (e.Error!=null).
                if (args.Cancelled)
                {
                    // for this example, we can ignore as we don't allow this
                    // example to be cancelled.

                    // you can check e.Error for reasons behind the cancellation.
                    var cancellationError = args.Error;
                }
                else if (args.Error != null)
                {
                    // error occurred
                    Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show(args.Error.Message);
                    });
                }
                else
                {
                    // the request was completed successfully

                    // now we can either cast it to IDictionary<string, object> or IList<object>
                    var result = (IDictionary<string, object>)args.GetResultData();

                    // make sure to be on the right thread when working with ui.
                    Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show("Message Posted successfully");
                        //txtMessage.Text = string.Empty;
                    });
                }
            };

            var parameters = new Dictionary<string, object>();
            parameters["message"] = "";//txtMessage.Text;
            parameters["link"] = "http://www.vMudi.com";
            parameters["name"] = "vMudi Mood Tracker";
            parameters["description"] = "Mood tracking just got simple!";
            parameters["picture"] = "";//_url;
            fb.PostAsync("me/feed", parameters);
        }





        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {





 
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

        }
              

        private void img_copo_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            
        }

        private void cbAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grava_Button(object sender, EventArgs e)
        {

        }

        private void RadJumpList1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {

        }

        

       


    }
}