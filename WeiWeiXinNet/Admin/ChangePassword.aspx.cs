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
    /// 修改密码
    /// </summary>
    public partial class ChangePassword : System.Web.UI.Page
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

        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {

            if (WeTextBoxOne.Text.Trim().Length < 6   || WeTextBoxThree.Text.Trim().Length < 6 || WeTextBoxFour.Text.Trim().Length < 6)
            {

                Response.Write("<script>alert('密码长度至少6位!');</script>");

                return;
            }


            if (WeTextBoxThree.Text != WeTextBoxFour.Text )
            {

                Response.Write("<script>alert('两次输入新密码不一致!');</script>");

                return;
            }

            //
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

            //

            try
            {
                string PathDirRSQD = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\ADMIN\\" + name + ".dll");

                if (System.IO.File.Exists(PathDirRSQD) == false)
                {
                    Response.Write("<script>alert(' 密码修改错误!');</script>");

                    return;
                }
                System.IO.File.WriteAllText(PathDirRSQD, ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(WeTextBoxThree.Text), System.Text.Encoding.UTF8);

              //  String AAAA = System.IO.File.ReadAllText(PathDirRSQD, System.Text.Encoding.UTF8);

                Label1.Text = "密码修改成功！" + DateTime.Now.ToShortTimeString();

                return;

            }
            catch
            {
                Response.Write("<script>alert(' 密码修改错误!');</script>");

                return;
            }


           
        }
    }
}