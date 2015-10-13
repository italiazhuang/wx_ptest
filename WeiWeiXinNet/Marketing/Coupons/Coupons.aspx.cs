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
using System.Data.OleDb;

public partial class defaults : System.Web.UI.Page
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


        string PathDataBase1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic1.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        string Coupon = System.IO.File.ReadAllText(PathDataBase1, System.Text.Encoding.UTF8);
        string PathDataBase2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic2.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
        string UserHave = System.IO.File.ReadAllText(PathDataBase2, System.Text.Encoding.UTF8);



        //Session["WXOpenID"] = Request["QUERY_STRING"];
        string StrShow = "<div class=\"Type\"><a href=\"sbusend.ashx?id=" + UserIDTime + "\"><img src=\"" + Coupon + "\" width=\"294\" height=\"141\" /></a></div>";
        
        //查询是否已领取
        if (CouPoned(RID))
        {
            StrShow = "<br><div>您已获取优惠卷，请到实体店进行消费～</div>";
            StrShow += "<div class=\"Type\"><img src=\"" + UserHave + "\" width=\"294\" height=\"141\" /></div>";
        }
        this.LabelTxt.Text = StrShow;
        //if (!IsPostBack)
        //{

        //}

    }



    private bool CouPoned(string WXOpenID)
    {
        try
        {
            
            string sqlstr = "SELECT count(*) FROM WX_Coupons where CUserName='" + WXOpenID + "'";

            string PathDataBase = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

            OleDbConnection con = new OleDbConnection(source);
            //2、打开连接 C#操作Access之按列读取mdb  
            con.Open();

            DbCommand com = new OleDbCommand();

            com.Connection = con;
            com.CommandText = "select CUserName from WX_Coupons where CUserName='" + WXOpenID + "'";
            DbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                string C = reader["CUserName"].ToString();
                return true;
            }


            
             


            return false;
        }
        catch
        {
            return false;
        }

        /*
        string sqlstr = "SELECT count(*) FROM WX_Coupons where WXOpenID='"+WXOpenID+"'";
        myclass.ManageData mmd = new myclass.ManageData(source);
        string reinfo = mmd.ExecString(sqlstr);
        mmd.dbClose();
      
        if (reinfo == "0")
        {
            rebool = false;
        }    */    

         
    }
}
