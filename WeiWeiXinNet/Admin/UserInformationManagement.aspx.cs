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
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;




namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 用户信息管理
    /// </summary>
    public partial class UserInformationManagement : System.Web.UI.Page
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
           

            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable("wei");

            //dt.Columns.Add("ads", typeof(string));

            //DataRow dr = dt.NewRow();
            //dr["ads"] = "hyh";

            //ds.Tables.Add(dt);

            //GridView1.DataSource = ds.Tables;
            //GridView1.DataBind();

            myDatabind2();
        }

        protected void myDatabind2()
        {

            //系统目录 用户存放目录
            string PathDir0 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\USER\\");

            string[] ALLUser = System.IO.Directory.GetDirectories(PathDir0);
     

            DataTable dt = new DataTable();
            dt.Columns.Add("编号", Type.GetType("System.String"));
            dt.Columns.Add("关注时间", Type.GetType("System.String"));
            dt.Columns.Add("最后访问时间", Type.GetType("System.String"));
            dt.Columns.Add("最后写入时间", Type.GetType("System.String"));
            dt.Columns.Add("标示符", Type.GetType("System.String"));

            for (int i = 0; i < ALLUser.Length; i++)
            {
                DirectoryInfo one = new DirectoryInfo(ALLUser[i]);

                DataRow dr = dt.NewRow();
                //Response.Write(str[3]);
                dr["编号"] = i.ToString("D5");
                dr["关注时间"] = one.CreationTime.ToString("yyyy/MM/dd hh:mm:ss");
                dr["最后访问时间"] = one.LastAccessTime.ToString("yyyy/MM/dd hh:mm:ss");
                dr["最后写入时间"] = one.LastWriteTime.ToString("yyyy/MM/dd hh:mm:ss");
                dr["标示符"] = one.Name;
                dt.Rows.Add(dr);
            }

            gv_show.DataSource = dt;//前台gridview控件Id为gv_show
            gv_show.DataBind();

        }

        protected void myDatabindX()
        {
            StreamReader objReader = new StreamReader(Server.MapPath("RepositioningProfileDrug-rankMS.txt"), System.Text.Encoding.Default);
            string sLine = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("p1", Type.GetType("System.String"));
            dt.Columns.Add("p2", Type.GetType("System.String"));
            dt.Columns.Add("p3", Type.GetType("System.String"));
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine.IndexOf("name") < 0)
                {
                    string[] str = sLine.Split('\t');
                    DataRow dr = dt.NewRow();
                    //Response.Write(str[3]);
                    dr["name"] = str[0];
                    dr["p1"] = str[1];
                    dr["p2"] = str[2];
                    dr["p3"] = str[3];
                    dt.Rows.Add(dr);
                }
            }
            objReader.Close();
            gv_show.DataSource = dt;//前台gridview控件Id为gv_show
            gv_show.DataBind();
        }

 

        protected void gv_show_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_show.PageIndex = e.NewPageIndex;
            myDatabind2();

        }

     



        protected void gv_show_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var V = this.gv_show.Rows[e.NewEditIndex];

            String AData = this.gv_show.Rows[e.NewEditIndex].Cells[0].Text;

            string A = AData;
        }
 

        protected void gv_show_RowDataBound(object sender, GridViewRowEventArgs e)
        {
 if (e.Row.RowIndex > -1)
            {
                //循环每列 判断需要添加打开新窗体脚本的列 如果改行任意位置都能打开新窗体 则 直接执行if内代码  将cell改为e.Row
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (e.Row.Cells.GetCellIndex(cell) != 0 && e.Row.Cells.GetCellIndex(cell) != 10 && e.Row.Cells.GetCellIndex(cell) != 11)
                    {

                       //    var MyRow = e.Row.Cells[0];

                           string data = ((DataBoundLiteralControl)e.Row.Cells[4].Controls[0]).Text;
                           data = data.Replace("\n", "").Replace("\r", "").Trim();
                        //模版列 要获取到空间的值 如果是BoundFiled 直接去Text值即可
                          // Label lblId = "abc";
                        //弹出新窗体 
                          // cell.Attributes.Add("onclick", "window.showModalDialog('WebEditForm.aspx?Id=" + data + "','','dialogWidth=700px;dialogHeight=500px')");

                           cell.Attributes.Add("onclick", "javascript:PopUpWindow('WebEditForm.aspx?Id=" + data +"',100,100,810,500);");

                        // <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,800,490);">
                                            

                    }
                }
                //鼠标以上的样式
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#DEEFFF'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
                //鼠标样式
                e.Row.Style.Add("cursor", "hand");
            }
        }
    }
}