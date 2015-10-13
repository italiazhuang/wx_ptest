using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADOX;
using System.Text;

namespace WeiWeiXinNet
{
    /// <summary>
    /// 系统 目录管理器 
    /// </summary>
    public   class ClassDirectoryMag
    {
        /// <summary>
        /// 系统根目录  的上一级目录 Server.MapPath("~")
        /// </summary>
        public static string SYSTEMDIR="";

         
        /// <summary>
        ///  初始化系统目录
        /// </summary>
        /// <param name="dir"> 系统根目录   Server.MapPath("~")  </param>
        /// <param name="build">是否检测和建立目录</param>
        public static void Init(string dir, bool build)
        {
            SYSTEMDIR = dir;

            if (build)
            {
                CheckDir("USER_DIR"); //用户数据根目录

                CheckDir("USER_DIR\\SYSUSER"); //系统记录文件夹
                CheckDir("USER_DIR\\USER");//用户数据记录文件夹
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\"); //系统设置文件夹

                CheckDir("USER_DIR\\SYSUSER\\MyPost"); //关键词回复目录

                CheckDir("USER_DIR\\SYSUSER\\MyPost\\TXT"); //文本 关键词回复目录

                CheckDir("USER_DIR\\SYSUSER\\MyPost\\IMG"); //图文 关键词回复目录

                CheckDir("USER_DIR\\SYSUSER\\MyPost\\VOC"); //语音 关键词回复目录

                CheckDir("USER_DIR\\SYSUSER\\MyPost\\ZHUAN"); //关键词 转义 回复目录

                CheckDir("USER_DIR\\SYSUSER\\MyPost\\location1"); // lbs 地址信息
                CheckDir("USER_DIR\\SYSUSER\\MyPost\\location2"); //lbs 地址信息  精度差的 地址信息

                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement"); // Main01
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicNewsEditor");//Main02
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main03");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main04");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\CheckOnWorkAttendanceEdit");//05
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main06");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\AirQualityData");  //07
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\TodayinHistoryEdit"); //08
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\EveryDayEnglishData"); //09
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main10");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main11");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main12");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main13");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\WeiXinMenuEditor");  //14
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main15");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\TopNewsEditor");  //16
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\MobileSiteFramework");  //17
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\MobileSitePagesManagement");  //18
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main19");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main20");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main21");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main22");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main23");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main24");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\AboutWeWeiXinNet"); //25
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\MarketingPicIndex"); //26
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\UserPicIndex"); //27
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\WeiXinDataAPPIndex"); //28
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\ShopDataAPPIndex"); //29
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\SystemAPPIndex"); //30
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\MyTableAPPIndex"); //31
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main32");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main33");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main34");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main35");
                CheckDir("USER_DIR\\SYSUSER\\SYSSET\\Main36");

                CheckDir("USER_DIR\\SYSUSER\\HOME\\");//首页
                CheckDir("USER_DIR\\SYSUSER\\TUWEN\\"); //图文


                CheckDir("USER_DIR\\SYSUSER\\WEIQIANG\\");//微信墙
                CheckDir("USER_DIR\\SYSUSER\\GUNDONG\\"); //滚动新闻
                CheckDir("USER_DIR\\SYSUSER\\QD\\"); //签到配置文件
                CheckDir("USER_DIR\\SYSUSER\\HS");//每日历史
                CheckDir("USER_DIR\\SYSUSER\\YIJIAN\\");//意见
                CheckDir("USER_DIR\\SYSUSER\\USerName"); //用户注册名称 昵称目录
                CheckDir("USER_DIR\\SYSUSER\\Shangcheng\\");//商城文件夹

                CheckDir("USER_DIR\\SYSUSER\\Shangcheng\\SET");//商城 配置 文件夹
                CheckDir("USER_DIR\\SYSUSER\\Shangcheng\\GOODs");//商城商品文件夹
                CheckDir("USER_DIR\\SYSUSER\\Shangcheng\\DINGDAN");//商城订单 文件夹

                CheckDir("USER_DIR\\SYSUSER\\Shangcheng\\OLDDINGDAN");//商城订单 文件夹


                CheckDir("USER_DIR\\SYSUSER\\DINGDAN"); //订单文件夹
                CheckDir("USER_DIR\\SYSUSER\\EN"); //每日英语文件夹
                CheckDir("USER_DIR\\SYSUSER\\PM25"); //PM2.5 文件夹

                CheckDir("USER_DIR\\SYSUSER\\ADMIN"); //管理员账号 文件夹

                CheckDir("USER_DIR\\SYSUSER\\NEWS\\");//新闻目录

                CheckDir("USER_DIR\\SYSUSER\\MP3\\"); // 音乐台文件夹
                CheckDir("USER_DIR\\SYSUSER\\MP32\\"); // 音乐台文件夹 复制 字符路径 

                CheckDir("USER_DIR\\SYSUSER\\VOCDATA\\"); // 语音文件夹 

                CheckDir("USER_DIR\\SYSUSER\\PHOTO\\"); // 微相册文件夹

                CheckDir("USER_DIR\\SYSUSER\\IMG\\");//系统需要的图片

                CheckDir("USER_DIR\\SYSUSER\\Table\\"); // 表单文件夹
                CheckDir("USER_DIR\\SYSUSER\\Table\\Table1\\"); // 表单 文件夹  
                CheckDir("USER_DIR\\SYSUSER\\Table\\Table2\\"); // 表单结果收集文件夹 每个表单关键名称建立一个文件夹
                CheckDir("USER_DIR\\SYSUSER\\Table\\IMG\\"); // 表单图片文件夹


                CheckDir("USER_DIR\\SYSUSER\\Table\\Table3\\"); //例子文件夹 

                CheckDir("USER_DIR\\SYSUSER\\YJJIAN"); //用户反馈文件夹 

                CheckDir("USER_DIR\\SYSUSER\\PAGES"); //内容页文件夹

                CheckDir("USER_DIR\\SYSUSER\\LotteryTicket"); // 刮刮卡页面
                CheckDir("USER_DIR\\SYSUSER\\Turntable"); // 大转盘

                CheckDir("USER_DIR\\SYSUSER\\Coupons"); // 优惠劵


                CheckDir("USER_DIR\\SYSUSER\\Animation"); //动画引擎

                /// <summary>
                /// 建立 刮刮卡 数据库

                try
                {
                    LotteryTicket_InitDataBase();
                }
                catch
                { }

                try
                {
                    Turntable_InitDataBase();
                }
                catch
                { }

                try
                {
                    Coupons_InitDataBase();
                }
                catch
                { }


            }

        }


        /// <summary>
        /// 检测并且系统设置目录
        /// </summary>
        /// <param name="dir"></param>
        public static void CheckDir(string dir)
        {
            //系统目录 存放目录
            string PathDir03 = System.IO.Path.Combine(SYSTEMDIR,  dir);//"USER_DIR\\SYSUSER\\SYSSET\\" +
            if (     System.IO.Directory.Exists(PathDir03) == false)
            {   //建立用户目录
                System.IO.Directory.CreateDirectory(PathDir03);
            }
        }


        /// <summary>
        /// 建立 大转盘 数据库
        /// </summary>
        public static void Turntable_InitDataBase()
        {

            string PathDataBase = System.IO.Path.Combine(SYSTEMDIR, "USER_DIR\\SYSUSER\\Turntable\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            if (System.IO.File.Exists(PathDataBase) == true)
            {
                return;
            }

            try
            {

                ADOX.Catalog catalog = new Catalog();
                catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase + ";Jet OLEDB:Engine Type=5");

                ADODB.Connection cn = new ADODB.Connection();

                cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase, null, null, -1);
                catalog.ActiveConnection = cn;

                //     string Data1 = "CREATE TABLE WX_GGK( \r\n";
                //     Data1 += "ID int IDENTITY(1,1) NOT NULL,\r\n";
                //     Data1 += "Name nvarchar(200) NULL,\r\n";
                //     Data1 += "Cs int NULL\r\n";
                //     Data1 += ") ON PRIMARY\r\n";


                //            Data1 += "CREATE TABLE WX_GGK_JP(\r\n";
                //Data1 += "ID int IDENTITY(1,1) NOT NULL,\r\n";
                //Data1 += "Name nvarchar(200) NULL,\r\n";
                //Data1 += "Jp nvarchar(50) NULL,\r\n";
                //Data1 += "SJH nvarchar(50) NULL\r\n";
                //Data1 += ") ON PRIMARY\r\n";


                //     object dummy = Type.Missing;
                //     cn.Execute(Data1, out dummy, 0);
                  if (true)
                    {
                        ADOX.Table table = new ADOX.Table();
                        table.Name = "wx_dzp";
                        ADOX.Column column = new ADOX.Column();
                        column.ParentCatalog = catalog;
                        column.Name = "ID";
                        column.Type = DataTypeEnum.adInteger;
                        column.DefinedSize = 7;
                        column.Properties["AutoIncrement"].Value = true;
                        table.Columns.Append(column, DataTypeEnum.adInteger, 7);
                        table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

                        table.Columns.Append("Name", DataTypeEnum.adVarWChar, 200);
                        table.Columns.Append("Cs", DataTypeEnum.adInteger, 7);

                        catalog.Tables.Append(table);
                    }
                

                if (true)
                {
                    ADOX.Table table = new ADOX.Table();
                    table.Name = "wx_dzp_jp";
                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = catalog;
                    column.Name = "ID";
                    column.Type = DataTypeEnum.adInteger;
                    column.DefinedSize = 7;
                    column.Properties["AutoIncrement"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adInteger, 7);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

                    table.Columns.Append("Name", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("Jp", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("SJH", DataTypeEnum.adVarWChar, 200);

                    catalog.Tables.Append(table);
                }


                cn.Close();

            }
            catch
            {

            }

        }


        /// <summary>
        /// 建立 刮刮卡 数据库
        /// </summary>
        public static void LotteryTicket_InitDataBase()
        {

            string PathDataBase = System.IO.Path.Combine(SYSTEMDIR, "USER_DIR\\SYSUSER\\LotteryTicket\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            if (System.IO.File.Exists(PathDataBase) == true )
            {
               return;
            }

            try
            {

                ADOX.Catalog catalog = new Catalog();
                catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase + ";Jet OLEDB:Engine Type=5");

                ADODB.Connection cn = new ADODB.Connection();

                cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase, null, null, -1);
                catalog.ActiveConnection = cn;

           //     string Data1 = "CREATE TABLE WX_GGK( \r\n";
           //     Data1 += "ID int IDENTITY(1,1) NOT NULL,\r\n";
           //     Data1 += "Name nvarchar(200) NULL,\r\n";
           //     Data1 += "Cs int NULL\r\n";
           //     Data1 += ") ON PRIMARY\r\n";


           //            Data1 += "CREATE TABLE WX_GGK_JP(\r\n";
           //Data1 += "ID int IDENTITY(1,1) NOT NULL,\r\n";
           //Data1 += "Name nvarchar(200) NULL,\r\n";
           //Data1 += "Jp nvarchar(50) NULL,\r\n";
           //Data1 += "SJH nvarchar(50) NULL\r\n";
           //Data1 += ") ON PRIMARY\r\n";


           //     object dummy = Type.Missing;
           //     cn.Execute(Data1, out dummy, 0);

                if (true)
                {
                    ADOX.Table table = new ADOX.Table();
                    table.Name = "wx_ggk";
                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = catalog;
                    column.Name = "ID";
                    column.Type = DataTypeEnum.adInteger;
                    column.DefinedSize = 7;
                    column.Properties["AutoIncrement"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adInteger, 7);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
                    table.Columns.Append("Name", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("Cs", DataTypeEnum.adInteger, 7);
                    catalog.Tables.Append(table);
                }

                if (true)
                {
                    ADOX.Table table = new ADOX.Table();
                    table.Name = "wx_ggk_jp";
                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = catalog;
                    column.Name = "ID";
                    column.Type = DataTypeEnum.adInteger;
                    column.DefinedSize = 7;
                    column.Properties["AutoIncrement"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adInteger, 7);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

                    table.Columns.Append("Name", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("Jp", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("SJH", DataTypeEnum.adVarWChar, 200);

                    catalog.Tables.Append(table);
                }


                cn.Close();

            }
            catch
            {

            }

        }

        
         /// <summary>
        /// 建立 优惠劵 数据库
        /// </summary>
        public static void Coupons_InitDataBase()
        {

            // string sqlstr = "INSERT INTO WX_Coupons(CUserName, CUserPhone, CUserqq, WXOpenID)  VALUES   (N'" + CUserName + "',N'" + CUserPhone + "',N'" + CUserqq + "',N'" + Session["WXOpenID"] + "')";
               

            string PathDataBase = System.IO.Path.Combine(SYSTEMDIR, "USER_DIR\\SYSUSER\\Coupons\\db.dll");//"USER_DIR\\SYSUSER\\SYSSET\\" +
            if (System.IO.File.Exists(PathDataBase) == true )
            {
               return;
            }

            try
            {

                ADOX.Catalog catalog = new Catalog();
                catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase + ";Jet OLEDB:Engine Type=5");

                ADODB.Connection cn = new ADODB.Connection();

                cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PathDataBase, null, null, -1);
                catalog.ActiveConnection = cn;

                if (true)
                {
                    ADOX.Table table = new ADOX.Table();
                    table.Name = "WX_Coupons";
                    ADOX.Column column = new ADOX.Column();
                    column.ParentCatalog = catalog;
                    column.Name = "WXOpenID";
                    column.Type = DataTypeEnum.adInteger;
                    column.DefinedSize = 7;
                    column.Properties["AutoIncrement"].Value = true;
                    table.Columns.Append(column, DataTypeEnum.adInteger, 7);
                    table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
  // string sqlstr = "INSERT INTO WX_Coupons(CUserName, CUserPhone, CUserqq, WXOpenID)  VALUES   (N'" + CUserName + "',N'" + CUserPhone + "',N'" + CUserqq + "',N'" + Session["WXOpenID"] + "')";
                    table.Columns.Append("CUserName", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("CUserPhone", DataTypeEnum.adVarWChar, 200);
                    table.Columns.Append("CUserqq", DataTypeEnum.adVarWChar, 200);
                    catalog.Tables.Append(table);
                }
                cn.Close();
            }
            catch
            {

            }

        }

    }
}