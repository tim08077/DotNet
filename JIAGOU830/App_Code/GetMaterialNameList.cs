using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.ComponentModel;//组件和控件运行时和设计时行为的类  component 成分，零件

/// <summary>
///GetMaterialNameList 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]//ToolboxItem 
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class GetMaterialNameList : System.Web.Services.WebService {

    public GetMaterialNameList () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(Description = "通过输入材料名返回名称列表")]
    ///
    public string[] GetCompletionList(string prefixText,int count)
    {
        List<string> items = new List<string>(count);
        BLL.Sales.Material bllMaterial = new BLL.Sales.Material();
        DataSet ds = bllMaterial.GetList("  name like '%" + prefixText + "%'");
        for (int i = 0; i < count;i++ )//count 为设置的总行数，就是页面显示的下拉框
        { 
            if(ds.Tables[0].Rows.Count >i)
            {
                items.Add(ds.Tables[0].Rows[i]["name"].ToString());
            }

        }
        return items.ToArray();
    }

    
}
