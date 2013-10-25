using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace Common
{
    public class MsgBox
    {
        #region 警告框
        public static void Alert(string _Msg)
        {
            string StrScript;
            StrScript =("<script language=javascript>alert('"+_Msg+"');</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        public static void Alert(string _Msg,Page _Page)
        {
            string StrScript;
            StrScript = ("<script language=javascript>alert('" + _Msg + "');</script>");
            _Page.ClientScript.RegisterStartupScript(_Page.GetType(),"MsgBox",StrScript.ToString());
        }

        public static void Alert(string _Msg,string URL)
        {
            string StrScript;
            //StrScript = ("<script language=javascript>alert('" + _Msg + "');window.location='" + URL + "';</script>");
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("window.location='" + URL + "';");
            StrScript +=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);

        }

        public static object alert(string _Msg,string URL, Page _page )
        {
            string StrScript;
            StrScript=("<script language>alert('"+_Msg+"');window.location='"+URL+"';</script>");
            _page.ClientScript.RegisterStartupScript(_page.GetType(), "MsgBox2",StrScript.ToString());
            return StrScript;
        }

        #endregion 
        #region 一个含有“确定”、“取消”的警告框
        /// <summary>
        /// 一个含有 “确定 ”，点击返回先前的网页警告框 
        /// </summary>
        /// <param name="_Msg">警告字符串 </param>
        /// <param name="BackLong">要倒退几步 </param>
        public static void Alert_History(string _Msg, int BackLong)
        {
            string StrScript;
            StrScript = ("<script language=javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("history.go('" + BackLong + "')");
            StrScript+=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        /// <summary>
        /// 一个含有确定取消的警告框
        /// </summary>
        /// <param name="_Msg">警告字符串 </param>
        /// <param name="URL">确定以后要转到预设的网址</param>
        public static void confirm(string _Msg,string URL)
        {
            string StrScript;
            StrScript =("<script language=javascript>");
            StrScript += "var retValue=window.confirm('" + _Msg + "');" + "if(retValue){window.location='"+URL+"';}";
            StrScript +=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        /// <summary>
        /// 一个含有确定，关闭本页的对话框
        /// </summary>
        /// <param name="_Msg">警告字符串</param>
        public static void Alert_Close(string _Msg)
        {
            string StrScript;
            StrScript =("<script language=javascript>");
            StrScript +=("alert('"+_Msg+"');");
            StrScript +=("window.close();");
            StrScript +=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        /// <summary>
        /// 一个含有确定,点击后关闭自己，刷新父窗口的警告框
        /// </summary>
        /// <param name="_Msg"></param>
        /// <param name="page"></param>
        public static void Alert_ReloadWin(string _Msg,Page page)
        {
            string StrScript;
            StrScript = ("<script language =javascript>");
            StrScript += ("alert('" + _Msg + "');");
            StrScript += ("window.opener.location.href=window.opener.location.href;window.close();");
            StrScript += ("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(),"Alert_ReloadWin",StrScript);
            
        }
        /// <summary>
        /// 一个含有确定，点击后关闭自己，刷新父窗口的警告框
        /// </summary>
        /// <param name="_Msg"></param>
        public static void Alert_ReloadWin(string _Msg)
        {
            string StrScript;
            StrScript=("<script language=javascript>");
            StrScript +=("alert('" +_Msg + "');");
            StrScript +=("window.opener.location.href=window.opener.location.href;window.close();");
            StrScript +=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);

        }
        /// <summary>
        /// 一个含有确定，点击后关闭自己，刷新父窗口的警告框
        /// </summary>
        /// <param name="_Msg"></param>
        public static void AlertModal_ReloadWin(string _Msg)
        {
            string StrScript;
            StrScript=("<script language=javascript>");
            StrScript +=("alert('"+ _Msg+"');");
            StrScript +=("refreshParent();window.close();");
            StrScript +=("</script>");
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        #endregion
    }
}
