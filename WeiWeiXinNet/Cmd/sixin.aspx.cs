/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许 公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续 技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cmd_sixin : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";

    public string YZHENID;

    string TIME_MID = "";

    protected void Page_Load(object sender, EventArgs e)
    {


        //string id = Request.QueryString["id"];

        //YZHENID = id;

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

        if (Label2.Text == "0")
        {

            Label2.Text = "1";
            //   
            MyNick = GetNick();
            Label5.Text = MyNick;
            if (MyNick == "")
            {
                // Response.Write("<script>alert('请首先到  我的》个人设置 中设置个人信息') ; window.open(\"" + "../SetMyData.aspx?id=" + id + "\") </script>  ");


                string XXX = "<script language=\"javascript\"> alert(\"请首先设置个人信息！\");  self.location='" + "../SetMyData.aspx?id=" + RID + "';   </script>";

                Response.Write(XXX);
                //  Response.Redirect("../SetMyData.aspx?id="+id);

            }

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
    /// 收私信
    /// </summary>
    /// <returns></returns>
    public string USerSI()
    {


        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

        if (System.IO.Directory.Exists(PathDir) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir);
            string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
        }

        //用户私信 目录
        string PathDir2 = System.IO.Path.Combine(PathDir, "XIN");

        if (System.IO.Directory.Exists(PathDir2) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir2);
            //   string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            //  System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
        }

        string[] MyXIN = System.IO.Directory.GetFiles(PathDir2);

        DropDownList1.Items.Clear();

        foreach (string a in MyXIN)
        {
            System.IO.FileInfo xxaa = new System.IO.FileInfo(a);

            DropDownList1.Items.Add(xxaa.Name.ToLower().Replace(".txt", ""));
        }

        //用户私信 过期 目录   用户删除的信件在此存放
        string PathDir2OLD = System.IO.Path.Combine(PathDir, "SMS2");

        if (System.IO.Directory.Exists(PathDir2OLD) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir2OLD);
            //   string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            //  System.IO.File.WriteAllText(PathUser, RID, System.Text.Encoding.UTF8);
        }
        //

        Label1.Text = "收信成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        //收私信  遍历私信文件夹下的每一个  信件的标题是   时间_发送者ID   //
        return "";

    }

    /// <summary>
    /// 回复私信  
    /// </summary>
    /// <returns></returns>
    public bool SendSX()
    {
        //直接记录到收件用户的 个人私信文件夹


        //信件的标题是   时间_发送者ID
        //内容
        //[1] 发件人 
        //[2] 发件人昵称 + 学院 + 性别
        //[3] 信件内容

        return true;

    }



    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        USerSI();

        if (DropDownList1.Items.Count > 0)
        {
            ButtonFour.Visible = true;

            ButtonTwo.Visible = true;
        }
        else
        {
            ButtonFour.Visible = false;
            ButtonThree.Visible = false;
            ButtonTwo.Visible = false;
        }
    }
    protected void ButtonFour_Click(object sender, EventArgs e)
    {
        try
        {
            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

            //用户私信 目录
            string PathDir2 = System.IO.Path.Combine(PathDir, "XIN");

            string XIN = System.IO.Path.Combine(PathDir2, DropDownList1.Text + ".txt");

            string[] AA = System.IO.File.ReadAllLines(XIN, System.Text.Encoding.UTF8);

            WeTextBoxOne.Text = AA[1] + " " + AA[0] + "\r\n" + AA[3];

            Label1.Text = "读取成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

            ButtonThree.Visible = true;

            Label3.Visible = true;

            WeTextBoxTwo.Visible = true;

            Label4.Text = AA[2];

          //  string XXX = "self.location='send_xin.aspx'";//?id=" + YZHENID + "&md=" + RID + "|" + MyNick + "|" + AA[2] + "'";

            //  Label4.Text = "";
            //   ButtonThree.Attributes.Add("onclick",XXX);

            //   ButtonThree.Attributes.Add("onclick", " alert(\"请首先设置个人信息！\");");
        }
        catch
        {
            Label1.Text = "读取信件失败! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        }


    }
    protected void ButtonTwo_Click(object sender, EventArgs e)
    {
        try
        {
            string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));

            //用户私信 目录
            string PathDir2 = System.IO.Path.Combine(PathDir, "XIN");

            string XIN = System.IO.Path.Combine(PathDir2, DropDownList1.Text + ".txt");


            //垃圾箱
            string PathDir2DEL = System.IO.Path.Combine(PathDir, "XIN2");

            if (System.IO.Directory.Exists(PathDir2DEL) == false)
            {
                System.IO.Directory.CreateDirectory(PathDir2DEL);
            }

            string XIN2 = System.IO.Path.Combine(PathDir2DEL, DropDownList1.Text + ".txt");

            System.IO.File.Copy(XIN, XIN2);

            System.IO.File.Delete(XIN);

            USerSI();

            Label1.Text = "删除信件成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

            WeTextBoxOne.Text = "";
            ButtonThree.Visible = false;

            Label3.Visible = false;

            WeTextBoxTwo.Visible = false;

        }
        catch
        {
            Label1.Text = "删除信件失败! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        }
    }
    protected void ButtonThree_Click(object sender, EventArgs e)
    {
        //


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {

        WeTextBoxTwo.Text = WeTextBoxTwo.Text.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ");


        if (WeTextBoxTwo.Text.Trim().Length < 1)
        {
            Label1.Text = " 回复太短! ";

            return;
        }

        //我的ID  我的昵称 收件人ID
        string SHOU_ID = Label4.Text;  //收件人ID

        string TXT = Label5.Text + "\r\n" + DateTime.Now.ToString() + "\r\n" + RID + "\r\n" + WeTextBoxTwo.Text.Trim();



        //获取用户昵称
        string PathDir = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(SHOU_ID) + "\\XIN");

        if (System.IO.Directory.Exists(PathDir) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir);

        }

        string[] ss = { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "{", "[", "}", "]", "|", "\\", ":", ";", "\"", "'", ",", "<", ">", ".", "?", "/", "\r", "\n", "  ", "\t", " " };

        string XXNAME = Label5.Text;

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


        WeTextBoxTwo.Text = "";





        Label1.Text = " 信件回复成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        //直接写到对方收件箱


    }
}