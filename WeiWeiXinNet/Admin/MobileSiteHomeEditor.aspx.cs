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
    /// 站点 首页设置
    /// </summary>
    public partial class MobileSiteHomeEditor : System.Web.UI.Page
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

            //CKEditor1.CKEditorInstanceEventHandler = new System.Collections.Generic.List<object>();
            ////	CKEditor1.CKEditorInstanceEventHandler.Add(new object[] { "instanceReady", "function (evt) { alert('Event Handler attached on CKEditorInstanceEventHandler to editor: ' + evt.editor.name);}" });

            //CKEditor1.config.toolbar = new object[]
            //{
            //    new object[] { "Source", "-", "NewPage", "Preview", "-", "Templates" },
            //    new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
            //    new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat" },
            //    new object[] { "Form", "Checkbox", "Radio", "TextField", "Textarea", "Select", "Button", "ImageButton", "HiddenField" },
            //    "/",
            //    new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
            //    new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent", "Blockquote", "CreateDiv" },
            //    new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
            //    new object[] { "BidiLtr", "BidiRtl" },
            //    new object[] { "Link", "Unlink", "Anchor" },
            //    new object[] { "Image", "Flash", "Table", "HorizontalRule", "Smiley", "SpecialChar", "PageBreak", "Iframe" },
            //    "/",
            //    new object[] { "Styles", "Format", "Font", "FontSize" },
            //    new object[] { "TextColor", "BGColor" },
            //    new object[] { "Maximize", "ShowBlocks", "-", "About" }
            //};

         
            ButtonOne.Attributes.Add("OnClick", "return  jsSave();");

            //ButtonFive.Attributes.Add("OnClick", "return  jsLoad();");
            //Button6.Attributes.Add("OnClick", "return  jsLoad();");
            //ButtonSeven.Attributes.Add("OnClick", "return  jsLoad();");
            //Button8.Attributes.Add("OnClick", "return  jsLoad();");

            try
            {
                //系统目录 存放目录
                string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\Start.HTM");
                String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
                CKEditor1T.Text = TXTSET;
                ;
            }
            catch
            { }

        }
 

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\Start.HTM");            
            System.IO.File.WriteAllText(PathFileOne, CKEditor1T.Text, System.Text.Encoding.UTF8);

        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonFive_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\M0.HTML");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            CKEditor1T.Text = TXTSET;
        }

        protected void ButtonSix_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\M1.HTML");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            CKEditor1T.Text = TXTSET;
        }

        protected void ButtonSeven_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\M2.HTML");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            CKEditor1T.Text = TXTSET;
        }

        protected void ButtonEight_Click(object sender, EventArgs e)
        {
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\M3.HTML");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            CKEditor1T.Text = TXTSET;
        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {
           

        }

        protected void Button9_Click1(object sender, EventArgs e)
        {
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\HOME\\M5.HTML");
            String TXTSET = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            CKEditor1T.Text = TXTSET;
        }

      
    }
}