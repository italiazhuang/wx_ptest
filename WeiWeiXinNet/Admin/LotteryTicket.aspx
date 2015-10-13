<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotteryTicket.aspx.cs"
    Inherits="WeiWeiXinNet.admin.LotteryTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            刮刮卡： 刮刮卡抽奖设置
        </div>
        <div class="body-box">
            <form id="weweixin_form" runat="server">
            <asp:Button ID="Button3" runat="server"  onclick="Button3_Click"  Text="获奖结果"  CssClass="button"/>
            <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="刮刮卡设置" CssClass="button"/>
           
            <br/> <br/>
           
            
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <h2>
                        <a href="javascript:void(0);" onclick="javascript:PopUpWindow('../WebFormSimModel.aspx?sel=2',10,10,400,620);">【微网站模拟器】</a></h2>
                        <div class="with-line"></div>
                        <table cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td width="100">
                                    奖项设置
                                </td>
                                <td>
                                    <asp:TextBox ID="txt1" name="txt0" runat="server" Width="100%" Height="136px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="footCaption">
                                <td colspan="2">
                                    <asp:Button ID="Button2" runat="server" Text="保存" CssClass="button" OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel1" runat="server">
                 
                                <asp:GridView ID="GridView1" CssClass="list-table" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="AccessDataSourceGGK"
                                    Width="100%"  GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="记录号" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="ID"  ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="用户ID" SortExpression="Name" />
                                        <asp:BoundField DataField="Jp" HeaderText="获奖等级" SortExpression="Jp"  
                                            ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SJH" HeaderText="手机号码" SortExpression="SJH"  
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
                                <asp:AccessDataSource ID="AccessDataSourceGGK" runat="server" ConflictDetection="CompareAllValues"
                                    DataFile="~/USER_DIR/SYSUSER/LotteryTicket/db.dll" DeleteCommand="DELETE FROM [wx_ggk_jp] WHERE [ID] = ? AND [Name] = ? AND [Jp] = ? AND [SJH] = ?"
                                    InsertCommand="INSERT INTO [wx_ggk_jp] ([ID], [Name], [Jp], [SJH]) VALUES (?, ?, ?, ?)"
                                    OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Name], [Jp], [SJH] FROM [wx_ggk_jp]"
                                    UpdateCommand="UPDATE [wx_ggk_jp] SET [Name] = ?, [Jp] = ?, [SJH] = ? WHERE [ID] = ? AND [Name] = ? AND [Jp] = ? AND [SJH] = ?">
                                    <DeleteParameters>
                                        <asp:Parameter Name="original_ID" Type="Int32" />
                                        <asp:Parameter Name="original_Name" Type="String" />
                                        <asp:Parameter Name="original_Jp" Type="String" />
                                        <asp:Parameter Name="original_SJH" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ID" Type="Int32" />
                                        <asp:Parameter Name="Name" Type="String" />
                                        <asp:Parameter Name="Jp" Type="String" />
                                        <asp:Parameter Name="SJH" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="Name" Type="String" />
                                        <asp:Parameter Name="Jp" Type="String" />
                                        <asp:Parameter Name="SJH" Type="String" />
                                        <asp:Parameter Name="original_ID" Type="Int32" />
                                        <asp:Parameter Name="original_Name" Type="String" />
                                        <asp:Parameter Name="original_Jp" Type="String" />
                                        <asp:Parameter Name="original_SJH" Type="String" />
                                    </UpdateParameters>
                                </asp:AccessDataSource>
                </asp:Panel>
             
            
            </form>
        </div>
    </div>
    <p>
        &nbsp;</p>
</body>
</html>
