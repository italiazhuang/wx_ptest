using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassLibraryWeiBao
{
    public class ThumbnailImage
    {
        ///<summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径，含文件名）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径，含文件名）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="height">返回缩略图路径</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);


            width = 80;

            height = (80 * originalImage.Height) / originalImage.Width;



            if (originalImage.Width <= 80)
            {

                width = originalImage.Width;

                height = originalImage.Height;





            }






            int towidth = width;
            int toheight = height;

            int x = 0; //缩略图在画布上的X放向起始点
            int y = 0; //缩略图在画布上的Y放向起始点
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            int dw = originalImage.Width;
            int dh = originalImage.Height;

            if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
            {
                //宽比高大，以宽为准
                dw = originalImage.Width * towidth / originalImage.Width;
                dh = originalImage.Height * toheight / originalImage.Width;
                x = 0;
                //
                y = (toheight - dh) / 2;
            }
            else
            {
                //高比宽大，以高为准
                // 

                dw = originalImage.Width * towidth / originalImage.Height;
                dh = originalImage.Height * toheight / originalImage.Height;
                x = (towidth - dw) / 2;
                y = 0;
            }


            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以白色背景色填充
            g.Clear(Color.White);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(x, y, dw, dh),
             new Rectangle(0, 0, ow, oh),
             GraphicsUnit.Pixel);


            int ww = 0;


            try
            {
                //以Jpeg格式保存缩略图(KB最小)
                Crop1((Bitmap)bitmap).Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }



        private static Image Crop1(Bitmap bitmap)
        {
            if (bitmap.Width < bitmap.Height)
            {
                Rectangle rec = new Rectangle(0, 0, bitmap.Width, bitmap.Width);
                return bitmap.Clone(rec,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
            else
            {
                Rectangle rec = new Rectangle(0, 0, bitmap.Height, bitmap.Height);
                return bitmap.Clone(rec,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }

        }


        ///<summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径，含文件名）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径，含文件名）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="height">返回缩略图路径</param>
        public static void MakeThumbnail2(string originalImagePath, string thumbnailPath)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int width = 360;
            int height = (360 * originalImage.Height) / originalImage.Width;

            if (originalImage.Width <= 360)
            {
                width = originalImage.Width;
                height = originalImage.Height;


            }


            int towidth = width;
            int toheight = height;

            int x = 0; //缩略图在画布上的X放向起始点
            int y = 0; //缩略图在画布上的Y放向起始点
            int dw = originalImage.Width;

            int dh = originalImage.Height;

            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
            {

                //宽比高大，以宽为准

                dw = originalImage.Width * towidth / originalImage.Width;

                dh = originalImage.Height * toheight / originalImage.Width;

                x = 0;

                y = (toheight - dh) / 2;

            }

            else
            {

                //高比宽大，以高为准

                dw = originalImage.Width * towidth / originalImage.Height;

                dh = originalImage.Height * toheight / originalImage.Height;

                x = (towidth - dw) / 2;

                y = 0;

            }



            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以白色背景色填充
            g.Clear(Color.White);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(x, y, dw, dh),
             new Rectangle(0, 0, ow, oh),
             GraphicsUnit.Pixel);

            try
            {
                //以Jpeg格式保存缩略图(KB最小)
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


    }


﻿﻿

}
