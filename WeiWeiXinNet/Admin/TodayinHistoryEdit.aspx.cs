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
    /// 历史上的今天
    /// </summary>
    public partial class TodayinHistoryEdit : System.Web.UI.Page
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


            cmd_qiandao HisStory = new cmd_qiandao();
            WeTextBoxThree.Text = HisStory.GetHSDAY();


             //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\HS\\URL.dll");

            try
            {

                WeTextBoxOne.Text = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            }
            catch
            { }


        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\HS\\URL.dll");
           
            System.IO.File.WriteAllText(PathFileOne,WeTextBoxOne.Text,System.Text.Encoding.UTF8);



        }

    }
}