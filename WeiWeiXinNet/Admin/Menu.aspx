<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.Menu"
    CodeBehind="Menu.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function NavGoto() {

         }
     </script>

    <script type="text/javascript">
        function showMenu(menuID, obj) {
            CloseMenu(menuID);
            var menu = document.getElementById(menuID);
            var target = obj;
            if (document.all)
                d = menu.currentStyle.display;
            else
                d = document.defaultView.getComputedStyle(menu, null).getPropertyValue("display");
            if (d != "block") {
                menu.style.display = "block";
                target.style.backgroundImage = "url(images/min.gif)";
            }
            else {
                menu.style.display = "none";
                target.style.backgroundImage = "url(images/max.gif)";
            }
        }

        function CloseMenu(menuID) {
            for (var i = 0; i <= 8; i++) {
                if (menuID != 'menu' + i.toString()) {
                    var menu = document.getElementById("menu" + i.toString());
                    menu.style.display = "none";
                    var a = document.getElementById("a" + i.toString());
                    a.style.backgroundImage = "url(images/max.gif)";
                }
            }
        }
    </script>
</head>
<body>
    <div id="menu-box">
        <div class="menu">
            <div class="menu-head">
                <a href='WeiXinBasicManagement.aspx' id="a0" target="main" onclick="showMenu('menu0',this)">微信基础设置</a>
            </div>
            <ul id="menu0">
                <li><a href='WeiXinBasicConfigManagement.aspx' target="main">基础设置</a></li>
                <li><a href='WeiXinMenuEditor.aspx' target="main">菜单设置</a></li>
                <li><a href='WeiXinBasicNewsEditor.aspx' target="main">图文回复设置</a></li>
                <li><a href='WeiXinBasicNewsEditorT.aspx' target="main">文本回复设置</a></li>
                 <li><a href='WeiXinBasicNewsEditorL.aspx' target="main">LBS位置回复</a></li>
                <li><a href='WeiXinBasicNewsEditorV.aspx' target="main">音频回复设置</a></li>
                <li><a href='WeiXinBasicNewsEditorZ.aspx' target="main">关键词转向</a></li>
                <li><a href='ImgDataBase.aspx' target="main">图片素材管理</a></li>
                <li><a href='VocDataBase.aspx' target="main">音频素材管理</a></li>

            </ul>
        </div>
        <div class="menu">
            <div class="menu-head">
                <a href='MarketingPicIndex.aspx' id="a1" target="main" onclick="showMenu('menu1',this)">微应用设置</a>
            </div>
            <ul id="menu1">
                <li><a href='CheckOnWorkAttendanceEdit.aspx' target="main">签到设置</a></li>
                <li><a href='MicroWallManagement.aspx' target="main">微墙管理</a></li>
                <li><a href='MicroPhotoManagement.aspx' target="main">微相册</a></li>
                <li><a href='SongManagement.aspx' target="main">音乐台</a></li>

               <%-- <li><a href='SongManagement.aspx' target="main">客服机器人</a></li>--%>

            </ul>
        </div>
        <div class="menu">
            <div class="menu-head">
                <a href='UserPicIndex.aspx' target="main" id="a2" onclick="showMenu('menu2',this)">微营销设置</a>
            </div>
            <ul id="menu2">
                <li><a href='UserInformationManagement.aspx' target="main">用户信息</a></li>
                <li><a href='WeiXinUserToMe.aspx' target="main">反馈统计</a></li>
                <li><a href='qrcode.htm' target="main">二维码生成</a></li>

                 <li><a href='Turntable.aspx' target="main">大转盘</a></li>
                  <li><a href='LotteryTicket.aspx' target="main">刮刮卡</a></li>
                   <li><a href='Coupons.aspx' target="main">优惠劵</a></li>


            </ul>
        </div>
        <div class="menu">
            <div class="menu-head">
                <a href='WeiXinDataAPPIndex.aspx' target="main" id="a3" onclick="showMenu('menu3',this)">微网站管理</a>
            </div>
            <ul id="menu3">
                <li><a href='MobileSiteFramework.aspx' target="main">框架设置</a></li>
                <li><a href='MobileSiteHomeEditor.aspx' target="main">主页设置</a></li>
                <li><a href='MobileSiteCssEditor.aspx' target="main">样式设置</a></li>
                <li><a href='MainNews.aspx' target="main">图文页设置</a></li>
                <li><a href='MobileSitePagesManagement.aspx' target="main">页面管理</a></li>
                <li><a href='MobileSitePicturesManagement.aspx' target="main">图库管理</a></li>
            </ul>
        </div>
        <div class="menu">
            <div class="menu-head">
                <a href='MyTableAPPIndex.aspx' target="main" id="a4" onclick="showMenu('menu4',this)">微数据表单</a>
            </div>
            <ul id="menu4">
                <li><a href='MyTableAppEditor.aspx' target="main">我的表单</a></li>
                <li><a href='MyTableAppResManagement.aspx' target="main">表单素材管理</a></li>
            </ul>
        </div>

           <%--   <div class="menu">
            <div class="menu-head">
                <a href='Main31ANI.aspx' target="main" onclick="showMenu('menu10',this)">微动画管理</a>
            </div>
            <ul id="menu10">
                <li><a href='Main32ANI.aspx' target="main">我的动画</a></li>
                <li><a href='Main32ANIDATA.aspx' target="main">动画素材管理</a></li>
            </ul>
        </div>
--%>
        <div class="menu">
            <div class="menu-head">
                <a href='ShopDataAPPIndex.aspx' target="main" id="a5" onclick="showMenu('menu5',this)">微商店管理</a>
            </div>
            <ul id="menu5">
                <li><a href='MainGoods.aspx' target="main">商品管理</a></li>
                <li><a href='ShopOrdersManagement.aspx' target="main">当前订单管理</a></li>
                <li><a href='ShopOKOrdersManagement.aspx' target="main">历史订单管理</a></li>
            </ul>
        </div>

        <div class="menu" runat="server">
            <div class="menu-head">
                <a href='#' id="a6" onclick="javascript:window.open('../WeiWebSIM.aspx','newwindow','width=400,height=620,scrollbars=yes,top=10,left=10');">
                    微网站模拟器</a>
            </div>
            <ul id="menu6">
            </ul>
        </div>
        <div class="menu">
            <div class="menu-head">
                <a href='#' id="a7" onclick="javascript:window.open('../weixinsim.aspx','newwindow','width=400,height=620,scrollbars=yes,top=10,left=10');">
                    微信模拟器</a>
            </div>
            <ul id="menu7">
            </ul>
        </div>
        <!--
        <div class="menu">
            <div class="menu-head">
                <a href='Main32n.aspx' target="main" onclick="showMenu('menu9',this)">备用代码</a>
            </div>
            <ul id="menu9">
                <li><a href='AirQualityData.aspx' target="main">PM2.5获取</a></li>
                <li><a href='TodayinHistoryEdit.aspx' target="main">历史上的今天</a></li>
                <li><a href='EveryDayEnglishData.aspx' target="main">每日英语</a></li>
                <li><a href='Main11.aspx' target="main">大转盘 </a></li>
                <li><a href='Main12.aspx' target="main">刮刮卡  </a></li>
                <li><a href='MainEditImg.aspx' target="main">图片编辑 </a></li>
                <li><a href='MainVoiceMag.aspx' target="main">在线录音 </a></li>
                <li><a href='player/index.html' target="main">在线播放</a></li>
            </ul>
        </div>
        -->
        <div class="menu">
            <div class="menu-head">
                <a href='SystemAPPIndex.aspx' target="main" id="a8" onclick="showMenu('menu8',this)">系统操作</a>
            </div>
            <ul id="menu8">
                <li><a href='AboutWeWeiXinNet.aspx' target="main">关于我们</a></li>
                <li><a href='ChangePassword.aspx' target="main">修改密码</a></li>
                 <li><a href='WebFormSecurity.aspx' target="main">安全检测</a></li>
                <li><a href='clear.aspx' target="main" onclick='top.location.href = "clear.aspx";'>退出登陆</a></li>
                <li><a href="https://mp.weixin.qq.com/" target="_blank">微信后台管理</a></li>
                <li><a href="http://udoo123.taobao.com/" target="_blank">寻找更新版本</a> </li>
            </ul>
        </div>

        <div class="menu">
            <div class="menu-head">
                <a href="http://udoo123.taobao.com/" target="_blank"> 系统更新</a>
            </div>
            
        </div>

    </div>
</body>
</html>
