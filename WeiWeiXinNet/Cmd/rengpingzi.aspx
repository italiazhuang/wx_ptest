<%@ Page Language="C#" AutoEventWireup="true" Inherits="cmd_rengpingzi" Codebehind="RengPingZi.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href= '../USER_DIR/SYSUSER/HOME/v.css' rel='stylesheet' type='text/css'>
    <style>
        input.buttonx
        {
            font-size: 10px;
            color: #000;
            text-decoration: none;
            display: block;
            width: 78px;
            padding: 10px;
            border: 1px solid #DDD;
            text-align: center;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -o-border-radius: 5px;
            border-radius: 5px;
        }
        input.buttonx:hover
        {
            color: #fff;
            border-color: #3278BE;
        }
        
        input.buttonx:active
        {
            background: #4195DD;
            background: -webkit-gradient(linear, 0% 0%, 0% 100%, from(#003C82), to(#4195DD));
            background: -moz-linear-gradient(0% 90% 90deg, #4195DD, #003C82);
        }
    </style>
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
                                <asp:TextBox ID="WeTextBoxOne" runat="server" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <br />
                                <asp:Button ID="ButtonOne" runat="server" Height="31px" class="buttonx" OnClick="ButtonOne_Click"
                                    Text="扔瓶子" Width="88px" />
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
