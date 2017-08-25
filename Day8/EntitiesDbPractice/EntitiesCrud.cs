using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.EntitiesDbPractice
{
    class EntitiesCrud
    {
        public void ShowMaxPricePerson()
        {
            Day8_DbEntities d8e = new Day8_DbEntities();

            var Customers = from c in d8e.Customers
                            where c.Orders.Any(o => o.OrderPrice > 90)
                            select c;
            foreach(var c in Customers) {
                Console.WriteLine(String.Format("Customer FirstName: {0} --- Customer LastName: {1} --- Order Count: {2}.", c.First_Name, c.Last_Name, c.Orders.Count.ToString()));
                foreach(var o in c.Orders) {
                    Console.WriteLine(String.Format("Price is: {0} -- Date is: {1}.\n", o.OrderPrice, o.OrderDate));
                }
            }
        }

    }
}
