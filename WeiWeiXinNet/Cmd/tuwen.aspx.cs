/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全 后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;

public partial class tuwen : System.Web.UI.Page
{
    string TIME_MID = "";
    string RID = "";

    protected string word = "";

    protected string title = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        ////读取 
        //HttpCookie cookie2 = Request.Cookies["weiweixing08"];

        //if (cookie2 == null)
        //{
        //    Response.Redirect("help.aspx");
        //}
        //else
        //{
        //    TIME_MID = cookie2.Values["UserIDTime"];
        //    if (TIME_MID == null)
        //    {
        //        Response.Redirect("help.aspx");
        //    }
        //    else
        //    {
        //        //正确读取

        //        RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), TIME_MID);

        //        if (RID == "")
        //        {
        //            Response.Redirect("help.aspx");
        //        }
        //    }
        //}

        //if (Page.IsPostBack) return;
      
          word = Request.QueryString["w"];
          title = Request.QueryString["t"];


       



    }

    public string GetID()
    {
        //

        return TIME_MID;
    }

    public string GetNews()
    {
        if (word == null || title == null)
        {
            return "参数错误";
        }
        return GetHtml(word ,title );
    }



    /// <summary>
    ///  html
    /// </summary>
    /// <returns></returns>
    public string GetHtml(string word ,string title )
    {


        try
        {


            string PathFile = System.IO.Path.Combine( Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\IMG\\"+  word+".dll"); //图文 关键词回复目录);    

            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadFile(PathFile);

            string TableTxt = "";

            for (int i = 0; i < CMsgData.Items.Count; i++)
            {

                if (CMsgData.Items[i].Title.Trim() == title.Trim())
                {
                    TableTxt = CMsgData.Items[i].Description;

                    break;
                }

            }
            return TableTxt;
        }
        catch
        {
            return "";
        }
    }



}
