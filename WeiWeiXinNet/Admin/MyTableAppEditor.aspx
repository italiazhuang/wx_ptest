<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.MyTableAppEditor"
    CodeBehind="MyTableAppEditor.aspx.cs" %>

<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        var popUpWin = 0;
        function PopUpWindow(URLStr, left, top, width, height, newWin, scrollbars) {
            if (typeof (newWin) == "undefined")
                newWin = false;

            if (typeof (left) == "undefined")
                left = 100;

            if (typeof (top) == "undefined")
                top = 0;

            if (typeof (width) == "undefined")
                width = 800;

            if (typeof (height) == "undefined")
                height = 760;

            if (newWin) {
                open(URLStr, '', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
                return;
            }

            if (typeof (scrollbars) == "undefined") {
                scrollbars = 0;
            }

            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
            popUpWin.focus();
        }


    


        function jsModel() {
            if (confirm("ģ�彫�������б༭�����ã�ȷ������?")) {
                return true;
            }
            return false;
        }

        function opentest() {
            var ss = document.getElementById("WeTextBoxThree").value;


            var ss2 = "..\\WebSurvey\\m.aspx?t=USER_DIR\\SYSUSER\\table\\table1\\" + ss+ ".dll";

            PopUpWindow(ss2, 20, 20, 400, 650)

        }

    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body  >
    <div class="main-box">
        <div class="head-dark-box">
          �ҵı����������½����������µı����ߵ�����ռ���������û���д�����ݽ����ռ������밴��������д
        </div>
        <form id="weweixin_form" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="144px">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                &nbsp; ������URL��<asp:TextBox ID="WeTextBoxTwo" runat="server" Width="338px"></asp:TextBox>
                &nbsp;
                <iz:FileManager ID="FileManager1" runat="server" Height="500" OnExecuteCommand="FileManager1_ExecuteCommand"
                    OnToolbarCommand="FileManager1_ToolbarCommand" Width="1100">
                    <RootDirectories>
                        <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
                    </RootDirectories>
                    <CustomToolbarButtons>
                        <iz:CustomToolbarButton CommandName="GETDATA" ImageUrl="~/images/icons/get.png" Text="��ȡ��URL" />
                        <iz:CustomToolbarButton CommandName="GETDATA2" ImageUrl="~/images/icons/get.png"
                            Text="�½��� " />
                        <iz:CustomToolbarButton CommandName="GETDATA3" ImageUrl="~/images/icons/get.png"
                            Text="�ռ����� " />
                        <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
                    </CustomToolbarButtons>
                    <FileTypes>
                        <iz:FileType Extensions="dll" LargeImageUrl="~/images/32x32/notepad.png" Name="Text Document"
                            SmallImageUrl="~/images/16x16/notepad.png">
                            <Commands>
                                <iz:FileManagerCommand CommandName="EditText" Method="PostBack" Name="Edit (PostBack)"
                                    SmallImageUrl="~/images/16x16/notepad.png" />
                                <iz:FileManagerCommand CommandName="EditText" Name="Edit (Callback)" SmallImageUrl="~/images/16x16/notepad.png" />
                            </Commands>
                        </iz:FileType>
                    </FileTypes>
                </iz:FileManager>
            </asp:Panel>
            <br />
            <asp:Panel runat="server" ID="TextEditor" Visible="false">
                <div>
                    <table class="style1">
                        <tr>
                            <td>
                            </td>
                            <td>
                                ������(�����������ַ�)��<asp:TextBox ID="WeTextBoxThree" runat="server"></asp:TextBox>
                                &nbsp; <a href="javascript:void(0);" onclick="javascript:opentest();" 
                                        style="color: #99FF33">���Ա�</a>  &nbsp; <asp:Button ID="ButtonOne" runat="server" Text="����" OnClick="Button1_Click1" />
                                <asp:Button ID="ButtonTwo" runat="server" Text="ȡ��" OnClick="ButtonTwo_Click" />
                                <asp:Button ID="ButtonThree" runat="server" OnClick="ButtonThree_Click" Text="����1" Width="62px" />
                                <asp:Button ID="ButtonFour" runat="server" OnClick="ButtonFour_Click" Text="����2" Width="62px" />
                                <asp:Button ID="ButtonFive" runat="server" OnClick="ButtonFive_Click" Text="����3" Width="61px" />
                                <asp:Button ID="ButtonSix" runat="server" OnClick="ButtonSix_Click" Text="����4" Width="60px" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2">
                                <asp:TextBox ID="WeTextBoxOne" runat="server" Height="400" TextMode="MultiLine" Width="1100" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                </div>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <asp:Button ID="Button9" runat="server" OnClick="ButtonNine_Click" Text="����" Width="83px" />
                <br />
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <br />
            </asp:Panel>
        </div>
        </form>
    </div>
</body>
</html>
<%-- ��Ȩ���� udoo123.taobao.com--%>