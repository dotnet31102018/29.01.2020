using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePr
{
    public class Employee
    {
        public void foo()
        {

        }
        public Employee()
        {

        }
        public Employee(int id)
        {

        }
        public int Id { get; set; }
        public string firstname { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
