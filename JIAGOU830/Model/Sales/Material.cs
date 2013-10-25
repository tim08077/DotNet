using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Sales
{
    /// <summary>
    /// 材料信息实体类
    /// </summary>
    public class Material
    {
       public Material()
       {
       }  
       #region Model
       private int _materialid;
       private int _materialcategoryid;
       private int _manufacturerid;
       private string _name;
       private string _manufacturercode;
       private int _rootdepartmentid;
       /// <summary>
       /// 材料Id
       /// </summary>
       public int MaterialID
       {
           set { _materialid = value; }
           get { return _materialid; }
       }
        /// <summary>
        /// 材料分类ID 
        /// </summary>
       public int MaterialCategoryID
       {
           set { _materialcategoryid = value; }
           get { return _materialcategoryid; }
       }
        /// <summary>
        /// 厂商ID
        /// </summary>
       public int ManufacturerID
       {
           set { _manufacturerid = value; }
           get { return _manufacturerid; }
       }
        /// <summary>
        /// 材料名称
        /// </summary>
       public string Name
       {
           set { _name = value; }
           get { return _name; }
       }
        /// <summary>
        /// 厂家id 
        /// </summary>
       public string ManufacturerCode
       {
           set { _manufacturercode = value; }
           get { return _manufacturercode; }
       }
        /// <summary>
        /// 根部门ID
        /// </summary>
       public int RootDepartmentID
       {
           set { _rootdepartmentid = value; }
           get { return _rootdepartmentid; }
       }
       #endregion 

    }
}
