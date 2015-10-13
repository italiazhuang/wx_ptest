<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_weixinqiang" Codebehind="WeiXinQiang.aspx.cs" %>

<!DOCTYPE html>
<head runat="server">
	<link href="Styles/Style.css" rel="stylesheet" type="text/css">
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
			<li class="title">微信墙 : 发布信息到微信墙(8-136字)</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td>
                        <asp:TextBox ID="WeTextBoxOne" runat="server" Style="border-radius: 5px 5px;height:120px" MaxLength="136" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button ID="ButtonOne" runat="server" Text="发布" OnClick="ButtonOne_Click" Style="width:100%;border-radius: 5px 5px; height: 48px;" CssClass="submit2"/>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
