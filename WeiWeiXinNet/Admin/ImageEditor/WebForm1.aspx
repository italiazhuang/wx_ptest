<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ZoomImageDemo.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div>
         <table id="Crop" cellpadding="0" cellspacing="0" border="0" >
        <tr>
                <td style="height: 73px" colspan="3" class="Overlay"></td>
        </tr>
        <tr>
            <td style="width: 82px" class="Overlay"></td>
            <td style="width: 120px; height: 120px; border-width: 1px; border-style: solid; border-color: white;"></td>
            <td style="width: 82px" class="Overlay"></td>
        </tr>
        <tr>
                <td style="height: 73px" colspan="3" class="Overlay"></td>
        </tr>
        </table>
     <%--   <div style="position:relative;top:0px;left:0px;" id="IconContainer">
        <img id="ImageIcon" src="http://img.kaixin001.com.cn/i/blank.jpg" style="border-width:0px;position:relative" />
        </div>--%>
    </div>
    </form>
</body>
</html>
