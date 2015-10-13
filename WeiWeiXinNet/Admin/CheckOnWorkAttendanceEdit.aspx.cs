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
    /// 签到设置 
    /// </summary>
    public partial class CheckOnWorkAttendanceEdit : System.Web.UI.Page
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


            try
            { 
                //系统目录 存放目录  每天第一次签到
                string PathFileOneRT = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT.DLL");
                WeTextBoxOne.Text = System.IO.File.ReadAllText(PathFileOneRT, System.Text.Encoding.UTF8);
            }
            catch { }

            try
            {
                //系统目录 存放目录 每天第二次以后签到
                string PathFileOneRT = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT2.DLL");
                WeTextBoxTwo.Text = System.IO.File.ReadAllText(PathFileOneRT, System.Text.Encoding.UTF8);
            }
            catch { }



            try
            {//积分查询奖励
                string PathFileOnePRIZE = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\PRIZE.DLL");
                WeTextBoxThree.Text = System.IO.File.ReadAllText(PathFileOnePRIZE, System.Text.Encoding.UTF8);
            }
            catch
            { }




            try
            {
                //积分查询
                string PathFileOnePRIZE = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\JF.DLL");
                WeTextBoxFour.Text = System.IO.File.ReadAllText(PathFileOnePRIZE, System.Text.Encoding.UTF8);
            }
            catch
            { }

        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOneRT = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT.DLL");            
            System.IO.File.WriteAllText(PathFileOneRT, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

            string PathFileOneRT2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\RT2.DLL");
            System.IO.File.WriteAllText(PathFileOneRT2, WeTextBoxTwo.Text, System.Text.Encoding.UTF8);

            string PathFileOnePRIZE = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\PRIZE.DLL");
            System.IO.File.WriteAllText(PathFileOnePRIZE, WeTextBoxThree.Text, System.Text.Encoding.UTF8);

            string PathFileOneJF = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\QD\\JF.DLL");
            System.IO.File.WriteAllText(PathFileOneJF, WeTextBoxFour.Text, System.Text.Encoding.UTF8);


            Label1.Text = "保存成功：" + DateTime.Now.ToShortTimeString();
        }

    }
}