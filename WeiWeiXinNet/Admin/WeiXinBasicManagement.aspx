<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicManagement" CodeBehind="WeiXinBasicManagement.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="./img2/stylet.css">
 
</head>
<body  >
    <div class="main-box">
        <div class="head-dark-box">微信基础设置:请点击左侧菜单进行操作</div>
        <div class="body-box">
            <div class="white-box">
                <span class="red"></span>您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
            </div>
        </div>
        <div class="Menu">
            <div class="MenuBox2">
                <div class="contab" style="display: block;">
                    <a href="WeiXinBasicConfigManagement.aspx" class="Red">
                        <img src="./img2/6.jpg"><span>基础设置</span><span class="shuoming">微信平台基础设置</span>
                    </a>
                    <a href="WeiXinMenuEditor.aspx" class="Red">
                        <img src="./img2/h.jpg"><span>菜单设置</span><span class="shuoming">针对服务和认证平台的菜单设置模块</span>
                    </a>
                    <a href="WeiXinBasicNewsEditor.aspx" class="Red">
                        <img src="./img2/bgc.jpg"><span>图文回复设置</span><span class="shuoming">微信平台自动图文回复设置</span>
                    </a>
                    <a href="WeiXinBasicNewsEditorT.aspx" class="Red">
                        <img src="./img2/8.jpg"><span>文本回复设置</span><span class="shuoming">微信平台文本回复设置</span>
                    </a>
                    <a href="WeiXinBasicNewsEditorV.aspx" class="Red">
                        <img src="./img2/7c.jpg"><span>语音回复设置</span><span class="shuoming"> 微信平台语音回复设置</span>
                    </a>
                    <a href="WeiXinBasicNewsEditorZ.aspx" class="Red">
                        <img src="./img2/dd.jpg"><span>关键词转向</span><span class="shuoming"> 设置关键词指向一个设置好关键词</span>
                    </a>
                    <a href="WeiXinBasicNewsEditorL.aspx" class="Red">
                        <img src="./img2/q.jpg"><span>LSB位置回复</span><span class="shuoming"> 设置根据用户发送的位置信息来反馈结果</span>
                    </a>
                    <a href="ImgDataBase.aspx" class="Red">
                        <img src="./img2/bgc.jpg"><span>图片素材管理</span><span class="shuoming"> 管理本类别设置中的图片素材</span>
                    </a>
                    <a href="VocDataBase.aspx" class="Red">
                        <img src="./img2/88.jpg"><span>音频素材管理</span><span class="shuoming"> 管理本类别设置中的音频素材</span>
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
