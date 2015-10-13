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

using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;

namespace WeiWeiXinNet.admin
{
    /// <summary>
    ///  微微信 文本回复设置
    /// </summary>
    public partial class WeiXinBasicNewsEditorT : System.Web.UI.Page
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


            //给button1添加客户端事件
          //  ButtonSeven.Attributes.Add("OnClick", "return  jsED()");

            FileManager1.RootDirectories.Clear();
            RootDirectory rootDirectory = new RootDirectory();
            rootDirectory.DirectoryPath = "~/user_dir/sysuser/mypost/txt/";
            rootDirectory.Text = "文本消息";
            FileManager1.RootDirectories.Add(rootDirectory);

            System.Globalization.CultureInfo culture = null;
            string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            culture = new System.Globalization.CultureInfo("zh-CN");
            FileManager1.Culture = culture;

            FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Icons;

            Button9.Attributes.Add("OnClick", "return  jsED()");

            FileManager1.HideEXT = true;


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

        protected void FileManager1_ToolbarCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "GETDATA")
            {

                FileManager1.Visible = false;
                TextEditor.Visible = true;

                WeTextBoxFive.Text = "请输入关键字";
                Label1.Text = "";
                WeTextBoxOne.Text = "";

            }

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


                    WeTextBoxFive.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(item.PhysicalPath);
                   //解析 
                    TextMsgData CMsgData = new TextMsgData();
                    CMsgData.LoadFile(item.PhysicalPath);

                    WeTextBoxOne.Text = CMsgData.Content;
                    Label1.Text = "";
                    FileManager1.Visible = false;
                    TextEditor.Visible = true;
                }
            }
        }



        protected void ButtonThree_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {

        }       

        protected void ButtonFive_Click(object sender, EventArgs e)
        {

            
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            
        }
 

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }


        protected void txt0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {

            if (WeTextBoxFive.Text.Trim() == "")
            {
                Label1.Text = "请输入关键字"; return;
            }

            try
            {
                string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\sysuser\\MyPost\\txt\\" + WeTextBoxFive.Text.Trim() + ".dll"); //图文 关键词回复目录);    

                TextMsgData CMsgData = new TextMsgData();
                CMsgData.Content = WeTextBoxOne.Text;
                CMsgData.SaveFile(PathFile);
               
                FileManager1.Visible = true;
                TextEditor.Visible = false;
                Label1.Text = "保存成功！";

                FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Icons;

            }
            catch
            {
                Label1.Text = "保存失败,关键字中不能有特殊字符";
            }
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            FileManager1.Visible = true;
            TextEditor.Visible = false;
        }

    }
}