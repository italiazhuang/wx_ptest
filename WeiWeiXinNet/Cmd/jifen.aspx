<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_jifen" Codebehind="JiFen.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href= 'Styles/Style.css' rel='stylesheet' type='text/css'>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <ul class="round">
            <li class="title">我的积分</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td style="word-wrap:break-word;">
                        <% =GetDATA()%>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
