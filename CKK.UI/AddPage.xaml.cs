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
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Window
    {
        public string _Name = "";
        public decimal _Price = 0.00M;
        public int _Quantity = 0;
        public ObservableCollection<StoreItem> Observe = new();
        public AddPage()
        {
            InitializeComponent();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            StorePage store = new StorePage();
            store.Items_List.ItemsSource = Observe;
            store.Show();
            this.Close();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            string temp;
            temp = TypeName.Text;
            _Name = Convert.ToString(temp);
            temp = TypePrice.Text;
            _Price = Convert.ToDecimal(temp);
            temp = TypeQuantity.Text;
            _Quantity = Convert.ToInt32(temp);
            Entity entity = new Entity();
            entity.Name = _Name;
            Product product = new(entity);
            product.Price = _Price;
            Store store = new Store();
            StoreItem pass = new StoreItem(product, _Quantity);
            store.AddStoreItem(product, _Quantity);
            Observe.Add(pass);
        }
    }
}
