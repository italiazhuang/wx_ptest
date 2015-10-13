using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WeiWeixiN.Public.Message
{
    /// <summary>
    /// （响应）文本消息数据。
    /// 实际就是一个字符串
    /// </summary>
    public class TextMsgData : RepMsgData
    {
        public override string ToXmlText()
        {
            return MessageHelper.ToXmlText(this);
        }

        [Output]
        public string Content { get; set; }


        public static implicit operator TextMsgData(string s)
        {
            var ret = new TextMsgData
            {
                Content = s
            };
            return ret;
        }


        /// <summary>
        /// 从 文件 读取 数据 变成 结构体
        /// </summary>
        /// <param name="path"></param>
        public bool LoadFile(string pathx)
        {
            string Data = System.IO.File.ReadAllText(pathx, System.Text.Encoding.UTF8);

            return LoadSet(Data);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pathx"></param>
        public void SaveFile(string pathx)
        {

            /*
              <?xml version="1.0" encoding="utf-8"?>
                <weiweixinnet>
                    <TextMsgData>
                      <Text>2</Text>
                    </TextMsgData> 
                </weiweixinnet>
             */

            string SaveData = Getdata();

            System.IO.File.WriteAllText(pathx, SaveData, System.Text.Encoding.UTF8);


        }

        public string Getdata()
        {

            string SaveData = "";
            SaveData += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            SaveData += "<weiweixinnet>\r\n";
            SaveData += "  <TextMsgData>\r\n";

            if (Content != "")
                SaveData += "    <Text><![CDATA[" + Content + "]]></Text>\r\n";
            else
                SaveData += "    <Text></Text>\r\n";

            SaveData += "  </TextMsgData> \r\n";
            SaveData += "</weiweixinnet>\r\n";

            return SaveData;
        }

        /// <summary>
        ///  从字符串读取 结构体
        /// </summary>
        /// <param name="dat"></param>
        public bool LoadSet(string dat)
        {
            //解析

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(dat);
                XmlNodeList xnList = xmlDoc.SelectNodes("//TextMsgData");
                foreach (XmlNode xn in xnList)
                {
                    Content = (xn.SelectSingleNode("Text")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    return true;
                }
            }
            catch
            {
                return false;
            }



            return false;
        }


    }


    /// <summary>
    /// 转义 关键字
    /// </summary>
    public class ZhuanMsgData
    {


        /// <summary>
        /// 转义后的关键字
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 从 文件 读取 数据 变成 结构体
        /// </summary>
        /// <param name="path"></param>
        public bool LoadFile(string pathx)
        {
            string Data = System.IO.File.ReadAllText(pathx, System.Text.Encoding.UTF8);

            return LoadSet(Data);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pathx"></param>
        public void SaveFile(string pathx)
        {

            /*
              <?xml version="1.0" encoding="utf-8"?>
                <weiweixinnet>
                    <TextMsgData>
                      <Text>2</Text>
                    </TextMsgData> 
                </weiweixinnet>
             */

            string SaveData = Getdata();

            System.IO.File.WriteAllText(pathx, SaveData, System.Text.Encoding.UTF8);


        }

        public string Getdata()
        {

            string SaveData = "";
            SaveData += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";

            if (Content != "")
                SaveData += "  <ZhuanMsgData> <![CDATA[" + Content + "]]></ZhuanMsgData> \r\n";
            else
                SaveData += "  <ZhuanMsgData></ZhuanMsgData> \r\n";


            return SaveData;
        }

        /// <summary>
        ///  从字符串读取 结构体
        /// </summary>
        /// <param name="dat"></param>
        public bool LoadSet(string dat)
        {
            //解析

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(dat);
                XmlNode xn = xmlDoc.SelectSingleNode("//ZhuanMsgData");

                Content = xn.InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");

            }
            catch
            {
                return false;
            }



            return false;
        }


    }


    /// <summary>
    /// （响应）音乐消息数据
    /// </summary>
    public class MusicMsgData : RepMsgData
    {
        public const string NodeName = "Music";
        public override string ToXmlText()
        {
            var temp = MessageHelper.ToXmlText(this);
            return string.Format("<{0}>\n{1}\n</{0}>", NodeName, temp);
        }

        [Output]
        public string Title { get; set; }

        [Output]
        public string Description { get; set; }

        [Output]
        public string MusicUrl { get; set; }

        [Output]
        public string HQMusicUrl { get; set; }

        /// <summary>
        /// 从 文件 读取 数据 变成 结构体
        /// </summary>
        /// <param name="path"></param>
        public void LoadFile(string pathx)
        {
            string Data = System.IO.File.ReadAllText(pathx, System.Text.Encoding.UTF8);

            LoadSet(Data);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pathx"></param>
        public void SaveFile(string pathx)
        {

            /*
              <?xml version="1.0" encoding="utf-8"?>
                <weiweixinnet>
                    <TextMsgData>
                      <Text>2</Text>
                    </TextMsgData> 
                </weiweixinnet>
             */
            string SaveData = Getdata();


            System.IO.File.WriteAllText(pathx, SaveData, System.Text.Encoding.UTF8);


        }

        public string Getdata()
        {
            string SaveData = "";
            SaveData += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            SaveData += "<weiweixinnet>\r\n";
            SaveData += "   <MusicMsgData>\r\n";

            if (Title != "")
                SaveData += "      <Title><![CDATA[" + Title + "]]></Title>\r\n";
            else
                SaveData += "      <Title></Title>\r\n";

            if (Description != "")
                SaveData += "      <Description><![CDATA[" + Description + "]]></Description>\r\n";
            else
                SaveData += "      <Description></Description>\r\n";

            if (MusicUrl != "")
                SaveData += "      <MusicUrl><![CDATA[" + MusicUrl + "]]></MusicUrl>\r\n";
            else
                SaveData += "      <MusicUrl></MusicUrl>\r\n";

            if (HQMusicUrl != "")
                SaveData += "      <HQMusicUrl><![CDATA[" + HQMusicUrl + "]]></HQMusicUrl>\r\n";
            else
                SaveData += "      <HQMusicUrl></HQMusicUrl>\r\n";


            SaveData += "   </MusicMsgData> \r\n";
            SaveData += "</weiweixinnet>\r\n";

            return SaveData;

        }


        /// <summary>
        ///  从字符串读取 结构体
        /// </summary>
        /// <param name="dat"></param>
        public bool LoadSet(string dat)
        {
            //解析

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(dat);
                XmlNodeList xnList = xmlDoc.SelectNodes("//MusicMsgData");
                foreach (XmlNode xn in xnList)
                {
                    Title = (xn.SelectSingleNode("Title")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    Description = (xn.SelectSingleNode("Description")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    MusicUrl = (xn.SelectSingleNode("MusicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    HQMusicUrl = (xn.SelectSingleNode("HQMusicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    return true;
                }
            }
            catch
            {
                return false;
            }



            return false;
        }


    }

    /// <summary>
    /// （响应）图文消息数据
    /// </summary>
    public class NewsMsgData : RepMsgData
    {
        public NewsMsgData()
        {
            Items = new List<NewsItem>();
        }

        public const string NodeName = "Articles";

        /// <summary>
        /// 具体条目列表。
        /// 相当于每一个条目就是条新闻
        /// </summary>
        public List<NewsItem> Items { get; set; }

        public int ArticleCount { get { return Items.Count; } }

        public override string ToXmlText()
        {
            var temp = new StringBuilder();
            foreach (var item in Items)
            {
                temp.AppendLine(item.ToXmlText());
            }
            var ret = string.Format("<{0}>\n{1}</{0}>", NodeName, temp);
            ret = string.Format("<ArticleCount>{0}</ArticleCount>\n{1}", ArticleCount, ret);
            return ret;
        }

        /// <summary>
        /// 从 文件 读取 数据 变成 结构体
        /// </summary>
        /// <param name="path"></param>
        public void LoadFile(string pathx)
        {
            try
            {

                string Data = System.IO.File.ReadAllText(pathx, System.Text.Encoding.UTF8);

                LoadSet(Data);
            }
            catch
            { }
        }


        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pathx"></param>
        public void SaveFile(string pathx)
        {

            /*
              <?xml version="1.0" encoding="utf-8"?>
                <weiweixinnet>
                    <TextMsgData>
                      <Text>2</Text>
                    </TextMsgData> 
                </weiweixinnet>
             */

            string SaveData = Getdata();

            System.IO.File.WriteAllText(pathx, SaveData, System.Text.Encoding.UTF8);


        }

        public string Getdata()
        {
            string SaveData = "";
            SaveData += "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            SaveData += "<weiweixinnet>\r\n";

            foreach (NewsItem item in Items)
            {
                SaveData += " <NewsMsgData>\r\n";

                if (item.Title != "")
                    SaveData += "     <Title><![CDATA[" + item.Title + "]]></Title>\r\n";
                else
                    SaveData += "     <Title></Title>\r\n";

                if (item.Description != "")
                    SaveData += "     <Description><![CDATA[" + item.Description + "]]></Description>\r\n";
                else
                    SaveData += "     <Description></Description>\r\n";

                if (item.PicUrl != "")
                    SaveData += "     <PicUrl><![CDATA[" + item.PicUrl + "]]></PicUrl>\r\n";
                else
                    SaveData += "     <PicUrl></PicUrl>\r\n";


                if (item.Url != "")
                    SaveData += "     <Url><![CDATA[" + item.Url + "]]></Url>\r\n";
                else
                    SaveData += "     <Url></Url>\r\n";


                SaveData += " </NewsMsgData> \r\n";
            }

            SaveData += "</weiweixinnet>\r\n";

            return SaveData;

        }


        /// <summary>
        ///  从字符串读取 结构体
        /// </summary>
        /// <param name="dat"></param>
        public bool LoadSet(string dat)
        {
            Items.Clear();
            //解析

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(dat);
                XmlNodeList xnList = xmlDoc.SelectNodes("//NewsMsgData");
                foreach (XmlNode xn in xnList)
                {
                    NewsItem item = new NewsItem();
                    item.Title = (xn.SelectSingleNode("Title")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                    item.Description = (xn.SelectSingleNode("Description")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");

                    item.PicUrl = (xn.SelectSingleNode("PicUrl")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");


                    item.Url = (xn.SelectSingleNode("Url")).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");

                    Items.Add(item);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }


    }

    public class NewsItem
    {
        public const string NodeName = "item";

        [Output]
        public string Title { get; set; }

        [Output]
        public string Description { get; set; }

        [Output]
        public string PicUrl { get; set; }

        [Output]
        public string Url { get; set; }

        public string ToXmlText()
        {
            var temp = MessageHelper.ToXmlText(this);
            return string.Format("<{0}>\n{1}\n</{0}>", NodeName, temp);
        }

        public override string ToString()
        {
            return ToXmlText();
        }

        /// <summary>
        /// 字符串化
        /// </summary>
        /// <returns></returns>
        public string ToStr()
        {
            return GTxt(Title) + "\n" + GTxt(Description) + "\n" + GTxt(PicUrl) + "\n" + GTxt(Url);
        }


        /// <summary>
        /// 将字符串 转换为 对象
        /// </summary>
        /// <param name="dat"></param>
        public void ToItem(string dat)
        {
            string[] s = dat.Split('\n');

            Title = s[0];
            Description = s[1];
            PicUrl = s[2];
            Url = s[3];
        }

        /// <summary>
        /// 清理 字符串
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public string GTxt(string dat)
        {
            return dat.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ");
        }


    }

}

/*
 
 <?xml version="1.0" encoding="utf-8"?>
<Workflow>
  <Activity>
    <ActivityId>1</ActivityId>
    <ActivityName>start</ActivityName>
    <BindingPageId>1</BindingPageId>
    <BindingRoleId>1</BindingRoleId>
    <ActivityLevel>1</ActivityLevel>
  </Activity>
  <Activity>
    <ActivityId>2</ActivityId>
    <ActivityName>pass</ActivityName>
    <BindingPageId>2</BindingPageId>
    <BindingRoleId>2</BindingRoleId>
    <ActivityLevel>2</ActivityLevel>
  </Activity>
</Workflow>
 
 */