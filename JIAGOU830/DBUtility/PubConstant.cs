using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DBUtility
{
    public class PubConstant
    {
        public static string ConnectionString
        {
            get
            {
                string _connectionString =ConfigurationManager.AppSettings["ConnectionString"];
                return _connectionString;
            }
        }
    }
}
