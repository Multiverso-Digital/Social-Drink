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
using Microsoft.Phone.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;
using Buddy;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Windows.Data;
using System.Threading;
using System.Net.NetworkInformation;
//using NetworkDetection;
using Microsoft.Phone.Net.NetworkInformation;
//using Microsoft.Devices.NetworkInformation;


namespace Social_Drink
{
    public partial class MostraFotoPlace : PhoneApplicationPage
    {

        public byte[] byteArray0;
        public List<ViewModel> items = new List<ViewModel>();
        AuthenticatedUser user = null;
        MetadataItem Chave = null;
        Picture  pic = null;
        PhotoAlbum album = null;
        BuddyClient client = new BuddyClient(Constants.AppName, Constants.AppPass);
        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };


       




        public MostraFotoPlace()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            App.PassouFotoPlace = true;
        }





        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            eLocal.Text = App.LocName;
            eEnde.Text = App.LocAddress;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_sendimage.ToString();
            carrega();

        }




        private void carrega()
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
                        App.LocFotoFileName0 = e.OriginalFileName;


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




        public void enviando_novo()
        {
            try
            {

                ligadesliga_tray(true, Localization.ms62.ToString());


                client.LoginAsync((result, state) =>
                {
                    if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                    else
                    {
                        user = result;

                        if (user != null)
                        {


                            this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.ms63.ToString()); });



                            user.PhotoAlbums.CreateAsync((r, ex) =>
                            {


                                album = r;

                                if (album != null)
                                {
                                    App.LocIDAlbum = album.AlbumId;

                                    this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.ms64.ToString()); });

                                    album.AddPictureAsync((p, ex2) =>
                                    {
                                        if (p != null)
                                        {
                                            pic = p;
                                            this.Dispatcher.BeginInvoke(() =>
                                            {
                                                ligadesliga_tray(false, "");
                                                //App.LinkFoto = pic.ThumbnailUrl;
                                                App.LinkFoto = pic.FullUrl;

                                                MessageBox.Show(Localization.ms65.ToString());
                                                NavigationService.GoBack();

                                            });
                                        }
                                       
                                        
                                        /*
                                        else
                                        {
                                            this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.ms71.ToString()); });
                                        }
                                        */

                                    }, byteArray0, App.LocName);
                                }
                            }, App.LocID);
                        }
                    }
                }, App.Conf[0].UserToken);



            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }
        }





















       /*

        public void Fazlogin()
        {


            try
            { 
            
            
            ligadesliga_tray(true, "Login...");
            client.LoginAsync((result, state) =>
            {
                if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                else
                {
                    user = result;
                    if (user != null)
                    {
                        PegaAlbum();
                    }

                }
            }, App.UserToken);

            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }



        }



        private void PegaAlbum()
        {



            try
            {
            
            

            ligadesliga_tray(true, "Get album...");            
            user.PhotoAlbums.GetAsync((r, ex) =>
            {
                album = r;
                if (ex.Completed == true)
                {
                    if (album != null)
                    {
                    }
                    else
                    {
                        ligadesliga_tray(false, "");
                    }
                }
            }, App.LocID);

}
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }


        }



        private void Gera_Album()
        {

            user.PhotoAlbums.CreateAsync((r, ex) =>
            {
                album = r;

                if (ex.Completed == true)
                {

                    if (album != null)
                    {
                        Pegafotos();
                    }
                }


            }, App.LocID);
        }







        private void Gera_Virtual_Album()
        {
            user.VirtualAlbums.CreateAsync((r, ex) =>
            {
                Valbum = r;

                if (ex.Completed == true)
                {
                    if (Valbum != null)
                    {

                        Gera_Chave_Album_Local(Valbum.ID);
                    }
                }

            }, App.LocID);
        }







        private void Pega_Virtual_Album()
        {

            user.VirtualAlbums.GetAsync((r, ex) =>
            {
                Valbum = r;


                if (ex.Completed == true)
                {
                    if (Valbum != null)
                    {
                        PegaAlbum();
                    }
                }

            }, Convert.ToInt32(Chave.Value));
        }


        private void Pega_Chave_Album_Local()
        {
            client.Metadata.GetAsync((r, ex) =>
            {
                Chave = r;

                if (ex.Completed == true)
                {

                    if (Chave != null)
                    {
                        Pega_Virtual_Album();
                    }
                    else
                    {
                        Gera_Virtual_Album();
                    }

                }

            }, "<localAlbum>" + App.LocID + "</localAlbum>");
        }


        private void Gera_Chave_Album_Local(int ID)
        {

            client.Metadata.SetAsync((r, ex) =>
            {

                if (ex.Completed == true)
                {
                    if (r == true)
                    {
                        Gera_Album();
                    }
                }


            }, "<localAlbum>" + App.LocID + "</localAlbum>", ID.ToString(), Convert.ToDouble(App.LocLat), Convert.ToDouble(App.LocLon), "");

        }

        public void manda_imagem(byte[] imagem, string localID, string localnome, string albumID)
        {





            album.AddPictureAsync((p, ex2) =>
            {


                if (ex2.Completed == true)
                {


                    if (p != null)
                    {
                        pic = p;
                        picP = p;


                        Pegafotos();

                    }

                }




            }, imagem, localnome);

        }



        public void manda_Virtual()
        {
            Valbum.AddPictureAsync((p1, ex4) =>
            {
                if (ex4.Completed == true)
                {

                    if (p1 == true)
                    {
                        Pega_Novo_Virtual_Album();
                    }
                }

            }, picP);
        }




        private void Pega_Novo_Virtual_Album()
        {

            user.VirtualAlbums.GetAsync((r, ex) =>
            {
                Valbum = r;


                if (ex.Completed == true)
                {
                    if (Valbum != null)
                    {
                        Pegafotos();
                    }
                }

            }, Convert.ToInt32(Chave.Value));
        }



        private void Pegafotos()
        {
            try
            {
            this.Dispatcher.BeginInvoke(() => { items.Clear(); });
            ligadesliga_tray(true, "download photos...");
            this.Dispatcher.BeginInvoke(() => { img0.Source = null; });
            client.LoginAsync((result, state) =>
            {
                if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                else
                {
                    user = result;
                    if (user != null)
                    {
                                user.PhotoAlbums.GetAsync((r, ex) =>
                                {

                                    album = r;

                                    if (ex.Completed == true)
                                    {


                                        if (album != null)
                                        {
                                            App.LocIDAlbum = album.AlbumId;


                                                if (album.Pictures.Count > 4)
                                                {
                                                }
                                                else
                                                {
                                                }


                                                for (int i = 0; i < album.Pictures.Count; i++)
                                                {

                                                    LoadImage(album.Pictures[i].FullUrl);


                                                    Uri uriF = new Uri(album.Pictures[i].FullUrl, UriKind.Absolute);
                                                    Uri uriT = new Uri(album.Pictures[i].ThumbnailUrl, UriKind.Absolute);

                                                    App.LinkFoto = uriT.AbsoluteUri.ToString();

                                                    items.Add(new ViewModel()
                                                    {
                                                        urlF = uriF.AbsoluteUri.ToString(),
                                                        urlT = uriT.AbsoluteUri.ToString(),                                                       

                                                    });                                                   

                                                }

                                                if (items.Count == album.Pictures.Count)
                                                {
                                                }

                                        }
                                        else
                                        {
                                            ligadesliga_tray(false, "Album é nulo");
                                        }
                                    }

                                }, App.LocIDAlbum);
                    }
                }
            }, App.UserToken);



            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                return;
            }



           
            if ((album != null) && (album.Pictures.Count != soma)) {
            
                this.Dispatcher.BeginInvoke(() => {MessageBox.Show("Numeros divergem");});
            } 


        }



*/



       



       

        public void ligadesliga_tray(bool valor, string texto)
        {

            this.Dispatcher.BeginInvoke(() => { SystemTray.IsVisible = valor; });


            this.Dispatcher.BeginInvoke(() => { progress1.IsVisible = valor; });
            this.Dispatcher.BeginInvoke(() => { progress1.IsIndeterminate = valor; });
            this.Dispatcher.BeginInvoke(() => { progress1.Text = texto; });
            this.Dispatcher.BeginInvoke(() => { SystemTray.SetProgressIndicator(this, progress1); });
        }


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            carrega();

        }






        public class ViewModel
        {


            public string urlF
            {
                get;
                set;
            }

            public string urlT
            {
                get;
                set;
            }


            public BitmapImage bit
            {
                get;
                set;
        }
        }



/*
        public class StringToImageConverter : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string url = value as string;
                Uri uri = new Uri(url);
                return new BitmapImage(uri);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }









        public void SaveImage()
        {



            /*


            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {

                int conta  = items.Count;
                int coloca = -1;

                foreach (ViewModel2 x in items)
                {

                    coloca = coloca + 1;

                    string fileName = "fotoF_" + coloca+".jpg";
                    if (isolatedStorage.FileExists(fileName))
                        isolatedStorage.DeleteFile(fileName);
                    var fileStream = isolatedStorage.CreateFile(fileName);
                    System.IO.Stream wb = Application.GetResourceStream(new Uri(x.urlF.UriSource.DnsSafeHost.ToString())).Stream;
                    BitmapImage bi = new BitmapImage();
                    bi.CreateOptions = BitmapCreateOptions.None;
                    bi.SetSource(wb);
                    WriteableBitmap bit = new WriteableBitmap(bi);
                    bit.SaveJpeg(fileStream, bit.PixelWidth, bit.PixelHeight, 0, 100);
                    



                    
                    
                    
                    
                    string fileNameT = "fotoT_" + coloca+".jpg";
                    if (isolatedStorage.FileExists(fileNameT))
                        isolatedStorage.DeleteFile(fileNameT);
                    var fileStreamT = isolatedStorage.CreateFile(fileNameT);
                    System.IO.Stream wbT = Application.GetResourceStream(new Uri(x.urlT.UriSource.AbsoluteUri.ToString())).Stream;
                    BitmapImage biT = new BitmapImage();
                    biT.CreateOptions = BitmapCreateOptions.None;
                    biT.SetSource(wbT);
                    WriteableBitmap bitT = new WriteableBitmap(biT);
                    bitT.SaveJpeg(fileStream, bitT.PixelWidth, bitT.PixelHeight, 0, 100);
                    mostra.Add(new ViewModel() { Picture = fileName, ThumbnailPicture = fileNameT });                    
                    fileStream.Close();
                    fileStreamT.Close();

                }

                slideView.ItemsSource = mostra;


            }
             * 
             * 
             * 
             */
       

    



        










        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }


        public void ligadesliga_busy(bool valor)
        {

 
        }


        private void Send_Click(object sender, EventArgs e)
        {

         
        }









        






















        

   
      
       /*

      
        private void LoadImage(string fileName) 
        { 
           
            this.Dispatcher.BeginInvoke(() => {
            Image img = new Image(); 
            Uri uri = new Uri(fileName, UriKind.Absolute); 
            img.Source = new System.Windows.Media.Imaging.BitmapImage(uri); 
            img.ImageOpened += new EventHandler<RoutedEventArgs>(Image_ImageOpened);
            });


        } 
        
        
        void Image_ImageOpened(object sender, RoutedEventArgs e){    
           
            this.Dispatcher.BeginInvoke(() => {
            
            Image img = (Image)sender;    
            BitmapImage bi = (BitmapImage)img.Source;    
            double width = bi.PixelWidth;
            double height = bi.PixelWidth;
            soma = soma + 1;
            if (soma == album.Pictures.Count)
            {
                ligadesliga_tray(false, "");
            } 

            });

        */






        

        private void img0_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            carrega();
        }

        private void Button_Send(object sender, EventArgs e)
        {


            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                //NavigationService.GoBack();
                return;
            }
            
            
            
            if (img0.Source == null)
            {
                MessageBox.Show(Localization.ms61.ToString());
                return;
            }

            enviando_novo();
        }


      



      

    }
}