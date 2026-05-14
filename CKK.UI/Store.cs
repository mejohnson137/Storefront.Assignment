using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        readonly List<StoreItem> Items = new();
        public StoreItem AddStoreItem(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
            StoreItem? item = FindStoreItemById(product.Id);
            if (item?.GetProduct()?.Id == product.Id)
            {
                item.SetQuantity(item.GetQuantity() + quantity);
                return item;
            }
            else
            {
                StoreItem neu = new(product, quantity);
                {
                    Items.Add(neu);
                    return neu;
                }
            }
        }
        public StoreItem? RemoveStoreItem(int id, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("");
            }
            if (Items.Count < 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
            StoreItem? temp = FindStoreItemById(id);
            if (temp == null)
            {
                throw new ProductDoesNotExistException("");
            }
            if (id == temp!.GetProduct()!.Id)
            {
                int total = temp.GetQuantity() - quantity;
                if (total > 0)
                {
                    temp.SetQuantity(total);
                }
                else
                {
                    temp.SetQuantity(0);
                }
            }
            return temp;
        }
        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }
        public StoreItem? FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException("");
            }
            if (Items.Count < 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
            var temp = from item in Items
                       where item.GetProduct()?.Id == id
                       select item;
            if (temp != null)
            {
                return temp?.FirstOrDefault();
            }
            else return null;
        }
    }
}