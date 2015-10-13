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
    /// 微信 LBS 回复
    /// </summary>
    public partial class WeiXinBasicNewsEditorL : System.Web.UI.Page
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

            //  TextEditorOne.Visible = false;

            //给button1添加客户端事件
            //  ButtonSeven.Attributes.Add("OnClick", "return  jsED()");

            FileManager1.RootDirectories.Clear();
            RootDirectory rootDirectory = new RootDirectory();
            rootDirectory.DirectoryPath = "~/user_dir/sysuser/mypost/location1/";
            rootDirectory.Text = "LBS消息";
            FileManager1.RootDirectories.Add(rootDirectory);

            if (Page.IsPostBack) return;


            System.Globalization.CultureInfo culture = null;
            string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            culture = new System.Globalization.CultureInfo("zh-CN");
            FileManager1.Culture = culture;

            FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;

            //Button9.Attributes.Add("OnClick", "return  jsED()");

            //Button10.Attributes.Add("OnClick", "return  jsModel()");
            //Button11.Attributes.Add("OnClick", "return  jsModel()");
            //Button12.Attributes.Add("OnClick", "return  jsModel()");
            //Button13.Attributes.Add("OnClick", "return  jsModel()");
            //Button14.Attributes.Add("OnClick", "return  jsModel()");
            //Button15.Attributes.Add("OnClick", "return  jsModel()");
            //Button16.Attributes.Add("OnClick", "return  jsModel()");
            //Button17.Attributes.Add("OnClick", "return  jsModel()");
            //Button18.Attributes.Add("OnClick", "return  jsModel()");
            //Button19.Attributes.Add("OnClick", "return  jsModel()");


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

              //  WeTextBoxFive.Text = "请输入关键字";
                Label1.Text = "";
                WeTextBoxOne.Text = "";

            }

            if (e.CommandName == "GETDATA_ONE")
            {

                FileManager1.Visible = false;
                //TextEditorOne.Visible = true;

             //   WeTextBoxFive.Text = "请输入关键字";
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

                    char[] x={'_','.'};
                  string[] Name2=   ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(item.PhysicalPath).Split(x);

                  WeTextBoxFive.Text=  Name2[0].Replace("V",".") ;
                  WeTextBoxSix.Text = Name2[1].Replace("V", ".");
                  //  string text = File.ReadAllText(item.PhysicalPath, System.Text.Encoding.UTF8);

                    //  TreeView1.Nodes.Add(new TreeNode("新图文消息", ""));
                    

                    NewsMsgData CMsgData = new NewsMsgData();
                    CMsgData.LoadFile(item.PhysicalPath);


                    

                    TextBoxTitle.Text = CMsgData.Items[0].Title;
                    txt0.Text = CMsgData.Items[0].PicUrl;
                    TextBoxUrl.Text = CMsgData.Items[0].Url;
                    TextBoxEDIT.Text = CMsgData.Items[0].Description;
                     

                    WeTextBoxOne.Text = CMsgData.Getdata();
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

            NewsMsgData CMsgData = new NewsMsgData();
            for (int i = 0; i < N; i++)
            {
                NewsItem cN = new NewsItem();
                cN.Title = "项目 " + i.ToString() + " 标题";
                cN.Description = "项目 " + i.ToString() + " 具体内容描述";
                cN.PicUrl = "http://xxxx.com/img/a.jpg ";
                cN.Url = "http://xxxx.com/img/a.aspx";

                CMsgData.Items.Add(cN);
            }
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

        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            FileManager1.Visible = true;
            TextEditor.Visible = false;
        }

      

         

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {

        }

   

       

        protected void Button24_Click(object sender, EventArgs e)
        {

            if (WeTextBoxFive.Text.Trim() == "")
            {
                Label1.Text = "请输入关键字"; return;
            }

            NewsItem myItem = new NewsItem();
            myItem.Title = TextBoxTitle.Text;
            myItem.PicUrl = txt0.Text;
            myItem.Url = TextBoxUrl.Text;
            myItem.Description = TextBoxEDIT.Text;

            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadSet(WeTextBoxOne.Text);

            bool IsSave = false;
            for (int i = 0; i < CMsgData.Items.Count; i++)
            {


                CMsgData.Items[i] = myItem;
                IsSave = true;
                break;

            }

            if (IsSave == false)
                CMsgData.Items.Add(myItem);



            WeTextBoxOne.Text = CMsgData.Getdata();

            try
            {
                long nX = (int)(double.Parse(WeTextBoxFive.Text) * 100000);
                long nY = (int)(double.Parse(WeTextBoxSix.Text) * 100000);

                string NAME2 = nX.ToString() + "_" + nY.ToString();   //模糊地址

                //long nX1 = (int)(double.Parse(WeTextBoxFive.Text) * 10000000);
                //long nY1 = (int)(double.Parse(WeTextBoxSix.Text) * 10000000);



                string NAME1 = WeTextBoxFive.Text.Replace(".", "V") + "_" + WeTextBoxSix.Text.Replace(".", "V"); //高精度地址


                string PathFile1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location1\\" + NAME1 + ".dll"); //图文 关键词回复目录);    
                File.WriteAllText(PathFile1, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

                string PathFile2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location2\\" + NAME2 + ".dll"); //图文 关键词回复目录);    
                File.WriteAllText(PathFile2, WeTextBoxOne.Text, System.Text.Encoding.UTF8);



                FileManager1.Visible = true;
                TextEditor.Visible = false;
                Label1.Text = "保存成功！";

                FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;

            }
            catch
            {
                Label1.Text = "保存失败,关键字中不能有特殊字符";
            }
        }

    }
}