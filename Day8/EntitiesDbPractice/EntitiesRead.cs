using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.EntitiesDbPractice
{
    class EntitiesRead
    {
        public static void DisplayCustomerFirstName()
        {
            Day8_DbEntities d8e = new Day8_DbEntities();

            var Customer = from c in d8e.Customers
                           where c.CustomerId == 1
                           select c;

            Console.WriteLine(String.Format("19 -- Customer FirstName is: {0}.", Customer.First().First_Name));
        }
    }
}
