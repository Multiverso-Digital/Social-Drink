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
using System.IO;

namespace Social_Drink
{
    public partial class web_browser : PhoneApplicationPage
    {
        public web_browser()
        {

            string site = "";

            InitializeComponent();



            site = "politica_privacidade_en-US.html";
            if (App.Conf[0].Idioma == "pt-BR") {site = "politica_privacidade_pt-BR.html";};
            if (App.Conf[0].Idioma == "pt-PT") {site = "politica_privacidade_pt-BR.html";};
            if (App.Conf[0].Idioma == "es-ES") { site = "politica_privacidade_es-ES.html"; };
       

                
                var rs = Application.GetResourceStream(new Uri(site, UriKind.Relative));
                StreamReader sr = new StreamReader(rs.Stream);
                webBrowser1.NavigateToString(sr.ReadToEnd());
                
                
               
                
            
     

        }
    }
}