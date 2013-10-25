using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL.Accounts
{
    public class Accounts_UserRoles
    {

        private readonly DAL.Accounts.Accounts_UserRoles dal = new DAL.Accounts.Accounts_UserRoles();
        public Accounts_UserRoles()
        { }

        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        public bool Exists(int ID, int RoleCode)
        {
            return dal.Exists(ID,RoleCode);
        }

        public int Add(Model.Accounts.Accounts_UserRoles model)
        {
            return dal.Add(model);
        }

        public void Update(Model.Accounts.Accounts_UserRoles model)
        {
            dal.Update(model);

        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public void Delete(int UserID, int RoleCode)
        {
            dal.Delete(UserID, RoleCode);
        }

        public Model.Accounts.Accounts_UserRoles GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public void Delete(string strWhere)
        {
            dal.Delete(strWhere);
        }
    }
}
