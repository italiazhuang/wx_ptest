<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.MobileSitePagesManagement"  CodeBehind="MobileSitePagesManagement.aspx.cs" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function jsED1() {
            if (confirm("确定保存?")) {
                return true;
            }
            return false;
        }
        function jsED2() {
            if (confirm("确定取消?")) {
                return true;
            }
            return false;
        }
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
        function opentest() {
               var ss = document.getElementById("WeTextBoxThree").value;
           // var ss2 = "../USER_DIR/SYSUSER/GUNDONG/news.htm";
            PopUpWindow(ss, 20, 20, 400, 650)
        }
    </script>
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
           页面管理：管理微网站中用户自定义页面
        </div>
       
        <form id="weweixin_form" runat="server">
       
              
                <iz:FileManager ID="FileManager1" runat="server" Height="500" Width="1100" OnExecuteCommand="FileManager1_ExecuteCommand"  OnToolbarCommand="FileManager1_ToolbarCommand">
                    <RootDirectories>
                        <iz:RootDirectory DirectoryPath="~/user_dir/sysuser/pages/" Text="页面管理" />
                    </RootDirectories>
                    <CustomToolbarButtons>
                        <iz:CustomToolbarButton Text="新建页面" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
                    </CustomToolbarButtons>
                    <FileTypes>
                        <iz:FileType Extensions="txt,htm,html,css,js,ini,config" Name="Text Document" SmallImageUrl="~/images/16x16/notepad.png"
                            LargeImageUrl="~/images/32x32/notepad.png">
                            <Commands>
                                <iz:FileManagerCommand Name="Edit (PostBack)" Method="PostBack" CommandName="EditText"
                                    SmallImageUrl="~/images/16x16/notepad.png" />
                                <iz:FileManagerCommand Name="Edit (Callback)" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                            </Commands>
                        </iz:FileType>
                    </FileTypes>
                </iz:FileManager>
                <asp:Panel runat="server" ID="TextEditor" Visible="false">
                    文件名：<asp:TextBox ID="WeTextBoxTwo" runat="server" Width="126px"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    &nbsp; 引用地址：<asp:TextBox ID="WeTextBoxThree" runat="server" Width="374px"></asp:TextBox>
                    <a href="javascript:void(0);" onclick="javascript:opentest();">【测试】</a><div>
                        <%--  <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="400" Width="600"/>
                        --%>
                        <CKEditor:CKEditorControl ID="WeTextBoxOne" runat="server" Height="500" 
                            Width="1100" onprerender="TextBox1_PreRender">
	                            内容编辑
                        </CKEditor:CKEditorControl>
                    </div>
                    <div>
                        <asp:Button ID="ButtonOne" runat="server" OnClick="ButtonOne_Click" Text="保存" 
                            Width="121px" />
                        <asp:Button ID="ButtonTwo" runat="server" OnClick="ButtonTwo_Click" Text="关闭" 
                            Width="121px" />
                    </div>
                </asp:Panel>
            
        </form>
    </div>
</body>
</html>
