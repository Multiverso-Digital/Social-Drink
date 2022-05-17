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
using Microsoft.Xna.Framework.Media;
using Facebook;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Social_Drink
{
    public partial class Frases_Mostra_Imagens : PhoneApplicationPage
    {

        public class Album
        {
    
        public string src {get; set;}     
       


        }

        public static List<Album> ListaAlbum = new List<Album>();

    




        public Frases_Mostra_Imagens()
        {
            InitializeComponent();


            if (App.CameraAlbum != null)
            {
                Camera();
            }

            if (App.ListaKaraka[App.passa_param].album != null)
            {
                FqlSample();
            }
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
            MediaPlayer.Queue.ToString();
            MediaLibrary mediaLibrary;
            PictureAlbum cameraRoll = null;


            foreach (MediaSource source in MediaSource.GetAvailableMediaSources())
            {
                if (source.MediaSourceType == MediaSourceType.LocalDevice)
                {
                    mediaLibrary = new MediaLibrary(source);
                    PictureAlbumCollection allAlbums = mediaLibrary.RootPictureAlbum.Albums;
                    foreach (PictureAlbum album in allAlbums)
                    {
                        if (album.Name == App.CameraAlbum)
                        {

                            cameraRoll = album;
                        }

                        //ListaCamera.Add(new CameraPhoto() { nome = album.Name, qtd = "Photos in this album: " + album.Pictures.Count.ToString(), icon = "images/FB_Camera.png" });



                    }
                }
            }

            //lb3.ItemsSource = ListaCamera.ToList();

            

            List<BitmapImage> lstBitmapImage = new List<BitmapImage>();
            foreach (Picture p in cameraRoll.Pictures)
            {
                BitmapImage b = new BitmapImage();
                b.SetSource(p.GetThumbnail());
                lstBitmapImage.Add(b);
            }


            this.listBox2.ItemsSource = lstBitmapImage;
            
        
        }



        private void FB()
        {
            MediaPlayer.Queue.ToString();
            MediaLibrary mediaLibrary;
            PictureAlbum cameraRoll = null;


            foreach (MediaSource source in MediaSource.GetAvailableMediaSources())
            {
                if (source.MediaSourceType == MediaSourceType.LocalDevice)
                {
                    mediaLibrary = new MediaLibrary(source);
                    PictureAlbumCollection allAlbums = mediaLibrary.RootPictureAlbum.Albums;
                    foreach (PictureAlbum album in allAlbums)
                    {
                        if (album.Name == App.CameraAlbum)
                        {

                            cameraRoll = album;
                            
                        }

                        //ListaCamera.Add(new CameraPhoto() { nome = album.Name, qtd = "Photos in this album: " + album.Pictures.Count.ToString(), icon = "images/FB_Camera.png" });



                    }
                }
            }

            //lb3.ItemsSource = ListaCamera.ToList();



            List<BitmapImage> lstBitmapImage = new List<BitmapImage>();
            foreach (Picture p in cameraRoll.Pictures)
            {
                BitmapImage b = new BitmapImage();
                b.SetSource(p.GetThumbnail()); 
                lstBitmapImage.Add(b);
            }


            this.listBox2.ItemsSource = lstBitmapImage;


        }


        private void FqlSample()
        {

            busyIndicator.IsRunning = true;

            ListaAlbum.Clear();

            var fb = new FacebookClient(App.Conf[0].FB_Token);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    busyIndicator.IsRunning = false;

                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();

                string teste = result.ToString();


                var data = (IList<object>)result["data"];

                JToken jToken = JObject.Parse(teste)["data"];
              
                IList<JToken> jlList = jToken.Children().ToList();

                foreach (JToken x in jlList)
                {

                    Album fotos = JsonConvert.DeserializeObject<Album>(x.ToString());

                   


                   
                        ListaAlbum.Add(new Album() { src = fotos.src });
                   
                }





                var count = data.Count;

                // since this is an async callback, make sure to be on the right thread
                // when working with the UI.
                Dispatcher.BeginInvoke(() =>
                {




                    listBox.ItemsSource = ListaAlbum.ToList();
                    busyIndicator.IsRunning = false;

                    // TotalFriends.Text = string.Format("You have {0} friend(s).", count);





                });
            };


            //SELECT pid,src_big,src_small,created,caption,src FROM photo WHERE aid= 2577764492599832939 ORDER BY created DESC

            // query to get all the friends
            var query = string.Format("SELECT src, created FROM photo WHERE aid=" + App.ListaKaraka[App.passa_param].album.ToString()          + " order by created DESC limit 50");

            // Note: For windows phone 7, make sure to add [assembly: InternalsVisibleTo("Facebook")] if you are using anonymous objects as parameter.
            fb.GetAsync("fql", new { q = query });


            



        }

        private void lb1_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
            
            
            Album sele = listBox.SelectedItem as Album;


            foreach (App.Karaka x in App.ListaKaraka)
            {
                if (x.seq == App.passa_param)
                {
                    x.foto = sele.src;
                    x.tipo = 2; //Foto Facebook
                }

            }


            
            //App.FBAlbumPhoto = sele.src;
            //App.passa_param = 1;
            NavigationService.Navigate(new Uri("/Frases_UmaFoto.xaml", UriKind.RelativeOrAbsolute)); 
        }

        private void lb3_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            //var element = this.listBox2.ItemContainerGenerator.ContainerFromIndex()


            BitmapImage sele = listBox2.SelectedItem as BitmapImage;
            App.CameraAlbumPhoto = sele.UriSource.AbsoluteUri.ToString();
            //App.passa_param = 2;
            NavigationService.Navigate(new Uri("/Frases_UmaFoto.xaml", UriKind.RelativeOrAbsolute)); 
        }




    }
}