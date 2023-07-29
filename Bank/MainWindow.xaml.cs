using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Regex regex = new Regex("[^0-9]+");
        private string _cardNumber = "";

        #region MoveWindow
        private bool clicked = false;
        private Point lmAbs = new Point();
        void PnMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            clicked = true;
            this.lmAbs = e.GetPosition(this);
            this.lmAbs.Y = Convert.ToInt16(this.Top) + this.lmAbs.Y;
            this.lmAbs.X = Convert.ToInt16(this.Left) + this.lmAbs.X;
        }

        void PnMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            clicked = false;
        }

        void PnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (clicked)
            {
                Point MousePosition = e.GetPosition(this);
                Point MousePositionAbs = new Point();
                MousePositionAbs.X = Convert.ToInt16(this.Left) + MousePosition.X;
                MousePositionAbs.Y = Convert.ToInt16(this.Top) + MousePosition.Y;
                this.Left = this.Left + (MousePositionAbs.X - this.lmAbs.X);
                this.Top = this.Top + (MousePositionAbs.Y - this.lmAbs.Y);
                this.lmAbs = MousePositionAbs;
            }
        }

        #endregion


        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void SubmitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (CardNumberTxt.Text == "" || FamilyTxt.Text == "" || NameTxt.Text == "")
            {
                MessageBox.Show("فیلد های خالی را پر کنید");
            }
            else
            {
                MessageBox.Show("Save data");
            }

        }

        /// <summary>
        /// Check len of card number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardNumberTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            e.Handled = regex.IsMatch(e.Text);
            if (!e.Handled)
            {
                if (_cardNumber.Length >= 16)
                {
                    MessageBox.Show("طول شماره کارت بیش از 16 رقم است");
                    e.Handled = true;
                }
                else
                {
                    _cardNumber += e.Text;
                }

            }
            

        }

        /// <summary>
        /// Not working properly for back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardNumberTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (CardNumberTxt.Text=="")
            {
                _cardNumber = "";
            }
            else if (e.Key == Key.Back)
            {
               int lastIndex=_cardNumber.Length-1 ;
                if (lastIndex >= 0) { 
                _cardNumber.Remove(lastIndex);
                }
            }      
        }



        /// <summary ss>
        /// This method will seperate Card numbers by "-"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardNumberTxt_LostFocus(object sender, RoutedEventArgs e)
        {

            string cardNumber = _cardNumber;
          
            string seperatedCardNumber = "";
            int seperatorCounter = 0;
            int seperatorseries = 0; 

            foreach (var item in cardNumber)
            {
                seperatorCounter += 1;
                if (seperatorCounter==4)
                {
                    if (seperatorseries < 3) { 
                         seperatedCardNumber += item + "-";
                        seperatorseries += 1;
                         seperatorCounter = 0;
                    }
                    else { seperatedCardNumber += item; }
                }
                else { seperatedCardNumber += item; }


            }
            CardNumberTxt.Text = seperatedCardNumber;

            
        }

       

        
        private void ShowDataButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Data dataWindow= new Data();
            dataWindow.ShowDialog();
        }

        private void CloseButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
         
        }

        
    }
}
