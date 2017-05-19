using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class HotelDB
    {
        public OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Гостиница.accdb");
        public OleDbCommand query = new OleDbCommand();
        public OleDbDataReader reader;
        public OleDbDataAdapter adapter;
        
        public void QueryExecuteReader(string textCommand)
        {
            connection.Open();
            query.CommandText = textCommand;
            query.Connection = connection;
            reader = query.ExecuteReader();
        }
        public void QueryExecuteNon(string textCommand)
        {
            connection.Open();
            query.CommandText = textCommand;
            query.Connection = connection;
            query.ExecuteNonQuery();
        }

        public DataSet GetDataSet(string textCommand)
        {
            reader.Close();
            DataSet ds = new DataSet();
            query.CommandText = textCommand;
            query.Connection = connection;
            adapter = new OleDbDataAdapter(query);
            adapter.Fill(ds);
            CloseConnection();
            return ds;
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
