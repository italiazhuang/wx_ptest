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
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using IZ.WebFileManager;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Collections.Specialized;
using LitJson;

using System.Text;
 
namespace WeiWeiXinNet.admin
{
    /// <summary>
    /// 菜单编辑器  
    /// </summary>
    public partial class WeiXinMenuEditor : System.Web.UI.Page
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


            try
            {
                string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtAppid.dll");
                txtAppid.Text = System.IO.File.ReadAllText(PathFileOne, System.Text.Encoding.UTF8);
            }
            catch { }

            try
            {
                string PathFileOnetxtKey = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtKey.dll");
                txtKey.Text = System.IO.File.ReadAllText(PathFileOnetxtKey, System.Text.Encoding.UTF8);
            }
            catch
            { }

            try
            {
                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtMenuString.dll");
                txtMenuString.Text = System.IO.File.ReadAllText(PathFileOnetxtMenuString, System.Text.Encoding.UTF8);
            }
            catch
            { }

            ButtonOne.Attributes.Add("OnClick", "return  jsQ1();");
            ButtonTwo.Attributes.Add("OnClick", "return  jsQ2();");
            ButtonThree.Attributes.Add("OnClick", "return  jsQ3();");


            LoadMenuSet();

            txtMenuString.Text = GetMenu();
               
            
        }

        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            if (!CheckAppSetting())
                return;

         //   if (MessageBox.Show("您确定要获菜单数据吗？获取后将会覆盖现在的菜单结构体内容!", "确定更新", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            MyHttpWebRequest request = new MyHttpWebRequest();
            string token = this.GetToken();
            if (String.IsNullOrEmpty(token))
            {
                ShowLog("获取Token失败!");
                return;
            }

            string rtn = request.getPage(String.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", token));

            try
            {
                LitJson.JsonData data = LitJson.JsonMapper.ToObject(rtn);
                if (!String.IsNullOrEmpty(data["errcode"].ToString()))
                {
                    ShowLog("获取菜单返回:\r\n" + rtn);
                }
                else
                {
                    txtMenuString.Text = rtn;
                }
            }
            catch (Exception ex)
            {
                txtMenuString.Text = rtn;
            }
            
        }


        private bool CheckAppSetting()
        {
            if (String.IsNullOrEmpty(txtAppid.Text.Trim()))
            {
                ShowLog("请填写AppId");
                return false;
            }
            if (String.IsNullOrEmpty(txtKey.Text.Trim()))
            {
                ShowLog("请填写AppSecret");
                return false;
            }
            return true;
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            if (!CheckAppSetting())
                return;


            txtMenuString.Text = GetMenu();


            SaveConfig();


            if (String.IsNullOrEmpty(txtMenuString.Text.Trim()))
            {
                ShowLog("请填写菜单信息");
                return;
            }
         //   if (MessageBox.Show("您确定要创建或更新菜单吗？", "确定更新", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            //1:获得token
            MyHttpWebRequest request = new MyHttpWebRequest();
            string token = GetToken();
            if (String.IsNullOrEmpty(token))
            {
                ShowLog("获取Token失败!");
                return;
            }
            //2:删除当前菜单
            string rtn = request.getPage("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + token);

            ShowLog("清除菜单返回：\r\n" + rtn);

            //3:创建菜单
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("", txtMenuString.Text);
            rtn = request.post("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + token, nvc, Encoding.UTF8);
            ShowLog("提交菜单返回：" + rtn);
        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            if (!CheckAppSetting())
                return;
         //   if (MessageBox.Show("您确定清除微信菜单吗？清除后您还可以重建菜单!", "确定清除", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            txtMenuString.Text = GetMenu();


            SaveConfig();

            MyHttpWebRequest request = new MyHttpWebRequest();
            string token = this.GetToken();
            if (String.IsNullOrEmpty(token))
            {
                ShowLog("获取Token失败!");
                return;
            }

            string rtn = request.getPage("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + token);

            ShowLog("清除菜单返回：\r\n" + rtn);
           
            
        }

        private string Token = "";
        private DateTime TokenTime;
        private int expires = 0;
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        private string GetToken()
        {
            if (!String.IsNullOrEmpty(Token))
            {
                if (DateTime.Now.Subtract(TokenTime).TotalSeconds < expires) return Token;
            }
            MyHttpWebRequest request = new MyHttpWebRequest();
            string rtn = request.getPage(String.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", txtAppid.Text, txtKey.Text));
            ShowLog("获取Token返回:" + rtn);
            try
            {
                LitJson.JsonData data = LitJson.JsonMapper.ToObject(rtn);
                Token = data["access_token"].ToString();
                TokenTime = DateTime.Now;
                expires = Convert.ToInt32(data["expires_in"].ToString());
                return Token;
            }
            catch (Exception ex)
            {
                ShowLog(ex.Message);
            }
            return "";
        }


        public void ShowLog(string log)
        {
            Label1.Text = DateTime.Now.ToShortTimeString() + " " + log;
        }

        /// <summary>
        /// 配置系统
        /// </summary>
        public void SaveConfig()
        {
            //保存配置

            //系统目录 存放目录
            string PathFileOne = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtAppid.dll");
            System.IO.File.WriteAllText(PathFileOne, txtAppid.Text, System.Text.Encoding.UTF8);

            string PathFileOnetxtKey = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtKey.dll");
            System.IO.File.WriteAllText(PathFileOnetxtKey, txtKey.Text, System.Text.Encoding.UTF8);

            string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\txtMenuString.dll");
            System.IO.File.WriteAllText(PathFileOnetxtMenuString, txtMenuString.Text, System.Text.Encoding.UTF8);

            ShowLog("保存成功！");
        }

        protected void ButtonFive_Click(object sender, EventArgs e)
        {
          //  txtMenuString.Text = WeTextBoxOne.Text;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
           
        }

        protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        {
               var One = TreeView1.SelectedNode;
                Label2.Text = One.Value;
                Label3.Text = "";

                WeTextBoxThree.Text = "";
                DropDownList2.Text ="";
                WeTextBoxFour.Text ="";

                LoadData(Label2.Text);

        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="name"></param>
        public void LoadData(string name)
        {
            name = name.Replace(":", "_");

            try
            {
                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\"+ name+".dll");
              string[] DataLines= System.IO.File.ReadAllLines(PathFileOnetxtMenuString, System.Text.Encoding.UTF8);

              WeTextBoxThree.Text = DataLines[0];
              DropDownList2.Text = DataLines[1];
              WeTextBoxFour.Text = DataLines[2];

              if (WeTextBoxThree.Text == "")
              { WeTextBoxThree.Text = "菜单名称"; }

              if (WeTextBoxFour.Text == "")
              { WeTextBoxFour.Text = "参数数据"; }

            }
            catch
            {

               
                  WeTextBoxThree.Text = "菜单名称";  

                
                  WeTextBoxFour.Text = "参数数据";  

            
            
            }
        }


       

        /// <summary>
        /// 读取一个顶层 菜单配置
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public string LoadDataTopMenu(string name)
        {
            string GDATA = "";

            name = name.Replace(":", "_");

            try
            {
                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\" + name + ".dll");
                string[] DataLines = System.IO.File.ReadAllLines(PathFileOnetxtMenuString, System.Text.Encoding.UTF8);

                if (DataLines[1].Trim() == "发送键值")
                {
                    GDATA += "{	\r\n";
                    GDATA += "\"type\":\"click\",	\r\n";
                    GDATA += " \"name\":\"" + DataLines[0].Trim().Replace("\n","") + "\",	\r\n";
                    GDATA += "\"key\":\"" + DataLines[2].Trim().Replace("\n", "") + "\"	\r\n }";
                    return GDATA;
                }
                else
                {
                    GDATA += "{	\r\n";
                    GDATA += "\"type\":\"view\",	\r\n";
                    GDATA += " \"name\":\"" + DataLines[0].Trim().Replace("\n", "") + "\",	\r\n";
                    GDATA += "\"url\":\"" + DataLines[2].Trim().Replace("\n", "") + "\"	\r\n }";
                    return GDATA;
                }

                return "";

            }
            catch
            { }

            return "";
        }



        /// <summary>
        /// 读取数据 标题
        /// </summary>
        /// <param name="name"></param>
        public string LoadDataTitle(string name)
        {
            name = name.Replace(":", "_");

            try
            {
                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\" + name + ".dll");
                string[] DataLines = System.IO.File.ReadAllLines(PathFileOnetxtMenuString, System.Text.Encoding.UTF8);

               return  DataLines[0];
               
            }
            catch
            { }

            return "请填写菜单名称";
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="name"></param>
        public void SaveData(string name)
        {
            name = name.Replace(":","_");

            try
            {
                string[] DataLines = { WeTextBoxThree.Text, DropDownList2.Text, WeTextBoxFour.Text };

                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\" + name + ".dll");
                System.IO.File.WriteAllLines(PathFileOnetxtMenuString, DataLines, System.Text.Encoding.UTF8);

                Label3.Text = "保存成功："+Label2.Text;
            }
            catch
            {
                Label3.Text = "保存失败："+Label2.Text;
                
            }


        }

        protected void ButtonEight_Click(object sender, EventArgs e)
        {

            SaveData(Label2.Text);

            LoadMenuSet();

            txtMenuString.Text = GetMenu();

            Label1.Text = "";
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {

            //保存菜单状态

          TreeNode  Menu1=  TreeView1.Nodes[0];
          TreeNode Menu1_1 = TreeView1.Nodes[0].ChildNodes[0];
          TreeNode Menu1_2 = TreeView1.Nodes[0].ChildNodes[1];
          TreeNode Menu1_3 = TreeView1.Nodes[0].ChildNodes[2];
          TreeNode Menu1_4 = TreeView1.Nodes[0].ChildNodes[3];
          TreeNode Menu1_5 = TreeView1.Nodes[0].ChildNodes[4];


          TreeNode Menu2 = TreeView1.Nodes[1];
          TreeNode Menu2_1 = TreeView1.Nodes[1].ChildNodes[0];
          TreeNode Menu2_2 = TreeView1.Nodes[1].ChildNodes[1];
          TreeNode Menu2_3 = TreeView1.Nodes[1].ChildNodes[2];
          TreeNode Menu2_4 = TreeView1.Nodes[1].ChildNodes[3];
          TreeNode Menu2_5 = TreeView1.Nodes[1].ChildNodes[4];


          TreeNode Menu3 = TreeView1.Nodes[2];
          TreeNode Menu3_1 = TreeView1.Nodes[2].ChildNodes[0];
          TreeNode Menu3_2 = TreeView1.Nodes[2].ChildNodes[1];
          TreeNode Menu3_3 = TreeView1.Nodes[2].ChildNodes[2];
          TreeNode Menu3_4 = TreeView1.Nodes[2].ChildNodes[3];
          TreeNode Menu3_5 = TreeView1.Nodes[2].ChildNodes[4];

          string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\" + "menu_select" + ".dll");

          string[] MSELECT = new string[18];
          int ZhiZhen = 0;
          if (Menu1.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu1_1.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu1_2.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu1_3.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu1_4.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu1_5.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }

          if (Menu2.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu2_1.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu2_2.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu2_3.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu2_4.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu2_5.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }

          if (Menu3.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu3_1.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu3_2.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu3_3.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu3_4.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }
          if (Menu3_5.Checked) { MSELECT[ZhiZhen] = "1"; ZhiZhen++; } else { MSELECT[ZhiZhen] = "0"; ZhiZhen++; }




          System.IO.File.WriteAllLines(PathFileOnetxtMenuString, MSELECT, System.Text.Encoding.UTF8);


        }


        public void LoadMenuSet()
        {
            try
            {

                TreeNode Menu1 = TreeView1.Nodes[0];
                TreeNode Menu1_1 = TreeView1.Nodes[0].ChildNodes[0];
                TreeNode Menu1_2 = TreeView1.Nodes[0].ChildNodes[1];
                TreeNode Menu1_3 = TreeView1.Nodes[0].ChildNodes[2];
                TreeNode Menu1_4 = TreeView1.Nodes[0].ChildNodes[3];
                TreeNode Menu1_5 = TreeView1.Nodes[0].ChildNodes[4];


                TreeNode Menu2 = TreeView1.Nodes[1];
                TreeNode Menu2_1 = TreeView1.Nodes[1].ChildNodes[0];
                TreeNode Menu2_2 = TreeView1.Nodes[1].ChildNodes[1];
                TreeNode Menu2_3 = TreeView1.Nodes[1].ChildNodes[2];
                TreeNode Menu2_4 = TreeView1.Nodes[1].ChildNodes[3];
                TreeNode Menu2_5 = TreeView1.Nodes[1].ChildNodes[4];


                TreeNode Menu3 = TreeView1.Nodes[2];
                TreeNode Menu3_1 = TreeView1.Nodes[2].ChildNodes[0];
                TreeNode Menu3_2 = TreeView1.Nodes[2].ChildNodes[1];
                TreeNode Menu3_3 = TreeView1.Nodes[2].ChildNodes[2];
                TreeNode Menu3_4 = TreeView1.Nodes[2].ChildNodes[3];
                TreeNode Menu3_5 = TreeView1.Nodes[2].ChildNodes[4];

                string PathFileOnetxtMenuString = System.IO.Path.Combine(Server.MapPath("~"), "USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor\\" + "menu_select" + ".dll");

                string[] MSELECT = System.IO.File.ReadAllLines(PathFileOnetxtMenuString, System.Text.Encoding.UTF8);

                int ZhiZhen = 0;

                if (MSELECT[ZhiZhen] == "1") { Menu1.Checked = true; ZhiZhen++; } else { Menu1.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu1_1.Checked = true; ZhiZhen++; } else { Menu1_1.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu1_2.Checked = true; ZhiZhen++; } else { Menu1_2.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu1_3.Checked = true; ZhiZhen++; } else { Menu1_3.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu1_4.Checked = true; ZhiZhen++; } else { Menu1_4.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu1_5.Checked = true; ZhiZhen++; } else { Menu1_5.Checked = false; ZhiZhen++; }

                if (MSELECT[ZhiZhen] == "1") { Menu2.Checked = true; ZhiZhen++; } else { Menu2.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu2_1.Checked = true; ZhiZhen++; } else { Menu2_1.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu2_2.Checked = true; ZhiZhen++; } else { Menu2_2.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu2_3.Checked = true; ZhiZhen++; } else { Menu2_3.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu2_4.Checked = true; ZhiZhen++; } else { Menu2_4.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu2_5.Checked = true; ZhiZhen++; } else { Menu2_5.Checked = false; ZhiZhen++; }

                if (MSELECT[ZhiZhen] == "1") { Menu3.Checked = true; ZhiZhen++; } else { Menu3.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu3_1.Checked = true; ZhiZhen++; } else { Menu3_1.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu3_2.Checked = true; ZhiZhen++; } else { Menu3_2.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu3_3.Checked = true; ZhiZhen++; } else { Menu3_3.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu3_4.Checked = true; ZhiZhen++; } else { Menu3_4.Checked = false; ZhiZhen++; }
                if (MSELECT[ZhiZhen] == "1") { Menu3_5.Checked = true; ZhiZhen++; } else { Menu3_5.Checked = false; ZhiZhen++; }

                Menu1.Text = LoadDataTitle(Menu1.Value);
                Menu1_1.Text = LoadDataTitle(Menu1_1.Value);
                Menu1_2.Text = LoadDataTitle(Menu1_2.Value);
                Menu1_3.Text = LoadDataTitle(Menu1_3.Value);
                Menu1_4.Text = LoadDataTitle(Menu1_4.Value);
                Menu1_5.Text = LoadDataTitle(Menu1_5.Value);

                Menu2.Text = LoadDataTitle(Menu2.Value);
                Menu2_1.Text = LoadDataTitle(Menu2_1.Value);
                Menu2_2.Text = LoadDataTitle(Menu2_2.Value);
                Menu2_3.Text = LoadDataTitle(Menu2_3.Value);
                Menu2_4.Text = LoadDataTitle(Menu2_4.Value);
                Menu2_5.Text = LoadDataTitle(Menu2_5.Value);

                Menu3.Text = LoadDataTitle(Menu3.Value);
                Menu3_1.Text = LoadDataTitle(Menu3_1.Value);
                Menu3_2.Text = LoadDataTitle(Menu3_2.Value);
                Menu3_3.Text = LoadDataTitle(Menu3_3.Value);
                Menu3_4.Text = LoadDataTitle(Menu3_4.Value);
                Menu3_5.Text = LoadDataTitle(Menu3_5.Value);
            }
            catch
            {

            }

        }


        /// <summary>
        /// 刷新菜单状态
        /// </summary>
        public void RsTreeView()
        {



        }

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {

        }

        /// <summary>
        /// 得到菜单数据
        /// </summary>
        /// <returns></returns>
        public string GetMenu()
        {

            ArrayList MENU = new ArrayList();
         

            string DataMenu = "";
            DataMenu += " { \r\n";
            DataMenu += " \"button\":[  \r\n";


            TreeNode Menu1 = TreeView1.Nodes[0];
            TreeNode Menu1_1 = TreeView1.Nodes[0].ChildNodes[0];
            TreeNode Menu1_2 = TreeView1.Nodes[0].ChildNodes[1];
            TreeNode Menu1_3 = TreeView1.Nodes[0].ChildNodes[2];
            TreeNode Menu1_4 = TreeView1.Nodes[0].ChildNodes[3];
            TreeNode Menu1_5 = TreeView1.Nodes[0].ChildNodes[4];


            TreeNode Menu2 = TreeView1.Nodes[1];
            TreeNode Menu2_1 = TreeView1.Nodes[1].ChildNodes[0];
            TreeNode Menu2_2 = TreeView1.Nodes[1].ChildNodes[1];
            TreeNode Menu2_3 = TreeView1.Nodes[1].ChildNodes[2];
            TreeNode Menu2_4 = TreeView1.Nodes[1].ChildNodes[3];
            TreeNode Menu2_5 = TreeView1.Nodes[1].ChildNodes[4];


            TreeNode Menu3 = TreeView1.Nodes[2];
            TreeNode Menu3_1 = TreeView1.Nodes[2].ChildNodes[0];
            TreeNode Menu3_2 = TreeView1.Nodes[2].ChildNodes[1];
            TreeNode Menu3_3 = TreeView1.Nodes[2].ChildNodes[2];
            TreeNode Menu3_4 = TreeView1.Nodes[2].ChildNodes[3];
            TreeNode Menu3_5 = TreeView1.Nodes[2].ChildNodes[4];

            if (Menu1.Checked == true)
            {
                if (Menu1_1.Checked == false && Menu1_2.Checked == false && Menu1_3.Checked == false && Menu1_3.Checked == false && Menu1_3.Checked == false)
                {
                     //没有子项 
                   string md=  LoadDataTopMenu(Menu1.Value);
                   if (md.Length > 10)
                       MENU.Add(md);

                }
                else
                {
                    string MenuName = LoadDataTitle(Menu1.Value);
                    ArrayList childMENU_1 = new ArrayList();

                    //子项 1
                    if (Menu1_1.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu1_1.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 2
                    if (Menu1_2.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu1_2.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }
                    //子项 3
                    if (Menu1_3.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu1_3.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 4
                    if (Menu1_4.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu1_4.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 5
                    if (Menu1_5.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu1_5.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    if (childMENU_1.Count == 1)
                    {
                        MENU.Add("{ \"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n" + childMENU_1[0].ToString() + " \r\n  ] }");


                    }
                    else if (childMENU_1.Count > 1)
                    {
                        string mdata = "{ \"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n";

                        for (int i = 0; i < childMENU_1.Count - 1; i++)
                        {
                            mdata += childMENU_1[i].ToString() + ",\r\n";
                        }

                        mdata += childMENU_1[childMENU_1.Count - 1].ToString() + "\r\n]}";
                        MENU.Add(mdata);
                    }



                }
            }



            if (Menu2.Checked == true)
            {
                if (Menu2_1.Checked == false && Menu2_2.Checked == false && Menu2_3.Checked == false && Menu2_4.Checked == false && Menu2_5.Checked == false)
                {
                    //没有子项 
                    string md = LoadDataTopMenu(Menu2.Value);
                    if (md.Length > 10)
                        MENU.Add(md);

                }
                else
                {
                    string MenuName = LoadDataTitle(Menu2.Value);
                    ArrayList childMENU_1 = new ArrayList();

                    //子项 1
                    if (Menu2_1.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu2_1.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 2
                    if (Menu2_2.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu2_2.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }
                    //子项 3
                    if (Menu2_3.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu2_3.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 4
                    if (Menu2_4.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu2_4.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 5
                    if (Menu2_5.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu2_5.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    if (childMENU_1.Count == 1)
                    {
                        MENU.Add("{ \"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n" + childMENU_1[0].ToString() +" \r\n  ] }" );

                    }
                    else if (childMENU_1.Count > 1)
                    {
                        string mdata = "{\"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n";

                        for (int i = 0; i < childMENU_1.Count - 1; i++)
                        {
                            mdata += childMENU_1[i].ToString() + ",\r\n";
                        }

                        mdata += childMENU_1[childMENU_1.Count - 1].ToString() + "\r\n ] }";
                        MENU.Add(mdata);
                    }



                }
            }

            if (Menu3.Checked == true)
            {
                if (Menu3_1.Checked == false && Menu3_2.Checked == false && Menu3_3.Checked == false && Menu3_4.Checked == false && Menu3_5.Checked == false)
                {
                    //没有子项 
                    string md = LoadDataTopMenu(Menu3.Value);
                    if (md.Length > 10)
                        MENU.Add(md);

                }
                else
                {
                    string MenuName = LoadDataTitle(Menu3.Value);
                    ArrayList childMENU_1 = new ArrayList();

                    //子项 1
                    if (Menu3_1.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu3_1.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 2
                    if (Menu3_2.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu3_2.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }
                    //子项 3
                    if (Menu3_3.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu3_3.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 4
                    if (Menu3_4.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu3_4.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    //子项 5
                    if (Menu3_5.Checked == true)
                    {
                        string md = LoadDataTopMenu(Menu3_5.Value);
                        if (md.Length > 10)
                            childMENU_1.Add(md);
                    }

                    if (childMENU_1.Count == 1)
                    {
                        MENU.Add("{ \"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n" + childMENU_1[0].ToString() + " \r\n   ]}");


                    }
                    else if (childMENU_1.Count > 1)
                    {
                        string mdata = "{ \"name\":\"" + MenuName + "\", \r\n \"sub_button\":[ \r\n";

                        for (int i = 0; i < childMENU_1.Count - 1; i++)
                        {
                            mdata += childMENU_1[i].ToString() + ",\r\n";
                        }

                        mdata += childMENU_1[childMENU_1.Count - 1].ToString() + "]}\r\n";
                        MENU.Add(mdata);
                    }



                }
            }

            if (MENU.Count == 1)
                DataMenu += MENU[0].ToString();

            if (MENU.Count == 2)
                DataMenu += MENU[0].ToString() +",\r\n"+MENU[1].ToString();

            if (MENU.Count == 3)
                DataMenu += MENU[0].ToString() + ",\r\n" + MENU[1].ToString() + ",\r\n" + MENU[2].ToString();


          


            DataMenu += "             ] \r\n";
            DataMenu += " } \r\n";

            return DataMenu;
        }


    }

    /**/
    /// <summary>
    /// HttpWeb请求管理。
    /// </summary>
    public class MyHttpWebRequest
    {
        /**/
        /// <summary>
        /// 保存网站Cookie。
        /// </summary>
        private string m_cookieheader;

        /// <summary>
        /// 保存引用地址
        /// </summary>
        private string m_Referer = string.Empty;

        private HttpStatusCode m_Status = HttpStatusCode.OK;


        /**/
        /// <summary>
        /// 页面请求超时限制。
        /// </summary>
        private int TIMEOUT = 60000;

        /// <summary>
        /// 设置引用URL
        /// </summary>
        /// <param name="url"></param>
        public void SetReferer(string url)
        {
            m_Referer = url;
        }

        /// <summary>
        /// 设置最长连接时间
        /// </summary>
        /// <param name="seconds">秒</param>
        public void SetTimeOut(int seconds)
        {
            TIMEOUT = seconds * 1000;
        }

        /// <summary>
        /// 设置引用URL
        /// </summary>
        /// <param name="url"></param>
        public HttpStatusCode GetStatusCode
        {
            get { return m_Status; }
        }

        public MyHttpWebRequest()
        {
            //
            // 构造函数逻辑
            //
            this.m_cookieheader = "";
        }

        /**/
        /// <summary>
        /// 断开，清除Cookie。
        /// </summary>
        public void Disconnect()
        {
            this.m_cookieheader = "";
        }

        /**/
        /// <summary>
        /// 登录，记录会话。
        /// </summary>
        public string Login(String url, NameValueCollection paramList, System.Text.Encoding wideCharEncoding)
        {
            return getPage(url, paramList, wideCharEncoding, "POST", true);
        }

        /**/
        /// <summary>
        /// Form提交方式获取响应数据。
        /// </summary>
        public string post(String url, NameValueCollection paramList, System.Text.Encoding wideCharEncoding)
        {
            return getPage(url, paramList, wideCharEncoding, "POST", false);
        }



        /**/
        /// <summary>
        /// Get方式获取响应数据。
        /// </summary>
        public string getPage(String url)
        {
            return getPage(url, null, null, "GET", false);
        }

        /**/
        /// <summary>
        /// Get方式获取响应数据。
        /// </summary>
        public byte[] getPageData(String url, bool doSetCookie)
        {
            return getPageBytes(url, null, null, "GET", doSetCookie);
        }

        private string getPage(String url, NameValueCollection paramList, System.Text.Encoding wideCharEncoding, string method, bool doSetCookie)
        {
            return System.Text.Encoding.UTF8.GetString(getPageBytes(url, paramList, wideCharEncoding, method, doSetCookie));
            // return System.Text.Encoding.Default.GetString( getPageBytes(url, paramList, wideCharEncoding, method, doSetCookie) );
        }


        private byte[] getPageBytes(String url, NameValueCollection paramList, System.Text.Encoding wideCharEncoding, string method, bool resetCookie)
        {
            HttpWebResponse res = null;
            System.Collections.ArrayList result = new System.Collections.ArrayList(5000);

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                // req.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:10.0) Gecko/20100101 Firefox/10.0";
                req.AllowAutoRedirect = false;
                req.Method = method;
                //req.KeepAlive = true;
                // req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                // req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                //req.Headers.Add(HttpRequestHeader.AcceptCharset, "GB2312,utf-8;q=0.7,*;q=0.7");
                // req.ContentType = "application/x-www-form-urlencoded";
                //  req.CookieContainer = new CookieContainer();
                // req.CookieContainer.SetCookies(new Uri(url), this.m_cookieheader);
                req.Timeout = TIMEOUT;
                // if (m_Referer != string.Empty)
                //     req.Referer = this.m_Referer;

                //上行方式时，设置参数
                if (method.ToUpper() != "GET")
                {
                    StringBuilder UrlEncoded = new StringBuilder();
                    Char[] reserved = { '?', '=', '&' };
                    byte[] SomeBytes = null;

                    if (paramList != null)
                    {
                        System.Text.StringBuilder paramBuilder = new System.Text.StringBuilder();
                        String paramstr = null;
                        for (int li = 0; li < paramList.Keys.Count; li++)
                        {
                            if (li > 0)
                            {
                                paramBuilder.Append("&");
                            }
                            if (paramList.Keys[li] != "")
                            {
                                paramBuilder.Append(paramList.Keys[li]);
                                paramBuilder.Append("=");
                            }
                            paramBuilder.Append(paramList[paramList.Keys[li]]);
                        }

                        paramstr = paramBuilder.ToString();

                        //int i=0, j;
                        //while(i<paramstr.Length)
                        //{
                        //    j=paramstr.IndexOfAny(reserved, i);
                        //    if (j==-1)
                        //    {
                        //        UrlEncoded.Append(HttpUtility.UrlEncode(paramstr.Substring(i, paramstr.Length-i), wideCharEncoding ));
                        //        break;
                        //    }
                        //    UrlEncoded.Append(HttpUtility.UrlEncode(paramstr.Substring(i, j-i), wideCharEncoding));
                        //    UrlEncoded.Append(paramstr.Substring(j,1));
                        //    i = j+1;
                        //}
                        SomeBytes = Encoding.UTF8.GetBytes(paramstr);

                        req.ContentLength = SomeBytes.Length;
                        Stream newStream = req.GetRequestStream();
                        newStream.Write(SomeBytes, 0, SomeBytes.Length);
                        newStream.Close();
                    }
                    else
                    {
                        req.ContentLength = 0;
                    }
                }


                //请求响应
                res = (HttpWebResponse)req.GetResponse();
                m_Status = res.StatusCode;
                if (resetCookie)
                {
                    this.m_cookieheader = req.CookieContainer.GetCookieHeader(new Uri(url));
                }

                Stream ReceiveStream = res.GetResponseStream();

                System.IO.BinaryReader sr = null;
                if (res.ContentEncoding == "gzip")
                {
                    GZipStream stream = new GZipStream(ReceiveStream, CompressionMode.Decompress);

                    sr = new BinaryReader(stream);
                }
                else
                    sr = new BinaryReader(ReceiveStream);

                //读取数据


                byte[] read = new byte[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    result.AddRange(GetSubBytes(read, 0, count));
                    count = sr.Read(read, 0, 256);
                }



            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
                result.Clear();
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return (byte[])result.ToArray(typeof(byte));
        }

        private byte[] GetSubBytes(byte[] buffer, int index, int count)
        {
            if ((count + index) > buffer.Length)
            {
                count = buffer.Length - index;
            }
            System.IO.MemoryStream s = new System.IO.MemoryStream(buffer, index, count);
            return s.ToArray();
        }


       
    }
}