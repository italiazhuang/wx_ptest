using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;
using System.Text.RegularExpressions;
using System.Globalization;
    /// <summary>
    /// update 的摘要说明
    /// </summary>
    public class ftvv: IHttpHandler
    {
        static int II1 = 0;
        public void ProcessRequest(HttpContext context)
        {
            II1 = 0;
            //ClassTianQi.GetTiamQi();
            context.Response.ContentType = "text/html";
            //LOAD QIANG
            string PathDirRSWQ = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\PHOTO\\");
            context.Response.Write("<html>");
            context.Response.Write("<head>");
            context.Response.Write("<title>微信照片墙</title>");
            context.Response.Write("</head>");
            context.Response.Write("<body>");
            context.Response.Write("<p>&nbsp;</p>");
            context.Response.Write("<table width=\"90%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\">");
            context.Response.Write("  <tr>");
            context.Response.Write("    <td height=\"20\" align=\"center\" valign=\"middle\" style=\"font-size:40px;\"><strong>照片墙 - 【发送照片到微信,即刻照片上墙】</strong></td>");
            context.Response.Write("  </tr>");
            context.Response.Write("  <tr>");
            context.Response.Write("   <td>&nbsp;</td>");
            context.Response.Write(" </tr>");

            //获得当前 url 完整路径
            string host = context.Request.ServerVariables["HTTP_HOST"] + context.Request.ServerVariables["PATH_INFO"];
            host = host.Replace("ft.ashx", "");

            string echoStrID = context.Request["id"];
            string url2 = "http://" + host + "Web.aspx?id=" + echoStrID;

            string echoStr = context.Request["img"];
            String RT = "";
            String Name = "照片分享:" + echoStr.Remove(echoStr.LastIndexOf("."));// echoStr.ToLower().Replace(".jpg", "").Replace(".png", "").Replace(".gif", "").Replace("_", "-"); ;
            string URLX = "http://"+host+"user_dir/sysuser/photo/" + echoStr;
            RT += " <tr  bgcolor=\"#CCCCCC\" width=\"98%\" height=\"20\" align=\"left\" valign=\"middle\" ><td style=\"font-size:40px;\"><p>" + Name + "</p><p ><img src=\"" + URLX + "\" width=\"100%\"   align=\"absmiddle\"></p><p></p></td></tr>\r\n";
            RT += " <tr  bgcolor=\"#CCCCCC\" width=\"98%\" height=\"20\" align=\"left\" valign=\"middle\" ><td style=\"font-size:40px;\"><p></p><p><a href=\"" + url2 + "\">进入微网站</a></p></td></tr>\r\n";
            context.Response.Write(RT);// 
            context.Response.Write("</table>");
            context.Response.Write("<p>&nbsp;</p>");         
            context.Response.Write("</body>");
            context.Response.Write("</html>");
        }   

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
 