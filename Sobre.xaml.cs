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

namespace Social_Drink
{
    public partial class Sobre : PhoneApplicationPage
    {
        public Sobre()
        {
            InitializeComponent();

            //hyperlinkButton1.Content = Localization.b_hyper;

            App.Passou = true;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Menu.xaml", UriKind.Relative));
            if (NavigationService.CanGoBack)
            {

                NavigationService.GoBack();
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }
            
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();

        }


        private void email_Click(object sender, EventArgs e)
        {

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }

            EmailComposeTask task = new EmailComposeTask();
            task.Subject = "Social Drink";
            task.To = "abreu@abreuretto.com";
            task.Body = "";
            task.Show();
        }

        private void fb_Click(object sender, EventArgs e)
        {

            if (App.Conf[0].NET == false)
            {
                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            ShareLinkTask shareLinkTask = new ShareLinkTask();
            shareLinkTask.LinkUri = new Uri("http://www.facebook.com/wpabreuretto", UriKind.Absolute);
            shareLinkTask.Title = Localization.ms126;
            shareLinkTask.Message = "";
            shareLinkTask.Show();
        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/web_browser.xaml", UriKind.RelativeOrAbsolute));
            
        }

    }
}