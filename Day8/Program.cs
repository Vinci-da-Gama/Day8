using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step1 - Handshake with database
            string DataConnStr = "Data Source=LUCIFER-PC\\SQLEXPRESS;Initial Catalog=Day8_Db;Integrated Security=True";
            SqlConnection DbConnection = new SqlConnection(DataConnStr);
            DbConnection.Open();

            //Step2 - Spedify command
            string cmdSp = "SelectAllCustomers";
            SqlCommand myCmd = DbConnection.CreateCommand();
            myCmd.CommandText = cmdSp;
            myCmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader myDbReader;
            myDbReader = myCmd.ExecuteReader();

            //Step3 - Use Database
            while (myDbReader.Read())
            {
                Console.WriteLine(myDbReader[1]+" -- "+myDbReader[2]);
            }
            DbConnection.Close();

            Console.ReadLine();
        }
    }
}
