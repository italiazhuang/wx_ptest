<%@ Page Language="C#" AutoEventWireup="true" Inherits="send_xin" Codebehind="send_xin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href= '../USER_DIR/SYSUSER/HOME/v.css' rel='stylesheet' type='text/css'>
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
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="昵称"></asp:Label>
                            &nbsp;<asp:Label ID="Label2" runat="server" Text="性别"></asp:Label>
                            &nbsp;<asp:Label ID="Label3" runat="server" Text="学院"></asp:Label>
                            &nbsp;
                            <asp:Label ID="Label6" runat="server" Text="XXX" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="输入:"></asp:Label>
                            <asp:TextBox ID="WeTextBoxOne" Height="28px" runat="server" Width="80%"></asp:TextBox>
                            <br />
                            <p align="center">
                                <asp:Button align="center" ID="ButtonOne" runat="server" Height="28px" Text="发送" Width="30%"
                                    OnClick="ButtonOne_Click" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="签名"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="状态"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
