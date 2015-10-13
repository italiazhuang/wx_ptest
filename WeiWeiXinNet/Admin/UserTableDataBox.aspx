<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.UserTableDataBox" Codebehind="UserTableDataBox.aspx.cs" %>

<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap-combined.min.css" rel="stylesheet">
 
</head>
<body  >
    <div class="main-box">
        <div class="head-dark-box">
            欢迎使用
        </div>
        <div class="body-box">
            <span class="red"></span>您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
            每个表单占用一个文件夹，同一个用户单次或多次填写的表单会存放在以该用户ID命名的文件中</div>
        <form id="weweixin_form" runat="server">
        <div>

        		<asp:Panel ID="Panel1" runat="server" Height="172px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:GridView ID="gv_show" runat="server" AutoGenerateColumns="False" 
                Width="95%" AllowPaging="True" OnPageIndexChanging="gv_show_PageIndexChanging" 
                PageSize="10000" BorderWidth="1px" onrowediting="gv_show_RowEditing" 
                onrowdatabound="gv_show_RowDataBound">
        <Columns>
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <%# Eval("编号").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="关注时间">
                    <ItemTemplate>
                        <%# Eval("关注时间").ToString()%>
                    </ItemTemplate>                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="最近访问时间">
                    <ItemTemplate>
                        <%# Eval("最后访问时间").ToString()%>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="最后写入时间">
                    <ItemTemplate>
                        <%# Eval("最后写入时间").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>

              <asp:TemplateField HeaderText="标示符">
                    <ItemTemplate>
                        <%# Eval("标示符").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>


        </Columns>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                NextPageText="Next" PreviousPageText="Previous" />
        </asp:GridView> 

        </asp:Panel>

            <div>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <iz:FileManager ID="FileManager1" runat="server" Height="400" Width="800" OnExecuteCommand="FileManager1_ExecuteCommand"
                    OnToolbarCommand="FileManager1_ToolbarCommand">
                    <RootDirectories>
                        <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
                    </RootDirectories>
                    <CustomToolbarButtons>
                       <%-- <iz:CustomToolbarButton Text="收集结果" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />--%>
                        <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
                    </CustomToolbarButtons>
                    <FileTypes>
                        <iz:FileType Extensions="dll" Name="Text Document" SmallImageUrl="~/images/16x16/notepad.png"
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
    </div>
</body>
</html>
