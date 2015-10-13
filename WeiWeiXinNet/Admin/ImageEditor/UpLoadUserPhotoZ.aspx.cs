//----------------------------------------------------------------
// Copyright (C) 上海互联网软件有限公司
// 版权所有。 
// All rights reserved.

// 文件名：UpLoadUserPhoto
// 文件功能描述：
// 
// 
// 创建标识： 王少明
// 创建时间：  2008/9/23 15:43:24
// 修改标识：
// 修改描述：
//----------------------------------------------------------------
using System;

namespace ZoomImageDemo
{
    public partial class UpLoadUserPhotoZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            if (!string.IsNullOrEmpty(Request.QueryString["size"])) //只有尺寸 时候   2种尺寸 长方形360x200  正方形200x200
            {
                string size = Request.QueryString["size"];
                if (size.IndexOf("360x200") >= 0)
                {

                }

            }
            if (!string.IsNullOrEmpty(Request.QueryString["PicRurl"])) //网络传过来的需要编辑的图像url 保存地址  图像尺寸 
            {


                ImageDrag.ImageUrl = Request.QueryString["Picurl"];
                ImageIcon.ImageUrl = Request.QueryString["Picurl"];
                Page.ClientScript.RegisterStartupScript(typeof(UpLoadUserPhotoZ), "step2", "<script type='text/javascript'>Step2();</script>");
            }else
            if (!string.IsNullOrEmpty(Request.QueryString["Picurl"]))
            {
                ImageDrag.ImageUrl = Request.QueryString["Picurl"];
                ImageIcon.ImageUrl = Request.QueryString["Picurl"];
                Page.ClientScript.RegisterStartupScript(typeof(UpLoadUserPhotoZ), "step2", "<script type='text/javascript'>Step2();</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(UpLoadUserPhotoZ), "step1", "<script type='text/javascript'>Step1();</script>");
            }
        }
        private const string savepath = "User";

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuPhoto.PostedFile != null && fuPhoto.PostedFile.ContentLength>0)
            {
                
                string ext = System.IO.Path.GetExtension(fuPhoto.PostedFile.FileName).ToLower();
                if (ext != ".jpg" && ext != ".jepg" && ext != ".bmp" && ext != ".gif" && ext != ".png")
                {
                    return ;
                }
                string filename ="xuanye_"+DateTime.Now.ToString("yyyyMMddHHmmss")+ext;
                string path = "~/admin/ImageEditor/UploadPhoto/" + filename;
                fuPhoto.PostedFile.SaveAs(Server.MapPath(path));
                Response.Redirect("~/admin/ImageEditor/UpLoadUserPhotoZ.aspx?Picurl=" + Server.UrlEncode(path));
            }
            else
            {
                //do some thing;
            }
        }

        protected void btn_Image_Click(object sender, EventArgs e)
        {
            int imageWidth = Int32.Parse(txt_width.Text);
            int imageHeight = Int32.Parse(txt_height.Text);
            int cutTop = Int32.Parse(txt_top.Text);
            int cutLeft = Int32.Parse(txt_left.Text);
            int dropWidth = Int32.Parse(txt_DropWidth.Text);
            int dropHeight = Int32.Parse(txt_DropHeight.Text);

            string  IPATH =  Server.MapPath(savepath);

            string filename = CutPhotoHelp.SaveCutPic(Server.MapPath(ImageIcon.ImageUrl), IPATH, 0, 0, dropWidth,
                                    dropHeight, cutLeft, cutTop, imageWidth, imageHeight);

            this.imgphoto.ImageUrl = "~/admin/ImageEditor/User/" + filename;
            Page.ClientScript.RegisterStartupScript(typeof(UpLoadUserPhotoZ), "step3", "<script type='text/javascript'>Step3();</script>");
        }
    }
}
