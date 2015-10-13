<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.SystemAPPIndex" Codebehind="SystemAPPIndex.aspx.cs" %>
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

                


               
                    
                    <a href="AboutWeWeiXinNet.aspx" class="Red">
                        <img src="./img2/fs.jpg"><span>关于我们</span><span class="shuoming">微信平台程序版本及联系方式</span>
                    </a> 

                        <a href="ChangePassword.aspx" class="Red">
                        <img src="./img2/wav.jpg"><span>修改密码</span><span class="shuoming">修改用户密码</span>
                    </a> 

                        <a href='clear.aspx' target="main" onclick='top.location.href = "clear.aspx" ;'  class="Red">
                        <img src="./img2/11.jpg"><span>退出登录</span><span class="shuoming">退出系统登录</span>
                    </a> 

                          <a href='https://mp.weixin.qq.com/' target="main" onclick='top.location.href = "clear.aspx" ;'  class="Red">
                        <img src="./img2/11.jpg"><span>微信后台管理</span><span class="shuoming">登录微信官方后台</span>
                    </a> 


                             <a href='https://udoo123.taobao.com/' target="main" onclick='top.location.href = "clear.aspx" ;'  class="Red">
                        <img src="./img2/11.jpg"><span>寻找新版本</span><span class="shuoming">登陆WeWeiXin.NET官网</span>
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