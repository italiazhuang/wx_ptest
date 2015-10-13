<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.MobileSiteFramework"
    CodeBehind="MobileSiteFramework.aspx.cs" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>框架模板</title>
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
    </head>
<body >
   

    <div class="main-box">
        <div class="head-dark-box">
            框架模板：设置微网站的整体导航菜单栏框架</div>
     <form id="weweixin_form" runat="server"> 
        <table   style="margin: 0;" border="0" cellspacing="0" cellpadding="0"
            width="100%">
           <tr>
                <td  >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a class="Red" href="javascript:void(0);" onclick="javascript:window.open('../test.ashx?dat=User_Dir/sysuser/home/Main.HTM','testwindow','width=400,height=500,scrollbars=yes,top=150,left=150')">[微网站模拟器]</a>
                    <asp:Button ID="ButtonOne" runat="server" Text="保存" OnClick="ButtonOne_Click" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td  valign="top" >
                    <asp:TextBox ID="CKEditor1T" runat="server" Width="1100px" Height="569px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
       </form>
    </div> 
</body>
</html>
