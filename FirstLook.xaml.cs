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
using System.Windows.Resources;
using System.IO;
using System.Globalization;
using System.Text;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Telerik.Examples.WP.SlideView
{
    public partial class FirstLook : UserControl
    {
        private List<ViewModel> itemsSource = new List<ViewModel>(7);
        private DispatcherTimer playTimer;

        public FirstLook()
        {
            InitializeComponent();

            this.playTimer = new DispatcherTimer();
            this.playTimer.Interval = TimeSpan.FromSeconds(2);
            this.playTimer.Tick += this.OnPlayTimerTick;

            this.LoadData();
            this.slideView.DataContext = this.itemsSource;

            this.Unloaded += this.OnUnloaded;
        }

        private void OnPlayTimerTick(object sender, EventArgs e)
        {
            this.slideView.MoveToNextItem();
        }

        private void LoadData()
        {
            StreamResourceInfo resource = Application.GetResourceStream(new Uri("SlideView/FirstLookData.txt", UriKind.RelativeOrAbsolute));
            using (StreamReader reader = new StreamReader(resource.Stream))
            {
                string line = string.Empty;
                int index = 1;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');
                    ViewModel model = new ViewModel();
                    model.Image = new Uri("Images/" + values[0], UriKind.RelativeOrAbsolute);
                    model.Title = values[1];
                    model.Date = DateTime.Parse(values[2], CultureInfo.InvariantCulture);
                    model.Index = index;
                    model.Likes = values[3];

                    this.itemsSource.Add(model);
                    index++;
                }
            }
        }

        public class ViewModel
        {
            public int Index
            {
                get;
                set;
            }

            public Uri Image
            {
                get;
                set;
            }

            public string DateText
            {
                get
                {
                    return this.Date.ToString("MMMM dd, yyyy");
                }
            }

            public DateTime Date
            {
                get;
                set;
            }

            public string Title
            {
                get;
                set;
            }

            public string Likes
            {
                get;
                set;
            }
        }

        private void OnPlayTap(object sender, GestureEventArgs e)
        {
            if (this.playTimer.IsEnabled)
            {
                this.StopSlideShow();
            }
            else
            {
                this.playTimer.Start();
                this.buttonImage.Source = new BitmapImage(new Uri("Images/pause.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (this.playTimer.IsEnabled)
            {
                this.StopSlideShow();
            }
        }

        private void StopSlideShow()
        {
            this.playTimer.Stop();
            this.buttonImage.Source = new BitmapImage(new Uri("Images/play.png", UriKind.RelativeOrAbsolute));
        }
    }
}
