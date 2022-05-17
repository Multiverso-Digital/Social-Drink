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
//using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using System.Globalization;
using System.Net.NetworkInformation;
using Telerik.Windows.Controls;
using Buddy;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Phone.Net.NetworkInformation;
using System.Collections.ObjectModel;
using Microsoft.Devices;
using Microsoft.Expression.Interactivity.Layout;
using System.Windows.Interactivity;
//using Telerik.Examples.WP;
using System.Threading;
using System.IO.IsolatedStorage;
using MyToolkit;
//using Facebook;
//using VirtualDataMIX11;
using Telerik.Windows.Controls.LoopingList;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System.ComponentModel;
using System.Xml.Linq;
using System.IO;
//using Microsoft.Xna.Framework;
//using System.IO;
//using Microsoft.Xna.Framework.Audio;


//using Microsoft.Phone.Net.NetworkInformation;
//using Microsoft.Phone.Net.NetworkInformation;

namespace Social_Drink
{
    public partial class Checkin : PhoneApplicationPage
    {


        MediaElement mediaElement = new MediaElement();
        MediaElement mediaElement2 = new MediaElement();
       

        IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
        double alcool = 0;
        int tagw = 0;
        int minhaconta = 0;

  //      public byte[] byteArray0;

        private BackgroundWorker backgroundWorker;

        AuthenticatedUser user = null;
        MetadataItem Chave = null;
        Buddy.Picture pic = null;
        PhotoAlbum album = null;
        BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
    //    public List<ViewModel> items = new List<ViewModel>();
      



        DispatcherTimer dt = new DispatcherTimer();

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public static System.Windows.Point pontos { get; set; }
        public static System.Windows.Point ptogarrafa { get; set; }
        public static bool temDrop { get; set; }
        public static bool flip = false;
        public static bool cliclou_copo = false;
        public static bool mandou_foto = false;
        
        public static int contaleft = 140;
        public static int contatop = 550;
        public static int fila = 4;
        public static int completa = 0;



        public static int vezes = 0;
     

        public static int contaleft_e = -350;
        public static int contatop_e = 550;
        public static int vezes_e = 0;
        public static int fila_e = 4;



        public static List<System.Windows.Point> pointarray = new List<System.Windows.Point>(21);
        public static List<Thickness> tickarray = new List<Thickness>(21);



        public object senderdrop { get; set; }




        public string laty = "";
        public string lony = "";
        public string latx = "";
        public string lonx = "";
     //   public string toke = "";
        public string local = "";
        public string dateString = "";
        public string bebida = "";
        public string marca = "";
        public string IDLocal = "";
        double distancia = 0;

        int conta_copo = 0;
        int contafoto = 0;




      

       
        bool flip1 = false;
        
        
        bool holdS = false;
        bool jaexiste = false;



        private Random random;
        int[] lista = new int[23];
        int pontosSlot = 0;
        int spins = 0;
        int dura = 0;
        int quem = 0;
        bool flipSlot = true;
        bool completou = true;




        public object senderx = null;

       // Get_User_Meta SyncJobsInicial = new Get_User_Meta();
       // Get_User_Meta SyncJobsFinal   = new Get_User_Meta();
       // Get_Application_Meta SyncJobsAppInicial = new Get_Application_Meta();
       // Get_Application_Meta SyncJobsAppFinal = new Get_Application_Meta();
        BuddyClient client = new BuddyClient(Constants.AppName, Constants.AppPass);


        Image antes = new Image();


        ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = false,
            Text = ""
        };
        
        public class localEdit
        {
            public string nome { get; set; }
            public string ende { get; set; }
            
        }




        public void adicionaFrase()
        {


            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 10, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.0, valfim = 0.019, texto = "Um pouco tonto" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 11, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.019, valfim = 0.04, texto = "Aconchegante e descontraído" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 12, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.04, valfim = 0.09, texto = "Falta de coordenação (legalmente bêbado)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 13, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.09, valfim = 0.014, texto = "Possível apagão(perda de memória)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 14, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.14, valfim = 0.19, texto = "Se sente confuso e atordoado" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 15, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.19, valfim = 0.24, texto = "Emocionalmente e fisicamente entorpecido" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 16, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.24, valfim = 0.29, texto = "Pode estar bêbado!" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 17, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.29, valfim = 0.34, texto = "Provavelmente entrará em coma" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 18, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.34, valfim = 9.99, texto = "Chame um Taxi!" });

            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 19, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.0, valfim = 0.019, texto = "Little lightheaded" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 20, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.019, valfim = 0.04, texto = "Warm and relaxed" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 21, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.04, valfim = 0.09, texto = "Lack of coordination and balance (legally drunk)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 22, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.09, valfim = 0.014, texto = "Possible blackout (memory loss)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 23, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.14, valfim = 0.19, texto = "Feel confused, dazed, or otherwise disoriented" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 24, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.19, valfim = 0.24, texto = "Emotionally and physically numb" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 25, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.24, valfim = 0.29, texto = "In a drunken stupor" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 26, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.29, valfim = 0.34, texto = "Probably in a coma" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 27, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.34, valfim = 9.99, texto = "Call a Taxi!" });


            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 1, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.0, valfim = 0.019, texto = "Little lightheaded" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 2, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.019, valfim = 0.04, texto = "Warm and relaxed" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 3, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.04, valfim = 0.09, texto = "Lack of coordination and balance (legally drunk)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 4, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.09, valfim = 0.014, texto = "Possible blackout (memory loss)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 5, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.14, valfim = 0.19, texto = "Feel confused, dazed, or otherwise disoriented" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 6, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.19, valfim = 0.24, texto = "Emotionally and physically numb" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 7, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.24, valfim = 0.29, texto = "In a drunken stupor" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 8, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.29, valfim = 0.34, texto = "Probably in a coma" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 9, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.34, valfim = 9.99, texto = "Call a Taxi!" });



            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 28, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.0, valfim = 0.019, texto = "Un poco mareado" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 29, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.019, valfim = 0.04, texto = "acogedor y relajado" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 30, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.04, valfim = 0.09, texto = "falta de coordinación (legalmente borracho)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 31, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.09, valfim = 0.014, texto = "apagón posible (pérdida de memoria)" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 32, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.14, valfim = 0.19, texto = "Sientes confundido y aturdido" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 33, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.19, valfim = 0.24, texto = "emocional y físicamente adormecido" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 34, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.24, valfim = 0.29, texto = "Puede estár borracho!" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 35, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.29, valfim = 0.34, texto = "Es probable que entre en coma" });
            App.ListaFrases.Add(new App.Frases() { ativo = 1, codigo = 36, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.34, valfim = 9.99, texto = "Llamar a un taxi" });





        }




        public void adicionaFilme()
        {

            App.ListaFilmes.Add(new App.Filmes() { ativo = 1, codigo = 200, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", lati = "1", longi = "1", raio = "40075000", URI = "x-LzUNuTZqA" });
            App.ListaFilmes.Add(new App.Filmes() { ativo = 1, codigo = 100, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", lati = "1", longi = "1", raio = "40075000", URI = "MZtDqpdvy7s" });
            App.ListaFilmes.Add(new App.Filmes() { ativo = 1, codigo = 1, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", lati = "1", longi = "1", raio = "40075000", URI = "xO53rQ9nqQs" });
            App.ListaFilmes.Add(new App.Filmes() { ativo = 1, codigo = 300, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", lati = "1", longi = "1", raio = "40075000", URI = "DOpej1RPdAA" });
            App.ListaFilmes.Add(new App.Filmes() { ativo = 1, codigo = 400, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-PT", lati = "1", longi = "1", raio = "40075000", URI = "LAIQKn3VKKk" });


        }



     //   private BackgroundWorker backgroundWorker;


        public Checkin()
        {
            InitializeComponent();


            App.LinkFoto = null;

            mediaElement.AutoPlay = false;
            mediaElement2.AutoPlay = false;


            LayoutRoot.Children.Add(mediaElement);
            LayoutRoot.Children.Add(mediaElement2);

            mediaElement2.Source = new Uri("images/copo.mp3", UriKind.RelativeOrAbsolute);
            mediaElement.Source = new Uri("images/samba_rio.mp3", UriKind.RelativeOrAbsolute);




            if (App.ListaFilmes.Count == 0)
            {

                if (store.FileExists("filmes.xml"))
                {
                    App.ListaFilmes = GravaIS.IsolatedStorageCacheManager<List<App.Filmes>>.Retrieve("filmes.xml");
                    if (App.ListaFilmes.Count == 0)
                    {
                        adicionaFilme();
                    }


                }
                else
                {
                    adicionaFilme();
                }




                for (int i = 0; i <= App.ListaFilmes.Count - 1; i++)
                {
                    DateTime monta = Convert.ToDateTime(App.ListaFilmes[i].datfim);
                    float diferenca = DateTime.Compare(DateTime.Today, monta);

                    if (diferenca > 0)
                    {
                        App.ListaFilmes[i].ativo = 0;
                    }

                }

                if (store.FileExists("medalhas.xml"))
                {
                    App.ListaMedalhas = GravaIS.IsolatedStorageCacheManager<List<App.medalhas>>.Retrieve("medalhas.xml");
                }

                if (store.FileExists("omarcas.xml"))
                {
                    App.LOutras = GravaIS.IsolatedStorageCacheManager<List<App.OMarcas>>.Retrieve("omarcas.xml");
                }

                if (store.FileExists("dmarcas.xml"))
                {
                    App.LDelete = GravaIS.IsolatedStorageCacheManager<List<App.OMarcas>>.Retrieve("dmarcas.xml");
                }

                if (store.FileExists("shots.xml"))
                {
                    App.ListaShot = GravaIS.IsolatedStorageCacheManager<List<App.Shot>>.Retrieve("shots.xml");
                }

                if (store.FileExists("qrcode.xml"))
                {
                    App.QRPromocao = GravaIS.IsolatedStorageCacheManager<List<App.qrpromocao>>.Retrieve("qrcode.xml");
                }

                XDocument loadedDataBebi = XDocument.Load("SampleData/bebidas.xml");
                var dataBebi = from query in loadedDataBebi.Descendants("Bebida")
                               select new App.Bebidas
                               {
                                   Nome = (string)query.Element("Nome"),
                                   img = (string)query.Element("img"),
                                   dose_ml = (double)query.Element("dose"),
                                   garrafa = (string)query.Element("garrafa"),
                                   teor = (double)query.Element("teor"),
                               };

                App.ListaBebidas = dataBebi.ToList();

                Dispatcher.BeginInvoke(() =>
                {
                    foreach (App.Bebidas x in App.ListaBebidas)
                    {

                        Uri uri = new Uri(x.garrafa, UriKind.Relative);
                        ImageSource imgSource = new BitmapImage(uri);
                        x.img_garrafa = imgSource;

                        string ima = x.img.Replace("_03.png", "_00.png");

                        Uri uri1 = new Uri(ima, UriKind.Relative);
                        ImageSource imgSource1 = new BitmapImage(uri1);
                        x.img_copo = imgSource1;

                    }



                });


                if (store.FileExists("frases.xml"))
                {
                    App.ListaFrases = GravaIS.IsolatedStorageCacheManager<List<App.Frases>>.Retrieve("frases.xml");
                    if (App.ListaFrases.Count == 0)
                    {
                        adicionaFrase();
                    }


                }
                else
                {

                    adicionaFrase();
                    
                }




                for (int i = 0; i <= App.ListaFrases.Count - 1; i++)
                {
                    DateTime monta = Convert.ToDateTime(App.ListaFrases[i].datfim);
                    float diferenca = DateTime.Compare(DateTime.Today, monta);

                    if (diferenca > 0)
                    {
                        App.ListaFrases[i].ativo = 0;
                    }

                }



         
            }




            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_checkin.ToString();
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_capture.ToString();

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false; 



            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_promotion.ToString();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).Text = Localization.b_info.ToString();
            ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.b_clear.ToString();

            targetElement.Visibility = Visibility.Collapsed;
            targetElement1.Visibility = Visibility.Collapsed;




            /*

            bool darkTheme = ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible);
            if (darkTheme == true)
            {


                ApplicationBar.BackgroundColor = Colors.Black;

            }
            else
            {
                ApplicationBar.BackgroundColor = Colors.White;
            }
            */


            App.LinkFoto = null;
            eSel.Visibility = Visibility.Collapsed;
            img_lousa.Visibility = Visibility.Collapsed;
            img_som.Visibility =   Visibility.Collapsed;
            barra.Visibility = Visibility.Collapsed;
            list1.Visibility = Visibility.Collapsed;
            list2.Visibility = Visibility.Collapsed;
            list3.Visibility = Visibility.Collapsed;
   


            
            this.random = new Random();
            this.list1.DataSource = new PictureDataSource(0);
            this.list2.DataSource = new PictureDataSource(1);
            this.list3.DataSource = new PictureDataSource(2);
            this.list1.SelectedIndex = 1;
            this.list2.SelectedIndex = 4;
            this.list3.SelectedIndex = 7;

            this.list1.ScrollCompleted += this.OnLoopingListScrollCompleted;
            this.list2.ScrollCompleted += this.OnLoopingListScrollCompleted;
            this.list3.ScrollCompleted += this.OnLoopingListScrollCompleted;


            Limpar_Click(null, null);

            

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);          
        }





        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            mandou_foto = false;

        }



        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            mandou_foto = true;

            try
            {

           

                client2.LoginAsync((result, state) =>
                {
                    if (state.Exception != null) {  }
                    else
                    {
                        user = result;

                        if (user != null)
                        {


                            this.Dispatcher.BeginInvoke(() => {  });



                            user.PhotoAlbums.CreateAsync((r, ex) =>
                            {


                                album = r;

                                if (album != null)
                                {
                                    App.LocIDAlbum = album.AlbumId;

                                    this.Dispatcher.BeginInvoke(() => {  });

                                    album.AddPictureAsync((p, ex2) =>
                                    {
                                        if (p != null)
                                        {
                                            pic = p;
                                            this.Dispatcher.BeginInvoke(() =>
                                            {
                                                App.LinkFoto = pic.FullUrl;
                                                App.LocFotoFileName0 = pic.FullUrl;
                                                //MessageBox.Show(Localization.ms65.ToString());
                                                
                                            });
                                        }


                                        /*
                                        else
                                        {
                                            this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.ms71.ToString()); });
                                        }
                                        */

                                    }, App.byteArray0, App.LocName);
                                }
                            }, App.LocID);
                        }
                    }
                }, App.Conf[0].UserToken);



            }
            catch (Exception ex)
            {
                //MessageBox.Show(Localization.m02.ToString());
                return;
            }


           


        }








        public class MediaImage
        {

            public BitmapImage ImageFile { get; set; }

        }


        private void GetImages()

        {


            imgfoto.Visibility = Visibility.Visible;

            MediaLibrary mediaLibrary = new MediaLibrary();
            var pictures = mediaLibrary.Pictures;

            contafoto = contafoto + 1;
            if (contafoto >= pictures.Count)
            {
                contafoto = 1;
            }


            var picture = pictures[contafoto];




          


                BitmapImage image = new BitmapImage();

                image.SetSource(picture.GetImage());

                MediaImage mediaImage = new MediaImage();

                mediaImage.ImageFile = image;

                imgfoto.Source = mediaImage.ImageFile;
                
               



           
        }
















        private void OnLoopingListScrollCompleted(object sender, LoopingListScrollEventArgs args)
        {
            if (this.list1.ScrollState == LoopingPanelScrollState.NotScrolling &&
                 this.list2.ScrollState == LoopingPanelScrollState.NotScrolling &&
                 this.list3.ScrollState == LoopingPanelScrollState.NotScrolling)
            {

                if ((list1.SelectedIndex != -1) && (list2.SelectedIndex != -1) && (list3.SelectedIndex != -1))
                {
                    lista[list1.SelectedIndex] = lista[list1.SelectedIndex] + 1;
                    lista[list2.SelectedIndex] = lista[list2.SelectedIndex] + 1;
                    lista[list3.SelectedIndex] = lista[list3.SelectedIndex] + 1;


                    //          MessageBox.Show("passou List1= " + list1.SelectedIndex.ToString() + " List2= " + list2.SelectedIndex.ToString() + " List3= " + list3.SelectedIndex.ToString());




                   // playsound2("images/samba_rio.mp3");



                    completou = true;
                    Uri uri2 = new Uri("/images/MACHINE2.png", UriKind.Relative);
                    ImageSource imgSource3 = new BitmapImage(uri2);
                    img_lousa.Source = imgSource3;
                   // mediaElement15.Stop();

                    Thread.Sleep(100);


                    for (int i = 0; i <= 22; i++)
                    {
                        int ganhou = 0;


                        if (lista[i] > 1)
                        {

                            if (lista[i] == 2)
                            {
                                ganhou = 8;
                                if (i == 0) { ganhou = 16; }
                            }
                            if (lista[i] == 3)
                            {
                                ganhou = 32;
                                if (i == 0) { ganhou = 64; }
                            }

                            pontosSlot = pontosSlot + ganhou;
                            tGanha.Text = "You win: " + (ganhou).ToString();

                            if ((ganhou > 0) && (ganhou < 32))
                            {
                                if (flipSlot == true)
                                {


                                    PlaySound("images/ganha.wav");


                                   // GetImages();

                                    //mediaElement2.Play();



                                    /*
                                    MediaPlayerLauncher launcher = new MediaPlayerLauncher();
                                    launcher.Media = new Uri("http://www.youtube.com/watch?v=JrhkdurpGrY", UriKind.RelativeOrAbsolute);
                                    launcher.Controls = MediaPlaybackControls.All;
                                    launcher.Show();
                                    */













                                }








                            }

                            if (ganhou > 31)
                            {

                                if (flipSlot == true)
                                {

                                   playsound2("images/samba_rio.mp3");

                                   // mediaElement4.Play();
                                    dispatcherTimer.Stop();
                                }


                            }
                            if (ganhou < 0)
                            {

                                if (flipSlot == true)
                                {
                                   // mediaElement3.Play();
                                   // tGanha.Text = "You Lose: " + (ganhou).ToString();
                                }


                            }
                            break;
                        }
                    }


                    tPontos.Text = pontosSlot.ToString();
                    tSpins.Text = spins.ToString();


                    if (pontosSlot > 0)
                    {


                        List<App.medalhas> fil = new List<App.medalhas>();
                        fil = App.ListaMedalhas;
                        var resu = (from x in fil
                                    where ((x.data == DateTime.Today.ToString("MM/dd/yyyy")) && (x.locname == App.LocName))
                                    select x).SingleOrDefault();

                        if (resu == null)
                        {
                            App.ListaMedalhas.Add(new App.medalhas() { pais = App.LocPais, cida = App.LocCity, cod = "1", data = DateTime.Today.ToString("MM/dd/yyyy"), email = App.Conf[0].EmailUsu, locname = App.LocName, tipo = "1", lat = App.LocLat, lon = App.LocLon, promoname = "spin", pontos = pontosSlot, spin = spins });

                        }
                        else
                        {

                            foreach (App.medalhas x in App.ListaMedalhas)
                            {

                                if ((x.data == DateTime.Today.ToString("MM/dd/yyyy")) && (x.locname == App.LocName))
                                {

                                    x.spin = spins;
                                    x.pontos = pontosSlot;

                                }

                            }

                        }

                    }                    







                }
















            }

        }


        public class PictureDataSource : LoopingListDataSource
        {
            private int columnIndex;

            public PictureDataSource(int colIndex)
                : base(12)
            {
                this.columnIndex = colIndex;
            }

            public int ColumnIndex
            {
                get
                {
                    return this.columnIndex;
                }
            }

            protected override LoopingListDataItem GetItemCore(int index)
            {
                PictureDataItem item = new PictureDataItem();
                this.UpdateItemCore(item, index);

                return item;
            }

            protected override void UpdateItemCore(LoopingListDataItem dataItem, int logicalIndex)
            {
                PictureDataItem item = dataItem as PictureDataItem;
                //string theme = MainViewModel.Instance.IsDarkTheme ? "dark" : "light";
                string uri = "images/dark/" + (this.columnIndex + 1) + "." + (logicalIndex + 1) + ".png";
                item.Picture = new Uri(uri, UriKind.Relative);




            }
        }

        public class PictureDataItem : LoopingListDataItem
        {
            private Uri picture;

            public PictureDataItem()
            {
            }

            public Uri Picture
            {
                get
                {
                    return this.picture;
                }
                set
                {
                    this.picture = value;
                    this.OnPropertyChanged("Picture");
                }
            }
        }


        private void ScrollList(RadLoopingList list)
        {
            int duration = this.random.Next(1500, 3000);
            double offset = this.random.Next(3000, 5000);

            list.SelectedIndex = -1;

            list.AnimateVerticalOffset(list.VerticalOffset + offset, new Duration(TimeSpan.FromMilliseconds(duration)), new CubicEase());

            if ((list.DataSource as PictureDataSource).ColumnIndex == 0)
            {

                if (duration >= dura)
                {
                    dura = duration;
                    quem = 1;
                }

            }

            if ((list.DataSource as PictureDataSource).ColumnIndex == 1)
            {

                if (duration >= dura)
                {
                    dura = duration;
                    quem = 2;
                }



            }

            if ((list.DataSource as PictureDataSource).ColumnIndex == 2)
            {
                if (duration >= dura)
                {
                    dura = duration;
                    quem = 3;
                }

            }






        }









    /*

        public void escondetudo(int opa)
        {

            return;



            for (int i = 0; i < 12; i++)
            {

                foreach (UIElement item in SP1.Children)
                {
                    Image teste = item as Image;

                    if (teste != null)
                    {
                        if (App.ListaShot[i].ml > 0)
                        {


                            if (teste.Tag.ToString() == App.ListaShot[i].tag.ToString())
                            {

                                teste.Source = App.ListaBebidas[App.ListaShot[i].tag].img_garrafa;
                                teste.Visibility = Visibility.Visible;
                                item.Visibility = Visibility.Visible;
                            }
                            






                        }
                        else
                        {

                            item.Visibility = Visibility.Collapsed;
                            


                        }


                    }
                }

               






            }
        }

        


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {


           meuconta = meuconta + 1;


            if (meuconta == 1)
            {

                Uri uri1 = new Uri("champanhe_00.png", UriKind.Relative);
                ImageSource imgSource1 = new BitmapImage(uri1);
                img_copo.Source = imgSource1;
                //Thread.Sleep(1500);
            }



            if (meuconta == 2)
            {

                Uri uri2 = new Uri("champanhe_01.png", UriKind.Relative);
                ImageSource imgSource2 = new BitmapImage(uri2);
                img_copo.Source = imgSource2;
                //Thread.Sleep(1500);
            }





            if (meuconta == 3)
            {

                Uri uri3 = new Uri("champanhe_02.png", UriKind.Relative);
                ImageSource imgSource3 = new BitmapImage(uri3);
                img_copo.Source = imgSource3;

            }


            if (meuconta == 4)
            {

                Uri uri4 = new Uri("champanhe_03.png", UriKind.Relative);
                ImageSource imgSource4 = new BitmapImage(uri4);
                img_copo.Source = imgSource4;
                dispatcherTimer2.Stop();
            }











        }

        */




        private void playsound1(string path)
        {



            mediaElement2.Stop();
            mediaElement2.Position = TimeSpan.Zero; 
            mediaElement2.Play();


        }





        private void playsound2(string path)
        {



            mediaElement.Stop();
           // mediaElement.Source = new Uri(path, UriKind.RelativeOrAbsolute);
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();


        }





        private void PlaySound(string path)
        {
            try
            {
                SoundEffect sound = SoundEffect.FromStream(Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream);
                SoundEffectInstance instance = sound.CreateInstance();
                instance.Play();


            }
            catch (Exception e)
            {

            }
        }





        public void PopulaGarrafas()
        {
        }


              private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {


                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_checkin.ToString();
              //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_capture.ToString();
                ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).Text = Localization.b_promotion.ToString();
                ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).Text = Localization.b_info.ToString();
                ((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).Text = Localization.b_clear.ToString();



                  /*
                bool darkTheme = ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible);
                if (darkTheme == true)
                {


                    ApplicationBar.BackgroundColor = Colors.Black;

                }
                else
                {
                    ApplicationBar.BackgroundColor = Colors.White;
                }
                  */


                tGanha.Text = Localization.ms107;
                eNome.Content = App.LocName;


               if (App.Passou == false) {  pega_pontos();}

                App.Passou = true;


                //mediaElement1.Source = new Uri("http://www.youtube.com/watch?v=h4SBljVQA3k&feature=player_detailpage", UriKind.Absolute);
               

         /*     
              ExcluirTudoUser();
              ExcluirTudoApp();
              return; 
           */      




                /*


                                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                                {
                                    MessageBox.Show(Localization.m01.ToString());
                                return;
                                }





                               LigaDesligaBuzy(true);

                               if (App.Passou == false)               
                               {
                               EscondeCompo(1);
                               }
                               else
                               {
                               EscondeCompo(0);
                               }

                               if (App.PassouMarca == true)
                               {
                                   EscondeCompo(0);
                                   App.PassouMarca = false;
                               }
                               else
                               {
                  
                               }

                               if (App.Clicou == true)
                               {
                                    App.Clicou = false;
                               }


                               if (App.PassouDoses == true)
                               {
                                   App.PassouDoses = false;
                                   EscondeCompo(0);
                                   LigaDesligaBuzy(false);
                                   return;
                               }

                               InicializaVariaveis();
                               ZeraTabelas();

                  

                  */


                                List<App.Filmes> fil = new List<App.Filmes>();
                                fil = App.ListaFilmes;
                                var resu = (from x in fil
                                            where x.idioma == App.Conf[0].Idioma
                                            orderby x.datini ascending
                                            select x).ToList();

                                List<App.Filmes> resu1 = new List<App.Filmes>();

                                if (resu == null)
                                {
                                    resu1 = (from x in fil
                                             where x.idioma == "default"
                                             orderby x.datini ascending
                                             select x).ToList();
                                }
                                else
                                {
                                    resu1 = (from x in fil
                                             where x.idioma == App.Conf[0].Idioma
                                             orderby x.datini ascending
                                             select x).ToList();

                                }





                                string def = "";
                                string filme = ""; 

                                foreach (App.Filmes x in resu1)
                                {
                                    var sCoord = new GeoCoordinate(Convert.ToDouble(x.lati, CultureInfo.InvariantCulture), Convert.ToDouble(x.longi, CultureInfo.InvariantCulture));
                                    var eCoord = new GeoCoordinate(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));
                                    distancia = sCoord.GetDistanceTo(eCoord);
                                    if (distancia <=   Convert.ToDouble(x.raio, CultureInfo.InvariantCulture)) 
                                    {
                                        if (x.lati != "1")
                                        {
                                            filme = x.URI;
                                        }
                                        else
                                        {
                                            def = x.URI;
                                        }


                                    }

                                }


                                if (filme == "")
                                {
                                    App.LocFilme = def;
                                }
                                else
                                {
                                    App.LocFilme = filme;
                                }





                                  


                if ((App.LatSat != 0) && (App.LonSat != 0))
                {

                    var sCoord = new GeoCoordinate(App.LatSat, App.LonSat);
                    var eCoord = new GeoCoordinate(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));

                    distancia = sCoord.GetDistanceTo(eCoord);

                }
                else
                {
                    distancia = 0;

                }


               //MessageBox.Show("Distância: " + distancia.ToString());







               if ((App.PassouMarca == true) && (App.marca != null))
               {
                   EscondeCompo(0);
                   App.PassouMarca = false;
                   return;
               }
               else
               {
                   EscondeCompo(1);

               }



                /*
                               if (App.ListaShot[0].ml > 0)
                               {
                                   App.shots  = App.ListaShot[0].shots;
                                   App.dose   = App.ListaShot[0].ml;
                                   App.bebida = App.ListaShot[0].bebida;
                                   App.marca  = App.ListaShot[0].marca;
                                   eSel.Text  = App.bebida + ": " + App.marca;


                                   EscondeCompo(0);    
                   
                   
                   
                   
                   
                   
                   
                   
                   
                   
                   
                                   //      t_shot.Text = "" + App.shots.ToString();
              
                   
                               //    t_tot_ml.Text = ((App.dose) / 1000).ToString("0.000", CultureInfo.InvariantCulture) + " L";
                   
                              //     Uri uri1 = new Uri("/images/button_up.png", UriKind.Relative);
                              //     ImageSource imgSource1 = new BitmapImage(uri1);
               
                   
                   
                   
                   
                                   // this.img_button.Source = imgSource1;
                   
                                  // image1.Source = App.ListaBebidas[App.ListaShot[0].tag].img_copo;
                                 //  img_bebida.Source = App.ListaBebidas[App.ListaShot[0].tag].img_garrafa;
               

                 


                                   //App.ListaShot[0].imagem.Visibility = Visibility.Collapsed;



                                //   PopulaGarrafas();


                               //    App.ImgBebiClicada = img_bebida;
                               //    App.ImgBebiClicada.Tag = App.ListaShot[0].tag.ToString();
                                  // slider1.Value = App.ListaShot[0].slider;
 



               

               

                               }



                 * 
                 * 
                 */







               targetElement.Visibility = Visibility.Visible;
               eWarning.Text = Localization.ms131;
               eWarning.Visibility = Visibility.Visible;

               dt.Interval = TimeSpan.FromSeconds(3);
               dt.Tick += new EventHandler(dt_Tick);
               dt.Start();



              // Thread.Sleep(5000);
               //targetElement.Visibility = Visibility.Collapsed;
               //eWarning.Visibility = Visibility.Collapsed;






            }



              void dt_Tick(object sender, EventArgs e)
              {

                 
                      dt.Stop();
                      targetElement.Visibility = Visibility.Collapsed;       



              }




              private void EscondeCompo(int esconde)

              {
 
                  if (esconde == 1)
               {
               }
               else
               {


                   eSel.Visibility = Visibility.Visible;
                   eSel.Visibility = Visibility.Visible;
 
               }
            

               }


              protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
              {



                  YouTube.CancelPlay();
                  


                      if (App.bebida != null)
                      {
                          eSel.Text = App.bebida;
                      }


                      if (App.marca != null)
                      {
                          Uri uri = new Uri(App.img, UriKind.Relative);
                          ImageSource imgSource = new BitmapImage(uri);
                          confere2();
                
                          poe_mesa(senderx); 

                          App.shots = 1;



                          bebida = App.bebida;
                          marca = App.marca;
                          eSel.Text = App.bebida + ": " + App.marca; 
                        

                          EscondeCompo(0);
                          App.Passou = true;
                          poe_lousa(tagw);
                 
                      }


                     



              }




              protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
              {
              }





               private void ZeraTabelas()
               {

           

               }


               private void LigaDesligaProgress(bool valor, string texto)
               {
                   progress1.IsVisible = valor;
                   progress1.IsIndeterminate = valor;
                   progress1.Text = texto;
                   SystemTray.SetProgressIndicator(this, progress1);


               }

               private void LigaDesligaBuzy(bool val)
               {
                   // busyIndicator.IsRunning = val;
               }


               private void InicializaVariaveis()
               {
               latx = App.LocLat.ToString();
               lonx = App.LocLon.ToString();
               laty = latx.Replace(",", ".");
               lony = lonx.Replace(",", ".");
               local = App.LocName;
               IDLocal = App.LocID;
               dateString = DateTime.Now.ToShortDateString();
               localEdit coloca = new localEdit();
               coloca.nome = App.LocName;
               coloca.ende = App.LocAddress+" "+ App.LocPais+" "+ App.LocUF+" "+App.LocCity+"  "+App.LocFone;
               App.NaoSoma = false;
               }

           
              private void MostraMapa()
              {

              }

                 


              private void RadHubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
              {

                   confere();
 
              }



              public void confere()
              {

                  if (eSel.Text.Length == 0)
                  {
                      MessageBox.Show(Localization.m22.ToString());
                      return;
                  }


                  if (App.marca == null)
                  {
                      MessageBox.Show(Localization.m23.ToString());
                      return;
                  }
                        

                 
                  Executa_Set_User();

                  latx = App.LocLat.ToString();
                  lonx = App.LocLon.ToString();
                  laty = latx.Replace(",", ".");
                  lony = lonx.Replace(",", "."); 
                   
                  App.FBUrl = "http://dev.virtualearth.net/embeddedMap/v1/ajax/aerial?zoomLevel=17&center=" + laty + "_" + lony + "&pushpins=" + laty + "_" + lony;
                  App.FBMens = "";
                  App.NaoSoma = true;

                  NavigationService.Navigate(new Uri("/Messages_Main.xaml", UriKind.RelativeOrAbsolute));

              }


              public void Executa_Set_App_Local_2()
              {


                  this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });
                  string chave = "<A2><A2_email>" + App.Conf[0].EmailUsu + "</A2_email><A2_local>" + App.LocName + "</A2_local><A2_pais>" + System.Globalization.RegionInfo.CurrentRegion.DisplayName + "</A2_pais></A2>";
                  try
                  {
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(App_Local2);
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, "1", App.LocLat, App.LocLon, "", "");
                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      LigaDesligaProgress(false, "");
                      return;
                  }
              }
              void App_Local2(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
              {
                  if (e.Error == null)
                  {
                      if (e.Result != null)
                      {
                          //Executa_Set_App_Local_2();
                          LigaDesligaProgress(false, "");
                      }
                      else
                      {

                      }
                      LigaDesligaProgress(false, "");
                  }
              }


              public void Executa_Set_App_Local()
              {


                  this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });
                  string chave = "<A0><A0_local>" + App.LocName + "</A0_local><A0_pais>" + App.LocPais + "</A0_pais><A0_cida>" + App.LocCity + "</A0_cida></A0>";
                  try
                  {
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(App_Local);
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, "1", App.LocLat, App.LocLon, "", "");
                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      LigaDesligaProgress(false, "");
                      return;
                  }
              }
              void App_Local(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
              {
                  if (e.Error == null)
                  {
                      if (e.Result != null)
                      {
                          //Executa_Set_App_Local_2();
                      }
                      else
                      {

                      }
                      LigaDesligaProgress(false, "");
                  }
              }











              public void Executa_Set_User_Local()
              {
                  

                  this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });
                  string chave = "<A0><A0_local>" + App.LocName + "</A0_local></A0>";
                  try
                  {
                      client.Service.MetaData_UserMetaDataValue_SetCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs>(User_Local);
                      client.Service.MetaData_UserMetaDataValue_SetAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, chave, "1", App.LocLat, App.LocLon,"","");
                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      LigaDesligaProgress(false, "");
                      return;
                  }
              }
              void User_Local(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs e)
              {
                  if (e.Error == null)
                  {
                      if (e.Result != null)
                      {
                          
                         // Executa_Set_App_Local();
                      }
                      else
                      {
                          
                      }

                      LigaDesligaProgress(false, "");
                  }
              }




           













              public void Executa_Set_App()
              {


                  this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });

                  string chave = "<A1><A1_local>" + App.LocName + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca></A1>";



                  try
                  {
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(User_CheckIn_Pro);
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, "1", App.LocLat, App.LocLon, "", "");

                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      LigaDesligaProgress(false, "");
                      return;
                  }

              }




              void User_CheckIn_Pro(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
              {

                  if (e.Error == null)
                  {


                      if (e.Result != null)
                      {
                         
                          
                      }
                      
                      //Executa_Set_User_Local();
                     // LigaDesligaProgress(false, "");

                  }
              }


              public class Coordenadas
              {

                  private float _longitude = 0;
                  private float _latitude = 0;
                  public float Longitude
                  {
                      get { return _longitude; }
                      set { _longitude = value; }
                  }

                  public float Latitude
                  {
                      get { return _latitude; }
                      set { _latitude = value; }
                  }

              }









              public void Executa_Set_TotBebida()
              {


                  //this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });

                  string chave = "<A8><A8_bebida>" + App.bebida + "</A8_bebida><A8_marca>" + App.marca + "</A8_marca></A8>";



                  try
                  {
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(Data_totbebida_Pro);
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, "1", "0", "0", "", "");

                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      // LigaDesligaProgress(false, "");
                      return;
                  }

              }




              void Data_totbebida_Pro(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
              {

                  if (e.Error == null)
                  {


                      if (e.Result != null)
                      {


                      }

                      //Executa_Set_User_Local();
                      // LigaDesligaProgress(false, "");

                  }
              }
























              public void Executa_Set_CheckTot()
              {


                  //this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });

                  string chave = "<A5><A5_datadrink>" + String.Format("{0:MM/dd/yyyy}", DateTime.Now) + "</A5_datadrink></A5>";



                  try
                  {
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(Data_CheckIn_Pro);
                      client.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, "1", "0", "0", "", "");

                  }

                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                      // LigaDesligaProgress(false, "");
                      return;
                  }

              }




              void Data_CheckIn_Pro(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
              {

                  if (e.Error == null)
                  {


                      if (e.Result != null)
                      {


                      }

                      //Executa_Set_User_Local();
                      // LigaDesligaProgress(false, "");

                  }
              }




              public void Executa_Set_User()
              {




                  Coordenadas objcoordenadas = new Coordenadas();

                  objcoordenadas.Latitude = Convert.ToSingle(App.LocLat, CultureInfo.InvariantCulture);
                  objcoordenadas.Longitude = Convert.ToSingle(App.LocLon, CultureInfo.InvariantCulture);
 

                  this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, Localization.m33.ToString()); });

                  string chave = "<A1><A1_data>" + String.Format("{0:MM/dd/yyyy}", DateTime.Now) + "</A1_data><A1_local>" + App.LocName + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca></A1>";
                  AuthenticatedUser user = null;

                  client.LoginAsync((result, state) =>
                  {
                      if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                      else
                      {
                          user = result;

                          MetadataItem x = null;



                       //   user.CheckInAsync((p23, x23) =>
                         // {

                              

                              user.Metadata.GetAsync((p1, ex1) =>
                                  {

                                      x = p1;


                                      if (ex1.Completed == true)
                                      {
                                          if (x == null)
                                          {

                                              user.Metadata.SetAsync((p, ex) =>
                                              {
                                                  if (ex.Exception != null) MessageBox.Show("Error: " + ex.Exception.Message);


                                                  if (p == true)
                                                  {

                                                      LigaDesligaProgress(false, "");
                                                      Executa_Set_App();
                                                      Executa_Set_User_Local();
                                                      Executa_Set_App_Local();
                                                      Executa_Set_App_Local_2();
                                                      Executa_Set_CheckTot();
                                                      Executa_Set_TotBebida();
                                                      


                                                  }
                                                  else
                                                  {



                                                  }


                                              }, chave, "1", 0, 0);












                                          }
                                          else
                                          {
                                              //MessageBox.Show("Já existe" + x.Key);
                                          }
                                      }

                                  }, chave);

                          //}, Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture), App.LocName);
                      }









                  }, App.Conf[0].UserToken);








              }












        /*


              public void Executa_Get_User_MetaFinal()
              {


                  SyncJobsFinal.ElementFinished += new Get_User_Meta.ElementFinishedDelegate(SyncJobsFinal_ElementFinished);
                  SyncJobsFinal.WorkFinished += new Get_User_Meta.WorkFinishedDelegate(SyncJobsFinal_WorkFinished);

                  string[] chaves = new string[2];
                  chaves[0] = "<i1>" + local + "</i1><i11>" + bebida + "</i11>";
                  chaves[1] = "<i2>" + local + "</i2><i21>" + bebida + "</i21><i22>" + marca + "</i22>";


                  App.ListaGet[1].MetaKey = "<i1>" + local + "</i1><i11>" + bebida + "</i11>";
                  App.ListaGet[2].MetaKey = "<i2>" + local + "</i2><i21>" + bebida + "</i21><i22>" + marca + "</i22>";

                  App.ListaGet[3].MetaKey = "<i3>" + local + "</i3><i31>" + bebida + "</i31>";
                  App.ListaGet[4].MetaKey = "<i4>" + local + "</i4><i41>" + bebida + "</i41><i42>" + marca + "</i42>";


                  SyncJobsFinal.GetMetaUserAsync(toke, chaves);

              }

              void SyncJobsFinal_WorkFinished(bool success)
              {
                  if (success)
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaBuzy(true); });
                      this.Dispatcher.BeginInvoke(() => { NavigationService.Navigate(new Uri("/CheckinDrinkFinal.xaml", UriKind.RelativeOrAbsolute)); });
                  }

                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      return;
                  }
              }

              void SyncJobsFinal_ElementFinished()
              {
                  if (SyncJobsFinal.CurrentElementToRun > SyncJobsFinal.ElementsToRun.Count - 1)
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, " "); });
                  }
                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, "Geting user data place drinking... "); });
                  }

              }

        */
              private void radHubTile3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
              {
                  //this.NavigationService.Navigate(new Uri("/CheckinDet.xaml", UriKind.RelativeOrAbsolute));
              }

              private void eSel_ItemClick(object sender, Telerik.Windows.Controls.Primitives.SelectorItemClickEventArgs e)
              {
                //  eBrand.Text = "";

      
              }





        /*

              public void Executa_Get_App_MetaInicial()
              {



              }



              void SyncJobsAppInicial_WorkFinished(bool success)
              {


                  if (success)
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      this.Dispatcher.BeginInvoke(() => { EscondeCompo(0);});
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaBuzy(false); });                      
                      this.ColocaValores();
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });

                      if (marca != "")
                      {

                      }
                      else
                      {
                      }



                      App.ListaTotais[7].MetaKey         = App.ListaGet[7].MetaKey;
                      App.ListaTotais[7].MetaValue       = App.ListaGet[7].MetaValue;
                      App.ListaTotais[7].MetaLatitude    = App.ListaGet[7].MetaLatitude;
                      App.ListaTotais[7].MetaLongitude   = App.ListaGet[7].MetaLongitude;

                      App.ListaTotais[8].MetaKey         = App.ListaGet[7].MetaKey;
                      App.ListaTotais[8].MetaValue       = App.ListaGet[7].MetaValue;
                      App.ListaTotais[8].MetaLatitude    = App.ListaGet[7].MetaLatitude;
                      App.ListaTotais[8].MetaLongitude   = App.ListaGet[7].MetaLongitude;

                      App.ListaTotais[1].MetaKey         = App.ListaGet[7].MetaKey;
                      App.ListaTotais[1].MetaValue       = App.ListaGet[7].MetaValue;
                      App.ListaTotais[1].MetaLatitude    = App.ListaGet[7].MetaLatitude;
                      App.ListaTotais[1].MetaLongitude   = App.ListaGet[7].MetaLongitude;

                      App.ListaTotais[2].MetaKey         = App.ListaGet[7].MetaKey;
                      App.ListaTotais[2].MetaValue       = App.ListaGet[7].MetaValue;
                      App.ListaTotais[2].MetaLatitude    = App.ListaGet[7].MetaLatitude;
                      App.ListaTotais[2].MetaLongitude   = App.ListaGet[7].MetaLongitude;






                  }

                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      
                      return;
                  }
              }

              /// <summary>
              /// </summary>
              void SyncJobsAppInicial_ElementFinished()
              {



                  if (SyncJobsAppInicial.CurrentElementToRun > SyncJobsAppInicial.ElementsToRun.Count - 1)
                  {
                      this.Dispatcher.BeginInvoke(() => { this.LigaDesligaProgress(false, ""); });
                  }
                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, "Donwload Application data drinks ..."); });

                  }



                  
                      
              }

              public void Executa_Get_App_MetaFinal()
              {



                  SyncJobsAppFinal.ElementFinished += new Get_Application_Meta.ElementFinishedDelegate(SyncJobsAppFinal_ElementFinished);
                  SyncJobsAppFinal.WorkFinished += new Get_Application_Meta.WorkFinishedDelegate(SyncJobsAppFinal_WorkFinished);

                  string[] chaves = new string[4];

                  chaves[0] = "<i3>" + local + "</i3><i31>" + bebida + "</i31>";
                  chaves[1] = "<i4>" + local + "</i4><i41>" + bebida + "</i41><i42>" + marca + "</i42>";
                  App.ListaGet[3].MetaKey = "<i3>" + local + "</i3><i31>" + bebida + "</i31>";
                  App.ListaGet[4].MetaKey = "<i4>" + local + "</i4><i41>" + bebida + "</i41><i42>" + marca + "</i42>";

                  SyncJobsAppFinal.GetMetaApplicationAsync(chaves);


              }



              void SyncJobsAppFinal_WorkFinished(bool success)
              {




                  if (success)
                  {

                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaBuzy(true); });
                      App.NaoSoma = false;

                      for (int i = 0; i < 5; i++)
                      {
                          App.ListaTotais[i].MetaKey = App.ListaGet[i].MetaKey;
                          App.ListaTotais[i].MetaValue = App.ListaGet[i].MetaValue;
                          App.ListaTotais[i].MetaLatitude = App.ListaGet[i].MetaLatitude;
                          App.ListaTotais[i].MetaLongitude = App.ListaGet[i].MetaLongitude;
                      }



                      this.Dispatcher.BeginInvoke(() => { NavigationService.Navigate(new Uri("/CheckinDrinkFinal.xaml", UriKind.RelativeOrAbsolute)); });
                  }

                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(false, ""); });
                      return;
                  }
              }

              /// <summary>
              /// </summary>
              void SyncJobsAppFinal_ElementFinished()
              {


                  if (SyncJobsAppFinal.CurrentElementToRun > SyncJobsAppFinal.ElementsToRun.Count - 1)
                  {
                      this.Dispatcher.BeginInvoke(() => { this.LigaDesligaProgress(false, ""); });
                  }
                  else
                  {
                      this.Dispatcher.BeginInvoke(() => { LigaDesligaProgress(true, "Geting Application data drinking ..."); });
                  }
              }
        */

        public void ExcluirTudoUser()
        {
            try
          {

             BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
              client1.Service.MetaData_UserMetaDataValue_DeleteAllCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_DeleteAllCompletedEventArgs>(Get_UserMeta_Drinks);
              client1.Service.MetaData_UserMetaDataValue_DeleteAllAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken);
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
              return;
          }
          }

          void Get_UserMeta_Drinks(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_DeleteAllCompletedEventArgs e)
        {
        }


          public void ExcluirTudoApp()
          {
              try
              {

                  BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                  client1.Service.MetaData_ApplicationMetaDataValue_DeleteAllCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_DeleteAllCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                  client1.Service.MetaData_ApplicationMetaDataValue_DeleteAllAsync(Constants.AppName, Constants.AppPass);
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
                  return;
              }
          }
        
        
        
        
        
        
        
        
        void Get_ApplicationMeta_Drinks(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_DeleteAllCompletedEventArgs e)
          {
          }

        

/*


        public void ColocaValores()
        {



            if (SyncJobsAppInicial.CurrentElementToRun > SyncJobsAppInicial.ElementsToRun.Count - 1)
            {
            }

        }

        */

        private void Check_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            confere();
        }

        private void eBrand_TextInputStart(object sender, TextCompositionEventArgs e)
        {


            if (App.dose > 1)
            {
            }
            else
            {
            }

        }

        private void eBrand_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Enter)    
                {  
                    this.Focus();
                   // confere2();
                    EscondeCompo(0);  
                }
        }

        private void Button_Cancel(object sender, EventArgs e)
        {

        }

        private void Button_Send(object sender, EventArgs e)
        {
            confere();

        }


        private void confere2()
        {

            
            /*
            
            if (eSel.Text.Length == 0)
            {

                MessageBox.Show(Localization.m22.ToString());
                return;

            }


            if (eBrand.Text.Trim().Length == 0)
            {
                MessageBox.Show(Localization.m23.ToString());
                return;
            }

            App.marca = eBrand.Text.Trim();
            bebida = App.bebida;
            marca = eBrand.Text.Trim();
            */
           


        }

        private void eSel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

                      try

            { 

            LigaDesligaBuzy(true);
            App.marca = null;
     //       eBrand.Text = "";
            App.PassouBebidas = true;
            NavigationService.Navigate(new Uri("/mostra_bebidas_novo.xaml", UriKind.RelativeOrAbsolute));
            LigaDesligaBuzy(false);


            }
                      catch (Exception ex)
                      {
                          MessageBox.Show(Localization.m02.ToString());
                          return;
                      }


            

        }

        private void CenterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void image2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
            this.NavigationService.Navigate(new Uri("/MostraFotoPlace.xaml", UriKind.RelativeOrAbsolute));
/*

            App.dose = App.dose + 25;
            if (App.dose > 1000) {
            App.dose = 1000;
            }
          //  slider1.Value = App.dose;
          //  doses.Text = App.dose.ToString();
            if (App.dose > 1)
            {
          //      tDose.Text = Localization.tDoses.ToString();
          //      img_sub.Visibility = Visibility.Visible;
            }
            else
            {

                if (App.dose == 1)
                {

           //         tDose.Text = Localization.tDose.ToString();
           //         img_sub.Visibility = Visibility.Visible;
                }
                else
                {
           //         img_sub.Visibility = Visibility.Collapsed;
                }
            }
            */

        }

        private void image3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            /*

            App.dose = App.dose - 25;

            if (App.dose <= 0)
            {
                App.dose = 0;
            }

            if (App.dose <= 0) {

                tDose.Text = Localization.tDose.ToString();
                App.dose = 0;
                img_sub.Visibility = Visibility.Collapsed;
            }

            if (App.dose > 1) {
                tDose.Text = Localization.tDoses.ToString();
            }
            doses.Text =  App.dose.ToString();
          //  slider1.Value = App.dose;
             * 
             * 
             */ 
        }

        private void OK_Button(object sender, EventArgs e)
        {
            confere();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            /*
            
            
            if (slider1 != null)
            {
                int value1 = Convert.ToInt32(slider1.Value);
                App.dose = value1;
                doses.Text = value1.ToString();
                if (App.dose > 0) 
                {
                    img_sub.Visibility = Visibility.Visible;
                } 
                else
                {
                    img_sub.Visibility = Visibility.Collapsed;
                }
            }

            */


        }

        private void image2_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {


            


        }

        private void eBrand_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LigaDesligaBuzy(true);
            
            App.PassouMarca = true;
            NavigationService.Navigate(new Uri("/MostraMarcas.xaml", UriKind.RelativeOrAbsolute));



            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true; 
 


            LigaDesligaBuzy(false);

        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           // App.PassouDoses = true;
           // NavigationService.Navigate(new Uri("/MostraDoses.xaml", UriKind.RelativeOrAbsolute)); 
        }



       


        private void poe_mesa(object sender)
        {


         //   img_bebida.Source = (sender as Image).Source;
         //   img_bebida.Visibility = Visibility.Visible;


            /*


            if (App.dose == 0) return;
            if (App.ListaShot[12].bebida == "")
            {
                for (int i = 12; i > 0; i--)
                {
                    App.ListaShot[i].bebida = App.ListaShot[i - 1].bebida;
                    App.ListaShot[i].local = App.ListaShot[i - 1].local;
                    App.ListaShot[i].latitude = App.ListaShot[i - 1].latitude;
                    App.ListaShot[i].longitude = App.ListaShot[i - 1].longitude;
                    App.ListaShot[i].gravou = App.ListaShot[i - 1].gravou;
                    App.ListaShot[i].tag = App.ListaShot[i - 1].tag;
                    App.ListaShot[i].horahoje = App.ListaShot[i - 1].horahoje;
                    App.ListaShot[i].shots = App.ListaShot[i - 1].shots;
                    App.ListaShot[i].ml = App.ListaShot[i - 1].ml;
                    App.ListaShot[i].marca = App.ListaShot[i - 1].marca;
                }


                PopulaGarrafas();
            }


            */



        }

        private void image2_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.PassouFotoPlace = true;
            this.NavigationService.Navigate(new Uri("/MostraFotoPlace.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Rel_Button(object sender, EventArgs e)
        {
           // this.NavigationService.Navigate(new Uri("/CheckinDet.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Absinthe_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {






            return;
            
            
            
            
            /*
            string str = (sender as Image).Tag as string;
            App.ImgBebiClicada = (sender as Image);
            App.bebida = App.ListaBebidas[Convert.ToInt32(str)].Nome;
            App.img = App.ListaBebidas[Convert.ToInt32(str)].img;
            App.dose = App.ListaBebidas[Convert.ToInt32(str)].dose_ml;
            App.ListaShot[0].bebida = App.bebida;
            App.ListaShot[0].ml = App.dose;
            App.ListaShot[0].tag = Convert.ToInt32(str);
            App.PassouMarca = true;
            NavigationService.Navigate(new Uri("/MostraMarcas.xaml", UriKind.RelativeOrAbsolute));
            senderx = sender;
            */




        }

        private void img_button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
                VibrateController vibrate = VibrateController.Default;   
                vibrate.Start(TimeSpan.FromMilliseconds(500));
                App.shots = App.shots + 1;
                App.dose  = App.dose + App.ListaBebidas[Convert.ToInt32(App.ImgBebiClicada.Tag as string)].dose_ml;
           //     t_shot.Text = ""+App.shots.ToString();
               //     App.ListaShot[0].bebida = App.bebida;
                //    App.ListaShot[0].local = App.LocName;
                //    App.ListaShot[0].latitude = Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture);
                //    App.ListaShot[0].longitude = Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture);
                //    App.ListaShot[0].gravou = 0;
                //    App.ListaShot[0].tag =  Convert.ToInt32(App.ImgBebiClicada.Tag as string);
                //    App.ListaShot[0].horahoje = DateTime.Today.ToString("hh:mm:ss");
                //    App.ListaShot[0].shots = App.shots;
                //    App.ListaShot[0].ml = App.dose;
               //     App.ListaShot[0].marca = App.marca;
        }

    

        private void slider1_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


            /*

            if (slider1.Value != null)           {


                t_ml.Text = ((slider1.Value)/1000).ToString("0.000")+" L";
            }

            */


        }

        private void img_soma_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           // slider1.Value = slider1.Value + 50;
            //t_ml.Text = slider1.Value.ToString("0.000");
        }

        private void img_sub_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            /*

            if (slider1.Value >= 50)
            {
                slider1.Value = slider1.Value - 50;
               // t_ml.Text = slider1.Value.ToString("0.000");
            }
             * 
             * 
             */ 
        }

        private void eNome_Click(object sender, RoutedEventArgs e)
        {


            if (App.Conf[0].NET == false)
            {

                MessageBox.Show(Localization.m85.ToString());
                return;

            }




            if (App.quem == 1)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetail.xaml", UriKind.RelativeOrAbsolute));
            }

            if (App.quem == 2)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetailGoogle.xaml", UriKind.RelativeOrAbsolute));
            }

            if (App.quem == 3)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetailNokia.xaml", UriKind.RelativeOrAbsolute));
            }



           // this.NavigationService.Navigate(new Uri("/mapa_ende.xaml", UriKind.RelativeOrAbsolute));






        }

        private void img_bebida_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            /*

            if (App.dose > 0) return;

            App.ImgBebiClicada.Visibility = Visibility.Visible;
            (sender as Image).Visibility = Visibility.Collapsed;
       
            */


        }

        private void beb1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            flip1 = !flip1;
            if (flip1 == true)
            {

                string str = (sender as Image).Tag as string;
                int inde = Convert.ToInt32(str);
                RadToolTipService.Open((sender as Image), App.ListaShot[inde].bebida + " shots: " + App.ListaShot[inde].shots.ToString());

            }
            else
            {
                RadToolTipService.Close();
            }


        }

        private void Absinthe_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
           

        }



        private void Absinthe_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            (sender as Image).Height = 133;
            (sender as Image).Width = 64;
            Storyboard3.Stop();
            Storyboard3.Children[0].SetValue(Storyboard.TargetNameProperty, (sender as Image).Name);
        }











       /*


        private void Absinthe_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Image source = null;
            Image dest = null;
            double top = 0;
            source = (sender as Image);

            top = e.ManipulationOrigin.Y;


            GeneralTransform objGeneralTransform = borda.TransformToVisual(Application.Current.RootVisual as UIElement);
            Point point = objGeneralTransform.Transform(new Point(0, 0));
            double myObjTop = point.Y;
            double myObjLeft = point.X;



            Rect rectDest = new Rect();




            rectDest.X = point.X;
            rectDest.Y = point.Y;
            rectDest.Width = 64;
            rectDest.Height = 133;


            BehaviorCollection behaviours = Interaction.GetBehaviors(sender as Image);

            if (behaviours.Count > 0 && behaviours[0] is MouseDragElementBehavior)
            {
                MouseDragElementBehavior dragBehaviour = behaviours[0] as MouseDragElementBehavior;

                Rect temp = new Rect(dragBehaviour.X, dragBehaviour.Y, (sender as Image).ActualWidth, (sender as Image).ActualHeight);

                temp.Intersect(rectDest);






                if (temp != Rect.Empty)
                {






                    if (temp.Height > 130 && temp.Width > 56)
                    {


                        temDrop = true;
                        Uri uri1 = new Uri("champanhe_00.png", UriKind.Relative);
                        ImageSource imgSource1 = new BitmapImage(uri1);
                        img_copo.Source = imgSource1;


                    }
                    else
                    {

                        (sender as Image).Height = 100;
                        (sender as Image).Width = 48;

                        img_copo.Source = null;

                    }

                    //Storyboard3.Begin();
                }
                else
                {
                    // Storyboard3.Stop();

                    (sender as Image).Height = 100;
                    (sender as Image).Width = 48;

                    img_copo.Source = null;
                }
            }
        }


        private Rect UserControlBounds(FrameworkElement element, double top)
        {
            return new Rect(element.Margin.Left, top, element.ActualWidth, element.ActualHeight);
        }

        private void Absinthe_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        */








        private void img_copo_MouseEnter(object sender, MouseEventArgs e)
        {



          /*  
            
            
            
            cliclou_copo = true;



            if (App.marca == "")
            {


                App.PassouMarca = true;
                NavigationService.Navigate(new Uri("/MostraMarcas.xaml", UriKind.RelativeOrAbsolute));
                return;

            }


            string ima = App.img.Replace(".png", "_00.png");
            Uri uri1 = new Uri(ima, UriKind.Relative);
            ImageSource imgSource1 = new BitmapImage(uri1);
            img_copo.Source = imgSource1;

            if (App.ListaBebidas[tagw].teor > 0)
            {

                alcool = alcool + (App.ListaBebidas[tagw].teor * App.ListaBebidas[tagw].dose_ml);
                t_shot.Text = String.Format("{0:0.00}", alcool) + " gr/L";
                
                if ((alcool > 0.5)  && (alcool < 0.79)) 
                {

                    eWarning.Text = "careful with alcohol in your blood!";
                    targetElement.Visibility = Visibility.Visible;
                    anima();

                }


                if (alcool > 0.5)
                {
                    slider1.Value = alcool;
                    
                }




            }

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 30);
            minhaconta = 0;
            dispatcherTimer.Start();


            */


        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {


            minhaconta = minhaconta + 1;


            if (minhaconta == 1)
            {
                string ima = App.img.Replace("_00.png", "_00.png");
                Uri uri1 = new Uri(ima, UriKind.Relative);
                ImageSource imgSource1 = new BitmapImage(uri1);
                img_copo.Source = imgSource1;
                //Thread.Sleep(1500);
            }



            if (minhaconta == 2)
            {
                string ima = App.img.Replace("_00.png", "_01.png");
                Uri uri2 = new Uri(ima, UriKind.Relative);
                ImageSource imgSource2 = new BitmapImage(uri2);
                img_copo.Source = imgSource2;
                //Thread.Sleep(1500);
            }





            if (minhaconta == 3)
            {
                string ima = App.img.Replace("_00.png", "_02.png");
                Uri uri3 = new Uri(ima, UriKind.Relative);
                ImageSource imgSource3 = new BitmapImage(uri3);
                img_copo.Source = imgSource3;

            }


            if (minhaconta == 4)
            {
                string ima = App.img.Replace("_00.png", "_03.png");
                Uri uri4 = new Uri(ima, UriKind.Relative);
                ImageSource imgSource4 = new BitmapImage(uri4);
                img_copo.Source = imgSource4;
                dispatcherTimer.Stop();
               


                if (App.ListaBebidas[tagw].teor == 0) 
                {
                    /*
                    Uri uri1 = new Uri("images/copo.wav", UriKind.Relative);
                    mediaElement1.Stop();
                    mediaElement1.Source = uri1;
                    */ 
                    copia_copo_esq();
                }
                else
                {
                copia_copo();
                }

            }











        }



        private void toca_sirene()
        {

       //     Uri uri1 = new Uri("images/sirene.mp3", UriKind.Relative);
       //     mediaElement1.Stop();
       //     mediaElement1.Source = uri1;
       //     mediaElement1.Position = TimeSpan.Zero;
       //     mediaElement1.Play();
        }





        private void toca_sino()
        {

        //    Uri uri1 = new Uri("images/copo.wav", UriKind.Relative);
       //   mediaElement1.Stop();
       //     mediaElement1.Source = uri1;
       //     mediaElement1.Position = TimeSpan.Zero;
       //     mediaElement1.Play();

        }



        private void origem_Copy4_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            (sender as Image).Height = 133;
            (sender as Image).Width = 64;
            Storyboard3.Stop();
            Storyboard3.Children[0].SetValue(Storyboard.TargetNameProperty, (sender as Image).Name);

            


        }






        private void origem_Copy4_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {



           



            GeneralTransform objGeneralTransform = borda.TransformToVisual(Application.Current.RootVisual as UIElement);
            System.Windows.Point point = objGeneralTransform.Transform(new System.Windows.Point(0, 0));
            double myObjTop = point.Y;
            double myObjLeft = point.X;



            Rect rectDest = new Rect();

            rectDest.X = point.X;
            rectDest.Y = point.Y;
            rectDest.Width = 64;
            rectDest.Height = 133;



           






             BehaviorCollection behaviours = Interaction.GetBehaviors(sender as Image);

             if (behaviours.Count > 0 && behaviours[0] is MouseDragElementBehavior)
             {
                 MouseDragElementBehavior dragBehaviour = behaviours[0] as MouseDragElementBehavior;



                
                 
                 
                 
                 
                 Rect temp = new Rect(dragBehaviour.X, dragBehaviour.Y, (sender as Image).ActualWidth, (sender as Image).ActualHeight);

                 
                 
                 
                 
                 
                 
                 temp.Intersect(rectDest);






                 if (temp != Rect.Empty)
                 {


                 



                     if ((dragBehaviour.X >= rectDest.X - 10) && (dragBehaviour.X <= rectDest.X - 10 + 32) && (dragBehaviour.Y <= rectDest.Y - 9) && (dragBehaviour.Y >= rectDest.Y - 33))
                     {

                         VibrateController vibrate = VibrateController.Default;
                         vibrate.Start(TimeSpan.FromMilliseconds(500));


                     }

                 }
             }
        }



        private void PoeCopo(int tagw)
        {











            App.bebida = App.ListaBebidas[Convert.ToInt32(tagw)].Nome;
            App.img = App.ListaBebidas[Convert.ToInt32(tagw)].img;
            App.dose = App.ListaBebidas[Convert.ToInt32(tagw)].dose_ml;
       //     App.ListaShot[0].bebida = App.bebida;
       //     App.ListaShot[0].ml = App.dose;
       //     App.ListaShot[0].tag = Convert.ToInt32(tagw);
         //   App.ListaShot[0].sangue = App.sangue;
            App.PassouMarca = true;
            NavigationService.Navigate(new Uri("/MostraMarcas.xaml", UriKind.RelativeOrAbsolute));

           





            string ima = App.img.Replace("_00.png", "_00.png");
            Uri uri1 = new Uri(ima, UriKind.Relative);
            ImageSource imgSource1 = new BitmapImage(uri1);
            img_copo.Source = imgSource1;
            borda.Visibility = Visibility.Collapsed;

            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
          //  ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true; 

           


        }



        
       



        private void origem_Copy4_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            

            //Thread.Sleep(5000);


            tagw = Convert.ToInt32((sender as Image).Tag);



            senderdrop = sender;




            //   MessageBox.Show("Deixou borda X: " + e.TotalManipulation.Translation.X.ToString()+"  Y:"+ e.TotalManipulation.Translation.Y.ToString());





            Image source = null;
            Image dest = null;
            double top = 0;


            // (sender as Image).Name;


            source = (sender as Image);
            //    dest = img_drop;







            //        SearchVisualTree(grid_mesa, source.Name);


            top = e.ManipulationOrigin.Y;


            GeneralTransform objGeneralTransform = borda.TransformToVisual(Application.Current.RootVisual as UIElement);
            System.Windows.Point point = objGeneralTransform.Transform(new System.Windows.Point(0, 0));
            double myObjTop = point.Y;
            double myObjLeft = point.X;



            Rect rectDest = new Rect();

            rectDest.X = point.X;
            rectDest.Y = point.Y;
            rectDest.Width = 64;
            rectDest.Height = 133;


            //(sender as Image).SetValue(Canvas.LeftProperty, point.X);
            //(sender as Image).SetValue(Canvas.TopProperty, point.Y);

           // (sender as Image).Margin = new Thickness(point.X, point.Y-350, 0, 0);


            // rectDest.X = 250;
            // rectDest.Y = 600;
            // rectDest.Height = 100;
            // rectDest.Width = 48;



            BehaviorCollection behaviours = Interaction.GetBehaviors(sender as Image);

            if (behaviours.Count > 0 && behaviours[0] is MouseDragElementBehavior)
            {
                MouseDragElementBehavior dragBehaviour = behaviours[0] as MouseDragElementBehavior;

                Rect temp = new Rect(dragBehaviour.X, dragBehaviour.Y, (sender as Image).ActualWidth, (sender as Image).ActualHeight);

                temp.Intersect(rectDest);





 










                if (temp != Rect.Empty)
                {



                    if ((dragBehaviour.X >= rectDest.X-50) && (dragBehaviour.X <= rectDest.X+46) &&  (dragBehaviour.Y >= rectDest.Y-100) && (dragBehaviour.Y <= rectDest.Y+50))


                    {


                        //(sender as Image).Margin = borda.Margin; 
                        
                        


                        temDrop = true;
                        PoeCopo(tagw);




                        if (App.ListaBebidas[tagw].teor == 0)
                        {
                            fila_e = 4;
                        }
                        else
                        {




                            if (alcool == 0)
                            {


                                    fila = 4;

                          
                            }

                        }
                       










                    }
                    else
                    {



                        tira_lousa();

                        //fila = 4;
                        temDrop = false;
               //         reta.Visibility = Visibility.Visible;
                        borda.Visibility = Visibility.Visible;
                        targetElement.Visibility = Visibility.Collapsed;
                        targetElement1.Visibility = Visibility.Collapsed;

               //         eTap.Visibility = Visibility.Visible;
               //         eTap2.Visibility = Visibility.Visible;



                        (sender as Image).Height = 100;
                        (sender as Image).Width = 48;




                        TranslateTransform myTranslate = new TranslateTransform();
                        myTranslate.Transform(pointarray[tagw]);
                        (sender as Image).RenderTransform = myTranslate;
                        (sender as Image).RenderTransform = new CompositeTransform();
                        Storyboard.SetTargetName(Storyboard3, "Tea");
                        Storyboard.SetTargetProperty(Storyboard3, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)"));

                        img_copo.Source = null;

                    }

                }
                else
                {


                    tira_lousa();
                   // fila = 4;

                    temDrop = false;
                //    reta.Visibility = Visibility.Visible;
                    borda.Visibility = Visibility.Visible;
                 //   eTap.Visibility = Visibility.Visible;
                //    eTap2.Visibility = Visibility.Visible;



                    (sender as Image).Height = 100;
                    (sender as Image).Width = 48;


                    TranslateTransform myTranslate = new TranslateTransform();
                    TransformGroup grupo = new TransformGroup();
                    myTranslate.Transform(pointarray[tagw]);
                    (sender as Image).RenderTransform = myTranslate;


                    //  (sender as Image).RenderTransform.Transform(pointarray[tagw]);  

                    (sender as Image).RenderTransform = new CompositeTransform();
                    Storyboard.SetTargetName(Storyboard3, "Tea");
                    Storyboard.SetTargetProperty(Storyboard3, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)"));



                    img_copo.Source = null;
                }
            }
        }


        private Rect UserControlBounds(FrameworkElement element, double top)
        {
            return new Rect(element.Margin.Left, top, element.ActualWidth, element.ActualHeight);
        }









       


















        private void copia_copo()
        {

            conta_copo = conta_copo + 1;


            if (conta_copo == 13)
            {
                conta_copo = 1;
                Limpar_Click(null, null);


                try
                {
                    YouTube.Play(App.LocFilme);
                }
                catch
                {

                }


                return;
            }





            if (conta_copo == 12)
            {
                //conta_copo = 1;
                anima2();
                //Limpar_Click(null, null);
                tap_spin(null, null);
                return;
            }



           

            if (fila == 0)
            {

                if (App.Conf[0].AVISO == true)
                {
                //    eWarning.Text = "Call a Taxi!";
               //     targetElement.Visibility = Visibility.Visible;
                    anima();
                    anima2();
                }     





                return;
            }




            vezes = vezes + 1;



            if (vezes > fila)
            {

                
                
                
                contaleft = (contaleft - ((vezes - 1) * 45)) + 20; ;
                vezes = 1;
                contatop = contatop - 45;
                fila = fila - 1;




                if (fila == 0) 
                {

             
                        img_taxi.Visibility = Visibility.Visible;
                        anima();
                        anima2();
            //            Limpar_Click(null, null);
                   
                   

                    return;


                }




             










            }


            contaleft = contaleft + 45;
            Image newImage = new Image();
            newImage.Height = 44;
            newImage.Width = 44;
            newImage.Source = img_copo.Source;
            newImage.Margin = new Thickness(contaleft, contatop, 10, 10);
            newImage.Tag = 999;
            ContentPanel.Children.Add(newImage);



        }




        private void copia_copo_esq()
        {


            if (fila_e == 0)
            {

                //MessageBox.Show("Please go to bathdromm!");
                return;


            }




            vezes_e = vezes_e + 1;



            if (vezes_e > fila_e)
            {

                contaleft_e = (contaleft_e - ((vezes_e - 1) * 45)) + 20; ;
                vezes_e = 1;
                contatop_e = contatop_e - 45;

                fila_e = fila_e - 1;

                if (fila_e == 0)
                {

                   // MessageBox.Show("Please go to bathdromm!");
                    return;


                }




            }


            contaleft_e = contaleft_e + 45;
            Image newImage = new Image();
            newImage.Height = 44;
            newImage.Width = 44;
            newImage.Source = img_copo.Source;
            newImage.Margin = new Thickness(contaleft_e, contatop_e, 10, 10);
            newImage.Tag = 999;
            ContentPanel.Children.Add(newImage);



        }





















        private void pega_pontos()
        {

            pointarray.Clear();

            for (int i = 0; i < 22; i++)
            {
                pointarray.Add(new System.Windows.Point { X = 0, Y = 0 });
                tickarray.Add(new Thickness { Left = 0, Top = 0, Right = 0, Bottom = 0 });
            }
            int tagx = 0;

            foreach (UIElement item in ContentPanel.Children)
            {
                Image teste = item as Image;

                if (teste != null)
                {
                    tagx = Convert.ToInt32(teste.Tag.ToString());
                    if (tagx < 22)
                    {
                        GeneralTransform objGeneralTransform = item.TransformToVisual(Application.Current.RootVisual as UIElement);
                        System.Windows.Point point = objGeneralTransform.Transform(new System.Windows.Point(0, 0));
                        pointarray[tagx] = point;
                        tickarray[tagx] = teste.Margin;
                    }
                }
            }
        }

        private void borda_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void borda_LostMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void borda_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void borda_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void grid_garrafa_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

        }

        private void origem_Copy4_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Absinthe_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
           // MessageBox.Show("Passou");
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Limpar_Click(object sender, EventArgs e)
        {

      //      mediaElement2.Stop();
      //      mediaElement2.Visibility = Visibility.Collapsed;

          //  Uri uri1 = new Uri("images/copo.wav", UriKind.Relative);
          //  mediaElement1.Stop();
          //  mediaElement1.Source = uri1;


       //     eWarning1.Text = "";

        //    img_taxi.Visibility = Visibility.Collapsed;


         //   tira_lousa();

         contaleft = 140;
         contatop = 550;
         vezes = 0;

         if ((App.bebida == "Beer") || (App.bebida == "Champagne") || (App.bebida == "Cocktails") || (App.bebida == "Liqueur") || (App.bebida == "Sake") || (App.bebida == "Wine"))                          

        
        {
            fila = 4;

        } else
        {
            fila = 4;
        }

        


         contaleft_e = -350;
         contatop_e = 550;
         vezes_e = 0;
         fila_e = 4;

         alcool = 0;
      //   slider1.Value = 0;
     //    t_shot.Text = "0";

       //  eTapMens.Text = "";

            for (int index = ContentPanel.Children.Count - 1; index >= 0; index--)
            {




                if (ContentPanel.Children[index] is Image)
                {

                    Image teste = ContentPanel.Children[index] as Image;
                    if (teste.Tag.ToString() == "999")
                    {

                        ContentPanel.Children.RemoveAt(index);

                    }
                    

                }

            }






            



        }

        private void mediaElement1_MediaEnded(object sender, RoutedEventArgs e)
        {
           // mediaElement1.Visibility = Visibility.Collapsed;
        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            //Canvas.SetZIndex(mediaElement1, 0);

           // mediaElement1.BringToFront();

        }





      







        private void img_copo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {



            targetElement.Visibility = Visibility.Collapsed;
            targetElement1.Visibility = Visibility.Collapsed;


            if (dispatcherTimer.IsEnabled) { return; }



            captura_imagem();



            /*
            
            if ((alcool >= 0.38)   &&   (fila <= 1)  && (App.ListaBebidas[tagw].teor > 0))
            {
                
                
                
                
                if (App.Conf[0].AVISO == true)
                {

                    if (App.Conf[0].NET == true)
                    {
                        
                        //mediaElement2.Stop();


                        if (MyToolkit.Networking.NetworkStateTracker.IsWiFiConnected == true)
                        {
                            if (App.LocFilme != null)
                            {


                                try
                                {
                                    YouTube.Play(App.LocFilme);
                                }
                                catch
                                {
                                    mostra_anima();
                                }
                            }
                            else
                            {
                                mostra_anima();
                            }



                        }
                        else
                        {
                            mostra_anima();
                        }


                    }
                    else
                    {


                        mostra_anima();
                         
                    }
                }
                return;
            }

            */

            if ((fila == 0) && (App.ListaBebidas[tagw].teor == 0))
            {
                
                return;
            }




          
            if (Convert.ToInt32((sender as Image).Tag) > 0)
            {


                playsound1("images/copo.mp3");


               // this.mediaElement1.Stop();
               // this.mediaElement1.Position = TimeSpan.Zero;
               // this.mediaElement1.Play();
                

                /*
                Stream stream = TitleContainer.OpenStream("images/copo.mp3");
                SoundEffect effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
                */



            }

             

            cliclou_copo = true;



            if ((App.marca == null) || (App.marca == ""))
            {


                App.PassouMarca = true;
                NavigationService.Navigate(new Uri("/MostraMarcas.xaml", UriKind.RelativeOrAbsolute));

                ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            //    ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true; 
                return;

            }


            string ima = App.img.Replace("_00.png", "_00.png");
            Uri uri1 = new Uri(ima, UriKind.Relative);
            ImageSource imgSource1 = new BitmapImage(uri1);
            img_copo.Source = imgSource1;






            /*

                App.SomaShots(App.LocID, App.LocName, App.bebida, App.marca, App.dose, tagw);
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 30);
                minhaconta = 0;
                dispatcherTimer.Start();
            */
                soma_shot();

                targetElement.Visibility = Visibility.Collapsed;
                targetElement1.Visibility = Visibility.Collapsed ;



                Uri uri8; 
                 
                if (App.bebida == "Cachaca")
                {
                    uri8 = new Uri("http://www.abreuretto.com/socialdrink/cachaca_01_en_US.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "pt")
                    uri8 = new Uri("http://www.abreuretto.com/socialdrink/cachaca_01_pt_BR.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "es")
                    uri8 = new Uri("http://www.abreuretto.com/socialdrink/cachaca_01_es_ES.png", UriKind.RelativeOrAbsolute);                 
                    ImageSource imgSource8 = new BitmapImage(uri8);
                    imgfoto.Source = imgSource8;
                }



             if (App.bebida == "Whisky")
                {
                    uri8 = new Uri("http://www.abreuretto.com/socialdrink/whisky_01_en_US.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "pt")
                        uri8 = new Uri("http://www.abreuretto.com/socialdrink/whisky_01_pt_BR.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "es")
                        uri8 = new Uri("http://www.abreuretto.com/socialdrink/whisky_01_es_ES.png", UriKind.RelativeOrAbsolute);                 
                    ImageSource imgSource8 = new BitmapImage(uri8);
                    imgfoto.Source = imgSource8;
                }

             if (App.bebida == "Beer")
                {
                    uri8 = new Uri("http://www.abreuretto.com/socialdrink/beer_01_en_US.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "pt")
                        uri8 = new Uri("http://www.abreuretto.com/socialdrink/beer_01_pt_BR.png", UriKind.RelativeOrAbsolute);
                    if (App.Conf[0].Idioma.Substring(0,2) == "es")
                        uri8 = new Uri("http://www.abreuretto.com/socialdrink/beer_01_es_ES.png", UriKind.RelativeOrAbsolute);                 
                    ImageSource imgSource8 = new BitmapImage(uri8);
                    imgfoto.Source = imgSource8;
                }


             if (App.bebida == "Vodka")
             {
                 uri8 = new Uri("http://www.abreuretto.com/socialdrink/vodka_01_en_US.png", UriKind.RelativeOrAbsolute);
                 if (App.Conf[0].Idioma.Substring(0, 2) == "pt")
                     uri8 = new Uri("http://www.abreuretto.com/socialdrink/vodka_01_pt_BR.png", UriKind.RelativeOrAbsolute);
                 if (App.Conf[0].Idioma.Substring(0, 2) == "es")
                     uri8 = new Uri("http://www.abreuretto.com/socialdrink/vodka_01_es_ES.png", UriKind.RelativeOrAbsolute);
                 ImageSource imgSource8 = new BitmapImage(uri8);
                 imgfoto.Source = imgSource8;
             }


             if (App.bebida == "Wine")
             {
                 uri8 = new Uri("http://www.abreuretto.com/socialdrink/wine_01_en_US.png", UriKind.RelativeOrAbsolute);
                 if (App.Conf[0].Idioma.Substring(0, 2) == "pt")
                     uri8 = new Uri("http://www.abreuretto.com/socialdrink/wine_01_pt_BR.png", UriKind.RelativeOrAbsolute);
                 if (App.Conf[0].Idioma.Substring(0, 2) == "es")
                     uri8 = new Uri("http://www.abreuretto.com/socialdrink/wine_01_es_ES.png", UriKind.RelativeOrAbsolute);
                 ImageSource imgSource8 = new BitmapImage(uri8);
                 imgfoto.Source = imgSource8;
             }



                if (App.ListaBebidas[tagw].teor > 0)
                {


                    if ((alcool > 0.4) && (fila == 0)) { return; }


                    alcool = alcool + App.ListaBebidas[tagw].teor;
                    //       t_shot.Text = String.Format("{0:0.000}", alcool) + " gr/dL";


                    string idiomax = App.Conf[0].Idioma; 
                    if (App.Conf[0].Idioma == "pt-PT")
                    {
                    
                        idiomax = "pt-BR";
                    }
                       
                       



                    List<App.Frases> fra = new List<App.Frases>();
                    fra = App.ListaFrases;
                    var resu = (from x in fra
                                where x.idioma == idiomax
                                orderby x.valini ascending
                                select x).ToList();

                    List<App.Frases> resu1 = new List<App.Frases>();

                    if (resu == null)
                    {
                        resu1 = (from x in fra
                                 where x.idioma == "default"
                                 orderby x.valini ascending
                                 select x).ToList();


                    }
                    else
                    {
                        resu1 = (from x in fra
                                 where x.idioma == idiomax
                                 orderby x.valini ascending
                                 select x).ToList();

                    }




                    foreach (App.Frases x in resu1)
                    {

                        if ((alcool > x.valini) && (alcool <= x.valfim))
                        {
                            targetElement.Visibility = Visibility.Visible;
                            targetElement1.Visibility = Visibility.Visible;

                            eWarning.Text = x.texto;
                            eWarning1.Text = Localization.eSangue +" "+ (alcool * 1000).ToString() + " mg/dl"; 


                        }

                    }


                    foreach (App.Frases x in resu1)
                    {

                        if ((alcool > x.valini) && (alcool <= x.valfim) && (App.bebida == x.bebida))
                        {
                            targetElement.Visibility = Visibility.Visible;
                            targetElement1.Visibility = Visibility.Visible;

                            eWarning.Text = x.texto;

                            eWarning1.Text = Localization.eSangue + " " + (alcool * 1000).ToString() + " mg/dl";  

                        }

                    }

                    foreach (App.Frases x in resu1)
                    {

                        if ((alcool > x.valini) && (alcool <= x.valfim) && (App.bebida == x.bebida) && ((App.marca == x.marca)))
                        {
                            targetElement.Visibility = Visibility.Visible;
                            targetElement1.Visibility = Visibility.Visible;

                            eWarning.Text = x.texto;
                            eWarning1.Text = Localization.eSangue + " " + (alcool * 1000).ToString() + " mg/dl";  

                        }

                    }


                }






                if (targetElement.Visibility != Visibility.Visible)
                {
                    
                    imgfoto.Visibility = Visibility.Visible;
                    

                }
                else
                {
                    imgfoto.Visibility = Visibility.Collapsed;
                }









                                /*


                                 if ((alcool > 0.019) && (alcool <= 0.04))
                                 {

                                     eWarning1.Text = "warm and relaxed";
                    
                                 }

                                 if ((alcool > 0.04) && (alcool <= 0.09))
                                 {

                                     if (eWarning1.Text != "lack of coordination and balance (legally drunk)")
                                     {
                                         img_taxi.Visibility = Visibility.Visible;
                                         eWarning.Text = "Please, do not drive! Call a Taxi!";
                                        // targetElement.Visibility = Visibility.Visible;
                                         anima();
                                         anima2();

                                     }


                                     eWarning1.Text = "lack of coordination and balance (legally drunk)";


                     
                                 }


                                 if ((alcool > 0.09) && (alcool <= 0.14))
                                 {

                                     eWarning1.Text = "possible blackout (memory loss)";
                     
                                 }

                                 if ((alcool > 0.14) && (alcool <= 0.19))
                                 {

                                     eWarning1.Text = "You feel confused, dazed, or otherwise disoriented";
                     
                                 }

                                 if ((alcool > 0.19) && (alcool <= 0.24))
                                 {



                                     if (eWarning1.Text != "emotionally and physically numb")
                                     {
                                         img_taxi.Visibility = Visibility.Visible;
                                         eWarning.Text = "Please, do not drive! Call a Taxi!";
                                      //   targetElement.Visibility = Visibility.Visible;
                                         anima();
                                         anima2();
                                     }


                                     eWarning1.Text = "emotionally and physically numb";
                     
                                 }

                                 if ((alcool > 0.24) && (alcool <= 0.29))
                                 {

                                     eWarning1.Text = "in a drunken stupor";
                     
                                 }

                                 if ((alcool > 0.29) && (alcool <= 0.34))
                                 {


                                     if (eWarning1.Text != "You are probably in a coma")
                                     {
                                         img_taxi.Visibility = Visibility.Visible;
                                         eWarning.Text = "Please, do not drive! Call a Taxi!";
                                     //    targetElement.Visibility = Visibility.Visible;
                                         anima();
                                         anima2();
                                     }


                                     eWarning1.Text = "You are probably in a coma";
                     
                                 }

                                 if (alcool > 0.34)
                                 {

                                     eWarning1.Text = "it's a miracle if you're not dead.";

                                 }



                                if ((alcool > 0.04) && (alcool < 0.05))
                                {

                                    eWarning.Text = "careful with alcohol in your blood!";
                                 //   targetElement.Visibility = Visibility.Visible;
                                    anima();

                                }



                




                                if (alcool > 0.04)
                                {
                                //    slider1.Value = alcool;

                                }




                            }

                            */



               




        }



        private void mostra_anima()
        {

         //   img_frase.Visibility = Visibility.Collapsed;
            //mediaElement5.AutoPlay = true;
           // mediaElement5.Visibility = Visibility.Visible;
         //   mediaElement5.Play();
            
            
            
            


          //  mediaElement2.Stop();
         //   mediaElement2.Position = TimeSpan.Zero;
         //   mediaElement2.Play();
         //   mediaElement2.Visibility = Visibility.Visible;
        }




        private void soma_shot()
        {
            App.SomaShots(App.LocID, App.LocName, App.bebida, App.marca, App.dose, tagw);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 30);
            minhaconta = 0;
            dispatcherTimer.Start();
        }






        private void image1_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {


            if (App.Conf[0].NET == false)
            {

                MessageBox.Show(Localization.m85.ToString());
                return;

            }


            NavigationService.Navigate(new Uri("/MostraTaxi.xaml", UriKind.RelativeOrAbsolute));



        }
































        private void anima()
        {

            return;


            /*

            if (App.Conf[0].AVISO == false) { return; }
           


            RadScaleAnimation scaleAnimation = this.LayoutRoot.Resources["radScaleAnimation"] as RadScaleAnimation;

            RadAnimationManager.StopIfRunning(this.targetElement, scaleAnimation);

            scaleAnimation.StartScaleX = 1;
            scaleAnimation.EndScaleX = 2;
            scaleAnimation.StartScaleY = 1;
            scaleAnimation.EndScaleY = 2;


            if (this.targetElement != null)
            {
                RadAnimationManager.Play(this.targetElement, scaleAnimation, () =>
                {
                    this.targetElement.Visibility = Visibility.Collapsed;
                    
                });
            }
            */

        }


          private void anima2()
        {

 


            RadMoveAnimation animation = this.LayoutRoot.Resources["radMoveAnimation"] as RadMoveAnimation;
            System.Windows.Point endPoint = new System.Windows.Point();
            endPoint.X = -200;
            endPoint.Y = 215;
            animation.EndPoint = endPoint;            
            RadAnimationManager.Play(this.img_taxi, animation);
 

           





              

        }




        private void poe_lousa(int tagfica)
          {










            string tagf = tagfica.ToString();
            string[] tira = new string[] { "8", "10", "4", "5", "3", "0", "2", "13", "12", "6", "15","18","19","20","21" };
            string[] tira_T = new string[] { "40", "41", "42", "43", "44", "35", "36", "37", "38", "39","30","31","32","33","34" };



       //     Slot.Visibility = Visibility.Visible;
       //     grid_garrafa.Visibility = Visibility.Collapsed;

            img_lousa.Visibility = Visibility.Visible;
            eSel.Visibility = Visibility.Visible;
            barra.Visibility = Visibility.Visible;
            list1.Visibility = Visibility.Visible;
            list2.Visibility = Visibility.Visible;
            list3.Visibility = Visibility.Visible;

        //    t_shot.Visibility = Visibility.Visible;
            img_som.Visibility = Visibility.Visible;
          //  eSangue.Visibility = Visibility.Visible;
         //   slider1.Visibility = Visibility.Visible;
          //  eWarning1.Visibility = Visibility.Visible;
       //     eTapMens.Text = Localization.m88;
            eDrop.Visibility = Visibility.Collapsed;


               foreach (UIElement item in ContentPanel.Children)
                {
                    TextBlock texto = item as TextBlock;

                    if (texto != null)
                    {

                        if (texto.Tag != null)
                        {

                            if (tira_T.Contains(texto.Tag.ToString()))
                            {
                                texto.Visibility = Visibility.Collapsed;
                            }

                        }
                    }




                   Image img = item as Image;
                    if (img != null)
                    {
                         if (tira.Contains(img.Tag.ToString())) 

                        {
                            if (img.Tag.ToString() != tagf)
                            {
                                img.Visibility = Visibility.Collapsed;
                            }
                        }
                    }



               }


               targetElement.Visibility = Visibility.Visible;
               eWarning.Text = Localization.ms132;
               eWarning.Visibility = Visibility.Visible;
              // dt.Interval = TimeSpan.FromSeconds(5);
              // dt.Start();

               


          }


        private void tira_lousa()
        {

            string[] tira = new string[] { "8", "10", "4", "5", "3", "0", "2", "13", "12", "6", "15", "18", "19", "20", "21" };
            string[] tira_T = new string[] { "40", "41", "42", "43", "44", "35", "36", "37", "38", "39", "30", "31", "32", "33", "34" };

            img_lousa.Visibility = Visibility.Collapsed;
            img_som.Visibility = Visibility.Collapsed;
            img_som.Visibility = Visibility.Collapsed;
            barra.Visibility = Visibility.Collapsed;
            list1.Visibility = Visibility.Collapsed;
            list2.Visibility = Visibility.Collapsed;
            list3.Visibility = Visibility.Collapsed;
            targetElement.Visibility = Visibility.Collapsed;
            targetElement1.Visibility = Visibility.Collapsed;



       //     Slot.Visibility = Visibility.Collapsed;
       //     grid_garrafa.Visibility = Visibility.Visible;
            
            eSel.Visibility = Visibility.Collapsed;
        //    t_shot.Visibility = Visibility.Collapsed;
        //    eSangue.Visibility = Visibility.Collapsed;
        //    slider1.Visibility = Visibility.Collapsed;
        //    eWarning1.Visibility = Visibility.Collapsed;
            eDrop.Visibility = Visibility.Visible;
      //      mediaElement2.Visibility = Visibility.Collapsed;
       //   mediaElement2.Stop();
        //    eTapMens.Text = "";

            foreach (UIElement item in ContentPanel.Children)
            {
                TextBlock texto = item as TextBlock;

                if (texto != null)
                {
                    if (texto.Tag != null)
                    {

                        if (tira_T.Contains(texto.Tag.ToString()))
                        {
                            texto.Visibility = Visibility.Visible;
                        }
                    }
                }

                Image img = item as Image;
                if (img != null)
                {
                    if (tira.Contains(img.Tag.ToString()))
                    {
                        img.Visibility = Visibility.Visible;
                    }
                }



            }
        }





        private void slider1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //anima();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void Captura_Click(object sender, EventArgs e)
        {

           /*


            WriteableBitmap bmp = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
            bmp.Render(this, null);
            bmp.Invalidate();
            this.image1.Source = bmp;
            App.ImgTela = new Image();
            App.ImgTela.Source = this.image1.Source;           
            String tempJPEG = "tela01.jpg";
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }
                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(tempJPEG);

                 System.Windows.Media.Imaging.Extensions.SaveJpeg(bmp, fileStream, bmp.PixelWidth, bmp.PixelHeight, 0, 85);


                 using (MemoryStream stream = new MemoryStream())
                 {
                     WriteableBitmap writableBitmap = new WriteableBitmap(bmp);
                     System.Windows.Media.Imaging.Extensions.SaveJpeg(writableBitmap, stream, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                     App.byteArray0 = stream.ToArray();
                 }
                
                fileStream.Close();
            }


           




            

            //NavigationService.Navigate(new Uri("/Mostra_Foto_Tela.xaml", UriKind.RelativeOrAbsolute));
           


            
            
            
            //Set a new background
            
            /*
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(NextImage, UriKind.Relative));
            ContentGrid.Background = brush;
            */


        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }

        private void Promocao_click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/Mostra_Promotion.xaml", UriKind.RelativeOrAbsolute));

            
        }

        private void info_click(object sender, EventArgs e)
        {

           // NavigationService.Navigate(new Uri("/Mostra_Info.xaml", UriKind.RelativeOrAbsolute));
            

        }


        private void captura_imagem()
        {


            if (App.LinkFoto != null)
            {
             
                
                    return;
                
                
                
                
            }



            if (mandou_foto == true)
            {
                return;

            }



            mandou_foto = true;



            WriteableBitmap bmp = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
            bmp.Render(this, null);
            bmp.Invalidate();
            this.image1.Source = bmp;
            App.ImgTela = new Image();
            App.ImgTela.Source = this.image1.Source;
            String tempJPEG = "tela01.jpg";
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(tempJPEG))
                {
                    myIsolatedStorage.DeleteFile(tempJPEG);
                }
                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(tempJPEG);

                System.Windows.Media.Imaging.Extensions.SaveJpeg(bmp, fileStream, bmp.PixelWidth, bmp.PixelHeight, 0, 85);


                using (MemoryStream stream = new MemoryStream())
                {
                    WriteableBitmap writableBitmap = new WriteableBitmap(bmp);
                    System.Windows.Media.Imaging.Extensions.SaveJpeg(writableBitmap, stream, bmp.PixelWidth, bmp.PixelHeight, 0, 100);
                    App.byteArray0 = stream.ToArray();
                }

                fileStream.Close();


                backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync();




            }

        }







        private void checkin_Click(object sender, EventArgs e)
        {


            











            latx = App.LocLat.ToString();
            lonx = App.LocLon.ToString();
            laty = latx.Replace(",", ".");
            lony = lonx.Replace(",", ".");
            
            
            string a1 = "<a href=\"";
            string a2 = "http://dev.virtualearth.net/embeddedMap/v1/ajax/aerial?zoomLevel=17&center=";
            string a3 = laty + "_" + lony + "&pushpins=" + laty + "_" + lony;
            string a4 = "\"";
            string a5 = ">Link do mapa</a>";


           // App.FBUrl = a1+a2+a3+a4+a5;
            
            
            App.FBUrl = "http://dev.virtualearth.net/embeddedMap/v1/ajax/aerial?zoomLevel=17&center=" + laty + "_" + lony + "&pushpins=" + laty + "_" + lony;
            App.FBMens = "";
            App.NaoSoma = true;
           
            
           // <a href="http://tinyurl.com/abreuretto" >Open in new window</a>
            
            
            
            NavigationService.Navigate(new Uri("/Messages_Main.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void mediaElement2_MediaEnded(object sender, RoutedEventArgs e)
        {
            
          //  mediaElement2.Position = TimeSpan.Zero;
          //  mediaElement2.Play();
             
        }

        private void mediaElement2_MediaOpened(object sender, RoutedEventArgs e)
        {
           // mediaElement2.Stop();
        }

        private void tap_som(object sender, System.Windows.Input.GestureEventArgs e)
        {



            try
            {



                flipSlot = !flipSlot;


                if (flipSlot == false)
                {

                    Uri uri2 = new Uri("/images/som_off.png", UriKind.Relative);
                    ImageSource imgSource3 = new BitmapImage(uri2);
                    img_som.Source = imgSource3;

                }
                else
                {

                    Uri uri2 = new Uri("/images/som_on.png", UriKind.Relative);
                    ImageSource imgSource3 = new BitmapImage(uri2);
                    img_som.Source = imgSource3;


                }


            }
            catch
            {

            }



        }

        private void list2_ScrollCompleted(object sender, Telerik.Windows.Controls.LoopingList.LoopingListScrollEventArgs e)
        {

        }

        private void list1_ScrollCompleted(object sender, Telerik.Windows.Controls.LoopingList.LoopingListScrollEventArgs e)
        {

        }

        private void list3_ScrollCompleted(object sender, Telerik.Windows.Controls.LoopingList.LoopingListScrollEventArgs e)
        {

        }

        private void tap_spin(object sender, System.Windows.Input.GestureEventArgs e)
        {




            try
            {



                targetElement.Visibility = Visibility.Collapsed;
                targetElement1.Visibility = Visibility.Collapsed;
                imgfoto.Visibility = Visibility.Collapsed;




                if (completou == false)
                {
                    completa = completa + 1;
                    if (completa < 10)
                    {
                        return;
                    }

                    else
                    {
                        completa = 0;
                    }

                }
                else
                {
                    completa = 0;
                }



                for (int i = 0; i <= 22; i++)
                {
                    lista[i] = 0;
                }

                if (flipSlot == true)
                {

                    PlaySound("images/inicio.wav");
                    //mediaElement15.Play();
                }

                dura = 0;
                tGanha.Text = Localization.ms107;
                spins = spins + 1;
                tPontos.Text = pontosSlot.ToString();
                tSpins.Text = spins.ToString();

                Uri uri = new Uri("/images/MACHINE3.png", UriKind.Relative);
                ImageSource imgSource2 = new BitmapImage(uri);
                img_lousa.Source = imgSource2;


                completou = false;



                this.ScrollList(this.list1);
                this.ScrollList(this.list2);
                this.ScrollList(this.list3);

            }
            catch
            {

            }







        }


        private void OpenDirectionTo()
        {

           GeoCoordinate mapCenter = new GeoCoordinate(Convert.ToDouble(App.LocLat, CultureInfo.InvariantCulture), Convert.ToDouble(App.LocLon, CultureInfo.InvariantCulture));
            BingMapsDirectionsTask directionTask = new BingMapsDirectionsTask();
            directionTask.Start = new LabeledMapLocation("You", App.LocCel);
            directionTask.End = new LabeledMapLocation(App.LocName+" "+App.LocAddress, mapCenter);
            directionTask.Show();
        }



        private void local_click(object sender, EventArgs e)
        {
            if (App.Conf[0].NET == false)
            {

                MessageBox.Show(Localization.m85.ToString());
                return;

            }


           // OpenDirectionTo();




            if (App.quem == 1)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetail.xaml", UriKind.RelativeOrAbsolute));
            }

            if (App.quem == 2)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetailGoogle.xaml", UriKind.RelativeOrAbsolute));
            }

            if (App.quem == 3)
            {
                this.NavigationService.Navigate(new Uri("/LocalDetailNokia.xaml", UriKind.RelativeOrAbsolute));
            }








         //   this.NavigationService.Navigate(new Uri("/mapa_ende.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tap_img_frase(object sender, System.Windows.Input.GestureEventArgs e)
        {
      //      mediaElement1.Stop();
      //      mediaElement2.Stop();
       //     mediaElement3.Stop();
      //      mediaElement4.Stop();
      //      mediaElement5.Stop();
    //        mediaElement15.Stop();
            
            mostra_anima();
        }

        private void mediaElement5_MediaEnded(object sender, RoutedEventArgs e)
        {

      //      img_frase.Visibility = Visibility.Collapsed;
           

        }

       

      



/*
    
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerS = new DispatcherTimer();

        

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hold = true;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);//days,hours,minutes,seconds,milliseconds
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
       
        void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (hold == true)
            {
                image2_Tap(sender, null);
            }
        }

        private void image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
     
        {
            hold = false;
        }

        private void img_sub_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            holdS = true;
            timerS.Interval = new TimeSpan(0, 0, 0, 0, 50);//days,hours,minutes,seconds,milliseconds
            timerS.Tick += new EventHandler(timer_tick_sub);
            timerS.Start();
        }
        void timer_tick_sub(object sender, EventArgs e)
        {
            timerS.Stop();
            if (holdS == true)
            {
                image3_Tap(sender, null);
            }
        }

        private void img_sub_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            holdS = false;
        }


        */







    }
}