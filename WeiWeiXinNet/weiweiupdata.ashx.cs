 
using System;
using System.Web;

public class weiweiupdata : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

        //读取的时候
        HttpCookie cookie2 = context.Request.Cookies["weiweixing"];

        if (cookie2 == null)
        {
            context.Response.Redirect("login.aspx");
            return;
        }

        string name = cookie2.Values["name"];
        if (name == null)
        {
            context.Response.Redirect("login.aspx");
            return;
        }

        string md5 = cookie2.Values["md5"];
        if (md5 == null)
        {
            context.Response.Redirect("login.aspx");
            return;
        }
        
        

        //   context.Response.ContentType = "text/plain";
        //   context.Response.Write("Hello World"); Response.Write("<br />" + Request.Files[0].FileName);

        string Path1 = context.Server.MapPath("~");
        string Path2 = context.Server.MapPath(".");

        string host = context.Request.ServerVariables["HTTP_HOST"] + context.Request.ServerVariables["PATH_INFO"];

        host = host.Replace("weiweiupdata.ashx", "");

        // "http://" + host + "/WebSurvey/m.aspx";

        try
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];

            if (uploads == null || CKEditorFuncNum == null)
            {
                return;
            }

            string PathDir = System.IO.Path.Combine(context.Server.MapPath("."), "USER_DIR\\IMGUP");

            if (System.IO.Directory.Exists(PathDir) == false)
            {   //建立图片目录
                System.IO.Directory.CreateDirectory(PathDir);

            }


            string fex = uploads.ContentType.ToLower();

            DateTime cc = DateTime.Now;
            string NewName = cc.Year.ToString("D2") + cc.Month.ToString("D2") + cc.Day.ToString("D2") + cc.Hour.ToString("D2") + cc.Minute.ToString("D2") + cc.Second.ToString("D2") + cc.Millisecond.ToString("D3");

            string NewNameFull = "";// System.IO.Path.Combine(PathDir2, NWS + ".TXT");

            if (fex.IndexOf("jpg") > 0 || fex.IndexOf("jpeg") > 0)
            {
                NewNameFull = (NewName + ".jpg");
            }
            else if (fex.IndexOf("png") > 0)
            {
                NewNameFull = (NewName + ".png");
            }
            else if (fex.IndexOf("gif") > 0)
            {
                NewNameFull = (NewName + ".gif");
            }
            else if (fex.IndexOf("bmp") > 0)
            {
                NewNameFull = (NewName + ".bmp");
            }
            else if (fex.IndexOf("swf") > 0)
            {
                NewNameFull = (NewName + ".swf");
            }
            else
            {

                context.Response.Write("<script type=\"text/javascript\">");
                context.Response.Write("window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ",''," + "'文件格式不正确（必须为.jpg/.gif/.bmp/.png文件）');");
                context.Response.Write("</script>");
                context.Response.End();
            }


            // string file = System.IO.Path.GetFileName(uploads.FileName);
            uploads.SaveAs(System.IO.Path.Combine(PathDir, NewNameFull)); ;//context.Server.MapPath(".") + "\\Images\\" + file);
            string url = "http://" + host + "" + "USER_DIR/IMGUP/" + NewNameFull;




            string fileName = url, errMsg = "";
            context.Response.Write(String.Format("<script type=\"text/javascript\">window.parent.CKEDITOR.tools.callFunction({0}, '{1}', '{2}');</script>",
                context.Request.QueryString["CKEditorFuncNum"],
                fileName,
                errMsg));

           
        }
        catch
        {
            string fileName, errMsg = "上传错误: '请重新上传图片'";
            fileName = "";
            errMsg = errMsg.Replace("'", "\\'");
            context.Response.Write(String.Format("<script type=\"text/javascript\">window.parent.CKEDITOR.tools.callFunction({0}, '{1}', '{2}');</script>",
                context.Request.QueryString["CKEditorFuncNum"],
                fileName,
                errMsg));

            context.Response.Write("");
            context.Response.End();
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}