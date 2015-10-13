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
using System.Collections;

public partial class Default2 : System.Web.UI.Page
{
    static string TIME_MID = "";
    static string RID = "";
    public string MyNick = "";
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
        MyNick = GetNick();
        if (MyNick == "")
        {
            // Response.Write("<script>alert('请首先到  我的》个人设置 中设置个人信息') ; window.open(\"" + "../SetMyData.aspx?id=" + id + "\") </script>  ");
            string XXX = "<script language=\"javascript\"> alert(\"请首先设置个人信息！\");  self.location='" + "../SetMyData.aspx?id=" + TIME_MID + "';   </script>";
            Response.Write(XXX);
            return;
            //  Response.Redirect("../SetMyData.aspx?id="+id);
        }
        Label1.Text = GetNiCK_X(RID);
    }

    public string GetNickX()
    {
        return Label1.Text;
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

    /// <summary>
    ///
    /// </summary>
    public string GetNiCK_X(string RR)
    {
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
        sws.WriteLine(RR.Replace("\n", " "));
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
        string RTT = aNiCKX + "-" + aXB;
        return RTT;
    }


    public string GetID()
    {
        //
        return TIME_MID;
    }
    protected void ButtonOne_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// 获取聊天数据
    /// </summary>
    /// <param name="a"></param>
    /// <param name="ty"></param>
    public static string GetLIST(string a, string ty, string NICKXX)
    {
        string RTY = ClassLibraryWeiBao.ClassServerCOM.GetDataXPLP_X("http://127.0.0.1:48095/weiwei/", RID, ty, a.Replace("@", "$").Replace("[", "【").Replace("]", "】").Replace("|", "~"));
        string[] xxx = RTY.Split('|');
        if (xxx[0] != "NEWDATA")
        {
            return "数据错误";
        }
        ArrayList CCC1 = new ArrayList();
        ArrayList CCC2 = new ArrayList();
        string XXGG = "";
        for (int i = 2; i < xxx.Length; i++)
        {
            int llx = xxx.Length - i + 1;
            string[] XSS = xxx[llx].Split('\n');
            //tableListBox.Attributes.Add("onclick", "doubleClick()");
            char[] Xs = { ' ', '\n' };
            string[] XXXSS = XSS[0].Replace("：", "\n").Split(Xs);
            string AAA = "jBox.open('iframe:send_xin.aspx?id=" + TIME_MID + "&md=" + RID + "|" + NICKXX + "|" + XSS[1] + "', '微信助手-发送私信', $(window).width() * 0.9, $(window).height() * 0.6);";
            string AHTMLx = "&nbsp;<a onclick=\"" + AAA + "\"  href=\"#\">[>>]</a>&nbsp;";
            XXGG += AHTMLx + XSS[0] + "<br/>";
        }
        return XXGG;
    }
    [System.Web.Services.WebMethod]//这个属性很重要，要想异步调用，不需添加 
    public static string DoEasy(object o)
    {
        string[] XX = o.ToString().Split('\r');
        if (XX[1].ToString() == "W_W" || XX[1].Trim().Length == 0)
        {
            return GetLIST("", "CHAT_GET|0", XX[0]);
        }
        string TXT = XX[0] + ":" + XX[1];
        return GetLIST(TXT, "CHAT_ADD|0", XX[0]);
    }
}