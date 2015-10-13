<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.Frame" Codebehind="admin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
</head>

<frameset rows="80,*" framespacing="0" frameborder="no" border="0"">
  <frame src="Top.aspx" name="top" frameborder="no" scrolling="no" border="0" noresize="true" />
  <frameset cols="160,*" framespacing="0" frameborder="no" border="0" topmargin="0"  leftmargin="0" marginheight="0" marginwidth="0">
    <frame src="Menu.aspx" name="left" frameborder="no" scrolling="auto" topmargin="0" leftmargin="0" border="0" />
    <frame src="WeiXinBasicManagement.aspx" name="main" frameborder="no"/>
  </frameset>
</frameset>


 <form id="weweixin_form" runat="server">
        <div>
         
        </div>
        </form>


</html>
<%-- 版权所有 udoo123.taobao.com--%>