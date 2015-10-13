/*
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
using System.Collections;

using System.Reflection;
using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;


public partial class shangcheng : System.Web.UI.Page
{
    /// <summary>
    /// 加密后的 时间戳
    /// </summary>
    static string TIME_MID = "";
    static string RID = "";


    public string MyNick = "";



    protected void Page_Load(object sender, EventArgs e)
    {


        string id = Request.QueryString["id"];
        if (id != null)
        {
            TIME_MID = id;
            RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), TIME_MID);

            //保存 一个 cookie
            DateTime dtExpire = DateTime.Now.AddDays(7);
            HttpCookie cookie = new HttpCookie("weiweixing08");
            cookie.Values.Add("UserIDTime", TIME_MID);
            cookie.Expires = dtExpire;
            Response.Cookies.Add(cookie);

        }
        else
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
        }
        //  Label2.Text = ListBox1.Items.Count.ToString();





        MyNick = GetNick();

        if (MyNick == "")
        {
            // Response.Write("<script>alert('请首先到  我的》个人设置 中设置个人信息') ; window.open(\"" + "../SetMyData.aspx?id=" + id + "\") </script>  ");


            string XXX = "<script language=\"javascript\"> alert(\"请首先设置个人信息！\");  self.location='" + "../SetMyData.aspx?id=" + TIME_MID + "';   </script>";

            Response.Write(XXX);

            return;
            //  Response.Redirect("../SetMyData.aspx?id="+id);
        }



        if (Page.IsPostBack) return;

        string PathDir = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
        string PathDizHI = System.IO.Path.Combine(PathDir, "liuYan.TXT");

        try
        {
            if (WeTextBoxOne.Text.Trim().Length == 0 || WeTextBoxOne.Text == "地址和联系方式：")
            {
                //读取地址 和 联系方式
                WeTextBoxOne.Text = System.IO.File.ReadAllText(PathDizHI, System.Text.Encoding.UTF8);

                if (WeTextBoxOne.Text.Trim() == "")
                {
                    WeTextBoxOne.Text = "买家留言：【请确认送货地址】";
                }
            }
        }
        catch
        {

        }



        //  Label1.Text = GetNiCK_X(RID);


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
    /// 返回总的数量
    /// </summary>
    /// <returns></returns>
    /*
    public string GetCount()
    {
        try
        {
            // string FF=  "function demo04x() {  jBox.open(\"iframe:http://www.baidu.com\", \"微信助手\", $(window).width() * 0.96, $(window).height()*0.6);   }";

            string PathDirRSQD = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\");

            if (System.IO.Directory.Exists(PathDirRSQD) == false)
            {
                System.IO.Directory.CreateDirectory(PathDirRSQD);
            }

            string[] MyLIST = System.IO.Directory.GetFiles(PathDirRSQD, "*.png");

            return MyLIST.Length.ToString();
        }
        catch
        {
            return "0";
        }
    }
    */


    /// <summary>
    /// 获取 当前商品信息
    /// </summary>
    /// <param name="a">商品编号</param>
    /// <param name="ty"></param>
    public static string GetLIST()
    {

        //获得购物车
        Hashtable MMM = GetGouwuChe();

        string PathFile = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\goods.dll"); //图文 关键词回复目录)

        /*
     <table width='100%'  border='1' align='left' cellpadding='0' cellspacing='4' id='myTable'>    
             <tr class='goodshead'><td height='24'> </td></tr>
  
    <tr class='goodsline'><td height='24'><table width='100%'  border='0' align='left' cellpadding='0' cellspacing='4' id='myTable2'><tr class='goodsline'><td width='50' rowspan='2'>
         <img src='' alt='欢迎选购' name='AAA' width='50' height='50' id='AAA' style='background-color: #99CC99' /></td>
        <td width='1179' height='24'><h5>商品名称 商品价格</h5></td></tr>
          
      <tr class='goodsline'><td height='24'><h5>商品 购买</h5></td></tr></table></td></tr>
  
</table>
         
         */


        try
        {
            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadFile(PathFile);

            string RT = "<tr><td height='24'>" + GetAllQian(CMsgData, MMM) + "</td></tr>";



            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                int WuNum = 0;
                if (MMM.Contains(CMsgData.Items[i].Title) == true)
                {
                    WuNum = (int)MMM[CMsgData.Items[i].Title];
                }

                string XXX1 = "javascript:AddProduct('" + CMsgData.Items[i].Title + "','+','0');void(0);";
                string XXX2 = "javascript:AddProduct('" + CMsgData.Items[i].Title + "','-','0');void(0);";
                string NOW = " 当前数量【" + WuNum.ToString() + "】<a href=\"" + XXX1 + "\">[＋]</a> " + " <a href=\"" + XXX2 + "\"> [－]</a>";
                string url = "USER_DIR\\SYSUSER\\Shangcheng\\goods\\" + CMsgData.Items[i].Url;

                RT += "<tr><td height='24'><table width='100%'  border='0' cellpadding='0' cellspacing='0' id='myTable2' class='cpbiaoge'><tr><td width='50' rowspan='2'>";
                RT += "<a href='" + url + "'><img src='" + CMsgData.Items[i].PicUrl + "' alt='欢迎选购' name='AAA' width='50' height='50' id='AAA' style='background-color: #99CC99' /></a></td>";
                RT += "<td><h5>" + CMsgData.Items[i].Title + "  &nbsp; &nbsp;售价:" + CMsgData.Items[i].Description + "</h5></td></tr>";
                RT += "<tr><td height='24'><h5>" + NOW + "</h5></td></tr></table></td></tr>";


            }

            RT = "<table width='100%'  border='0' cellpadding='0' cellspacing='0' id='myTable'  class='cpbiaoge'>" + RT + "</table>\r\n";
            return RT;




        }
        catch
        {
            return "数据配置错误";
        }



    }


    [System.Web.Services.WebMethod]//这个属性很重要，要想异步调用，不需添加 
    public static string DoEasy(object o)
    {
        try
        {
            string XXX = GetLIST();


            return XXX;
        }
        catch
        {
            string XXX = GetLIST();


            return XXX;
        }

    }


    [System.Web.Services.WebMethod]//这个属性很重要，要想异步调用，不需添加 
    public static string DoEasyP(object o)
    {

        //记录 用户购物车内容

        string[] AAA = o.ToString().Split('|');

        AddGouWU(AAA[0], AAA[1]);

        string aaaa = GetLIST();

        return aaaa;

        //  SaveGouwuChe
        //xiedao


    }

    /// <summary>
    /// 增加一个数据  保存一个数据到购物车
    /// </summary>
    public static void AddGouWU(string WUID, string JJ)
    {
        Hashtable MMM = GetGouwuChe();

        if (MMM.Contains(WUID) == false)
        {
            if (JJ == "+")
            {
                MMM.Add(WUID, 1);
            }
        }
        else
        {
            int XXX = (int)MMM[WUID];

            if (JJ == "+")
            {
                MMM[WUID] = XXX + 1;
            }
            else
            {
                if (XXX > 0)
                {
                    MMM[WUID] = XXX - 1;
                }
            }
        }

        SaveGouwuChe(MMM);

    }

    /// <summary>
    /// 获得购物车数据
    /// </summary>
    /// <returns></returns>
    public static Hashtable GetGouwuChe()
    {

        Hashtable MM = new Hashtable();

        //获取用户昵称
        string PathDir = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
        string PathUser = System.IO.Path.Combine(PathDir, "SHANGCHENG.TXT");
        try
        {

            string[] NICK_D = System.IO.File.ReadAllLines(PathUser, System.Text.Encoding.UTF8);

            foreach (string aa in NICK_D)
            {
                if (aa.IndexOf('\t') > 0)
                {
                    string[] AAAA = aa.Split('\t');

                    if (MM.Contains(AAAA[0].Trim()) == false)
                    {
                        MM.Add(AAAA[0].Trim(), Int32.Parse(AAAA[1].Trim())); //购物车增加一个 
                    }
                    else
                    {

                    }
                }


            }
        }
        catch { }

        return MM;

    }



    /// <summary>
    /// 保存购物车
    /// </summary>
    /// <returns></returns>
    public static void SaveGouwuChe(Hashtable MM)
    {


        //获取用户昵称
        string PathDir = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
        string PathUser = System.IO.Path.Combine(PathDir, "SHANGCHENG.TXT");

        string[] NICK_D = new string[MM.Count];
        int III = 0;
        foreach (DictionaryEntry one in MM)
        {
            NICK_D[III] = one.Key.ToString() + "\t" + one.Value.ToString();

            III++;
        }


        System.IO.File.WriteAllLines(PathUser, NICK_D, System.Text.Encoding.UTF8);





    }

    /// <summary>
    /// 获得 购物车中所有物品 的数量 和 金钱总数
    /// </summary>
    /// <returns></returns>
    public static String GetAllQian(NewsMsgData CMsgData, Hashtable MMM)
    {

        int WUNUM = 0;
        double QIAM = 0;

        foreach (DictionaryEntry one in MMM)
        {
            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                if (CMsgData.Items[i].Title.Trim() == one.Key.ToString().Trim())
                {
                    double AONEQAIN = double.Parse(CMsgData.Items[i].Description);

                    QIAM += (int)one.Value * AONEQAIN;
                    WUNUM += (int)one.Value;
                }
            }
        }

        return "物品总数：" + WUNUM + " 总价格：" + QIAM;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

        if (WeTextBoxOne.Text.Trim().Length < 5 || WeTextBoxOne.Text == "地址和联系方式：")
        {
            Label1.Text = "请正确填写地址和联系方式";
            return;
        }

        string PathFile = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\goods.dll"); //图文 关键词回复目录)
        NewsMsgData CMsgData = new NewsMsgData();
        CMsgData.LoadFile(PathFile);


        Hashtable MMM = GetGouwuChe();
        int WUNUM = 0;
        string GetDingDan = "";

        foreach (DictionaryEntry one in MMM)
        {
            WUNUM += (int)one.Value;

            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                if (CMsgData.Items[i].Title.Trim() == one.Key.ToString().Trim())
                {
                    GetDingDan += " 名称：" + CMsgData.Items[i].Title + "\t单价：" + CMsgData.Items[i].Description + "\t数量：" + one.Value.ToString() + "\r\n";
                }
            }

        }

        if (WUNUM < 0.1)
        {
            Label1.Text = "购物车为空";
            return;
        }



        try
        {


            //发送 购物车里的数据 到 采购清单 

            //订单目录
            string PathDirSYS = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SHANGCHENG\\DINGDAN");



            DateTime PP = DateTime.Now;

            string TXTXX = System.IO.Path.Combine(PathDirSYS, PP.Year.ToString("D2") + PP.Month.ToString("D2") + PP.Day.ToString("D2") + PP.Hour.ToString("D2") + PP.Minute.ToString("D2") + "_" + RID + ".dll");


            string PathDir = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(RID));
            string PathSHangcheng = System.IO.Path.Combine(PathDir, "SHANGCHENG.TXT");

            string PathLiuYan = System.IO.Path.Combine(PathDir, "liuyan.TXT");
            string PathDizHI = System.IO.Path.Combine(PathDir, "dizhi.TXT");
            //保存地址
            string dizhi = System.IO.File.ReadAllText(PathDizHI, System.Text.Encoding.UTF8).Trim().Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");


            GetDingDan += "=======================\r\n";
            GetDingDan += "下单时间:" + DateTime.Now.ToString() + "\r\n";

            GetDingDan += "=======================\r\n";
            GetDingDan += "卖家:" + RID+"\r\n";
            GetDingDan += "=======================\r\n";
            GetDingDan += "地址:" + dizhi+"\r\n";
            GetDingDan += "=======================\r\n";
            GetDingDan += "留言：" + WeTextBoxOne.Text.Trim().Replace("\n", " ").Replace("\t", " ").Replace("\r", " ")+"\r\n";

            //写入订单
            System.IO.File.WriteAllText(TXTXX, GetDingDan);


            //发送购物清单 到系统
            MMM.Clear();


            //清空购物车
            System.IO.File.WriteAllText(PathSHangcheng, "", System.Text.Encoding.UTF8);

            //清除留言
            WeTextBoxOne.Text = "";
            System.IO.File.WriteAllText(PathLiuYan, "", System.Text.Encoding.UTF8);
             

            LinkButton1.PostBackUrl = "dingdan.aspx?id=" + TIME_MID;
            LinkButton1.Visible = true;
            Label1.Text = DateTime.Now.ToString() + " - 订单提交成功";
        }
        catch
        {
            Label1.Text = DateTime.Now.ToString() + " - 订单提交失败";
        }


    }
}