using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day8.AdapterAllCustomers
{
    class AdapterInsertUpdateDelete: DbConnection
    {
        private string TextOrSp { get; set; }
        public AdapterInsertUpdateDelete(string cmd)
        {
            this.TextOrSp = cmd;
        }

        private SqlConnection StartConnection()
        {
            DbConnection DbStr = new DbConnection();
            string DbConnString = DbStr.ConnectToDbString();
            SqlConnection DbConn = new SqlConnection(DbConnString);
            DbConn.Open();
            return DbConn;
        }

        public void InsertByAdapter()
        {
            SqlConnection DbConn = this.StartConnection();
            // SqlCommand insertCmd = DbConn.CreateCommand();

            SqlDataAdapter Adapter = new SqlDataAdapter();

            Adapter.SelectCommand = DbConn.CreateCommand();
            Adapter.SelectCommand.CommandText = "Select * From Customers";

            Adapter.InsertCommand = DbConn.CreateCommand();
            Adapter.InsertCommand.CommandText = this.TextOrSp;
            // @Fn, @Ln, @Email, @G, @Zip, @State, @Jd, @Cl
            Adapter.InsertCommand.Parameters.Add("@Fn", SqlDbType.NVarChar, 50, "First_Name");
            Adapter.InsertCommand.Parameters.Add("@Ln", SqlDbType.NVarChar, 50, "Last_Name");
            Adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100, "Email");
            Adapter.InsertCommand.Parameters.Add("@G", SqlDbType.VarChar, 6, "Gender");
            Adapter.InsertCommand.Parameters.Add("@Zip", SqlDbType.Int, 3, "Zip");
            Adapter.InsertCommand.Parameters.Add("@State", SqlDbType.VarChar, 30, "State");
            Adapter.InsertCommand.Parameters.Add("@Jd", SqlDbType.SmallDateTime, 20, "Join_Date");
            Adapter.InsertCommand.Parameters.Add("@Cl", SqlDbType.Int, 4, "CreditLimit");

            Adapter.UpdateCommand = DbConn.CreateCommand();
            Adapter.UpdateCommand.CommandText = "Update Customers SET First_Name = @Fn, Last_Name = @Ln, Email = @Email, Gender = @G, Zip = @Zip, State = @State, Join_Date = @Jd, CreditLimit = @Cl Where CustomerId = @CustomerId";
            Adapter.UpdateCommand.Parameters.Add("@CustomerId", SqlDbType.Int, 4, "CustomerId");
            Adapter.UpdateCommand.Parameters.Add("@Fn", SqlDbType.NVarChar, 50, "First_Name");
            Adapter.UpdateCommand.Parameters.Add("@Ln", SqlDbType.NVarChar, 50, "Last_Name");
            Adapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100, "Email");
            Adapter.UpdateCommand.Parameters.Add("@G", SqlDbType.VarChar, 6, "Gender");
            Adapter.UpdateCommand.Parameters.Add("@Zip", SqlDbType.Int, 3, "Zip");
            Adapter.UpdateCommand.Parameters.Add("@State", SqlDbType.VarChar, 30, "State");
            Adapter.UpdateCommand.Parameters.Add("@Jd", SqlDbType.SmallDateTime, 20, "Join_Date");
            Adapter.UpdateCommand.Parameters.Add("@Cl", SqlDbType.Int, 4, "CreditLimit");

            Adapter.DeleteCommand = DbConn.CreateCommand();
            Adapter.DeleteCommand.CommandText = "Delete From Customers Where CustomerId = @CustomerId";
            Adapter.DeleteCommand.Parameters.Add("@CustomerId", SqlDbType.Int, 4, "CustomerId");

            // Adapter.InsertCommand.ExecuteNonQuery();
            DataSet CrudDs = new DataSet();
            Adapter.Fill(CrudDs);

            DbConn.Close();

            Console.WriteLine("Before -- DbConn is closed.");
            // Dispaly all Customers
            LoopAndHint listCustomers = new LoopAndHint(CrudDs);
            listCustomers.ListCustomersLoop();

            // This step will do some changes for DB
            // 1st -- Insert
            Random Random4Digits = new Random();
            Random Random3Digits = new Random();
            DataRow NewDsRow = CrudDs.Tables[0].NewRow();
            NewDsRow["First_Name"] = "Fn_Ha";
            NewDsRow["Last_Name"] = "Ln_Ho";
            NewDsRow["Email"] = "haho@sth.com";
            NewDsRow["Gender"] = "Female";
            NewDsRow["Zip"] = Random4Digits.Next(1000, 9999);
            NewDsRow["State"] = "Texas";
            NewDsRow["Join_Date"] = DateTime.Now.ToString();
            NewDsRow["CreditLimit"] = Random3Digits.Next(100, 999);
            // Insert new row to Dataset, Dataset is in memery. So it is still not sent to databse.
            CrudDs.Tables[0].Rows.Add(NewDsRow);

            // 2nd -- Update
            CrudDs.Tables[0].Rows[0]["First_Name"] = "Elyssa-haha";

            // 3rd -- Delete -- This example has foreign key, Cannot Apply Delete Easily.
            // CrudDs.Tables[0].Rows[1].Delete();

            // Then it will backup and connect to its own Table Columns, No need to re-open them.
            Adapter.Update(CrudDs);

            Console.WriteLine("After -- no need re-open connection.");
            // LoopAndHint listCustomers = new LoopAndHint(CrudDs);
            listCustomers.ListCustomersLoop();
        }
    }
}
