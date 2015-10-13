/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用 微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public partial class send_xin : System.Web.UI.Page
{

    string TIME_MID = "";
    string RID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       

         
        // 我的ID | 我的昵称 | 收件人ID
        string MD = Request.QueryString["md"];

        if (MD != null)
            if (MD != "")
                Label6.Text = MD;


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

        if (Label1.Text == "昵称")
        {


            //用户目录

            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\"+ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

            if (System.IO.Directory.Exists(PathDir) == false)
            {   //建立用户目录
                System.IO.Directory.CreateDirectory(PathDir);
                string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
                System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
            }

            //昵称
            string NICK = System.IO.Path.Combine(PathDir, "NICK.TXT");
            if (System.IO.File.Exists(NICK) == true)
            {
                Label1.Text = "昵称：" + System.IO.File.ReadAllText(NICK, System.Text.Encoding.UTF8);
            }

            //学院
            string XUEYUAN = System.IO.Path.Combine(PathDir, "XUEYUAN.TXT");
            if (System.IO.File.Exists(XUEYUAN) == true)
            {
                Label2.Text = "学院：" + System.IO.File.ReadAllText(XUEYUAN, System.Text.Encoding.UTF8);
            }

            //性别
            string XINGBIE = System.IO.Path.Combine(PathDir, "XINGBIE.TXT");
            if (System.IO.File.Exists(XINGBIE) == true)
            {
                Label3.Text = "性别：" + System.IO.File.ReadAllText(XINGBIE, System.Text.Encoding.UTF8);
            }

            //签名
            string QIANMING = System.IO.Path.Combine(PathDir, "QIANMING.TXT");
            if (System.IO.File.Exists(QIANMING) == true)
            {
                Label4.Text = "个人签名：" + System.IO.File.ReadAllText(QIANMING, System.Text.Encoding.UTF8);
            }
        }

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

    public string GetID()
    {
        //

        return TIME_MID;
    }
    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        WeTextBoxOne.Text = WeTextBoxOne.Text.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ");

        if (WeTextBoxOne.Text.Trim().Length <= 2)
        {
            Label7.Text = "信件内容太短";
            return;
        }

        try
        {
            //发送私信 直接发送到对方的  收件夹中
            string[] AA = Label6.Text.Split('|');

            //我的ID  我的昵称 收件人ID
            string SHOU_ID = AA[2];  //收件人ID

            string TXT = AA[1].Replace("-男", "").Replace("-女", "") + "\r\n" + DateTime.Now.ToString() + "\r\n" + AA[0] + "\r\n" + WeTextBoxOne.Text.Trim();


            //获取 地址 和 文件名


            //获取用户昵称
            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\"+ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(SHOU_ID) + "\\XIN");

            if (System.IO.Directory.Exists(PathDir) == false)
            {   //建立用户目录
                System.IO.Directory.CreateDirectory(PathDir);

            }



            string[] ss = { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "{", "[", "}", "]", "|", "\\", ":", ";", "\"", "'", ",", "<", ">", ".", "?", "/", "\r", "\n", "  ", "\t", " ", "：", "；", "。" };
            string XXNAME = AA[1].Replace("-男", "").Replace("-女", "");
            foreach (string a in ss)
            {
                XXNAME = XXNAME.Replace(a, "");
            }
            XXNAME = XXNAME.Replace(" ", "");
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    string DS = XXNAME + "_" + DateTime.Now.Year.ToString("D2") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + "_" + i.ToString("D2");// +"_" + DateTime.Now.Second.ToString("D2") + DateTime.Now.Millisecond.ToString("D4");
                    // 
                    string XIN = System.IO.Path.Combine(PathDir, DS + ".txt");
                    System.IO.File.WriteAllText(XIN, TXT, System.Text.Encoding.UTF8);
                    break;
                }
                catch
                { }
            }


            Label7.Text = "信件发送成功！ " + DateTime.Now.Hour.ToString("D2") + "：" + DateTime.Now.Minute.ToString("D2");

            WeTextBoxOne.Visible = false;
            ButtonOne.Visible = false;
        }
        catch
        {
            Label7.Text = "信件发送失败，请重试！";

        }



    }
}