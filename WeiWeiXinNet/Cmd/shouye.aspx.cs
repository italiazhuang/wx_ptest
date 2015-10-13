
/*
  站点：  udoo123.tao.com
  许可： 本源代码 允许公司或者 个人开发自用微信公众号服务使用和盈利性商业 ，严禁重新包装后作为产品出售 
  本源码提供完全后续技术咨询支持  开源社区QQ群： 微微信.NET  172036441
 */
using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Globalization;

public partial class shouye : System.Web.UI.Page
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

    public string GetID()
    {
        //

        return TIME_MID;
    }

    public string GetENDAYMP3()
    {
        return EN_mp3;
    }

    private string EN_mp3 = "";


    /// <summary>
    /// 获取每日英语
    /// </summary>
    /// <returns></returns>
    public string GetENDAY()
    {
        string PathDirRS_EN = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\EN");
        

        //EN
        String[] JD = GetDataTxtEN(PathDirRS_EN);

        EN_mp3 = "http://localhost:2374/USER_DIR/USER/EN/" + JD[0];// JD[0].Replace("/", "").Replace("\n", "").Replace("\\", "/");

        return JD[1];
        //  Description = "输入help察看更多",
        //  Title = "NXUHELP签到学英语:     \n\n" + JD[1] + "\n\n" + GD_XTX + ". 您当前积[" + JiFeng + "]分,输入\"JF 或 积分\"可用积分换礼品哦！",//+ URLMP3,
        //  MusicUrl = URLMP3,// @"http://news.iciba.com//admin//tts//2014-03-18.mp3",
        //  HQMusicUrl = URLMP3//"http://www.0951uc.com/%E9%9D%92%E6%98%A5%E6%A0%A1%E5%9B%AD"


    }

    /// <summary>
    /// 得到当前的PM2.5
    /// </summary>
    /// <returns></returns>
    public string GetPM25()
    {
        string fff = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25");
       


        string result = GetPM25(fff);

        return result;

    }


    /// <summary>
    /// 获取 每日英语数据
    /// </summary>
    /// <param name="mDir"></param>
    /// <returns></returns>
    public static string[] GetDataTxtEN(string mDir)
    {

        string[] RT = { "mp3", "Test" };

        DateTime VVVV = DateTime.Now;

        string Pathx = System.IO.Path.Combine(mDir, VVVV.Year + "_" + VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + "_" + VVVV.Hour.ToString("D2") + "_EN.txt");


        if (System.IO.File.Exists(Pathx) == true)
        {

            string A = System.IO.File.ReadAllText(Pathx, System.Text.Encoding.UTF8);

            string[] RTX = A.Split('\n');
            RT[0] = RTX[0];
            RT[1] = RTX[1];
            return RT;

        }
        else
        {

            try
            {

                WebClient NN = new WebClient();
                NN.Encoding = System.Text.Encoding.UTF8;



                string UU = "http://open.iciba.com/dsapi/";

                String DA = NN.DownloadString(UU);

                string[] X = { "\",\"", "\" ,\"", "\", \"" };

                string[] Xx = { "\":\"", "\" :\"", "\": \"" };

                String[] NX = DA.Split(X, StringSplitOptions.None);

                string A1 = NX[1].Split(Xx, StringSplitOptions.None)[1];
                string A2 = NX[2].Split(Xx, StringSplitOptions.None)[1];
                string A3 = NX[3].Split(Xx, StringSplitOptions.None)[1];
                string A4 = NX[4].Split(Xx, StringSplitOptions.None)[1];
                string A5 = NX[5].Split(Xx, StringSplitOptions.None)[1];


                string B1 = ToGB2312(A1);
                string B2 = ToGB2312(A2);
                string B3 = ToGB2312(A3);
                string B4 = ToGB2312(A4);
                string B5 = ToGB2312(A5);



                String DACN = A1.Replace("\n", "") + "\n" + A2.Replace("\n", "") + " " + B3.Replace("\n", "");


                RT[0] = A1.Replace("\n", "");
                RT[1] = A2.Replace("\n", "") + " " + B3.Replace("\n", "");



                System.IO.File.WriteAllText(Pathx, DACN, System.Text.Encoding.UTF8);


                return RT;
            }
            catch
            {
                return RT;
            }
        }
    }



    /// <summary>
    /// 获取每天 PM2.5 数据
    /// </summary>
    /// <param name="mDir"></param>
    /// <returns></returns>
    public string GetPM25(string mDir)
    {
        DateTime VVVV = DateTime.Now;

        string Pathx = System.IO.Path.Combine(mDir, VVVV.Year + "_" + VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + "_" + VVVV.Hour.ToString("D2") + "_pm25.txt");
        //
        //  string Pathx = System.IO.Path.Combine(mDir, VVVV.Year + "_" + VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + "_pm25.txt");


        if (System.IO.File.Exists(Pathx) == true)
        {

            string A = System.IO.File.ReadAllText(Pathx, System.Text.Encoding.UTF8);

            return A;

        }
        else
        {

            try
            {
                System.Net.WebClient V = new System.Net.WebClient();

                V.Encoding = System.Text.Encoding.UTF8;//.GetEncoding("GB2312");

                String BOX = V.DownloadString("http://www.pm25.in/api/querys/pm2_5.json?city=%E9%93%B6%E5%B7%9D&token=EmUTd9GpyeH5P8mbx5UM");

                /*
                 [{"aqi":33,"area":"银川","pm2_5":23,"pm2_5_24h":30,"position_name":"贺兰山马莲口","primary_pollutant":null,"quality":"优","station_code":"1484A","time_point":"2014-03-09T02:00:00Z"},{"aqi":50,"area":"银川","pm2_5":24,"pm2_5_24h":43,"position_name":"宁安大街","primary_pollutant":null,"quality":"优","station_code":"1486A","time_point":"2014-03-09T02:00:00Z"},{"aqi":77,"area":"银川","pm2_5":32,"pm2_5_24h":61,"position_name":"宁化生活区","primary_pollutant":"颗粒物(PM10)","quality":"良","station_code":"1487A","time_point":"2014-03-09T02:00:00Z"},{"aqi":72,"area":"银川","pm2_5":34,"pm2_5_24h":56,"position_name":"贺兰山东路","primary_pollutant":"颗粒物(PM10)","quality":"良","station_code":"1488A","time_point":"2014-03-09T02:00:00Z"},{"aqi":77,"area":"银川","pm2_5":39,"pm2_5_24h":63,"position_name":"学院路","primary_pollutant":"颗粒物(PM10)","quality":"良","station_code":"1489A","time_point":"2014-03-09T02:00:00Z"},{"aqi":75,"area":"银川","pm2_5":55,"pm2_5_24h":63,"position_name":"银湖巷","primary_pollutant":"细颗粒物(PM2.5)","quality":"良","station_code":"1485A","time_point":"2014-03-09T02:00:00Z"},{"aqi":63,"area":"银川","pm2_5":34,"pm2_5_24h":52,"position_name":null,"primary_pollutant":"颗粒物(PM10)","quality":"良","station_code":null,"time_point":"2014-03-09T02:00:00Z"}]
                     
                 */

                String[] BB = BOX.Replace("},{", "\n").Split('\n');//.Replace("{\"weatherinfo\":{", "").Replace("}}", "");

                String[] BSS = BB[3].Split(',');
                //2 4 7 19 51 59 66 "空气质量指数："+_T(BSS[0])+" 当前1小时PM2.5细颗粒物:"+_T(BSS[2])+" 首要污染物:"+_T(BSS[5])+" 当前空气质量："+ _T(BSS[6])

                //     2014年3月4日              星期二    　　　　　  6℃~-6℃        晴         　　　　　　　     微风          小于3级  天气冷，建议着棉服、羽绒服、皮夹克加羊毛衫等冬季服装。年老体弱者宜着厚棉衣、冬大衣或厚羽绒服。
                string A = "空气指数：" + _T(BSS[0]) + ",PM2.5颗粒:" + _T(BSS[2]) + ",首要污染物:" + _T(BSS[5]) + ",空气质量：" + _T(BSS[6]);// "今天是" + _T(BSS[2]) + "" + _T(BSS[4]) + " 今日气温为" + _T(BSS[7]) + " 天气情况：" + _T(BSS[19]) + " " + _T(BSS[51]) + " 风力" + _T(BSS[59]) + "。" + _T(BSS[66]) + "明日气温:" + _T(BSS[8]) + "明日天气：" + _T(BSS[20]);

                System.IO.File.WriteAllText(Pathx, A, System.Text.Encoding.UTF8);


                return A;
            }
            catch
            {
                return " 请重试！";
            }
        }


    }

    public string _T(string dat)
    {
        return dat.Split(':')[1].Replace("\"", "");
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