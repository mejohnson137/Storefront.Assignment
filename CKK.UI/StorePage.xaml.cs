using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;


namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for StorePage.xaml
    /// </summary>
    public partial class StorePage : Window
    {
        public List<StoreItem>? _Items;

        public StorePage()
        {
            InitializeComponent();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPage add = new AddPage();
            add.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            object temp = Items_List.SelectedItem;
            Product found = (Product)temp;
            EditPage edit = new EditPage(found.Id);
            edit.Show();
            this.Close();
        } 

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("are you sure you want to remove this item?", "Item removal", MessageBoxButton.YesNo);

            object temp = Items_List.SelectedItem;
            Product found = (Product)temp;
            Store store = new();
            store.RemoveStoreItem(found.Id, 1);
        }

        private void SearchBar_KeyDown(object? sender, KeyEventArgs e)
        {
            string? search = Convert.ToString(sender);
        }

    }
}
