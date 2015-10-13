/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cmd_about : System.Web.UI.Page
{
    public string RID = "";
    string TIME_MID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //读取 
        HttpCookie cookie2 = Request.Cookies["weiweixing08"];
        if (cookie2 == null)
        {
            Response.Redirect("help.aspx");
        }
        else
        {
            TIME_MID = cookie2.Values["UserIDTime"];
            if (TIME_MID == null)
            {
                Response.Redirect("help.aspx");
            }
            else
            {
                //正确读取

                RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), TIME_MID);

                if (RID == "")
                {
                    Response.Redirect("help.aspx");
                }
            }
        }
        if (Page.IsPostBack) return;
    }

    public string GetDATA()
    {
        return GetHtml("about.htm");
    }


    /// <summary>
    ///  html
    /// </summary>
    /// <returns></returns>
    public string GetHtml(string PathX)
    {
        try
        {
            string PathDirRSQD = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\");
            String GUNDONG_TXT = System.IO.Path.Combine(PathDirRSQD, PathX);
            String AAAA = System.IO.File.ReadAllText(GUNDONG_TXT, System.Text.Encoding.UTF8);
            return AAAA;
        }
        catch
        {
            return "";
        }
    }

}