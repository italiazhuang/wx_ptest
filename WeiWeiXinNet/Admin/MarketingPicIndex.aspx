<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.MarketingPicIndex" Codebehind="MarketingPicIndex.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<link href="include/admin.css" rel="stylesheet" type="text/css" />  
  
</head>
<body  >
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
                    <a href="CheckOnWorkAttendanceEdit.aspx" class="Red">
                        <img src="./img2/c.jpg"><span>签到设置</span><span class="shuoming">微信平台签到设置</span>
                    </a><a href="MicroWallManagement.aspx" class="Red">
                        <img src="./img2/2.jpg"><span>微墙设置</span><span class="shuoming">微信平台微墙复设置</span>
                    </a><%--<a href="AirQualityData.aspx" class="Red">
                        <img src="./img2/88.jpg"><span>PM2.5获取</span><span class="shuoming">微信平台PM2.5信息获取</span>
                    </a><a href="TodayinHistoryEdit.aspx" class="Red">
                        <img src="./img2/77.jpg"><span>历史上的今天</span><span class="shuoming"> 微信平台历史上的今天信息获取</span>
                    </a>
                    <a href="EveryDayEnglishData.aspx" class="Red">
                        <img src="./img2/h.jpg"><span>每日英语</span><span class="shuoming">微信平台每日语音信息获取</span>
                    </a>--%><a href="MicroPhotoManagement.aspx" class="Red">
                        <img src="./img2/bgc.jpg"><span>微相册</span><span class="shuoming"> 微信平台微相册管理</span>
                    </a>

                    <a href="SongManagement.aspx" class="Red">
                        <img src="./img2/5.jpg"><span>音乐台</span><span class="shuoming"> 微信平台在线音乐管理</span>
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