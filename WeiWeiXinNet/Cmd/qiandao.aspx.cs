
/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions; 

public partial class cmd_qiandao : System.Web.UI.Page
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


         //    if (Page.IsPostBack) return;

       
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
    /// 获得用户 签到数据数据
    /// </summary>
    /// <returns></returns>
    public string GetDATA_ONE()
    {

        DateTime VVVV = DateTime.Now;

        string PathDirRS2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\"+ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
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

        //
        string PathxQD = System.IO.Path.Combine(PathDirRS3, VVVV.Year + "_" + VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + "_QD.txt");

        String GD_XTX = "";

        if (System.IO.File.Exists(PathxQD) == false)
        {

            string PathDirRSQD = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\");
            

            DateTime QDVVVV = DateTime.Now;


            string QAXNUMPath = System.IO.Path.Combine(PathDirRSQD, QDVVVV.Year + "_" + QDVVVV.Month.ToString("D2") + "_" + (QDVVVV.Day).ToString("D2") + "qdsernum.txt");
            if (System.IO.File.Exists(QAXNUMPath) == false)
                System.IO.File.WriteAllText(QAXNUMPath, "0");

            string QAXNUM = System.IO.File.ReadAllText(QAXNUMPath);

            int LLNUM = 0;
            try
            {
                LLNUM = Int32.Parse(QAXNUM) + 1;// 147091;
                System.IO.File.WriteAllText(QAXNUMPath, LLNUM.ToString());
            }
            catch
            {
                LLNUM = 1;
            }


               //系统目录 存放目录  每天第一次签到
                string PathFileOneRT = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT.DLL");
               String ModelQD = System.IO.File.ReadAllText(PathFileOneRT, System.Text.Encoding.UTF8);

            System.IO.File.WriteAllText(PathxQD, VVVV.ToShortTimeString());
            GD_XTX =     string.Format(ModelQD,  VVVV.ToShortTimeString()  ,  LLNUM.ToString()) ;//  "成功{0} 签到\n您是今天第{1}位签到者";
        }
        else
        {
            //系统目录 存放目录 每天第二次以后签到
            string PathFileOneRT = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT2.DLL");
            String ModelQD2 = System.IO.File.ReadAllText(PathFileOneRT, System.Text.Encoding.UTF8);
           
            String xxxx = System.IO.File.ReadAllText(PathxQD);
            GD_XTX = string.Format(ModelQD2, xxxx);//   "已于{0}签到";

        }

        return GD_XTX;


    }

    public  string GetDATA()
    {
        string QDDATA = GetDATA_ONE();

        string XXXX = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"cpbiaoge\"> <tbody>";

        XXXX += " <tr><td>  " + QDDATA + " </td></tr>";
        XXXX += "    <tr > <td>历史上的" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日  </td> </tr>";
        XXXX += "  <tr><td > " + GetHSDAY() + "</td> </tr>";
        XXXX += "</tbody></table>";

        return XXXX;
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


    /// <summary>
    /// 获取每日历史
    /// </summary>
    /// <returns></returns>
    public string GetHSDAY()
    {
        string PathDirRS_EN = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HS");
        
      
        String JD = GetDataHistory(PathDirRS_EN);



        string str = JD;


        //删除内含的 样式表代码
        Regex CutStyle = new Regex(@"<style([^>])*>(\w|\W)*?</style([^>])*>", RegexOptions.IgnoreCase);




        Regex BrHtml = new Regex("<span(.*?)>", RegexOptions.IgnoreCase);
       string  TempStr = BrHtml.Replace(str , "");

       Regex BrHtml2 = new Regex("<mark(.*?)>", RegexOptions.IgnoreCase);
         TempStr = BrHtml2.Replace(TempStr, "");

         Regex BrHtml3 = new Regex("<sup(.*?)>", RegexOptions.IgnoreCase);
         TempStr = BrHtml3.Replace(TempStr, "");


        return TempStr;

        
       

    }

 


    /// <summary>
    /// 获取  数据
    /// </summary>
    /// <param name="mDir"></param>
    /// <returns></returns>
    private string  GetDataHistory(string mDir)
    {
        string RT = "";
        DateTime VVVV = DateTime.Now;
       string Pathx = System.IO.Path.Combine(mDir,   VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + "_HS.txt");

        if (System.IO.File.Exists(Pathx) == true  )
        {
            string A = System.IO.File.ReadAllText(Pathx, System.Text.Encoding.UTF8);            
            return A;
        }
        else
        {
            try
            {

                WebClient NN = new WebClient();
                NN.Encoding = System.Text.Encoding.UTF8;
                NN.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");

                string UU = "http://zh.wikipedia.org/wiki/4月9日";

                String DA = NN.DownloadString(UU);

             

                string A1 = "title=\"编辑段落：大事记\">编辑</a><span class=\"mw-editsection-bracket\">]</span></span></h2>";
                
                string A2 = "<h2><span class=\"mw-headline\"";

                int aa1 = DA.IndexOf(A1);
                if (aa1 > 0)
                {
                    int aa2 = DA.IndexOf(A2, aa1);

                    if (aa2 > 0)
                    {
                        RT = DA.Substring(aa1 + A1.Length, aa2 - aa1-A1.Length);

                         RT = Regex.Replace(RT, "<a (.*?)>", "", RegexOptions.Compiled);//过滤a标签
                        RT = Regex.Replace(RT, "</a>", "");//替换a结束标签

                        RT = RT.Replace("[來源請求]", "");

                        
                    }

                }

                 
                /*
                Regex reg = new Regex("(.*)(<div class=\"listren\">)(.*?)(</div>)(.*)");
                MatchCollection mc = reg.Matches(DA);

                string HH = "";
                foreach (Match m in mc)
                {
                   HH += m.Value + "\n";
                }
                */


                System.IO.File.WriteAllText(Pathx, RT, System.Text.Encoding.UTF8);


            }
            catch
            {
                
            }


            return RT;

        }
    }

}