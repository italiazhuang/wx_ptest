using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// Security 的摘要说明
    /// </summary>
    public class Security : IHttpHandler
    {
        HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            //读取的时候
            HttpCookie cookie2 = context.Request.Cookies["weiweixing"];

            if (cookie2 == null)
            {
                context.Response.Redirect("login.aspx");
                return;
            }

            string name = cookie2.Values["name"];
            if (name == null)
            {
                context.Response.Redirect("login.aspx");
                return;
            }

            string md5 = cookie2.Values["md5"];
            if (md5 == null)
            {
                context.Response.Redirect("login.aspx");
                return;
            }

            string ext = context.Request["e"];


            _context = context;
            context.Response.ContentType = "text/plain";

            context.Response.Write("开始检测:"+ DateTime.Now.ToString()+"\r\n");

            string PathM = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR");

            SysDir = context.Server.MapPath("~");

            DirectoryInfo DIR = new DirectoryInfo(PathM);
            GetFiles(DIR, "*." + ext);


            context.Response.Write("检测结束:" + DateTime.Now.ToString() + "\r\n");

        }

        public string SysDir = "";

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 得某文件夹下所有的文件
        /// </summary>
        /// <param name="directory">文件夹名称</param>
        /// <param name="pattern">搜寻指类型</param>
        /// <returns></returns>
        public void GetFiles(DirectoryInfo directory, string pattern)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {

                foreach (FileInfo info in directory.GetFiles(pattern))
                {
                    //  result = result + info.FullName.ToString() + "<br/>";


                    _context.Response.Write(info.FullName.ToString().Replace(SysDir,"") + "\r\n");

                    //result = result + info.Name.ToString() + ";";
                }

                foreach (DirectoryInfo info in directory.GetDirectories())
                {
                    GetFiles(info, pattern);
                }
            }
            //  string returnString = result;
            //  return returnString;

        }


    }
}