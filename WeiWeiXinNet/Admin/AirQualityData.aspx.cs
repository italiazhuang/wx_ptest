/*
 *    WeWeiXin.NET 
 *
 *    论坛： http://tieba.baidu.com/f?kw=微微信_net
 *    更新：udoo123.taobao.com
 *    作者： http://blog.csdn.net/weixin_net
 *    QQ群： 172036441
 *    授权：个人或 公司运营自身微信公众号使用和二次开发自由使用，或者针对特定的单个用户进行二次开发自由使用，禁止重新包装后批量转卖
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Text;
using IZ.WebFileManager;
namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 空气质量获取
    /// </summary>
    public partial class AirQualityData : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;


            //读取的时候
            HttpCookie cookie2 = Request.Cookies["weiweixing"];

            if (cookie2 == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            string name = cookie2.Values["name"];
            if (name == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            string md5 = cookie2.Values["md5"];
            if (md5 == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            
            shouye Pm25D = new shouye();

            try
            {
                //系统目录 存放目录
                string PathFileOneUrl = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25\\URL.DLL");
                WeTextBoxOne.Text = System.IO.File.ReadAllText(PathFileOneUrl, System.Text.Encoding.UTF8);
            }
            catch { }

            try
            {
                string PathFileOneCity = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25\\city.DLL");
                WeTextBoxTwo.Text = System.IO.File.ReadAllText(PathFileOneCity, System.Text.Encoding.UTF8);
            }
            catch
            { }


            WeTextBoxThree.Text = Pm25D.GetPM25(System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25\\"));




        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {

            shouye Pm25D = new shouye();

            //系统目录 存放目录
            string PathFileOneRT = Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25\\URL.DLL");
            File.WriteAllText(PathFileOneRT, WeTextBoxOne.Text,Encoding.UTF8);
            string PathFileOnePRIZE = Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PM25\\city.DLL");
            File.WriteAllText(PathFileOnePRIZE,WeTextBoxTwo.Text,Encoding.UTF8);
            Label1.Text = "保存成功: "+ DateTime.Now.ToShortTimeString();          
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            
        }

    }
}