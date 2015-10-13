using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiWeiXinNet.admin
{
    public partial class LotteryTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            try
            {
                string PathDataBase1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\LotteryTicket\\JiangPing.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
                txt1.Text = System.IO.File.ReadAllText(PathDataBase1, System.Text.Encoding.UTF8);
       
            }
            catch
            { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string PathDataBase1 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\LotteryTicket\\JiangPing.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            System.IO.File.WriteAllText(PathDataBase1, txt1.Text, System.Text.Encoding.UTF8);
       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            Panel2.Visible = false;
            Panel1.Visible = true ;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }
}