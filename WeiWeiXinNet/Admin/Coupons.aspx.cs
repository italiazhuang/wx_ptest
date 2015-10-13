using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiWeiXinNet.admin
{
    public partial class Coupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            try
            {
                string PathDataBase1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic1.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
                txt0.Text = System.IO.File.ReadAllText(PathDataBase1, System.Text.Encoding.UTF8);
                string PathDataBase2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic2.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
                txt3.Text = System.IO.File.ReadAllText(PathDataBase2, System.Text.Encoding.UTF8);

                   Image1.ImageUrl =  txt0.Text ;

                   Image2.ImageUrl = txt3.Text;
            }
            catch
            { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string PathDataBase1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic1.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            System.IO.File.WriteAllText(PathDataBase1, txt0.Text, System.Text.Encoding.UTF8);
            string PathDataBase2 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\Coupons\\pic2.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            System.IO.File.WriteAllText(PathDataBase2, txt3.Text, System.Text.Encoding.UTF8);

            Image1.ImageUrl = txt0.Text;

            Image2.ImageUrl = txt3.Text;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            Panel1.Visible = false;
            Panel2.Visible = true ;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }
    }
}