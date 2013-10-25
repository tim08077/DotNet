using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Accounts
{
    public class Accounts_Department
    {
        public Accounts_Department()
        {}

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ClassID", "Accounts_Department");
        }

        public bool Exists(int classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Department");
            strSql.Append(" where ClassID=@ClassID ");
            SqlParameter[] parameters = { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = classID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public void Add(Model.Accounts.Accounts_Department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Department(");
            strSql.Append("ClassID,ClassName,ClassType,ParentID,ParentPath,Depth,RootID,Child,arrChildID,PrevID,NextID,OrderID,Path,Notes)");
            strSql.Append(" values (");
            strSql.Append("@ClassID,@ClassName,@ClassType,@ParentID,@ParentPath,@Depth,@RootID,@Child,@arrChildID,@PrevID,@NextID,@OrderID,@Path,@Notes)");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.VarChar,500),
					new SqlParameter("@ClassType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ParentPath", SqlDbType.VarChar,50),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@Child", SqlDbType.Int,4),
					new SqlParameter("@arrChildID", SqlDbType.VarChar,500),
					new SqlParameter("@PrevID", SqlDbType.Int,4),
					new SqlParameter("@NextID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ClassID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.ClassType;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.ParentPath;
            parameters[5].Value = model.Depth;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.Child;
            parameters[8].Value = model.arrChildID;
            parameters[9].Value = model.PrevID;
            parameters[10].Value = model.NextID;
            parameters[11].Value = model.OrderID;
            parameters[12].Value = model.Path;
            parameters[13].Value = model.Notes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Update(Model.Accounts.Accounts_Department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Department set ");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("ClassType=@ClassType,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("ParentPath=@ParentPath,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("Child=@Child,");
            strSql.Append("arrChildID=@arrChildID,");
            strSql.Append("PrevID=@PrevID,");
            strSql.Append("NextID=@NextID,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Path=@Path,");
            strSql.Append("Notes=@Notes");
            strSql.Append(" where ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.VarChar,500),
					new SqlParameter("@ClassType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ParentPath", SqlDbType.VarChar,50),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@Child", SqlDbType.Int,4),
					new SqlParameter("@arrChildID", SqlDbType.VarChar,500),
					new SqlParameter("@PrevID", SqlDbType.Int,4),
					new SqlParameter("@NextID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ClassID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.ClassType;
            parameters[3].Value = model.ParentID;
            parameters[4].Value = model.ParentPath;
            parameters[5].Value = model.Depth;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.Child;
            parameters[8].Value = model.arrChildID;
            parameters[9].Value = model.PrevID;
            parameters[10].Value = model.NextID;
            parameters[11].Value = model.OrderID;
            parameters[12].Value = model.Path;
            parameters[13].Value = model.Notes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Department ");
            strSql.Append(" where ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
            parameters[0].Value = classID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public Model.Accounts.Accounts_Department GetModel(int classId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClassID,ClassName,ClassType,ParentID,ParentPath,Depth,RootID,Child,arrChildID,PrevID,NextID,OrderID,Path,Notes from Accounts_Department ");
            strSql.Append(" where ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
            parameters[0].Value = classId;

            Model.Accounts.Accounts_Department model = new Model.Accounts.Accounts_Department();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["ClassType"].ToString() != "")
                {
                    model.ClassType = int.Parse(ds.Tables[0].Rows[0]["ClassType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.ParentPath = ds.Tables[0].Rows[0]["ParentPath"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Child"].ToString() != "")
                {
                    model.Child = int.Parse(ds.Tables[0].Rows[0]["Child"].ToString());
                }
                model.arrChildID = ds.Tables[0].Rows[0]["arrChildID"].ToString();
                if (ds.Tables[0].Rows[0]["PrevID"].ToString() != "")
                {
                    model.PrevID = int.Parse(ds.Tables[0].Rows[0]["PrevID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NextID"].ToString() != "")
                {
                    model.NextID = int.Parse(ds.Tables[0].Rows[0]["NextID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                model.Notes = ds.Tables[0].Rows[0]["Notes"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        
        }
        public DataSet GetList(string strWhere, string strOrderType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassID,ClassName,ClassType,ParentID,ParentPath,Depth,RootID,Child,arrChildID,PrevID,NextID,OrderID,Path,Notes ");
            strSql.Append(" FROM Accounts_Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrderType.Trim() != "")
            {
                //增加按照顺序号排序 无限级分类必需 默认为  RootID,OrderID
                strSql.Append(" order by " + strOrderType);
            }
            else
            {
                strSql.Append(" order by RootID,OrderID");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ClassID,ClassName,ClassType,ParentID,ParentPath,Depth,RootID,Child,arrChildID,PrevID,NextID,OrderID,Path,Notes ");
            strSql.Append(" FROM Accounts_Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录 根据ClassName  无限级分类必需
        /// </summary>
        public bool Exists(string ClassName, int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Department");
            strSql.Append(" where ClassName=@ClassName and ParentID=@ParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.Int,4)};
            parameters[0].Value = ClassName;
            parameters[1].Value = ParentID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 取得当前最大RootID  无限级分类必需
        /// </summary>
        public int GetMaxRootID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(RootID) from Accounts_Department");

            object obj = DbHelperSQL.GetSingles(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 取得最大OrderID  无限级分类必需
        /// </summary>
        public int GetMaxOrderID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(OrderID) from Accounts_Department");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingles(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 取得父分类下最大的分类ID,即本分类的上一个分类ID  无限级分类必需
        /// </summary>
        public int GetPrevID(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassID from Accounts_Department where ParentID=" + ParentID + " order by OrderID desc");

            object obj = DbHelperSQL.GetSingles(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 得到一个对象实体  根据查询语句  无限级分类必需
        /// </summary>
        public Model.Accounts.Accounts_Department GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClassID,ClassName,ClassType,ParentID,ParentPath,Depth,RootID,Child,arrChildID,PrevID,NextID,OrderID,Path,Notes from Accounts_Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            Model.Accounts.Accounts_Department model = new Model.Accounts.Accounts_Department();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["ClassType"].ToString() != "")
                {
                    model.ClassType = int.Parse(ds.Tables[0].Rows[0]["ClassType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.ParentPath = ds.Tables[0].Rows[0]["ParentPath"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Child"].ToString() != "")
                {
                    model.Child = int.Parse(ds.Tables[0].Rows[0]["Child"].ToString());
                }
                model.arrChildID = ds.Tables[0].Rows[0]["arrChildID"].ToString();
                if (ds.Tables[0].Rows[0]["PrevID"].ToString() != "")
                {
                    model.PrevID = int.Parse(ds.Tables[0].Rows[0]["PrevID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NextID"].ToString() != "")
                {
                    model.NextID = int.Parse(ds.Tables[0].Rows[0]["NextID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                model.Notes = ds.Tables[0].Rows[0]["Notes"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 向上移动分类
        /// </summary>
        public void MoveOrderUp(int MoveClassID)
        {
            DAL.Accounts.Accounts_Department dal = new Accounts_Department();
            Model.Accounts.Accounts_Department model = dal.GetModel(MoveClassID);
            if (model != null)
            {
                //如果要移动的分类的ParentID为0，即为一级分类
                StringBuilder strSql = new StringBuilder();
                if (model.ParentID == 0)
                {
                    //设置移动数量为1
                    int MoveNum = 1;
                    int ClassID = model.ClassID;
                    int cRootID = model.RootID;
                    //得到本栏目的PrevID,NextID
                    int PrevID = model.PrevID;
                    int NextID = model.NextID;
                    int i = 0;
                    int tRootID = 0;
                    int tClassID = 0;
                    int tPrevID = 0;
                    //int tNextID = 0;
                    DataSet ds = new DataSet();
                    DataSet dst = new DataSet();

                    //如果当前栏目已经在最上面，则无需移动
                    //if (ds.Tables[0].Rows.Count > 0)
                    if (model.PrevID > 0)
                    {
                        //先修改上一栏目的NextID和下一栏目的PrevID
                        Model.Accounts.Accounts_Department mct = new Model.Accounts.Accounts_Department();
                        if (PrevID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set NextID=");
                            strSql.Append(NextID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(PrevID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        if (NextID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set PrevID=");
                            strSql.Append(PrevID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(NextID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        //得到最大RootID值
                        int MaxRootID = dal.GetMaxRootID() + 1;
                        //先将当前栏目移至最后，包括子栏目
                        strSql.Remove(0, strSql.Length);
                        strSql.Append("update Accounts_Department set RootID=");
                        strSql.Append(MaxRootID);
                        strSql.Append(" where RootID=");
                        strSql.Append(cRootID);
                        DbHelperSQL.ExecuteSql(strSql.ToString());
                        //然后将位于当前栏目以上的栏目的RootID依次加一，范围为要提升的数字
                        ds = dal.GetList(" ParentID=0 and RootID<" + cRootID, "RootID desc");
                        i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //得到要提升位置的RootID，包括子栏目
                            tRootID = int.Parse(dr["RootID"].ToString());
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set RootID=RootID+1 where RootID=");
                            strSql.Append(tRootID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            i = i + 1;
                            if (i > MoveNum)
                            {
                                tClassID = int.Parse(dr["ClassID"].ToString());
                                tPrevID = int.Parse(dr["PrevID"].ToString());
                                break;
                            }
                        }
                        //更新移动后本栏目的的PrevID和NextID，以及上一栏目的NextID和下一栏目的PrevID
                        mct = dal.GetModel(ClassID);
                        if (mct != null)
                        {
                            mct.PrevID = tPrevID;
                            mct.NextID = tClassID;
                            dal.Update(mct);
                        }
                        mct = dal.GetModel(tClassID);
                        if (mct != null)
                        {
                            mct.PrevID = ClassID;
                            dal.Update(mct);
                        }
                        if (tPrevID > 0)
                        {
                            mct = dal.GetModel(tPrevID);
                            if (mct != null)
                            {
                                mct.NextID = ClassID;
                                dal.Update(mct);
                            }
                        }
                        //然后再将当前栏目从最后移到相应位置，包括子栏目
                        ds = dal.GetList(" RootID=" + MaxRootID, "");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                if (mct != null)
                                {
                                    mct.RootID = tRootID;
                                    dal.Update(mct);
                                }
                            }
                        }
                    }

                }
                //如果要移动的分类的ParentID不为0，即不是一级分类
                else
                {
                    int ClassID = model.ClassID;
                    //设置移动数量为1
                    int MoveNum = 1;
                    int ParentID = model.ParentID;
                    int OrderID = model.OrderID;
                    string ParentPath = model.ParentPath + "," + ClassID;
                    int Child = model.Child;
                    int PrevID = model.PrevID;
                    int NextID = model.NextID;
                    int AddOrderNum = 0;
                    int i = 0;
                    int tOrderID = 0;
                    int tClassID = 0;
                    int tPrevID = 0;
                    DataSet ds = new DataSet();
                    DataSet dst = new DataSet();
                    //如果当前栏目已经在最上面，则无需移动
                    if (model.PrevID > 0)
                    {
                        Model.Accounts.Accounts_Department mct = new Model.Accounts.Accounts_Department();
                        //获得要移动的栏目的所有子栏目数，然后加1（栏目本身），得到排序增加数（即其上栏目的OrderID增加数AddOrderNum）
                        if (Child > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("select count(*) from Accounts_Department where ParentPath like '%");
                            strSql.Append(ParentPath);
                            strSql.Append("%'");
                            AddOrderNum = int.Parse(DbHelperSQL.GetSingles(strSql.ToString()).ToString()) + 1;
                        }
                        else
                        {
                            //如果要移动的分类没有子分类，则排序增加数为1
                            AddOrderNum = 1;
                        }
                        //先修改上一栏目的NextID和下一栏目的PrevID
                        if (PrevID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set NextID=");
                            strSql.Append(NextID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(PrevID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        if (NextID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set PrevID=");
                            strSql.Append(PrevID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(NextID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        //和该栏目同级且排序在其之上的栏目------更新其排序，范围为要提升的数字AddOrderNum
                        ds = dal.GetList(" ParentID=" + ParentID + " and OrderID<" + OrderID, "OrderID desc");
                        i = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            tOrderID = int.Parse(dr["OrderID"].ToString());
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set OrderID=OrderID+");
                            strSql.Append(AddOrderNum);
                            strSql.Append(" where ClassID=");
                            strSql.Append(int.Parse(dr["ClassID"].ToString()));
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //如果有子分类
                            if (int.Parse(dr["Child"].ToString()) > 0)
                            {
                                dst = dal.GetList("ParentPath like '%" + dr["ParentPath"].ToString() + "," + dr["ClassID"].ToString() + "%'", "OrderID");
                                if (dst.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow drt in dst.Tables[0].Rows)
                                    {
                                        strSql.Remove(0, strSql.Length);
                                        strSql.Append("update Accounts_Department set OrderID=OrderID+");
                                        strSql.Append(AddOrderNum);
                                        strSql.Append(" where ClassID=");
                                        strSql.Append(int.Parse(drt["ClassID"].ToString()));
                                        DbHelperSQL.ExecuteSql(strSql.ToString());
                                    }
                                }
                            }
                            i = i + 1;
                            if (i >= MoveNum)
                            {
                                //获得最后一个提升序号的同级栏目信息
                                tClassID = int.Parse(dr["ClassID"].ToString());
                                tPrevID = int.Parse(dr["PrevID"].ToString());
                                break;
                            }
                        }
                        //更新移动后本栏目的的PrevID和NextID，以及上一栏目的NextID和下一栏目的PrevID
                        mct = dal.GetModel(ClassID);
                        if (mct != null)
                        {
                            mct.PrevID = tPrevID;
                            mct.NextID = tClassID;
                            //更新所要排序的栏目的序号
                            mct.OrderID = tOrderID;
                            dal.Update(mct);
                        }
                        mct = dal.GetModel(tClassID);
                        if (mct != null)
                        {
                            mct.PrevID = ClassID;
                            dal.Update(mct);
                        }
                        if (tPrevID > 0)
                        {
                            mct = dal.GetModel(tPrevID);
                            if (mct != null)
                            {
                                mct.NextID = ClassID;
                                dal.Update(mct);
                            }
                        }
                        //如果有下属栏目，则更新其下属栏目排序
                        if (Child > 0)
                        {
                            i = 1;
                            ds = dal.GetList(" ParentPath like '%" + ParentPath + "%'", "OrderID");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    if (mct != null)
                                    {
                                        mct.OrderID = tOrderID + i;
                                        dal.Update(mct);
                                    }
                                    i = i + 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 向下移动分类
        /// </summary>
        public void MoveOrderDown(int MoveClassID)
        {
            DAL.Accounts.Accounts_Department dal = new Accounts_Department();
            Model.Accounts.Accounts_Department model = dal.GetModel(MoveClassID);
            if (model != null)
            {
                //如果要移动的分类的ParentID为0，即为一级分类
                StringBuilder strSql = new StringBuilder();
                if (model.ParentID == 0)
                {
                    //设置移动数量为1
                    int MoveNum = 1;
                    int ClassID = model.ClassID;
                    int cRootID = model.RootID;
                    //得到本栏目的PrevID,NextID
                    int PrevID = model.PrevID;
                    int NextID = model.NextID;
                    int i = 0;
                    int tRootID = 0;
                    int tClassID = 0;
                    //int tPrevID = 0;
                    int tNextID = 0;
                    DataSet ds = new DataSet();
                    DataSet dst = new DataSet();
                    //如果当前栏目已经在最下面，则无需移动
                    //if (ds.Tables[0].Rows.Count > 0)
                    if (model.NextID > 0)
                    {
                        //先修改上一栏目的NextID和下一栏目的PrevID
                        Model.Accounts.Accounts_Department mct = new Model.Accounts.Accounts_Department();
                        if (PrevID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set NextID=");
                            strSql.Append(NextID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(PrevID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        if (NextID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set PrevID=");
                            strSql.Append(PrevID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(NextID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        //得到最大RootID值
                        int MaxRootID = dal.GetMaxRootID() + 1;
                        //先将当前栏目移至最后，包括子栏目
                        strSql.Remove(0, strSql.Length);
                        strSql.Append("update Accounts_Department set RootID=");
                        strSql.Append(MaxRootID);
                        strSql.Append(" where RootID=");
                        strSql.Append(cRootID);
                        DbHelperSQL.ExecuteSql(strSql.ToString());
                        //然后将位于当前栏目以下的栏目的RootID依次减一，范围为要下降的数字
                        ds = dal.GetList(" ParentID=0 and RootID>" + cRootID, "RootID");
                        i = 1;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //得到要提升位置的RootID，包括子栏目
                            tRootID = int.Parse(dr["RootID"].ToString());
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set RootID=RootID-1 where RootID=");
                            strSql.Append(tRootID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            i = i + 1;
                            if (i > MoveNum)
                            {
                                tClassID = int.Parse(dr["ClassID"].ToString());
                                tNextID = int.Parse(dr["NextID"].ToString());
                                break;
                            }
                        }
                        //更新移动后本栏目的的PrevID和NextID，以及上一栏目的NextID和下一栏目的PrevID
                        mct = dal.GetModel(ClassID);
                        mct.PrevID = tClassID;
                        mct.NextID = tNextID;
                        dal.Update(mct);
                        mct = dal.GetModel(tClassID);
                        mct.NextID = ClassID;
                        dal.Update(mct);
                        if (tNextID > 0)
                        {
                            mct = dal.GetModel(tNextID);
                            if (mct != null)
                            {
                                mct.PrevID = ClassID;
                                dal.Update(mct);
                            }
                        }
                        //然后再将当前栏目从最后移到相应位置，包括子栏目
                        ds = dal.GetList(" RootID=" + MaxRootID, "");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                if (mct != null)
                                {
                                    mct.RootID = tRootID;
                                    dal.Update(mct);
                                }
                            }
                        }
                    }

                }
                else
                {
                    //以下是简便的写法
                    //int NextID = model.NextID;
                    ////如果当前栏目已经在最下面，则无需移动
                    //if (NextID > 0)
                    //{ 
                    //    //如果要下移栏目，相当于把同级分类中当前栏目的下一个栏目上移
                    //    //找出同级分类中当前栏目的下一个栏目
                    //    UART.Model.Accounts.Accounts_Department mct = new UART.Model.Accounts.Accounts_Department();
                    //    mct = dal.GetModel(NextID);
                    //    dal.MoveOrderUp(mct.ClassID);
                    //}




                    int ClassID = model.ClassID;
                    //设置移动数量为1
                    int MoveNum = 1;
                    int ParentID = model.ParentID;
                    int OrderID = model.OrderID;
                    string ParentPath = model.ParentPath + "," + ClassID;
                    int Child = model.Child;
                    int PrevID = model.PrevID;
                    int NextID = model.NextID;
                    //int AddOrderNum = 0;
                    int SubtractOrderNum = 0;
                    int i = 0;
                    int ii = 0;
                    int tOrderID = 0;
                    int tClassID = 0;
                    int tPrevID = 0;
                    int tNextID = 0;
                    int tChild = 0;
                    DataSet ds = new DataSet();
                    DataSet dst = new DataSet();

                    //如果当前栏目已经在最下面，则无需移动
                    if (model.NextID > 0)
                    {
                        Model.Accounts.Accounts_Department mct = new Model.Accounts.Accounts_Department();
                        //获得要移动的栏目的所有子栏目数，然后加1（栏目本身），得到排序减少数（即其下栏目的OrderID减少数SubtractOrderNum）
                        if (Child > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("select count(*) from Accounts_Department where ParentPath like '%");
                            strSql.Append(ParentPath);
                            strSql.Append("%'");
                            SubtractOrderNum = int.Parse(DbHelperSQL.GetSingles(strSql.ToString()).ToString()) + 1;
                        }
                        else
                        {
                            //如果要移动的分类没有子分类，则排序增加数为1
                            SubtractOrderNum = 1;
                        }
                        //先修改上一栏目的NextID和下一栏目的PrevID
                        if (PrevID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set NextID=");
                            strSql.Append(NextID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(PrevID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        if (NextID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set PrevID=");
                            strSql.Append(PrevID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(NextID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        //和该栏目同级且排序在其之下的栏目------更新其排序，范围为要下降的数字
                        ds = dal.GetList(" ParentID=" + ParentID + " and OrderID>" + OrderID, "OrderID");
                        //同级栏目
                        i = 0;
                        //同级栏目和子栏目
                        ii = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            tOrderID = int.Parse(dr["OrderID"].ToString());
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set OrderID=OrderID-");
                            strSql.Append(SubtractOrderNum);
                            strSql.Append(" where ClassID=");
                            strSql.Append(int.Parse(dr["ClassID"].ToString()));
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //如果有子分类
                            if (int.Parse(dr["Child"].ToString()) > 0)
                            {
                                dst = dal.GetList("ParentPath like '%" + dr["ParentPath"].ToString() + "," + dr["ClassID"].ToString() + "%'", "OrderID");
                                if (dst.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow drt in dst.Tables[0].Rows)
                                    {
                                        strSql.Remove(0, strSql.Length);
                                        strSql.Append("update Accounts_Department set OrderID=OrderID-");
                                        strSql.Append(SubtractOrderNum);
                                        strSql.Append(" where ClassID=");
                                        strSql.Append(int.Parse(drt["ClassID"].ToString()));
                                        DbHelperSQL.ExecuteSql(strSql.ToString());
                                        //子栏目数加1
                                        ii = ii + 1;
                                    }
                                }
                            }
                            //同级栏目数加1 最后算出来的是该分类要下降的数量
                            ii = ii + 1;
                            i = i + 1;
                            if (i >= MoveNum)
                            {
                                //获得最后一个提升序号的同级栏目信息
                                tClassID = int.Parse(dr["ClassID"].ToString());
                                tNextID = int.Parse(dr["NextID"].ToString());
                                //以下这个与上移不同
                                tChild = int.Parse(dr["Child"].ToString());
                                break;
                            }
                        }
                        //如果最后一个提升序号的同级栏目有子分类
                        //if (tChild > 0)
                        //{
                        //    strSql.Remove(0, strSql.Length);
                        //    strSql.Append("select count(*) from Accounts_Department where ParentPath like '%");
                        //    strSql.Append(ParentPath);
                        //    strSql.Append(",");
                        //    //这里要加上最后一个提升序号的同级栏目的ClassID
                        //    strSql.Append(tClassID);
                        //    strSql.Append("%'");
                        //    AddOrderNum = int.Parse(DbHelperSQL.GetSingle(strSql.ToString()).ToString()) + 1;
                        //}
                        //else
                        //{
                        //    AddOrderNum = 1;
                        //}

                        //更新移动后本栏目的的PrevID和NextID，以及上一栏目的NextID和下一栏目的PrevID
                        mct = dal.GetModel(ClassID);
                        if (mct != null)
                        {
                            mct.PrevID = tClassID;
                            mct.NextID = tNextID;
                            //更新所要排序的栏目的序号
                            mct.OrderID = OrderID + ii;
                            dal.Update(mct);
                        }
                        mct = dal.GetModel(tClassID);
                        if (mct != null)
                        {
                            mct.NextID = ClassID;
                            dal.Update(mct);
                        }
                        if (tNextID > 0)
                        {
                            mct = dal.GetModel(tPrevID);
                            if (mct != null)
                            {
                                mct.PrevID = ClassID;
                                dal.Update(mct);
                            }
                        }
                        //如果有下属栏目，则更新其下属栏目排序
                        if (Child > 0)
                        {
                            i = 1;
                            ds = dal.GetList(" ParentPath like '%" + ParentPath + "%'", "OrderID");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    if (mct != null)
                                    {
                                        mct.OrderID = OrderID + ii + i;
                                        dal.Update(mct);
                                    }
                                    i = i + 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 移动分类
        /// </summary>
        public void Move(int MoveClassID, int toParentID)
        {
            DAL.Accounts.Accounts_Department dal = new Accounts_Department();
            Model.Accounts.Accounts_Department model = dal.GetModel(MoveClassID);
            if (model != null)
            {
                int ClassID = model.ClassID;
                int Depth = model.Depth;
                int Child = model.Child;
                int RootID = model.RootID;
                int ParentID = model.ParentID;
                string ParentPath = model.ParentPath;
                int PrevID = model.PrevID;
                int NextID = model.NextID;
                int OrderID = model.OrderID;
                int PrevOrderID = 0;
                int i = 0;
                string ClassName = model.ClassName;
                string arrChildID = model.arrChildID;
                string iParentPath = string.Empty;

                int ClassCount = 0;
                int MaxRootID = 0;

                int rParentID = toParentID;
                //所属栏目不能为自己
                //目标栏目与当前父栏目相同，无需移动
                //不能指定该栏目的下属栏目作为所属栏目
                if (rParentID != ClassID && rParentID != ParentID)
                {

                    StringBuilder strSql = new StringBuilder();
                    DataSet ds = new DataSet();
                    DataSet dst = new DataSet();
                    Model.Accounts.Accounts_Department mct = new Model.Accounts.Accounts_Department();
                    Model.Accounts.Accounts_Department mc = new Model.Accounts.Accounts_Department();
                    bool bEnableMove = true;
                    //此处判断外部栏目的功能不需要 注释掉
                    ////不能指定外部栏目为所属栏目
                    //if (rParentID > 0)
                    //{
                    //    dst = dal.GetList("ClassType=1 and ClassID=" + rParentID, "");
                    //    if (dst.Tables[0].Rows.Count == 0)
                    //    {
                    //        bEnableMove = false;
                    //    }
                    //}
                    //不能指定该栏目的下属栏目作为所属栏目
                    string[] arrTemp = arrChildID.Split(',');
                    for (i = 0; i < arrTemp.Length; i++)
                    {
                        //如果该栏目的子分类中包括要移动的父分类ID，说明是要移动到该栏目的下属栏目作为所属栏目
                        //不能移动
                        if (arrTemp[i].ToString() == rParentID.ToString())
                        {
                            bEnableMove = false;
                            //找到一个 退出循环
                            break;
                        }
                    }
                    //如果可以移动
                    if (bEnableMove == true)
                    {
                        //得到要移动的栏目数
                        ClassCount = arrChildID.Split(',').Length;
                        //需要更新其原来所属栏目信息，包括深度、父级ID、栏目数、排序等数据
                        //需要更新当前所属栏目信息

                        MaxRootID = dal.GetMaxRootID();

                        //更新原来同一父栏目的上一个栏目的NextID和下一个栏目的PrevID
                        if (PrevID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set NextID=");
                            strSql.Append(NextID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(PrevID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }
                        if (NextID > 0)
                        {
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set PrevID=");
                            strSql.Append(PrevID);
                            strSql.Append(" where ClassID=");
                            strSql.Append(NextID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                        }

                        //如果原来不是一级分类改成一级分类
                        if (ParentID > 0 && rParentID == 0)
                        {
                            //更新其原来所属栏目的栏目数，
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set child=child-1 where ClassID=");
                            strSql.Append(ParentID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //更新此栏目的原来所有上级栏目的子栏目ID数组
                            ds = dal.GetList("ClassID in (" + ParentPath + ")", "");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                //从上级栏目的子分类ID数组中去除本分类及子分类的ID
                                mct.arrChildID = dal.RemoveClassID(mct.arrChildID, arrChildID);
                                dal.Update(mct);
                            }
                            //更新与此栏目同根且排序在其之下的栏目的排序 不包括子栏目
                            ds = dal.GetList("RootID=" + RootID + " and OrderID>" + OrderID, "");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    //如果为子栏目 则不更新
                                    if (mct.ParentID != ClassID)
                                    {
                                        //新的排序ID为原来的排序减去本分类及子分类的数量
                                        mct.OrderID = mct.OrderID - arrChildID.Split(',').Length;
                                        dal.Update(mct);
                                    }
                                }
                            }
                            //得到上一个一级分类栏目
                            ds = dal.GetList("RootID=" + MaxRootID + " and Depth=0", "");
                            {
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    PrevID = 0;
                                }
                                else
                                {
                                    mct = dal.GetModel(int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString()));
                                    if (mct != null)
                                    {
                                        //得到新的PrevID
                                        PrevID = mct.ClassID;
                                        //更新上一个一级分类栏目的NextID的值
                                        mct.NextID = ClassID;
                                        dal.Update(mct);
                                    }
                                }
                            }
                            //得到新的RootID
                            MaxRootID = MaxRootID + 1;
                            //更新当前栏目数据
                            model.Depth = 0;
                            model.OrderID = 0;
                            model.RootID = MaxRootID;
                            model.ParentID = 0;
                            model.ParentPath = "0";
                            model.PrevID = PrevID;
                            model.NextID = 0;
                            dal.Update(model);

                            //如果有下属栏目，则更新其下属栏目数据。
                            //更新下属栏目的排序，更新下属栏目深度和一级排序ID(rootid)数据
                            if (Child > 0)
                            {
                                ParentPath = ParentPath + ",";
                                //从子栏目数组中去掉当前栏目的ID
                                arrChildID = dal.RemoveClassID(arrChildID, ClassID.ToString());
                                ds = dal.GetList("ClassID in (" + arrChildID + ")", "");
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    iParentPath = dr["ParentPath"].ToString().Replace(ParentPath, "");
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    mct.Depth = mct.Depth - Depth;
                                    mct.RootID = MaxRootID;
                                    mct.ParentPath = "0," + iParentPath;
                                    //更新子栏目的排序 新的排序为原排序减去本栏目的排序
                                    mct.OrderID = mct.OrderID - OrderID;
                                    dal.Update(mct);
                                }
                            }
                        }
                        //如果是将一个分栏目移动到其他分栏目下
                        else if (ParentID > 0 && rParentID > 0)
                        {
                            //更新其原父类的子栏目数
                            //更新其原来所属栏目的栏目数，
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set child=child-1 where ClassID=");
                            strSql.Append(ParentID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //更新此栏目的原来所有上级栏目的子栏目ID数组
                            ds = dal.GetList("ClassID in (" + ParentPath + ")", "");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                //从上级栏目的子分类ID数组中去除本分类及子分类的ID
                                mct.arrChildID = dal.RemoveClassID(mct.arrChildID, arrChildID);
                                dal.Update(mct);
                            }
                            //更新与此栏目同根且排序在其之下的栏目的排序 不包括子栏目
                            ds = dal.GetList("RootID=" + RootID + " and OrderID>" + OrderID, "");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    //如果为子栏目 则不更新
                                    if (mct.ParentID != ClassID)
                                    {
                                        //新的排序ID为原来的排序减去本分类及子分类的数量
                                        mct.OrderID = mct.OrderID - arrChildID.Split(',').Length;
                                        dal.Update(mct);
                                    }
                                }
                            }
                            //获得目标栏目的相关信息
                            mc = dal.GetModel(rParentID);
                            if (mc.Child > 0)
                            {
                                //得到在目标栏目中与本栏目同级的最后一个栏目的ClassID，并更新其NextID的指向
                                ds = dal.GetList("ParentID=" + mc.ClassID, "OrderID desc");
                                //得到新的PrevID
                                PrevID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());

                                strSql.Remove(0, strSql.Length);
                                strSql.Append("update Accounts_Department set NextID=");
                                strSql.Append(ClassID);
                                strSql.Append(" where ClassID=");
                                strSql.Append(PrevID);
                                DbHelperSQL.ExecuteSql(strSql.ToString());

                                //得到目标栏目的子栏目的最大OrderID
                                strSql.Remove(0, strSql.Length);
                                strSql.Append("select Max(OrderID) from Accounts_Department where ClassID in (");
                                strSql.Append(mc.arrChildID);
                                strSql.Append(")");
                                PrevOrderID = int.Parse(DbHelperSQL.GetSingles(strSql.ToString()).ToString());
                            }
                            else
                            {
                                PrevID = 0;
                                PrevOrderID = mc.OrderID;
                            }
                            //更新目标栏目的子栏目数
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set child=child+1 where ClassID=");
                            strSql.Append(rParentID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //更新目标栏目及目标栏目的所有上级栏目的子栏目ID数组
                            ds = dal.GetList("ClassID in (" + mc.ParentPath + "," + mc.ClassID + ")", "");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                //从上级栏目的子分类ID数组中去除本分类及子分类的ID
                                mct.arrChildID = mct.arrChildID + "," + arrChildID;
                                dal.Update(mct);
                            }

                            //在获得移动过来的栏目数后更新排序在指定栏目之后的栏目排序数据
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set OrderID=OrderID+");
                            strSql.Append(ClassCount);
                            strSql.Append(" where RootID=");
                            strSql.Append(mc.RootID);
                            strSql.Append(" and OrderID>");
                            strSql.Append(PrevOrderID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());

                            //更新当前栏目数据
                            model.Depth = mc.Depth + 1;
                            model.OrderID = PrevOrderID + 1;
                            model.RootID = mc.RootID;
                            model.ParentID = rParentID;
                            model.ParentPath = mc.ParentPath + "," + mc.ClassID;
                            model.PrevID = PrevID;
                            model.NextID = 0;
                            dal.Update(model);

                            //如果当前栏目有子栏目则更新子栏目数据，深度为原来的相对深度加上当前所属栏目的深度
                            if (Child > 0)
                            {
                                i = 1;
                                //从子栏目数组中去掉当前栏目的ID
                                arrChildID = dal.RemoveClassID(arrChildID, ClassID.ToString());
                                ParentPath = ParentPath + ",";
                                ds = dal.GetList(" ClassID in (" + arrChildID + ")", "OrderID");
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    i = i + 1;
                                    iParentPath = mc.ParentPath + "," + mc.ClassID.ToString() + "," + dr["ParentPath"].ToString().Replace(ParentPath, "");
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    mct.Depth = mct.Depth - Depth + mc.Depth + 1;
                                    mct.RootID = mc.RootID;
                                    mct.ParentPath = iParentPath;
                                    //更新子栏目的排序 新的排序为原排序依次加1
                                    mct.OrderID = PrevOrderID + i;
                                    dal.Update(mct);
                                }
                            }
                        }
                        //如果原来是一级栏目改成其他栏目的下属栏目
                        else if (ParentID == 0 && rParentID > 0)
                        {
                            //更新排序在其之下的一级栏目的排序RootID
                            ds = dal.GetList("ParentID=0 and RootID>" + RootID, "");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    //新的RootID为原来的RootID-1
                                    mct.RootID = mct.RootID - 1;
                                    dal.Update(mct);
                                }
                            }
                            //获得目标栏目的相关信息
                            mc = dal.GetModel(rParentID);
                            if (mc.Child > 0)
                            {
                                //得到在目标栏目中与本栏目同级的最后一个栏目的ClassID，并更新其NextID的指向
                                ds = dal.GetList("ParentID=" + mc.ClassID, "OrderID desc");
                                //得到新的PrevID
                                PrevID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());

                                strSql.Remove(0, strSql.Length);
                                strSql.Append("update Accounts_Department set NextID=");
                                strSql.Append(ClassID);
                                strSql.Append(" where ClassID=");
                                strSql.Append(PrevID);
                                DbHelperSQL.ExecuteSql(strSql.ToString());

                                //得到目标栏目的子栏目的最大OrderID
                                strSql.Remove(0, strSql.Length);
                                strSql.Append("select Max(OrderID) from Accounts_Department where ClassID in (");
                                strSql.Append(mc.arrChildID);
                                strSql.Append(")");
                                PrevOrderID = int.Parse(DbHelperSQL.GetSingles(strSql.ToString()).ToString());
                            }
                            else
                            {
                                PrevID = 0;
                                PrevOrderID = mc.OrderID;
                            }
                            //更新目标栏目的子栏目数
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set child=child+1 where ClassID=");
                            strSql.Append(rParentID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());
                            //更新目标栏目及目标栏目的所有上级栏目的子栏目ID数组
                            ds = dal.GetList("ClassID in (" + mc.ParentPath + "," + mc.ClassID + ")", "");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                //从上级栏目的子分类ID数组中去除本分类及子分类的ID
                                mct.arrChildID = mct.arrChildID + "," + arrChildID;
                                dal.Update(mct);
                            }
                            //在获得移动过来的栏目数后更新排序在指定栏目之后的栏目排序数据
                            strSql.Remove(0, strSql.Length);
                            strSql.Append("update Accounts_Department set OrderID=OrderID+");
                            strSql.Append(ClassCount);
                            strSql.Append(" where RootID=");
                            strSql.Append(mc.RootID);
                            strSql.Append(" and OrderID>");
                            strSql.Append(PrevOrderID);
                            DbHelperSQL.ExecuteSql(strSql.ToString());

                            //更新当前栏目数据
                            model.Depth = mc.Depth + 1;
                            model.OrderID = PrevOrderID + 1;
                            model.RootID = mc.RootID;
                            model.ParentID = rParentID;
                            model.ParentPath = mc.ParentPath + "," + mc.ClassID;
                            model.PrevID = PrevID;
                            model.NextID = 0;
                            dal.Update(model);

                            //如果当前栏目有子栏目则更新子栏目数据，深度为原来的相对深度加上当前所属栏目的深度
                            if (Child > 0)
                            {
                                i = 1;
                                //从子栏目数组中去掉当前栏目的ID
                                //arrChildID = dal.RemoveClassID(arrChildID, ClassID.ToString());
                                //其实这里的ParentPath就是"0"，加上逗号后为 "0,"
                                ParentPath = ParentPath + ",";
                                ds = dal.GetList(" RootID=" + RootID + " and ParentID>0", "OrderID");
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    i = i + 1;
                                    iParentPath = mc.ParentPath + "," + mc.ClassID.ToString() + "," + dr["ParentPath"].ToString().Replace(ParentPath, "");
                                    mct = dal.GetModel(int.Parse(dr["ClassID"].ToString()));
                                    mct.Depth = mct.Depth + mc.Depth + 1;
                                    mct.RootID = mc.RootID;
                                    mct.ParentPath = iParentPath;
                                    //更新子栏目的排序 新的排序为原排序依次加1
                                    mct.OrderID = PrevOrderID + i;
                                    dal.Update(mct);
                                }
                            }
                        }
                    }

                }
            }

        }

        /// <summary>
        /// 从上级栏目的子分类ID数组中去除本分类及子分类的ID
        /// </summary>
        /// <param name="arrClassID_Parent">上级栏目的子分类ID数组</param>
        /// <param name="arrClassID_Child">本分类及子分类的ID数组</param>
        /// <returns></returns>
        public string RemoveClassID(string arrClassID_Parent, string arrClassID_Child)
        {

            string arrClassID3 = string.Empty;

            if (arrClassID_Parent == string.Empty)
            {
                arrClassID3 = string.Empty;
            }
            else if (arrClassID_Child == string.Empty)
            {
                arrClassID3 = arrClassID_Parent;
            }
            else if (arrClassID_Parent.Trim() == arrClassID_Child.Trim())
            {
                arrClassID3 = string.Empty;
            }
            else
            {
                string[] arrClassID = arrClassID_Parent.Split(',');
                //如果本分类及子分类的ID数组含有逗号，即有子分类
                if (arrClassID_Child.IndexOf(",") > 0)
                {
                    string[] arrClassID2 = arrClassID_Child.Split(',');
                    for (int i = 0; i < arrClassID.Length; i++)
                    {
                        bool bFound = false;
                        for (int j = 0; j < arrClassID2.Length; j++)
                        {
                            if (arrClassID[i] == arrClassID2[j])
                            {
                                bFound = true;
                                break;
                            }
                        }
                        if (bFound == false)
                        {
                            if (arrClassID3 == string.Empty)
                            {
                                arrClassID3 = arrClassID[i];
                            }
                            else
                            {
                                arrClassID3 = arrClassID3 + "," + arrClassID[i];
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < arrClassID.Length; i++)
                    {
                        if (arrClassID[i] != arrClassID_Child)
                        {
                            if (arrClassID3 == string.Empty)
                            {
                                arrClassID3 = arrClassID[i];
                            }
                            else
                            {
                                arrClassID3 = arrClassID3 + "," + arrClassID[i];
                            }
                        }
                    }
                }

            }
            return arrClassID3;

        }

    }
}
