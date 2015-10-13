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
            ��ӭʹ��
        </div>
        <div class="body-box">
            <span class="red"></span>����,��ӭ����,����¼ʱ����:<span id="TimeSpan" class="red"></span>.
            ÿ����ռ��һ���ļ��У�ͬһ���û����λ�����д�ı��������Ը��û�ID�������ļ���</div>
        <form id="weweixin_form" runat="server">
        <div>

        		<asp:Panel ID="Panel1" runat="server" Height="172px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:GridView ID="gv_show" runat="server" AutoGenerateColumns="False" 
                Width="95%" AllowPaging="True" OnPageIndexChanging="gv_show_PageIndexChanging" 
                PageSize="10000" BorderWidth="1px" onrowediting="gv_show_RowEditing" 
                onrowdatabound="gv_show_RowDataBound">
        <Columns>
                <asp:TemplateField HeaderText="���">
                    <ItemTemplate>
                        <%# Eval("���").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��עʱ��">
                    <ItemTemplate>
                        <%# Eval("��עʱ��").ToString()%>
                    </ItemTemplate>                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�������ʱ��">
                    <ItemTemplate>
                        <%# Eval("������ʱ��").ToString()%>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���д��ʱ��">
                    <ItemTemplate>
                        <%# Eval("���д��ʱ��").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>

              <asp:TemplateField HeaderText="��ʾ��">
                    <ItemTemplate>
                        <%# Eval("��ʾ��").ToString()%>
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
                       <%-- <iz:CustomToolbarButton Text="�ռ����" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />--%>
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
