using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Day8.EntitiesDbPractice
{
    class EntityWithStoreProcedures
    {
        public void ShowMenuWithSp()
        {
            bool isRun = true;
            while(isRun) {
                isRun = displayMenu();
            }
        }

        #region Private Static displayMenu
        private static bool displayMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press 1. show 3 types Ids");
            Console.WriteLine("Press 2. Add New Product");
            Console.WriteLine("Press Other Keys. Other Key Restart...");
            Console.WriteLine("Press 3. Exit.");
            Console.WriteLine("---------------------------\n");
            string MenuCmd = Console.ReadLine();
            
            switch (MenuCmd)
            {
                case "1":
                    Display3Ids();
                    break;
                case "2":
                    InsertNewProduct();
                    break;
                case "3":
                    //so break while loop...
                    return false;
                default:
                    Console.WriteLine("Please 1, 2, or 3... Press Other Enter to Continue...");
                    Console.ReadLine();
                    break;
            }
            return true;
        }
        #endregion

        #region Display3Ids Function  
        private static void Display3Ids()
        {
            Console.WriteLine("Display 3 ids...\n");

            // Step 1: Handshake Database
            SqlConnection copConnection = new SqlConnection("Data Source=LUCIFER-PC\\SQLEXPRESS;Initial Catalog=Day8_Db;Integrated Security=True");
            copConnection.Open();

            // Step 2: Specify Request
            SqlCommand Read3IdsCmd = copConnection.CreateCommand();
            SqlDataReader Read3IdsReader;

            // Step 3: Apply Store Procedure & Params
            Read3IdsCmd.CommandText = "ThreeInnerJoin";
            Read3IdsCmd.CommandType = CommandType.StoredProcedure;
            // Read3IdsCmd.Parameters.Add(...);
            Read3IdsReader = Read3IdsCmd.ExecuteReader();

            // Step 4: Loop through it
            while(Read3IdsReader.Read()) {
                Console.WriteLine(String.Format("CustomerId: {0} --- OrderId: {1} --- ProductId: {2}.", Read3IdsReader[0], Read3IdsReader[1], Read3IdsReader[2]));
            }

            // Step 5: Disconnect
            copConnection.Close();

            Console.WriteLine("Press Enter to Contunue...");
        }
        #endregion

        private static void InsertNewProduct()
        {
            Console.WriteLine("InsertNewProduct...\n");
            Console.WriteLine("Please Input a Product Name...");
            string ProductName = Console.ReadLine();

            // Step 1: Handshake Database
            SqlConnection pConnection = new SqlConnection("Data Source=LUCIFER-PC\\SQLEXPRESS;Initial Catalog=Day8_Db;Integrated Security=True");
            pConnection.Open();

            // Step 2: Specify Request
            SqlCommand InsertCmd = pConnection.CreateCommand();

            // Step 3: Cmd & Params
            InsertCmd.CommandType = CommandType.StoredProcedure;
            InsertCmd.CommandText = "InsertNewProduct";
            InsertCmd.Parameters.Add(new SqlParameter("@PdName", ProductName));

            // Step 4: Show Result
            int rowAffected = InsertCmd.ExecuteNonQuery();

            if(rowAffected == 1) {
                Console.WriteLine("\nThere one new product is inserted.");
            } else {
                Console.WriteLine("\nInjection Error...");
            }

            // Step 5: Disconnect
            pConnection.Close();

            Console.WriteLine("Press Enter to Contunue...");
        }
    }
}
