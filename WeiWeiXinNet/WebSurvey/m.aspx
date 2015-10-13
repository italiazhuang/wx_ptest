<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="m.aspx.cs" Inherits="WeiWeiXinNet.WebSurvey.m" %>

<%@ Register Namespace="sstchur.web.survey" Assembly="sstchur.web.survey" TagPrefix="cc1" %>
<html>
<head>
<title>  <% =IM%>   </title>
    <style type="text/css">
        body, table, td
        {
            font-family: arial;
            font-size: 12px;
            color: #336699;
        }
    </style>
</head>
<body bgcolor="#ffffff">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
        <tr valign="top" align="center">
            <td width="100%" height="100%">
                <table border="0" cellpadding="10" cellspacing="0" width="380" style="border: solid 1px #000000;">
                    <tr valign="top" align="left">
                        <td>
                            <br />
                            <p align="center">
                                <h3>
                                <% =IM%>  </h3>
                            </p>
                            <asp:Panel ID="pnlSurvey" Visible="false" runat="server">
                                <form id="weweixin_form" runat="server">
                                <cc1:WebSurvey ID="ws"   runat="server" />
                                </form>
                            </asp:Panel>
                            <asp:Panel ID="pnlPreviouslyCompleted" Visible="false" runat="server">
                                Thank you for taking our survey.
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
