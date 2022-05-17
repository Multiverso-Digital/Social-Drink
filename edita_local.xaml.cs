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
using Telerik.Windows.Controls;
//using Telerik.Examples.WP.MessageBox;

namespace Social_Drink
{
    public partial class edita_local : PhoneApplicationPage
    {
        public edita_local()
        {
            InitializeComponent();

            List<App.locais> sorte = new List<App.locais>();
            sorte = App.LocaisGoogle;
            var sortex = (from x in sorte
                          where x.name != App.LocName
                          orderby x.distancia ascending
                          select x).ToList();
            lb2.ItemsSource = sortex;

            eMuda.Text = App.LocName;

        }




        private void muda_local(App.locais sele)
        {


            foreach (App.locais x in App.LocaisGoogle)
            {

                if (x.name == App.LocName)
                {                   
                    x.name = sele.name;
                    x.address = sele.address;
                    x.cida = sele.cida;
                    x.pais = sele.pais;
                    x.idlocal = sele.idlocal;
                    x.latitude = sele.latitude;
                    x.longitude = sele.longitude;
                    x.icon = sele.icon;
                    x.img = sele.img;
                    x.reference = sele.reference;
                    x.tipo = sele.tipo;
                    x.distStr = sele.distStr;
                }

            }


            for (int i = 0; i <= App.ListaShot.Count - 1; i++)
            {

                if (App.ListaShot[i].local == App.LocName)
                {

                    App.ListaShot.RemoveAt(i);

                }
            }


            for (int i = 0; i <= App.LocaisUsu.Count - 1; i++)
            {



                if (App.LocaisUsu[i].name == App.LocName)
                {

                    App.LocaisUsu.RemoveAt(i);

                }
            }




            MessageBox.Show(Localization.m107);


        }



        private void lb2_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {



            App.locais sele = lb2.SelectedItem as App.locais;






            var result = MessageBox.Show(Localization.m131.ToString(), Localization.m130.ToString(), MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                muda_local(sele);
            }
            else
            {
                
                
            }










            
            
            
        
            // App.PoeShots(App.LocID, App.LocName);


            //Executa_Set_CheckTot();

            //App.AdicionaLocal();
        }
    }
}