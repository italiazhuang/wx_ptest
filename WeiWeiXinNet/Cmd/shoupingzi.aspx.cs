﻿/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后 作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cmd_shoupingzi : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";
    string TIME_MID = "";

    protected void Page_Load(object sender, EventArgs e)
    {



        //string id = Request.QueryString["id"];

        //if (id == null)
        //    Response.Redirect("../help.aspx");
        //if (id == "")
        //    Response.Redirect("../help.aspx");


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

     //   if (Page.IsPostBack) return;


        if (Label3.Text == "0")
        {
            Label3.Text = "1";

            //收瓶子
            GetPingZI();

        }


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

        return RID;
    }

    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GetPingZI()
    {
        string RTY = ClassLibraryWeiBao.ClassServerCOM.GetDataXPLP("http://127.0.0.1:48090/weiwei/", RID, "收瓶子");

        GH(RTY.IndexOf("[") > 0);

        int a1 = RTY.IndexOf("[");
        if (a1 > 0)
        {
            int a2 = RTY.IndexOf("]", a1);
            if (a2 > 0)
            {
                string AA = RTY.Substring(a1 + 1, a2 - a1 - 1);
                WeTextBoxTwo.Text = AA.Trim();
            }

        }


        Label2.Text = RTY;


    }
    protected void ButtonTwo_Click(object sender, EventArgs e)
    {

        if (WeTextBoxTwo.Text.Trim() == "" || WeTextBoxOne.Text.Trim() == "")
        {
            Label2.Text = "请输入正确的数据";
            return;
        }


        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

        if (System.IO.Directory.Exists(PathDir) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir);
            string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
        }

        //记录用户输入
        //用户日志文件
        string Nsame = DateTime.Now.ToString().Replace(":", "_").Replace("-", "_").Replace("\\", "_").Replace("/", "_").Replace(" ", "_") + ".txt";
        string PathUserData = System.IO.Path.Combine(PathDir, Nsame);
        //记录用户输入到用户文件
        StreamWriter sws = new StreamWriter(PathUserData, true, System.Text.Encoding.UTF8);
        sws.WriteLine(WeTextBoxOne.Text.Replace("\n", " "));
        sws.Close();

        String aNiCKX = "某同学";

        try
        {
            //昵称
            string NICK = System.IO.Path.Combine(PathDir, "NICK.TXT");
            if (System.IO.File.Exists(NICK) == true)
            {
                aNiCKX = System.IO.File.ReadAllText(NICK, System.Text.Encoding.UTF8);
            }
        }
        catch
        { }
        String aXUEYUANX = "物电";

        try
        {
            //学院
            string XUEYUAN = System.IO.Path.Combine(PathDir, "XUEYUAN.TXT");
            if (System.IO.File.Exists(XUEYUAN) == true)
            {
                aXUEYUANX = System.IO.File.ReadAllText(XUEYUAN, System.Text.Encoding.UTF8);
            }
        }
        catch
        { }
        aXUEYUANX = ClassLibraryWeiBao.ClassServerCOM.GetXueYuanShortName(aXUEYUANX);


        String aXB = "女";

        try
        {
            //性别
            string XINGBIE = System.IO.Path.Combine(PathDir, "XINGBIE.TXT");
            if (System.IO.File.Exists(XINGBIE) == true)
            {
                aXB = System.IO.File.ReadAllText(XINGBIE, System.Text.Encoding.UTF8);
            }
        }
        catch
        { }

        //加入的数据
        string RTT = aXUEYUANX + "-" + aXB + ":" + WeTextBoxOne.Text.Replace("\n", " ").Replace(":", "：").Replace("@", "$").Replace("[", "【").Replace("]", "】");

        //  string RTY = ClassLibraryWeiBao.ClassServerCOM.GetDataXPLP("http://127.0.0.1:48090/weiwei/", RID, "扔瓶子@" + RTT);

        string YY = "回复@" + WeTextBoxTwo.Text + "@" + RTT;

        string RTY = ClassLibraryWeiBao.ClassServerCOM.GetDataXPLP("http://127.0.0.1:48090/weiwei/", RID, YY);

        GH(RTY.IndexOf("[") > 0);

        Label2.Text = RTY;
    }

    public void GH(bool Show)
    {


        Label4.Visible = Show;
        Label5.Visible = Show;

        WeTextBoxOne.Visible = Show;
        WeTextBoxTwo.Visible = Show;

        ButtonTwo.Visible = Show;

    }

}