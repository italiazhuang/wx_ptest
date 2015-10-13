using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiWeiXinNet
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        string TIME_MID = "";
        string RID = "";

        public void ProcessRequest(HttpContext context)
        {


            //读取 
            HttpCookie cookie2 = context.Request.Cookies["weiweixing08"];

            if (cookie2 == null)
            {
                context.Response.Redirect("help.aspx");
            }
            else
            {
                TIME_MID = cookie2.Values["UserIDTime"];
                if (TIME_MID == null)
                {
                    context.Response.Redirect("help.aspx");
                }
                else
                {
                    //正确读取

                    RID = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetID(context.Server.MapPath("~"), TIME_MID);

                    if (RID == "")
                    {
                        context.Response.Redirect("help.aspx");
                    }
                }
            }
            context.Response.ContentType = "text/html";
          //  context.Response.Write("Hello World");


            string Url  = context.Request.QueryString["dat"];

            if (Url == null)
                return;

            if (Url.ToLower().IndexOf("aspx") >= 0 || Url.ToLower().IndexOf("ashx") >= 0)
            {
                return;
            }
            //获得数据  并且 返回回去
            string PathFileOne = System.IO.Path.Combine(context.Server.MapPath("~"),Url);// "USER_DIR\\SYSUSER\\HOME\\Start.HTM");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            context.Response.Write(TXTSET);
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