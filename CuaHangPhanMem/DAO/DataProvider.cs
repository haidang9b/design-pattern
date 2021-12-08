using CuaHangPhanMem.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set { instance = value; }
        }

        private DataProvider() { }

        private string connectString = SaveDataStatic.typeServer == 1 ? SaveDataStatic.connectString1 : SaveDataStatic.connectString2;


        public DbConnection GetConnection()
        {
            DatabaseFactory factory = DBFactory.Instance().createDatabaseFactory();
            return factory.CreateConnection(connectString);
        }

        public string GetConnectionString()
        {
            return connectString;
        }

        public DatabaseFactory GetFactory()
        {
            DatabaseFactory factory = DBFactory.Instance().createDatabaseFactory();
            return factory;
        }
        // Dung de load data theo data table
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            DatabaseFactory factory = DBFactory.Instance().createDatabaseFactory();
            using (DbConnection connection = factory.CreateConnection(connectString))
            {
                connection.Open();
                DbCommand command = factory.CreateCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            var param = factory.CreateParameter(item, parameter[i]);
                            command.Parameters.Add(param);
                            i++;
                        }
                    }
                }
                DbDataAdapter adapter = factory.CreateDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        //dung cho them xoa sua , tra ve la so dong no thực hiện đc
        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            DatabaseFactory factory = DBFactory.Instance().createDatabaseFactory();

            using (DbConnection connection = factory.CreateConnection(connectString))
            {
                connection.Open();
                DbCommand command = factory.CreateCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            var param = factory.CreateParameter(item, parameter[i]);
                            command.Parameters.Add(param);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }



        // Dùng để trả về string, int , double .. chứ không phải một class
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            DatabaseFactory factory = DBFactory.Instance().createDatabaseFactory();
            using (DbConnection connection = factory.CreateConnection(connectString))
            {
                connection.Open();
                DbCommand command = factory.CreateCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            var param = factory.CreateParameter(item, parameter[i]);
                            command.Parameters.Add(param);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

    }
}
