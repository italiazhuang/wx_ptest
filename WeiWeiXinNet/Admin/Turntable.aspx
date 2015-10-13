<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Turntable.aspx.cs"
    Inherits="WeiWeiXinNet.admin.Turntable" %>

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
        <form id="weweixin_form" runat="server">
        <div class="head-dark-box">
            大转盘： 大转盘抽奖&nbsp;
            (正式使用前请确保设置正确，并确认具有实际获奖结果的设置数据在需要投入时使用，抽奖系统易被攻击需要谨慎使用)</div>

        <div class="body-box">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="获奖记录" CssClass="button" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="大转盘设置"  CssClass="button"/>

        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <h2>
                <a href="javascript:void(0);" onclick="javascript:PopUpWindow('../WebFormSimModel.aspx?sel=1',10,10,400,620);">
                    【微网站模拟器】</a></h2>
            <table class="list-table" cellspacing="0" cellpadding="4" width="100%">
                <tr>
                    <td width="100">
                        大转盘文本
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="110px" TextMode="MultiLine"  Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        中奖数据设置
                    </td>
                    <td>
                        <asp:TextBox ID="txt2" name="txt0" runat="server" Width="100%" Height="87px" 
                            TextMode="MultiLine">1, 2, 3, 4, 5, 0,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        设置说明
                    </td>
                    <td>
                            <textarea style="height: 85px; width: 100%" name="S1" rows="1">                                                     
 可以看到  1, 2, 3, 4, 5, 0,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99
这99个数，
 if (data == 1 || data==2) {//一等奖4%
         rotateFunc(0, '恭喜您抽中的一等奖')
随机产生100个数字，当等于1，2时就中了一等奖
如果设成  data == 100 || data==200    那一等奖肯定就中不了的，因为系统就不会出现100,200 最大的数，才99
二等奖，三等奖同样设置就行了，                          
                          </textarea>
                    </td>
                </tr>

                <tr class="footCaption">  
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="保存" Width="89px" OnClick="Button1_Click" CssClass="button"/>   
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td> 
                </tr>

            </table>
           
                       
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel1" runat="server">
       <h2>获奖记录</h2>  
                    <asp:GridView ID="GridView1" CssClass="list-table" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="AccessDataSourceTurntable"
                            Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            ShowFooter="True"  GridLines="None" ShowHeaderWhenEmpty="True">
                            <Columns>
                                
                                <asp:BoundField DataField="Name" HeaderText="用户ID" SortExpression="Name"  
                                    ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ID" HeaderText="记录号" InsertVisible="False" ReadOnly="True"
                                    SortExpression="ID"  ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Jp" HeaderText="奖品" SortExpression="Jp"  
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
                        <asp:AccessDataSource ID="AccessDataSourceTurntable" runat="server" ConflictDetection="CompareAllValues"
                            DataFile="~/USER_DIR/SYSUSER/Turntable/db.dll" DeleteCommand="DELETE FROM [wx_dzp_jp] WHERE [ID] = ? AND [Name] = ? AND [Jp] = ? AND [SJH] = ?"
                            InsertCommand="INSERT INTO [wx_dzp_jp] ([Name], [ID], [Jp], [SJH]) VALUES (?, ?, ?, ?)"
                            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Name], [ID], [Jp], [SJH] FROM [wx_dzp_jp]"
                            UpdateCommand="UPDATE [wx_dzp_jp] SET [Name] = ?, [Jp] = ?, [SJH] = ? WHERE [ID] = ? AND [Name] = ? AND [Jp] = ? AND [SJH] = ?">
                            <DeleteParameters>
                                <asp:Parameter Name="original_ID" Type="Int32" />
                                <asp:Parameter Name="original_Name" Type="String" />
                                <asp:Parameter Name="original_Jp" Type="String" />
                                <asp:Parameter Name="original_SJH" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="ID" Type="Int32" />
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
        </div>
        </form>
    </div>
</body>
</html>
