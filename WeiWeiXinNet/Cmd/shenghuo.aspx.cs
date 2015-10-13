/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务 使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class shenghuo : System.Web.UI.Page
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


    }

    public string GetIDX()
    {
        //

        return TIME_MID;
    }

    /// <summary>
    /// 读取微墙数据
    /// </summary>
    /// <returns></returns>
    public string GetID()
    {
        //
        string PathDirRSWQ = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\WEIQIANG\\");
    

        ArrayList MMM = new ArrayList();

        /*
          <li class="title"><span class="none smallspan">店铺信息</span></li> <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge"> <tbody>
                    <tr><td>
                            ff&nbsp;
                        </td></tr>
 
                </tbody> </table>
         */



        for (int i = 0; i < 7; i++)
        {
            DateTime QD = DateTime.Now.AddDays(-1 * i);
            ArrayList MX = GetMySetDataGW(PathDirRSWQ, QD);
            //    MMM.Add("<p>" + QD.ToShortDateString() + "</p>");

            MMM.Add("<ul class=\"round\"><li class=\"title\">" + QD.ToShortDateString() + " </li> <table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"cpbiaoge\"> <tbody>");


            for (int ii = MX.Count - 1; ii >= 0; ii--)
            {
                MMM.Add("<tr><td>" + MX[ii] + "</td></tr>");
                if (MMM.Count > 30)
                {
                    MMM.Add(" </tbody></table>");
                    goto XXCC;
                }
            }

            MMM.Add(" </tbody></table></ul>");
        }
    XXCC:

        String ND = "";

        for (int i = 0; i < MMM.Count; i++)
        {
            ND += ("<p>" + MMM[i].ToString() + "</p>");
        }

        return "<P align=\"right\"><font color=\"#0000FF\"><a onclick=\"d_weixinqiang();\"  href=\"#\">发布信息到微墙</a></font></P>" + ND;
    }


    /// <summary>
    /// 读取 微信墙
    /// </summary>
    /// <param name="PathFile"></param>
    /// <returns></returns>
    public ArrayList GetMySetDataGW(string PathFileDir, DateTime QDVVVV)
    {
        string QAXNUMPathWQ = System.IO.Path.Combine(PathFileDir, QDVVVV.Year + "_" + QDVVVV.Month.ToString("D2") + "_" + (QDVVVV.Day).ToString("D2") + "_WQ.txt");
        if (System.IO.File.Exists(QAXNUMPathWQ) == false)
            System.IO.File.WriteAllText(QAXNUMPathWQ, DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + " " + "小萌: 今天，开始新的一天!\r\n");

        string[] myData = System.IO.File.ReadAllLines(QAXNUMPathWQ, System.Text.Encoding.UTF8);
        ArrayList MMM = new ArrayList();
        for (int i = 0; i < myData.Length; i++)
        {
            string MD = myData[i];
            if (MD.Trim().Length > 0)
            {
                MMM.Add(MD);
            }
        }
        return MMM;
    }

}