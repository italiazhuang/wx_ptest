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
    /// 微微信 关键词转义设置
    /// </summary>
    public partial class WeiXinBasicNewsEditorZ : System.Web.UI.Page
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
            rootDirectory.DirectoryPath ="~/user_dir/sysuser/mypost/zhuan/";
            rootDirectory.Text = "关键词转向";
            FileManager1.RootDirectories.Add(rootDirectory);

            System.Globalization.CultureInfo culture = null;
            string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            culture = new System.Globalization.CultureInfo("zh-CN");
            FileManager1.Culture = culture;

            FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Icons;

            Button9.Attributes.Add("OnClick", "return  jsED()");

        //    Button10.Attributes.Add("OnClick", "return  jsModel()");
            


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

                    ZhuanMsgData CMsgData = new ZhuanMsgData();

                    CMsgData.LoadFile(item.PhysicalPath);


                    string text = CMsgData.Content;// File.ReadAllText(item.PhysicalPath, System.Text.Encoding.UTF8);

                    WeTextBoxOne.Text = text;
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

        protected void ButtonTen_Click(object sender, EventArgs e)
        {

            WeTextBoxOne.Text = GetXML_MODEL(1);
        }

        /// <summary>
        /// 模板
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public string GetXML_MODEL(int N)
        {

            ZhuanMsgData CMsgData = new ZhuanMsgData();
            CMsgData.Content = "关键字";
            return CMsgData.Getdata();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(2);
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(3);
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(4);
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(5);
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(6);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(7);
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(8);
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(9);
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(10);
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
                string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\sysuser\\MyPost\\zhuan\\" + WeTextBoxFive.Text.Trim() + ".dll"); //图文 关键词回复目录);    

               // File.WriteAllText(PathFile, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

                ZhuanMsgData CMsgData = new ZhuanMsgData();
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