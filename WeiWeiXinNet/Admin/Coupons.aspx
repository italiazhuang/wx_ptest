<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="WeiWeiXinNet.admin.Coupons" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>优惠券</title>
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
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            优惠劵：优惠劵设置
        </div>
        <div class="body-box">
            <form id="form1x" runat="server">
            <asp:Button ID="Button2" runat="server" Text="优惠劵领取结果" OnClick="Button2_Click" CssClass="button"/>
            <asp:Button ID="Button3" runat="server" Text="设置优惠劵" OnClick="Button3_Click" CssClass="button"/>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <div>
                    <h2>
                        <a href="javascript:void(0);" onclick="javascript:PopUpWindow('../WebFormSimModel.aspx?sel=3',10,10,400,620);">【优惠劵预览】</a></h2>
                    <table class="list-table" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                优惠劵设置
                            </td>
                            <td >
                                未领取时图片
                            </td>
                            <td>
                                领取后图片
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Image ID="Image1" name="Image1" runat="server" Width="183px" Height="213px" />
                                <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,880,490);">
                                    点击选择未领取图片</a>
                            </td>
                            <td>
                                <asp:Image ID="Image2" name="Image1" runat="server" Width="183px" Height="213px" />
                                <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectImg2.aspx',100,100,880,490);">
                                    点击选择领取后图片</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txt0" name="txt0" runat="server" Width="186px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt3" name="txt0" runat="server" Width="186px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="footCaption">
                            <td colspan="3">
                                <asp:Button ID="Button1" runat="server" Text="保存" Width="89px" OnClick="Button1_Click" CssClass="button"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <br />
                <asp:GridView ID="GridView1" runat="server" CssClass="list-table" 
                    AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="WXOpenID" DataSourceID="AccessDataSourceWeiWei"
                    Width="100%"   GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="WXOpenID" HeaderText="记录号" InsertVisible="False"  
                            ReadOnly="True" SortExpression="WXOpenID" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUserPhone" HeaderText="用户手机号" 
                            SortExpression="CUserPhone"  ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUserName" HeaderText="用户ID" 
                            SortExpression="CUserName" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUserqq" HeaderText="用户QQ" SortExpression="CUserqq"  
                            ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="操作" 
                            ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="head-light-box" />
                </asp:GridView>
                <asp:AccessDataSource ID="AccessDataSourceWeiWei" runat="server" ConflictDetection="CompareAllValues"
                    DataFile="~/USER_DIR/SYSUSER/Coupons/db.dll" DeleteCommand="DELETE FROM [WX_Coupons] WHERE [WXOpenID] = ? AND [CUserPhone] = ? AND [CUserName] = ? AND [CUserqq] = ?"
                    InsertCommand="INSERT INTO [WX_Coupons] ([WXOpenID], [CUserPhone], [CUserName], [CUserqq]) VALUES (?, ?, ?, ?)"
                    OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [WXOpenID], [CUserPhone], [CUserName], [CUserqq] FROM [WX_Coupons]"
                    UpdateCommand="UPDATE [WX_Coupons] SET [CUserPhone] = ?, [CUserName] = ?, [CUserqq] = ? WHERE [WXOpenID] = ? AND [CUserPhone] = ? AND [CUserName] = ? AND [CUserqq] = ?">
                    <DeleteParameters>
                        <asp:Parameter Name="original_WXOpenID" Type="Int32" />
                        <asp:Parameter Name="original_CUserPhone" Type="String" />
                        <asp:Parameter Name="original_CUserName" Type="String" />
                        <asp:Parameter Name="original_CUserqq" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="WXOpenID" Type="Int32" />
                        <asp:Parameter Name="CUserPhone" Type="String" />
                        <asp:Parameter Name="CUserName" Type="String" />
                        <asp:Parameter Name="CUserqq" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CUserPhone" Type="String" />
                        <asp:Parameter Name="CUserName" Type="String" />
                        <asp:Parameter Name="CUserqq" Type="String" />
                        <asp:Parameter Name="original_WXOpenID" Type="Int32" />
                        <asp:Parameter Name="original_CUserPhone" Type="String" />
                        <asp:Parameter Name="original_CUserName" Type="String" />
                        <asp:Parameter Name="original_CUserqq" Type="String" />
                    </UpdateParameters>
                </asp:AccessDataSource>
                <br />
            </asp:Panel>
            </form>
        </div>
    </div>
</body>
</html>
