using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        public StoreItem AddStoreItem(Product product, int quantity)
        {
            return AddStoreItem(product, quantity);
        }
        public StoreItem? RemoveStoreItem(int id, int? quantity)
        {
            return RemoveStoreItem(id, quantity);
        }
        public StoreItem? FindStoreItemById(int id)
        {
            return FindStoreItemById(id);
        }
        public List<StoreItem> GetStoreItems()
        {
            return GetStoreItems();
        }
    }
}
