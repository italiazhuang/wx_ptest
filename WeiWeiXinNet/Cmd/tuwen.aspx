<%@ Page Language="C#" AutoEventWireup="true" Inherits="tuwen" Codebehind="tuwen.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/Style.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="Pink/jquery.mobile-1.4.2.min.css">
    <link href="USER_DIR/SYSUSER/TUWEN/contents.css" rel="stylesheet" type="text/css">
    <script src="Pink/jquery.js"></script>
    <script src="Pink/jquery.mobile-1.4.2.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div>
        <%  =GetNews() %>
    </div>
    </form>
</body>
</html>
<%-- 版权所有 udoo123.taobao.com--%>