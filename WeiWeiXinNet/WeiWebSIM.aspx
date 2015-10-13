<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiWebSIM.aspx.cs" Inherits="WeiWeiXinNet.WeiWebSIM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        需要模拟的用户ID <asp:TextBox ID="WeTextBoxOne" runat="server">user_id</asp:TextBox>
        <asp:Button ID="ButtonOne" runat="server" onclick="ButtonOne_Click" Text="进入" />
        <br />
        <br />
        调试时采用不同用户id 可以模拟多用户交互操作<br />
        <br />
    
    </div>
    </form>
</body>
</html>
