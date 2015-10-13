<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinMenuEditor"
    CodeBehind="WeiXinMenuEditor.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
     

        function jsQ5() {
            if (confirm("样例将会覆盖现有菜单编辑框的内容，确定操作吗?")) {
                return true;
            }
            return false;
        }

        function jsQ1() {
            if (confirm("确定操作吗?")) {
                return true;
            }
            return false;
        }

        function jsQ2() {
            if (confirm("确定操作吗?")) {
                return true;
            }
            return false;
        }

        function jsQ3() {
            if (confirm("确定操作吗?")) {
                return true;
            }
            return false;
        }
        function jsQ4() {
            if (confirm("确定操作吗?")) {
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
<body  >
    <div class="main-box">
        <div class="head-dark-box">
            菜单设置：微信官方规定菜单仅限于微信服务号和经过认证的微信订阅号,菜单设置后会在24小时自动更新，或者取消后重新关注微信号码 可以立刻查看菜单设置效果
        </div>
         <div class="body-box">
            <div class="white-box">
            <form id="weweixin_form" runat="server">
            <table class="list-table" cellspacing="0" cellpadding="0"  width="100%">
                <tr>
                    <td>
                        <table height="450">
                            <tr>
                                <td valign="top" class="head-light-box" style="font-weight:normal">
                                    <span><strong>微信菜单设计</strong></span>
                                    <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" Height="294px" Width="173px" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1"
                                        OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" OnTreeNodePopulate="TreeView1_TreeNodePopulate"
                                        PopulateNodesFromClient="False" onclick="ClickTree()">
                                        <Nodes>
                                            <asp:TreeNode ShowCheckBox="True" Text="菜单一" Value="菜单一">
                                                <asp:TreeNode Text="菜单一:1" Value="菜单一:1"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单一:2" Value="菜单一:2"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单一:3" Value="菜单一:3"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单一:4" Value="菜单一:4"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单一:5" Value="菜单一:5"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode ShowCheckBox="True" Text="菜单二" Value="菜单二">
                                                <asp:TreeNode Text="菜单二:1" Value="菜单二:1"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单二:2" Value="菜单二:2"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单二:3" Value="菜单二:3"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单二:4" Value="菜单二:4"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单二:5" Value="菜单二:5"></asp:TreeNode>
                                            </asp:TreeNode>
                                            <asp:TreeNode Selected="True" ShowCheckBox="True" Text="菜单三" Value="菜单三">
                                                <asp:TreeNode Text="菜单三:1" Value="菜单三:1"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单三:2" Value="菜单三:2"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单三:3" Value="菜单三:3"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单三:4" Value="菜单三:4"></asp:TreeNode>
                                                <asp:TreeNode Text="菜单三:5" Value="菜单三:5"></asp:TreeNode>
                                            </asp:TreeNode>
                                        </Nodes>
                                         <NodeStyle Width="100%" />
                                    </asp:TreeView>
                                </td>
                                <td valign="top"   style="font-weight:normal">
                                    <table>
                                        <tr>
                                            <td>
                                                <strong><span class="style10">当前选择:</span></strong> <span class="style10">
                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                    &nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
                                                </span>
                                            </td>
                                            <tr>
                                                <td>
                                                   菜单文本:
                                                </td>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="WeTextBoxThree" runat="server" Width="90%" MaxLength="7"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        菜单命令类型
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList2" runat="server" Width="90%" CssClass="style8">
                                                            <asp:ListItem>跳转URL</asp:ListItem>
                                                            <asp:ListItem>发送键值</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        菜单命令参数（URL或关键字）
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="WeTextBoxFour" runat="server" Width="90%" MaxLength="250"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button8" runat="server" Text="保存" OnClick="ButtonEight_Click" CssClass="button"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        目前自定义菜单最多包括3个一级菜单，每个一级菜单最多包含5个二级菜单。一级菜单最多4个汉字，二级菜单最多7个汉字
                                                    </td>
                                                </tr>
                                    </table>
                                </td>
                                <td valign="top"  class="head-light-box" style="font-weight:normal">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                               <b>操作返回</b><asp:Label ID="Label1" runat="server" BackColor="#CC9900"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                AppId
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;<asp:TextBox ID="txtAppid" runat="server" Width="251px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                AppSecret
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtKey" runat="server" Width="303px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                菜单JSON数据&nbsp;<asp:TextBox ID="txtMenuString" runat="server" Width="361px" TextMode="MultiLine"
                                                    Height="150px">{
     &quot;button&quot;:[
     {	
          &quot;type&quot;:&quot;click&quot;,
          &quot;name&quot;:&quot;今日歌曲&quot;,
          &quot;key&quot;:&quot;V1001_TODAY_MUSIC&quot;
      },
      {
           &quot;type&quot;:&quot;click&quot;,
           &quot;name&quot;:&quot;歌手简介&quot;,
           &quot;key&quot;:&quot;V1001_TODAY_SINGER&quot;
      },
      {
           &quot;name&quot;:&quot;菜单&quot;,
           &quot;sub_button&quot;:[
            {
               &quot;type&quot;:&quot;click&quot;,
               &quot;name&quot;:&quot;hello word&quot;,
               &quot;key&quot;:&quot;V1001_HELLO_WORLD&quot;
            },
            {
               &quot;type&quot;:&quot;click&quot;,
               &quot;name&quot;:&quot;赞一下我们&quot;,
               &quot;key&quot;:&quot;V1001_GOOD&quot;
            }]
       }]
 }</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="ButtonOne" runat="server" Text="获取菜单文本" OnClick="ButtonOne_Click" CssClass="button"/>
                                                <asp:Button ID="ButtonTwo" runat="server" Text="创建/更新菜单" OnClick="ButtonTwo_Click"  CssClass="button"/><asp:Button ID="ButtonThree" runat="server" Text="清除菜单" OnClick="ButtonThree_Click"  CssClass="button"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
            </table>
            </form>
        </div>
        </div>
    </div>
</body>
</html>
