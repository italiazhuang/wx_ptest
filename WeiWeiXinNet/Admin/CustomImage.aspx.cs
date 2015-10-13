﻿/*
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
    ///  图像设置
    /// </summary>
    public partial class CutomImage : System.Web.UI.Page
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
                if(e.Items.Count == 0)
                    return;

                FileManagerItemInfo item = e.Items[0];
                ViewState["EditDocumentPath"] = item.PhysicalPath;
                string text = File.ReadAllText(item.PhysicalPath);

                WeTextBoxOne.Text = text;

                FileManager1.Visible = false;
                TextEditor.Visible = true;
            }
        }
    }
    
    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        string filePath = (string) ViewState["EditDocumentPath"];
        File.WriteAllText(filePath, WeTextBoxOne.Text,System.Text.Encoding.UTF8);
        
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