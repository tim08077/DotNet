using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Accounts
{
    public class PubConstant
    {
        public static string ConnectionString
        {
            get
            {
                string text = ConfigurationManager.AppSettings["ConnectionString"];
                return text;
            }
        }
    }
}
