using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        public int GetCustomerId()
        {
            return GetCustomerId();
        }
        public ShoppingCartItem AddProduct(Product product, int quantity)
        {
            return AddProduct(product, quantity);
        }
        public ShoppingCartItem? RemoveProduct(int id, int quantity)
        {
            return RemoveProduct(id, quantity);
        }
        public decimal GetTotal()
        {
            return GetTotal();
        }
        public ShoppingCartItem? GetProductById(int id)
        {
            return GetProductById(id);
        }
        List<ShoppingCartItem> GetProducts()
        {
            return GetProducts();
        }
    }
}
