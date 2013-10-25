using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Accounts
{
    public class Accounts_Department
    {
        public Accounts_Department()
        { }
        #region Model
        private int _classid;
        private string _classname;
        private int _classtype;
        private int _parentid;
        private string _parentpath;
        private int _depth;
        private int _rootid;
        private int _child;
        private string _arrchildid;
        private int _previd;
        private int _nextid;
        private int _orderid;
        private string _path;
        private string _notes;
        /// <summary>
        /// 部门ID
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// 部门类型  1--管理部门  2--一线部门
        /// </summary>
        public int ClassType
        {
            set { _classtype = value; }
            get { return _classtype; }
        }
        /// <summary>
        /// 父分类ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 父路径
        /// </summary>
        public string ParentPath
        {
            set { _parentpath = value; }
            get { return _parentpath; }
        }
        /// <summary>
        /// 深度 一级分类深度为0
        /// </summary>
        public int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 根ID
        /// </summary>
        public int RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// 子分类数
        /// </summary>
        public int Child
        {
            set { _child = value; }
            get { return _child; }
        }
        /// <summary>
        /// 所有子分类
        /// </summary>
        public string arrChildID
        {
            set { _arrchildid = value; }
            get { return _arrchildid; }
        }
        /// <summary>
        /// 上一个分类ID
        /// </summary>
        public int PrevID
        {
            set { _previd = value; }
            get { return _previd; }
        }
        /// <summary>
        /// 下一个分类ID
        /// </summary>
        public int NextID
        {
            set { _nextid = value; }
            get { return _nextid; }
        }
        /// <summary>
        /// 顺序
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 分类路径
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes
        {
            set { _notes = value; }
            get { return _notes; }
        }
        #endregion Model

       
    }
}
