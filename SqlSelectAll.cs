using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    class Program
    {
    
        // Don't forget newtonsoft nugget!!!!!!!!!!!!
        
        public class Employee
        {
            public int Id { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int Salary { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        private static List<object> SelectAll(string tableName)
        {
            //Command and Data Reader
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=VS17-SQL2017\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM {tableName}";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                var e = new
                {
                    Id = reader["ID"],
                    firaName = reader["FIRSTNAME"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();

            return list;
        }
        static void Main(string[] args)
        {
            var result = SelectAll("Employees");
            result.ForEach(e => Console.WriteLine(e));
        }
    }
}
