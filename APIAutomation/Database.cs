using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace APIAutomation
{
    public class Database
    {
        public static SqlConnection DatabaseConnect()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Data Source=.\SQLEXPRESS; database=testdb;";
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            return conn;
        }
    }
}
