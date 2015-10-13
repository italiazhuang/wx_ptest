/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者个人开发自用微信公众号服务使用和盈利性 商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class cmd_xiaomeng : System.Web.UI.Page
{
    public string RID = "";
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
        
        if (Page.IsPostBack) return;

    }

    public string GetDATA()
    {
        String SSS = "<audio src=\"" + MP3.Replace("\r", "").Replace("\n", "") + "\">您的浏览器不支持 audio 标签</audio>";

        return "";// SSS;
    }
    protected void ButtonOne_Click(object sender, EventArgs e)
    {

        WeTextBoxTwo.Text = "ME:" + WeTextBoxOne.Text + "\r\nXM:" + GetDataXAIML("http://127.0.0.1:48080/", RID, WeTextBoxOne.Text, "template");

        WeTextBoxOne.Text = "";
    }

    /// <summary>
    ///   音乐
    /// </summary>
    public static string MP3 = "";

    /// <summary>
    /// 获取数据 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="id"></param>
    /// <param name="dat"></param>
    /// <returns></returns>
    public static string GetDataXAIML(string url, string id, string dat, string lv)
    {
        try
        {
            WebClient NN = new WebClient();
            NN.Encoding = System.Text.Encoding.UTF8;

            string UU = url + "weibao|" + id + "|" + lv + "|" + ToUnicode(dat);

            String DA = NN.DownloadString(UU);

            string[] XXX = DA.Split('|');

            MP3 = XXX[1];

            String DACN = ToGB2312(XXX[0]);

            return DACN;
        }
        catch
        {
            return "漂流瓶服务器 故障";
        }

    }

    /// <summary>
    /// 汉字转换为Unicode编码
    /// </summary>
    /// <param name="str">要编码的汉字字符串</param>
    /// <returns>Unicode编码的的字符串</returns>
    public static string ToUnicode(string str)
    {
        byte[] bts = Encoding.Unicode.GetBytes(str);
        string r = "";
        for (int i = 0; i < bts.Length; i += 2) r += "\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
        return r;
    }
    /// <summary>
    /// 将Unicode编码转换为汉字字符串
    /// </summary>
    /// <param name="str">Unicode编码字符串</param>
    /// <returns>汉字字符串</returns>
    public static string ToGB2312(string str)
    {
        string r = "";
        MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        byte[] bts = new byte[2];
        foreach (Match m in mc)
        {
            bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
            bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
            r += Encoding.Unicode.GetString(bts);
        }
        return r;
    }

}