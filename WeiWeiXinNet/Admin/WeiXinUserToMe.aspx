<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.WeiXinUserToMe" Codebehind="Main15.aspx.cs" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
          用户反馈信息：用户反馈统计结果收集，帮助您了解用户需求
        </div>
    <form id="weweixin_form" runat="server">
	<div>
		<iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100px" 
            onexecutecommand="FileManager1_ExecuteCommand" BackColor="#EDEBE0" 
            BorderColor="#ACA899" BorderWidth="1px" 
            Font-Names="Tahoma,Verdana,Geneva,Arial,Helvetica,sans-serif" Font-Size="11px" 
            ForeColor="Black" meta:resourcekey="FileManager1Resource1">
			<RootDirectories>
				<iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
			</RootDirectories>
            <FileTypes>
                <iz:FileType Extensions="txt,htm,html,css,js,ini,config" Name="Text Document" SmallImageUrl="~/images/16x16/notepad.png"  LargeImageUrl="~/images/32x32/notepad.png">
                    <Commands>
                        <iz:FileManagerCommand Name="Edit (PostBack)" Method="PostBack" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                        <iz:FileManagerCommand Name="Edit (Callback)" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                    </Commands>
                </iz:FileType>
            </FileTypes>
		</iz:FileManager>
        <asp:Panel runat="server" ID="TextEditor" Visible="False" 
            meta:resourcekey="TextEditorResource1">
            <table width="90%" align="center" cellpadding="0" cellspacing="4" id="myTable">
            <tr>
                <td class="leftCaption" width="100">发送时间：</td>
                <td>
                    <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1"  Text="Label"></asp:Label>
                 </td>
              </tr>

              <tr>
                <td class="leftCaption">用户账号：</td>
                <td>
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1" Text="Label"></asp:Label>
                </td>
              </tr>
              <tr>
                <td class="leftCaption">用户来源：</td>
                <td>
                    <asp:Label ID="Label3" runat="server" meta:resourcekey="Label3Resource1"  Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                <td class="leftCaption">用户性别：</td>
                <td>
                    <asp:Label ID="Label4" runat="server" meta:resourcekey="Label4Resource1"  Text="Label"></asp:Label>
                </td>
              </tr>

              <tr>
                <td class="leftCaption">用户意见：</td>
                <td>
                    <asp:Label ID="Label5" runat="server" meta:resourcekey="Label5Resource1"  Text="Label"></asp:Label>
                </td>
              </tr>
              <tr>
                <td class="leftCaption">原始数据：</td>
                <td>
                    <asp:TextBox ID="WeTextBoxOne" runat="server" Height="41px" meta:resourcekey="TextBox1Resource1" TextMode="MultiLine" Width="442px"  Visible="False" />
                </td>
              </tr>
              <tr class="footCaption">
                <td colspan="2">
                    <div class="with-line">
                    <asp:Button ID="ButtonTwo" runat="server" OnClick="ButtonTwo_Click" Text="取消"  CssClass="button"/>
                    </div>
                  </td>
              </tr>
            </table>
        </asp:Panel>
	</div>
    </form>
   </div>
</body>
</html>



 

