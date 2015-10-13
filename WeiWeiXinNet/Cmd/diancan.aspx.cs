
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

public partial class cmd_diancan : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";
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
        //  if (Page.IsPostBack) return;
        MyNick = GetNick();

        if (MyNick == "")
        {
            // Response.Write("<script>alert('请首先到  我的》个人设置 中设置个人信息') ; window.open(\"" + "../SetMyData.aspx?id=" + id + "\") </script>  ");


            string XXX = "<script language=\"javascript\"> alert(\"请首先设置个人信息！\");  self.location='" + "../SetMyData.aspx?id=" + RID + "';   </script>";

            Response.Write(XXX);
            //  Response.Redirect("../SetMyData.aspx?id="+id);
        }

    }

    /// <summary>
    /// 获得用户设置好的昵称
    /// </summary>
    /// <returns></returns>
    public string GetNick()
    {

        //获取用户昵称
        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

        if (System.IO.Directory.Exists(PathDir) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir);
            string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
        }

        //昵称
        string NICK = System.IO.Path.Combine(PathDir, "NICK.TXT");

        string NICK_D = "";

        if (System.IO.File.Exists(NICK) == true)
        {
            NICK_D = System.IO.File.ReadAllText(NICK, System.Text.Encoding.UTF8);
        }

        return NICK_D;
    }

    public string GetDATA()
    {


        return GetHtml("diancan.htm");

    }


    /// <summary>
    ///  html
    /// </summary>
    /// <returns></returns>
    public string GetHtml(string PathX)
    {
        try
        {
            // string FF=  "function demo04x() {  jBox.open(\"iframe:http://www.baidu.com\", \"微信助手\", $(window).width() * 0.96, $(window).height()*0.6);   }";

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