using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;
using System.Text.RegularExpressions;
using System.Globalization;

using System.Net;
using System.Text;


/// <summary>
/// v 的摘要说明
/// </summary>
public class v : IHttpHandler
{


    /// <summary>
    ///    开发者 验证 模块
    /// </summary>
    /// <param name="context"></param>
    public bool ProcessRequest2(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        try
        {
            string echoStr = context.Request["echoStr"];

            if (!string.IsNullOrEmpty(echoStr))
            {
                string signature = context.Request.QueryString["signature"], // 微信加密签名
                              timestamp = context.Request.QueryString["timestamp"], // 时间戳
                              nonce = context.Request.QueryString["nonce"], // 随机数
                              echostr = context.Request.QueryString["echostr"];// 随机字符串
                // 微信请求参数非空验证
                if (!String.IsNullOrEmpty(signature) && !String.IsNullOrEmpty(timestamp) && !String.IsNullOrEmpty(nonce) && !String.IsNullOrEmpty(echostr))
                {

                    string PathFileToken = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01Token.dll");
                    string Tokenstr = System.IO.File.ReadAllText(PathFileToken, System.Text.Encoding.UTF8);


                    // 检查加密签名是否正确
                    if (ClassLibraryWeiBao.weixinlib.ClassSignture.CheckSignature(signature, timestamp, nonce, Tokenstr))
                    {
                        context.Response.Write(echoStr);

                        return true;
                    }
                }
            }
        }
        catch (Exception e)
        {

        }
        return false;
    }







    public bool IsReusable
    {
        get
        {
            return false;
        }
    }



    /// <summary>
    /// 全新处理程序   主要作用
    /// 1 记录用户所有的输入
    /// 2 关键词匹配返回
    /// 3 不匹配的所有的输入 均返回 带 ID时间戳 的 Start
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {

        string httpMethod = context.Request.HttpMethod.ToUpper();

        if (httpMethod == "GET")
        {            
            ProcessRequest2(context);
            //如果 是 验证  则 直接 退出             
            return;
        }

        context.Response.ContentType = "text/plain";
        var m = ReceiveMessage.ParseFromContext();
        if (m == null)
            return;
        //获得当前 url 完整路径
        string host = context.Request.ServerVariables["HTTP_HOST"] + context.Request.ServerVariables["PATH_INFO"];
        host = host.Replace("v.ashx", "");
        string PathDir = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\USER\\" + ClassLibraryWeiBao.ClassServerCOM.GetMasterPasswordBytes(m.FromUserName));
        if (System.IO.Directory.Exists(PathDir) == false)
        {   //建立用户目录
            System.IO.Directory.CreateDirectory(PathDir);
            string PathUser = System.IO.Path.Combine(PathDir, "USER_NAME.TXT");
            System.IO.File.WriteAllText(PathUser, m.FromUserName, System.Text.Encoding.UTF8);
        }
        //被关注
        if (m.MsgType == MessageType.Event && m.InnerToXmlText().IndexOf("subscribe") >= 0)
        {
            string AXNUMPath = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\sysuser\\usernum.txt");
            string AXNUM = System.IO.File.ReadAllText(AXNUMPath);
            int LLNUM = 500;
            try
            {
                LLNUM = Int32.Parse(AXNUM) + 1;// 147091;
                System.IO.File.WriteAllText(AXNUMPath, LLNUM.ToString());
            }
            catch
            {
            }
            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\WeiXinBasicConfigManagement.dll");
            String[] TXTSET = System.IO.File.ReadAllLines(PathFileOne, System.Text.Encoding.UTF8);

            // TXTSET[0]; 微信名称
            //TXTSET[1]; 微信号码
            //TXTSET[2]; 关注后回复的 字符串模板   格式： 欢迎关注【{0}】,您是我们第{1}关注者，输入 HELP 查看更多内容



            // 系统自动 寻找和匹配 start 关键字设置文件  如果找到 则自动返回
            if (true)
            {
                
                TypeMsg = 0;
                string UserID = m.FromUserName;
                string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
                RepMsgData myData = GetMySetDataG(context.Server.MapPath("~"), "start", host, ID_TIME);
                if (myData != null)
                {
                    string nn = myData.ToXmlText().ToLower();
                    if (TypeMsg == 1)
                    {
                        var r = m.GetNewsResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                    if (TypeMsg == 2)
                    {
                        var r = m.GetTextResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                    if (TypeMsg == 3)
                    {
                        var r = m.GetMusicResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                }

            }



            //当没有 start 图文回复关注的时候  自动 返回文本消息
            //发送关注返回数据
            var r2 = m.GetTextResponse();
            string result = string.Format(TXTSET[2], TXTSET[0], LLNUM);
            r2.Data = (TextMsgData)result;
            r2.Response();
            return;
        }

        //数据解析
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(m.ToXmlText());//"<xml><description><![CDATA[木子屋:http://www.mzwu.com/]]></description></xml>");

        //本地 地点  LBS
        if (m.MsgType == MessageType.Location)
        {

            string X = xmlDoc.SelectSingleNode("//Location_X").FirstChild.InnerText.ToLower().Trim();
            string Y = xmlDoc.SelectSingleNode("//Location_Y").FirstChild.InnerText.ToLower().Trim();

            string Scale = xmlDoc.SelectSingleNode("//Scale").FirstChild.InnerText.ToLower().Trim();

            long nX = (long )(double.Parse(X) * 100000 );
            long  nY = (long)(double.Parse(Y) * 100000);


            string NameX1000 = X.Replace(".","V") +"_"+Y.Replace(".","V");

            string NameX1001 = X.Replace(".", "V")+"0" + "_" + Y.Replace(".", "V");
            string NameX1002 = X.Replace(".", "V") + "0" + "_" + Y.Replace(".", "V")+"0";
            string NameX1003 = X.Replace(".", "V") + "_" + Y.Replace(".", "V") + "0";



            string NameX2 = nX.ToString() + "_" + nY.ToString();


            string PathFile00 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location1\\" + NameX1000 + ".dll"); //高精度地址    
            string PathFile01 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location1\\" + NameX1001 + ".dll"); //高精度地址    
            string PathFile02 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location1\\" + NameX1002 + ".dll"); //高精度地址    
            string PathFile03 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location1\\" + NameX1003 + ".dll"); //高精度地址    




            string PathFile2 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MyPost\\location2\\" + NameX2 + ".dll"); //模糊地址


            //精确地址匹配
            if (System.IO.File.Exists(PathFile00) == true)
            {
                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile00);

                for (int i = 0; i < CMsgData.Items.Count; i++)
                {
                    var XONE = CMsgData.Items[i];
                    XONE.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.PicUrl, host);
                    XONE.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.Url, host);
                    CMsgData.Items[i] = XONE;
                }
 

                var r = m.GetNewsResponse();
                r.Data = CMsgData;
                r.Response();
                return;
            }

            //精确地址匹配
            if (System.IO.File.Exists(PathFile01) == true)
            {
                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile01);
                for (int i = 0; i < CMsgData.Items.Count; i++)
                {
                    var XONE = CMsgData.Items[i];
                    XONE.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.PicUrl, host);
                    XONE.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.Url, host);
                    CMsgData.Items[i] = XONE;
                }
                var r = m.GetNewsResponse();
                r.Data = CMsgData;
                r.Response();
                return;
            }

            //精确地址匹配
            if (System.IO.File.Exists(PathFile02) == true)
            {
                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile02);
                for (int i = 0; i < CMsgData.Items.Count; i++)
                {
                    var XONE = CMsgData.Items[i];
                    XONE.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.PicUrl, host);
                    XONE.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.Url, host);
                    CMsgData.Items[i] = XONE;
                }
                var r = m.GetNewsResponse();
                r.Data = CMsgData;
                r.Response();
                return;
            }

            //精确地址匹配
            if (System.IO.File.Exists(PathFile03) == true)
            {
                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile03);
                for (int i = 0; i < CMsgData.Items.Count; i++)
                {
                    var XONE = CMsgData.Items[i];
                    XONE.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.PicUrl, host);
                    XONE.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.Url, host);
                    CMsgData.Items[i] = XONE;
                }
                var r = m.GetNewsResponse();
                r.Data = CMsgData;
                r.Response();
                return;
            }

            //模糊地址匹配
            if (System.IO.File.Exists(PathFile2) == true)
            {
                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile2);
                for (int i = 0; i < CMsgData.Items.Count; i++)
                {
                    var XONE = CMsgData.Items[i];
                    XONE.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.PicUrl, host);
                    XONE.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(XONE.Url, host);
                    CMsgData.Items[i] = XONE;
                }
                var r = m.GetNewsResponse();
                r.Data = CMsgData;
                r.Response();
                return;
            }

            //寻找地址匹配文件
            //GetX = GetLocationBox( X,Y,NameX  );
            //返回值
            //发送关注返回数据
            var r2 = m.GetTextResponse();
            string result = "您发送了位置信息 X:" + X + " Y:" + Y + " 缩放：" + Scale;
            r2.Data = (TextMsgData)result;
            r2.Response();
            return;
        
        }


        //菜单 或者 用户文本输入
        if (m.MsgType == MessageType.Text || (m.MsgType == MessageType.Event && m.InnerToXmlText().IndexOf("subscribe") < 0))
        {
            //读取
            string rr = "";

            if (m.MsgType == MessageType.Text)
            {
                rr = xmlDoc.SelectSingleNode("//Content").FirstChild.InnerText.ToLower().Trim();
            }
            else
            {
                rr = xmlDoc.SelectSingleNode("//EventKey").FirstChild.InnerText.ToLower().Trim();
            }

            //用户日志文件
            string Nsame = DateTime.Now.ToString().Replace(":", "_").Replace("-", "_").Replace("\\", "_").Replace("/", "_").Replace(" ", "_") + ".txt";
            string PathUserData = System.IO.Path.Combine(PathDir, Nsame);
            //记录用户输入到用户文件
            StreamWriter sws = new StreamWriter(PathUserData, true, System.Text.Encoding.UTF8);
            sws.WriteLine(rr.Replace("\n", " "));
            sws.Close();

            //首先判断转义  遇到转义直接替换
            string ZhuanYi = GetZhuanYi(context.Server.MapPath("~"), rr);
            if (ZhuanYi.Length > 0)
                rr = ZhuanYi;

            //微墙查询
            if (rr.ToLower() == "q"|| rr.ToLower() == "wq" )
            {
                string PathDirRSWQ = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\WEIQIANG\\");
                if (System.IO.Directory.Exists(PathDirRSWQ) == false)
                {
                    System.IO.Directory.CreateDirectory(PathDirRSWQ);
                }
                DateTime QDVVVV = DateTime.Now;
                string QAXNUMPathWQ = System.IO.Path.Combine(PathDirRSWQ, QDVVVV.Year + "_" + QDVVVV.Month.ToString("D2") + "_" + (QDVVVV.Day).ToString("D2") + "_WQ.txt");
                if (System.IO.File.Exists(QAXNUMPathWQ) == false)
                    System.IO.File.WriteAllText(QAXNUMPathWQ, DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + " " + "小萌: 今天，开始新的一天!\r\n");


                string UserID = m.FromUserName;  //用户　ID
                //使用时间戳加密 
                string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);

                var r = m.GetNewsResponse();
                r.Data = GetMySetDataGW(host, QAXNUMPathWQ, ID_TIME);
                r.Response();
                return;
            }

            //微墙输入
            if (rr.ToLower().IndexOf("q@") == 0 || rr.ToLower().IndexOf("墙@") == 0 || rr.ToLower().IndexOf("信息@") == 0 || rr.ToLower().IndexOf("微信墙@") == 0 || rr.ToLower().IndexOf("微信@") == 0 || rr.ToLower().IndexOf("微墙@") == 0 || rr.ToLower().IndexOf("wq@") == 0)
            {
                string PathDirRSWQ = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\WEIQIANG\\");
                DateTime QDVVVV = DateTime.Now;
                string QAXNUMPathWQ = System.IO.Path.Combine(PathDirRSWQ, QDVVVV.Year + "_" + QDVVVV.Month.ToString("D2") + "_" + (QDVVVV.Day).ToString("D2") + "_WQ.txt");
                string[] XWQ = rr.Split('@');
                if (XWQ[1].Replace("\r", "").Replace("\n", "").Length > 0)
                {
                    string DATAR = DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + " " + XWQ[1].Replace("\r", "").Replace("\n", "").Replace("  ", " ");
                    StreamWriter sws2 = new StreamWriter(QAXNUMPathWQ, true, System.Text.Encoding.UTF8);
                    sws2.WriteLine(DATAR);
                    sws2.Close();
                }
                var r = m.GetNewsResponse();
                //load read txt  show  9
                string UserID = m.FromUserName;  //用户　ID
                //使用时间戳加密 
                string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);

                r.Data = GetMySetDataGW(host, QAXNUMPathWQ, ID_TIME);
                r.Response();
                return;
            }


            if (rr == "@")   //用户签到
            {
                cmd_qiandao myQD = new cmd_qiandao();
                myQD.RID = m.FromUserName;
                //发送关注返回数据
                var r2 = m.GetTextResponse();
                r2.Data = (TextMsgData)myQD.GetDATA_ONE(); ;
                r2.Response();
                return;
            }


            if (rr.ToLower() == "ft") //照片墙
            {
                string PathDirRSWQ = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\PHOTO\\");
                var r = m.GetNewsResponse();
                string UserID = m.FromUserName;  //用户　ID
                //使用时间戳加密 
                string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
                r.Data = GetMySetDataFT(host, PathDirRSWQ, ID_TIME);
                r.Response();
                return;
            }

            // 积分
            if (rr.ToLower() == "jf")
            {
                cmd_jifen myJF = new cmd_jifen();
                myJF.RID = m.FromUserName;
                var r2 = m.GetTextResponse();
                r2.Data = (TextMsgData)myJF.GetDATA(); ;
                r2.Response();
                return;

            }


            ////me 我的应用  出现  我的积分 我的订单 优惠劵 私信 等等各项的信息内容
            //if (rr.ToLower() == "me")
            //{
            //    cmd_jifen myJF = new cmd_jifen();
            //    myJF.RID = m.FromUserName;
            //    var r2 = m.GetTextResponse();
            //    r2.Data = (TextMsgData)myJF.GetDATA(); ;
            //    r2.Response();
            //    return;

            //}



            // 购物  出现  出现  微商店中的 前 8个商品信息 用户直接点击即可购买 第二行显示我的订单状况
            if (rr.ToLower() == "gw")
            {
               
                //获得 订单数量  和 商品列表
                  //订单目录
                string PathDirSYS = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\DINGDAN\\");
                string RID = m.FromUserName; ;       
                string[] XXXX = System.IO.Directory.GetFiles(PathDirSYS, "*" + RID + "*");
                //订单数量

                string PathFile = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "USER_DIR\\SYSUSER\\Shangcheng\\goods.dll"); //图文 关键词回复目录)

                NewsMsgData CMsgData = new NewsMsgData();
                CMsgData.LoadFile(PathFile);
                int LL=CMsgData.Items.Count;


                    string UserID = m.FromUserName;  //用户　ID
            //使用时间戳加密 
                 string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);

                if(LL >9 )LL=9;

                NewsMsgData CMsgDataRT = new NewsMsgData();

                NewsItem titleItem = new NewsItem();
                titleItem.Title = "微商店 我的订单："+XXXX.Length.ToString()+"个 点击进入" ;
                titleItem.Description = "微商店 我的订单：" + XXXX.Length.ToString() + "个 点击进入";
                titleItem.Url = "http://" + (host + "/cmd/shangcheng.aspx?id=").Replace("//", "/").Replace("\\", "\\") + ID_TIME;

                CMsgDataRT.Items.Add(titleItem);

                for (int i = 0; i < LL; i++)
                {
                    CMsgData.Items[i].Url = titleItem.Url;
                    CMsgDataRT.Items.Add(CMsgData.Items[i]); 
                }

                var r = m.GetNewsResponse();
                r.Data = CMsgDataRT;
                r.Response();


            }


            

            // 优惠劵  出现我的优惠劵 信息
            if (rr.ToLower() == "yhj")
            {
                 
                    //var r = m.GetNewsResponse();
                    //string UserID = m.FromUserName;  //用户　ID
                    ////使用时间戳加密 
                    //string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
                   
                    //string Url2 = "http://" + (host +"").Replace("//", "/");
                    //string PicUrl2 = "http://" + (host +"").Replace("//", "/");
                    //r.Data = GetStartDataNewOne( "优惠劵说明", "优惠劵标题",  PicUrl2,   Url2);
                    //r.Response();
                    //return;
                rr = "优惠劵";

            }

            // 大转盘  出现大转盘
            if (rr.ToLower() == "dzp")
            {
                rr = "大转盘";
            }

            // 刮刮卡  出现刮刮卡
            if (rr.ToLower() == "ggk")
            {
                rr = "刮刮卡";
            }

            // 游戏频道  出现游戏
            if (rr.ToLower() == "yx")
            {
                rr = "游戏";
            }




            // 听歌  
            if (rr.ToLower() == "tg")
            {
                string PathDirMp3 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MP3");
                string PathDirMp32 = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\MP32");
                string[] ASONG = System.IO.Directory.GetFiles(PathDirMp3);
                Random nmn = new Random(Environment.TickCount);
                double nmn1 = nmn.NextDouble();
                int xx_int = (int)((double)ASONG.Length * nmn1);
                string URLMP3 = "";
                string URLMP3_TXT = "";
                if (ASONG.Length > 0)
                {
                    System.IO.FileInfo xxfile = new System.IO.FileInfo(ASONG[xx_int]);
                    URLMP3_TXT = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(xxfile);

                    string PathDirRS2zMp3URL = System.IO.Path.Combine(PathDirMp32, GetMasterPasswordBytes(xxfile.Name) + ".mp3");

                    if (System.IO.File.Exists(PathDirRS2zMp3URL) == false)
                    {
                        System.IO.File.Copy(ASONG[xx_int], PathDirRS2zMp3URL);
                    }

                    URLMP3 = "http://" + host + "USER_DIR/SYSUSER/MP32/" + GetMasterPasswordBytes(xxfile.Name) + ".mp3";// JD[0].Replace("/", "").Replace("\n", "").Replace("\\", "/");



                }
                //音乐响应！
                var rx = m.GetMusicResponse();
                rx.Data = new MusicMsgData
                {
                    Description = "输入TG可以换歌",
                    Title = "微信音乐台:\n" + URLMP3_TXT,//+ URLMP3,
                    MusicUrl = URLMP3,// @"http://news.iciba.com//admin//tts//2014-03-18.mp3",
                    HQMusicUrl = URLMP3//"http://www.0951uc.com/%E9%9D%92%E6%98%A5%E6%A0%A1%E5%9B%AD"
                };

                rx.Response();

                return;

            }


            //
            //音乐响应
            if (rr == "音乐测试")
            {
                var rx = m.GetMusicResponse();
                rx.Data = new MusicMsgData
                {
                    Description = "音乐描述",
                    Title = "音乐标题",
                    MusicUrl = "http://音乐url",
                    HQMusicUrl = "http://高品质url"
                };

                rx.Response();
                return;
            }

            if (true)
            {
                //查找匹配文件
                TypeMsg = 0;
                string UserID = m.FromUserName;
                string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
                RepMsgData myData = GetMySetDataG(context.Server.MapPath("~"), rr, host, ID_TIME);
                if (myData != null)
                {
                    string nn = myData.ToXmlText().ToLower();
                    if (TypeMsg == 1)
                    {
                        var r = m.GetNewsResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                    if (TypeMsg == 2)
                    {
                        var r = m.GetTextResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                    if (TypeMsg == 3)
                    {
                        var r = m.GetMusicResponse();
                        r.Data = myData;
                        r.Response();
                        return;
                    }

                }

            }






        } if (m.MsgType == MessageType.Image) // 用户上传了图片
        {
            //读取 并且保存用户数据 到用户文件夹
            string rrUrl = xmlDoc.SelectSingleNode("//PicUrl").FirstChild.InnerText;
            System.Net.WebClient web = new System.Net.WebClient();
            DateTime tv = DateTime.Now;
            string name = tv.Year + "_" + tv.Month.ToString("D2") + "_" + (tv.Day).ToString("D2") + "_" + (tv.Hour).ToString("D2");
            string name_full = "";  //微信照片墙 图片记录
            string my_name_full = ""; //用户自己的目录图片

            //判断扩展名
            string IMG_EXT = ".png";
            string NewURLTest = rrUrl.ToLower() + "Z";
            if (NewURLTest.IndexOf(".jpgZ") > 0)
                IMG_EXT = ".jpg";

            if (NewURLTest.IndexOf(".pngZ") > 0)
                IMG_EXT = ".png";

            if (NewURLTest.IndexOf(".gifZ") > 0)
                IMG_EXT = ".gif";

            if (NewURLTest.IndexOf(".bmpZ") > 0)
                IMG_EXT = ".bmp";

            for (int i = 0; i < 999; i++)
            {
                name_full = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\PHOTO\\" + name) + "_" + i.ToString("D3") + IMG_EXT;
              //  my_name_full = System.IO.Path.Combine(PathDir, "USER_DIR\\SYSUSER\\PHOTO\\" + name) + "_" + i.ToString("D3") + IMG_EXT;
                my_name_full = System.IO.Path.Combine(PathDir,   name) + "_" + i.ToString("D3") + IMG_EXT;
                if (System.IO.File.Exists(name_full) == false && System.IO.File.Exists(my_name_full) == false)
                    break;
            }

            //下载和复制
            try
            {
                web.DownloadFile(rrUrl, name_full);
                System.IO.File.Copy(name_full, my_name_full);
            }
            catch
            { }

            //返回微信墙
            string PathDirRSWQ = System.IO.Path.Combine(context.Server.MapPath("~"), "USER_DIR\\SYSUSER\\PHOTO\\");
            var r = m.GetNewsResponse();
            string UserID = m.FromUserName;  //用户　ID
            //使用时间戳加密 
            string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
            r.Data = GetMySetDataFT(host, PathDirRSWQ, ID_TIME);
            r.Response();
            return;
        }



        if (true)
        {
            //查找help 文件   系统 匹配不到任何数据时  自动返回
            TypeMsg = 0;
            string UserID = m.FromUserName;
            string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
            RepMsgData myData = GetMySetDataG(context.Server.MapPath("~"), "help", host, ID_TIME);
            if (myData != null)
            {
                string nn = myData.ToXmlText().ToLower();
                if (TypeMsg == 1)
                {
                    var r = m.GetNewsResponse();
                    r.Data = myData;
                    r.Response();
                    return;
                }

                if (TypeMsg == 2)
                {
                    var r = m.GetTextResponse();
                    r.Data = myData;
                    r.Response();
                    return;
                }

                if (TypeMsg == 3)
                {
                    var r = m.GetMusicResponse();
                    r.Data = myData;
                    r.Response();
                    return;
                }

            }

        }




        //用户默认输入 均返回 start里面的值
        {
            var r = m.GetNewsResponse();
            string UserID = m.FromUserName;  //用户　ID
            //使用时间戳加密 
            string ID_TIME = ClassLibraryWeiBao.ClassTimeEncryptionAlgorithm.GetTimeID(context.Server.MapPath("~"), UserID);
            //string host = context.Request.ServerVariables["HTTP_HOST"] + context.Request.ServerVariables["PATH_INFO"];
            r.Data = GetStartData2(context.Server.MapPath("~"), host, ID_TIME);  //  GetMySetData(fff, URLX);

            r.Response();
            return;
        }


    }

    /// <summary>
    /// 识别转义 没有的时候 返回 空
    /// </summary>
    /// <param name="SysPath"></param>
    /// <param name="KeyWord"></param>
    /// <returns></returns>
    public string GetZhuanYi(string SysPath, string KeyWord)
    {

        string NP_ZHUAN = System.IO.Path.Combine(SysPath, "USER_DIR/SYSUSER/MyPost/ZHUAN/" + KeyWord + ".dll");
        if (System.IO.File.Exists(NP_ZHUAN))
        {
            ZhuanMsgData C = new ZhuanMsgData();
            C.LoadFile(NP_ZHUAN);
            return C.Content.Trim();
        }

        return "";

    }

    /// <summary>
    /// 消息类型  1 图文 2文本 3音乐
    /// </summary>
    public static int TypeMsg = 0;


    /// <summary>
    /// 从 3个 系统关键词路径中寻找关键词匹配
    /// </summary>
    /// <param name="SysPath">系统路径</param>
    /// <param name="KeyWord">关键字</param>
    /// <param name="host">url基地址</param>
    /// <param name="timestr"> 时间戳</param>
    /// <returns></returns>
    public static RepMsgData GetMySetDataG(string SysPath, string KeyWord, string host , string timestr)
    {

        string NP_IMG = System.IO.Path.Combine(SysPath, "USER_DIR\\SYSUSER\\MyPost\\IMG\\" + KeyWord + ".dll");
        string NP_TXT = System.IO.Path.Combine(SysPath, "USER_DIR\\SYSUSER\\MyPost\\TXT\\" + KeyWord + ".dll");
        string NP_VOC = System.IO.Path.Combine(SysPath, "USER_DIR\\SYSUSER\\MyPost\\VOC\\" + KeyWord + ".dll");


        if (System.IO.File.Exists(NP_IMG))
        {
            TypeMsg = 1;
            NewsMsgData C = new NewsMsgData();

            C.LoadFile(NP_IMG);

            if (C.Items.Count == 1)
            {

                var X = C.Items[0];
                X.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(X.PicUrl, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);

                if (X.Url.Trim() == "")
                {
                    //生成一个指向 本关键词中设置的url
                    string URL = "cmd/tuwen.aspx?w=" + KeyWord + "&t=" + X.Title.Trim();

                    X.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(URL, host);
                }
                else
                {
                    X.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(X.Url, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);
                }

                X.Description = ClassLibraryWeiBao.ClassWeiWeiXin.NoHTML(X.Description);


            }
            else
            {
                for (int i = 0; i < C.Items.Count; i++)
                {
                    var X = C.Items[i];
                    X.PicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(X.PicUrl, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);

                    if (X.Url.Trim() == "")
                    {
                        //生成一个指向 本关键词中设置的url
                        string URL = "cmd/tuwen.aspx?w=" + KeyWord + "&t=" + X.Title.Trim();

                        X.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(URL, host);
                    }
                    else
                    {
                        X.Url = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(X.Url, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);
                    }
                    X.Description = "";
                }
            }

            return C;
        }


        if (System.IO.File.Exists(NP_TXT))
        {
            TypeMsg = 2;
            TextMsgData C = new TextMsgData();
            C.LoadFile(NP_TXT);

            return C;
        }

        if (System.IO.File.Exists(NP_VOC))
        {
            TypeMsg = 3;
            MusicMsgData C = new MusicMsgData();
            C.LoadFile(NP_VOC);

            C.HQMusicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(C.HQMusicUrl, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);
            C.MusicUrl = ClassLibraryWeiBao.ClassWeiWeiXin.GetUrlPath(C.MusicUrl, host).Replace("<%ID%>", timestr).Replace("<%id%>", timestr);

            return C;
        }

        // TextMsgData XC = new TextMsgData();
        //XC.Content = "请输入正确关键字";
        return null;

    }





    /// <summary>
    /// 将Unicode编码转换为汉字字符串
    /// </summary>
    /// <param name="str">Unicode编码字符串</param>
    /// <returns>汉字字符串</returns>
    public static string ToGB2312(string str)
    {
        string r = "";
        MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        byte[] bts = new byte[2];
        foreach (Match m in mc)
        {
            bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
            bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
            r += System.Text.Encoding.Unicode.GetString(bts);
        }
        return r;
    }



    /// <summary>
    /// 读取数据　    URLX为确定的 
    ///  1 内容
    ///  2 标题
    ///  3图
    ///  4 url
    /// 
    /// 
    /// </summary>
    /// <param name="PathFile"></param>
    /// <returns></returns>
    public static NewsMsgData GetMySetData(string PathFile, string UrlX)
    {

        string[] myData = System.IO.File.ReadAllLines(PathFile, System.Text.Encoding.UTF8);




        NewsMsgData C = new NewsMsgData();


        List<NewsItem> Items = new List<NewsItem>();




        //响应3条新闻信息

        for (int i = 0; i < myData.Length; i += 4)
        {
            NewsItem Xone = new NewsItem
            {
                Description = myData[i], // "new1",
                Title = myData[i + 1],// "EN了",
                PicUrl = myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                Url = UrlX// "http://baidu.com"
            };

            Items.Add(Xone);

        }

        C.Items = Items;

        return C;

    }

    /// <summary>
    /// 读取数据　  
    ///  1 内容
    ///  2 标题
    ///  3图
    ///  4 url
    /// 
    /// 
    /// </summary>
    /// <param name="PathFile"></param>
    /// <returns></returns>
    public static NewsMsgData GetMySetData(string PathFile)
    {

        string[] myData = System.IO.File.ReadAllLines(PathFile, System.Text.Encoding.UTF8);




        NewsMsgData C = new NewsMsgData();


        List<NewsItem> Items = new List<NewsItem>();




        //响应3条新闻信息

        for (int i = 0; i < myData.Length; i += 4)
        {
            NewsItem Xone = new NewsItem
             {
                 Description = myData[i], // "new1",
                 Title = myData[i + 1],// "EN了",
                 PicUrl = myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                 Url = myData[i + 3]// "http://baidu.com"
             };

            Items.Add(Xone);

        }

        C.Items = Items;

        return C;

    }

    /// <summary>
    /// 照片墙
    /// </summary>
    /// <param name="PathFile"></param>
    /// <param name="host">当前url地址 </param>
    /// <returns></returns>
    public static NewsMsgData GetMySetDataFT(string host, string PathFile, string ID_TIME)
    {

        string url2 = "http://" + host + "Web.aspx?id=" + ID_TIME;

        string[] myData = System.IO.Directory.GetFiles(PathFile);


        int st = 0;
        int end = 0;

        if (myData.Length > 9)
        {
            st = myData.Length;
            end = myData.Length - 9;

        }
        else
        {
            st = myData.Length;
            end = 0;

        }

        NewsMsgData C = new NewsMsgData();
        List<NewsItem> Items = new List<NewsItem>();

        NewsItem XoneX = new NewsItem
        {
            Description = "微信照片墙【发送照片到订阅号】", // "new1",
            Title = "微信照片墙【发送照片到订阅号】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = url2// myData[i + 3]// "http://baidu.com"
        };

        Items.Add(XoneX);
        for (int i = st - 1; i >= end; i--)
        {
            string MD = myData[i];

            System.IO.FileInfo xx = new System.IO.FileInfo(MD);
            String Name = ClassLibraryWeiBao.ClassWeiWeiXin.GetFileName(MD);
            string URLX = "http://" + host + "user_dir/sysuser/photo/" + xx.Name;

            NewsItem Xone = new NewsItem
            {
                Description = "照片:" + Name, // "new1",
                Title = "照片:" + Name,// "EN了",
                PicUrl = URLX,//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                Url = "http://" + host + "ft.ashx?img=" + xx.Name + "&id=" + ID_TIME // myData[i + 3]// "http://baidu.com"
            };

            Items.Add(Xone);
            if (Items.Count >= 9)
                break;

        }

        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信照片墙 ", // "new1",
            Title = "点击进入微网站",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = url2   // "http://" + host + "/Web.aspx?id=" + ID_TIME// myData[i + 3]// "http://baidu.com"
        };
        Items.Add(XoneX2);

        C.Items = Items;

        return C;

    }


    /// <summary>
    /// 读取数据　  qiang   
    ///  1 
    ///  2 标题
    ///  3
    ///  4 
    /// 
    /// 
    /// </summary>
    /// <param name="PathFile"></param>
    /// <returns></returns>
    public static NewsMsgData GetMySetDataGW(string host, string PathFile ,string id)
    {
        string url2 = "http://" + host + "shenghuo.aspx?id=" + id;


        string[] myData = System.IO.File.ReadAllLines(PathFile, System.Text.Encoding.UTF8);




        NewsMsgData C = new NewsMsgData();


        List<NewsItem> Items = new List<NewsItem>();

        NewsItem XoneX = new NewsItem
        {
            Description = "微信微信墙 - 【微墙@昵称:内容】", // "new1",
            Title = "微信微信墙 - 【微墙@昵称:内容】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url =url2//  "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };

        Items.Add(XoneX);


        //响应3条新闻信息

        for (int i = myData.Length - 1; i >= 0; i--)
        {

            string MD = myData[i];
            if (MD.Trim().Length > 0)
            {
                if (MD.Length >= 22)
                    MD = MD.Substring(0, 22);

                NewsItem Xone = new NewsItem
                {
                    Description = MD, // "new1",
                    Title = MD,// "EN了",
                    PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                    Url =url2// "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
                };

                Items.Add(Xone);
                if (Items.Count >= 9)
                    break;
            }
        }

        /*
        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信微信墙【微墙@昵称:内容】", // "new1",
            Title = "发布请输入【微墙@昵称:内容】查看【微墙】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = ""// myData[i + 3]// "http://baidu.com"
        };
        */
        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信微信墙【微墙@昵称:内容】", // "new1",
            Title = "点击查看更多..",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url =url2// "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };
        Items.Add(XoneX2);

        C.Items = Items;

        return C;

    }


    public static NewsMsgData GetMySetDataGW2(string PathFile)
    {

        string[] myData = System.IO.File.ReadAllLines(PathFile, System.Text.Encoding.UTF8);




        NewsMsgData C = new NewsMsgData();


        List<NewsItem> Items = new List<NewsItem>();

        NewsItem XoneX = new NewsItem
        {
            Description = "微信表白墙 - 【表白@昵称:内容】", // "new1",
            Title = "微信表白墙 - 【表白@昵称:内容】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };

        Items.Add(XoneX);


        //响应3条新闻信息

        for (int i = myData.Length - 1; i >= 0; i--)
        {

            string MD = myData[i];
            if (MD.Trim().Length > 0)
            {
                if (MD.Length >= 22)
                    MD = MD.Substring(0, 22);

                NewsItem Xone = new NewsItem
                {
                    Description = MD, // "new1",
                    Title = MD,// "EN了",
                    PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                    Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
                };

                Items.Add(Xone);
                if (Items.Count >= 9)
                    break;
            }
        }

        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信微信墙【微墙@昵称:内容】", // "new1",
            Title = "点击查看更多..",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };
        /*
        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信微信墙【微墙@昵称:内容】", // "new1",
            Title = "发布请输入【微墙@昵称:内容】查看【微墙】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = ""// myData[i + 3]// "http://baidu.com"
        };
        */

        Items.Add(XoneX2);

        C.Items = Items;

        return C;

    }

    public static NewsMsgData GetMySetDataGW3(string PathFile)
    {

        string[] myData = System.IO.File.ReadAllLines(PathFile, System.Text.Encoding.UTF8);




        NewsMsgData C = new NewsMsgData();


        List<NewsItem> Items = new List<NewsItem>();

        NewsItem XoneX = new NewsItem
        {
            Description = "微信吐槽墙 - 【吐槽@昵称:内容】", // "new1",
            Title = "微信吐槽墙 - 【吐槽@昵称:内容】",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };

        Items.Add(XoneX);


        //响应3条新闻信息

        for (int i = myData.Length - 1; i >= 0; i--)
        {

            string MD = myData[i];
            if (MD.Trim().Length > 0)
            {
                if (MD.Length >= 22)
                    MD = MD.Substring(0, 22);

                NewsItem Xone = new NewsItem
                {
                    Description = MD, // "new1",
                    Title = MD,// "EN了",
                    PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
                    Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
                };

                Items.Add(Xone);
                if (Items.Count >= 9)
                    break;
            }
        }


        NewsItem XoneX2 = new NewsItem
        {
            Description = "微信微信墙【微墙@昵称:内容】", // "new1",
            Title = "点击查看更多..",// "EN了",
            PicUrl = "",//myData[i + 2],// "http://c.hiphotos.baidu.com/ting/pic/item/b8014a90f603738d538032bfb21bb051f919ec61.jpg",
            Url = "http://www.0951uc.com/user_dir/tupdate.ashx"// myData[i + 3]// "http://baidu.com"
        };


        Items.Add(XoneX2);

        C.Items = Items;

        return C;

    }


    /// <summary>
    /// 获取 Start数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static NewsMsgData GetStartData2(string apppath, string host, string id)
    {

        //host = host.Replace("v.ashx", "");
        ;// "http://" + host + "user_dir/sysuser/img/start.jpg";

        string url2 = "http://" + host + "Web.aspx?id=" + id;

        //标题
        string PathFileT6 = System.IO.Path.Combine(apppath, "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T6.dll");
        string TextBox6_text = System.IO.File.ReadAllText(PathFileT6, System.Text.Encoding.UTF8);

        //内容
        string PathFileT7 = System.IO.Path.Combine(apppath, "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T7.dll");
        string TextBox7_Text = System.IO.File.ReadAllText(PathFileT7, System.Text.Encoding.UTF8);


        string PathFileT8 = System.IO.Path.Combine(apppath, "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01T8.dll");
        string TextBox8_Text = System.IO.File.ReadAllText(PathFileT8, System.Text.Encoding.UTF8);

        string url1 = "http://" + (host + TextBox8_Text).Replace("//", "/");

        //微社区入口

        NewsMsgData C = new NewsMsgData
        {

            Items = new List<NewsItem>
        {
            new NewsItem
            {
                Description = TextBox7_Text,//" Start，这是一个极速用户交互程序来帮助您在微信学习、社交和生活，点击进入",
                Title =TextBox6_text,// " Start应用服务",
                PicUrl =url1,
                Url = url2
            }
        }
        };

        return C;

    }



    /// <summary>
    /// 获取 单图文消息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static NewsMsgData GetStartDataNewOne(string Description2, string Title2, string PicUrl2, string Url2)
    {

       
        
        //微社区入口

        NewsMsgData C = new NewsMsgData
        {

            Items = new List<NewsItem>
        {
            new NewsItem
            {
                Description = Description2,//" Start，这是一个极速用户交互程序来帮助您在微信学习、社交和生活，点击进入",
                Title =Title2,// " Start应用服务",
                PicUrl =PicUrl2,
                Url = Url2
            }
        }
        };

        return C;

    }


    /// <summary>
    /// 获得 文件名称
    /// </summary>
    /// <param name="dat"></param>
    /// <returns></returns>
    public static string GetMasterPasswordBytes(string dat)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        byte[] aaa = md5.ComputeHash(System.Text.Encoding.GetEncoding("GB2312").GetBytes(dat));

        string XXS = "";
        for (int i = 0; i < aaa.Length; i++)
        {
            XXS += aaa[i];
        }

        byte[] aaa2 = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(XXS));

        string XXS2 = "";
        for (int i = 0; i < aaa2.Length; i++)
        {
            XXS2 += aaa2[i];
        }


        return XXS2;
    }

    /// <summary>
    /// FILE DAY PATH
    /// </summary>
    /// <param name="PathxD"></param>
    /// <returns></returns>
    public string GetTxtFileName(string PathxD)
    {
        DateTime VVVV = DateTime.Now;
        string Pathx = System.IO.Path.Combine(PathxD, VVVV.Year + "_" + VVVV.Month.ToString("D2") + "_" + VVVV.Day.ToString("D2") + ".txt");

        return Pathx;
    }











}



