using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL.Accounts
{
    public class Accounts_Department
    {
        public Accounts_Department()
        { }

        private readonly DAL.Accounts.Accounts_Department dal = new DAL.Accounts.Accounts_Department();

        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        public bool Exists(int classId)
        {
            return dal.Exists(classId);
        }
        public int Add(Model.Accounts.Accounts_Department model)
        {
            //获得分类ID 注意，这里的GetMaxId已经自动加1了，所以这里不用加了
            int ClassID = dal.GetMaxId();

            int MaxRootID = 0;
            int PrevID = 0;
            int PrevOrderID = 0;
            int Child = 0;
            int RootID = 0;
            int ParentDepth = 0;
            string ParentPath = "0";
            string arrChildID = string.Empty;

            //根据父分类ID和分类名称判断其他属性
            //先设置RootID为自己的ID，如果父分类ID不为0，即不是一级分类，再修改RootID为父分类的RootID
            MaxRootID = dal.GetMaxRootID();

            RootID = ClassID;


            //如果父分类ID>0,先取出父分类的信息
            if (model.ParentID > 0)
            {
                Model.Accounts.Accounts_Department mc = dal.GetModel(model.ParentID);
                //不是一级分类，修改RootID为父分类的RootID
                RootID = mc.RootID;
                //得到父级分类的深度
                ParentDepth = mc.Depth;
                //得到父级分类的路径
                ParentPath = mc.ParentPath + "," + mc.ClassID;
                Child = mc.Child;
                //得到子分类
                arrChildID = mc.arrChildID + "," + ClassID;

                //更新本分类的所有上级分类的子分类ID数组
                Model.Accounts.Accounts_Department mcp = new Model.Accounts.Accounts_Department();
                DataSet ds = dal.GetList(" ClassID in (" + ParentPath + ")", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        mcp = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                        if (mcp != null)
                        {
                            mcp.arrChildID = mcp.arrChildID + "," + ClassID;
                            dal.Update(mcp);
                        }
                    }
                }

                //如果父分类已经有子分类
                if (Child > 0)
                {
                    //得到父栏目的所有子栏目中最后一个栏目的OrderID
                    PrevOrderID = dal.GetMaxOrderID("ClassID in (" + arrChildID + ")");
                    //得到本栏目的上一个栏目ID
                    PrevID = dal.GetPrevID(model.ParentID);
                }
                else
                {
                    PrevOrderID = mc.OrderID;
                    //如果父分类没有子分类,则前一个ID设置为0
                    PrevID = 0;
                }
            }
            else
            {
                //如果父分类为0,即为一级分类,如果已经存在其他一级分类
                if (MaxRootID > 0)
                {
                    Model.Accounts.Accounts_Department mc = dal.GetModel(" RootID=" + MaxRootID + " and Depth=0");
                    if (mc != null)
                    {
                        PrevID = mc.ClassID;
                    }
                }
                else
                {
                    //如果没有其他一级分类,则前一个ID设置为0
                    PrevID = 0;
                }
                PrevOrderID = 0;
                ParentPath = "0";
            }
            //设置model其他属性
            model.ClassID = ClassID;
            model.RootID = RootID;
            //如果父级ID大于0,则本身的Depth为父级分类的Depth+1
            if (model.ParentID > 0)
            {
                model.Depth = ParentDepth + 1;
            }
            else
            {
                model.Depth = 0;
            }
            model.ParentPath = ParentPath;
            //model.Path = ParentPath + "," + ClassID;
            model.OrderID = PrevOrderID;
            model.Child = 0;
            model.PrevID = PrevID;
            model.NextID = 0;
            model.arrChildID = model.ClassID.ToString();

            //添加此model
            dal.Add(model);

            //更新与本栏目同一父栏目的上一个栏目的“NextID”字段值
            Model.Accounts.Accounts_Department m = new Model.Accounts.Accounts_Department();
            m = dal.GetModel("ClassID=" + PrevID);
            if (m != null)
            {
                m.NextID = ClassID;
                dal.Update(m);
            }

            if (model.ParentID > 0)
            {
                //更新其父类的子栏目数
                m = dal.GetModel("ClassID=" + model.ParentID);
                if (m != null)
                {
                    m.Child += 1;
                    dal.Update(m);
                }

                //更新该栏目排序以及大于本需要和同在本分类下的栏目排序序号
                DataSet dsp = dal.GetList(" RootID=" + RootID + " and OrderID>" + PrevOrderID, "");
                if (dsp.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsp.Tables[0].Rows)
                    {
                        m = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                        if (m != null)
                        {
                            m.OrderID += 1;
                            dal.Update(m);
                        }
                    }
                }
                m = dal.GetModel("ClassID=" + ClassID);
                if (m != null)
                {
                    m.OrderID = PrevOrderID + 1;
                    dal.Update(m);
                }
            }

            //返回本分类ID
            return ClassID;
        }

        public void Update(Model.Accounts.Accounts_Department model)
        {
            dal.Update(model);
        }

        public void Delete(int ClassID)
        {

            dal.Delete(ClassID);
        }

        public Model.Accounts.Accounts_Department GetModel(int ClassID)
        {

            return dal.GetModel(ClassID);
        }

        public DataSet GetList(string strWhere, string strOrderType)
        {
            return dal.GetList(strWhere, strOrderType);
        }

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Accounts.Accounts_Department> GetModelList(string strWhere, string strOrderType)
        {
            DataSet ds = dal.GetList(strWhere, strOrderType);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Accounts.Accounts_Department> DataTableToList(DataTable dt)
        {
            List<Model.Accounts.Accounts_Department> modelList = new List<Model.Accounts.Accounts_Department>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Accounts.Accounts_Department model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Accounts.Accounts_Department();
                    if (dt.Rows[n]["ClassID"].ToString() != "")
                    {
                        model.ClassID = int.Parse(dt.Rows[n]["ClassID"].ToString());
                    }
                    model.ClassName = dt.Rows[n]["ClassName"].ToString();
                    if (dt.Rows[n]["ClassType"].ToString() != "")
                    {
                        model.ClassType = int.Parse(dt.Rows[n]["ClassType"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    model.ParentPath = dt.Rows[n]["ParentPath"].ToString();
                    if (dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
                    }
                    if (dt.Rows[n]["RootID"].ToString() != "")
                    {
                        model.RootID = int.Parse(dt.Rows[n]["RootID"].ToString());
                    }
                    if (dt.Rows[n]["Child"].ToString() != "")
                    {
                        model.Child = int.Parse(dt.Rows[n]["Child"].ToString());
                    }
                    model.arrChildID = dt.Rows[n]["arrChildID"].ToString();
                    if (dt.Rows[n]["PrevID"].ToString() != "")
                    {
                        model.PrevID = int.Parse(dt.Rows[n]["PrevID"].ToString());
                    }
                    if (dt.Rows[n]["NextID"].ToString() != "")
                    {
                        model.NextID = int.Parse(dt.Rows[n]["NextID"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    model.Path = dt.Rows[n]["Path"].ToString();
                    model.Notes = dt.Rows[n]["Notes"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("", "");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// 是否存在该记录 根据ClassName  无限级分类必需
        /// </summary>
        public bool Exists(string ClassName, int ParentID)
        {
            return dal.Exists(ClassName, ParentID);
        }


        /// <summary>
        /// 获得下拉列表框要显示的数据列表，显示树形列表  无限级分类必需
        /// </summary>
        /// <returns></returns>
        public DataSet GetDropdownListOption()
        {
            string strTemp = string.Empty;
            int tmpDepth = 0;
            string[] arrShowLine = new string[20];
            int i = 0;
            //给数组设置初值，0为假 1为真
            for (i = 0; i < arrShowLine.Length; i++)
            {
                arrShowLine[i] = "0";
            }
            DataSet ds = dal.GetList("", "");
            //如果已经有分类
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    tmpDepth = int.Parse(dr["Depth"].ToString());
                    //如果此分类下有NextID，说明不是父分类下最后一个子分类
                    if (int.Parse(dr["NextID"].ToString()) > 0)
                    {
                        arrShowLine[tmpDepth] = "1";
                    }
                    else
                    {
                        arrShowLine[tmpDepth] = "0";
                    }
                    //如果深度大于0，说明不是一级分类，需要在前面加空格缩进
                    if (tmpDepth > 0)
                    {
                        for (i = 1; i <= tmpDepth; i++)
                        {
                            //深度每加一层，加一个空格
                            strTemp += "&nbsp;&nbsp;";
                            if (i == tmpDepth)
                            {
                                //如果此分类下NextID大于0，说明不是父分类下最后一个子分类，加├
                                if (int.Parse(dr["NextID"].ToString()) > 0)
                                {
                                    strTemp += "├&nbsp;";
                                }
                                //最后一个子分类加└
                                else
                                {
                                    strTemp += "└&nbsp;";
                                }
                            }
                            else
                            {
                                if (arrShowLine[i] == "1")
                                {
                                    strTemp += "│";
                                }
                                else
                                {
                                    strTemp += "&nbsp;";
                                }
                            }
                        }
                    }
                    //修改ds中的数据 这个时候要HtmlDecode一下,不然DropdownList的Text属性在输出HTML的时候会自动编码
                    //不能输出正确的空格,而是直接输出&nbsp;
                    dr["ClassName"] = System.Web.HttpUtility.HtmlDecode(strTemp) + dr["ClassName"].ToString();
                    //清空strTemp
                    strTemp = string.Empty;
                    //如果是外部栏目，再加一个“外”字
                    //if (dr["ClassType"].ToString() == "2")
                    //{
                    //    dr["ClassName"] = dr["ClassName"].ToString() + "(外)";
                    //}
                }
            }
            //返回修改后的DataSet
            return ds;
        }

        /// <summary>
        /// 向上移动分类
        /// </summary>
        public void MoveOrderUp(int MoveClassID)
        {
            dal.MoveOrderUp(MoveClassID);
        }

        /// <summary>
        /// 向下移动分类
        /// </summary>
        public void MoveOrderDown(int MoveClassID)
        {
            dal.MoveOrderDown(MoveClassID);
        }

        /// <summary>
        /// 移动分类到指定的父分类下
        /// </summary>
        public void Move(int MoveClassID, int toParentID)
        {
            dal.Move(MoveClassID, toParentID);
        }

        //2010.02.05添加
        /// <summary>
        /// 取得部门名称路径
        /// </summary>
        /// <param name="DepartmentID">部门ID</param>
        /// <returns></returns>
        public string GetDepartmentPath(string DepartmentID)
        {
            StringBuilder strDepartment = new StringBuilder();

            BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
            Model.Accounts.Accounts_Department m = bll.GetModel(int.Parse(DepartmentID));
            string parentPath = m.ParentPath;
            string selfDeptName = m.ClassName;
            //取得父级路径部门名称
            string[] arrParentDept = parentPath.Split(',');
            if (arrParentDept.Length > 1)
            {
                for (int i = 1; i < arrParentDept.Length; i++)
                {
                    m = bll.GetModel(int.Parse(arrParentDept[i]));
                    strDepartment.Append(m.ClassName);
                    strDepartment.Append("/");
                }
            }
            strDepartment.Append(selfDeptName);

            return strDepartment.ToString();
        }

        /// <summary>
        /// Gets the root ID.取得指定部门的根ID
        /// </summary>
        /// <param name="DepartmentID">The department ID.</param>
        /// <returns></returns>
        public int GetRootID(int DepartmentID)
        {
            BLL.Accounts.Accounts_Department bll = new BLL.Accounts.Accounts_Department();
            Model.Accounts.Accounts_Department m = bll.GetModel(DepartmentID);
            return m.RootID;
        }

    }
}
