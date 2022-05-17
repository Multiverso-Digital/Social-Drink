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
    public class CustomHeaderedContentControl
    {
        
        public string Title
        {
            get
            {
                return this.title.Text;
            }

            set
            {
                this.title.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message.Text;
            }

            set
            {
                this.message.Text = value;
            }
        }
    }
}
