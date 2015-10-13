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
    /// 微微信 音频回复设置
    /// </summary>
    public partial class WeiXinBasicNewsEditorV : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
          

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
            rootDirectory.DirectoryPath = "~/user_dir/sysuser/mypost/voc/";
            rootDirectory.Text = "音频消息";
            FileManager1.RootDirectories.Add(rootDirectory);

            if (Page.IsPostBack) return;


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
                
                //string zipFile = System.IO.Path.Combine(FileManager1.CurrentDirectory.PhysicalPath,
                //                                        "ZIP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");


                //Label1.Text = "";

                //if (FileManager1.SelectedItems.Length == 0)
                //    Label1.Text = "Please, select any item first.<br />";
                //else
                //    foreach (FileManagerItemInfo item in FileManager1.SelectedItems)
                //    {
                //        Label1.Text += item.VirtualPath + "<br />";

                //    }


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

                    MusicMsgData mData = new MusicMsgData();
                    mData.LoadFile(item.PhysicalPath);

                    WeTextBoxSix.Text = mData.Description;
                    WeTextBoxSix.Text = mData.Title;
                    txt0.Text = mData.MusicUrl;
                    txt1.Text = mData.HQMusicUrl;

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


        ///// <summary>
        ///// 保存 图文消息
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ButtonNine_Click(object sender, EventArgs e)
        //{
        //    if (WeTextBoxFive.Text.Trim().Length == 0)
        //    {
        //        Label1.Text = "关键词不能为空：" + DateTime.Now.ToShortTimeString();
        //        return;
        //    }

        //    if (WeTextBoxFive.Text.Trim().Length == 0)
        //    {
        //        Label1.Text = "内容不能为空：" + DateTime.Now.ToShortTimeString();
        //        return;
        //    }


        //    string PathXML = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\MyPost\\IMG\\" + WeTextBoxFive.Text.Trim() + ".dll"); //图文 关键词回复目录);    
        //    System.IO.File.WriteAllText(PathXML , WeTextBoxOne.Text , System.Text.Encoding.UTF8 );

        //    RS();

        //    WeTextBoxOne.Text = "";
        //    WeTextBoxFive.Text = "";

        //}

        ///// <summary>
        ///// 刷新目录
        ///// </summary>
        //public void RS()
        //{
        //    string PathDir02 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\MyPost\\IMG"); //图文 关键词回复目录);    
        //    string[] MyXIN = System.IO.Directory.GetFiles(PathDir02, "*.dll");

        //    DropDownList2.Items.Clear();

        //    foreach (string a in MyXIN)
        //    {
        //        System.IO.FileInfo xxaa = new System.IO.FileInfo(a);

        //        DropDownList2.Items.Add(xxaa.Name.ToLower().Replace(".dll", ""));
        //    }

        //}

     

        
       

        protected void ButtonFive_Click(object sender, EventArgs e)
        {

            
        }

        //protected void ButtonSix_Click(object sender, EventArgs e)
        //{
        //    if (DropDownList2.Text.Length == 0)
        //    {
        //        Label1.Text = "删除错误：" + DateTime.Now.ToShortTimeString();

        //        return;
        //    }

        //    string PathDir02 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\MyPost\\IMG\\" + DropDownList2.Text+".dll"); //图文 关键词回复目录);    

        //    System.IO.File.Delete(PathDir02);

        //    Label1.Text = "删除成功：" + DateTime.Now.ToShortTimeString();

           
        //    RS();

        //    WeTextBoxOne.Text = "";
        //    WeTextBoxFive.Text = "";
        //}

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            
        }

   

        /// <summary>
        /// 模板
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public string GetXML_MODEL(int N)
        {

            MusicMsgData CMsgData = new MusicMsgData();
            CMsgData.Description = "音乐描述";
            CMsgData.Title = "音乐标题";
            CMsgData.MusicUrl = "音乐URL";
            CMsgData.HQMusicUrl = "高品质音乐URL";

           return  CMsgData.Getdata();
        }

        
 
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        //protected void Button20_Click(object sender, EventArgs e)
        //{
        //    WeTextBoxFive.Text = DropDownList2.Text;

        //    string PathDir02 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\MyPost\\IMG\\" + DropDownList2.Text + ".dll"); //图文 关键词回复目录);    

        //    WeTextBoxOne.Text = System.IO.File.ReadAllText(PathDir02, System.Text.Encoding.UTF8);

        //    Label1.Text = "读取成功：" + DateTime.Now.ToShortTimeString();

        //}

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
                string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\sysuser\\MyPost\\voc\\" + WeTextBoxFive.Text.Trim() + ".dll"); //图文 关键词回复目录);    


                MusicMsgData mData = new MusicMsgData
                {
                    Description =WeTextBoxSix.Text,
                    Title = WeTextBoxSix.Text,//+ URLMP3,
                    MusicUrl =txt0.Text,// @"http://news.iciba.com//admin//tts//2014-03-18.mp3",
                    HQMusicUrl =txt1.Text//"http://www.0951uc.com/%E9%9D%92%E6%98%A5%E6%A0%A1%E5%9B%AD"
                };

                mData.SaveFile(PathFile);
               // File.WriteAllText(PathFile, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

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