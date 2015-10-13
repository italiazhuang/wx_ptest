<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.MainNews"
    CodeBehind="MainNews.aspx.cs" %>
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

        function opentest() {
          //  var ss = document.getElementById("TextBoxUrl").value;

           // var ss2 = "..\\USER_DIR\\SYSUSER\\NEWS\\" + ss;

            var ss3 = "../cmd/news.ashx";

            PopUpWindow(ss3, 20, 20, 400, 650)

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
             图文页面设置
        </div>
        <form id="weweixin_form" runat="server">
        <div class="body-box">
            备注说明：管理微网站内图文新闻页面内容
            <div class="white-box">
        <asp:Panel runat="server" ID="TextEditor" Visible="true">
            <table class="userinfoArea" style="margin: 0;" border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                <td>
                        <table width="100%" class="list-table" cellpadding="0" cellspacing="0">
                            <tr class="head-light-box">
                                <td style="text-align:center;width:240px">图文标题列表</td>
                                <td>
                                    标题:<asp:TextBox ID="TextBoxTitle" runat="server" Width="188px"></asp:TextBox>
                                    图片:<asp:TextBox ID="txt0" runat="server" name="txt0" OnTextChanged="txt0_TextChanged" Width="73px"></asp:TextBox>
                                    <input type="button" onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,880,490);" value="选择图片" class="button"/>
                                    <input type="button" onclick="javascript:opentest();" value="测试" class="button"/>
                                    <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="保存当前项数据" CssClass="button"/>

                                    <asp:TextBox ID="WeTextBoxOne" runat="server" Height="34px" TextMode="MultiLine" Width="552px" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="TextBoxUrl" runat="server" ReadOnly="True" Width="44px" style="display:none;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                        <td valign="top">
                        <div style="overflow-x:hidden;overflow-y:scroll;height:300px;width:240px">
                       <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                        <asp:TreeView ID="TreeView1" runat="server" Height="294px" onclick="ClickTree()"
                            OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged"
                            OnTreeNodePopulate="TreeView1_TreeNodePopulate" PopulateNodesFromClient="False"
                            Width="100%">
                            <Nodes>
                                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                            </Nodes>
                            <NodeStyle Font-Bold="True" Font-Size="Small" Width="100%"/>
                        </asp:TreeView>
                        </div>
                        <div style="margin-top:5px;text-align:center">
                        <asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="删除" CssClass="button"/>
                        <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="增加" CssClass="button"/>
                        </div>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td valign="top">
                                    <CKEditor:CKEditorControl ID="TextBoxEDIT" runat="server" CustomConfig="config3.js" Height="412px" Width="100%">内容编辑</CKEditor:CKEditorControl>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        </div>
        </div>
        </form>
    </div>
</body>
</html>
