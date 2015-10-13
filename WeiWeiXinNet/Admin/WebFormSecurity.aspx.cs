using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WeiWeiXinNet.admin
{
    public partial class WebFormSecurity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl frame1 = (HtmlControl)this.FindControl("frame1");

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

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text.Trim() == "")
                return;

            string PathM = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR");

            frame1.Attributes["src"] = "Security.ashx?e="+ TextBox1.Text ;
            //当然你还可以动态改变frame的大小：
            frame1.Attributes["width"] = "100%";
            frame1.Attributes["height"] = "500px";


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.Text;
        }

    

    }



 




}