using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.UI
{
    internal static class DbSettings
    {
        public static string ConnectionString
        {
            get
            {
                return "Server=.; Database=Northwind; Integrated Security=true;";
            }
        }
    }
}
