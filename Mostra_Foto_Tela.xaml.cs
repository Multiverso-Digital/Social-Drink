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
using System.IO.IsolatedStorage;
//using Newtonsoft.Json.Schema;
//using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Phone.Tasks;
//using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Shell;




namespace Social_Drink
{
    public partial class Mostra_Foto_Tela : PhoneApplicationPage
    {
        public Mostra_Foto_Tela()
        {
            InitializeComponent();
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_save.ToString();
            image1.Source = App.ImgTela.Source;


        }

        private void Save_Button(object sender, EventArgs e)
        {

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("tela01.jpg", FileMode.Open, FileAccess.Read)) 
                { 
                    MediaLibrary mediaLibrary = new MediaLibrary(); 
                    Picture pic = mediaLibrary.SavePicture("tela0101.jpg", fileStream); 
                    fileStream.Close(); 
                } 
            } 

            PhotoChooserTask photoChooserTask = new PhotoChooserTask(); 
            photoChooserTask.Show();

        }
    }
}