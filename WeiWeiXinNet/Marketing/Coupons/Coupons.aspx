<%@ Page Language="C#" AutoEventWireup="true" Inherits="defaults" Codebehind="Coupons.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta content="width=device-width, initial-scale=1.0, maximum-scale=2.0, user-scalable=yes" name="viewport" />
<title> </title>
<link type="text/css" rel="stylesheet" href="css/style.css" />

  <script language="javascript" type="text/javascript">
      function onBridgeReady() {
          document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
              WeixinJSBridge.call('hideOptionMenu');
          });

          document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
              WeixinJSBridge.call('hideToolbar');
          });

      }

      if (typeof WeixinJSBridge == "undefined") {
          if (document.addEventListener) {
              document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
          } else if (document.attachEvent) {
              document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
              document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
          }
      } else {
          onBridgeReady();
      }

    </script> 

</head>
<body>
<div id="Main">
    <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
        <asp:Label ID="LabelTxt" runat="server" Text=""></asp:Label>
		</form>
 
<div class="Info"><strong> </strong><br>
  <b>Copyright   2000-2013</b>  </div>
</div>
</body>
</html>

