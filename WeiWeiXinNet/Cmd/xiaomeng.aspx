﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_xiaomeng" Codebehind="XiaoMeng.aspx.cs" %>

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
                                TO小萌：<asp:TextBox ID="WeTextBoxOne" runat="server" Width="50%" Style="height: 28px"></asp:TextBox><asp:Button
                                    ID="ButtonOne" runat="server" OnClick="ButtonOne_Click" Text="发送" Width="60px" Style="height: 28px" />
                                <br />
                                <asp:TextBox ID="WeTextBoxTwo" runat="server" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>
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