<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.MyTableAPPIndex" Codebehind="MyTableAPPIndex.aspx.cs" %>
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
		<p>微表单是一套类似于金数据的网络万能表单系统，管理员可以编制任意表单，用户填写后，可以在 《表单结果收集》 处查看用户填写结果</p>
	</div>

       <link rel="stylesheet" type="text/css" href="./img2/stylet.css">
    <div class="Menu">
            <div class="MenuBox2">
                <div class="contab" style="display: block;">

                <a href="MyTableAppEditor.aspx" class="Red">
                        <img src="./img2/fs.jpg"><span>我的表单</span><span class="shuoming">建立、浏览、管理用户建立的表单</span>
                    </a> 


                    <a href="MyTableAppResManagement.aspx" class="Red">
                        <img src="./img2/1.jpg"><span>表单结果收集</span><span class="shuoming">表单填写结果收集</span>
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