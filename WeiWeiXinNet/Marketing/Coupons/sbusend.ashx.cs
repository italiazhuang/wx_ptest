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

namespace WeiWeiXinNet.Coupons
{

    /// <summary>
    /// sbusend 的摘要说明
    /// </summary>
    public class sbusend : IHttpHandler
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public string UserIDTime = "";

        /// <summary>
        /// OPENID
        /// </summary>
        string RID = "";


        public void ProcessRequest(HttpContext context)
        {

            string id = context.Request.QueryString["id"];
            if (id != null)
            {
                UserIDTime = id;
            }
            else
            {
                context.Response.Redirect("help.aspx");
            }

            if (id == "")
                context.Response.Redirect("help.aspx");

            RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(context.Server.MapPath("~"), UserIDTime);

            if (RID == "")
            {
                context.Response.Redirect("help.aspx");
            }




            context.Response.ContentType = "text/html";
           // context.Response.Write("Hello World");

              //Session["WXOpenID"]
         //CID, CUpdate, CMake, CUserName, CUserPhone, CUserqq, WXOpenID
            //提交以后
          //  string CUserName = context.Request["username"];
          //  CUserName = CUserName.Replace("'","");
          //  string CUserPhone = context.Request["userphone"];
          //  CUserPhone = CUserPhone.Replace("'", "");
          //  string CUserqq = context.Request["userqq"];
          //  CUserqq = CUserqq.Replace("'", "");
            //string Msg = "";
            //if (CUserName == "")
            //{
            //    Msg = "   <SCRIPT language=JavaScript>alert('联系人不能为空～');javascript:history.go(-1)</SCRIPT>";
            //    context.Response.Write(Msg);
            //    return;
            //}
            //if (CUserPhone == "")
            //{
            //    Msg = "   <SCRIPT language=JavaScript>alert('电话不能为空～');javascript:history.go(-1)</SCRIPT>";
            //    context.Response.Write(Msg);
            //    return;
            //}
            string CUserName = "a";
            string CUserPhone = "b";
            string CUserqq = "c";



            try
            {

               // string sqlstr = "INSERT INTO WX_Coupons(CUserName, CUserPhone, CUserqq, WXOpenID)  VALUES   ('" + CUserName + "','" + CUserPhone + "','" + CUserqq + "','" + RID+ "')";

              //  string sqlstr = "INSERT INTO WX_Coupons( CUserName)  VALUES   ('" + RID + "')";
                string sqlstr = "INSERT INTO WX_Coupons(CUserName, CUserPhone, CUserqq)  VALUES   ('" + RID + "','" + CUserPhone + "','" + CUserqq + "')";


                string PathDataBase = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
                String source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase;

                OleDbConnection con = new OleDbConnection(source);
                //2、打开连接 C#操作Access之按列读取mdb  
                con.Open();

                DbCommand comd = new OleDbCommand();

 
                //连接字符串
                comd.CommandText = sqlstr;
                comd.Connection = con;
                //执行命令，将结果返回
                int sm = comd.ExecuteNonQuery();


                context.Response.Write("<SCRIPT language=JavaScript>alert('成功领取优惠卷！');window.location.href=\"Coupons.aspx?id=" + UserIDTime + "\"</SCRIPT>");
            }
            catch
            {
                context.Response.Write("<SCRIPT language=JavaScript>alert('领取优惠卷失败，请确认输入信息正确！');window.location.href=\"Coupons.aspx?id=" + UserIDTime + "\"</SCRIPT>");
            }

       
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}



 
