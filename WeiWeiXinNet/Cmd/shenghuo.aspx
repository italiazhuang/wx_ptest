<%@ Page Language="C#" AutoEventWireup="true" Inherits="shenghuo" Codebehind="shenghuo.aspx.cs" %>
<!DOCTYPE html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>信息墙</title>
	<link href="Styles/Style.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="Pink/jquery.mobile-1.4.2.min.css">
    <script src="Pink/jquery.js"></script>
    <script src="Pink/jquery.mobile-1.4.2.min.js"></script>
    <link id="skin" rel="stylesheet" href="Pink/jbox.css" />
    <script type="text/javascript" src="Pink/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Pink/jquery.jBox.src.js"></script>
    <script type="text/javascript">
        var _jBoxConfig = {};
        _jBoxConfig.defaults = {
            id: null,
            top: '15%',
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
        function d_weixinqiang() {
            jBox.open("iframe:cmd/weixinqiang.aspx?id=<%= GetIDX() %>", "微信助手-微信墙", $(window).width() * 0.96, $(window).height() * 0.6);
        }
    </script>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <% = GetID()%>
    </div>
    </form>
</body>
</html>
