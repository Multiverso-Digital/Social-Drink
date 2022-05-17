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

namespace Social_Drink
{
    public partial class Frases_Frase : PhoneApplicationPage
    {
        public Frases_Frase()
        {
            InitializeComponent();
        }

        private void textBox1_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string teste = textBox1.Text.ToString();
            eTotal.Text = teste.Length.ToString() + "/200";
        }

        private void save_button(object sender, EventArgs e)
        {
            App.Filme_Tipo = 1;
            App.Filme_Title = textBox1.Text.ToString();
            App.Filme_VideoImageUrl = "/images/frase_frase_lista.png";
            App.Filme_VideoId = eSel.SelectedItem.ToString();

            NavigationService.GoBack();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }

        }
    }
}