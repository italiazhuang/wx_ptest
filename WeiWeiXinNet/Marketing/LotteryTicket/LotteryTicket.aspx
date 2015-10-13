<%@ Page Language="C#" AutoEventWireup="true" Inherits="LotteryTicket" Codebehind="LotteryTicket.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>刮刮卡</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1" />
 <script type="text/javascript" src="ggk/jquery.1.9.1.min.js"></script>
    <script type="text/javascript" src="ggk/wScratchPad.js"></script>
     <link href="ggk/style.css" rel="stylesheet" type="text/css" />
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
    <form id="form1" runat="server">
    <div>
        
        <div class="bd"  id="bd" runat="server">
        <div class="cj">
        <div class="gjq" runat="server" id="gjq">
        <div id="wScratchPad2" style="display:inline-block; position:relative; border:solid black 1px;"></div>
          <script  language="javascript" type="text/javascript">
//          var imurl=document.getElementById("hide").value;
            $("#wScratchPad2").wScratchPad({
                   color: 'grey',
//                image:'ggk/images/1.jpg',

            });

        </script>
        </div>
        </div>
         <div class="sm">
        <div class="hang">
         <asp:Button ID="Button1" runat="server" style=" width:120px; height:30px; border:0px; margin-left:100px; background-color:#f7bf38;" Text="提交并继续" OnClick="Button1_Click" />
        </div>
        <div class="sm"><!--120 -->
        <div class="hang"></div>
                    <div class="hang">一等奖：送50积分；二等奖：送40积分</div>
                    <div class="hang">三等奖：送30积分；四等奖：送20积分</div>
                    <div class="hang">五等奖：送10积分</div>
        </div>
       
        </div>
         <div class="sm"><!--210 -->
        <div class="hang"></div>
        <div class="hang" style=" height:auto; color:Red; line-height:35px;">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
        <div class="hang" style=" height:auto;">1、抽奖完毕请点击“提交并继续”按钮</div>
          <div class="hang" style=" height:auto;">可继续抽奖或领取奖品</div>
        <div class="hang" style=" height:auto;">2、每人只有一次中奖机会，抽到奖品之</div>
        <div class="hang" style=" height:auto;">后不能再次抽奖便
       
         <asp:HiddenField ID="hide" runat="server" /></div>
           <div class="hang" style=" height:auto;">3、进入本页面即消耗一次抽奖机会</div>
        </div>
        </div>
         <!--次数用完-->
          <div class="csyw" id="csyw" runat="server">

                </div>
                
                 <!--中奖页面-->
                <div class="zjl" id="zjl" runat="server">
                <div class="xx">
                <div class="he"> <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></div>
                <div class="he" style=" font-size:20px; color:#610000; line-height:30px;">
                    手机号：<asp:TextBox ID="TextBox2" runat="server" style=" width:200px; height:28px;"></asp:TextBox></div>
                <div class="he">
                
                    <asp:Button ID="Button2" runat="server" Text="提交" style=" width:120px; height:30px; margin-left:60px;" OnClick="Button2_Click" />
                  <%--  <asp:LinkButton ID="LinkButton1"  runat="server"  style=" width:auto; height:auto; " OnClick="insj_Click"  >
                       <asp:Image ID="Image2" runat="server" style=" width:90px; height:30px; margin-left:80px;" ImageUrl="~/wx/tj.jpg" />
               </asp:LinkButton>--%>
                    </div>
                </div>
                </div>
                 <!--中奖结束页面-->
                <div class="zjjs" id="zjjs" runat="server"></div>
    </div>
    </form>
</body>
</html>
