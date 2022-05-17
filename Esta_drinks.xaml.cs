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
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using System.Globalization;
using Buddy;
//using Telerik.Examples.WP.Chart;



namespace Social_Drink
{
    public partial class Esta_drinks : PhoneApplicationPage
    {

       // private ObservableCollection<ChartBusinessObject> itemsSource;
       // private ObservableCollection<ChartBusinessObject> itemsSource2;

        private DispatcherTimer timer;
        private DateTime lastDate;
        private Random random = new Random();
        private double valor = 0;
       
        private int contando = 0;

        public Esta_drinks()
        {
            InitializeComponent();
           
            
            
            
            
            
            
            
            
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(1000);
            this.timer.Tick += this.OnTimer;

            contando = 0;
           

            FillData();

            CategoricalSeries series = this.radChart1.Series[0] as CategoricalSeries;
            series.ValueBinding = new GenericDataPointBinding<ChartBusinessObject, double>() { ValueSelector = obj => obj.Value };
            series.CategoryBinding = new GenericDataPointBinding<ChartBusinessObject, object>() { ValueSelector = obj => obj.Category };
            this.radChart1.DataContext = this.itemsSource;



           

            
            
            this.timer.Start();

        }









        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e) 
        { 
            base.OnBackKeyPress(e); 
            if (NavigationService.CanGoBack) 
            { 
                e.Cancel = true;
                this.timer.Stop();
                NavigationService.GoBack(); 
            } 
        }





        private void FillData()
        {
            this.itemsSource = new ObservableCollection<ChartBusinessObject>();
            this.itemsSource2 = new ObservableCollection<ChartBusinessObject>();

            this.lastDate = DateTime.Now;
            for (int i = 0; i < 51; i++)
            {
                this.lastDate = this.lastDate.AddMilliseconds(500);
                this.itemsSource.Add(this.CreateBusinessObject(valor));
                
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {

            ListaDrinks();
            this.lastDate = this.lastDate.AddMilliseconds(500);
            this.itemsSource.RemoveAt(0);
            this.itemsSource.Add(this.CreateBusinessObject(valor));

           

            contando = contando + 1;
            tTotal.Text = contando.ToString()+"s";
            if (contando >= 50) {
                ApplicationBar.IsVisible = true;
          
                 this.timer.Stop();
            }


        }

/*
        
        private ChartBusinessObject CreateBusinessObject(double valor)
        {
            ChartBusinessObject obj = new ChartBusinessObject();

            obj.Value =  valor;//                this.random.Next(15, 55);
            obj.Category = this.lastDate;
            return obj;
        }

        */



        private void ListaDrinks()
        {

            string monta = "<A5><A5_datadrink>" + String.Format("{0:MM/dd/yyyy}", DateTime.Now) + "</A5_datadrink></A5>";

            try
            {

                BuddyClient client2 = new BuddyClient(Constants.AppName, Constants.AppPass);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataCompleted += new EventHandler<Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs>(Get_ApplicationMeta_Drinks);
                client2.Service.MetaData_ApplicationMetaDataValue_SearchDataAsync(Constants.AppName, Constants.AppPass, "10000000", "0.000000", "0.000000", "50", monta, "", "-1", "0", "999999", "1", "DESC", "true");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(Localization.m02.ToString());
                return;
            }
        }

        void Get_ApplicationMeta_Drinks(object sender, Buddy.BuddyService.MetaData_ApplicationMetaDataValue_SearchDataCompletedEventArgs e)
        {



            if (e.Error == null)
            {
                if (e.Result.Count == 0)
                {
                }
                else
                {

                   valor = Convert.ToDouble(e.Result[0].MetaValue);

                    tTotDrink.Text =  String.Format("{0:0.##}", valor);


                }

            }

                   

       }



        
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {


              contando = 0;
              tTotal.Text = contando.ToString()+"s";
              ApplicationBar.IsVisible = false; 
              this.timer.Start();


        }



    }
}