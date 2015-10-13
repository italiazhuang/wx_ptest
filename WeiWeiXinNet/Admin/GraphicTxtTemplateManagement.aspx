<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.GraphicTxtTemplateManagement"
    CodeBehind="GraphicTxtTemplateManagement.aspx.cs" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function jsSave() {
            if (confirm("确定保存吗?")) {
                return true;
            }
            return false;
        }

        function jsLoad() {
            if (confirm("模板将覆盖掉现有主页内容，确定读取吗?")) {
                return true;
            }
            return false;
        }



    </script>
    <style type="text/css">
        .style1
        {
            width: 123px;
        }
    </style>
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            欢迎使用
        </div>
        <div class="body-box">
            <span class="red"></span>您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
            <p>
                请点击左侧菜单进行操作.</p>
         
        <form id="weweixin_form" runat="server">
         
            <table class="userinfoArea" style="margin: 0;" border="0" cellspacing="0" cellpadding="0"
                width="100%">
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        <p>
                            <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../User_Dir/sysuser/news/news.HTM','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">
                                [测试]</a>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td class="style1"  valign="top" >
                        <br />
                        图文页设置<br />
                        图文页模板数据<br />
                        <asp:Button ID="ButtonFive" runat="server" Text="模板1" OnClick="ButtonFive_Click"  CssClass="button"/>
                        <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../User_Dir/sysuser/news/m0.html','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">
                            [测试]</a>
                        <br />
                        <asp:Button ID="ButtonSix" runat="server" Text="模板2" OnClick="ButtonSix_Click"  CssClass="button"/>
                        <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../User_Dir/sysuser/news/m1.html','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">
                            [测试]</a>
                        <br />
                        <asp:Button ID="ButtonSeven" runat="server" Text="模板3" OnClick="ButtonSeven_Click"  CssClass="button"/>
                        <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../User_Dir/sysuser/news/m2.html','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">
                            [测试]</a>
                        <br />
                        <asp:Button ID="Button8" runat="server" Text="模板4" OnClick="ButtonEight_Click"  CssClass="button"/>
                        <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../User_Dir/sysuser/news/m3.html','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">
                            [测试]</a><br />
&nbsp;<asp:Button ID="ButtonOne" runat="server" Text="保存" OnClick="ButtonOne_Click" CssClass="button"/>
                    </td>
                    <td>
                        <asp:TextBox ID="CKEditor1T" runat="server" Width="100%" Height="419px"  TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
       
        </form> </div>
    </div>
</body>
</html>
