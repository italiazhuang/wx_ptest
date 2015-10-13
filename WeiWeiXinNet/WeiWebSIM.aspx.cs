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

namespace WeiWeiXinNet
{
    public partial class WeiWebSIM : System.Web.UI.Page
    {

        string TIME_MID = "";
        string RID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ButtonOne_Click(object sender, EventArgs e)
        {

            if (WeTextBoxOne.Text.Trim() == "")
            {
                return;
            }

            string UserID = WeTextBoxOne.Text;// "weiwei_user_id";  //用户　ID
            //使用时间戳加密 
            string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(Server.MapPath("~"),UserID);

            //weiwei_user_id
            Response.Redirect("Web.aspx?id=" + ID_TIME);
   }
    }
}