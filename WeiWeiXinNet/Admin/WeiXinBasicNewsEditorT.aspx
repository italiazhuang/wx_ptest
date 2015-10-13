<%@ Page Language="C#" AutoEventWireup="True" ValidateRequest="false" Inherits="WeiWeiXinNet.admin.WeiXinBasicNewsEditorT"
    CodeBehind="WeiXinBasicNewsEditorT.aspx.cs" %>

<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
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
    <script type="text/javascript">
        function jsbq(srt) {
            document.getElementById("WeTextBoxOne").value = document.getElementById("WeTextBoxOne").value + "/" + srt;
        }
        function jsED() {
            if (confirm("确定保存?")) {
                return true;
            }
            return false;
        }
        function jsModel() {
            if (confirm("模板将覆盖现有编辑框设置，确定加载?")) {
                return true;
            }
            return false;
        }
    </script>
    <style type="text/css">
        .biaoqing
        {
            position: relative;
            display: block;
            height: 25px;
            width: 60px;
            background: url(./img2/z_files/0.gif) no-repeat left center;
        }
        .biaoqing span
        {
            display: block;
            line-height: 25px;
            text-indent: 20px;
            cursor: pointer;
        }
        .biaoqing:hover ul
        {
            display: block;
        }
        .biaoqing ul
        {
            display: none;
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
            box-shadow: 0px 1px 3px #ccc;
            left: -50px;
            padding: 5px;
            position: absolute;
            top: -220px;
            width: 450px;
        }
        .biaoqing ul li
        {
            border: 1px solid #dfe6f6;
            height: 24px;
            width: 24px;
            display: block;
            padding: 2px;
            float: left;
            cursor: pointer;
        }
        .biaoqing ul li:hover
        {
            border: 1px solid #336699;
        }
    </style>
</head>
<body >
    <div class="main-box">
        <div class="head-dark-box">
            文本回复设置：请点击 新建文本消息 按钮建立您新的图文回复消息 ，或者点击 ☆ 选择编辑已有消息</div>
        <div class="body-box">
        <form id="weweixin_form" runat="server">
        <asp:Panel runat="server" ID="TextEditor" Visible="false">
            <table class="userinfoArea" style="margin: 0 64 0 0; width: 90%;" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="80" class="mleftCaption">
                        文本消息关键字
                    </td>
                    <td><asp:TextBox ID="WeTextBoxFive" runat="server">关键词</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="leftCaption" valign="top">
                        文本回复内容
                    </td>
                    <td>
                        <asp:TextBox ID="WeTextBoxOne" runat="server" Height="261px" TextMode="MultiLine" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div>
                            <ul>
                                <li class="biaoqing"><span>表情</span>
                                    <ul>
                                        <li>
                                            <img src="./img2/z_files/0.gif" alt="微笑" onclick="jsbq(&#39;微笑&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/1.gif" alt="撇嘴" onclick="jsbq(&#39;撇嘴&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/2.gif" alt="色" onclick="jsbq(&#39;色&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/3.gif" alt="发呆" onclick="jsbq(&#39;发呆&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/4.gif" alt="得意" onclick="jsbq(&#39;得意&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/5.gif" alt="流泪" onclick="jsbq(&#39;流泪&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/6.gif" alt="害羞" onclick="jsbq(&#39;害羞&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/7.gif" alt="闭嘴" onclick="jsbq(&#39;闭嘴&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/8.gif" alt="睡" onclick="jsbq(&#39;睡&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/9.gif" alt="大哭" onclick="jsbq(&#39;大哭&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/10.gif" alt="尴尬" onclick="jsbq(&#39;尴尬&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/11.gif" alt="发怒" onclick="jsbq(&#39;发怒&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/12.gif" alt="调皮" onclick="jsbq(&#39;调皮&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/13.gif" alt="呲牙" onclick="jsbq(&#39;呲牙&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/14.gif" alt="惊讶" onclick="jsbq(&#39;惊讶&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/15.gif" alt="难过" onclick="jsbq(&#39;难过&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/16.gif" alt="酷" onclick="jsbq(&#39;酷&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/17.gif" alt="冷汗" onclick="jsbq(&#39;冷汗&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/18.gif" alt="抓狂" onclick="jsbq(&#39;抓狂&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/19.gif" alt="吐" onclick="jsbq(&#39;吐&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/20.gif" alt="偷笑" onclick="jsbq(&#39;偷笑&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/21.gif" alt="可爱" onclick="jsbq(&#39;可爱&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/22.gif" alt="白眼" onclick="jsbq(&#39;白眼&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/23.gif" alt="傲慢" onclick="jsbq(&#39;傲慢&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/24.gif" alt="饥饿" onclick="jsbq(&#39;饥饿&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/25.gif" alt="困" onclick="jsbq(&#39;困&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/26.gif" alt="惊恐" onclick="jsbq(&#39;惊恐&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/27.gif" alt="流汗" onclick="jsbq(&#39;流汗&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/28.gif" alt="憨笑" onclick="jsbq(&#39;憨笑&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/29.gif" alt="大兵" onclick="jsbq(&#39;大兵&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/30.gif" alt="奋斗" onclick="jsbq(&#39;奋斗&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/31.gif" alt="咒骂" onclick="jsbq(&#39;咒骂&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/32.gif" alt="疑问" onclick="jsbq(&#39;疑问&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/33.gif" alt="嘘" onclick="jsbq(&#39;嘘&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/34.gif" alt="晕" onclick="jsbq(&#39;晕&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/35.gif" alt="折磨" onclick="jsbq(&#39;折磨&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/36.gif" alt="衰" onclick="jsbq(&#39;衰&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/37.gif" alt="骷髅" onclick="jsbq(&#39;骷髅&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/38.gif" alt="敲打" onclick="jsbq(&#39;敲打&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/39.gif" alt="再见" onclick="jsbq(&#39;再见&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/40.gif" alt="擦汗" onclick="jsbq(&#39;擦汗&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/41.gif" alt="抠鼻" onclick="jsbq(&#39;抠鼻&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/42.gif" alt="鼓掌" onclick="jsbq(&#39;鼓掌&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/43.gif" alt="糗大了" onclick="jsbq(&#39;糗大了&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/44.gif" alt="坏笑" onclick="jsbq(&#39;坏笑&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/45.gif" alt="左哼哼" onclick="jsbq(&#39;左哼哼&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/46.gif" alt="右哼哼" onclick="jsbq(&#39;右哼哼&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/47.gif" alt="哈欠" onclick="jsbq(&#39;哈欠&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/48.gif" alt="鄙视" onclick="jsbq(&#39;鄙视&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/49.gif" alt="委屈" onclick="jsbq(&#39;委屈&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/50.gif" alt="快哭了" onclick="jsbq(&#39;快哭了&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/51.gif" alt="阴险" onclick="jsbq(&#39;阴险&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/52.gif" alt="亲亲" onclick="jsbq(&#39;亲亲&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/53.gif" alt="吓" onclick="jsbq(&#39;吓&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/54.gif" alt="可怜" onclick="jsbq(&#39;可怜&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/55.gif" alt="菜刀" onclick="jsbq(&#39;菜刀&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/56.gif" alt="西瓜" onclick="jsbq(&#39;西瓜&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/57.gif" alt="啤酒" onclick="jsbq(&#39;啤酒&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/58.gif" alt="篮球" onclick="jsbq(&#39;篮球&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/59.gif" alt="乒乓" onclick="jsbq(&#39;乒乓&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/60.gif" alt="咖啡" onclick="jsbq(&#39;咖啡&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/61.gif" alt="饭" onclick="jsbq(&#39;饭&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/62.gif" alt="猪头" onclick="jsbq(&#39;猪头&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/63.gif" alt="玫瑰" onclick="jsbq(&#39;玫瑰&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/64.gif" alt="凋谢" onclick="jsbq(&#39;凋谢&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/65.gif" alt="示爱" onclick="jsbq(&#39;示爱&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/66.gif" alt="爱心" onclick="jsbq(&#39;爱心&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/67.gif" alt="心碎" onclick="jsbq(&#39;心碎&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/68.gif" alt="蛋糕" onclick="jsbq(&#39;蛋糕&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/69.gif" alt="闪电" onclick="jsbq(&#39;闪电&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/70.gif" alt="炸弹" onclick="jsbq(&#39;炸弹&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/71.gif" alt="刀" onclick="jsbq(&#39;刀&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/72.gif" alt="足球" onclick="jsbq(&#39;足球&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/73.gif" alt="瓢虫" onclick="jsbq(&#39;瓢虫&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/74.gif" alt="便便" onclick="jsbq(&#39;便便&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/75.gif" alt="月亮" onclick="jsbq(&#39;月亮&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/76.gif" alt="太阳" onclick="jsbq(&#39;太阳&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/77.gif" alt="礼物" onclick="jsbq(&#39;礼物&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/78.gif" alt="拥抱" onclick="jsbq(&#39;拥抱&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/79.gif" alt="强" onclick="jsbq(&#39;强&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/80.gif" alt="弱" onclick="jsbq(&#39;弱&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/81.gif" alt="握手" onclick="jsbq(&#39;握手&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/82.gif" alt="胜利" onclick="jsbq(&#39;胜利&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/83.gif" alt="抱拳" onclick="jsbq(&#39;抱拳&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/84.gif" alt="勾引" onclick="jsbq(&#39;勾引&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/85.gif" alt="拳头" onclick="jsbq(&#39;拳头&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/86.gif" alt="差劲" onclick="jsbq(&#39;差劲&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/87.gif" alt="爱你" onclick="jsbq(&#39;爱你&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/88.gif" alt="NO" onclick="jsbq(&#39;NO&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/89.gif" alt="OK" onclick="jsbq(&#39;OK&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/90.gif" alt="爱情" onclick="jsbq(&#39;爱情&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/91.gif" alt="飞吻" onclick="jsbq(&#39;飞吻&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/92.gif" alt="跳跳" onclick="jsbq(&#39;跳跳&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/93.gif" alt="发抖" onclick="jsbq(&#39;发抖&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/94.gif" alt="怄火" onclick="jsbq(&#39;怄火&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/95.gif" alt="转圈" onclick="jsbq(&#39;转圈&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/96.gif" alt="磕头" onclick="jsbq(&#39;磕头&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/97.gif" alt="回头" onclick="jsbq(&#39;回头&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/98.gif" alt="跳绳" onclick="jsbq(&#39;跳绳&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/99.gif" alt="挥手" onclick="jsbq(&#39;挥手&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/100.gif" alt="激动" onclick="jsbq(&#39;激动&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/101.gif" alt="街舞" onclick="jsbq(&#39;街舞&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/102.gif" alt="献吻" onclick="jsbq(&#39;献吻&#39;)"></li>
                                        <li>
                                            <img src="./img2/z_files/103.gif" alt="左太极" onclick="jsbq(&#39;左太极&#39;)"></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                            文字加超链接范例：&lt;a&nbsp;href=&quot;http://udoo123taobao.com&quot;&gt; 微信.NET&lt;/a&gt;
                            <br />
                            请不要多于1000字否则无法发送!
                    </td>
                </tr>
                <tr class="footCaption">
                     <td colspan="2">
                        <div class="with-line">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <asp:Button ID="Button9" runat="server" OnClick="ButtonNine_Click" Text="保存" CssClass="button"/>
                        <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="不保存退出" CssClass="button"/>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <iz:FileManager ID="FileManager1" runat="server" Height="500px" Width="1100" OnExecuteCommand="FileManager1_ExecuteCommand"
            OnToolbarCommand="FileManager1_ToolbarCommand">
            <RootDirectories>
                <iz:RootDirectory DirectoryPath="~/Files/My Documents" Text="My Documents" />
            </RootDirectories>
            <CustomToolbarButtons>
                <iz:CustomToolbarButton Text="新建文本消息" CommandName="GETDATA" ImageUrl="~/images/icons/get.png" />
                <%-- <iz:CustomToolbarButton Text="Say Hello!" PerformPostBack="false" OnClientClick="alert('Hello!')"
                    ImageUrl="images/16x16/smile.gif" />--%>
            </CustomToolbarButtons>
            <FileTypes>
                <iz:FileType Extensions="txt,htm,html,css,js,ini,config,dll" Name="Text Document"
                    SmallImageUrl="~/images/16x16/notepad.png" LargeImageUrl="~/images/32x32/notepad.png">
                    <Commands>
                        <iz:FileManagerCommand Name="Edit (PostBack)" Method="PostBack" CommandName="EditText"
                            SmallImageUrl="~/images/16x16/notepad.png" />
                        <iz:FileManagerCommand Name="Edit (Callback)" CommandName="EditText" SmallImageUrl="~/images/16x16/notepad.png" />
                    </Commands>
                </iz:FileType>
            </FileTypes>
        </iz:FileManager>
       
        </form>
    </div>
</body>
</html>
