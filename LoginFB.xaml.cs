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
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Social_Drink
{
    public partial class LoginFB : PhoneApplicationPage
    {


        private const string ExtendedPermissions = "user_about_me,publish_stream,email,read_friendlists";
        private readonly FacebookClient _fb = new FacebookClient();
 
        
        
        
        
        // Constructor
        public LoginFB()
        {
            InitializeComponent();

            App.Passou = true;

            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = FacebookSettings.AppID;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "page";
            parameters["scope"] = ExtendedPermissions;
            BrowserControl.Navigate(_fb.GetLoginUrl(parameters));



        }

        private void Browser_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void LoginSucceded(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                string json = result.ToString();
               
                var id = (string)result["id"];
                var email = (string)result["email"];
                var name = (string)result["name"];
                var first_name = (string)result["first_name"];
                var last_name = (string)result["last_name"];
               // var picture = (string)result["picture"]["data"]["url"];


                JToken picture = JObject.Parse(json)["picture"]["data"]["url"];

                FacebookAccess FBA = new FacebookAccess();

                FBA.AccessToken = accessToken;
                FBA.UserId = id;
                FBA.picture = picture.ToString();
                FBA.email = email;
                FBA.name = name;
                FBA.first_name = first_name;
                FBA.last_name = last_name;



                App.Conf[0].FB_Token = accessToken; ;
                App.Conf[0].FB_UserID = id;
                App.Conf[0].EmailUsu = email;
                App.Conf[0].NomeUsu = name;


                Dispatcher.BeginInvoke(() => NavigationService.GoBack());
                


            };

            fb.GetAsync("me?fields=id,name,first_name,last_name,picture,email");
        }



        private void Browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                LoginSucceded(accessToken);
            }
            else
            {
                MessageBox.Show(oauthResult.ErrorDescription);
            }

        }


    public class FacebookSettings
    {
            public static string AppID = "368445269888525";
            public static string AppSecret = "f8d8bdbc4ff3edf22906bf55d635df9c";
    }

     public class FacebookAccess
    {
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string picture { get; set; }
        public string email { get; set; }
    }



        


     public static void SaveSetting<T>(string fileName, T dataToSave)
     {
         using (var store = IsolatedStorageFile.GetUserStoreForApplication())
         {
             try
             {
                 using (var stream = store.CreateFile(fileName))
                 {
                     var serializer = new DataContractSerializer(typeof(T));
                     serializer.WriteObject(stream, dataToSave);
                 }
             }
             catch (Exception e)
             {
                 MessageBox.Show(e.Message);
                 return;
             }
         }
     }

        




    }
}