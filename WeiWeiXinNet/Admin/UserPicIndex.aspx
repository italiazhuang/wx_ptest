<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.UserPicIndex" Codebehind="UserPicIndex.aspx.cs" %>
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
                    


                     <a href="UserInformationManagement.aspx" class="Red">
                        <img src="./img2/1.jpg"><span>用户信息</span><span class="shuoming">用户信息在微信平台上的各种信息</span>
                    </a>
                    
                    <a href="WeiXinUserToMe.aspx" class="Red">
                        <img src="./img2/fs.jpg"><span>反馈统计</span><span class="shuoming">统计用户对于本微信的意见和建议</span>
                    </a> 




                    <a href="qrcode.htm" class="Red">
                        <img src="./img2/qrcode.png"><span>二维码生成</span><span class="shuoming">将需要推广的URL生成QR二维码</span>
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