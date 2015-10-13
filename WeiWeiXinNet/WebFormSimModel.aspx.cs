using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeiWeiXinNet
{
    public partial class WebFormSimModel : System.Web.UI.Page
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public string UserIDTime = "";

        /// <summary>
        /// 用户ID
        /// </summary>
        string RID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        


        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            string sel = Request.QueryString["sel"]; //1 大转盘  2刮刮卡 3优惠劵

            if (WeTextBoxOne.Text.Trim() == "")
                return;

            string UserID = WeTextBoxOne.Text;// "weiwei_user_id";  //用户　ID
            //使用时间戳加密 
            string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(Server.MapPath("~"), UserID);

            //weiwei_user_id
            switch (sel)
            {
                case "1":
                    Response.Redirect("Marketing/Turntable/Turntable.aspx?id=" + ID_TIME);
                    break;
                case "2":
                    Response.Redirect("Marketing/LotteryTicket/LotteryTicket.aspx?id=" + ID_TIME);
                    break;
                case "3":
                    Response.Redirect("Marketing/Coupons/Coupons.aspx?id=" + ID_TIME);
                    break;
            }


        }
    }
}