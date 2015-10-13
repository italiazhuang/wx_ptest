using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;

namespace WeiWeiXinNet
{
    /// <summary>
    /// ml 的摘要说明
    /// 获取首页模板 并且返回
    /// </summary>
    public class wenews : IHttpHandler
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
            context.Response.Write("<!DOCTYPE html><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><meta name='viewport' content='width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;' /><meta name='apple-mobile-web-app-capable' content='yes' /><meta name='apple-mobile-web-app-status-bar-style' content='blac'/><meta name='format-detection' content='telephone=no' /><title></title><link href= 'Styles/Style.css' rel='stylesheet' type='text/css'></head><body>\r\n");
            //获得数据  并且 返回回去

            string PathFile = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\NEWS\\news.dll"); //图文 关键词回复目录);    

            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadFile(PathFile);

            string TableTxt = "";
            string S = "..\\USER_DIR\\SYSUSER\\NEWS\\";
            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                string DATA = "<table width='100%'  border='0' cellpadding='0' cellspacing='0' style='border:0'><tr style='border:0'><td width='50' style='border:0'><a href='" + S + CMsgData.Items[i].Url + "'> <img src='" + CMsgData.Items[i].PicUrl + "'  width='50px' height='50px'> </a> </td><td style='border:0'> <a href='" + S + CMsgData.Items[i].Url + "'>" + CMsgData.Items[i].Title + "</a></td></tr></table>";
                TableTxt += "  <tr><td>"+  DATA+"</td></tr>";
            }
            TableTxt = "<div class=\"cardexplain\"><ul class=\"round\"><li class='title'>图文消息</li><table  border='0' cellpadding='0' cellspacing='0' width='100%'  class='cpbiaoge'>" + TableTxt + "</table></ul></div></body></html>";
            context.Response.Write(TableTxt);
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