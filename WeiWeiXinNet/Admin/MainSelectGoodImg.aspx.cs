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
    /// 选择商品图像
    /// </summary>
    public partial class MainSelectGoodImg : System.Web.UI.Page
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

        if (Page.IsPostBack) return;
        System.Globalization.CultureInfo culture = null;
        string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

        culture = new System.Globalization.CultureInfo("zh-CN");
        FileManager1.Culture = culture;

        FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Thumbnails;
        //Thumbnails


        //FileManager1.RootDirectories.Clear();
        //RootDirectory rootDirectory = new RootDirectory();
        //rootDirectory.DirectoryPath = DirectoryManager.GetRootDirectoryPath(Context) + DropDownList1.SelectedValue;
        //rootDirectory.Text = DropDownList1.SelectedItem.Text;
        //FileManager1.RootDirectories.Add(rootDirectory);

        //FileManager1.Directory = null;

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
                // string text = File.ReadAllText(item.PhysicalPath);

                //   WeTextBoxOne.Text = text;

                //  FileManager1.Visible = false;
                // TextEditor.Visible = true;

                WeTextBoxTwo.Text = item.VirtualPath;

            }
        }
    }

    protected void FileManager1_ToolbarCommand(object sender, CommandEventArgs e)
    {

        if (e.CommandName == "GETDATAZ")
        {
            string zipFile = System.IO.Path.Combine(FileManager1.CurrentDirectory.PhysicalPath,
                                                    "ZIP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");




            if (FileManager1.SelectedItems.Length == 0)
            {
                // Label1.Text = "Please, select any item first.<br />";
            }
            else
            {

                foreach (FileManagerItemInfo item in FileManager1.SelectedItems)
                {
                    //   Label1.Text += item.VirtualPath + "<br />";
                    WeTextBoxTwo.Text = item.VirtualPath;
                    //     <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./ImageEditor/UpLoadUserPhotoC.aspx',100,100,600,500);">点击上传照片</a>
                    //   Response.Write("<javascript>javascript:PopUpWindow('./ImageEditor/UpLoadUserPhotoZ.aspx',100,100,600,500);</javascript>");

                }
            }

        }



    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        string filePath = (string)ViewState["EditDocumentPath"];
        File.WriteAllText(filePath, WeTextBoxOne.Text);

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