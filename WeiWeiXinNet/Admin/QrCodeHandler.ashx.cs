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
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace WeiWeiXinNet.admin
{
	/// <summary>
	/// 
    /// 
    /// QR二维码生成
    /// 
    /// 
    /// 
	/// </summary>
	public class QrCodeHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			// Retrieve the parameters from the QueryString
			var codeParams = CodeDescriptor.Init(context.Request);

			// Encode the content
			if (codeParams == null || !codeParams.TryEncode())
			{
				context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
				return;
			}

			// Render the QR code as an image
			using (var ms = new MemoryStream())
			{
				codeParams.Render(ms);
				context.Response.ContentType = codeParams.ContentType;
				context.Response.OutputStream.Write(ms.GetBuffer(), 0, (int) ms.Length);
			}
		}

		/// <summary>
		/// Return true to indicate that the handler is thread safe because it is stateless
		/// </summary>
		public bool IsReusable
		{
			get { return true; }
		}
	}

	/// <summary>
	/// Class containing the description of the QR code and wrapping encoding and rendering.
	/// </summary>
	internal class CodeDescriptor
	{
		public ErrorCorrectionLevel Ecl;
		public string Content;
		public QuietZoneModules QuietZones;
		public int ModuleSize;
		public BitMatrix Matrix;
		public string ContentType;

		/// <summary>
		/// Parse QueryString that define the QR code properties
		/// </summary>
		/// <param name="request">HttpRequest containing HTTP GET data</param>
		/// <returns>A QR code descriptor object</returns>
		public static CodeDescriptor Init(HttpRequest request)
		{
			var cp = new CodeDescriptor();

			// Error correction level
			if (!Enum.TryParse(request.QueryString["e"], out cp.Ecl))
				cp.Ecl = ErrorCorrectionLevel.L;

			// Code content to encode
			cp.Content = request.QueryString["t"];

			// Size of the quiet zone
			if (!Enum.TryParse(request.QueryString["q"], out cp.QuietZones))
				cp.QuietZones = QuietZoneModules.Two;

			// Module size
			if (!int.TryParse(request.QueryString["s"], out cp.ModuleSize))
				cp.ModuleSize = 12;

			return cp;
		}

		/// <summary>
		/// Encode the content with desired parameters and save the generated Matrix
		/// </summary>
		/// <returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>
		public bool TryEncode()
		{
			var encoder = new QrEncoder(Ecl);
			QrCode qr;
			if (!encoder.TryEncode(Content, out qr))
				return false;

			Matrix = qr.Matrix;
			return true;
		}

		/// <summary>
		/// Render the Matrix as a PNG image
		/// </summary>
		/// <param name="ms">MemoryStream to store the image bytes into</param>
		internal void Render(MemoryStream ms)
		{
			var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
			render.WriteToStream(Matrix, ImageFormat.Png, ms);
			ContentType = "image/png";
		}
	}
}