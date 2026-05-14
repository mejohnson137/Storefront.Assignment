using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using System.Xml.Linq;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        private Product? product;
        public Product? Product
        {
            get
            {
                return product;
            }
            set
            {
                if (value != null)
                {
                    product = value;
                }
            }
        }
        private int quantity;
        public int Quantity 
        {
            get
            {
                return quantity; 
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }
                else
                {
                    quantity = value;
                }
            } 
        }
    }
}
