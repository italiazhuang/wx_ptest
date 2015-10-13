<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_sixin" Codebehind="SiXin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
	<link href= 'Styles/Style.css' rel='stylesheet' type='text/css'>
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <ul class="round">
			<li class="title">我的私信</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td>
                        私信 &nbsp;
                        <asp:Button ID="ButtonOne" runat="server" Text="收信" Height="28px" OnClick="ButtonOne_Click"  Width="60px" />
                        &nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" Width="30%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Button ID="ButtonFour" runat="server" OnClick="ButtonFour_Click" Text="阅读" Visible="False" Width="60px" Style="height: 28px" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Text="ADD" Visible="False"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="NICK" Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="输入:" Visible="False"></asp:Label>
                        <asp:TextBox ID="WeTextBoxTwo" runat="server" Width="55%" Visible="False" Style="height: 28px"></asp:TextBox>
                        <asp:Button ID="ButtonThree" runat="server" Width="50px" Text="回复" Visible="False" OnClick="Button3_Click1"
                            Style="height: 28px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="WeTextBoxOne" runat="server" Height="70px" TextMode="MultiLine" Width="95%"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonTwo" runat="server" Text="删除当前信件" OnClick="ButtonTwo_Click" Visible="False"
                            Style="height: 28px" />
                        <asp:Label ID="Label1" runat="server" Text="状态"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
