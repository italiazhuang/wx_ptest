
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
using System.IO;
using System.Security.Cryptography;

public partial class cmd_jifen : System.Web.UI.Page
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



        // if (Page.IsPostBack) return;

          
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

    public string GetDATA()
    {
        //
        string PathDirRS2 = System.IO.Path.Combine( Server.MapPath("~"), "USER_DIR\\USER\\"+ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
        if (System.IO.Directory.Exists(PathDirRS2) == false)
        {
            System.IO.Directory.CreateDirectory(PathDirRS2);
        }

        int JiFeng = 0;

        string PathDirRS3 = System.IO.Path.Combine(PathDirRS2, "QD");
        if (System.IO.Directory.Exists(PathDirRS3) == false)
        {
            System.IO.Directory.CreateDirectory(PathDirRS3);
            JiFeng = 0;
        }

        string PathDirRSQD = System.IO.Path.Combine( Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\");
        

        DateTime QDVVVV = DateTime.Now;

        //模板
        string QAXNUMPathJF_TXT = System.IO.File.ReadAllText( System.IO.Path.Combine(PathDirRSQD, "JF.DLL"), System.Text.Encoding.UTF8);


        string QAXNUMPathJF = System.IO.Path.Combine(PathDirRSQD, "PRIZE.DLL");
        if (System.IO.File.Exists(QAXNUMPathJF) == false)
            System.IO.File.WriteAllText(QAXNUMPathJF, "0\r\n1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11");

        //  string QAXNUM = System.IO.File.ReadAllText(QAXNUMPathJF);

        JiFeng = System.IO.Directory.GetFiles(PathDirRS3).Length;

        int JFDENGJ = JiFeng / 7 + 1;
        
      
        string result = "";
        //if (JFDENGJ >= 7)
        //{
        //    String JFDAT = getJFDAT(7, QAXNUMPathJF);

        //    result = " <P>  您当前积" + JiFeng.ToString() + "分现在的等级是最高级,您获得了7个神秘礼品包:</P>\n" + JFDAT + "\r\n  <P>  全新的神秘礼品赠送计划即将开始!</P>";
        //}
        //else
        //{
        String JFDAT = getJFDAT(JFDENGJ, QAXNUMPathJF);//  您当前积{0}分,积分等级{1},您获得了神秘礼品包:\n{2} 

        result = string.Format(QAXNUMPathJF_TXT, JiFeng.ToString(), JFDENGJ.ToString(), JFDAT);// " <P> 您当前积" + JiFeng.ToString() + "分,等级" + JFDENGJ.ToString() + "级,您获得了" + JFDENGJ.ToString() + "个神秘礼品包:</P>\n" + JFDAT + "\n\n <P>   距离下一级还需要7个积分,请再接再厉哦! @签到赚积分！</P>";
       // }


        return result;
    }

    /// <summary>
    /// 派送礼包
    /// </summary>
    /// <param name="JF"></param>
    /// <param name="path"></param>
    /// <returns></returns>
      string getJFDAT(int JF, string path)
    {
        string RT = "";

        System.Collections.ArrayList XL = new System.Collections.ArrayList();
        try
        {
            string[] XS = System.IO.File.ReadAllLines(path, System.Text.Encoding.UTF8);

            foreach (string a in XS)
            {
                if (a.Length > 10)
                    XL.Add( a.Trim().Replace("\r", "").Replace("\n", ""));

            }

        }
        catch
        {

        }

        for (int i = 0; i < JF; i++)
        {
            if (i < XL.Count)
            {
                RT += "<P>" + XL[i].ToString() + "</P>\n";
            }
        }

        return RT;
    }
}