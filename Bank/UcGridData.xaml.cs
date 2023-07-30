using Bank.Controller;
using Bank.Model.Entity;
using Bank.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using MessageBox = System.Windows.MessageBox;

namespace Bank
{
    /// <summary>
    /// Interaction logic for GridData.xaml
    /// </summary>
    public partial class GridData : UserControl
    {
        #region Instances
        public ObservableCollection< PersonView> Collection { get; set; }
        PersonView prs = new PersonView();
     
        PersonController personController = new PersonController();
        #endregion
        public GridData()
        {
            Collection = new ObservableCollection<PersonView>();
            InitializeComponent();
        }

      

        private void UcGridDatatable_Loaded(object sender, RoutedEventArgs e)
        {
            var PeopleData = personController.Readall();
            BindGrid(PeopleData);



        }

        private void BindGrid(List<Person> PeopleData) {


            DataGrid.ItemsSource = null;
            Collection.Clear();
            foreach (Person person in PeopleData)
            {

                prs.Id = person.Id;
                prs.CardsNumber = person.Cards[0].CardNumber;
                prs.RegDate = person.Cards[0].RegistrationDate;
                prs.Family = person.Family;
                prs.Name = person.Name;
                Collection.Add(prs);
                prs = new PersonView();
            }
            DataGrid.ItemsSource = Collection;
        }

        private void delBtnContextMenu_Click(object sender, RoutedEventArgs e)
        {
           
           
            var RowSelected = DataGrid.SelectedItem;
            if (RowSelected!= null) {
                MessageBoxResult resultMsg;

                resultMsg = MessageBox.Show( "آیا از حذف اطمینان دارید؟", "اخطار", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (resultMsg == MessageBoxResult.Yes) {
                    MessageBox.Show( "رکورد حذف شد", "پیغام", MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchData = personController.Read(searchTxt.Text);
            BindGrid(searchData);
        }
    }
}
