using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
 
using System.Net;
using System.Text;

namespace ClassLibraryWeiBao
{
    /// <summary>
    ///  服务器通信 服务 ClassServerCOM 的摘要说明
    /// </summary>
    public class ClassServerCOM
    {

        

        public ClassServerCOM()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //








        }


        /// <summary>
        /// 学院 名称 简写
        /// </summary>
        /// <param name="NN"></param>
        /// <returns></returns>
        public static string GetXueYuanShortName(string NN)
        {
            string RT = "未知";
            switch (NN.Trim())
            {
                case "人文学院": RT = "人文"; break;
                case "政法学院": RT = "政法"; break;
                case "外国语学院": RT = "外院"; break;
                case "阿拉伯学院": RT = "阿院"; break;
                case "经济管理学院": RT = "经管"; break;
                case "数学计算机学院": RT = "数计"; break;
                case "物理电气信息学院": RT = "物电"; break;
                case "化学化工学院": RT = "化工"; break;
                case "生命科学学院": RT = "生科"; break;
                case "资源环境学院": RT = "资环"; break;
                case "机械工程学院": RT = "机械"; break;
                case "农学院": RT = "农学院"; break;
                case "葡萄酒学院": RT = "葡萄酒"; break;
                case "土木水利工程学院": RT = "土木"; break;
                case "教育学院": RT = "教育"; break;
                case "体育学院": RT = "体育"; break;
                case "音乐学院": RT = "音乐"; break;
                case "美术学院": RT = "美术"; break;
                case "马克思主义学院": RT = "马克思"; break;
                case "国际教育学院": RT = "国际"; break;
                case "继续教育学院": RT = "继续教育"; break;
                case "民族预科教育学院": RT = "预科"; break;
                case "远程教育学院": RT = "远程教育"; break;
                case "新华学院": RT = "新华"; break;
            }


            return RT;
        }

        /// <summary>
        /// 获取数据 
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="id">用户ID</param>
        /// <param name="dat">指令</param>
        /// <returns></returns>
        public static string GetDataXPLP(string url, string id, string dat)
        {
            try
            {
                WebClient NN = new WebClient();
                NN.Encoding = System.Text.Encoding.UTF8;

                string UU = url + "|" + ToUnicode2(id) + "|" + ToUnicode2(dat);

                String DA = NN.DownloadString(UU);

                String DACN = ToGB23122(DA);

                return DACN;
            }
            catch
            {
                return "漂流瓶服务器 故障";
            }

        }


        /// <summary>
        /// 获取数据 
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="id">用户ID</param>
        /// <param name="dat">参数</param>
        /// <param name="ty"> 类型</param>
        /// <returns></returns>
        public static string GetDataXPLP_X(string url, string id,string ty ,string canshu)
        {
            try
            {
                WebClient NN = new WebClient();
                NN.Encoding = System.Text.Encoding.UTF8;

                string UU = url + "|" + ToUnicode2(id) + "|" + ToUnicode2(ty) + "|" + ToUnicode2(canshu);

                String DA = NN.DownloadString(UU);

                String DACN = ToGB23122(DA);

                return DACN;
            }
            catch
            {
                return "CHATERROR|CHAT服务器故障";
            }

        }

        /// <summary>
        /// 获得 MD5 名称
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public static string GetMasterPasswordBytes(string dat)
        {
            if (dat.Length == 0)
                return null;

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
        /// 汉字转换为Unicode编码
        /// </summary>
        /// <param name="str">要编码的汉字字符串</param>
        /// <returns>Unicode编码的的字符串</returns>
        public static string ToUnicode2(string str)
        {
            byte[] bts = Encoding.Unicode.GetBytes(str);
            string r = "";
            for (int i = 0; i < bts.Length; i += 2) r += "\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return r;
        }
        /// <summary>
        /// 将Unicode编码转换为汉字字符串
        /// </summary>
        /// <param name="str">Unicode编码字符串</param>
        /// <returns>汉字字符串</returns>
        public static string ToGB23122(string str)
        {
            string r = "";
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            foreach (Match m in mc)
            {
                bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                r += Encoding.Unicode.GetString(bts);
            }
            return r;
        }


    }
}