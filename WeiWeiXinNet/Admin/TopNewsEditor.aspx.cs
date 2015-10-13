/*
 *    WeWeiXin.NET 
 *
 *    论坛：http://tieba.baidu.com/f?kw=微微信_net
 *    更新：udoo123.taobao.com
 *    作者：http://blog.csdn.net/weixin_net
 *    QQ群：172036441
 *    授权：个人或公司运营自身微信公众号使用和二次开发自由使用，或者针对特定的单个用户进行二次开发自由使用，禁止重新包装后批量转卖
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using IZ.WebFileManager;



namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 滚动新闻设置
    /// </summary>
    public partial class TopNewsEditor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           

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

            if (Page.IsPostBack) return;



            try
            {
                //系统目录 存放目录
                string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\new.dll");
                String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
                WeTextBoxOne.Text = TXTSET;


                string PathFileOne2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\news.htm");
                String TXTSET2 = System.IO.File.ReadAllText(PathFileOne2, System.Text.Encoding.UTF8);
                WeTextBoxTwo.Text = TXTSET2;

                
            }
            catch
            { }

            ButtonOne.Attributes.Add("OnClick", "return  jsSave();");


        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\new.dll");
            System.IO.File.WriteAllText(PathFileOne, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

                  string PathFileOne2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\GUNDONG\\news.htm");
            System.IO.File.WriteAllText(PathFileOne2, WeTextBoxTwo.Text, System.Text.Encoding.UTF8);



        }

      
    }
}