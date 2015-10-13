<%@ Page Title="登录" Language="C#"  AutoEventWireup="True" CodeBehind="MicroWallManagement.aspx.cs" Inherits="WeiWeiXinNet.admin.MicroWallManagement" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微墙管理</title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
            微墙管理：用户在微信中输入 Q，实现微墙查询，输入 微墙@信息内容 ，实现向微墙发布信息 , 管理员在此处管理用户发布的信息
        </div>
         
    <form id="weweixin_form" runat="server">
    <div>
 	 
	<div>
		<iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100" 
            onexecutecommand="FileManager1_ExecuteCommand">
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
        <asp:Panel runat="server" ID="TextEditor" Visible="false">
            <div>
                <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="500px" Width="1100"/>
            </div>
            <div>
                <asp:Button runat="server" ID="ButtonOne" Text="保存" OnClick="ButtonOne_Click" /><asp:Button runat="server" ID="ButtonTwo" Text="取消" OnClick="ButtonTwo_Click" />
            </div>
        </asp:Panel>
	</div>
 
    </div>
    </form>
   </div>
</body>
</html>



 

