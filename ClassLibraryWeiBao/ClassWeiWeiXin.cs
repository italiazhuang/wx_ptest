using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;     //包含正则表达式

namespace ClassLibraryWeiBao
{
 public    class ClassWeiWeiXin
    {

     /// <summary>
     ///  判断 含 http://  https:// 时 直接返回 不包含的时候 合成本地路径
     /// </summary>
     /// <param name="path1"></param>
     /// <param name="host"></param>
     /// <returns></returns>
     public static string GetUrlPath(string path1, string host)
     {
         if (path1.ToLower().IndexOf("http:") >= 0)
             return path1;

         if (path1.ToLower().IndexOf("https:") >= 0)
             return path1;

         string npath = "http://" +( host + path1).Replace("//","/");

         return npath;

     }

        /// <summary>
        /// 获取 文件名 去掉扩展名
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileName(string filepath)
        {
            try
            {
                System.IO.FileInfo FileN = new System.IO.FileInfo(filepath);

                string name = FileN.Name.Remove(FileN.Name.LastIndexOf("."));

                return name;
            }
            catch
            {
                System.IO.FileInfo FileN = new System.IO.FileInfo(filepath);

                string name = FileN.Name;

                return name;
            }


        }

        /// <summary>
        /// 获取 文件名 去掉扩展名
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileName(   System.IO.FileInfo FileN )
        {
            try
            {
            

                string name = FileN.Name.Remove(FileN.Name.LastIndexOf("."));

                return name;
            }
            catch
            {
               
                string name = FileN.Name;

                return name;
            }


        }


     
     public static string NoHTML(string Htmlstring) //去除HTML标记
      {
          //删除脚本
          Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
          //删除HTML
          Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

          Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
          Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

          Htmlstring.Replace("<", "");
          Htmlstring.Replace(">", "");
          Htmlstring.Replace("\r\n", " ");
          

          return Htmlstring;
      }



    }
}
