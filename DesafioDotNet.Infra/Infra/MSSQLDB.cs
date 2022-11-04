using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DesafioDotNet.Infra.Infra
{
    public class MSSQLDB
    {
        private readonly string ConnectionSTR;
        private SqlConnection DB;

        public MSSQLDB()
        {
            ConnectionSTR = "server=(localdb)\\mssqllocaldb;database=Products;Integrated Security=True";
        }

        public SqlConnection GetCon()
        {
            DB = new SqlConnection(ConnectionSTR);
            return DB;
        }
    }
}
