using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace ConsoleApplication1
{

    [DebuggerDisplay("Customer (ID={ID}, Name={Name})")]
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

   class Program
    {          
        static void Main(string[] args)
        {
            Customer c = new Customer { ID = 1, Name = "John" };
            Console.WriteLine(c);
        }


    }
}
