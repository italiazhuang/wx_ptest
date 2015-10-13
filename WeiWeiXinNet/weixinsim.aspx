<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weixinsim.aspx.cs" Inherits="WeiWeiXinNet.weixinsim" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href= 'USER_DIR/SYSUSER/HOME/v.css' rel='stylesheet' type='text/css'>
    <title>微信消息模拟器</title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="4">
                <tr>
                    <td>
                                输入<asp:TextBox ID="WeTextBoxOne" runat="server" Width="141px"></asp:TextBox>
                                <asp:Button ID="ButtonOne" runat="server" Text="发送" OnClick="ButtonOne_Click" />
                                &nbsp;用户<asp:TextBox ID="WeTextBoxThree" runat="server" Width="64px">user_id</asp:TextBox>
                                <asp:Button ID="ButtonTwo" runat="server" Text="关注" OnClick="ButtonTwo_Click" />
                                <asp:Button ID="ButtonThree" runat="server" Text="图片" OnClick="ButtonThree_Click" />
                                <asp:Button ID="ButtonFour" runat="server" OnClick="ButtonFour_Click" Text="菜单点击" />
                                <asp:Button ID="ButtonSix" runat="server" OnClick="ButtonSix_Click" Text="清空屏幕" />
                                <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="LBS" />
                                <asp:Button ID="ButtonFive" runat="server" OnClick="ButtonFive_Click" Text="听歌" />
                                <asp:Button ID="ButtonSeven" runat="server" OnClick="ButtonSeven_Click" Text="签到" Width="29px" />
                                <asp:Button ID="Button12" runat="server" OnClick="ButtonEight_Click" Text="积分" />
                                <asp:Button ID="Button9" runat="server" OnClick="ButtonNine_Click" Text="照片墙" />
                                <asp:Button ID="Button10" runat="server" OnClick="ButtonTen_Click" Text="Start" />
                                <asp:Button ID="Button8" runat="server" Text="微墙" OnClick="Button8_Click1" />
                                <asp:Button ID="Button13" runat="server"   Text="购物" onclick="Button13_Click" />
                                <asp:Button ID="Button14" runat="server"   Text="大转盘"  onclick="Button14_Click" />
                                <asp:Button ID="Button15" runat="server"  Text="刮刮卡" onclick="Button15_Click" />
                                <asp:Button ID="Button16" runat="server"  Text="优惠劵" onclick="Button16_Click" />
                                <asp:Button ID="Button17" runat="server"  Text="游戏" onclick="Button17_Click" />
                    </td>
                </tr>
            </table>
            <asp:Literal ID="WeTextBoxTwo" runat="server">
            </asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<%-- 版权所有 udoo123.taobao.com--%>