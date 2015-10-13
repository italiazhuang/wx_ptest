<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default2" Codebehind="shejiao.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1" />
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>微信聊天室</title>
     <link href= '../USER_DIR/SYSUSER/HOME/v.css' rel='stylesheet' type='text/css'>
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



        function dwd() {
            // jBox.alert("Hello 微信助手");
            jBox.alert("Hello 微信助手", '关于我们', { width: 300, height: 150 });
        }


        function d_set() {
            jBox.open("iframe:SetMyData.aspx?id=<%= GetID() %>", "微信助手-个人设置", $(window).width() * 0.9, $(window).height() * 0.6);
        }

        function d_jifen() {
            jBox.open("iframe:cmd/jifen.aspx?id=<%= GetID() %>", "微信助手-我的积分", $(window).width() * 0.9, $(window).height() * 0.6);
        }



        $(function () {


        });
        
    </script>
    <script type="text/javascript">
        function dwd2() {
            jBox.alert("Hello 2 微信助手", '关于我们', { width: 300, height: 150 });

        }  
    </script>
    <script type="text/javascript">

        var id = window.setInterval("DoIt2()", 3000);

        function DoIt2() {

            PageMethods.DoEasy("<%=GetNickX() %>" + "\r" + "W_W" + "\r", CallBack);
        }

        function DoIt() {
            var txt = document.getElementById("Text1").value;

            document.getElementById("Text1").value = "";

            PageMethods.DoEasy("<%=GetNickX() %>" + "\r" + txt + "\r", CallBack);
        }
        function CallBack(result) { //result是接收PageMethods.DoEasy的返回值
            var inTxt = document.getElementById("Text1").value;
            var txt = document.getElementById("ShowSpan");
            txt.style.display = "inline";

            txt.innerHTML = "<br/>" + result;

        } 
    </script>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <ul class="round">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td>
                        <div>
                            <asp:ScriptManager ID="sm1" runat="server" EnablePageMethods="true">
                            </asp:ScriptManager>
                            输入聊天（点击[>>]可发信私聊）：<input id="Text1" type="text" height="28px" />
                            <input id="ButtonOne" type="button" value="确定输入" onclick="DoIt()" height="28px" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="color: Black; display: none" id="ShowSpan">这里是显示内容</span>
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
