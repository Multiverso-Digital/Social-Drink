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
using System.IO.IsolatedStorage;

namespace Social_Drink
{
    public partial class NewMarca : PhoneApplicationPage
    {
        public NewMarca()
        {
            InitializeComponent();
            eBebida.Text = App.bebida;

            RadJumpList1.ItemsSource = App.LDelete.ToList();

            if (RadJumpList1.ItemCount > 0)
            {
            
                eSelAll.Visibility = Visibility.Visible;

            } else

            {
            eSelAll.Visibility = Visibility.Collapsed;
            }


        }

        private void OK_Button(object sender, EventArgs e)
        {


            if (RadJumpList1.CheckedItems.Count > 0)
            {


                for (int j = 0; j <= RadJumpList1.CheckedItems.Count-1; j++)
                {

                    App.OMarcas teste = RadJumpList1.CheckedItems[j] as App.OMarcas;



                    for (int i = 0; i <= App.LDelete.Count-1; i++)
                    {

                        if ((teste.Nome == App.LDelete[i].Nome) && (teste.Bebida == App.LDelete[i].Bebida))
                        {

                            App.LDelete.RemoveAt(i);

                        }

                    }

                }

            }



            if ((eMarca.Text.Trim().Length == 0) && (RadJumpList1.CheckedItems.Count == 0))
            {
                MessageBox.Show(Localization.m38.ToString());
                return;
            }






           if (eMarca.Text.Trim().Length > 0)
           {


            bool Tem = false;

            foreach (App.OMarcas x in App.LOutras)
            {
                if (x.Nome.Trim().ToUpper() == eMarca.Text.Trim().ToUpper())
                {
                    Tem = true;
                }
            }

            foreach (App.Marcas w in App.ListaMarcas)
            {
                if (w.Nome.Trim().ToUpper() == eMarca.Text.Trim().ToUpper())
                {
                    Tem = true;
                }
            }





            if (Tem == false)
            {
                App.LOutras.Add(new App.OMarcas() { Bebida = App.bebida, img = App.img, Nome = eMarca.Text });
            }
            else
            {
                MessageBox.Show(Localization.m39.ToString());
                return;
            }

   
           

           }





            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }



        }

        private void eMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {        // focus the page in order to remove focus from the text box        // and hide the soft keyboard        t
                this.Focus();
            }
        }

        private void RadJumpList1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {

        }

        private void eSelAll_Click(object sender, RoutedEventArgs e)
        {
            if (eSelAll.IsChecked == true) 
            {

                RadJumpList1.CheckedItems.CheckAll();

            } else

            {
                RadJumpList1.CheckedItems.UncheckRange(0, RadJumpList1.ItemCount);
            }

        }
    }
}