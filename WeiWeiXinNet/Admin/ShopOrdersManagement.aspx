<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.ShopOrdersManagement" CodeBehind="ShopOrdersManagement.aspx.cs" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.IO" %>
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
    </script>
</head>
<body  >
    <div class="main-box">
        <div class="head-dark-box">
            ��ǰ��������
        </div>

        <form id="weweixin_form" runat="server">
         <div class="body-box">
         ��ע˵�����鿴��ǰ��Ҫ����Ķ����б�������Բ鿴�������飬 ����Ա����ֱ���ڶ����ϻظ����û�
            <div class="white-box">
            <asp:Panel ID="Panel1" runat="server">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </asp:Panel>
            <div>
                <asp:Panel runat="server" ID="Panel2" Visible="false">
                    <div>
                    </div>
                    <div>
                        <asp:TextBox ID="WeTextBoxOne" runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="WeTextBoxTwo" runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="WeTextBoxThree" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button runat="server" ID="ButtonOne" Text="����" OnClick="ButtonOne_Click" /><asp:Button
                            runat="server" ID="ButtonTwo" Text="ȡ��" OnClick="ButtonTwo_Click" />
                        <br />
                        <br />
                    </div>
                </asp:Panel>
            </div>
        </div>
        </div>
        </form>
    </div>
</body>
</html>
