using System.Windows.Controls;

namespace Social_Drink
{
    public partial class CustomHeaderedContentControl : UserControl
    {
        public CustomHeaderedContentControl()
        {
            InitializeComponent();
        }

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
