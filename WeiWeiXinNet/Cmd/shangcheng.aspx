<%@ Page Language="C#" AutoEventWireup="true" Inherits="shangcheng" CodeBehind="shangcheng.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,height=device-height,inital-scale=1.0,maximum-scale=1.0,user-scalable=no;">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title></title>
    <link href= 'Styles/Style.css' rel='stylesheet' type='text/css'>
    <script type="text/javascript">
        function dwd2() {
            jBox.alert("WeWeiXin.NET", '关于我们', { width: 300, height: 150 });
        }  
    </script>
    <script type="text/javascript">
        function DoIt0() {
            PageMethods.DoEasy(String(0), CallBack);
        }
        function DoIt2() {

            var txt = document.getElementById("Text1").value;

            id = Number(txt);
            id--;
            if (id < 0)
                id = 0;
            document.getElementById("Text1").value = String(id);
            PageMethods.DoEasy(String(id), CallBack);
        }
        function DoIt() {
            var txt = document.getElementById("Text1").value;
            id = Number(txt);
            id++;
            if (id >= 10 - 1)
                id = 10 - 1;
            document.getElementById("Text1").value = String(id);
            PageMethods.DoEasy(String(id), CallBack);
        }
        function CallBack(result) { //result是接收PageMethods.DoEasy的返回值
            // var inTxt = document.getElementById("Text1").value;
            var txt = document.getElementById("ShowSpanP");
            txt.style.display = "inline";
            txt.innerHTML = "<br/>" + result;
        }
        function AddProduct(id, name, price) {
            PageMethods.DoEasyP(id + "|" + name + "|" + price, CallBackP);
        }
        function CallBackP(result) { //result是接收PageMethods.DoEasy的返回值

            var txt = document.getElementById("ShowSpanP");
            txt.style.display = "inline";
            txt.innerHTML = "<br/>" + result;
        } 
    </script>
</head>
<body onload="DoIt0()">
    <form id="weweixin_form" runat="server">
    <div class="cardexplain">
        <ul class="round">
            <asp:ScriptManager ID="sm1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
            <li class="title">微商店</li>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="cpbiaoge">
                <tr>
                    <td>
                        <asp:TextBox ID="WeTextBoxOne" runat="server" Width="95%" Text="买家留言：【请确认送货地址】" Style="border-radius: 5px 5px;height:80px" TextMode="MultiLine"></asp:TextBox>
						<div><asp:Button ID="ButtonOne" runat="server" OnClick="Button1_Click1" Width="100%" Text="订购" CssClass="submit2" Style="width:100%;border-radius: 5px 5px; height: 48px;"/></div>
                        <div><asp:LinkButton ID="LinkButton1" runat="server" Visible="False">查看订单</asp:LinkButton>
                        <asp:Label ID="Label1" runat="server"></asp:Label></div>
                    </td>
				</tr>
                <tr>
                    <td style="padding:0;border:0">
                         <span style="color: Black; display: none" id="ShowSpanP">这里是显示内容</span>
                    </td>
                </tr>
            </table>
        </ul>
    </div>
    </form>
</body>
</html>
