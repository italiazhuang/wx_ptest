<%@ Page Language="C#" AutoEventWireup="true" Inherits="shouye" Codebehind="shouye.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href= 'css/v.css' rel='stylesheet' type='text/css'> 
	<link rel="stylesheet" href="Pink/jquery.mobile-1.4.2.min.css">
    <script src="Pink/jquery.js"></script>
    <script src="Pink/jquery.mobile-1.4.2.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>微微信.NET</title>
    <link id="skin" rel="stylesheet" href="Pink/jbox.css" />
    <script type="text/javascript" src="Pink/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Pink/jquery.jBox.src.js"></script>
    <script type="text/javascript">
        var _jBoxConfig = {};
        _jBoxConfig.defaults = {
            id: null,
            top: '10px',
            border: 5,
            opacity: 0.2,
            timeout: 0,
            showType: 'fade',
            showSpeed: 'fast',
            showIcon: true,
            showClose: true,
            draggable: true,
            dragLimit: true,
            dragClone: false,
            persistent: true,
            showScrolling: true,
            ajaxData: {},
            iframeScrolling: 'auto',

            title: 'jBox',
            width: 350,
            height: 'auto',
            bottomText: '',
            buttons: { '确定': 'ok' },
            buttonsFocus: 0,
            loaded: function (h) { },
            submit: function (v, h, f) { return true; },
            closed: function () { }
        };
        _jBoxConfig.stateDefaults = {
            content: '',
            buttons: { '确定': 'ok' },
            buttonsFocus: 0,
            submit: function (v, h, f) { return true; }
        };
        _jBoxConfig.tipDefaults = {
            content: '',
            icon: 'info',
            top: '40%',
            width: 'auto',
            height: 'auto',
            opacity: 0,
            timeout: 2000,
            closed: function () { }
        };
        _jBoxConfig.messagerDefaults = {
            content: '',
            title: 'jBox',
            icon: 'none',
            width: 350,
            height: 'auto',
            timeout: 3000,
            showType: 'slide',
            showSpeed: 600,
            border: 0,
            buttons: {},
            buttonsFocus: 0,
            loaded: function (h) { },
            submit: function (v, h, f) { return true; },
            closed: function () { }
        };
        _jBoxConfig.languageDefaults = {
            close: '关闭',
            ok: '确定',
            yes: '是',
            no: '否',
            cancel: '取消'
        };

        $.jBox.setDefaults(_jBoxConfig);



        function dwd() {
            // jBox.alert("Hello 微信助手");
            jBox.alert("Hello 微信助手", '关于我们', { width: 300, height: 150 });
        }


        function d_qiandao() {
            jBox.open("iframe:cmd/qiandao.aspx?id=<%= GetID() %>", "微信助手-每日签到", $(window).width() * 0.96, $(window).height() * 0.6);
        }

        function d_diancan() {
          jBox.open("iframe:cmd/shangcheng.aspx?id=<%= GetID() %>", "微信助手-美食点餐", $(window).width() * 0.96, $(window).height() * 0.7);
        }

        function d_jifen() {
            jBox.open("iframe:cmd/jifen.aspx?id=<%= GetID() %>", "微信助手-我的积分", $(window).width() * 0.96, $(window).height() * 0.6);
        }

        function d_rengpingzi() {
            jBox.open("iframe:cmd/rengpingzi.aspx?id=<%= GetID() %>", "微信助手-漂流瓶", $(window).width() * 0.96, $(window).height() * 0.6);
        }

        function d_shoupingzi() {
            jBox.open("iframe:cmd/shoupingzi.aspx?id=<%= GetID() %>", "微信助手-漂流瓶", $(window).width() * 0.96, $(window).height() * 0.6);
        }

        function d_sixin() {
            jBox.open("iframe:cmd/sixin.aspx?id=<%= GetID() %>", "微信助手-我的私信", $(window).width() * 0.96, $(window).height() * 0.7);
        }


        function d_weixinqiang() {
            jBox.open("iframe:cmd/weixinqiang.aspx?id=<%= GetID() %>", "微信助手-微信墙", $(window).width() * 0.96, $(window).height() * 0.6);
        }


        function d_xiaomeng() {
            jBox.open("iframe:cmd/xiaomeng.aspx?id=<%= GetID() %>", "微信助手-小萌英文聊天", $(window).width() * 0.96, $(window).height() * 0.45);
        }


        function d_youxi() {
            jBox.open("iframe:cmd/youxi.aspx?id=<% =GetID() %>", "微信助手-游戏", $(window).width() * 0.96, $(window).height() * 0.6);
        }


        $(function () {


        });
        
    </script>
</head>
<body style="margin: 0; padding: 0">
    <form id="form2" runat="server">
    <div class="cardexplain">
        <ul class="round">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="6">
                <tr>
                    <td colspan="3">
                        <p>
                            <strong>银川空气质量：</strong><%=GetPM25()%></p>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <p>
                            <strong>今日英语：</strong><audio src=" <%=GetENDAYMP3().Trim()%>"></audio><%=GetENDAY().Trim()%>
                        </p>
                    </td>
                </tr>
                <tr align="center">
                    <td width="32%" height="79">
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_qiandao();" href="#">
                                        <img src="imgx/4.png" width="60" height="60" />
                                    </a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_qiandao();" href="#">签到 </a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="37%">
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_jifen();" href="#">
                                        <img src="imgx/11.png" alt="" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_jifen();" href="#">积分</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="31%">
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_weixinqiang();" href="#">
                                        <img src="imgx/2.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_weixinqiang();" href="#">微信墙</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_shoupingzi();" href="#">
                                        <img src="imgx/15.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_shoupingzi();" href="#">收瓶子</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_rengpingzi();" href="#">
                                        <img src="imgx/10.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_rengpingzi();" href="#">扔瓶子</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_sixin();" href="#">
                                        <img src="imgx/5.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_sixin();" href="#">私信</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_youxi();" href="#">
                                        <img src="imgx/3.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_youxi();" href="#">游戏</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_xiaomeng();" href="#">
                                        <img src="imgx/9.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_xiaomeng();" href="#">小萌</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr align="center">
                                <td>
                                    <a onclick="d_diancan();" href="#">
                                        <img src="imgx/1.png" width="60" height="60" /></a>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <a onclick="d_diancan();" href="#">微商店<a onclick="demo04();" href="#">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
