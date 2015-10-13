<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.WeiXinDataAPPIndex" Codebehind="WeiXinDataAPPIndex.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<link href="include/admin.css" rel="stylesheet" type="text/css" />   
  <script type="text/javascript">	
   function ShowTime()
   {
	  var dt = new Date();
	  var temp = dt.getFullYear() + "年" + ( dt.getMonth() + 1) + "月" + dt.getDate() + "日";
	  temp += " " + dt.getHours() + ": " ;
	  if(dt.getMinutes()<10)
	  {
	     temp += "0";
	  }
	  temp += dt.getMinutes() + ": ";
	  if(dt.getSeconds()<10)
	  {
		temp += "0";
	  }
	  temp += dt.getSeconds() + "&nbsp;";		 
	  document.all("TimeSpan").innerHTML = temp;
	  window.setTimeout("ShowTime()",1000)
   }
   function winOnLoad()
   {
      ShowTime();
   	  window.setTimeout("ShowTime()",1000)
   }
  </script>
</head>
<body onload="winOnLoad();">
<div class="main-box">
	<div class="head-dark-box">
		欢迎使用
	</div>
	<div class="body-box">
		<span class="red"></span> 您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
		<p>请点击左侧菜单进行操作.</p>
	</div>

       <link rel="stylesheet" type="text/css" href="./img2/stylet.css">
    <div class="Menu">
            <div class="MenuBox2">
                <div class="contab" style="display: block;">
                    <a href="MobileSiteFramework.aspx" class="Red">
                        <img src="./img2/5.jpg"><span>框架设置</span><span class="shuoming">微网站平台主体框架设置</span>
                    </a>
                    <a href="MobileSiteHomeEditor.aspx" class="Red">
                        <img src="./img2/jn.jpg"><span>主页设置</span><span class="shuoming">微网站平台主页设置</span>
                    </a>
                    <a href="MobileSiteCssEditor.aspx" class="Red">
                        <img src="./img2/9.jpg"><span>样式设置</span><span class="shuoming">微网站样式表设置</span>
                    </a> 

                     <a href="GraphicTxtTemplateManagement.aspx" class="Red">
                        <img src="./img2/9.jpg"><span>图文页设置</span><span class="shuoming">微网站图文页内容设置</span>
                    </a> 

                                 <a href="MobileSitePagesManagement.aspx" class="Red">
                        <img src="./img2/3.jpg"><span>页面管理</span><span class="shuoming">微网站平台内容页设置</span>
                    </a>
                    <a href="MobileSitePicturesManagement.aspx" class="Red">
                        <img src="./img2/0.jpg"><span>图库管理</span><span class="shuoming">管理微网站平台上各种图片照片</span>
                    </a> 

                </div>
            </div>
        </div>

     <form id="weweixin_form" runat="server">
    <div>
    
    </div>
    </form>
</div>
</body>
</html>