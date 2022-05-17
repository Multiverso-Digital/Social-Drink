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
using System.Device.Location;
using Microsoft.Phone.Shell;
using System.Globalization;
using Microsoft.Phone.Tasks;
using System.Device;
using Microsoft.Phone.UserData;
using Microsoft.Phone.Controls.Maps;
using Telerik.Windows.Controls;
//using Telerik.Examples.WP;
//using Telerik.QSF.WP.Helpers;


namespace Social_Drink
{
    public partial class MostraTaxi : PhoneApplicationPage
    {

        PhoneNumberChooserTask phoneNumberChooserTask = new PhoneNumberChooserTask();
        SmsComposeTask smsComposeTask = new SmsComposeTask();
        SavePhoneNumberTask savePhoneNumberTask = new SavePhoneNumberTask();
        SaveContactTask contato = new SaveContactTask();

        public bool flip = true;
        public string displayName = "TAXI";
        string phone = "";
        public string link = "";
        public MostraTaxi()
        {
            InitializeComponent();


            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).Text = Localization.b_save.ToString();


            eBar.Text = App.LocName;
            eEnde.Text = App.LocAddress;


            if (App.Conf[0].NomeUsu != null)
            {
                eNome.Text = App.Conf[0].NomeUsu;
            }
            
            
            if (App.Conf[0].NumCel != null) {
            eCelular.Text =    App.Conf[0].NumCel;
            }

            if (App.Conf[0].Destino != null)
            {
                eDestino.Text = App.Conf[0].Destino;
            }




            if (App.Conf[0].NET == false)
            {

                MessageBox.Show(Localization.m85.ToString());
                return;
            }


            string latx = App.LatCel.ToString().Replace(",", ".");
            string lonx = App.LonCel.ToString().Replace(",", ".");
            Pushpin pin1 = new Pushpin();
            int zoom = 16;
            pin1.Template = this.Resources["pinMyLoc"] as ControlTemplate;
            pin1.Location = App.LocCel;
            pin1.FontSize = 12;
            pin1.Content += ("Here");
            map1.LogoVisibility = Visibility.Collapsed;
            map1.CopyrightVisibility = Visibility.Collapsed;
            map1.Children.Add(pin1);
            //map1.Visibility = Visibility.Visible;
            map1.SetView(App.LocCel, zoom);

            link =  "http://dev.virtualearth.net/embeddedMap/v1/ajax/aerial?zoomLevel=17&center=" + latx + "_" + lonx + "&pushpins=" + latx + "_" + lonx;


            //pega_taxi();
        }

     

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            contato.FirstName = "TAXI";
            contato.Nickname = "TAXI";
            contato.Show();
        }

        private void btnMakePhoneCall_Click(object sender, RoutedEventArgs e)
        {

            pega_taxi();
            
        }






        private void pega_taxi()
        {
            
            
            
           // Contacts contacts = new Contacts();
           // contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
           // contacts.SearchAsync(displayName, FilterKind.DisplayName, null);


            PhoneNumberChooserTask contato = new PhoneNumberChooserTask();
            contato.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            contato.Show();



        }


        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("The phone number for " + e.DisplayName + " is " + e.PhoneNumber);


                phone = e.PhoneNumber;


                //Code to start a new call using the retrieved phone number.
                //PhoneCallTask phoneCallTask = new PhoneCallTask();
                //phoneCallTask.DisplayName = e.DisplayName;
                //phoneCallTask.PhoneNumber = e.PhoneNumber;
                //phoneCallTask.Show();
            }
        }



        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {

            ContactPhoneNumber numero;
            int tottaxi = 0;

        foreach (var result in e.Results)    
        
        {


            numero = result.PhoneNumbers.FirstOrDefault();

            if (numero != null)
            {
                tottaxi = tottaxi + 1;
                phone = numero.PhoneNumber;
            }

            if (tottaxi > 1)
            {

                MessageBox.Show(Localization.m89);




            }

            /*
            this.tbdisplayName.Text = "Name: " + result.DisplayName;        
            this.tbEmail.Text = "E-mail address: " + result.EmailAddresses.FirstOrDefault().EmailAddress;        
            this.tbPhone.Text = "Phone Number: " + result.PhoneNumbers.FirstOrDefault();        
            this.tbPhysicalAddress.Text = "Address: " + result.Addresses.FirstOrDefault().PhysicalAddress.AddressLine1;        
            this.tbWebsite.Text = "Website: " + result.Websites.FirstOrDefault();
    */

            
        }




            if (phone != "")
            {


                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.PhoneNumber = phone;
                phoneCallTask.DisplayName = "TAXI";
                phoneCallTask.Show();


            }
            else
            {

                button1_Click(null, null);
            }


        }

        private void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {


            if (phone == "")
            {
                MessageBox.Show(Localization.m90);


                PhoneNumberChooserTask contato = new PhoneNumberChooserTask();
                contato.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
                contato.Show();
                
                return;

            }



            if (eNome.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m91);
                return;
            }

            if (eCelular.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m92);
                return;
            }

            if (eDestino.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m93);
                return;
            }




            string texto = Localization.m94 + " " + App.LocName + " " + Localization.m95 + ": " + App.LocAddress + " " + Localization.m96 + " " + eNome.Text + " " + Localization.m97 + " " + eCelular.Text + " " + Localization.m98 + " " + link + " " + Localization.m99 + " " + eDestino.Text;

            smsComposeTask.To = phone;
            smsComposeTask.Body =  texto;
            smsComposeTask.Show();
        }

        private void image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {




            if (flip == true)
            {

                map1.Visibility = Visibility.Visible;
            }
            else
            {
                map1.Visibility = Visibility.Collapsed;

            }

            flip = !flip;
            



        }

        private void Save_Button(object sender, EventArgs e)
        {



            if (eNome.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m91);
                return;
            }

            if (eCelular.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m92);
                return;
            }

            if (eDestino.Text.Trim().Length == 0)
            {

                MessageBox.Show(Localization.m93);
                return;
            }



            App.Conf[0].NomeUsu = eNome.Text.Trim();
            App.Conf[0].NumCel  = eCelular.Text.Trim();
            App.Conf[0].Destino = eDestino.Text.Trim();



            MessageBox.Show(Localization.m100);



        }

        private void eNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void eCelular_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void eDestino_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void procura_Button(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Lista_Taxi.xaml", UriKind.RelativeOrAbsolute));
        }//end of funt

       




    }
}