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
    /// 微网站页面 管理
    /// </summary>
    public partial class MobileSitePagesManagement : System.Web.UI.Page
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

        System.Globalization.CultureInfo culture = null;
        string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

        culture = new System.Globalization.CultureInfo("zh-CN");
        FileManager1.Culture = culture;

        FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;
        //Thumbnails

        FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;
        //Thumbnails

        FileManager1.RootDirectories.Clear();
        RootDirectory rootDirectory = new RootDirectory();
        rootDirectory.DirectoryPath = "~/user_dir/sysuser/pages/";
        rootDirectory.Text = "页面管理";
        FileManager1.RootDirectories.Add(rootDirectory);


        //ButtonOne.Attributes.Add("OnClick", "return  jsED1()");
        //ButtonTwo.Attributes.Add("OnClick", "return  jsED2()");
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

            WeTextBoxOne.Text = "页面.HTM";
            Label1.Text = "";
            WeTextBoxOne.Text = "";

            FileManager1.Visible = false;
            TextEditor.Visible = true;
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
                string text = File.ReadAllText(item.PhysicalPath, System.Text.Encoding.UTF8);

                FileInfo mfile = new FileInfo(item.PhysicalPath);
                WeTextBoxTwo.Text = mfile.Name.ToLower().Replace(".htm","");

                WeTextBoxOne.Text = text;
                WeTextBoxThree.Text = item.VirtualPath;
                FileManager1.Visible = false;
                TextEditor.Visible = true;

               // ButtonThree.Attributes.Add("OnClick", "javascript:window.open('" + item.VirtualPath + "','newwindow2','width=400,height=500,scrollbars=yes,top=150,left=150')");
               
            }
        }
    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        //   string filePath = (string) ViewState["EditDocumentPath"];

        if (WeTextBoxTwo.Text.ToLower().IndexOf(".") >= 0 )
        {
            Label1.Text = "不能含扩展名";
            return;
        }

        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\PAGES\\" + WeTextBoxTwo.Text.Trim()+".htm"); //图文 关键词回复目录);    


        File.WriteAllText(PathFile, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

        FileManager1.Visible = true;
        TextEditor.Visible = false;

        Label1.Text = "";
    }

    protected void ButtonTwo_Click(object sender, EventArgs e)
    {
        FileManager1.Visible = true;
        TextEditor.Visible = false;
    }

    protected void TextBox1_PreRender(object sender, EventArgs e)
    {

        //if (!string.IsNullOrWhiteSpace(WeTextBoxOne.Text))
        //{
        //    ButtonOne_Click(null, null);
        //    // write here what you want to save in your database.
        //}


    }    
 




    }
}