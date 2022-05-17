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
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;

namespace Social_Drink
{
    public partial class Mostra_Promotion : PhoneApplicationPage
    {

        private readonly DispatcherTimer _timer;
        private readonly ObservableCollection<string> _matches;

        private PhotoCameraLuminanceSource _luminance;
        private QRCodeReader _reader;
        private PhotoCamera _photoCamera;
        


        public Mostra_Promotion()
        {
            InitializeComponent();

            _matches = new ObservableCollection<string>();
            _matchesList.ItemsSource = _matches;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (o, arg) => ScanPreviewBuffer();


        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            _photoCamera = new PhotoCamera();
            _photoCamera.Initialized += OnPhotoCameraInitialized;
            _previewVideo.SetSource(_photoCamera);
            CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();
            base.OnNavigatedTo(e);

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _timer.Stop();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        
        {
            _timer.Stop();
            _photoCamera.Dispose();
        }




        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {


            try
            {

                int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
                int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);

                _luminance = new PhotoCameraLuminanceSource(width, height);
                _reader = new QRCodeReader();

                Dispatcher.BeginInvoke(() =>
                {
                    _previewTransform.Rotation = _photoCamera.Orientation;
                    _timer.Start();
                });

            }
            catch
            {

            }



        }

        private void ScanPreviewBuffer()
        {
            try
            {
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = _reader.decode(binBitmap);
                Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
            }
            catch
            {
            }
        }

        private void DisplayResult(string text)
        {
            if (!_matches.Contains(text))
            {
                _matches.Add(text);
                MessageBox.Show(Localization.ms110);
                _timer.Stop();
                _photoCamera.Dispose();
                _previewRect.Visibility = Visibility.Collapsed;
                save_click(null, null);

            }
        }

        private void save_click(object sender, EventArgs e)
        {

            string linha1 = "";
            string linha2 = "";
            string linha3 = "";
            string linha4 = "";

            if (_matches.Count == 0)
            {
                MessageBox.Show("Wrong QR Code!");
                return;
            }

            string strData = _matches[0].ToString();
            char[] separator = new char[] { '\n'};
            string[] strSplitArr = strData.Split(separator);

          
            MessageBox.Show(Localization.ms111);
           // _matchesList.Items.Add("This code is not a Social Drink QR Code!");
            return;
            

            linha1 = strSplitArr[0].ToString();
            linha2 = strSplitArr[1].ToString();
            linha3 = strSplitArr[2].ToString();
            linha4 = strSplitArr[3].ToString();








            App.QRPromocao.Add(new App.qrpromocao() { datahoje = DateTime.Today.ToString("MM/dd/yyyy"), local = App.LocName, latitude = App.LocLat, longitude = App.LocLon, qr_linha01 = linha1, qr_linha02 = linha2, qr_linha03 = linha3, qr_linha04 = linha4, horahoje = DateTime.Today.ToString("HH:MM:SS"), ganhou=0 });



            MessageBox.Show("The code will be sent to our server to check the validity. You will be notified by email if winning the points specified in the code. If points are valid they will be added to your account.");

            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();

            }

        }

        private void info_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mostra_Info_Promo.xaml", UriKind.RelativeOrAbsolute));
        }





    }
}