using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    class Program
    {

        // old-way
        private static List<object> SelectAll(string tableName)
        {
            //Command and Data Reader
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
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
            //var result = SelectAll("Employees");
            //result.ForEach(e => Console.WriteLine(e));

            List<Employee> employees = QueryExecutor.SelectAll<Employee>("Employees");
            employees.ForEach(e => Console.WriteLine(e));
            /*
            Type employee_type = Type.GetType("TemplatePr.Employee");

            Type type = Type.GetType("TemplatePr.Employee");
            Employee e = new Employee() { Id = 1, FirstName = "danny", LastName = "cohen", Gender = "Male", Salary = 41000 };
            if (type == employee_type)
            {
                /*
                if (type == typeof(Employee))
                {
                    Console.WriteLine();
                }
                if (type == e.GetType())
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
                var t2 = type.GetType();
                var t3 = type.GetType();
                var t4 = t3.GetType();
                if (t3 == t4)
                {
                    Console.WriteLine();
                }

            }
            // Print the Type details

            Console.WriteLine("Full Name = {0}", type.FullName);
            Console.WriteLine("Just the Class Name = {0}", type.Name);
            Console.WriteLine("Just the Namespace = {0}", type.Namespace);
            Console.WriteLine();
            // Print the list of Methods
            Console.WriteLine("Methods in Customer Class");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                // Print the Return type and the name of the method
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();
            //  Print the Properties
            Console.WriteLine("Properties in Customer Class");
            PropertyInfo[] properties = type.GetProperties();
            Console.WriteLine("{");
            foreach (PropertyInfo property in properties)
            {
                // Print the property type and the name of the property
                /*
                if (property.PropertyType == typeof(Int32))
                {
                    property.SetValue(e, 100);
                }
                else
                {
                    property.SetValue(e, "new name");
                }
                Console.WriteLine(property.Name + " : " + property.GetValue(e));
            }
            Console.WriteLine("}");
            Console.WriteLine();
            //  Print the Constructors
            Console.WriteLine("Constructors in Customer Class");
            ConstructorInfo[] constructors = type.GetConstructors();
            constructors.ToList().ForEach(c => Console.WriteLine(c));

            Assembly assembly = Assembly.LoadFile(@"C:\Users\HackerU\source\repos\TemplatePr\TemplatePr\bin\Debug\TemplatePr.exe");
            assembly.GetTypes().ToList().ForEach(t => Console.WriteLine(t));

            Employee e2 = (Employee)Activator.CreateInstance(type, null);

            //            PropertyInfo piInstance = type.GetProperty("FirstName");
            //          piInstance.GetValue();

            Assembly assembly = Assembly.LoadFile(@"....bin\Debug\TestCases.dll");
            //get all types
            var testTypes = from t in assembly.GetTypes()
                            let attributes = t.GetCustomAttributes(typeof(NUnit.Framework.TestFixtureAttribute), true)
                            where attributes != null && attributes.Length > 0
                            orderby t.Name
                            select t;

            foreach (var type in testTypes)
            {
                //get test method in types.
                var testMethods = from m in type.GetMethods()
                                  let attributes = m.GetCustomAttributes(typeof(NUnit.Framework.TestAttribute), true)
                                  where attributes != null && attributes.Length > 0
                                  orderby m.Name
                                  select m;

                foreach (var method in testMethods)
                {
                    MethodInfo methodInfo = type.GetMethod(method.Name);

                    if (methodInfo != null)
                    {
                        object result = null;
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        object classInstance = Activator.CreateInstance(type, null);

                        if (parameters.Length == 0)
                        {
                            // This works fine
                            result = methodInfo.Invoke(classInstance, null);
                        }
                        else
                        {
                            object[] parametersArray = new object[] { "Hello" };

                            // The invoke does NOT work;
                            // it throws "Object does not match target type"             
                            result = methodInfo.Invoke(classInstance, parametersArray);
                        }
                    }

                }
            }

            // get private fields
            FieldInfo[] fields = myType.GetFields(
                             BindingFlags.NonPublic |
                             BindingFlags.Instance);

            var f1 = typeof(Employee).GetField("secret", BindingFlags.NonPublic | BindingFlags.Instance);
            var hahaha = f1.GetValue(e2);
            */
        }
    }
}
