using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Accounts
{
    public class Accounts_UserRoles
    {

        public Accounts_UserRoles()
        { }

        private int _id;
        private int _userid;
        private int _rolecode;

        public int ID
        {
            get { return _id; }
            set { _rolecode = value; }
        }

        public int UserID
        {
            get { return _userid; }
            set { _userid=value;}
        }

        public int RoleCode
        {
            get { return _rolecode; }
            set { _rolecode = value; }
        }

       
    }
}
