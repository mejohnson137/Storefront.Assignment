using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace CKK.Logic.Exceptions
{
    
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message)
        {
            Console.WriteLine("Invalid Id given.");
            Console.ReadLine();
        }
    }
}
