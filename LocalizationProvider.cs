using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Social_Drink
{



    public class LocalizationProvider
    {
        private readonly Localization _Resources = new Localization();

        public Localization Resources
        {
            get { return _Resources; }
        }
    }

}
