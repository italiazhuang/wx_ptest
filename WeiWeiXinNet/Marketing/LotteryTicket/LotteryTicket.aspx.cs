using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
//using System.Data.SqlClient;
using System.Data.OleDb;

public partial class LotteryTicket : System.Web.UI.Page
{

    /// <summary>
    /// 时间戳
    /// </summary>
    public string UserIDTime = "";

    /// <summary>
    /// OPENID
    /// </summary>
    string RID = "";

   // string source = @"Data Source=.; Initial Catalog=WXSource;User Id=test;Password=asakao;";
    protected void Page_Load(object sender, EventArgs e)
    {

        string id = Request.QueryString["id"];
        if (id != null)
        {
            UserIDTime = id;
        }
        else
        {
            Response.Redirect("help.aspx");
        }

        if (id == "")
            Response.Redirect("help.aspx");

        RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(Server.MapPath("~"), UserIDTime);

        if (RID == "")
        {
            Response.Redirect("help.aspx");
        }



        if (!IsPostBack)
        {
            getjp();
            getname();
        }

    }

    protected void getjp()//获得抽奖奖品信息
    {
        Random Random1 = new Random();
        int i3 = Random1.Next(0, 101);
        if (i3 <= 2)//一等奖中奖率2%
        {
            gjq.Style["background-image"] = "url('ggk/images/1.jpg')";
            Session["mzj"] = "一等奖";
        }
        else if (i3 > 2 && i3 <= 10)//二等奖中奖率8%
        {
            gjq.Style["background-image"] = "url('ggk/images/2.jpg')";
            Session["mzj"] = "二等奖";
        }
        else if (i3 > 10 && i3 <= 25)//三等奖中奖率15%
        {
            gjq.Style["background-image"] = "url('ggk/images/3.jpg')";
            Session["mzj"] = "三等奖";
        }
        else if (i3 > 9 && i3 <= 16)//四等奖中奖率7%
        {
            gjq.Style["background-image"] = "url('ggk/images/4.jpg')";
            Session["mzj"] = "四等奖";
        }
        else if (i3 > 16 && i3 <= 29)//五等奖中奖率13%
        {
            gjq.Style["background-image"] = "url('ggk/images/5.jpg')";
            Session["mzj"] = "五等奖";
        }
        else//不中奖
        {
            gjq.Style["background-image"] = "url('ggk/images/xxcy.jpg')";
            Session["mzj"] = "没中奖";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string b = RID;// Request["QUERY_STRING"];
        string a = Session["mzj"].ToString().Trim();

        if (a == "没中奖")
        {

            string url = Request.Url.ToString();
            Response.Redirect(url);
        }
        else
        {

            string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\LotteryTicket\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

            OleDbConnection con = new OleDbConnection(source);
            //2、打开连接 C#操作Access之按列读取mdb  
            con.Open();   
             
            DbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "select jp from wx_ggk_jp where name='" + b + "'";
            DbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                string jp = reader["jp"].ToString();
                bd.Style["Display"] = "None";//转盘层
                csyw.Style["Display"] = "None";//次数用完次数
                zjl.Style["Display"] = "Block";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面


                Label3.Text = "恭喜你以中奖" + jp + "请填写相关信息";

                con.Close();
            }
            else
            {
 
                OleDbCommand comd = new OleDbCommand();
                //连接字符串
                comd.CommandText = "insert into wx_ggk_jp (name,jp,sjh) values ('" + b + "','" + a + "','手机号')";
                comd.Connection = con;

                //执行命令，将结果返回
                int sm = comd.ExecuteNonQuery();
                con.Close();
                //释放资源
                con.Dispose();

                bd.Style["Display"] = "None";//转盘层
                csyw.Style["Display"] = "None";//次数用完次数
                zjl.Style["Display"] = "Block";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面


                Label3.Text = "恭喜你以中奖" + a + "请填写相关信息";
            }
        }
    }
    protected void getname()//判断是否第一次登陆
    {
        string b = RID;// Request["QUERY_STRING"];


        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\LotteryTicket\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

        OleDbConnection con = new OleDbConnection(source);
        //2、打开连接 C#操作Access之按列读取mdb  
        con.Open();

        DbCommand com = new OleDbCommand();

        com.Connection = con;
        com.CommandText = "select cs from wx_ggk where name='" + b + "'";
        DbDataReader reader = com.ExecuteReader();
        if (reader.Read())
        {
            int csi;
            string cs = reader["cs"].ToString();
            csi = int.Parse(cs);

            if (csi < 3)
            {
                int sy;
                sy = 3 - csi;
                //次数上限未到，无变化


                OleDbCommand comq = new OleDbCommand();
                comq.Connection = con;
                comq.CommandText = "select jp,sjh from wx_ggk_jp where name='" + b + "'";
                DbDataReader readerq = comq.ExecuteReader();
                if (readerq.Read())
                {

                    string jiangpin = readerq["jp"].ToString();
                    string shouji = readerq["sjh"].ToString();
                    if (shouji == "手机号")
                    {
                        //显示中奖页面
                        bd.Style["Display"] = "None";//转盘层
                        csyw.Style["Display"] = "None";//次数用完次数
                        zjl.Style["Display"] = "Block";//中奖页面
                        zjjs.Style["Display"] = "None";//中奖结束页面

                        Label3.Text = "恭喜你以中奖" + jiangpin + "请填写相关信息";
                    }
                    else
                    {
                        //显示中奖结束页面
                        bd.Style["Display"] = "None";//转盘层
                        csyw.Style["Display"] = "None";//次数用完次数
                        zjl.Style["Display"] = "None";//中奖页面
                        zjjs.Style["Display"] = "Block";//中奖结束页面

                    }
                }
                else
                {

                    //生成命令对象
                    OleDbCommand comd = new OleDbCommand();
                    //连接字符串
                    comd.CommandText = "update wx_ggk set cs=cs+1 where name='" + b + "'";
                    comd.Connection = con;

                    //执行命令，将结果返回
                    int sm = comd.ExecuteNonQuery();
                    if (sm > 0)
                    {     //抽奖页面显示剩余次数sy
                        bd.Style["Display"] = "Block";//转盘层
                        csyw.Style["Display"] = "None";//次数用完次数
                        zjl.Style["Display"] = "None";//中奖页面
                        zjjs.Style["Display"] = "None";//中奖结束页面

                        Label2.Text = "您已抽奖" + csi + "次，还有" + sy + "次抽奖机会";
                    }
                    else
                    {

                    }

                }

            }
            else
            {
                //次数超额，转到次数用完div
                bd.Style["Display"] = "None";//转盘层
                csyw.Style["Display"] = "Block";//次数用完次数
                zjl.Style["Display"] = "None";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面


            }





        }
        else
        {
            OleDbCommand comd = new OleDbCommand();
            //连接字符串
            comd.CommandText = "insert into wx_ggk (name,cs) values ('" + b + "','1')";
            comd.Connection = con;

            //执行命令，将结果返回
            int sm = comd.ExecuteNonQuery();
            bd.Style["Display"] = "Block";//转盘层
            csyw.Style["Display"] = "None";//次数用完次数
            zjl.Style["Display"] = "None";//中奖页面
            zjjs.Style["Display"] = "None";//中奖结束页面     
        }

        con.Close();
        //释放资源
        con.Dispose();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string b = RID;// Request["QUERY_STRING"];

        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\LotteryTicket\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

        OleDbConnection con = new OleDbConnection(source);
        //2、打开连接 C#操作Access之按列读取mdb  
        con.Open();

        DbCommand comd = new OleDbCommand();
 
        //连接字符串
        comd.CommandText = "update wx_ggk_jp set sjh='" + TextBox2.Text + "' where name='" + b + "'";
        comd.Connection = con;

        //执行命令，将结果返回
        int sm = comd.ExecuteNonQuery();
        con.Close();
        //释放资源
        con.Dispose();
        string url = Request.Url.ToString();
        Response.Redirect(url);
    }
}
