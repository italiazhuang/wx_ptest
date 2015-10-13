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

public partial class dzp : System.Web.UI.Page
{
    /// <summary>
    /// 时间戳
    /// </summary>
    public string UserIDTime = "";
    
    /// <summary>
    /// OPENID
    /// </summary>
    string RID = "";

  //  string source = @"Data Source=.; Initial Catalog=WXSource;User Id=test;Password=asakao;";
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



        getname(RID);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StarGame(RID);
    }

    /*
                        <div class="hang">大转盘测试期</div>
                    <div class="hang">一等奖：送50积分；二等奖：送40积分</div>
                    <div class="hang">三等奖：送30积分；四等奖：送20积分</div>
                    <div class="hang">五等奖：送10积分</div>
     
     */

    /// <summary>
    /// 获得等级设定
    /// </summary>
    /// <returns></returns>
    public string GetJiangPing()
    {

        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\JiangPing.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +

        string U = System.IO.File.ReadAllText(PathDataBase,System.Text.Encoding.UTF8);

        return U;

    }

    /// <summary>
    /// 获得 大转盘 设置
    /// </summary>
    /// <returns></returns>
  public string   GetSet()
    {
        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\set.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +

        string U = System.IO.File.ReadAllText(PathDataBase, System.Text.Encoding.UTF8);

        return U.Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim();
    }


    private void StarGame(string b  )
    {
      //   Request["QUERY_STRING"];
        string a = this.hide.Value;
        if (a == "没中奖")
        {
            string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

            OleDbConnection conn = new OleDbConnection(source);
            //2、打开连接 C#操作Access之按列读取mdb  
            conn.Open();

            DbCommand comd = new OleDbCommand();
            //连接字符串
            comd.CommandText = "update wx_dzp set cs=cs+1 where name='" + b + "'";
            comd.Connection = conn;

            //执行命令，将结果返回
            int sm = comd.ExecuteNonQuery();
            conn.Close();
            //释放资源
            conn.Dispose();
            main.Style["Display"] = "None";//转盘层
            zt.Style["Display"] = "None";//转盘规则展示层
            gz.Style["Display"] = "None";//转盘规则展示层
            csyw.Style["Display"] = "None";//次数用完次数
            zjl.Style["Display"] = "None";//中奖页面
            zjjs.Style["Display"] = "None";//中奖结束页面
            zccj.Style["Display"] = "Block";//再次抽奖页面
        }
        else
        {
            string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

            OleDbConnection con = new OleDbConnection(source);
            //2、打开连接 C#操作Access之按列读取mdb  
            con.Open();

            DbCommand com = new OleDbCommand();

            com.Connection = con;
            com.CommandText = "select jp from wx_dzp_jp where name='" + b + "'";
            DbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                string jp = reader["jp"].ToString();
                main.Style["Display"] = "None";//转盘层
                zt.Style["Display"] = "None";//转盘规则展示层
                gz.Style["Display"] = "None";//转盘规则展示层
                csyw.Style["Display"] = "None";//次数用完次数
                zjl.Style["Display"] = "Block";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面
                zccj.Style["Display"] = "None";//再次抽奖页面
                Label3.Text = "恭喜你以中奖" + jp + "请填写相关信息";
            }
            else
            {
         

                DbCommand comd = new OleDbCommand();


                //连接字符串
                comd.CommandText = "insert into wx_dzp_jp (name,jp,sjh) values ('" + b + "','" + a + "','手机号')";
                comd.Connection = con;
                //执行命令，将结果返回
                int sm = comd.ExecuteNonQuery();
                con.Close();
                //释放资源
                con.Dispose();
                main.Style["Display"] = "None";//转盘层
                zt.Style["Display"] = "None";//转盘规则展示层
                gz.Style["Display"] = "None";//转盘规则展示层
                csyw.Style["Display"] = "None";//次数用完次数
                zjl.Style["Display"] = "Block";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面
                zccj.Style["Display"] = "None";//再次抽奖页面

                Label3.Text = "恭喜你已中奖【 " + a + " 】请填写相关信息";
            }
            con.Close();
            //释放资源
            con.Dispose();
        }
    }


    /// <summary>
    /// 判断是否已经 处理过
    /// </summary>
    /// <param name="b"></param>
    protected void getname(string b)// 
    {
     //   string b = Request["QUERY_STRING"];

        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

        OleDbConnection con = new OleDbConnection(source);
        //2、打开连接 C#操作Access之按列读取mdb  
        con.Open();

        DbCommand com = new OleDbCommand();


        com.Connection = con;
        com.CommandText = "select cs from wx_dzp where name='" + b + "'";
        DbDataReader reader = com.ExecuteReader();
        if (reader.Read())
        {
            int csi;
            string cs = reader["cs"].ToString();
            csi = int.Parse(cs);
            if (csi < 3)
            {
                #region 三次循环
                int sy;
                sy = 3 - csi;
                //次数上限未到，无变化
                DbCommand comq = new OleDbCommand();
                comq.Connection = con;
                comq.CommandText = "select jp,sjh from wx_dzp_jp where name='" + b + "'";
                DbDataReader readerq = comq.ExecuteReader();
                if (readerq.Read())
                {
                    string jiangpin = readerq["jp"].ToString();
                    string shouji = readerq["sjh"].ToString();
                    if (shouji == "手机号")
                    {
                        //显示中奖页面
                        main.Style["Display"] = "None";//转盘层
                        zt.Style["Display"] = "None";//转盘规则展示层
                        gz.Style["Display"] = "None";//转盘规则展示层
                        csyw.Style["Display"] = "None";//次数用完次数
                        zjl.Style["Display"] = "Block";//中奖页面
                        zjjs.Style["Display"] = "None";//中奖结束页面
                        zccj.Style["Display"] = "None";//再次抽奖页面
                     
                    }
                    else
                    {
                        //显示中奖结束页面
                        main.Style["Display"] = "None";//转盘层
                        zt.Style["Display"] = "None";//转盘规则展示层
                        gz.Style["Display"] = "None";//转盘规则展示层
                        csyw.Style["Display"] = "None";//次数用完次数
                        zjl.Style["Display"] = "None";//中奖页面
                        zjjs.Style["Display"] = "Block";//中奖结束页面
                        zccj.Style["Display"] = "None";//再次抽奖页面
                    }
                }
                else
                {
                    //抽奖页面显示剩余次数sy
                    main.Style["Display"] = "Block";//转盘层
                    zt.Style["Display"] = "Block";//转盘规则展示层
                    gz.Style["Display"] = "Block";//转盘规则展示层
                    csyw.Style["Display"] = "None";//次数用完次数
                    zjl.Style["Display"] = "None";//中奖页面
                    zjjs.Style["Display"] = "None";//中奖结束页面
                    zccj.Style["Display"] = "None";//再次抽奖页面
                    Label2.Text = "您已抽奖" + csi + "次，还有" + sy + "次抽奖机会";
                }
                readerq.Close();
               
#endregion

            }
            else
            {
                //次数超额，转到次数用完div
                main.Style["Display"] = "None";//转盘层
                zt.Style["Display"] = "None";//转盘规则展示层
                gz.Style["Display"] = "None";//转盘规则展示层
                csyw.Style["Display"] = "Block";//次数用完次数
                zjl.Style["Display"] = "None";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面
                zccj.Style["Display"] = "None";//再次抽奖页面
            }

        }
        else
        {
            #region mainline02

            //次数上限未到，无变化
            DbCommand comd = new OleDbCommand();
                //连接字符串
                comd.CommandText = "insert into wx_dzp (name,cs) values ('" + b + "','0')";
                comd.Connection = con;
                //执行命令，将结果返回
                int sm = comd.ExecuteNonQuery();
                main.Style["Display"] = "Block";//转盘层
                zt.Style["Display"] = "Block";//转盘规则展示层
                gz.Style["Display"] = "Block";//转盘规则展示层
                csyw.Style["Display"] = "None";//次数用完次数
                zjl.Style["Display"] = "None";//中奖页面
                zjjs.Style["Display"] = "None";//中奖结束页面
                zccj.Style["Display"] = "None";//再次抽奖页面
              
                string url = Request.Url.ToString();
                Response.Redirect(url);
            #endregion
        }
        reader.Close();
        con.Close();
        //释放资源
        con.Dispose();

    }

    protected void ID1_Click(object sender, EventArgs e)//刷新页面，继续抽奖
    {
        string url = Request.Url.ToString();
        Response.Redirect(url);
    }

    protected void insj_Click(object sender, EventArgs e)//中奖页面添加手机号码
    {
        string b = RID;// Request["QUERY_STRING"];

        string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Turntable\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

        OleDbConnection conn = new OleDbConnection(source);
        //2、打开连接 C#操作Access之按列读取mdb  
        conn.Open();

        DbCommand comd = new OleDbCommand();


        //连接字符串
        comd.CommandText = "update wx_dzp_jp set sjh='" + TextBox2.Text+ "' where name='" + b + "'";
        comd.Connection = conn;
        //执行命令，将结果返回
        int sm = comd.ExecuteNonQuery();
        conn.Close();
        //释放资源
        conn.Dispose();
        string url = Request.Url.ToString();
        Response.Redirect(url);
    }
}
