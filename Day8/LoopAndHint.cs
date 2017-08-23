using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day8
{
    class LoopAndHint
    {
        private SqlDataReader DbReader { get; set; }
        private DataSet Ds { get; set; }
        public LoopAndHint(SqlDataReader dbReader)
        {
            this.DbReader = dbReader;
        }
        public LoopAndHint(DataSet ds)
        {
            this.Ds = ds;
        }

        public void DbReaderLoop()
        {
            while (this.DbReader.Read())
            {
                Console.WriteLine(this.DbReader[1]+" -- "+this.DbReader[2]);
            }
        }

        public void ListDataSetLoop()
        {
            foreach (DataRow cRow in Ds.Tables[0].Rows)
            {
                Console.WriteLine(String.Format("FirstName: {0} -- LastName: {1} ", cRow["First_Name"], cRow["Last_Name"]));
            }
        }

        public void ListCustomersLoop()
        {
            foreach (DataRow cRow in Ds.Tables[0].Rows)
            {
                Console.WriteLine(String.Format("FirstName: {0} -- LastName: {1} -- Email: {2} -- Gender: {3} -- Zip: {4} -- State: {5} -- Join_Date: {6} -- CreditLimit: {7} -- CustomerId: {8}.", cRow["First_Name"], cRow["Last_Name"], cRow["Email"], cRow["Gender"], cRow["Zip"], cRow["State"], cRow["Join_Date"], cRow["CreditLimit"], cRow["CustomerId"]));
            }
        }
    }
}
