<%@ Page Title="登录" Language="C#"   AutoEventWireup="True"
    CodeBehind="VocDataBase.aspx.cs" Inherits="WeiWeiXinNet.admin.VocDataBase" %>

<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
       

        function fooClose() {
            window.close();

        }
        function foo() {
            window.close();


            window.opener.document.getElementById("txt0").value = document.getElementById("WeTextBoxTwo").value
            window.opener.document.getElementById("Image1").setAttribute("src", document.getElementById("WeTextBoxTwo").value);
        } 


    </script>
</head>
<body>
 <div class="main-box">
        <div class="head-dark-box">
            音频素材管理 ： 管理订阅号音频回复所需的音频素材
        </div>
        
    <form id="weweixin_form" runat="server">
    <div>
        <div>
            
             
            <iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100" OnExecuteCommand="FileManager1_ExecuteCommand"
                OnToolbarCommand="FileManager1_ToolbarCommand">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath="~/USER_DIR/SYSUSER/VOCDATA/" Text="音频文件夹" />
                </RootDirectories>
                <CustomToolbarButtons>
           
                </CustomToolbarButtons>
                <FileTypes>
                  
                </FileTypes>
            </iz:FileManager>
            <asp:Panel runat="server" ID="TextEditor" Visible="false">
                <div>
                    <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="500" Width="1000" />
                </div>
                <div>
                    <asp:Button runat="server" ID="ButtonOne" Text="Save" OnClick="ButtonOne_Click" /><asp:Button
                        runat="server" ID="ButtonTwo" Text="Cancel" OnClick="ButtonTwo_Click" />
                </div>
            </asp:Panel>
        </div>
     
    </form>
    </div>
</body>
</html>
