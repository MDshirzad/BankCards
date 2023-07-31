using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
        }

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            dispatcherTimer.Start();

        }
        int t = 0;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

           
            t += 1;
            if (t == 28)

            {
                TextConst.Text = "در حال اتصال به پایگاه داده";


            }
            else if (t == 30)
            {
                Controller.PersonController personController = new Controller.PersonController();
                personController.Readall();

            }
            else if (t == 32)
            {
                TextConst.Text = "در حال آماده سازی";

            }
            else if (t > 40 && t < 50)
            {
                TextConst.Text = "خوش آمدید";
            }
            else if (t == 50)
            {

                dispatcherTimer.Stop();
                MainWindow w = new MainWindow();
                w.Show();
                this.Close();
            }
            else
            {

                TextConst.Opacity += 0.08;
                blref.Radius -= 0.4;


                if (t == 45)
                {
                    blref.Radius = 1;
                    TextConst.Opacity += 1;

                }


            }



        }
    }
}
