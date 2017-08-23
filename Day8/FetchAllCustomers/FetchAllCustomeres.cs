using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day8.FetchAllCustomers
{
    class GetAllCustomersBySp: DbConnection
    {
        public string SpCmd { get; set; }
        public GetAllCustomersBySp(string cmd)
        {
            SpCmd = cmd;
        }

        public void PrintOutAllCustomersFirstNameAndLastName()
        {
            //Step1 - Handshake with database
            //string DataConnStr = "Data Source=LUCIFER-PC\\SQLEXPRESS;Initial Catalog=Day8_Db;Integrated Security=True";
            DbConnection DbStr = new DbConnection();
            string DataConnStr = DbStr.ConnectToDbString();
            SqlConnection DbConnection = new SqlConnection(DataConnStr);
            DbConnection.Open();

            //Step2 - Spedify command
            SqlCommand myCmd = DbConnection.CreateCommand();
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = SpCmd;

            SqlDataReader myDbReader;
            myDbReader = myCmd.ExecuteReader();

            //Step3 - Use Database
            LoopAndHint whileLoop = new LoopAndHint(myDbReader);
            whileLoop.DbReaderLoop();

            DbConnection.Close();
        }
    }
}
