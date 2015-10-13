<%@ Page Language="C#" AutoEventWireup="True"  ValidateRequest ="false" Inherits="WeiWeiXinNet.admin.TopNewsEditor" Codebehind="TopNewsEditor.aspx.cs" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<link href="include/admin.css" rel="stylesheet" type="text/css" />   
  <script type="text/javascript">	
  
  function jsSave() {
      if (confirm("确定保存吗?")) {
          return true;
      }
      return false;
  }

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



  function opentest() {
    //  var ss = document.getElementById("TextBoxUrl").value;

      var ss2 = "../USER_DIR/SYSUSER/GUNDONG/news.htm";

      PopUpWindow(ss2, 20, 20, 400, 650)

  }



  </script>
    </head>
<body >
<div class="main-box">
<div class="head-dark-box">
		欢迎使用
	</div>
	<div class="body-box">
		<span class="red"></span> 您好,欢迎回来,您登录时间是:<span id="TimeSpan" class="red"></span>.
		<p>请点击左侧菜单进行操作.</p>
	 

     <form id="weweixin_form" runat="server">
 
                     <table  width="100%">
                     
                     <tr><td>
                         滚动通知内容&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="ButtonOne" runat="server" Text="保存" Width="82px" 
                            onclick="ButtonOne_Click" Height="29px" />
                         </td></tr>  
                      <tr><td>
                               <CKEditor:CKEditorControl ID="WeTextBoxOne" runat="server" Height="83px" 
                              CustomConfig="config2.js">
	                            内容编辑
		                       </CKEditor:CKEditorControl>
                          </td></tr>  
                       <tr><td>消息内容 &nbsp; <a href="javascript:void(0);" onclick="javascript:opentest();">【测试】</a>
                      
                      </td></tr>  
                        <tr><td>&nbsp;<CKEditor:CKEditorControl ID="WeTextBoxTwo" runat="server" Height="219px">
	                            内容编辑
		                       </CKEditor:CKEditorControl>
                            </td></tr>  
                         <tr><td>&nbsp;</td></tr>  
                     </table>

    </form> </div>
</div>
</body>
</html>