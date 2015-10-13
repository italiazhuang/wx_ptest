<%@ Page Title="µ«¬º" Language="C#"  AutoEventWireup="True"
    CodeBehind="MainSelectVoc.aspx.cs" Inherits="WeiWeiXinNet.admin.MainSelectVoc" %>

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

            window.opener.document.getElementById("txt1").value = document.getElementById("WeTextBoxTwo").value
            window.opener.document.getElementById("txt0").value = document.getElementById("WeTextBoxTwo").value
          //  window.opener.document.getElementById("Image1").setAttribute("src", document.getElementById("WeTextBoxTwo").value);
        } 


    </script>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div>
        <div>
            <input type="button" value="πÿ±’" onclick="fooClose();"> “Ù∆µ<asp:TextBox 
                ID="WeTextBoxTwo" Name="WeTextBoxTwo" runat="server" Width="593px"></asp:TextBox><input
                type="button" value="—°‘Ò≤¢ÕÀ≥ˆ" onclick="foo();">
            <br />
            <iz:FileManager ID="FileManager1" runat="server" Height="400" Width="800" OnExecuteCommand="FileManager1_ExecuteCommand"
                OnToolbarCommand="FileManager1_ToolbarCommand">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath="~/USER_DIR/SYSUSER/VOCDATA/" Text="“Ù∆µŒƒº˛º–" />
                </RootDirectories>
                <CustomToolbarButtons>
                    <%--  <iz:CustomToolbarButton Text="±‡º≠’˝∑ΩÕº" CommandName="GETDATAZ" ImageUrl="~/images/icons/get.png" />
                    --%>
                    <iz:CustomToolbarButton Text="—°‘Ò“Ù∆µ" CommandName="GETDATAZ" ImageUrl="~/images/icons/get.png" />
                    <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
                </CustomToolbarButtons>
                <FileTypes>
                    <iz:FileType Extensions="jpg,gif,png,bmp" Name="Text Document" SmallImageUrl="~/images/16x16/notepad.png"
                        LargeImageUrl="~/images/32x32/notepad.png">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit (PostBack)" Method="PostBack" CommandName="EditText"
                                SmallImageUrl="~/images/16x16/notepad.png" />
                            <iz:FileManagerCommand Name="Edit (Callback)" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                        </Commands>
                    </iz:FileType>
                </FileTypes>
            </iz:FileManager>
            <asp:Panel runat="server" ID="TextEditor" Visible="false">
                <div>
                    <asp:TextBox runat="server" ID="WeTextBoxOne" TextMode="MultiLine" Height="400" Width="800" />
                </div>
                <div>
                    <asp:Button runat="server" ID="ButtonOne" Text="Save" OnClick="ButtonOne_Click" /><asp:Button
                        runat="server" ID="ButtonTwo" Text="Cancel" OnClick="ButtonTwo_Click" />
                </div>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
