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

using WeiWeixiN.Public.Common;
using WeiWeixiN.Public.Message;

namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 微网站 图文管理
    /// </summary>
    public partial class MainNews : System.Web.UI.Page
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



             string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\NEWS\\news.dll"); //图文 关键词回复目录);    

            TreeView1.Nodes.Clear();

            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadFile(PathFile);

            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                TreeView1.Nodes.Add(new TreeNode(CMsgData.Items[i].Title));
            }

            WeTextBoxOne.Text = CMsgData.Getdata();

            TextBoxTitle.Text = "";
            txt0.Text = "";
            TextBoxUrl.Text = "";
            TextBoxEDIT.Text = "";
            Label2.Text = "";
 
 



        }

    

        protected void ButtonThree_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {

        }




        protected void ButtonFive_Click(object sender, EventArgs e)
        {


        }



        protected void ButtonTwo_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonTen_Click(object sender, EventArgs e)
        {

            WeTextBoxOne.Text = GetXML_MODEL(1);
        }

        /// <summary>
        /// 模板
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public string GetXML_MODEL(int N)
        {

            NewsMsgData CMsgData = new NewsMsgData();
            for (int i = 0; i < N; i++)
            {
                NewsItem cN = new NewsItem();
                cN.Title = "项目 " + i.ToString() + " 标题";
                cN.Description = "项目 " + i.ToString() + " 具体内容描述";
                cN.PicUrl = "http://xxxx.com/img/a.jpg ";
                cN.Url = "http://xxxx.com/img/a.aspx";

                CMsgData.Items.Add(cN);
            }
            return CMsgData.Getdata();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(2);
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(3);
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(4);
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(5);
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(6);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(7);
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(8);
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(9);
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            WeTextBoxOne.Text = GetXML_MODEL(10);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Button20_Click(object sender, EventArgs e)
        //{
        //    WeTextBoxFive.Text = DropDownList2.Text;

        //    string PathDir02 = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\MyPost\\IMG\\" + DropDownList2.Text + ".dll"); //图文 关键词回复目录);    

        //    WeTextBoxOne.Text = System.IO.File.ReadAllText(PathDir02, System.Text.Encoding.UTF8);

        //    Label1.Text = "读取成功：" + DateTime.Now.ToShortTimeString();

        //}

        protected void txt0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {

        }

  

        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {
            Label2.Text = TreeView1.SelectedNode.Text;

            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadSet(WeTextBoxOne.Text);

            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                if (CMsgData.Items[i].Title == Label2.Text)
                {
                    TextBoxTitle.Text = CMsgData.Items[i].Title;
                    txt0.Text = CMsgData.Items[i].PicUrl;
                    TextBoxUrl.Text = CMsgData.Items[i].Url;

                    string DataHTML = "";

                    try
                    {
                        //读取文件
                        string PathFile = System.IO.Path.Combine(Server.MapPath("~"),"USER_DIR\\SYSUSER\\NEWS\\"+  CMsgData.Items[i].Url);
                      DataHTML=  System.IO.File.ReadAllText(PathFile, System.Text.Encoding.UTF8);


                    }
                    catch
                    { }

                    TextBoxEDIT.Text = DataHTML;// CMsgData.Items[i].Description;

                    break;
                }


            }
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            Label2.Text = TreeView1.SelectedNode.Text;

        }

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {

        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TreeView1.Nodes.Count; i++)
            {
                if (TreeView1.Nodes[i].Text == Label2.Text)
                {
                    TreeView1.Nodes.RemoveAt(i);
                    break;
                }

            }

               TextBoxTitle.Text ="";
                    txt0.Text ="";
                    TextBoxUrl.Text ="";
                    TextBoxEDIT.Text = "";
                    Label2.Text = "";

        }


        /// <summary>  
        /// 生成随机字符串  
        /// </summary>  
        private class RandomStringGenerator
        {
            static readonly Random r = new Random();
            const string _chars = "0123456789";
            public static string GetRandomString()
            {
                char[] buffer = new char[5];
                for (int i = 0; i < 5; i++)
                {
                    buffer[i] = _chars[r.Next(_chars.Length)];
                }
                return new string(buffer);
            }
        }


        protected void Button23_Click(object sender, EventArgs e)
        {

            


            for (int j = 0; j < 10000; j++)
            {
                string Name = "新图文消息" + j.ToString("D2");
                bool IsOK=true ;

                string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\NEWS\\page"+j.ToString()+".htm" );

                if (System.IO.File.Exists(PathFile) == true)
                {
                    IsOK = false;
                }
                else
                {
                    for (int i = 0; i < TreeView1.Nodes.Count; i++)
                    {
                        //节点名称  已经存在 或者 文件名已经存在
                        if (TreeView1.Nodes[i].Text == Name)
                        {
                            IsOK = false; break;
                        }
                    }
                }

                if (IsOK == true)
                {
                    string filename ="page"+   j.ToString() + ".htm";  //自动生产一个文件名

                    TreeView1.Nodes.Add(new TreeNode(Name));

                    Label2.Text = Name;

                    TextBoxTitle.Text =Name;
                    txt0.Text ="";
                    TextBoxUrl.Text = filename; 
                    TextBoxEDIT.Text = "内容描述";

                    NewsItem myItem = new NewsItem();
                    myItem.Title = Name;
                    myItem.PicUrl ="";
                    myItem.Url = filename;
                    myItem.Description = "内容描述";

                    NewsMsgData CMsgData = new NewsMsgData();
                    CMsgData.LoadSet(WeTextBoxOne.Text);

                    CMsgData.Items.Add(myItem);
                    WeTextBoxOne.Text = CMsgData.Getdata();


                    return;
                }

            }
   
        }


        protected void Button21_Click(object sender, EventArgs e)
        {
            if (Label2.Text == "")
                return;

            NewsItem myItem = new NewsItem();
             myItem.Title =  TextBoxTitle.Text ;
             myItem.PicUrl= txt0.Text  ;
             myItem.Url=TextBoxUrl.Text  ;

             string PathFile = System.IO.Path.Combine(Server.MapPath("~"),"USER_DIR\\SYSUSER\\NEWS\\"+ myItem.Url);
             System.IO.File.WriteAllText(PathFile, TextBoxEDIT.Text, System.Text.Encoding.UTF8);

             myItem.Description = "";// 



            NewsMsgData CMsgData = new NewsMsgData();
            CMsgData.LoadSet(WeTextBoxOne.Text);


            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                
                if (CMsgData.Items[i].Title == Label2.Text)
                {
                    CMsgData.Items[i] = myItem;
                    break;
                }
            }

            WeTextBoxOne.Text = CMsgData.Getdata();


            TreeView1.Nodes.Clear();

            for (int i = 0; i < CMsgData.Items.Count; i++)
            {
                TreeView1.Nodes.Add(new TreeNode(CMsgData.Items[i].Title));
            }
            TextBoxTitle.Text = "";
            txt0.Text = "";
            TextBoxUrl.Text = "";
            TextBoxEDIT.Text = "";
            Label2.Text = "";



            Button24_Click(null, null);
        }

        protected void Button24_Click(object sender, EventArgs e)
        {

            
            try
            {
                string PathFile = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\NEWS\\news.dll"); //图文 关键词回复目录);    

                File.WriteAllText(PathFile, WeTextBoxOne.Text, System.Text.Encoding.UTF8);

               
                Label1.Text = "保存成功！";

                

            }
            catch
            {
                Label1.Text = "保存失败,关键字中不能有特殊字符";
            }
        }

    }
}