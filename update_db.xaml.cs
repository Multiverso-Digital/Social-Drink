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
using Microsoft.Phone.Shell;
using Buddy;
using System.Globalization;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Telerik.Windows.Controls;


namespace Social_Drink
{
    public partial class update_db : PhoneApplicationPage
    {
        int contax = 0;
        int currentAnimation = 0;
        int ind = 0;
        int soma = 0;
        int conta = 0;
        int soma1 = 0;
        int conta1 = 0;
        int soma2 = 0;
        int conta2 = 0;
        int soma3 = 0;
        int conta3 = 0;
        int soma5 = 0;
        int conta5 = 0;
        int soma8 = 0;
        int conta8 = 0;
        
        string chave40 = "";




       public double valorUsu = 0;
       public string lat = "";
       public string lon = "";
       public string data = "";
       public string local = "";
       public string bebida = "";
       public string marca = "";
       public double ml = 0;
       public string idlocal = "";
       public string pais = "";
       public string cida = "";
       public string email = "";
       
        public bool temFrase = false;
       public bool temFilme = false;
       

        BuddyClient client = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass); 
        BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client3 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client4 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client5 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client6 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client7 = new BuddyClient(Constants.AppName, Constants.AppPass);
        BuddyClient client8 = new BuddyClient(Constants.AppName, Constants.AppPass);


        public update_db()
        {
            InitializeComponent();

            if (App.Conf[0].NET == false) {

                MessageBox.Show(Localization.m85.ToString());
                return; 
            
            
            }

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);  
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {




            App.Passou = true;

       //     ExcluirUsu();
       //     return;

       //     ExcluirTudoUser();
       //     ExcluirTudoApp();
       //     return;


            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Localization.m01.ToString());
                return;
            }

/*
            if (MyToolkit.Networking.NetworkStateTracker.IsWiFiConnected == false)
            {
                MessageBox.Show(Localization.m104);
                NavigationService.GoBack();
            }

            */

            for (int i=0; i<= App.ListaShot.Count-1;i++)
            {
                if (App.ListaShot[i].gravou == 1) {
                App.ListaShot.RemoveAt(i);
                App.Conf[0].Gravou_no_Server = true;
                }
            }


            if (App.Conf[0].UserToken == null)
            {

                MessageBox.Show(Localization.m105);
                NavigationService.GoBack();

            }


            ligadesliga_busy(true, Localization.m106);
            ligadesliga_tray(true, Localization.m106);

            PegaDados(App.Conf[0].UserToken);
           


           


            

            //MessageBox.Show("Terminou");




        }


        public ProgressIndicator progress1 = new ProgressIndicator
        {
            IsVisible = true,
            IsIndeterminate = true,
            Text = ""
        };




        public void ligadesliga_busy(bool valor, string texto)
        {

            
            
            this.busyIndicator.IsRunning = valor;

            if (valor == true)
            {

                if (currentAnimation > 7)
                {
                    currentAnimation = 0;
                }


                this.busyIndicator.AnimationStyle = (AnimationStyle)(++this.currentAnimation);



                if (Storyboard1.GetCurrentState() != ClockState.Active)
                    Storyboard1.Begin();
                
                
                //image1_Copy_MouseLeftButtonDown(null, null);


            }
            
            
            this.busyIndicator.Content=texto; 
                                                
        }

        public void ligadesliga_tray(bool valor, string texto)
        {

            SystemTray.IsVisible = valor;

            progress1.IsVisible = valor;
            progress1.IsIndeterminate = valor;
            progress1.Text = texto;
            SystemTray.SetProgressIndicator(this, progress1);
        }


        public void verifica_seexiste_email()
        {
            if (App.Conf[0].UserToken != null)
            {
                PegaDados(App.Conf[0].UserToken);
                return;
            }

            try
            {
                client.Service.UserAccount_Profile_CheckUserEmailCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_CheckUserEmailCompletedEventArgs>(verifica_email);
                client.Service.UserAccount_Profile_CheckUserEmailAsync(Constants.AppName, Constants.AppPass, App.Conf[0].EmailUsu, "");
            }

            catch (Exception ex)
            {
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }


        void verifica_email(object sender, Buddy.BuddyService.UserAccount_Profile_CheckUserEmailCompletedEventArgs e)
        {




            try
            { 

            if (e.Error == null)
            {

                if (e.Result.ToString() == "UserEmailTaken")
                {



                    pega_usu();


                    if (1 == 1)
                    {
                       
                        
                        
                        
                        //MessageBox.Show(Localization.ms69.ToString());
                        //return;
                    }
                    else
                    {
                        
                        
                        
                        /*
                        App.UserEmail = eEmail.Text.Trim();
                        App.UserName = eNome.Text.Trim();
                        App.UserPass = eSenha.Password.Trim();
                        EditanoServer();
                        */
                    }



                }
                else
                {
                 
                    /*
                    App.UserEmail = eEmail.Text.Trim();
                    App.UserName = eNome.Text.Trim();
                    App.UserPass = eSenha.Password.Trim();
                     */ 
                      
                    GravanoServer();
                      
                }



            }
            else
            {

                pega_usu();
                
                //MessageBox.Show(Localization.ms69.ToString());
            }


            }

            catch (Exception ex)
            {
                ligadesliga_busy(false,"");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }





        public void pega_usu()
        {
            try
            {
                client.Service.UserAccount_Profile_RecoverCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_RecoverCompletedEventArgs>(recupera_user);
                client.Service.UserAccount_Profile_RecoverAsync(Constants.AppName, Constants.AppPass, App.Conf[0].EmailUsu, App.Conf[0].DeviceID);
            }

            catch (Exception ex)
            {
                 ligadesliga_busy(false,"");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }


        }


        void recupera_user(object sender, Buddy.BuddyService.UserAccount_Profile_RecoverCompletedEventArgs e)
        {

            try
            {



                if (e.Result.ToString() == "SecurityFailedBadUserName")
                {
                    MessageBox.Show("Bad UserName!");
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");
                    return;

                }

                if (e.Result.ToString() == "SecurityFailedBadUserPassword")
                {
                    MessageBox.Show("Bad Password!");
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");
                    return;

                }

                if ((e.Result.ToString() == "WrongSocketLoginOrPass") |
                (e.Result.ToString() == "ApplicationAPICallDisabledByDeveloper") |
                (e.Result.ToString() == "InvalidApplicationAndUserToken") |
                (e.Result.ToString() == "-1"))
                {

                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");

                    return;

                }


                if (e.Error == null)
                {
                    
                    App.Conf[0].UserToken = e.Result.ToString();
                    
                }
                else
                {
                    MessageBox.Show(Localization.m08.ToString());
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");

                    return;
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");

                return;
            }

            PegaDados(App.Conf[0].UserToken);


        }









        public void GravanoServer()
        {
            try
            {
                client.Service.UserAccount_Profile_CreateCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_CreateCompletedEventArgs>(inclui_profile);
                client.Service.UserAccount_Profile_CreateAsync(Constants.AppName, Constants.AppPass, App.Conf[0].EmailUsu, App.Conf[0].DeviceID, "male", 20, App.Conf[0].EmailUsu, -1, 0, 0, App.Conf[0].EmailUsu, "");
            }

            catch (Exception ex)
            {
             //   ligadesliga_busy(false);
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }

        }


        void inclui_profile(object sender, Buddy.BuddyService.UserAccount_Profile_CreateCompletedEventArgs e)
        {


            try
            { 


            if (e.Error == null)
            {
                App.Conf[0].UserToken = e.Result.ToString();
                PegaDados(App.Conf[0].UserToken);
                //App.Conf[0].UserToken = App.UserToken;

            }
            else
            {
                MessageBox.Show(Localization.m02.ToString());
            }


            }

            catch (Exception ex)
            {
                //ligadesliga_busy(false);
                ligadesliga_tray(false, "");
                ligadesliga_busy(false, "");
                MessageBox.Show(Localization.m02);
                return;
            }

        }




        public void PegaDados(string token)
        {

            ligadesliga_busy(true, Localization.m110.ToString());
            ligadesliga_tray(true, Localization.m110.ToString());


            try
            {
                client6.Service.UserAccount_Profile_GetFromUserTokenCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_GetFromUserTokenCompletedEventArgs>(pega_user);
                client6.Service.UserAccount_Profile_GetFromUserTokenAsync(Constants.AppName, Constants.AppPass, token);
            }

            catch (Exception ex)
            {
             //   ligadesliga_busy(false);
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m02.ToString());
                return;
            }



        }


        void pega_user(object sender, Buddy.BuddyService.UserAccount_Profile_GetFromUserTokenCompletedEventArgs e)
        {


            try
            {


                if (e.Error == null)
                {

                    if (e.Result != null)
                    {
                        for (int i = 0; i < e.Result.Count; i++)
                        {
                            App.Conf[0].UserID = e.Result[i].UserID;
                            App.Conf[0].NomeUsu = e.Result[i].UserApplicationTag;
                            App.Conf[0].EmailUsu = e.Result[i].UserEmail;
                            CompletaGoogle();

                        }
                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");

                return;
            }



            ligadesliga_tray(false, "");
            ligadesliga_busy(false, "");

         


        }








        public void Executa_Poe_Medalha()
        {


            ligadesliga_busy(true, "Set winner ...");
            ligadesliga_tray(true, "Set winner...");

            client7.Service.MetaData_ApplicationMetaDataValue_SetCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SetCompletedEventArgs>(poe_medal);

            soma8 = 0;
            conta8 = 0;

            foreach (App.medalhas x in App.ListaMedalhas)
            {

                if (x.pontos > 0)
                {
                    soma8 = soma8+1;
                    string chave = "<88><pais>" + x.pais + "</pais><cida>" + x.cida + "</cida><email>" + x.email + "</email><pontos>" + x.pontos.ToString() + "</pontos><spin>" + x.spin.ToString() + "</spin><local>" + x.locname + "</local><data>"+x.data+"</data></88>";
                    client7.Service.MetaData_ApplicationMetaDataValue_SetAsync(Constants.AppName, Constants.AppPass, chave, x.pontos.ToString(), x.lat, x.lon, "", "");
                }


            }






        }

        void poe_medal(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SetCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {

                      conta8 = conta8 + 1;
                      if (conta8 == soma8)
                      {
                          for (int i=0; i < App.ListaMedalhas.Count-1;i++)
                          {
                              App.ListaMedalhas.RemoveAt(i);
                          }
                      }
                    
                }
                else
                {



                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false, "");
                    valorUsu = 0;
                    return;
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                valorUsu = 0;
                return;
            }

           // ligadesliga_tray(false, "");
           // ligadesliga_busy(false, "");
        }

















        public void Executa_Get_User()
        {


            ligadesliga_busy(true, Localization.m108.ToString());
            ligadesliga_tray(true, Localization.m108.ToString());
            
            
            
            soma1 = 0;
            conta1 = 0;


            if (App.ListaShot.Count == 0)
            {


               // ligadesliga_busy(true, "Nothing to send...");
               // ligadesliga_tray(true, "Nothing to send...");
                MessageBox.Show(Localization.m107.ToString());
                App.SaiEnvia = true;
                NavigationService.GoBack();
                
                return;
                //Executa_Poe_Frase();
            }


            foreach (App.Shot x in App.ListaShot)
            {
                double testalat = Convert.ToDouble(x.latitude);
                double testalon = Convert.ToDouble(x.longitude);



                if ((testalat != 0) && (testalon != 0))
                {
                    soma1 = soma1 + 1;

                    lat = x.latitude;
                    lon = x.longitude;
                    data = x.datahoje;
                    local = x.local;
                    bebida = x.bebida;
                    marca = x.marca;
                    ml = x.ml;
                    idlocal = x.idlocal;
                    cida = x.cida;
                    pais = x.pais;
                    x.gravou = 1;


                    string chave = "<A1><A1_data>" + data + "</A1_data><A1_local>" + local + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca><shots>" + x.shots.ToString() + "</shots></A1>";

                    long datx = DateTime.Now.Ticks;

                    try
                    {
                        client.Service.MetaData_UserMetaDataValue_SetCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs>(pega_set_user);
                        client.Service.MetaData_UserMetaDataValue_SetAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, chave, datx.ToString(), lat, lon, "", "");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(Localization.m02.ToString());
                        ligadesliga_busy(false, "");
                        ligadesliga_tray(false, "");

                        return;
                    }



                  

                }





            }



            if (soma1 == 0)
            {

                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                MessageBox.Show(Localization.m107.ToString());

                return;

            }
            



        }

        void pega_set_user(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    if (e.Result != null)
                    {

                        conta1 = conta1 + 1;
                        if (conta1 >= soma1)
                        {

                            Executa_Set_App();
                        }

                    }
                }
                else
                {


                    this.Dispatcher.BeginInvoke(() =>
                    {
                        ligadesliga_tray(false, "");
                        ligadesliga_busy(false, "");
                    });
                    valorUsu = 0;
                    return;
                }
            }

            catch (Exception ex)
            {
                this.Dispatcher.BeginInvoke(() =>
                 {

                     ligadesliga_tray(false, "");
                     ligadesliga_busy(false, "");
                     valorUsu = 0;
                 });
                return;
            }


            this.Dispatcher.BeginInvoke(() =>
             {


                 ligadesliga_tray(false, "");
                 ligadesliga_busy(false, "");
             });
                    }


        /*

        void pega_get_user(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_GetCompletedEventArgs e)
        {
            try
            {

                MessageBox.Show(e.Error.ToString());


                if (e.Error == null)
                {
                    if (e.Result != null)
                    {
                        valorUsu = Convert.ToDouble(e.Result[0].MetaValue);
                    }
                    Executa_Set_User();
                }
                else
                {
                    
                    
                  //  MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    valorUsu = 0;
                    Executa_Set_User();
                    return;
                }
            }

            catch (Exception ex)
            {
            //    MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                valorUsu = 0;
                Executa_Set_User();
                return;
            }
            ligadesliga_tray(false, "");
        }


        public void Executa_Set_User()
        {
            string chave = "<A1><A1_data>" + data + "</A1_data><A1_local>" + local + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca></A1>";
            double valorOK = valorUsu + ml;
            
            try
            {
                client.Service.MetaData_UserMetaDataValue_SetCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs>(pega_set_user);
                client.Service.MetaData_UserMetaDataValue_SetAsync(Constants.AppName, Constants.AppPass, App.Conf[0].UserToken, chave, valorOK.ToString(), lat, lon, "", "");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");

                return;
            }
        }

        void pega_set_user(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_SetCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    Executa_Set_App();
                }
                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    valorUsu = 0;
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                valorUsu = 0;
                return;
            }

            ligadesliga_tray(false, "");
        }














/*


        public void Executa_Set_User()
        {
            Social_Drink.Checkin.Coordenadas objcoordenadas = new Social_Drink.Checkin.Coordenadas();
            objcoordenadas.Latitude = Convert.ToSingle(lat, CultureInfo.InvariantCulture);
            objcoordenadas.Longitude = Convert.ToSingle(lon, CultureInfo.InvariantCulture);
            this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.m33.ToString()); });
            string chave = "<A1><A1_data>" + data + "</A1_data><A1_local>" + local + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca></A1>";
            AuthenticatedUser user = null;
            string valor = ml.ToString(CultureInfo.InvariantCulture);
            
            client.LoginAsync((result, state) =>
            {
                if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                else
                {
                    user = result;
                    MetadataItem x = null;
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

                                       
                                        Executa_Set_App(lat, lon, data, local, bebida, marca, valor, idlocal);
                                       
                                    }
                                    else
                                    {

                                    }
                                }, chave, valor, 0, 0);
                            }
                            else
                            {

                                valor = valor + x.Value;
                                Executa_Atu_User(lat, lon, data, local, bebida, marca, valor, idlocal);
                            }
                        }

                    }, chave);

                }
            }, App.Conf[0].UserToken);
        }


        public void Executa_Atu_User()
        {
            Social_Drink.Checkin.Coordenadas objcoordenadas = new Social_Drink.Checkin.Coordenadas();
            objcoordenadas.Latitude = Convert.ToSingle(lat, CultureInfo.InvariantCulture);
            objcoordenadas.Longitude = Convert.ToSingle(lon, CultureInfo.InvariantCulture);
            this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.m33.ToString()); });
            string chave = "<A1><A1_data>" + data + "</A1_data><A1_local>" + local + "</A1_local><A1_bebida>" + bebida + "</A1_bebida><A1_marca>" + marca + "</A1_marca></A1>";
            AuthenticatedUser user = null;
      
            client.LoginAsync((result, state) =>
            {
                if (state.Exception != null) MessageBox.Show("Error: " + state.Exception.Message);
                else
                {
                    user = result;
                    MetadataItem x = null;
                    user.Metadata.GetAsync((p1, ex1) =>
                    {
                        x = p1;

                        if (ex1.Completed == true)
                        {
                            
                            
                                user.Metadata.SetAsync((p, ex) =>
                                {
                                    if (ex.Exception != null) MessageBox.Show("Error: " + ex.Exception.Message);
                                    if (p == true)
                                    {


                                        Executa_Set_App(lat, lon, data, local, bebida, marca, valor, idlocal);



                                    }
                                    else
                                    {

                                    }
                                }, chave, valor, 0, 0);
                            
                        }

                    }, chave);

                }
            }, App.Conf[0].UserToken);
        }

*/




        



































        public void Executa_Set_App()
        {


            ligadesliga_busy(true, Localization.m109.ToString());
            ligadesliga_tray(true, Localization.m109.ToString());


            if (App.ListaShot.Count == 0)
            {
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                App.SaiEnvia = true;
                MessageBox.Show(Localization.m107.ToString());
                return;
            }

            
            soma2 = 0;
            conta2 = 0;

            foreach (App.Shot x in App.ListaShot)
            {
                double testalat = Convert.ToDouble(x.latitude);
                double testalon = Convert.ToDouble(x.longitude);


                if ((testalat != 0) && (testalon != 0))
                {
                    soma2 = soma2 + 11;

                    lat = x.latitude;
                    lon = x.longitude;
                    data = x.datahoje;
                    local = x.local;
                    bebida = x.bebida;
                    marca = x.marca;
                    ml = x.ml;
                    idlocal = x.idlocal;
                    cida = x.cida;
                    pais = x.pais;
                  //  Executa_Get_User();
                    x.gravou = 1;


                    this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.m33.ToString()); });
                    string valor = ml.ToString();

                    string chave = "<1><MB>" + bebida + "</MB></1>";
                    string chave1 = "<11><MB>" + bebida + "</MB><MM>" + marca + "</MM></11>";

                    string chave2 = "<2><PP>" + pais + "</PP><PB>" + bebida + "</PB></2>";
                    string chave3 = "<21><PP>" + pais + "</PP><PB>" + bebida + "</PB><PM>" + marca + "</PM></21>";

                    string chave4 = "<3><PP>" + pais + "</PP><PC>" + cida + "</PC><PB>" + bebida + "</PB></3>";
                    string chave5 = "<31><PP>" + pais + "</PP><PC>" + cida + "</PC><PB>" + bebida + "</PB><PM>" + marca + "</PM></31>";

                    string chave6 = "<4><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL><PB>" + bebida + "</PB></4>";
                    string chave7 = "<41><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL><PB>" + bebida + "</PB><PM>" + marca + "</PM></41>";

                    string chave9 = "<6><PP>" + pais + "</PP><PC>" + cida + "</PC><PL>" + local + "</PL></6>";


                    try
                    {
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(User_CheckIn_Pro);
                      
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave1, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave2, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave3, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave4, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave5, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave6, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave7, valor, lat, lon, "", "");
                        client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave9, "1", lat, lon, "", "");
                    }

                    catch (Exception ex)
                    {
                        ligadesliga_busy(false,"");
                        ligadesliga_tray(false, "");
                        MessageBox.Show(Localization.m02);
                        return;
                    }



                }
            }

            if (App.ListaShot.Count > 0)
            {
                string chave8 = "<5><PP>" + pais + "</PP><PC>" + cida + "</PC><EM>" + App.Conf[0].EmailUsu + "</EM></5>";
                string chave10 = "<7><PP>" + pais + "</PP><EM>" + App.Conf[0].EmailUsu + "</EM></7>";

                client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave8, "1", lat, lon, "", "");
                client2.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave10, "1", lat, lon, "", "");
            }
        }




        void User_CheckIn_Pro(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
        {


            try
            {
                


            if (e.Error == null)
            {


                if (e.Result != null)
                {

                    conta2 = conta2 + 1;
                    if (conta2 == soma2)
                    {


                        this.Dispatcher.BeginInvoke(() =>
                       {
                          
                           LimpaShots();
                       });
                   
                        

                    }


                }

               

            }

            }

            catch (Exception ex)
                            {
                                this.Dispatcher.BeginInvoke(() =>
                 {

                     ligadesliga_busy(false, "");
                     ligadesliga_tray(false, "");
                     MessageBox.Show(Localization.m02);
                 });
                                return;
            }


        }



        public void LimpaShots()
        {


            try
            {
                ligadesliga_busy(true, Localization.m109.ToString());
                ligadesliga_tray(true, Localization.m109.ToString());

                for (int i = 0; i <= App.ListaShot.Count - 1; i++)
                {

                    double testalat = Convert.ToDouble(App.ListaShot[i].latitude);
                    double testalon = Convert.ToDouble(App.ListaShot[i].longitude);


                    if ((testalat != 0) && (testalon != 0))
                    {

                        App.ListaShot.RemoveAt(i);

                    }
                }


                for (int i = 0; i <= App.LocaisUsu.Count - 1; i++)
                {

                    double testalat = Convert.ToDouble(App.LocaisUsu[i].latitude);
                    double testalon = Convert.ToDouble(App.LocaisUsu[i].longitude);


                    if ((testalat != 0) && (testalon != 0))
                    {

                        App.LocaisUsu.RemoveAt(i);

                    }
                }

            }
            catch (Exception ex)
            {

                this.Dispatcher.BeginInvoke(() =>
                      {


                          MessageBox.Show(ex.Message);
                          ligadesliga_busy(false, "");
                          ligadesliga_tray(false, "");
                      });
                
                
                
                return;
            }


            MessageBox.Show(Localization.m107.ToString());
            ligadesliga_busy(false,"" );
            ligadesliga_tray(false, "");

            if (NavigationService.CanGoBack == true)
            {
                App.SaiEnvia = true;
                NavigationService.GoBack();
            }






        
        }







        public void Executa_Poe_Frase()
        {


            ligadesliga_busy(true, "Get data from server...");
            ligadesliga_tray(true, "Get data from server...");



            soma = 0;
     
                    this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.m33.ToString()); });
                    string valor = ml.ToString();

                    string chave =  "<F1><NU>10</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.00</IF><FF>0.019</FF><FB></FB><FM></FM><FR>Um pouco tonto</FR></F1>";
                    string chave1 = "<F1><NU>11</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.019</IF><FF>0.04</FF><FB></FB><FM></FM><FR>Aconchegante e descontraído</FR></F1>";
                    string chave2 = "<F1><NU>12</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.04</IF><FF>0.09</FF><FB></FB><FM></FM><FR>Falta de coordenação e equilíbrio (legalmente bêbado)</FR></F1>";
                    string chave3 = "<F1><NU>13</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.09</IF><FF>0.14</FF><FB></FB><FM></FM><FR>Possível apagão(perda de memória)</FR></F1>";
                    string chave4 = "<F1><NU>14</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.14</IF><FF>0.19</FF><FB></FB><FM></FM><FR>Você se sente confuso, atordoado, ou de outra forma desorientado</FR></F1>";
                    string chave5 = "<F1><NU>15</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.19</IF><FF>0.24</FF><FB></FB><FM></FM><FR>Emocionalmente e fisicamente entorpecido</FR></F1>";
                    string chave6 = "<F1><NU>16</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.24</IF><FF>0.29</FF><FB></FB><FM></FM><FR>Pode estar bêbado!</FR></F1>";
                    string chave7 = "<F1><NU>17</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.29</IF><FF>0.34</FF><FB></FB><FM></FM><FR>Você provavelmente entrará em coma</FR></F1>";
                    string chave8 = "<F1><NU>18</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>pt-BR</ID><IF>0.34</IF><FF>9.99</FF><FB></FB><FM></FM><FR>Chame um Taxi!</FR></F1>";

                    string chave9 = " <F1><NU>1</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.0</IF><FF>0.019</FF><FB></FB><FM></FM><FR>little lightheaded</FR></F1>";
                    string chave10 = "<F1><NU>2</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.019</IF><FF>0.04</FF><FB></FB><FM></FM><FR>warm and relaxed</FR></F1>";
                    string chave11 = "<F1><NU>3</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.04</IF><FF>0.09</FF><FB></FB><FM></FM><FR>lack of coordination and balance (legally drunk)</FR></F1>";
                    string chave12 = "<F1><NU>4</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.09</IF><FF>0.14</FF><FB></FB><FM></FM><FR>possible blackout (memory loss)</FR></F1>";
                    string chave13 = "<F1><NU>5</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.14</IF><FF>0.19</FF><FB></FB><FM></FM><FR>You feel confused, dazed, or otherwise disoriented</FR></F1>";
                    string chave14 = "<F1><NU>6</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.19</IF><FF>0.24</FF><FB></FB><FM></FM><FR>emotionally and physically numb</FR></F1>";
                    string chave15 = "<F1><NU>7</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.24</IF><FF>0.29</FF><FB></FB><FM></FM><FR>in a drunken stupor</FR></F1>";
                    string chave16 = "<F1><NU>8</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.29</IF><FF>0.34</FF><FB></FB><FM></FM><FR>You are probably in a coma</FR></F1>";
                    string chave17 = "<F1><NU>9</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><ID>default</ID><IF>0.34</IF><FF>9.99</FF><FB></FB><FM></FM><FR>Call a Taxi!</FR></F1>";

                    string chave18 = "<F1><NU>19</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.0</IF><FF>0.019</FF><FB></FB><FM></FM><FR>little lightheaded</FR></F1>";
                    string chave19 = "<F1><NU>20</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.019</IF><FF>0.04</FF><FB></FB><FM></FM><FR>warm and relaxed</FR></F1>";
                    string chave20 = "<F1><NU>21</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.04</IF><FF>0.09</FF><FB></FB><FM></FM><FR>lack of coordination and balance (legally drunk)</FR></F1>";
                    string chave21 = "<F1><NU>22</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.09</IF><FF>0.14</FF><FB></FB><FM></FM><FR>possible blackout (memory loss)</FR></F1>";
                    string chave22 = "<F1><NU>23</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.14</IF><FF>0.19</FF><FB></FB><FM></FM><FR>You feel confused, dazed, or otherwise disoriented</FR></F1>";
                    string chave23 = "<F1><NU>24</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.19</IF><FF>0.24</FF><FB></FB><FM></FM><FR>emotionally and physically numb</FR></F1>";
                    string chave24 = "<F1><NU>25</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.24</IF><FF>0.29</FF><FB></FB><FM></FM><FR>in a drunken stupor</FR></F1>";
                    string chave25 = "<F1><NU>26</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.29</IF><FF>0.34</FF><FB></FB><FM></FM><FR>You are probably in a coma</FR></F1>";
                    string chave26 = "<F1><NU>27</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>en-US</ID><IF>0.34</IF><FF>9.99</FF><FB></FB><FM></FM><FR>Call a Taxi!</FR></F1>";

                    string chave27 = "<F1><NU>19</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.0</IF><FF>0.019</FF><FB></FB><FM></FM><FR>Un poco mareado</FR></F1>";
                    string chave28 = "<F1><NU>20</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.019</IF><FF>0.04</FF><FB></FB><FM></FM><FR>acogedor y relajado</FR></F1>";
                    string chave29 = "<F1><NU>21</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.04</IF><FF>0.09</FF><FB></FB><FM></FM><FR>falta de coordinación (legalmente borracho)</FR></F1>";
                    string chave30 = "<F1><NU>22</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.09</IF><FF>0.14</FF><FB></FB><FM></FM><FR>apagón posible (pérdida de memoria)</FR></F1>";
                    string chave31 = "<F1><NU>23</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.14</IF><FF>0.19</FF><FB></FB><FM></FM><FR>Sientes confundido y aturdido</FR></F1>";
                    string chave32 = "<F1><NU>24</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.19</IF><FF>0.24</FF><FB></FB><FM></FM><FR>emocional y físicamente adormecido</FR></F1>";
                    string chave33 = "<F1><NU>25</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.24</IF><FF>0.29</FF><FB></FB><FM></FM><FR>Puede estár borracho!</FR></F1>";
                    string chave34 = "<F1><NU>26</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.29</IF><FF>0.34</FF><FB></FB><FM></FM><FR>Es probable que entre en coma</FR></F1>";
                    string chave35 = "<F1><NU>27</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><ID>es-ES</ID><IF>0.34</IF><FF>9.99</FF><FB></FB><FM></FM><FR>Llamar a un taxi</FR></F1>";


                    string chave36 = "<M1><NU>28</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><LG>pt-BR</LG><LA>1</LA><LO>1</LO><RA>40075000</RA><UR>xO53rQ9nqQs</UR></M1>";
                    string chave37 = "<M1><NU>29</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><LG>en-US</LG><LA>1</LA><LO>1</LO><RA>40075000</RA><UR>xO53rQ9nqQs</UR></M1>";
                    string chave38 = "<M1><NU>30</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><LG>default</LG><LA>1</LA><LO>1</LO><RA>40075000</RA><UR>xO53rQ9nqQs</UR></M1>";
                    string chave39 = "<M1><NU>30</NU><AT>1</AT><DI>2012/09/27</DI><DF>2050/11/01</DF><LG>es-ES</LG><LA>1</LA><LO>1</LO><RA>40075000</RA><UR>xO53rQ9nqQs</UR></M1>";


                    Guid coduni;
                    coduni = Guid.NewGuid();

                    string chave40 = "<PRO><PR><L1>Promoção Cerveja Devassa</L1><L2>Acumule Pontos</L2><L3>" + coduni + "</L3><L4>100</L4></PR><NU>1250</NU><DI>2012/09/01</DI><DF>2012/10/30</DF><PT>100</PT><AT>1</AT><TX>Acumule 1000 postos e ganhe uma Devassa aqui neste local.</TX></PRO>";



                    string valor1 = "0";
                    string lat1 = "0"; 
                    string lon1 = "0";
                    try
     
                    {
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(User_CheckIn_Pro2);
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave , valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave1, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave2, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave3, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave4, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave5, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave6, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave7, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave8, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave9, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave10, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave11, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave12, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave13, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave14, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave15, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave16, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave17, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave18, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave19, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave20, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave21, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave22, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave23, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave24, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave25, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave26, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave27, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave28, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave29, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave30, valor1, lat1, lon1, "", "");


                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave31, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave32, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave33, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave34, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave35, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave36, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave37, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave38, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave39, valor1, lat1, lon1, "", "");
                        client3.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, chave40, valor1, lat1, lon1, "", "");
     














                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ligadesliga_busy(false, "");
                        ligadesliga_tray(false, "");
                        return;
                    }




     

        }




        void User_CheckIn_Pro2(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
        {

            if (e.Error == null)
            {


                if (e.Result != null)
                {
                    soma = soma + 1;
                    if (soma > 30) 
                    {
                     Executa_Pega_Frase();
                     ligadesliga_busy(false, "");
                    }
                   
                }



            }
        }















        public void CompletaGoogle()
        {

            /*

            for (int i = 0; i < App.LocaisGoogle.Count; i++)
            {
                ind = i;
                pegaGeo(App.LocaisGoogle[i].latitude.Replace(",", "."), App.LocaisGoogle[i].longitude.Replace(",", "."));

            }

             */

           Executa_Poe_Medalha();
           Executa_Get_User();
         
          // Executa_Set_App();
          
          //  Executa_Poe_Frase();
         //  Executa_Pega_Filme();
         //  Executa_Manda_Promocao();
         //  Executa_Set_App();
         //  Executa_Poe_Frase();
           
            
           
                
           


            


        }





        public void pegaGeo(string latx, string lonx)
        {

            
            
            string url = "http://api.geonames.org/findNearbyPlaceName?lat=" + latx + "&lng=" + lonx + "&username=abreuretto";
            WebClient xmlClient = new WebClient();
            xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(geo_Completed);
            xmlClient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));



        }//end of funt


        void geo_Completed(object sender, DownloadStringCompletedEventArgs e)
        {

            
            string pais = "";
            string cida = "";
            
            
            if (e.Error == null)
            {
                //App.LocalG.Clear();

                XElement xmlDataStill = XElement.Parse(e.Result);
                conta = 0;
                foreach (var item in xmlDataStill.Descendants("geoname"))
                {

                    try
                    {

                        pais = (string)item.Element("countryName").Value;
                        cida = (string)item.Element("toponymName").Value;
                        App.ListaShot[ind].pais = pais;
                        App.ListaShot[ind].cida = cida;
                    }
                    catch
                    {
                        App.ListaShot[ind].pais = " ";
                        App.ListaShot[ind].cida = " ";
                    }



                }
            }
            else
            {
                MessageBox.Show(Localization.m02.ToString());
            }

        }//end of funt





        public void ExcluirTudoUser()
        {
            try
            {

                BuddyClient client1 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client1.Service.MetaData_UserMetaDataValue_DeleteAllCompleted += new EventHandler<Buddy.BuddyService.MetaData_UserMetaDataValue_DeleteAllCompletedEventArgs>(Get_UserMeta_Drinks);
                client1.Service.MetaData_UserMetaDataValue_DeleteAllAsync(Constants.AppName, Constants.AppPass, "UT-1c3cff3a-1b5d-48eb-b99d-3ab17da41dd2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        void Get_UserMeta_Drinks(object sender, Buddy.BuddyService.MetaData_UserMetaDataValue_DeleteAllCompletedEventArgs e)
        {

            if (e.Error == null)
            {

            }
            else
            {

                MessageBox.Show(e.Error.ToString());

            }

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



        public void ExcluirUsu()
        {

            try
            {
                client.Service.UserAccount_Profile_DeleteAccountCompleted += new EventHandler<Buddy.BuddyService.UserAccount_Profile_DeleteAccountCompletedEventArgs>(deleta_user);
          //      client.Service.UserAccount_Profile_DeleteAccountAsync(Constants.AppName, Constants.AppPass, "1479478", "");
         //      client.Service.UserAccount_Profile_DeleteAccountAsync(Constants.AppName, Constants.AppPass, "1479479", "");
         //      client.Service.UserAccount_Profile_DeleteAccountAsync(Constants.AppName, Constants.AppPass, "1479480", "");
         //      client.Service.UserAccount_Profile_DeleteAccountAsync(Constants.AppName, Constants.AppPass, "1479481", "");
         //      client.Service.UserAccount_Profile_DeleteAccountAsync(Constants.AppName, Constants.AppPass, "1479822", "");





                //479478
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                return;
            }

        }


        void deleta_user(object sender, Buddy.BuddyService.UserAccount_Profile_DeleteAccountCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }










        public void Executa_Poe_Ganhador(string chave, string email)
        {


            ligadesliga_busy(true, "Set winner ...");
            ligadesliga_tray(true, "Set winner...");
            
            
            
     

                    try
                    {
                        client7.Service.MetaData_ApplicationMetaDataValue_SetCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SetCompletedEventArgs>(poe_ganha);
                        client7.Service.MetaData_ApplicationMetaDataValue_SetAsync(Constants.AppName, Constants.AppPass, chave, email, lat, lon, "", "");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(Localization.m02.ToString());
                        ligadesliga_busy(false, "");
                        ligadesliga_tray(false, "");

                        return;
                    }
        }

        void poe_ganha(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SetCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    if (e.Result != null)
                    {

                      

                    }
                }
                else
                {

                   

                    //MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false, "");
                    valorUsu = 0;
                    return;
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                valorUsu = 0;
                return;
            }

            ligadesliga_tray(false, "");
            ligadesliga_busy(false, "");
        }





        public void Executa_Pega_Premio()
         {


             ligadesliga_busy(true, "Get promotions...");
             ligadesliga_tray(true, "Get promotions...");


             if (App.QRPromocao.Count == 0)
             {
                 MessageBox.Show("Send process finished.");
                 ligadesliga_busy(false, "");
                 ligadesliga_tray(false, ""); 
                 return;
             }


             foreach (App.qrpromocao x in App.QRPromocao)
             {

             chave40 = "%<PR><L1>" + x.qr_linha01 + "</L1><L2>" + x.qr_linha02 + "</L2><L3>" + x.qr_linha03 + "</L3><L4>" + x.qr_linha04 + "</L4></PR>%";
             Executa_Pega_Premio2(chave40);
             
             }




         }




        public void Executa_Pega_Premio2(string chave40)
        {

                try
                {
                    client8.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_premio);
                    client8.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave40, "", "-1", "0", "999", "0", "DESC", "true");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_busy(false, "");
                    ligadesliga_tray(false, "");
                    return;
                }

        }






        void pega_premio(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {

                    if (e.Result != null)
                    {

                        if (e.Result.Count > 0)
                        {
                            // App.ListaFrases.Clear();
                            //temFrase = true;

                            for (int i = 0; i < e.Result.Count; i++)
                            {
                                string chaves = e.Result[i].MetaKey;
                                string valor = e.Result[i].MetaValue;

                                if (valor.IndexOf("@") == -1)
                                {

                                    // ListaPromo.Add(new promo() { chave = "<P1><EM>" + App.Conf[0].EmailUsu + "</EM><AT>1</AT><DT>" + x.datahoje + "<LC>" + x.local + "</LC><LA>" + x.latitude + "</LA><LO>" + x.longitude + "</LO><L1>" + x.qr_linha01 + "</L1><L2>" + x.qr_linha02 + "</L2><L3>" + x.qr_linha03 + "</L3><L4>" + x.qr_linha04 + "</L4></P1>", lat = x.latitude, lon = x.longitude, premio = x.qr_linha04 });



                                    string EME = GetBetween(chaves, "<EM>", "</EM>", 0);
                                    string DAT = GetBetween(chaves, "<DT>", "</DT>", 0);
                                    string LOC = GetBetween(chaves, "<LC>", "</LC>", 0);
                                    string LAT = GetBetween(chaves, "<LA>", "</LA>", 0);
                                    string LON = GetBetween(chaves, "<LO>", "</LO>", 0);
                                    string NOP = GetBetween(chaves, "<L1>", "</L1>", 0);
                                    string PTO = GetBetween(chaves, "<L4>", "</L4>", 0);
                                    string COD = GetBetween(chaves, "<L3>", "</L3>", 0);


                                    App.ListaMedalhas.Add(new App.medalhas() { tipo = "QRCODE", cod = COD, data = DAT, email = EME, locname = LOC, promoname = NOP, lat = LAT, lon = LON, img = "/images/medal01.png" });

                                    Executa_Poe_Ganhador(chave40, App.Conf[0].EmailUsu);


                                }
                            }




                            ligadesliga_busy(false, "");
                            ligadesliga_tray(false, ""); 

                            MessageBox.Show("Send process finished.");

                        }

                        ligadesliga_busy(false, "");
                        ligadesliga_tray(false, ""); 
                        
                        

                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false, "");

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                ligadesliga_busy(false, "");

                return;
            }



            ligadesliga_busy(false, "");
            ligadesliga_tray(false, ""); 
                        
                        




        }











        /*

            string chave30 = "<PRO><PR><L1>Promoção Cerveja Devassa</L1><L2>Acumule Pontos</L2><L3>123456789</L3><L4>" + coduni + "</L4></PR><NU>1250</NU><DI>2012/09/01</DI><DF>2012/10/30</DF><PT>100</PT><AT>1</AT><TX>Acumule 1000 postos e ganhe uma Devassa aqui neste local.</TX></PRO>";


            string chave = "%<PR>" + App.Conf[0].Idioma + "</PR>%";



            try
            {
                client.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_frase);
                client.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave, "", "-1", "0", "999", "0", "DESC", "true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                return;
            }



        }


        */









        public void Executa_Pega_Frase()
        {



            ligadesliga_busy(true, "Get texts...");
            ligadesliga_tray(true, "Get texts...");



            temFrase = false;


            string chave42 = "%<ID>"+ App.Conf[0].Idioma+"</ID>%";

            try
            {
                client1.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_frase);
                client1.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave42, "", "-1", "0", "999", "0", "DESC", "true");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                return;
            }



        }


        void pega_frase(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {
            
            
            
            
            /*
            
            
            try
            {
                if (e.Error == null)
                {

                    if (e.Result != null)
                    {

                        if (e.Result.Count > 0)
                        {
                           // App.ListaFrases.Clear();
                            temFrase = true;
                        }
                        for (int i = 0; i < e.Result.Count; i++)
                        {
                           string frase = e.Result[i].MetaKey;
                           double INI = Convert.ToDouble(GetBetween(frase, "<IF>", "</IF>", 0), CultureInfo.InvariantCulture);
                           double FIM = Convert.ToDouble(GetBetween(frase, "<FF>", "</FF>", 0), CultureInfo.InvariantCulture);
                           string BEB = GetBetween(frase, "<FB>", "</FB>", 0);
                           string MAR = GetBetween(frase, "<FM>", "</FM>", 0);
                           string TEX = GetBetween(frase, "<FR>", "</FR>", 0);
                           string IDI = GetBetween(frase, "<ID>", "</ID>", 0);
                           string COD = GetBetween(frase, "<NU>", "</NU>", 0);
                           string ATV = GetBetween(frase, "<AT>", "</AT>", 0);
                           string DTI = GetBetween(frase, "<DI>", "</DI>", 0);
                           string DTF = GetBetween(frase, "<DF>", "</DF>", 0);

                           bool achou = false;

                           foreach (App.Frases x in App.ListaFrases)
                           {

                               if (x.codigo == Convert.ToInt32(COD))
                               {
                                   achou = true;
                                   x.ativo=Convert.ToInt32(ATV); 
                                   x.codigo=Convert.ToInt32(COD);
                                   x.datini=DTI;
                                   x.datfim=DTF;  
                                   x.idioma = IDI;
                                   x.valini = INI;
                                   x.valfim = FIM;
                                   x.bebida = BEB;
                                   x.marca = MAR;
                                   x.texto = TEX;

                               }

                           }

                           if (achou == false)
                           {
                               App.ListaFrases.Add(new App.Frases() { ativo = Convert.ToInt32(ATV), codigo = Convert.ToInt32(COD), datini = DTI, datfim = DTF, idioma = IDI, valini = INI, valfim = FIM, bebida = BEB, marca = MAR, texto = TEX });
                           }
                        
                        
                        
                        }


                        Executa_Pega_Frase_Default();
                        ligadesliga_busy(false, "");

                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false, "");
                    return;
                }

            }

            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                ligadesliga_tray(false, "");
                ligadesliga_busy(false, "");
                return;
            }



            ligadesliga_tray(false, "");
            ligadesliga_busy(false, "");


            */

        }





        public void Executa_Pega_Frase_Default()
        {



            ligadesliga_busy(true, "Get default texts...");
            ligadesliga_tray(true, "Get default texts...");

            if (temFrase == true)   
                        
            {
                //Executa_Pega_Filme();
                          
                return;}


            string chave51 = "%<ID>default</ID>%";

            try
            {
                client6.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_frase_default);
                client6.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave51, "", "-1", "0", "999", "0", "DESC", "true");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_busy(false, "");
                ligadesliga_tray(false, "");
                return;
            }



        }


        void pega_frase_default(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {


            /*


            try
            {


                if (e.Error == null)
                {

                    if (e.Result != null)
                    {

                        if (e.Result.Count > 0)
                        {
                            //App.ListaFrases.Clear();                            
                        }


                        for (int i = 0; i < e.Result.Count; i++)
                        {
                            string frase = e.Result[i].MetaKey;
                            double INI = Convert.ToDouble(GetBetween(frase, "<IF>", "</IF>", 0), CultureInfo.InvariantCulture);
                            double FIM = Convert.ToDouble(GetBetween(frase, "<FF>", "</FF>", 0), CultureInfo.InvariantCulture);
                            string BEB = GetBetween(frase, "<FB>", "</FB>", 0);
                            string MAR = GetBetween(frase, "<FM>", "</FM>", 0);
                            string TEX = GetBetween(frase, "<FR>", "</FR>", 0);
                            string IDI = GetBetween(frase, "<ID>", "</ID>", 0);
                            string COD = GetBetween(frase, "<NU>", "</NU>", 0);
                            string ATV = GetBetween(frase, "<AT>", "</AT>", 0);
                            string DTI = GetBetween(frase, "<DI>", "</DI>", 0);
                            string DTF = GetBetween(frase, "<DF>", "</DF>", 0);

                            bool achou = false;

                            foreach (App.Frases x in App.ListaFrases)
                            {

                                if (x.codigo == Convert.ToInt32(COD))
                                {
                                    achou = true;
                                    x.ativo = Convert.ToInt32(ATV);
                                    x.codigo = Convert.ToInt32(COD);
                                    x.datini = DTI;
                                    x.datfim = DTF;
                                    x.idioma = IDI;
                                    x.valini = INI;
                                    x.valfim = FIM;
                                    x.bebida = BEB;
                                    x.marca = MAR;
                                    x.texto = TEX;

                                }

                            }

                            if (achou == false)
                            {
                                App.ListaFrases.Add(new App.Frases() { ativo = Convert.ToInt32(ATV), codigo = Convert.ToInt32(COD), datini = DTI, datfim = DTF, idioma = IDI, valini = INI, valfim = FIM, bebida = BEB, marca = MAR, texto = TEX });
                            }

                            ligadesliga_busy(false, "");
                            App.Retira_da_Lista();
                            //Executa_Pega_Filme();
                            
                           
        



                        }

                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");

                return;
            }


            ligadesliga_busy(false, "");
            ligadesliga_tray(false, "");


            */

        }









        public void Executa_Pega_Filme()
        {



            ligadesliga_busy(true, "Get motions...");
            ligadesliga_tray(true, "Get motions...");



            temFilme = false;


            string chave55 = "%<LG>" + App.Conf[0].Idioma + "</LG>%";

            try
            {
                client4.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_filme);
                client4.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave55, "", "-1", "0", "999", "0", "DESC", "true");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                ligadesliga_busy(false, "");
                return;
            }



        }


        void pega_filme(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {
           
            /*
            
            
            
            try
            {
                if (e.Error == null)
                {

                    if (e.Result != null)
                    {

                        if (e.Result.Count > 0)
                        {
                            // App.ListaFrases.Clear();
                            temFilme = true;
                        }


                   //     string chave27 = "<M1><NU>28</NU><AT>1</AT><DI>2012/09/27</DI><DF>2012/11/01</DF><LG>pt-BR</LG><LA>1</LA><LO>1</LO><RA>40075000</RA><UR>x-LzUNuTZqA</UR></M1>";
              

                        for (int i = 0; i < e.Result.Count; i++)
                        {
                            string frase = e.Result[i].MetaKey;
                            string LAT = GetBetween(frase, "<LA>", "</LA>", 0);
                            string LON = GetBetween(frase, "<LO>", "</LO>", 0);
                            string RAI = GetBetween(frase, "<RA>", "</RA>", 0);
                            string URI = GetBetween(frase, "<UR>", "</UR>", 0);
                            string IDI = GetBetween(frase, "<LG>", "</LG>", 0);
                            string COD = GetBetween(frase, "<NU>", "</NU>", 0);
                            string ATV = GetBetween(frase, "<AT>", "</AT>", 0);
                            string DTI = GetBetween(frase, "<DI>", "</DI>", 0);
                            string DTF = GetBetween(frase, "<DF>", "</DF>", 0);

                            bool achou = false;

                            foreach (App.Filmes x in App.ListaFilmes)
                            {

                                if (x.codigo == Convert.ToInt32(COD))
                                {
                                    achou = true;
                                    x.ativo = Convert.ToInt32(ATV);
                                    x.codigo = Convert.ToInt32(COD);
                                    x.datini = DTI;
                                    x.datfim = DTF;
                                    x.idioma = IDI;
                                    x.lati = LAT;
                                    x.longi = LON;
                                    x.raio = RAI;
                                    x.URI = URI;

                                }

                            }

                            if (achou == false)
                            {
                                App.ListaFilmes.Add(new App.Filmes() { ativo = Convert.ToInt32(ATV), codigo = Convert.ToInt32(COD), datini = DTI, datfim = DTF, idioma = IDI, lati = LAT, longi = LON, raio = RAI, URI = URI });
                            }



                        }


                        Executa_Pega_Filme_Default();
                        ligadesliga_busy(false, "");

                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                ligadesliga_busy(false, "");

                //return;
            }



            ligadesliga_tray(false, "");
            ligadesliga_busy(false, "");


            */

        }





        public void Executa_Pega_Filme_Default()
        {

/*

            ligadesliga_busy(true, "Get default motions...");
            ligadesliga_tray(true, "Get default motions...");



            if (temFilme == true) {

               //  Executa_Manda_Promocao();
                 
                
                return; }


            string chave56 = "%<LG>default</LG>%";

            try
            {
                client5.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(pega_filme_default);
                client5.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "40075000", "-1", "-1", "100", chave56, "", "-1", "0", "999", "0", "DESC", "true");
            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");
                return;
            }

            */

        }


        void pega_filme_default(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {


            /*


            try
            {


                if (e.Error == null)
                {

                    if (e.Result != null)
                    {

                        if (e.Result.Count > 0)
                        {
                            //App.ListaFrases.Clear();                            
                        }


                        for (int i = 0; i < e.Result.Count; i++)
                        {
                            string frase = e.Result[i].MetaKey;
                            string LAT = GetBetween(frase, "<LA>", "</LA>", 0);
                            string LON = GetBetween(frase, "<LO>", "</LO>", 0);
                            string RAI = GetBetween(frase, "<RA>", "</RA>", 0);
                            string URI = GetBetween(frase, "<UR>", "</UR>", 0);
                            string IDI = GetBetween(frase, "<LG>", "</LG>", 0);
                            string COD = GetBetween(frase, "<NU>", "</NU>", 0);
                            string ATV = GetBetween(frase, "<AT>", "</AT>", 0);
                            string DTI = GetBetween(frase, "<DI>", "</DI>", 0);
                            string DTF = GetBetween(frase, "<DF>", "</DF>", 0);

                            bool achou = false;

                            foreach (App.Filmes x in App.ListaFilmes)
                            {

                                if (x.codigo == Convert.ToInt32(COD))
                                {
                                    achou = true;
                                    x.ativo = Convert.ToInt32(ATV);
                                    x.codigo = Convert.ToInt32(COD);
                                    x.datini = DTI;
                                    x.datfim = DTF;
                                    x.idioma = IDI;
                                    x.lati = LAT;
                                    x.longi = LON;
                                    x.raio = RAI;
                                    x.URI = URI;

                                }

                            }

                            if (achou == false)
                            {
                                App.ListaFilmes.Add(new App.Filmes() { ativo = Convert.ToInt32(ATV), codigo = Convert.ToInt32(COD), datini = DTI, datfim = DTF, idioma = IDI, lati = LAT, longi = LON, raio = RAI, URI = URI });
                            }



                            App.Retira_da_Lista();
                          //  Executa_Manda_Promocao();
              



                        }

                    }

                }

                else
                {
                    MessageBox.Show(Localization.m02.ToString());
                    ligadesliga_tray(false, "");

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(Localization.m02.ToString());
                ligadesliga_tray(false, "");

                return;
            }



            ligadesliga_tray(false, "");


            */

        }















        private static string GetBetween(string Input, string Start, string End, int Index = 0) 
            {

                int pos = Input.IndexOf(Start);
                int pos1 = Input.IndexOf(End);
                int respo = pos1 - pos;
                string teste = "";
            
            
            
            if (respo == 4) 
            {
                teste = "<>";
            } else
            {
                 teste = Regex.Matches(Input, string.Format("{0}(.+?){1}", Start, End))[Index].Groups[0].Value;
            }
                return StripTagsRegex(teste);
            }


            public static string StripTagsRegex(string source)
            {
                return Regex.Replace(source, "<.*?>", string.Empty);
            }



            public class promo
            {
                public string chave { get; set; }
                public string lat { get; set; }
                public string lon { get; set; }
                public string premio { get; set; }



            }
            public static List<promo> ListaPromo = new List<promo>();



            public void Executa_Manda_Promocao()
            {


                ligadesliga_busy(true, "Send QR Code if exists...");
                ligadesliga_tray(true, "Send QR Code if exists...");


                conta5 = 0;

                ListaPromo.Clear();

                this.Dispatcher.BeginInvoke(() => { ligadesliga_tray(true, Localization.m33.ToString()); });




                foreach(App.qrpromocao x in App.QRPromocao)
                {
                    ListaPromo.Add(new promo() { chave = "<P1><EM>" + App.Conf[0].EmailUsu + "</EM><AT>1</AT><DT>" + x.datahoje + "<LC>" + x.local + "</LC><LA>" + x.latitude + "</LA><LO>" + x.longitude + "</LO><L1>" + x.qr_linha01 + "</L1><L2>" + x.qr_linha02 + "</L2><L3>" + x.qr_linha03 + "</L3><L4>" + x.qr_linha04 + "</L4></P1>", lat = x.latitude, lon = x.longitude, premio=x.qr_linha04 });
                }

                //string chave = "<P1><EM>fulano@.com</EM><AT>1</AT><DT>2012/09/27</DT><LC>nome local</LC><LA></LA><LO>0.00</LO><L1></L1><L2></L2><L3></L3><L4></L4></P1>";




                //string valor = "100";
                string lat1 = App.LocLat;
                string lon1 = App.LocLon;
                try
                {
                    client1.Service.MetaData_ApplicationMetaDataCounter_IncrementCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs>(User_CheckIn_Pro3);

                    soma5 = 0;
                    foreach (promo j in ListaPromo)
                    {

                        client1.Service.MetaData_ApplicationMetaDataCounter_IncrementAsync(Constants.AppName, Constants.AppPass, j.chave, j.premio, j.lat, j.lon, "", "");
                        soma5 = soma5 + 1;
                    }
                
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ligadesliga_tray(false, "");
                    ligadesliga_busy(false, "");
                    return;
                }






            }




            void User_CheckIn_Pro3(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataCounter_IncrementCompletedEventArgs e)
            {

                if (e.Error == null)
                {


                    if (e.Result != null)
                    {

                        conta5 = conta5 + 1;

                        if (soma5 == conta5)
                        {
                            Executa_Pega_Premio();
                            ligadesliga_busy(false, "");
                        }
              



                    }



                }
            }

            private void image1_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {

            }






    }
}