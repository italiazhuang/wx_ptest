﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_shoupingzi" Codebehind="ShouPingZi.aspx.cs" %>

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
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="状态"></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="瓶子ID"></asp:Label>
                                &nbsp;<asp:TextBox ID="WeTextBoxTwo" runat="server" Width="24px" Style="margin-left: 0px"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" Text="回复内容"></asp:Label>
                                <asp:TextBox ID="WeTextBoxOne" runat="server" Width="118px"></asp:TextBox>
                                <asp:Button ID="ButtonTwo" runat="server" Text="回复" OnClick="ButtonTwo_Click" />
                                <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                                <br />
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
