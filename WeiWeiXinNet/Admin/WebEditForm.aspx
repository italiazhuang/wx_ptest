<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebEditForm.aspx.cs" Inherits="WeiWeiXinNet.admin.WebEditForm" %>
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

        <asp:TextBox ID="WeTextBoxOne" runat="server" Height="470px" TextMode="MultiLine" 
                 Width="780px" Visible="False"></asp:TextBox>



        </asp:Panel>
          <asp:Panel ID="Panel1" runat="server">
           <div class="main-box">
            <div class="head-dark-box">
                用户信息
            </div>
            <div class="body-box">
            <table width="100%" cellpadding="0" cellspacing="4">
                <tr>
                    <td width="150" class="leftCaption">
                        用户基本信息</td>
                    <td>
                        <asp:Button ID="ButtonTwo" runat="server" Height="26px" OnClick="Button2_Click1" Text="用户文件"
                            Width="105px" />
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        用户ID：
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        关注时间：
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        最后一次访问时间：
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        用户昵称：
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td  class="leftCaption">
                        用户性别：
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        用户来源：
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        用户签名：
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="leftCaption">
                        用户地址：
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td class="leftCaption">
                        用户积分：
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </div>
            </div>
        </asp:Panel>


    </form>
</body>
</html>
