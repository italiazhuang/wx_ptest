<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.GalleryManagement"  CodeBehind="GalleryManagement.aspx.cs" %>

 
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
            <span class="red"></span>您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.微相册是自动管理,请把文件名命名为该图片的内容说明
           
        </div>
    <form id="weweixin_form" runat="server">
    <div>
 
	<div>
		&nbsp; 图片引用路径:
        <asp:TextBox ID="WeTextBoxTwo" runat="server" Width="316px"></asp:TextBox>
		<iz:FileManager ID="FileManager1" runat="server" Height="400" Width="800" 
            onexecutecommand="FileManager1_ExecuteCommand"   OnToolbarCommand="FileManager1_ToolbarCommand">
			<RootDirectories>
				<iz:RootDirectory DirectoryPath="~/user_dir/IMGUP" Text="上传图片管理" />
			</RootDirectories>

               <CustomToolbarButtons>
                <iz:CustomToolbarButton Text="得到图片引用路径" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
               
            </CustomToolbarButtons>


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
                <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="400" Width="800"/>
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



 

