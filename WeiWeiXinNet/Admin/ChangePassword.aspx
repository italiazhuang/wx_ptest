<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.ChangePassword" Codebehind="ChangePassword.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<link href="include/admin.css" rel="stylesheet" type="text/css" />   
 
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 90px;
        }
    </style>
</head>
<body >
<div class="main-box">
	<div class="head-dark-box">
		修改密码
	</div>
	<div class="body-box">
		<form id="weweixin_form" runat="server">
    <div class="body-box">
        <table cellpadding="3" cellspacing="4" class="style1">
            <tr>
                <td class="style2">旧密码</td>
                <td>
                    <asp:TextBox ID="WeTextBoxOne" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">新密码</td>
                <td>
                    <asp:TextBox ID="WeTextBoxThree" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">重复密码</td>
                <td>
                    <asp:TextBox ID="WeTextBoxFour" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td class="footCaption" colspan="2">
                   <div class="with-line">
                   <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Button ID="ButtonOne" runat="server" CssClass="button" onclick="ButtonOne_Click" Text="确定修改"  Width="114px" />
                   </div>
                </td>
            </tr>

        </table>
    
    </div>
    </form>
	</div>
     
</div>
</body>
</html>