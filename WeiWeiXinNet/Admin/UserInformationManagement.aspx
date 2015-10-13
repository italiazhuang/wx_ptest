<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.UserInformationManagement" Codebehind="UserInformationManagement.aspx.cs" %>
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
<body >
    <div class="main-box">
        <div class="head-dark-box">
            �û���Ϣ
        </div>
        <div class="body-box">
         ��ע˵�����û���Ϣ����ÿ���û�һ���ļ���
        <form id="weweixin_form" runat="server">
        <div class="white-box">
 		<asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gv_show" CssClass="list-table" runat="server" AutoGenerateColumns="False" 
                Width="100%"  GridLines="None" AllowPaging="True" OnPageIndexChanging="gv_show_PageIndexChanging" 
                PageSize="10000" onrowediting="gv_show_RowEditing" 
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
        <HeaderStyle CssClass="head-light-box" />
       <FooterStyle CssClass="head-light-box"/>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
        </asp:GridView> 

        </asp:Panel>
        <br />
	 
	</div>
    </form>
   </div>
   </div>
</body>
</html>



 

