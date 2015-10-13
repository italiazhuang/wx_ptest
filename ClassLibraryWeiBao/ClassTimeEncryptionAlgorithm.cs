using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ClassLibraryWeiBao
{
    /// <summary>
    /// 时间辍　加密算法
    /// 
    /// 
    /// 时间戳算法 ：   字符字符串   前端  加上    字符串 1 +  3位毫秒  +  （2位小时+71） +  （2位秒 +17） + 字符串2 +  （2位天 +9）+ 2位随机数+  （2位月+3）+ （2位年 -10） +字符串3 +  2位数字 （ 字符串1 截取的位置  前半段随机）+  2位数字 （ 字符串2 截取的位置 后半段随机）+字符串长度 
    /// 
    /// </summary>
    public class ClassTimeEncryptionAlgorithm
    {

        /// <summary>
        /// 系统 秘钥  用户 根据自己情况 修改 
        /// 
        ///   每个系统的时间戳 均需要一个 秘钥
        /// 
        /// </summary>
        public static string SYS_KEY = "aQMNhjki";

        /// <summary>
        /// 时间戳失效 时间 为  48 小时  
        /// </summary>
        public static long TimeHour = 48;

        /// <summary>
        /// 获得一个时间戳
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="SysPath">加密键路径</param>
        /// <returns></returns>
        public static string GetTimeID( string SysPath, string user_id)
        {
            //系统目录 存放目录
            string PathFileTimeStrOne = System.IO.Path.Combine(SysPath, "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01TimeStr.dll");


            SYS_KEY = System.IO.File.ReadAllText(PathFileTimeStrOne, System.Text.Encoding.UTF8);


            DateTime T = DateTime.Now;

            string RT = "";

          //  Random RM = new Random(Environment.TickCount);

            //之间加一个随机数
          //  string user_id = "abc" + ((int)(999*RM.NextDouble()) ).ToString("D3")   +user_id2;

            string KEY = T.Year.ToString("D4") + T.Month.ToString("D2") + T.Day.ToString("D2"); ;
            RT = EncryptString(EncryptString(user_id, KEY), SYS_KEY);
            /*
            user_id = EncryptString(EncryptString(user_id, KEY), SYS_KEY);

            //字符串 的 截取 
            int Str1_NUM = (int)((double)(user_id.Length / 2) * RM.NextDouble());
            int Str2_NUM = user_id.Length / 2 + (int)((double)(user_id.Length / 2) * RM.NextDouble());

            //拆分 ID
            string Str1 = user_id.Substring(0, Str1_NUM);
            string Str2 = user_id.Substring(Str1_NUM, Str2_NUM - Str1_NUM);
            string Str3 = user_id.Substring(Str2_NUM, user_id.Length - Str2_NUM);
            string Str123 = Str1 + " " + Str2 + " " + Str3;

            //字符字符串   前端  加上    字符串 1 +  3位毫秒  +  （2位小时+71） +  （2位秒 +17） + 字符串2 +  （2位天 +9）+ 2位随机数+  （2位月+13）+ （2位年 -1005） +字符串3 +  2位数字 （ 字符串1 截取的位置  前半段随机）+  2位数字 （ 字符串2 截取的位置 后半段随机）+字符串长度 


            RT = Str2 + Str3 + Str1;  // 1  2  3      3  1 2
            RT = RT + Str2.Length.ToString("D2"); // a10
            RT = RT + Str3.Length.ToString("D2"); // a11

            //最后 的数据 表示长度 
            RT = RT + RT.Length.ToString("D3"); // a12
            */

            string myID = GetID(  SysPath,RT);

            if (myID != user_id)
            {
                return null;   //检验算法
            }
           // string NX = Str123 + "\r\n" + myID;

            return RT;
        }


        // DES加密解密算法：
        public static string EncryptString(string sInputString, string sKey)
        {
            byte[] data = Encoding.UTF8.GetBytes(sInputString);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();  //创建其支持存储区为内存的流。
            CryptoStream cs = new CryptoStream(ms, DES.CreateEncryptor(), CryptoStreamMode.Write);//将数据流连接到加密转换流
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();  //用缓冲区的当前状态更新基础数据源或储存库，随后清除缓
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }
        // DES解密字符串
        public static string DecryptString(string sInputString, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[sInputString.Length / 2];
            for (int x = 0; x < sInputString.Length; x += 2)
            {
                int i = Convert.ToInt32(sInputString.Substring(x, 2), 16);
                inputByteArray[x / 2] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.UTF8.GetString(ms.ToArray());

        }

        /// <summary>
        /// 解码为 用户真实ID 前后 3天时间 过期
        /// </summary>
        /// <param name="RT"></param>
        /// <returns></returns>
        public static string GetID( string SysPath,string RT)
        {

            //系统目录 存放目录
            string PathFileTimeStrOne = System.IO.Path.Combine(SysPath, "USER_DIR\\SYSUSER\\SYSSET\\WeiXinBasicConfigManagement\\Main01TimeStr.dll");


            SYS_KEY = System.IO.File.ReadAllText(PathFileTimeStrOne, System.Text.Encoding.UTF8);


              DateTime n1  = DateTime.Now;
              string aa = GetID(RT, n1);
              if (aa.Length > 0)
                  return aa;


              DateTime n2 = DateTime.Now.AddDays(1);
              string aa2 = GetID(RT, n2);
              if (aa2.Length > 0)
                  return aa2;

              DateTime n3 = DateTime.Now.AddDays(-1);
              string aa3 = GetID(RT, n3);
              if (aa3.Length > 0)
                  return aa3;


              return "";
        }



        /// <summary>
        /// 解析时间戳  判断 是否 合法 
        /// </summary>
        /// <param name="user_id_time"></param>
        /// <returns></returns>
        private static string GetID(string RT ,   DateTime T)
        {
            try
            {
                string KEY = T.Year.ToString("D4") + T.Month.ToString("D2") + T.Day.ToString("D2"); ;
                string us = DecryptString(DecryptString(RT, SYS_KEY), KEY);

                return us;
            }
            catch
            {
                return "";
            }


            /*
            try
            {
                //解密 RT
                int A_a12 = int.Parse(RT.Substring(RT.Length - 3, 3)); //a12

                if (RT.Length != A_a12 + 3)
                {
                    // "字符串错误 "
                }



                string KEY = T.Year.ToString("D4") + T.Month.ToString("D2") + T.Day.ToString("D2"); ;


                int cStr1_NUM = int.Parse(RT.Substring(RT.Length - 7, 2)); //a11
                int cStr2_NUM = int.Parse(RT.Substring(RT.Length - 5, 2)); //a10

                RT = RT.Substring(0, RT.Length - 7);

                string cStr1 = RT.Substring(0, cStr1_NUM);
                string cStr2 = RT.Substring(cStr1_NUM, cStr2_NUM);
                string cStr3 = RT.Substring(cStr2_NUM + cStr1_NUM, RT.Length - cStr2_NUM - cStr1_NUM);
                string cStr123 = cStr3 + " " + cStr1 + " " + cStr2;
                string cStr1232 = cStr3 + cStr1 + cStr2;
                try
                {
                    string us =DecryptString( DecryptString(cStr1232, KEY), SYS_KEY);

                    if (us.IndexOf("abc") == 0)
                    {
                        return us.Substring(6, us.Length - 6);
                    }

                    return "";
                }
                catch
                { }

            }
            catch
            { }
            */

            return "";

        }

    }
}
