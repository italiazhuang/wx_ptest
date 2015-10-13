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
    /// 微表单应用编辑
    /// </summary>
    public partial class MyTableAppEditor : System.Web.UI.Page
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

            FileManager1.RootDirectories.Clear();
            RootDirectory rootDirectory = new RootDirectory();
            rootDirectory.DirectoryPath = "~/user_dir/sysuser/table/table1";
            rootDirectory.Text = "我的表单";
            FileManager1.RootDirectories.Add(rootDirectory);

            System.Globalization.CultureInfo culture = null;
            string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            culture = new System.Globalization.CultureInfo("zh-CN");
            FileManager1.Culture = culture;

            FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Icons;

            FileManager1.HideEXT = true;

            ButtonThree.Attributes.Add("OnClick", "return  jsModel()");
            ButtonFour.Attributes.Add("OnClick", "return  jsModel()");
            ButtonFive.Attributes.Add("OnClick", "return  jsModel()");
            ButtonSix.Attributes.Add("OnClick", "return  jsModel()");
        

            //ButtonOne.ToolTip = "abc";

            //ButtonOne.PostBackUrl = "#";
            //ButtonOne.Attributes.Add("OnClick", "javascript:window.open('../admin/main35.aspx','newwindow','width=800,height=600,scrollbars=yes,top=50,left=50');");
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
                if(e.Items.Count == 0)
                    return;

                FileManagerItemInfo item = e.Items[0];
                ViewState["EditDocumentPath"] = item.PhysicalPath;
                string text = File.ReadAllText(item.PhysicalPath, System.Text.Encoding.UTF8);

                WeTextBoxOne.Text = text;

                string host = Request.ServerVariables["HTTP_HOST"];



                WeTextBoxTwo.Text = "http://" + (host + "/WebSurvey/m.aspx?t=" + item.VirtualPath).Replace("//", "/");

             //   ButtonSeven.Attributes.Add("OnClick", "javascript:window.open('" + WeTextBoxTwo.Text + "','newwindow','width=400,height=500,scrollbars=yes,top=150,left=150')");
                WeTextBoxThree.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(item.PhysicalPath);
                
                Panel1.Visible = false;
                TextEditor.Visible = true;
                Panel2.Visible = false;
            }
        }
    }

    protected void FileManager1_ToolbarCommand(object sender, CommandEventArgs e)
    {

        if (e.CommandName == "GETDATA2")
        {
            WeTextBoxThree.Text = "myTable";
            WeTextBoxOne.Text = "";
            WeTextBoxTwo.Text = "";
            Panel1.Visible = false;
        TextEditor.Visible = true;
        Panel2.Visible = false;
        }
        
        if (e.CommandName == "GETDATA")
        {
            string zipFile = System.IO.Path.Combine(FileManager1.CurrentDirectory.PhysicalPath,
                                                    "ZIP_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
            Label1.Text = "";

            if (FileManager1.SelectedItems.Length == 0)
                Label1.Text = "请先选择一个文件.<br />";
            else
                foreach (FileManagerItemInfo item in FileManager1.SelectedItems)
                {

                    string host = Request.ServerVariables["HTTP_HOST"];
                 //   Label1.Text += item.VirtualPath + "<br />";
                    WeTextBoxTwo.Text = "http://" + (host + "/WebSurvey/m.aspx?t=" + item.VirtualPath).Replace("//", "/");

                  //  ButtonSeven.Attributes.Add("OnClick", "javascript:window.open('"+ WeTextBoxTwo.Text+"','newwindow','width=400,height=500,scrollbars=yes,top=150,left=150')");
                }                            
        }


        //收集数据 
        if (e.CommandName == "GETDATA3")
        { 
            Label1.Text = "";

            if (FileManager1.SelectedItems.Length == 0)
                Label1.Text = "请先选择一个文件.<br />";
            else
                foreach (FileManagerItemInfo item in FileManager1.SelectedItems)
                {

                    string host = Request.ServerVariables["HTTP_HOST"];
                    //   Label1.Text += item.VirtualPath + "<br />";
                  //  WeTextBoxTwo.Text = "http://" + (host + "/WebSurvey/m.aspx?t=" + item.VirtualPath).Replace("//", "/");

                  //  读取收集结果文件夹  
                   // FileInfo my = new FileInfo(item.PhysicalPath);
                    string myname = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(item.PhysicalPath);

                    //得到结果文件夹
                    string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\table\\table2\\" + myname);

                    try
                    {

                        string[] mDir = System.IO.Directory.GetFiles(PathFile);

                        //文件 建立日期 最后写入时间  用户ID  数据

                        string TableX = "<table width='100%'> \r\n";
                        TableX += "<tr  valign=\"top\" bgcolor=\"#CCFF33\"> <td  width='10%'>编号</td> <td width='10%'>   用户ID </td>  <td width='10%'>建立日期 </td>  <td width='10%'>最后写入时间 </td>  <td  width='60%'>数据 </td> </tr>\r\n";

                        for (int i = 0; i < mDir.Length; i++)
                        {
                            string name = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(mDir[i]);
                            FileInfo mfile = new FileInfo(mDir[i]);

                            string data = System.IO.File.ReadAllText(  mDir[i], System.Text.Encoding.UTF8);

                           data=data.Replace("<?xml version=\"1.0\"?>\r\n","");
                            data=data.Replace("<Answers>\r\n","");
                           data = data.Replace("  <AnswerSet>\r\n", "");
                           data = data.Replace("</Answers>\r\n", "");
                            

                           data = data.Replace("  </AnswerSet>\r\n", "");
                           data = data.Replace("</Answers>", "");
                           data = data.Trim();

                           data = data.Replace("    ", "");

                            string mtstyle = "bgcolor=\"#CCFF66\"";
                            
                            if(i%2==0)
                                mtstyle = "bgcolor=\"#CCFF99\"";


                            TableX += "<tr " + mtstyle + "> <td>" + i.ToString() + "</td> <td>   " + name + " </td>  <td>" + mfile.CreationTime.ToString() + " </td>  <td>" + mfile.LastWriteTime.ToString() + " </td>  <td> <textarea rows=\"6\"  cols=\"100\">" + data + "</textarea></td> </tr>\r\n";


                        }

                        TableX += "</table>";

                        //   <textarea name="WeTextBoxOne" rows="2" cols="20" id="WeTextBoxOne" style="height:400px;width:800px;">

                        Literal1.Text = TableX;

                        Panel1.Visible = false;
                        TextEditor.Visible =false ;
                        Panel2.Visible =true ;

                    }
                    catch
                    {

                    }

                }


        }

    }

    
    
   

    protected void ButtonThree_Click(object sender, EventArgs e)
    {
        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Table\\Table3\\survey1.dll"); //图文 关键词回复目录);    

        WeTextBoxThree.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(PathFile);

        WeTextBoxOne.Text = File.ReadAllText(PathFile, System.Text.Encoding.UTF8);
         
        
        
    }

    protected void ButtonFour_Click(object sender, EventArgs e)
    {
        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Table\\Table3\\survey2.dll"); //图文 关键词回复目录);    

        WeTextBoxThree.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(PathFile);

        WeTextBoxOne.Text = File.ReadAllText(PathFile, System.Text.Encoding.UTF8);
         
    }

    protected void ButtonFive_Click(object sender, EventArgs e)
    {
        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Table\\Table3\\survey3.dll"); //图文 关键词回复目录);    

        WeTextBoxThree.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(PathFile);

        WeTextBoxOne.Text = File.ReadAllText(PathFile, System.Text.Encoding.UTF8);
         
    }

    protected void ButtonSix_Click(object sender, EventArgs e)
    {
        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Table\\Table3\\survey4.dll"); //图文 关键词回复目录);    

        WeTextBoxThree.Text = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(PathFile);

        WeTextBoxOne.Text = File.ReadAllText(PathFile, System.Text.Encoding.UTF8);
         
    }

    protected void ButtonSeven_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

        //   string filePath = (string) ViewState["EditDocumentPath"];


        if (WeTextBoxThree.Text.Trim() == "")
        {
            Label1.Text = "请输入关键字"; return;
        }

        try
        {
            string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\table\\table1\\" + WeTextBoxThree.Text.Trim() + ".dll"); //图文 关键词回复目录);    
            File.WriteAllText(PathFile, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

            Panel1.Visible = true;
            TextEditor.Visible = false;
            Panel2.Visible = false;
        }
        catch
        { }
    }

    protected void ButtonTwo_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
        TextEditor.Visible = false;
    }

    protected void ButtonEight_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonNine_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
        TextEditor.Visible = false;
    }

   
 


    }
}