using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiWeiXinNet
{
    /// <summary>
    /// ml 的摘要说明
    /// 
    /// 获取首页模板 并且返回
    /// 
    /// </summary>
    public class ml : IHttpHandler
    {
        string TIME_MID = "";
        string RID = "";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
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
            context.Response.Write("<link href= 'USER_DIR/SYSUSER/HOME/v.css' rel='stylesheet' type='text/css'>\r\n");
            //获得数据  并且 返回回去
            string PathFileOne = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\Start.HTM");
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