<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.CheckOnWorkAttendanceEdit"
    CodeBehind="CheckOnWorkAttendanceEdit.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            微信签到设置： 用户在微信中输入 @ 实现每日签到 ，请按照要求填写签到返回和签到积分奖励数据
        </div>
         
        <form id="weweixin_form" runat="server">
        <div class="body-box">
            <table cellspacing="0" cellpadding="3" width="100%">
                <tr>
                    <td class="style1">
                        每天第一次签到时返回的内容
                    </td>
                    <td>
                        <p>
                            <asp:TextBox ID="WeTextBoxOne" runat="server" Width="447px" Height="54px" 
                                TextMode="MultiLine"></asp:TextBox>
                            例：成功{0} 签到\n您是今天第{1}位签到者</p>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        每天签过到后再次签到时返回的内容
                    </td>
                    <td>
                        <p>
                            <asp:TextBox ID="WeTextBoxTwo" runat="server" Width="447px" Height="54px" 
                                TextMode="MultiLine"></asp:TextBox>
                            例：已于{0}签到</p>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        查看积分时候的模板</td>
                    <td>
                        <p>
                            <asp:TextBox ID="WeTextBoxFour" runat="server" Width="448px" Height="54px" 
                                TextMode="MultiLine"></asp:TextBox>
                            例：您当前积{0}分,积分等级{1},您获得了神秘礼品包:\n{2}</p>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        签到积分奖励奖励
                    </td>
                    <td>
                        <asp:TextBox ID="WeTextBoxThree" runat="server" Width="448px" Height="117px" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="footCaption">
                        <div class="with-line">
                        <asp:Button ID="ButtonOne" runat="server" CssClass="button" Text="保 存" OnClick="ButtonOne_Click" />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
