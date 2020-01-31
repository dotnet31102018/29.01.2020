using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPro
{
    public abstract class OracleTemplateBase : TemplateQueryRunner
    {
        protected override void CreateDbConnection()
        {
            Console.WriteLine("Creating oracle connection ... ");
        }
        protected override void OpenDbConnection()
        {
            Console.WriteLine("Opening oracle connection ... ");
        }
        protected override void CloseDbConnection()
        {
            Console.WriteLine("Closing oracle connection ... ");
        }

    }
}
