using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly Customer Customer;
        private readonly List<ShoppingCartItem> Items = new();
        public ShoppingCart(Customer customer)
        {
            Customer = customer;
        }
        public int GetCustomerId()
        {
            return Customer.Id;
        }
        public ShoppingCartItem AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
          
            ShoppingCartItem? item = GetProductById(product.Id);
            if (item?.GetProduct()?.Id == product.Id && Items.Count > 0)
            {
                item.SetQuantity(item.GetQuantity() + quantity);
                return item;
            }
            else
            {
                ShoppingCartItem neu = new(product, quantity);
                {
                    Items.Add(neu);
                    return neu;
                }
            }
        }
        public ShoppingCartItem AddProduct(Product product)
        {
            return AddProduct(product, 1);
        }
        public ShoppingCartItem? RemoveProduct(int id, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Items.Count < 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
            ShoppingCartItem? temp = GetProductById(id);
            if (temp == null)
            {
                throw new ProductDoesNotExistException("");
            }
            if (quantity < temp?.GetQuantity())
            {
                int total = temp.GetQuantity() - quantity;
                temp.SetQuantity(total);
                return temp;
            }
            else if (quantity >= temp?.GetQuantity() && Items.Count > 0)
            {
                Items.Remove(temp);
                return new ShoppingCartItem(new Product(), 0);
            }
            else return null;
        }
        public ShoppingCartItem? GetProductById(int id)
        {
            if (id <= 0)
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
            return null;
        }
        public decimal GetTotal()
        {
            var grandTotal = 0m;
            var total =
                from e in Items
                where e != null
                select e;
            foreach (var element in total)
            {
                grandTotal += element.GetTotal();
            }
            return grandTotal;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            if (Items.Count < 0)
            {
                throw new InventoryItemStockTooLowException("");
            }
            return Items;
        }
    }
}