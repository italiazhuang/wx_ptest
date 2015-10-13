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
    /// 微微信 表单
    /// </summary>
    public partial class UserTableDataBox : System.Web.UI.Page
    {
        

         

    protected void Page_Load(object sender, EventArgs e)
    {
        //CheckDir("USER_DIR\\SYSUSER\\Table\\"); // 表单文件夹
        //CheckDir("USER_DIR\\SYSUSER\\Table2\\"); // 表单结果收集文件夹 每个表单关键名称建立一个文件夹
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

        if (Page.IsPostBack) return;

        FileManager1.RootDirectories.Clear();
        RootDirectory rootDirectory = new RootDirectory();
        rootDirectory.DirectoryPath = "~/user_dir/sysuser/table/Table2";
        rootDirectory.Text = "表单结果收集";
        FileManager1.RootDirectories.Add(rootDirectory);

        System.Globalization.CultureInfo culture = null;
        string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

        culture = new System.Globalization.CultureInfo("zh-CN");
        FileManager1.Culture = culture;

        FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;

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

                FileManager1.Visible = false;
                TextEditor.Visible = true;
            }
        }
    }

    protected void FileManager1_ToolbarCommand(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "GETDATA")
        {
            string zipFile = System.IO.Path.Combine(FileManager1.CurrentDirectory.PhysicalPath,
                                                    "ZIP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");


            Label1.Text = "";

            if (FileManager1.SelectedItems.Length == 0)
                Label1.Text = "Please, select any item first.<br />";
            else
                foreach (FileManagerItemInfo item in FileManager1.SelectedItems)
                {
                    Label1.Text += item.VirtualPath + "<br />";

                }


        }

    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        string filePath = (string)ViewState["EditDocumentPath"];
        File.WriteAllText(filePath, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

        FileManager1.Visible = true;
        TextEditor.Visible = false;
    }

    protected void ButtonTwo_Click(object sender, EventArgs e)
    {
        FileManager1.Visible = true;
        TextEditor.Visible = false;
    }    
 


    }
}