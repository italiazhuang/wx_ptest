<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WeiWeiXinNet.admin.LoginX" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">

    .input_1 {
	BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #999999 1px solid; PADDING-LEFT: 2px; LIST-STYLE-POSITION: inside; FONT-SIZE: 12px; PADDING-BOTTOM: 2px; MARGIN-LEFT: 10px; BORDER-LEFT: #999999 1px solid; COLOR: #333333; PADDING-TOP: 2px; BORDER-BOTTOM: #999999 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serIf; LIST-STYLE-TYPE: none; HEIGHT: 18px; BACKGROUND-COLOR: #dadedf
}
        .style2
        {
            font-size: 11px;
            color: #000000;
            font-family: Verdana, Arial, Helvetica, sans-serIf;
            text-decoration: none;
        }
        .style3
        {
            width: 44px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        登录
    </h2>

    <TABLE cellSpacing=0 cellPadding=0 border=0 align="center" style="width: 585px">
        <TBODY>
        
        <TR>
          <TD  ></TD>
          <TD vAlign=center   height=279><TABLE height=109 cellSpacing=0 cellPadding=0 width=369 align=center 
            border=0>
              <TBODY>
              
              <TR>
                <TD width=155><IMG height=140 
                  src="images/wlogo.jpg" width=155 useMap=#Map 
                  border=0></TD>
                <TD vAlign=top align=left width=214>
                    <TABLE cellSpacing=0 cellPadding=0 border=0 
                        style="width: 317px">
                    <TBODY>
                    
                    <TR>
                      <TD vAlign=bottom width=167 height=30 class="style2">微微信.NET 0.92 后台管理登录</TD>
                    </TR>
                    <TR>
                      <TD height=123>
                          <TABLE height=109 cellSpacing=0 cellPadding=0 
                        align=center border=0 style="width: 301px">
                          <FORM name="form2"  action="adminww.aspx"  method="post"  >
                            
                              <TR>
                                <TD vAlign=bottom align=left height=28 class="style3"><DIV align=right><asp:Image runat="server" height=14  ID="imag1" 
                              src="images/id.gif" width=43/></DIV></TD>
                                <TD vAlign=bottom align=left width=114 
                              height=28> 
                                    <asp:TextBox class="input_1" ID="WeTextBoxOne" runat="server"></asp:TextBox>
                                </TD>
                              </TR>
                              <TR>
                                <TD align=left height=20 class="style3"><DIV align=right><asp:Image  ID="imag2" runat="server" height=14 
                              src="images/pass.gif" width=43/></DIV></TD>
                                <TD height=20> <asp:TextBox  class="input_1" ID="WeTextBoxTwo" runat="server" 
                                        TextMode="Password"></asp:TextBox>
                                  </TD>
                              </TR>
                              <TR>
                                <TD vAlign=center colSpan=2 height=25><DIV align=center>
                                    <asp:Button ID="ButtonThree" runat="server" Text="注销登录" onclick="ButtonThree_Click" 
                                        Visible="False" Height="30px" />
                                    <asp:Button ID="ButtonTwo" runat="server" Text="用户登录" onclick="ButtonTwo_Click" 
                                        Height="30px" />
                                    &nbsp; 
                                    </DIV></TD>
                              </TR>
                          </FORM>
                          
                        </TABLE></TD>
                    </TR>
                    </TBODY>
                  </TABLE></TD>
              </TR>
              </TBODY>
            </TABLE></TD>
          <TD ></TD>
        </TR>
        <TR>
          <TD>&nbsp;</TD>
          <TD ></TD>
          <TD width=16>&nbsp;</TD>
        </TR>
        </TBODY>
      </TABLE>
        <p>
            说明：请输入用户名和密码。系统默认的用户名为: admin 密码:abc123 为了您的系统安全请登陆后立刻进行修改!本系统提供完全源代码供用户使用，因使用本源码造成的人员生命财产损失由使用者自行承担，源码归购买用户使用和面向特定个人公司做二次开发使用，请勿修改为通用系统批量贩卖或免费传播！</p>
    </asp:Content>
