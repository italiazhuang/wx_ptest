<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_yijian" Codebehind="YiJian.aspx.cs" %>
<!DOCTYPE html>
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
			<li class="title">意见反馈</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tbody>
                    <tr>
                        <td>
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="状态"></asp:Label>
                                <br />
                                需要反馈处理的意见请留下QQ或电话等联系方式，我们会及时和您联系
                                <br />
                                <asp:TextBox ID="WeTextBoxOne" runat="server" style="height:90px" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                <br />
                                <asp:Button ID="ButtonOne" runat="server" Height="31px" OnClick="ButtonOne_Click" Text="发送" CssClass="submit2" Style="width:100%;border-radius: 5px 5px; height: 48px;"/>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
