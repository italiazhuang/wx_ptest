<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" Inherits="dzp" Codebehind="Turntable.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="./wx/style.css" rel="stylesheet" type="text/css" />
    <title>大转盘</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
<meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1">
    <script type="text/javascript" language="javascript" src="./wx/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="./wx/jQueryRotate.2.2.js"></script>
    <script type="text/javascript" language="javascript" src="./wx/jquery.easing.min.js"></script>
    <script type="text/javascript" language="javascript" src="./wx/alert.js"></script>

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


    <script language="javascript" type="text/javascript">
        $(function () {
            var rotateFunc = function (angle, text) {  //awards:奖项，angle:奖项对应的角度
                $('#lotteryBtn').stopRotate();
                $("#lotteryBtn").rotate({
                    angle: 0,
                    duration: 5000,
                    animateTo: angle + 1440, //angle是图片上各奖项对应的角度，1440是我要让指针旋转4圈。所以最后的结束的角度就是这样子^^
                    callback: function () {
                        alert(text)
                    }
                });
            };
            $("#btnstart").rotate({
                bind: {
                    click: function () {
                        //  var data = [1, 2, 3, 4, 5, 0,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99]; //返回的数组

                        var data = [<% =GetSet() %>];
                        data = data[Math.floor(Math.random() * data.length)];
                        //                        $.ajax({
                        //              type: "get",
                        //              url: "request.php?result=" + data,
                        //              cache: false,
                        //              success: function (html) {
                        //                alert(html);
                        //              }
                        //            });
                        if (data == 1 || data == 2) {//一等奖2%
                            rotateFunc(0, '恭喜您抽中的一等奖')
                            document.getElementById("hide").value = "一等奖";
                            window.setTimeout("printI()", 6000);
                        }
                        else if (data == 3 || data == 4 || data == 5 || data == 6 || data == 7) {//二等奖10%
                            rotateFunc(60, '恭喜您抽中的二等奖')
                            document.getElementById("hide").value = "二等奖";
                            window.setTimeout("printI()", 6000);
                        }
                        else if (data == 8 || data == 9 || data == 10 || data == 11 || data == 12 || data == 13 || data == 14 || data == 15) {//三等奖16%
                            var angle = [120, 300];
                            angle = angle[Math.floor(Math.random() * angle.length)]
                            rotateFunc(angle, '恭喜您抽中的三等奖')
                            document.getElementById("hide").value = "三等奖";
                            window.setTimeout("printI()", 6000);
                        }
                        else if (data == 16 || data == 17 || data == 18 || data == 19 || data == 20 || data == 21 || data == 22 || data == 23 || data == 24 || data == 25 || data == 26) {//四等奖22%
                            rotateFunc(180, '恭喜您抽中的四等奖')
                            document.getElementById("hide").value = "四等奖";
                            window.setTimeout("printI()", 6000);
                        }
                        else if (data == 27 || data == 28 || data == 29 || data == 30 || data == 31 || data == 32 || data == 33 || data == 34 || data == 35 || data == 36 || data == 37 || data == 38 || data == 39 || data == 40) {//四等奖28%
                            rotateFunc(240, '恭喜您抽中的五等奖')
                            document.getElementById("hide").value = "五等奖";
                            window.setTimeout("printI()", 6000);
                        }
                        else {
                            var angle = [30, 90, 150, 210, 270, 330];
                            var msg = ['不要灰心', '祝你好运', '再接再厉', '运气先攒着', '要加油哦', '谢谢参与'];
                            var rd = Math.floor(Math.random() * angle.length);
                            angle = angle[rd];
                            msg = msg[rd];
                            rotateFunc(angle, msg);
                            document.getElementById("hide").value = "没中奖";
                            window.setTimeout("printI()", 6000);
                        }
                    }
                }
            });
        });
    </script>

    <script language="javascript" type="text/javascript">  
    function printI()  {  
    var btn = document.getElementById("Button1");
        btn.click();
        }
    </script>

</head>
<body background="wx/test.jpg">
<div>
    <form id="form1" runat="server">
            <div class="main" id="main" runat="server">
                <div class="out">
                    <div class="out1">
                        <img id="lotteryBtn" src="./wx/out.png" width="250" alt="" />
                    </div>
                </div>
                <div class="in">
                    <div class="in1">
                        <img id="btnstart" src="./wx/in.png" alt="" /></div>
                </div>
            </div>
            <div class="zt" id="zt" runat="server">
                <div class="fl1">
                </div>
                <div class="fl">
                    <% =GetJiangPing() %>
                </div>
            </div>
            <div class="zt" runat="server" id="gz">
                <div class="fl1"></div>
                <div class="fl">
                    <div class="hang"></div>
                    <div class="hang"></div>
                    <div style="display:none;">
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="hide" runat="server" />
                </div>
            </div>
            
            <div class="jx">
               </div>                
                <!--抽奖次数用完页面-->
                <div class="csyw" id="csyw" runat="server"></div>                
                 <!--中奖页面-->
                <div class="zjl" id="zjl" runat="server">
                <div class="xx">
                <div class="he"> <asp:Label ID="Label3" runat="server" 
                        Text="恭喜您已经中奖，请输入手机号，稍后客服人员会和您取得联系"></asp:Label></div>
                <div class="he">
                    手机号：<asp:TextBox ID="TextBox2" runat="server" 
                        Width="239px"></asp:TextBox></div>
                <div class="he">
                    <asp:LinkButton ID="LinkButton1"  runat="server"  style=" width:auto; height:auto; " OnClick="insj_Click"  >
                       <asp:Image ID="Image2" runat="server" style=" width:90px; height:30px; margin-left:100px;" ImageUrl="./wx/tj.jpg" />
               </asp:LinkButton>
                    </div>
                </div>
                </div>
                 <!--中奖结束页面-->
                <div class="zjjs" id="zjjs" runat="server"></div>
                 <!--再次抽奖页面-->
                <div class="zccj" id="zccj" runat="server">
                <div class="xx1">
                <div class="he1">
               <asp:LinkButton ID="LinkButton8"  runat="server"  style=" width:auto; height:auto; " OnClick="ID1_Click"  >
                   <asp:Image ID="Image1" runat="server" style=" width:90px; height:30px; margin-left:100px;" ImageUrl="./wx/jxcj.jpg" />
               </asp:LinkButton>
                </div>
                </div>
                </div>
    </form>
        </div>
</body>
</html>
