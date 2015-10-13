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
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IZ.WebFileManager;
using System.Reflection;

namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 微微信
    /// </summary>
    public partial class WebEditForm : System.Web.UI.Page
    {
        public string UserDir = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            UserDir = Request.QueryString["id"];


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

            System.Globalization.CultureInfo culture = null;


            string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            culture = new System.Globalization.CultureInfo("zh-CN");
            FileManager1.Culture = culture;

            FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;
            //Thumbnails

            FileManager1.RootDirectories.Clear();
            RootDirectory rootDirectory = new RootDirectory();
            string PathOne = "~\\USER_DIR\\USER\\" + UserDir;

            rootDirectory.DirectoryPath = PathOne;
            rootDirectory.Text = "用户信息";
            FileManager1.RootDirectories.Add(rootDirectory);


            FileManager1.HideEXT = true;


            if (Page.IsPostBack) return;


            GetUserData(UserDir);


            for (int i = 0; i < typeof(ToolbarOptions).GetProperties().Length; i++)
            {
                PropertyInfo prop = typeof(ToolbarOptions).GetProperties()[i];

                if (prop.PropertyType == typeof(bool))
                {

                    if (prop.Name == "ShowRenameButton")
                    {
                        prop.SetValue(FileManager1.ToolbarOptions, false, null);
                    }


                    //ShowMoveButton;ShowFolderUpButton;ShowNewFolderButton
                    if (prop.Name == "ShowMoveButton")
                    {
                        prop.SetValue(FileManager1.ToolbarOptions, false, null);
                    }
                    if (prop.Name == "ShowFolderUpButton")
                    {
                        prop.SetValue(FileManager1.ToolbarOptions, false, null);
                    }
                    if (prop.Name == "ShowNewFolderButton")
                    {
                        prop.SetValue(FileManager1.ToolbarOptions, false, null);
                    }
                }
            }

        }

        /// <summary>
        /// 读取一个配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetOneUserData(string path)
        {
            try
            {
                string PathOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + path);

                string Data = System.IO.File.ReadAllText(PathOne, System.Text.Encoding.UTF8);

                return Data;
            }
            catch
            {
                return "空";
            }

        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="path"></param>
        public void GetUserData(string path)
        {

            string PathDirRS2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + path);

            System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\" + path + "\\");


            string PathDirRS3 = System.IO.Path.Combine(PathDirRS2, "QD");
            if (System.IO.Directory.Exists(PathDirRS3) == false)
            {
                System.IO.Directory.CreateDirectory(PathDirRS3);

            }

            int JiFeng = System.IO.Directory.GetFiles(PathDirRS3).Length;


            DirectoryInfo one = new DirectoryInfo(PathDirRS2);

            //用户ID：
            Label1.Text = GetOneUserData(path + "\\user_name.txt");
            //关注时间：[Label2]
            Label2.Text = one.CreationTime.ToString("yyyy/MM/dd hh:mm:ss");

            //最后一次访问时间：[Label3]
            Label3.Text = one.LastWriteTime.ToString("yyyy/MM/dd hh:mm:ss");

            //用户昵称：[Label4]
            Label4.Text = GetOneUserData(path + "\\nick.txt");
            //用户性别：[Label5]
            Label5.Text = GetOneUserData(path + "\\xingbie.txt");
            //用户来源：[Label6]
            Label6.Text = GetOneUserData(path + "\\xueyuan.txt");
            //用户签名：[Label7]
            Label7.Text = GetOneUserData(path + "\\qianming.txt");
            //用户地址：[Label8]
            Label8.Text = GetOneUserData(path + "\\dizhi.txt");
            //用户积分：[Label9]
            Label9.Text = JiFeng.ToString();


        }


        protected void FileManager1_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            if (Page.IsCallback)
            {
                e.ClientScript = "alert('Use ExecuteCommand event to handle your custom command.\\nCommandName=" + e.CommandName +
                                 "\\nItem=" + e.Items[0].VirtualPath + "')";
            }
            else
            {
                if (e.CommandName == "EditText")
                {
                    if (e.Items.Count == 0)
                        return;

                    FileManagerItemInfo item = e.Items[0];
                    ViewState["EditDocumentPath"] = item.PhysicalPath;
                    string text = File.ReadAllText(item.PhysicalPath, System.Text.Encoding.UTF8);

                    WeTextBoxOne.Text = text;
                    WeTextBoxOne.Visible = true;

                    Panel1.Visible = false ;
                    Panel2.Visible = true ;
                    FileManager1.Visible = false;
                   
                     
                }
            }
        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            string filePath = (string)ViewState["EditDocumentPath"];
           
 
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            Panel2.Visible = true ;

        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            if (WeTextBoxOne.Visible == true)
            {
                FileManager1.Visible = true;
                WeTextBoxOne.Visible = false;

            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }


    }
}