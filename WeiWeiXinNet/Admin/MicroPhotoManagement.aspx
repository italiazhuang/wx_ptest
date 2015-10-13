<%@ Page Title="登录" Language="C#"  AutoEventWireup="True"
    CodeBehind="MicroPhotoManagement.aspx.cs" Inherits="WeiWeiXinNet.admin.MicroPhotoManagement" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微相册管理</title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            微相册管理： 用户向微信发送 图片文件 ，会自动保存到微相册中，在微信中输入 FT 可以查看微相册
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
               
            </div>
            <div>
                <asp:Button runat="server" ID="ButtonOne" Text="Save" OnClick="ButtonOne_Click" /><asp:Button runat="server" ID="ButtonTwo" Text="Cancel" OnClick="ButtonTwo_Click" />
            </div>
        </asp:Panel>
	</div>
 
    </div>
    </form>
   </div>
</body>
</html>



 

