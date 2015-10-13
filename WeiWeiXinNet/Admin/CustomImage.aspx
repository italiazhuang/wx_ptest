<%@ Page Title="登录" Language="C#"  AutoEventWireup="True"
    CodeBehind="CustomImage.aspx.cs" Inherits="WeiWeiXinNet.admin.CutomImage" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.IO" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="main-box">
        <div class="head-dark-box">
            欢迎使用
        </div>
        <div class="body-box">
            <span class="red"></span>您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
           
        </div>
    <form id="weweixin_form" runat="server">
    <div>
 
	<div>
		<iz:FileManager ID="FileManager1" runat="server" Height="400" Width="600" 
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
                <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="400" Width="600"/>
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



 

