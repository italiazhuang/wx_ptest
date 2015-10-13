<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicNewsEditor" CodeBehind="WeiXinBasicNewsEditor.aspx.cs" %>
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

        function ClickTree() {

            var o = window.event.srcElement;

            if (o.tagName == "INPUT" && o.type == "checkbox") {

                __doPostBack("", "");

            }

        }

    </script>

</head>
<body >
    <div class="main-box">
    <form id="weweixin_form" runat="server">
        <div class="head-dark-box">图文回复设置：请点击 新建图文消息 按钮建立您新的图文回复消息 ，或者点击 ☆ 选择编辑已有图文 </div>
         <div class="body-box">
            <div class="white-box">
            
            <asp:Panel runat="server" ID="TextEditor" Visible="false">
                <table  class="list-table" cellspacing="0" cellpadding="0" width="100%">
                    <tr class="head-light-box" >
                        <td style="text-align:center;">
                            图文消息项列表
                        </td>
                        <td >
                            图文消息关键字
                            <asp:TextBox ID="WeTextBoxFive" runat="server" Width="187px">关键词</asp:TextBox>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="退出" CssClass="button"/>
                            <asp:TextBox ID="WeTextBoxOne" runat="server" Height="34px" TextMode="MultiLine" Width="552px"  Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td valign="top" width="240">
                           <div style="overflow-x:hidden;overflow-y:scroll;width:240px;height:300px">
                            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                            <asp:TreeView ID="TreeView1" runat="server" Height="294px" onclick="ClickTree()"
                                OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged"
                                OnTreeNodePopulate="TreeView1_TreeNodePopulate" PopulateNodesFromClient="False">
                                <Nodes>
                                    <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Bold="True" Font-Size="Small" Width="100%"/>
                            </asp:TreeView>
                            </div>
                            <div style="margin-top:5px;text-align:center">
                            <asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="删除项"  CssClass="button"/>
                            <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="增加项"  CssClass="button"/>
                            </div>
                        </td>
                        <td valign="top">
                            <table width="100%"  cellspacing="0" cellpadding="0" style="border-bottom:0px">
                                <tr>
                                    <td class="leftCaption">
                                        标题：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitle" runat="server" Width="400px"></asp:TextBox>
                                        <asp:Button ID="Button21" runat="server"  OnClick="Button21_Click"  Text="保存当前单项" CssClass="button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftCaption">
                                        图片：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt0" runat="server" name="txt0" OnTextChanged="txt0_TextChanged" Width="400px"></asp:TextBox>
                                        <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,880,490);">点击选择图片</a>
                                        <br />
                                        <asp:Image ID="Image1" runat="server" Height="37px" Width="61px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="leftCaption">
                                        URL：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxUrl" runat="server" Width="400px" ></asp:TextBox>
                                        <br /> 当URL为空时系统会自动调用下面图文编辑器中的内容，当URL不为空时，微信中点击访问URL地址 URL中&lt;%ID%&gt; 为自动的加密时间戳参数<br /> 
                                        系统依靠&lt;%ID%&gt;将动态的加密时间戳反馈到微网站系统 例如URL可以设置为 abc.aspx?ID=&lt;%ID%&gt;</td>
                                </tr>
                                <tr>
                                    <td  valign="top" class="leftCaption">内容：</td>
                                    <td>
                                       <CKEditor:CKEditorControl ID="TextBoxEDIT" runat="server" Height="270px"  Width="100%" onprerender="TextBoxEDIT_PreRender"> 内容编辑</CKEditor:CKEditorControl>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100px" OnExecuteCommand="FileManager1_ExecuteCommand"
                OnToolbarCommand="FileManager1_ToolbarCommand" BackColor="#EDEBE0">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
                </RootDirectories>
                <CustomToolbarButtons>
                    <iz:CustomToolbarButton Text="新建图文消息" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
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
            </div>
      </form>
   </div>
</body>
</html>
