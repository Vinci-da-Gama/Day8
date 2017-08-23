using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class DbConnection
    {
        private string ConnStr = "Data Source=LUCIFER-PC\\SQLEXPRESS;Initial Catalog=Day8_Db;Integrated Security=True";

        public string ConnectToDbString()
        {
            return this.ConnStr;
        }
    }
}
