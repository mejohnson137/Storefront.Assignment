using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Window
    {
        public string? _Name = "";
        public int _Id = 0;
        public decimal _Price = 0.00M;
        public int _Quantity = 0;
        public EditPage(int findId)
        {
            InitializeComponent();
            _Id = findId;
            //StoreItem? item = Store.FindStoreItemById(findId);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            StorePage store = new StorePage();
            store.Show();
            this.Close();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This was optional so I just put this here for now...");
        }
    }
}
