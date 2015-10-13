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

namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public partial class LoginX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (Page.IsPostBack) return;

            //使用时间戳加密 
            string UserIDTime = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(Server.MapPath("~"), "weiwei_test");

            //保存 一个 cookie
            DateTime dtExpire3 = DateTime.Now.AddDays(7);
            HttpCookie cookie3 = new HttpCookie("weiweixing08");
            cookie3.Values.Add("UserIDTime", UserIDTime);
            cookie3.Expires = dtExpire3;
            Response.Cookies.Add(cookie3);



            //读取的时候
            HttpCookie cookie2 = Request.Cookies["weiweixing"];

            if (cookie2 == null)
            {
                imag2.Visible = true;
                imag1.Visible = true;

                WeTextBoxOne.Visible = true;
                WeTextBoxTwo.Visible = true;

                ButtonThree.Visible = false;
                
                return;
            }
            else
            {
                //
                imag2.Visible = false;
                imag1.Visible = false;

                WeTextBoxOne.Visible = false;
                WeTextBoxTwo.Visible = false;

                ButtonThree.Visible = true;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {

            if(ButtonThree.Visible ==true )
                Response.Redirect("admin.aspx");



            if (WeTextBoxOne.Text.Length < 3 || WeTextBoxTwo.Text.Length < 3)
            {


                return;
            }

            DateTime dtExpire = DateTime.Now.AddDays(7);



            string PWS = GetNewPassWord(WeTextBoxOne.Text.Trim());

            string PWSMD5 = ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(WeTextBoxTwo.Text);

            if (PWS == PWSMD5)
            {
                Response.Write("<script>alert('删除成功!');window.location.href ='www.cnblogs.com'</script>");


            }
            else
            {

                Response.Write("<script>alert('登陆失败!');</script>");

                return;
            }


            HttpCookie cookie = new HttpCookie("weiweixing");
            cookie.Values.Add("name", WeTextBoxOne.Text);
            cookie.Values.Add("md5", PWSMD5);
            cookie.Expires = dtExpire;
            Response.Cookies.Add(cookie);

            ////读取的时候
            //HttpCookie cookie2 = Request.Cookies["weiweixing"];
            //string name = cookie2.Values["name"];
            //string md5 = cookie2.Values["md5"];

           


            Response.Redirect("admin.aspx");


        }

        /// <summary>
        /// 授权码
        /// </summary>
        /// <returns></returns>
        public string GetNewPassWord(string idname)
        {
            try
            {
                string PathDirRSQD = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\ADMIN\\" + idname + ".dll");

                if (System.IO.File.Exists(PathDirRSQD) == false)
                {
                    return "";
                }

                String AAAA = System.IO.File.ReadAllText(PathDirRSQD, System.Text.Encoding.UTF8);


                return AAAA;//
            }
            catch
            {
                return "";
            }
        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            Session.Clear();
            HttpCookie cookie = Request.Cookies["weiweixing"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(cookie);
            }

            Response.Redirect("login.aspx");


            imag2.Visible = true;
            imag1.Visible = true;

            WeTextBoxOne.Visible = true;
            WeTextBoxTwo.Visible = true;

            ButtonThree.Visible = false ;


        }

    }
}
