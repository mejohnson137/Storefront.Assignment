using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException(string message) : base(message)
        {
            Console.WriteLine("Product does not exist.");
            Console.ReadLine();
        }
    }
}
