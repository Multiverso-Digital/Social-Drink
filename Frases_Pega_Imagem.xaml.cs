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
using Facebook;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using Buddy;
using Microsoft.Phone.Tasks;
using System.IO;

namespace Social_Drink
{
    public partial class Frases_Pega_Imagem : PhoneApplicationPage
    {


        public byte[] byteArray0;
        //public List<ViewModel> items = new List<ViewModel>();


        //      NetworkInterfaceType currentNetworkType;
        //      private bool loaded = false;


        AuthenticatedUser user = null;
        //       AuthenticatedUser user2 = null;

        MetadataItem Chave = null;
        //      PicturePublic picP = null;
        Buddy.Picture pic = null;


        //        VirtualAlbum Valbum = null;
        PhotoAlbum album = null;


        public class Album
        {
            public string aid {get; set;}       
            public string owner {get; set;}       
            public string name {get; set;}
            public string object_id { get; set; }
            public string photo_count { get; set; } 
            public string icon { get; set; }
        }

        public class CameraPhoto
        {
            public string nome { get; set; }
            public string qtd { get; set; }
            public string icon { get; set; }
        }






        public static List<Album> ListaAlbum = new List<Album>();
        public static List<CameraPhoto> ListaCamera = new List<CameraPhoto>();


        public Frases_Pega_Imagem()
        {
            InitializeComponent();
            App.PegouFoto = false;
           
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            if (App.PegouFoto == true)
            {
                NavigationService.GoBack();
            }
        }


        private void Camera()
        {
            byteArray0 = null;
            PhotoChooserTask photo = new PhotoChooserTask();
            photo.Completed += new EventHandler<PhotoResult>(selectphoto_Completed);
            photo.ShowCamera = true;
            photo.Show();
            

        }


        void selectphoto_Completed(object sender, PhotoResult e)
        {
            try
            {
                

                if (e.TaskResult == TaskResult.OK)
                {
                    BinaryReader reader = new BinaryReader(e.ChosenPhoto);
                    if (byteArray0 == null)
                    {
                        //  this.slideView.ItemsSource = null;
                        BitmapImage image = new BitmapImage();
                        image.SetSource(e.ChosenPhoto);
                        // App.SelImg = e.ChosenPhoto;
                        App.ListaKaraka[App.passa_param].foto = e.OriginalFileName;
                        App.ListaKaraka[App.passa_param].tipo = 3;

                        


                        Image image1 = new Image()
                        {
                            //Width = 480,
                            //Height = 800,
                            Visibility = System.Windows.Visibility.Collapsed,
                            Source = image
                        };
                        ScaleTransform st = new ScaleTransform()
                        {
                            //ScaleX = 1.0,
                            //ScaleY = 1.0
                        };
                        
                        
                        WriteableBitmap wb = new WriteableBitmap(image1, null);
                        byteArray0 = ImageToByteArray(wb);
                        img0.Source = wb; //image;
                        App.PegouFoto = true;

                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }
        }



        public static byte[] ImageToByteArray(BitmapSource bitmapSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                WriteableBitmap writableBitmap = new WriteableBitmap(bitmapSource);
                System.Windows.Media.Imaging.Extensions.SaveJpeg(writableBitmap, stream, bitmapSource.PixelWidth, bitmapSource.PixelHeight, 0, 100);
                return stream.ToArray();
            }
        }







        private void FqlSample()
        {

            ListaAlbum.Clear();

            var fb = new FacebookClient(App.Conf[0].FB_Token);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();

                string teste = result.ToString();
                

                var data = (IList<object>)result["data"];

                JToken jToken = JObject.Parse(teste)["data"];
                IList<JToken> jlList = jToken.Children().ToList();

                foreach (JToken x in jlList) {

                    Album fotos = JsonConvert.DeserializeObject<Album>(x.ToString());

                    ListaAlbum.Add(new Album() { aid = fotos.aid, name = fotos.name, owner = fotos.owner, object_id = fotos.object_id, icon = "images/FB_Album.png", photo_count="Photos in this album: "+fotos.photo_count });

                }





                var count = data.Count;

                // since this is an async callback, make sure to be on the right thread
                // when working with the UI.
                Dispatcher.BeginInvoke(() =>
                {




                    lb2.ItemsSource = ListaAlbum.ToList();                    
                    
                   // TotalFriends.Text = string.Format("You have {0} friend(s).", count);





                });
            };

            // query to get all the friends
            var query = string.Format("SELECT aid, owner, name, object_id,photo_count FROM album WHERE owner="+App.Conf[0].FB_UserID.ToString());

            // Note: For windows phone 7, make sure to add [assembly: InternalsVisibleTo("Facebook")] if you are using anonymous objects as parameter.
            fb.GetAsync("fql", new { q = query });
        }








        private void lb2_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            
            
            Album sele = lb2.SelectedItem as Album;


            foreach (App.Karaka x in App.ListaKaraka)
            {
                if (x.seq == App.passa_param)
                {
                    x.album = sele.aid;
                    x.tipo = 2; //Foto Facebook
                }

            }


            //App.FBAlbum = sele.aid;
            
            NavigationService.Navigate(new Uri("/Frases_Mostra_Imagens.xaml", UriKind.RelativeOrAbsolute)); 

        }

        private void lb3_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {

            /*
            CameraPhoto sele = lb3.SelectedItem as CameraPhoto;
            App.CameraAlbum = sele.nome;           
            NavigationService.Navigate(new Uri("/Frases_Mostra_Imagens.xaml", UriKind.RelativeOrAbsolute));
 */
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lb2.Visibility = Visibility.Visible;
            img0.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
            //App.PegouFoto = true;
            FqlSample();
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            lb2.Visibility = Visibility.Collapsed;
            img0.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
 
            Camera();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}