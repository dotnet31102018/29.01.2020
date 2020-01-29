using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    public static class QueryExecutor
    {
        public static List<T> SelectAll<T>(string tableName) where T : new()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM {tableName}";

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<T> list = new List<T>();
            Type type_of_record = typeof(T);
            while (reader.Read() == true)
            {
                T one_record = new T();
                
                // short and sweet
                //type_of_record.GetProperties().ToList().ForEach(p => p.SetValue(one_record, reader[p.Name]));

                // longer way ...
                foreach(var oneProperty in type_of_record.GetProperties())
                {
                    var value = reader[oneProperty.Name];
                    oneProperty.SetValue(one_record, value);
                }
                list.Add(one_record);
            }
            
            cmd.Connection.Close();

            return list;
        }
    }
}
