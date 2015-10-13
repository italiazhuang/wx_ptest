<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicNewsEditorL"  CodeBehind="WeiXinBasicNewsEditorL.aspx.cs" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
            LBS定位设置：请点击 新建LBS响应 按钮建立您新的LBS回复消息 ，或者点击 ☆ 选择编辑已有消息</div>
            <form id="weweixin_form" runat="server">
            <div class="body-box">
            <asp:Panel runat="server" ID="TextEditor" Visible="false">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td valign="top" colspan="2">
                            <table width="100%">
                             <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:TextBox ID="WeTextBoxOne" runat="server" Height="34px" TextMode="MultiLine" Width="552px" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="mleftCaption">
                                        X坐标</td>
                                    <td>
                                        <asp:TextBox ID="WeTextBoxFive" runat="server" Height="22px" Width="500px">12345.12345</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="mleftCaption">Y坐标</td>
                                    <td>
                                        <asp:TextBox ID="WeTextBoxSix" runat="server" Height="22px" Width="500px">67890.67890</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="mleftCaption">标题 </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitle" runat="server" Width="500px">商铺名称</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftCaption">图片 </td>
                                    <td>
                                        <asp:TextBox ID="txt0" runat="server" name="txt0"  OnTextChanged="txt0_TextChanged" Width="500px"></asp:TextBox>
                                        <a href="javascript:void(0);"  onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,880,490);">
                                        点击选择图片</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftCaption">
                                        URL
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxUrl" runat="server" Width="500px">http://udoo123.taobao.com</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftCaption">
                                        内容 
                                    </td>
                                    <td>
                                        <CKEditor:CKEditorControl ID="TextBoxEDIT" runat="server" Height="200" Width="800"> 内容编辑</CKEditor:CKEditorControl>
                                    </td>
                                </tr>
                                <tr class="footCaption">
                                    <td colspan="2">
                                        <div class="with-line">
                                            <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="不保存退出" CssClass="button"/>
                                            <asp:Button ID="Button24" runat="server" OnClick="Button24_Click" Text="保存" CssClass="button"/>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100px" OnExecuteCommand="FileManager1_ExecuteCommand"
                OnToolbarCommand="FileManager1_ToolbarCommand">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath= "~/user_dir/sysuser/mypost/location1/" Text="LBS响应" />
                </RootDirectories>
                <CustomToolbarButtons>
                    <iz:CustomToolbarButton Text="新建LBS响应" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
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
            </div>
            </form>
   
    </div>
</body>
</html>
