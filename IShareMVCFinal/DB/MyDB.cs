using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.DB
{
    public class MyDB
    {
        private static MyDB _instance;

        private SqlConnection _connection;

        private MyDB()
        {            
            _connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=IShare;Data Source=DESKTOP-V7RAKQJ; MultipleActiveResultSets=true");
        }

        public static MyDB GetInstance()
        {
            if (_instance == null)
                _instance = new MyDB();
            return _instance;
        }

        public void ExecuteSql(string sql)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _connection.Close();
        }


        public SqlDataReader ExecuteSelectSql(string sql)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            var command = _connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }
    }
}