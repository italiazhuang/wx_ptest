<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicConfigManagement" CodeBehind="WeiXinBasicConfigManagement.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="./img2/stylet.css">
    <link href="include/admin.css" rel="stylesheet" type="text/css" />
    
    <script language="javascript">
        function jsED() {
            if (confirm("确定保存?")) {
                return true;
            }
            return false;
        }
    </script>
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
            微信基础设置：请按照提示填写您的微信号的相关内容
        </div>
        <div class="body-box">
        <form id="weweixin_form" runat="server">
        <table style="margin: 0;" border="0" cellspacing="0" cellpadding="0"
            width="100%">
            <tr>
                <td class="leftCaption" width="200">
                    微信系统名称
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxOne" runat="server" Width="350px"></asp:TextBox> 提示：填写您的微信的名称
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    微信系统号
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxTwo" runat="server" Width="350px"></asp:TextBox>
                    提示：填写您的微信号码
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    关注时发送用户的消息
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxThree" runat="server" Width="350px" Height="44px" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    如：欢迎关注【{0}】,您是我们第{1}关注者，输入 HELP 查看更多内容
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    特别注意
                </td>
                <td>
                    当图文回复、音频回复、文本回复中有 “Start”关键词的时候，系统将会在关注后，自动返回&quot;Start&quot;关键词中设置的内容<br />
                    当系统不能识别用户的输入时，将会自动返回&quot;HELP&quot;关键词中设置的内容
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    时间戳加密（8个字符长度）
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxFour" runat="server" Width="350px" MaxLength="8"></asp:TextBox>如：abc12345
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    <nobr>Token(与微信后台Token参数一致)</nobr>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxToken" runat="server" Width="350px" MaxLength="32"></asp:TextBox>必须为英文或者数字，长度为3-32个字符
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    微社区进入消息 标题
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxSix" runat="server" Width="350px"></asp:TextBox>
                    提示：微信关键字不能匹配时 自动显示微社区进入消息
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    微社区进入消息 内容
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxSeven" runat="server" Width="350px"></asp:TextBox>
                    提示：
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    微社区进入消息 图片
                </td>
                <td>
                    <asp:Image ID="Image1" name="Image1" runat="server" Width="160px" />
                    <asp:TextBox ID="txt0" name="txt0" runat="server" Width="186px"></asp:TextBox>
                    <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./MainSelectImg.aspx',100,100,880,490);">点击选择图片</a>
                </td>
            </tr>
            <tr>
                <td class="leftCaption">
                    用户数量起始（签到后会自动加1）
                </td>
                <td>
                    <asp:TextBox ID="WeTextBoxFive" runat="server" Width="350px" MaxLength="8"></asp:TextBox>如：500
                </td>
            </tr>
            <tr>
                <td  colspan="2" class="footCaption">
                <div class="with-line">
                    <asp:Button ID="ButtonOne" CssClass="button" runat="server" Text="保 存" Width="99px" OnClick="ButtonOne_Click" />
                </div>
                </td>
            </tr>
        </table>
        </form>
        </div>
    </div>
</body>
</html>
