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
    /// 订单索引 
    /// </summary>
    public partial class ShopOrdersManagement : System.Web.UI.Page
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

           
            //System.Globalization.CultureInfo culture = null;
            //string langName = new System.Globalization.CultureInfo("zh-CN").NativeName;

            //culture = new System.Globalization.CultureInfo("zh-CN");
            //FileManager1.Culture = culture;

            //FileManager1.FileViewMode = IZ.WebFileManager.Components.FileViewRenderMode.Details;
            ////Thumbnails

            //FileManager1.RootDirectories.Clear();
            //RootDirectory rootDirectory = new RootDirectory();

            ////string PathDirSYS = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SHANGCHENG\\DINGDAN");

            //rootDirectory.DirectoryPath = "~/user_dir/sysuser/shangcheng/dingdan";
            //rootDirectory.Text = "微商店订单";
            //FileManager1.RootDirectories.Add(rootDirectory);


            //FileManager1.HideEXT = true;

            ShowList();
        }
 


    public void ShowList()
    {

        //得到订单文件夹
        string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "user_dir/sysuser/shangcheng/dingdan");               
                          
       
        try
        {
            string[] mDir = System.IO.Directory.GetFiles(PathFile);

            //文件 建立日期 最后写入时间  用户ID  数据

            string TableX = "<table class='list-table' width='100%' style='width:100%;border-collapse:collapse;'> \r\n";
            TableX += "<tr class='head-light-box'> <td  width='5%'>编号</td> <td width='10%'>用户ID </td>  <td width='10%'>建立日期 </td>  <td width='10%'>最后写入时间 </td>  <td  width='60%'>数据 </td> </tr>\r\n";

            for (int i = 0; i < mDir.Length; i++)
            {
                string name = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(mDir[i]);
                FileInfo mfile = new FileInfo(mDir[i]);

                string data = System.IO.File.ReadAllText(mDir[i], System.Text.Encoding.UTF8);

               // string aH = "<a href='javascript:void(0);' onclick='javascript:PopUpWindow('UserGoodWebEdit.aspx?gd=" + name + "',100,100,880,490);' style='color: #FF0000'>";

                string aH = " <a href=\"javascript:void(0);\" onclick=\"javascript:PopUpWindow('UserGoodWebEdit.aspx?gd=" +name +"',10,10,960,540);\"  style=\"color: #FF0000\">";
                TableX += "<tr> "+"<td>" + i.ToString() + "</td> <td>   " +aH+ name + "</a> </td>  <td>" + mfile.CreationTime.ToString() + " </td>  <td>" + mfile.LastWriteTime.ToString() + " </td>  <td> " + data.Substring(0,data.Length/4).Replace(" ","").Replace("\r\n"," ") + "</td> </tr>\r\n";

            }

            TableX += "</table>";

            //   <textarea name="WeTextBoxOne" rows="2" cols="20" id="WeTextBoxOne" style="height:400px;width:800px;">

            Literal1.Text = TableX;

            Panel1.Visible = true;
            Panel2.Visible = false;
            

        }
        catch
        {

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

             //   FileManager1.Visible = false;
                Panel1.Visible = true;
            }
        }
    }

    protected void ButtonOne_Click(object sender, EventArgs e)
    {
        string filePath = (string) ViewState["EditDocumentPath"];
        File.WriteAllText(filePath, WeTextBoxOne.Text);
        
     //   FileManager1.Visible = true;
        Panel1.Visible = false;
    }

    protected void ButtonTwo_Click(object sender, EventArgs e)
    {
      //  FileManager1.Visible = true;
        Panel1.Visible = false;
    }    
 


    }
}