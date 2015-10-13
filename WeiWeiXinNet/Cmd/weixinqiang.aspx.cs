/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁 重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public partial class cmd_weixinqiang : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";

    public string TIME_MID = "";

    protected void Page_Load(object sender, EventArgs e)
    {


        //string id = Request.QueryString["id"];

        //if (id == null)
        //    Response.Redirect("../help.aspx");
        //if (id == "")
        //    Response.Redirect("../help.aspx");

        //TimeID = id;

        //RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"),id);
        //if (RID == "")
        //{
        //    Response.Redirect("../help.aspx");
        //}
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

        //   
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
        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\"+ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

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

        return RID;
    }
    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        //
        if (WeTextBoxOne.Text.Trim().Length < 5)
        {
            Label1.Text = "字数太少请重新输入:" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString();

            return;
        }


        string PathDirRSWQ = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\WEIQIANG\\");
       
        DateTime QDVVVV = DateTime.Now;
        string QAXNUMPathWQ = System.IO.Path.Combine(PathDirRSWQ, QDVVVV.Year + "_" + QDVVVV.Month.ToString("D2") + "_" + (QDVVVV.Day).ToString("D2") + "_WQ.txt");

        string DATAR = DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + " " + MyNick + ":" + WeTextBoxOne.Text.Replace("\r", " ").Replace("\n", " ").Replace("  ", " ");

        StreamWriter sws = new StreamWriter(QAXNUMPathWQ, true, System.Text.Encoding.UTF8);
        sws.WriteLine(DATAR);
        sws.Close();


        Label1.Text = "发布成功:" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString() + " 请点击《微墙》菜单查看";
        ButtonOne.Visible = false;

        // string XXX = "<script language=\"javascript\"> alert(\"请首先设置个人信息！\");  top.location='" + "../shenghuo.aspx?id=" + TimeID + "';   </script>";

        // Response.Write(XXX);

    }

    /// <summary>
    /// 获得 文件名称
    /// </summary>
    /// <param name="dat"></param>
    /// <returns></returns>
    public static string GetMasterPasswordBytes(string dat)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        byte[] aaa = md5.ComputeHash(System.Text.Encoding.GetEncoding("GB2312").GetBytes(dat));

        string XXS = "";
        for (int i = 0; i < aaa.Length; i++)
        {
            XXS += aaa[i];
        }

        byte[] aaa2 = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(XXS));

        string XXS2 = "";
        for (int i = 0; i < aaa2.Length; i++)
        {
            XXS2 += aaa2[i];
        }


        return XXS2;
    }

}