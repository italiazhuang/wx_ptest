<%@ Page Language="C#" AutoEventWireup="true" Inherits="SetMyData" Codebehind="setmydata.aspx.cs" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
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
	<li class="title">个人设置</li>
     <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" class="cpbiaoge">
        <tr>
            <td width="60" align="right">昵称：</td>
            <td>
                <asp:TextBox ID="WeTextBoxOne" runat="server" Width="95%" CssClass="text">某某</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">学院：</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="100%">
                    <asp:ListItem>人文学院</asp:ListItem>
                    <asp:ListItem>政法学院</asp:ListItem>
                    <asp:ListItem>外国语学院</asp:ListItem>
                    <asp:ListItem>阿拉伯学院</asp:ListItem>
                    <asp:ListItem>经济管理学院</asp:ListItem>
                    <asp:ListItem>数学计算机学院</asp:ListItem>
                    <asp:ListItem>物理电气信息学院</asp:ListItem>
                    <asp:ListItem>化学化工学院</asp:ListItem>
                    <asp:ListItem>生命科学学院</asp:ListItem>
                    <asp:ListItem>资源环境学院</asp:ListItem>
                    <asp:ListItem>机械工程学院</asp:ListItem>
                    <asp:ListItem>农学院</asp:ListItem>
                    <asp:ListItem>葡萄酒学院</asp:ListItem>
                    <asp:ListItem>土木水利工程学院</asp:ListItem>
                    <asp:ListItem>教育学院</asp:ListItem>
                    <asp:ListItem>体育学院</asp:ListItem>
                    <asp:ListItem>音乐学院</asp:ListItem>
                    <asp:ListItem>美术学院</asp:ListItem>
                    <asp:ListItem>马克思主义学院</asp:ListItem>
                    <asp:ListItem>国际教育学院</asp:ListItem>
                    <asp:ListItem>继续教育学院</asp:ListItem>
                    <asp:ListItem>民族预科教育学院</asp:ListItem>
                    <asp:ListItem>远程教育学院</asp:ListItem>
                    <asp:ListItem>新华学院</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">性别：</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="100%">
                    <asp:ListItem>女</asp:ListItem>
                    <asp:ListItem>男</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        
           <tr>
           <td align="right">联系：</td>
            <td>
                <asp:TextBox ID="WeTextBoxThree" runat="server" Height="67px" TextMode="MultiLine" class="text"  Width="95%">地址、电话：</asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="right">签名：</td>
            <td>
                <asp:TextBox ID="WeTextBoxTwo" runat="server" Height="67px" TextMode="MultiLine"  class="text" Width="95%">From now on,love yourself,enjoy living then smile.</asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <asp:Button ID="ButtonOne" runat="server" Text="保存" OnClick="ButtonOne_Click" Width="100%" Style="width:100%;border-radius: 5px 5px; height: 48px;" CssClass="submit2"/>
                <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    </ul>
    </div>
    </form>
</body>
</html>
<%-- 版权所有 udoo123.taobao.com--%>