using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day8.AdapterAllCustomers
{
    class GetCustomersByAdapter: DbConnection
    {
        public string SpCmd { get; set; }
        public GetCustomersByAdapter(string cmd)
        {
            SpCmd = cmd;
        }

        public void PrintCustomersByAdapter()
        {
            // Step1 -- Open Connection.
            DbConnection DbStr = new DbConnection();
            string DbConnStr = DbStr.ConnectToDbString();
            SqlConnection DbConn = new SqlConnection(DbConnStr);
            DbConn.Open();

            // Step2 -- Speficy Command
            SqlCommand DbCmd = DbConn.CreateCommand();
            DbCmd.CommandType = CommandType.StoredProcedure;
            DbCmd.CommandText = SpCmd;
            // DbCmd.CommandTimeout = 60;

            SqlDataAdapter AllCustomersDataAdapter = new SqlDataAdapter(DbCmd);
            DataSet ACDataSet = new DataSet();
            AllCustomersDataAdapter.Fill(ACDataSet);
            DbConn.Close();

            // setp 3 -- list rows
            LoopAndHint foreachLoop = new LoopAndHint(ACDataSet);
            foreachLoop.ListDataSetLoop();

            Console.ReadLine();
            
        }
    }
}
