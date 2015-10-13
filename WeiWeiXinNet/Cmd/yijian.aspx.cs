/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号 服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cmd_yijian : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";
    string TIME_MID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
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

      // if (Page.IsPostBack) return;

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
    ///  
    /// </summary>
    public bool RenPZ(string RR)
    {
        try
        {

            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

            if (System.IO.Directory.Exists(PathDir) == false)
            {   //建立用户目录
                System.IO.Directory.CreateDirectory(PathDir);
                string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
                System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
            }


            string PathDir2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\YIJIAN\\");

            



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


            string RTT = RID + "\r\n" + aXUEYUANX + "\r\n" + aXB + "\r\n" + RR.Replace("\n", " ").Replace(":", "：");
            DateTime cc = DateTime.Now;
            string NWS = cc.Year.ToString("D2") + cc.Month.ToString("D2") + cc.Day.ToString("D2") + cc.Hour.ToString("D2") + cc.Minute.ToString("D2") + cc.Second.ToString("D2") + cc.Millisecond.ToString("D3");

            string yijian22 = System.IO.Path.Combine(PathDir2, NWS + ".TXT");


            System.IO.File.WriteAllText(yijian22, RTT, System.Text.Encoding.UTF8);

            Label2.Text = "感谢您的意见，提交成功！ 我们会及时处理！";
            return true;

        }
        catch
        {
            Label2.Text = "系统故障，请重新提交！";
        }


        return false;

    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        if (RenPZ(WeTextBoxOne.Text))
        {
            WeTextBoxOne.Visible = false;
            ButtonOne.Visible = false;
        }

    }
}