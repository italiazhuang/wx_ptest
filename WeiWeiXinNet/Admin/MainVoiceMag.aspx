<%@ Page Title="��¼" Language="C#"   AutoEventWireup="True"
    CodeBehind="MainVoiceMag.aspx.cs" Inherits="WeiWeiXinNet.admin.MainVoiceMag" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="include/admin.css" rel="stylesheet" type="text/css" />
  
  <script type="text/javascript">
  

      function foo() {
          window.close();

          if (document.getElementById("WeTextBoxTwo").value != "")
          {
          window.opener.document.getElementById("txt0").value = document.getElementById("WeTextBoxTwo").value
          }
      } 


    </script>
    </head>
<body  >
    
    <form id="weweixin_form" runat="server">
    <div>
 
	<div>
        <input type=button value="�ر�" onclick="foo();"> ѡ�����Ƶ<asp:TextBox ID="WeTextBoxTwo" 
            Name="WeTextBoxTwo" runat="server" Width="368px"></asp:TextBox>
        <asp:Button ID="ButtonThree" runat="server" onclick="ButtonThree_Click" Text="��������" />
        <asp:Button ID="ButtonFour" runat="server"  Text="¼��һ������" 
            onclick="ButtonFour_Click" />
        <br />
		<iz:FileManager ID="FileManager1" runat="server" Height="400" Width="800" 
            onexecutecommand="FileManager1_ExecuteCommand"  OnToolbarCommand="FileManager1_ToolbarCommand">
			<RootDirectories>
				<iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
			</RootDirectories>

             <CustomToolbarButtons>
                 <iz:CustomToolbarButton Text="�༭��׼����ͼ" CommandName="GETDATAZ" ImageUrl="~/images/icons/get.png" />
 
                  <iz:CustomToolbarButton Text="�༭��׼����ͼ" CommandName="GETDATAC" ImageUrl="~/images/icons/get.png" />

               <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
            </CustomToolbarButtons>

            <FileTypes>
                <iz:FileType Extensions="jpg,gif,png,bmp" Name="Text Document" SmallImageUrl="~/images/16x16/notepad.png"  LargeImageUrl="~/images/32x32/notepad.png">
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
   
</body>
</html>



 

