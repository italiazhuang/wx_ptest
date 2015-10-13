<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGoodWebEdit.aspx.cs" Inherits="WeiWeiXinNet.admin.UserGoodWebEdit" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="include/admin.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>
<body>
    <form id="weweixin_form" runat="server">
         <asp:Panel runat="server" ID="Panel2" Visible="false">
             <asp:Button ID="ButtonThree" runat="server" OnClick="ButtonThree_Click" Text="返回" />
             <iz:FileManager ID="FileManager1" runat="server" Height="480px" Width="800px" OnExecuteCommand="FileManager1_ExecuteCommand" Visible="true">
            <RootDirectories>
                <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
            </RootDirectories>
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
        <asp:TextBox ID="WeTextBoxOne" runat="server" Height="470px" TextMode="MultiLine"  Width="780px" Visible="False"></asp:TextBox>

        </asp:Panel>
          <asp:Panel ID="Panel1" runat="server">
          <div class="main-box">
	        <div class="head-dark-box">
		        订单详细
	        </div>
	        <div class="body-box">
            <table width="100%" cellpadding="0" cellspacing="4">
                <tr>
                    <td width="150">
                        用户ID：
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        关注时间：
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        最后一次访问时间：
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户昵称：
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户性别：
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户来源：
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户签名：
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户地址：
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户积分：
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                    </td>
                </tr>

                  <tr>
                    <td>
                       订单内容
                     
                        <br />
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="选中确认订单已经完成" />
                        <br />
                        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                            Text="将订单移入已完成订单" Width="142px" />
                    </td>
                    <td>
                        <asp:TextBox ID="Label10" runat="server" BackColor="#CCFF99" Height="200px"  ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>回复用户</td>
                    <td>
                        <asp:TextBox ID="TextBoxMsg" runat="server" Width="347px"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="回复" />
                    </td>
                </tr>
            </table>
            </div>
        </asp:Panel>


         <asp:HiddenField ID="HiddenField1" runat="server" />


    </form>
</body>
</html>
