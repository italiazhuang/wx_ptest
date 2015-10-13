<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormSecurity.aspx.cs" Inherits="WeiWeiXinNet.admin.WebFormSecurity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    
    <div class="main-box">
	<div class="head-dark-box">
		安全检测：检查用户文件夹中是否有被上传木马文件 (请选择 或者输入 扩展名)
	</div>
	<div class="body-box">
    <form id="form2" runat="server">
    <table width="100%" cellpadding="0" cellspacing="4">
   <tr>
   <td>扩展名：
        <asp:DropDownList ID="DropDownList1" runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>选择扩展名</asp:ListItem>
            <asp:ListItem>asp</asp:ListItem>
            <asp:ListItem>aspx</asp:ListItem>
            <asp:ListItem>ashx</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         <asp:Button ID="Button1" runat="server" Text="搜索"  onclick="Button1_Click"  />
    </td>
   </tr>
   <tr>
        <td>
            <IFRAME id="frame1" src="" width ="100%" scrolling="auto" runat="server"></IFRAME>
        </td>
    </tr>
    </table>
    </form>
    </div>
    </div>
</body>
</html>
