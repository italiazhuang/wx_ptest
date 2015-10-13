/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class C1 : System.Web.UI.Page, ICallbackEventHandler
{

    public string UserIDTime = "";
    string RID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            UserIDTime = id;
        }
        else
        {
            Response.Redirect("help.aspx"); 
        }

        if(id=="")
            Response.Redirect("help.aspx"); 

          RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"),UserIDTime);

        if (RID == "")
        {
            Response.Redirect("help.aspx"); 
        }

        //保存 一个 cookie
        DateTime dtExpire = DateTime.Now.AddDays(7);
        HttpCookie cookie = new HttpCookie("weiweixing08");
        cookie.Values.Add("UserIDTime", UserIDTime);
        cookie.Expires = dtExpire;
        Response.Cookies.Add(cookie);


        if (!IsPostBack)
        {
            string strRefrence = string.Empty;
            strRefrence = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveDataFromServer", "context");

            string strCallBack = string.Empty;
            strCallBack = "function CallBackToTheServer(arg, context) {" + strRefrence + "};";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallBackToTheServer", strCallBack, true);
        }
    }

    #region ICallbackEventHandler Members

    private string strTimeFormat;

    public string GetCallbackResult()
    {
        return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss（12小时制）")+ " - [" + strTimeFormat +"]";
        if (strTimeFormat != "" && strTimeFormat == "12")
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss（12小时制）a");
        }
        else
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss（24小时制）b");
        }
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
        strTimeFormat = eventArgument;
    }

    #endregion

    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <returns></returns>
    public string GetTimeID()
    {
        return UserIDTime;
    }

    /// <summary>
    /// 获得滚动新闻数据
    /// </summary>
    /// <returns></returns>
    public string GetNewS()
    {
        try
        {
            string PathDirGUNDONG = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\new.dll");
            String AAAA = System.IO.File.ReadAllText(PathDirGUNDONG, System.Text.Encoding.UTF8);   
            return   AAAA;
        }
        catch
        {
            return "";
        }
   }


    /// <summary>
    /// 读取模板
    /// </summary>
    /// <returns></returns>
    public string GetHTML()
    {
        string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\Main.HTM");
        String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
        return  TXTSET;
    }
}