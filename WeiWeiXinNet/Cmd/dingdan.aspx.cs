/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续 技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///  用户可以读取自己的订单 查看卖家回复 并且 追加留言
/// </summary>
public partial class dingdan : System.Web.UI.Page
{
    public string RID = "";

    public string MyNick = "";

    public string YZHENID;

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
            YZHENID = cookie2.Values["UserIDTime"];
            if (YZHENID == null)
            {
                Response.Redirect("help.aspx");
            }
            else
            {
                //正确读取

                RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), YZHENID);

                if (RID == "")
                {
                    Response.Redirect("help.aspx");
                }
            }
        }

         

        if (Page.IsPostBack) return;
 

        if (DropDownList1.Items.Count == 0)
        {
            //
            //订单目录
            string PathDirSYS = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\DINGDAN\\");

            try
            {
                string[] XXXX = System.IO.Directory.GetFiles(PathDirSYS ,"*"+RID+"*");

                for(int i=0;i<XXXX.Length;i++)
                {
                    string aa = XXXX[XXXX.Length-1-i];
                
                    System.IO.FileInfo xx = new System.IO.FileInfo(aa);

              

                    DropDownList1.Items.Add(new ListItem( "订单：【"+ i.ToString()+"】",  aa    ));
                }

            }
            catch
            { }

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
        int i=0;
        foreach (string a in MyXIN)
        {
            System.IO.FileInfo xxaa = new System.IO.FileInfo(a);

            DropDownList1.Items.Add( new ListItem("信件["+i.ToString()+"] "+ xxaa.LastWriteTime.ToShortDateString()   ,a    ));
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
         
    }
    protected void ButtonFour_Click(object sender, EventArgs e)
    {
        try
        {
            //
            //订单目录
            string PathDirSYS = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\shangcheng\\DINGDAN\\");



            string XIN = System.IO.Path.Combine(PathDirSYS, DropDownList1.SelectedItem.Value);

            string AA = System.IO.File.ReadAllText(XIN, System.Text.Encoding.UTF8);

            WeTextBoxOne.Text = AA.ToUpper().Replace(".PNG", "");

            Label1.Text = "读取成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

            ButtonThree.Visible = true;

            Label3.Visible = true;

            WeTextBoxTwo.Visible = true;

            

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

            string XIN = System.IO.Path.Combine(PathDir2, DropDownList1.SelectedItem.Value );


            //垃圾箱
            string PathDir2DEL = System.IO.Path.Combine(PathDir, "XIN2");

            if (System.IO.Directory.Exists(PathDir2DEL) == false)
            {
                System.IO.Directory.CreateDirectory(PathDir2DEL);
            }

            string XIN2 = System.IO.Path.Combine(PathDir2DEL, DropDownList1.SelectedItem.Value);

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

        if (DropDownList1.SelectedItem == null)
        {
            Label1.Text = " 没有选择订单! ";

            return;
        }

        if (WeTextBoxTwo.Text.Trim().Length < 1)
        {
            Label1.Text = " 回复太短! ";

            return;
        }

        

        //
        //订单目录
        string PathDirSYS = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\shangcheng\\DINGDAN\\");

        string XIN = System.IO.Path.Combine(PathDirSYS, DropDownList1.SelectedItem.Value );

        //追加 联系方式 到订单
        StreamWriter sws = new StreamWriter(XIN, true, System.Text.Encoding.UTF8);
        sws.WriteLine("=======================");
        sws.WriteLine("买家："+ DateTime.Now.ToString()+"\t"+  WeTextBoxTwo.Text.Trim().Replace("\n", " ").Replace("\t", " "));
        sws.Close();

        WeTextBoxOne.Text = "";

        WeTextBoxTwo.Text = "";





        Label1.Text = " 信件回复成功! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

        //直接写到对方收件箱


    }
}