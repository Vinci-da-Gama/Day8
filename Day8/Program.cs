using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Day8.FetchAllCustomers;
using Day8.AdapterAllCustomers;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a for Selecting All Customers --- b for Selecting All Customer from Dataset. --- c for Inserting new row to Customers Table.");
            char InputedKey = Console.ReadKey().KeyChar;
            Console.WriteLine("19 -- "+InputedKey);
            string SpAllCustomers = "SelectAllCustomers";
            string InsertText = "INSERT INTO Customers ([First_Name], [Last_Name], [Email], Gender, Zip, [State], [Join_Date], CreditLimit) VALUES (@Fn, @Ln, @Email, @G, @Zip, @State, @Jd, @Cl)";

            switch (InputedKey)
            {
                case 'a':
                    Console.WriteLine("Cmd A for Selecting All Customers. Please wait for a while.");
                    GetAllCustomersBySp AllCustomers = new GetAllCustomersBySp(SpAllCustomers);
                    AllCustomers.PrintOutAllCustomersFirstNameAndLastName();
                    break;
                case 'b':
                    GetCustomersByAdapter GetCustomers = new GetCustomersByAdapter(SpAllCustomers);
                    Console.WriteLine("Cmd b for Selecting All Customers. please wait for a while.");
                    GetCustomers.PrintCustomersByAdapter();
                    break;
                case 'c':
                    AdapterInsertUpdateDelete AdapterInsert = new AdapterInsertUpdateDelete(InsertText);
                    Console.WriteLine("Cmd c for Insert New Customer --> Then print all Customers.");
                    AdapterInsert.InsertByAdapter();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
