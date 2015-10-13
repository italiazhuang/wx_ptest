/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码 提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
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

public partial class SetMyData : System.Web.UI.Page
{

    string TIME_MID = "";
    string RID = "";
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


        if (Label2.Text == "0")
        {
            Label2.Text = "1";

            //用户目录

            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

            if (System.IO.Directory.Exists(PathDir) == false)
            {   //建立用户目录
                System.IO.Directory.CreateDirectory(PathDir);
                string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
                System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
            }
            try
            {
                //昵称
                string NICK = System.IO.Path.Combine(PathDir, "NICK.TXT");
                if (System.IO.File.Exists(NICK) == true)
                {
                    WeTextBoxOne.Text = System.IO.File.ReadAllText(NICK, System.Text.Encoding.UTF8);
                }

                Label4.Text = WeTextBoxOne.Text;

                //学院
                string XUEYUAN = System.IO.Path.Combine(PathDir, "XUEYUAN.TXT");
                if (System.IO.File.Exists(XUEYUAN) == true)
                {
                    DropDownList1.Text = System.IO.File.ReadAllText(XUEYUAN, System.Text.Encoding.UTF8);
                }

                //地址
                string DIZHI = System.IO.Path.Combine(PathDir, "DIZHI.TXT");
                if (System.IO.File.Exists(DIZHI) == true)
                {
                    WeTextBoxThree.Text = System.IO.File.ReadAllText(DIZHI, System.Text.Encoding.UTF8);
                }



                //性别
                string XINGBIE = System.IO.Path.Combine(PathDir, "XINGBIE.TXT");
                if (System.IO.File.Exists(XINGBIE) == true)
                {
                    DropDownList2.Text = System.IO.File.ReadAllText(XINGBIE, System.Text.Encoding.UTF8);
                }

                //签名
                string QIANMING = System.IO.Path.Combine(PathDir, "QIANMING.TXT");
                if (System.IO.File.Exists(QIANMING) == true)
                {
                    WeTextBoxTwo.Text = System.IO.File.ReadAllText(QIANMING, System.Text.Encoding.UTF8);
                }
            }
            catch { }
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

    /// <summary>
    /// 名字 是否 已经 存在 
    /// </summary>
    /// <param name="anem"></param>
    /// <returns></returns>
    public bool IsHaveName(string anem, string rid)
    {

        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\USerName");

        //昵称 求 MD5
        string ncikmd5 = ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(anem);

        //昵称的名称
        string PathUserNickName = System.IO.Path.Combine(PathDir, ncikmd5 + ".TXT");

        try
        {

            if (System.IO.File.Exists(PathUserNickName) == true)
            {
                string[] MM = System.IO.File.ReadAllLines(PathUserNickName, System.Text.Encoding.UTF8);
                // MM={ RID,昵称 };
                if (rid.Trim() == MM[0].Trim())
                {
                    return false; //允许用户改回自己原有的昵称
                }

                return true; //该昵称已经有了

            }
            else
            {
                return false;
            }

        }
        catch
        { }

        return false;
    }

    /// <summary>
    /// 记录下已经有的数据
    /// </summary>
    /// <param name="anem"></param>
    /// <returns></returns>
    public void AddHaveName(string anem, string rid)
    {

        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\USerName");

        //昵称 求 MD5
        string ncikmd5 = ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(anem);

        //昵称的名称
        string PathUserNickName = System.IO.Path.Combine(PathDir, ncikmd5 + ".TXT");



        if (System.IO.Directory.Exists(PathUserNickName) == false)
        {
            string[] md = { rid, anem };
            System.IO.File.WriteAllLines(PathUserNickName, md, System.Text.Encoding.UTF8);

        }

        //string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\USerName");


        //string PathUser2 = System.IO.Path.Combine(PathDir, "USER_NAME_LIST.TXT");
        //StreamWriter sws = new StreamWriter(PathUser2, true, System.Text.Encoding.UTF8);
        //sws.WriteLine(anem);
        //sws.Close();

    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {

        if (WeTextBoxOne.Text.Trim() == "某某")
        {
            Label3.Text = "昵称已经存在，请重新输入!";
            return;

        }


        if (WeTextBoxOne.Text.Trim().Length <= 1)
        {
            Label3.Text = "昵称太短!";
            return;
        }


        string[] ss = { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "{", "[", "}", "]", "|", "\\", ":", ";", "\"", "'", ",", "<", ">", ".", "?", "/", "\r", "\n", "  ", "\t", " ", "：", "；", "。" };

        string XXNAME = WeTextBoxOne.Text;

        foreach (string a in ss)
        {
            XXNAME = XXNAME.Replace(a, "");
        }


        WeTextBoxOne.Text = XXNAME.Trim();


        if (IsHaveName(WeTextBoxOne.Text.ToLower(), RID) == true)
        {
            Label3.Text = "昵称已经存在，请重新输入!";
            return;
        }




        AddHaveName(WeTextBoxOne.Text, RID);

        Label4.Text = WeTextBoxOne.Text;
        //ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes
        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));


        //昵称
        string NICK = System.IO.Path.Combine(PathDir, "NICK.TXT");
        System.IO.File.WriteAllText(NICK, WeTextBoxOne.Text.Replace("|", "~").Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), System.Text.Encoding.UTF8);


        //学院
        string XUEYUAN = System.IO.Path.Combine(PathDir, "XUEYUAN.TXT");
        System.IO.File.WriteAllText(XUEYUAN, DropDownList1.Text.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), System.Text.Encoding.UTF8);


        //性别
        string XINGBIE = System.IO.Path.Combine(PathDir, "XINGBIE.TXT");
        System.IO.File.WriteAllText(XINGBIE, DropDownList2.Text.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), System.Text.Encoding.UTF8);


        //地址
        string DIZHI = System.IO.Path.Combine(PathDir, "DIZHI.TXT");
        System.IO.File.WriteAllText(DIZHI, WeTextBoxThree.Text.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), System.Text.Encoding.UTF8);



        //签名
        string QIANMING = System.IO.Path.Combine(PathDir, "QIANMING.TXT");
        System.IO.File.WriteAllText(QIANMING, WeTextBoxTwo.Text.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), System.Text.Encoding.UTF8);


        Label3.Text = "成功：" + DateTime.Now.ToShortTimeString() + "：" + DateTime.Now.Second.ToString();
        // Response.Write("<script>alert('保存成功！')</script>");

    }
}