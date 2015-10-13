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
    /// 用户基础设置
    /// </summary>
    public partial class WeiXinBasicConfigManagement : System.Web.UI.Page
    {
        protected void ButtonOne_Click(object sender, EventArgs e)
        {

            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\WeiXinBasicConfigManagement.dll");
            String[] TXTSET = { WeTextBoxOne.Text.Replace("\n", "").Replace("\r", ""), WeTextBoxTwo.Text.Replace("\n", "").Replace("\r", ""), WeTextBoxThree.Text.Replace("\n", "").Replace("\r", "") };
            System.IO.File.WriteAllLines(PathFileOne, TXTSET, System.Text.Encoding.UTF8);


            //系统目录 存放目录
            string PathFileTimeStrOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01TimeStr.dll");

            // string.Format("{0:d4}", n);        

            if (WeTextBoxFour.Text.Trim().Length <8)
            {
                WeTextBoxFour.Text =WeTextBoxFour.Text+ String.Format("{0:d"+  (8- WeTextBoxFour.Text.Trim().Length).ToString() +"}", 1); //自动补全
            }

            System.IO.File.WriteAllText(PathFileTimeStrOne, WeTextBoxFour.Text , System.Text.Encoding.UTF8);


            string AXNUMPath = System.IO.Path.Combine( Server.MapPath("~"), "USER_DIR\\sysuser\\usernum.txt");
            
                System.IO.File.WriteAllText(AXNUMPath, WeTextBoxFive.Text);



                string PathFileT6 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T6.dll");
                System.IO.File.WriteAllText(PathFileT6, WeTextBoxSix.Text, System.Text.Encoding.UTF8);

                string PathFileT7 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T7.dll");
                System.IO.File.WriteAllText(PathFileT7, WeTextBoxSeven.Text, System.Text.Encoding.UTF8);

                string PathFileT8 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T8.dll");
                System.IO.File.WriteAllText(PathFileT8, txt0.Text, System.Text.Encoding.UTF8);


                string PathFileToken = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01Token.dll");
                System.IO.File.WriteAllText(PathFileToken, TextBoxToken.Text, System.Text.Encoding.UTF8);


        }

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


            //给button1添加客户端事件
            ButtonOne.Attributes.Add("OnClick", "return  jsED()");


            try
            {
                //系统目录 存放目录
                string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\WeiXinBasicConfigManagement.dll");
                String[] TXTSET = System.IO.File.ReadAllLines(PathFileOne, System.Text.Encoding.UTF8);

                WeTextBoxOne.Text = TXTSET[0];
                WeTextBoxTwo.Text = TXTSET[1];
                WeTextBoxThree.Text = TXTSET[2];

                //时间戳
                string PathFileTimeStrOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01TimeStr.dll");
                WeTextBoxFour.Text  = System.IO.File.ReadAllText(PathFileTimeStrOne, System.Text.Encoding.UTF8);


                string AXNUMPath = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\sysuser\\usernum.txt");
                WeTextBoxFive.Text = System.IO.File.ReadAllText(AXNUMPath);

                //标题
                string PathFileT6 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T6.dll");
                WeTextBoxSix.Text = System.IO.File.ReadAllText(PathFileT6, System.Text.Encoding.UTF8);

                //内容
                string PathFileT7 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T7.dll");
                WeTextBoxSeven.Text = System.IO.File.ReadAllText(PathFileT7, System.Text.Encoding.UTF8);


                //IMG
                string PathFileT8 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T8.dll");
                txt0.Text = System.IO.File.ReadAllText(PathFileT8, System.Text.Encoding.UTF8);

                string host =  Request.ServerVariables["HTTP_HOST"] ;
      
                Image1.ImageUrl ="http://"+host+ txt0.Text;


                string PathFileToken = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01Token.dll");
                TextBoxToken.Text =  System.IO.File.ReadAllText(PathFileToken,  System.Text.Encoding.UTF8);



            }
            catch
            { }
        }

        


    }
}