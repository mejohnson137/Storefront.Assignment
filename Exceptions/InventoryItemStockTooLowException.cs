using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException(string message) : base(message)
        {
            Console.WriteLine("Inventory stock too low to complete task.");
            Console.ReadLine();
        }
    }
}
