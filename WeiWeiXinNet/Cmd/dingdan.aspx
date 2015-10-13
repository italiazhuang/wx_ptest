<%@ Page Language="C#" AutoEventWireup="true" Inherits="dingdan" CodeBehind="dingdan.aspx.cs" %>

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
          <li class="title">我的商品订单</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td width="20%">订单</td>
                    <td width="60%">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" Width="100%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="20%">
                        <asp:Button ID="ButtonFour" runat="server" OnClick="ButtonFour_Click" Text="阅读" Width="100%" Style="height: 28px" />
                    </td>
                </tr>
                    <tr>
                        <td >回复</td>
                        <td>
                            <asp:TextBox ID="WeTextBoxTwo" runat="server" Width="95%" CssClass="text" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                           <asp:Button ID="ButtonThree" runat="server" Width="100%" Text="回复" Visible="False" OnClick="Button3_Click1" Style="height: 28px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="WeTextBoxOne" runat="server" style="height:200px" TextMode="MultiLine" Width="95%" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        <asp:Label ID="Label1" runat="server" Text="状态"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                    </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
