<%@ Page Language="C#" AutoEventWireup="true" Inherits="wode" Codebehind="wode.aspx.cs" %>
<!DOCTYPE html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title></title>
	<link href="Styles/Style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <ul class="round">
            <li class="title">我的个人信息 </li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tbody>
                    <tr align="center">
                        <td>
                            <a href="SetMyData.aspx?id=<%= GetID() %>">个人设置</a>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <a href="jifen.aspx?id=<%= GetID() %>">我的积分</a>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <a href="sixin.aspx?id=<%= GetID() %>">我的私信</a>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <a href="yijian.aspx?id=<%= GetID() %>">意见反馈</a>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <a  href="about.aspx?id=<%= GetID() %>">关于我们</a>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <a href="shangcheng.aspx?id=<%= GetID() %>">微商店</a>
                        </td>
                    </tr>

                      <tr align="center">
                        <td>
                            <a href="dingdan.aspx?id=<%= GetID() %>">我的订单</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
<%-- 版权所有 udoo123.taobao.com--%>