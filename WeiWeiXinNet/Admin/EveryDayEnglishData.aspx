<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.EveryDayEnglishData" Codebehind="EveryDayEnglishData.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body >
<div class="main-box">
	<div class="head-dark-box">
		欢迎使用
	</div>
	<div class="body-box">
		<span class="red"></span> 您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
		<p>请点击左侧菜单进行操作.</p>
	</div>
     <form id="weweixin_form" runat="server">
  <div class="body-box">
               <table class="userinfoArea" style="margin: 0;" border="0" cellspacing="0" cellpadding="0"
                width="100%">
                <tr>
                    <td>
                        每日英语API
                    </td>
                    <td>
                        <p>
                            <asp:TextBox ID="WeTextBoxOne" runat="server" Width="335px"></asp:TextBox>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        获取今天的数据</td>
                    <td>
                        <asp:TextBox ID="WeTextBoxThree" runat="server" Width="335px" Height="100px"></asp:TextBox>
                        <asp:Button ID="ButtonTwo" runat="server" Text="读取" CssClass="button" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonThree" runat="server" Text="保存" onclick="ButtonThree_Click" CssClass="button"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</div>
</body>
</html>