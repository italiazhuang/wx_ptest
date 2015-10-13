<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicNewsEditorV"
    CodeBehind="WeiXinBasicNewsEditorV.aspx.cs" %>

<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var popUpWin = 0;
        function PopUpWindow(URLStr, left, top, width, height, newWin, scrollbars) {
            if (typeof (newWin) == "undefined")
                newWin = false;

            if (typeof (left) == "undefined")
                left = 100;

            if (typeof (top) == "undefined")
                top = 0;

            if (typeof (width) == "undefined")
                width = 800;

            if (typeof (height) == "undefined")
                height = 760;

            if (newWin) {
                open(URLStr, '', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
                return;
            }

            if (typeof (scrollbars) == "undefined") {
                scrollbars = 0;
            }

            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
            popUpWin.focus();
        }
    </script>
    <script language="javascript">
        function jsED() {
            if (confirm("确定保存?")) {
                return true;
            }
            return false;
        }
        function jsModel() {
            if (confirm("模板将覆盖现有编辑框设置，确定加载?")) {
                return true;
            }
            return false;
        }
    </script>
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
            音频消息：请点击 新建音频消息 按钮建立您新的音频回复消息 ，或者点击 ☆ 选择编辑已有消息
        </div>
        <form id="weweixin_form" runat="server">
        <asp:Panel runat="server" ID="TextEditor" Visible="false">
            <table cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="leftCaption" width="100">
                        音频消息关键字
                    </td>
                    <td>
                        <asp:TextBox ID="WeTextBoxFive" runat="server" BorderStyle="None" Font-Size="Larger" Width="187px">关键词</asp:TextBox>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="mleftCaption">音频标题</td>
                    <td><asp:TextBox ID="WeTextBoxSix" runat="server" Width="285px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="leftCaption">音频描述</td>
                    <td><asp:TextBox ID="WeTextBoxSeven" runat="server" Height="81px" TextMode="MultiLine" Width="288px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="leftCaption">音频URL</td>
                    <td>
                            <asp:TextBox ID="txt0" runat="server" name="txt0" OnTextChanged="txt0_TextChanged" Width="284px"></asp:TextBox>
                            <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectVoc.aspx',100,100,880,490);">点击选择音频</a>
                    </td>
                </tr>
                <tr>
                     <td class="leftCaption">高品质音频</td>
                     <td><asp:TextBox ID="txt1" runat="server" name="txt1" OnTextChanged="txt0_TextChanged" Width="285px"></asp:TextBox></td>
                </tr>
                <tr class="footCaption">
                    <td colspan="2">
                        <div class="with-line">
                        <asp:Button ID="Button9" runat="server" Text="保存" OnClick="ButtonNine_Click" CssClass="button"/>
                        <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="不保存退出" CssClass="button"/>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100" OnExecuteCommand="FileManager1_ExecuteCommand"
            OnToolbarCommand="FileManager1_ToolbarCommand">
            <RootDirectories>
                <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="音频消息" />
            </RootDirectories>
            <CustomToolbarButtons>
                <iz:CustomToolbarButton Text="新建音频消息" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
                <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
            </CustomToolbarButtons>
            <FileTypes>
                <iz:FileType Extensions="txt,htm,html,css,js,ini,config,dll" Name="Text Document"
                    SmallImageUrl="~/images/16x16/notepad.png" LargeImageUrl="~/images/32x32/notepad.png">
                    <Commands>
                        <iz:FileManagerCommand Name="Edit (PostBack)" Method="PostBack" CommandName="EditText"
                            SmallImageUrl="~/images/16x16/notepad.png" />
                        <iz:FileManagerCommand Name="Edit (Callback)" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                    </Commands>
                </iz:FileType>
            </FileTypes>
        </iz:FileManager>
        </form>
    </div>
</body>
</html>
