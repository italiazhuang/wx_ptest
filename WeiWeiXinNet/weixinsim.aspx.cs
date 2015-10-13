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
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace WeiWeiXinNet
{
    public partial class weixinsim : System.Web.UI.Page
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


        }

        /// <summary>
        /// 发送文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonOne_Click(object sender, EventArgs e)
        {

            if (WeTextBoxOne.Text.Trim() == "")
                WeTextBoxOne.Text = "文本消息";

            string xml = cTextXml(WeTextBoxOne.Text);
            string RT = SendToTest(xml);
            RT = XML2HTML(RT);
            WeTextBoxTwo.Text = " <font size=\"2\" color=\"#0000cc\">发送-文本(" + DateTime.Now.ToShortTimeString()+":"+DateTime.Now.Second.ToString() + "):" + WeTextBoxOne.Text + "</font><br/>" + RT + WeTextBoxTwo.Text;

        }




        public string SendToTest(string xml)
        {
            string host = Request.ServerVariables["HTTP_HOST"] + Request.ServerVariables["PATH_INFO"];
            host = host.Replace("weixinsim.aspx", "");

            string url = "http://" + host + "v.ashx";



            WeiWeiXinNet.admin.MyHttpWebRequest req = new WeiWeiXinNet.admin.MyHttpWebRequest();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("", xml);
          //  req.SetTimeOut(5);
            string rtn = req.post(url, nvc, Encoding.UTF8);
            

            return rtn;

        }


        /// <summary>
        /// 创建文本XML
        /// </summary>
        /// <param name="SendTxtData"> 发送文本数据</param>
        /// <returns></returns>
        private string cTextXml(string SendTxtData)
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<xml>").Append("\r\n");
            txt.Append("<ToUserName><![CDATA[").Append("txtToUserNameText").Append("]]></ToUserName>").Append("\r\n");
            txt.Append("<FromUserName><![CDATA[").Append(WeTextBoxThree.Text).Append("]]></FromUserName>").Append("\r\n");
            txt.Append("<CreateTime>").Append(GetTimestamp()).Append("</CreateTime>").Append("\r\n");
            txt.Append("<MsgType><![CDATA[text]]></MsgType>").Append("\r\n");
            txt.Append("<Content><![CDATA[").Append(SendTxtData).Append("]]></Content>").Append("\r\n");
            txt.Append("<MsgId>1234567890123456</MsgId>").Append("\r\n");
            txt.Append("</xml>");
            return txt.ToString();
        }

        /// <summary>
        /// 创建图片XML
        /// </summary>
        /// <returns></returns>
        private string cPicXml(string PicUrl)
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<xml>").Append("\r\n");
            txt.Append("<ToUserName><![CDATA[").Append("txtToUserNameText").Append("]]></ToUserName>").Append("\r\n");
            txt.Append("<FromUserName><![CDATA[").Append(WeTextBoxThree.Text).Append("]]></FromUserName>").Append("\r\n");
            txt.Append("<CreateTime>").Append(GetTimestamp()).Append("</CreateTime>").Append("\r\n");
            txt.Append("<MsgType><![CDATA[image]]></MsgType>").Append("\r\n");
            txt.Append("<PicUrl><![CDATA[").Append(PicUrl).Append("]]></PicUrl>").Append("\r\n");
            txt.Append("<MsgId>1234567890123456</MsgId>").Append("\r\n");
            txt.Append("</xml>");
            return txt.ToString();
        }

        /// <summary>
        /// 订阅XML
        /// </summary>
        /// <returns></returns>
        private string cSubcribleXml()
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<xml>").Append("\r\n");
            txt.Append("<ToUserName><![CDATA[").Append("txtToUserNameText").Append("]]></ToUserName>").Append("\r\n");
            txt.Append("<FromUserName><![CDATA[").Append(WeTextBoxThree.Text).Append("]]></FromUserName>").Append("\r\n");
            txt.Append("<CreateTime>").Append(GetTimestamp()).Append("</CreateTime>").Append("\r\n");
            txt.Append("<MsgType><![CDATA[event]]></MsgType>").Append("\r\n");
            txt.Append("<Event><![CDATA[subscribe]]></Event>").Append("\r\n");
            txt.Append("</xml>");
            return txt.ToString();
        }

        /// <summary>
        /// 菜单 点击
        /// </summary>
        /// <param name="EventKey">键值</param>
        /// <returns></returns>
        private string cMenuClickXml(string EventKey)
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<xml>").Append("\r\n");
            txt.Append("<ToUserName><![CDATA[").Append("txtToUserNameText").Append("]]></ToUserName>").Append("\r\n");
            txt.Append("<FromUserName><![CDATA[").Append(WeTextBoxThree.Text).Append("]]></FromUserName>").Append("\r\n");
            txt.Append("<CreateTime>").Append(GetTimestamp()).Append("</CreateTime>").Append("\r\n");
            txt.Append("<MsgType><![CDATA[event]]></MsgType>").Append("\r\n");
            txt.Append("<Event><![CDATA[CLICK]]></Event>").Append("\r\n");
            txt.Append("<EventKey><![CDATA[").Append(EventKey).Append("]]></EventKey>").Append("\r\n");
            txt.Append("</xml>");
            return txt.ToString();
        }


        /// <summary>
        /// 位置XML
        /// </summary>
        /// <returns></returns>
        private string LocationXml()
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("<xml>").Append("\r\n");
            txt.Append("<ToUserName><![CDATA[").Append("txtToUserNameText").Append("]]></ToUserName>").Append("\r\n");
            txt.Append("<FromUserName><![CDATA[").Append(WeTextBoxThree.Text).Append("]]></FromUserName>").Append("\r\n");
            txt.Append("<CreateTime>").Append(GetTimestamp()).Append("</CreateTime>").Append("\r\n");
            txt.Append("<MsgType><![CDATA[location]]></MsgType>").Append("\r\n");
            txt.Append("<Location_X>").Append("12345.12345").Append("</Location_X>").Append("\r\n");
            txt.Append("<Location_Y>").Append("67890.67890").Append("</Location_Y>").Append("\r\n");
            txt.Append("<Scale>20</Scale>").Append("\r\n");
            txt.Append("<Label><![CDATA[]]></Label>").Append("\r\n");
            txt.Append("<MsgId>1234567890123456</MsgId>").Append("\r\n");
            txt.Append("</xml>");
            return txt.ToString();
        }

        private Int64 GetTimestamp()
        {
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (Int64)span.TotalSeconds;
        }

        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            //  WeTextBoxTwo.Text = "<font size=\"2\" color=\"#0000cc\">我-关注本微信(" + DateTime.Now.ToShortTimeString() + "):" + "</font><br/>" + WeTextBoxTwo.Text;

            string xml = cSubcribleXml();
            string RT = SendToTest(xml);
            RT = XML2HTML(RT);
            WeTextBoxTwo.Text = " <font size=\"2\" color=\"#0000cc\">发送-关注(" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString() + "):" + "【关注】" + "</font><br/>" + RT + WeTextBoxTwo.Text;


        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            // WeTextBoxTwo.Text = "<font size=\"2\" color=\"#0000cc\">我-上传图片(" + DateTime.Now.ToShortTimeString() + "):" + "</font><br/>" + WeTextBoxTwo.Text;


            string host = Request.ServerVariables["HTTP_HOST"] + Request.ServerVariables["PATH_INFO"];
            host = host.Replace("weixinsim.aspx", "");

            string url = "http://" + host + "imgx/start3.jpg";

            string xml = cPicXml(url);
            string RT = SendToTest(xml);
            RT = XML2HTML(RT);
            WeTextBoxTwo.Text = " <font size=\"2\" color=\"#0000cc\">上传-图片(" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString() + "):" + "【上传图片】" + "</font><br/>" + RT + WeTextBoxTwo.Text;
              

        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {

            if (WeTextBoxOne.Text.Trim() == "")
                WeTextBoxOne.Text = "菜单键值";

            string xml = cMenuClickXml(WeTextBoxOne.Text);
            string RT = SendToTest(xml);
            RT = XML2HTML(RT);
            WeTextBoxTwo.Text = " <font size=\"2\" color=\"#0000cc\">点击-菜单(" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString() + "):" + WeTextBoxOne.Text + "</font><br/>" + RT + WeTextBoxTwo.Text;  

        }


        /*
         //图文
<xml>
<ToUserName><![CDATA[txtFromUserNameText]]></ToUserName>
<FromUserName><![CDATA[txtToUserNameText]]></FromUserName>
<CreateTime>452390109</CreateTime>
<MsgType><![CDATA[news]]></MsgType>
<ArticleCount>1</ArticleCount>
<Articles>
<item>
<Title><![CDATA[微信助手Start应用服务]]></Title>
<Description><![CDATA[欢迎使用微信助手-微信大学Start应用服务，这是一个极速用户交互程序来帮助您在微信学习、社交和生活，点击进入]]></Description>
<PicUrl><![CDATA[http://www.xxxx.com/start1.jpg]]></PicUrl>
<Url><![CDATA[http://www.xxxx.com/Web.aspx?id=16C21B42928ABA0F2BF3E54542ACA91C9FB5C2B0434DB46F89318BF060715352BC60D827C147ADF807E937405706E13FFA0F829DA28F0E3B]]></Url>
</item>
</Articles>
</xml>


//文本

<xml>
<ToUserName><![CDATA[txtFromUserNameText]]></ToUserName>
<FromUserName><![CDATA[txtToUserNameText]]></FromUserName>
<CreateTime>452390194</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[[微笑]欢迎关注微信大学微信助手官方微信公众平台！您是第8302位关注者~本平台由微信大学电子科技协会提供技术支持，为师生、校友、家长提供全方位的校园信息服务。【Start】可以查询更多内容哦。[害羞]]]></Content>
</xml>

                  //关注
         <xml>
<ToUserName><![CDATA[txtFromUserNameText]]></ToUserName>
<FromUserName><![CDATA[txtToUserNameText]]></FromUserName>
<CreateTime>452393492</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[[微笑]欢迎关注微信大学微信助手官方微信公众平台！您是第8316位关注者~本平台由微信大学电子科技协会提供技术支持，为师生、校友、家长提供全方位的校园信息服务。【Start】可以查询更多内容哦。[害羞]]]></Content>
</xml>
         

//音乐

<xml>
<ToUserName><![CDATA[txtFromUserNameText]]></ToUserName>
<FromUserName><![CDATA[txtToUserNameText]]></FromUserName>
<CreateTime>452391263</CreateTime>
<MsgType><![CDATA[music]]></MsgType>
<Music>
<Title><![CDATA[音乐标题]]></Title>
<Description><![CDATA[音乐描述]]></Description>
<MusicUrl><![CDATA[http://音乐url]]></MusicUrl>
<HQMusicUrl><![CDATA[http://高品质url]]></HQMusicUrl>
</Music>
</xml> 
         

         * 
         * 
         */



        /// <summary>
        /// 微信返回值解析
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public string XML2HTML(string xml)
        {



            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(xml);


                XmlNode xnMsgType = xmlDoc.SelectSingleNode("//MsgType");
                if (xnMsgType.InnerText.ToLower().Trim() == "news")
                {
                    //  + " + RT + "</font><br/>" + WeTextBoxTwo.Text; ;
                    string RT = "<font size=\"2\" color=\"#990000\">收到：图文消息</font><br/><font size=\"2\" color=\"#09206c\">";

                    XmlNodeList xnList = xmlDoc.SelectNodes("//item");
                    foreach (XmlNode xn in xnList)
                    {

                        string cTitle = (xn.SelectSingleNode("Title")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); 
                        string cDescription = (xn.SelectSingleNode("Description")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                        string cPicUrl = (xn.SelectSingleNode("PicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                        string cUrl = (xn.SelectSingleNode("Url")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); 

                        // <textarea cols="40" rows="1">sdcsdv</textarea>

                        RT += "<font size=\"2\" color=\"#006600\">标题:</font><textarea cols='35' rows='1'>" + cTitle + "</textarea><br/>";
                        RT += "<font size=\"2\" color=\"#006600\">描述:</font><textarea cols='35' rows='2'>" + cDescription + "</textarea><br/>";
                        RT += "<font size=\"2\" color=\"#006600\">图片:</font>"+ "<textarea cols='35' rows='1'>" + cPicUrl + "</textarea>" + GetMinBoxJs(cPicUrl) +"<br/>";
                        RT += "<font size=\"2\" color=\"#006600\">链接:</font>" + "<textarea cols='35' rows='1'>" + cUrl + "</textarea>" + GetMinBoxJs(cUrl)+"<br/>";

                    }

                    return RT + "</font><br/>";

                }
                if (xnMsgType.InnerText.ToLower().Trim() == "text")
                {
                    //Content
                    string cContent = xmlDoc.SelectSingleNode("//Content").InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); ;

                    string RT = "<font size=\"2\" color=\"#990000\">收到：文本消息</font><br/><font size=\"2\" color=\"#09206c\">";
                    return RT + "<textarea cols='35' rows='2'>" + cContent + "</textarea></font><br/>";

                } if (xnMsgType.InnerText.ToLower().Trim() == "music")
                {
                    XmlNode xnOne = xmlDoc.SelectSingleNode("//Music");

                    string cTitle = (xnOne.SelectSingleNode("Title")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); ;
                    string cDescription = (xnOne.SelectSingleNode("Description")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); ;
                    string cMusicUrl = (xnOne.SelectSingleNode("MusicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); ;
                    string cHQMusicUrl = (xnOne.SelectSingleNode("HQMusicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", ""); ;


                    string RT = "<font size=\"2\" color=\"#990000\">收到：音乐消息</font><br/><font size=\"2\" color=\"#09206c\">";


                    RT += "<font size=\"2\" color=\"#006600\">标题:</font><textarea cols='35' rows='1'>" + cTitle + "</textarea><br/>";
                    RT += "<font size=\"2\" color=\"#006600\">描述:</font><textarea cols='35' rows='2'>" + cDescription + "</textarea><br/>";
                    RT += "<font size=\"2\" color=\"#006600\">音乐:</font>" + "<textarea cols='35' rows='1'>" + cMusicUrl + "</textarea>"+ GetMinBoxJs(cMusicUrl) +"<br/>";
                    RT += "<font size=\"2\" color=\"#006600\">高品质:</font>" + "<textarea cols='35' rows='1'>" + cHQMusicUrl + "</textarea>" + GetMinBoxJs(cHQMusicUrl)+"<br/>";

                    return RT + "</font><br/>";

                }
                else
                {
                    return "<font size=\"2\" color=\"#006600\">收到：<br/>不能解析的数据类型: <textarea cols='35' rows='1'>" + xnMsgType.InnerText.ToLower().Trim() + "</textarea></font>";
                }


            }
            catch
            {
                return "<font size=\"2\" color=\"#006600\">收到：<br/>返回数据解析错误</font>";
            }

            return "";


        }

        /// <summary>
        /// 获取一个可以弹窗的URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetMinBoxJs(string url)
        {
            return "<a href='#'  onclick=\"javascript:window.open('"+ url+"','new2window','width=400,height=620,scrollbars=yes,top=10,left=421');\">"+"[查看]"+"</a>";
        }

        protected void ButtonFive_Click(object sender, EventArgs e)
        {
             
                WeTextBoxOne.Text = "tg";

                ButtonOne_Click(null ,null );
           
        }

        protected void ButtonSix_Click(object sender, EventArgs e)
        {
            WeTextBoxTwo.Text = "";
        }

        protected void ButtonSeven_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "@";

            ButtonOne_Click(null, null);
          //  WeTextBoxOne.Text = "我要输入的内容";
        }

        protected void ButtonEight_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "jf";

            ButtonOne_Click(null, null);
           // WeTextBoxOne.Text = "我要输入的内容";
        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "ft";

            ButtonOne_Click(null, null);
        }

        protected void ButtonTen_Click(object sender, EventArgs e)
        {

            WeTextBoxOne.Text = "Start";

            ButtonOne_Click(null, null);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            //发送位置 


            string xml = LocationXml();
            string RT = SendToTest(xml);
            RT = XML2HTML(RT);
            WeTextBoxTwo.Text = " <font size=\"2\" color=\"#0000cc\">LBS发送(" + DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString() + "):" + "【位置】" + "</font><br/>" + RT + WeTextBoxTwo.Text;



            
        }

        protected void Button8_Click1(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "q";

            ButtonOne_Click(null, null);
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "gw";

            ButtonOne_Click(null, null);
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "dzp";

            ButtonOne_Click(null, null);
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "ggk";

            ButtonOne_Click(null, null);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "yhj";

            ButtonOne_Click(null, null);
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = "yx";

            ButtonOne_Click(null, null);
        }









    }
}