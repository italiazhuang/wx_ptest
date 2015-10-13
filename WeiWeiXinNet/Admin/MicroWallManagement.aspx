<%@ Page Title="��¼" Language="C#"  AutoEventWireup="True" CodeBehind="MicroWallManagement.aspx.cs" Inherits="WeiWeiXinNet.admin.MicroWallManagement" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>΢ǽ����</title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
            ΢ǽ�����û���΢�������� Q��ʵ��΢ǽ��ѯ������ ΢ǽ@��Ϣ���� ��ʵ����΢ǽ������Ϣ , ����Ա�ڴ˴������û���������Ϣ
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
                <asp:Button runat="server" ID="ButtonOne" Text="����" OnClick="ButtonOne_Click" /><asp:Button runat="server" ID="ButtonTwo" Text="ȡ��" OnClick="ButtonTwo_Click" />
            </div>
        </asp:Panel>
	</div>
 
    </div>
    </form>
   </div>
</body>
</html>



 

