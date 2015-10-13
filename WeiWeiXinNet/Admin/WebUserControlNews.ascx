<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlNews.ascx.cs" Inherits="WeiWeiXinNet.admin.WebUserControlNews" %>
<style type="text/css">

        .style3
        {
            width: 216px;
        }
        *{text-shadow:none !important;color:#000 !important;background:transparent !important;box-shadow:none !important;} 
textarea,input[type="text"],input[type="password"],input[type="datetime"],input[type="datetime-local"],input[type="date"],input[type="month"],input[type="time"],input[type="week"],input[type="number"],input[type="email"],input[type="url"],input[type="search"],input[type="tel"],input[type="color"],.uneditable-input{background-color:#ffffff;border:1px solid #cccccc;-webkit-box-shadow:inset 0 1px 1px rgba(0, 0, 0, 0.075);-moz-box-shadow:inset 0 1px 1px rgba(0, 0, 0, 0.075);box-shadow:inset 0 1px 1px rgba(0, 0, 0, 0.075);-webkit-transition:border linear .2s, box-shadow linear .2s;-moz-transition:border linear .2s, box-shadow linear .2s;-o-transition:border linear .2s, box-shadow linear .2s;transition:border linear .2s, box-shadow linear .2s;}
select,textarea,input[type="text"],input[type="password"],input[type="datetime"],input[type="datetime-local"],input[type="date"],input[type="month"],input[type="time"],input[type="week"],input[type="number"],input[type="email"],input[type="url"],input[type="search"],input[type="tel"],input[type="color"],.uneditable-input{display:inline-block;padding:4px 6px;margin-bottom:10px;font-size:14px;line-height:20px;color:#555555;-webkit-border-radius:4px;-moz-border-radius:4px;border-radius:4px;vertical-align:middle;
}
        
        input[type="text"]
        {
            font-size: 13px;
            border: 1px solid #d9d9d9;
            padding: 0 6px;
           
        }
        
      input,textarea,.uneditable-input{margin-left:0;} input,textarea,.uneditable-input{margin-left:0;} 
input,textarea,.uneditable-input{margin-left:0;}
input,textarea,.uneditable-input{width:206px;}
input,button,select,textarea{font-family:"Helvetica Neue",Helvetica,Arial,sans-serif;}
label,input,button,select,textarea{font-size:14px;font-weight:normal;line-height:20px;}
button,input{*overflow:visible;line-height:normal;}
button,input,select,textarea{margin:0;font-size:100%;vertical-align:middle;}
input, select, textarea{
	font-size:12px;
}
input[type="file"],input[type="image"],input[type="submit"],input[type="reset"],input[type="button"],input[type="radio"],input[type="checkbox"]{width:auto;}
label,select,button,input[type="button"],input[type="reset"],input[type="submit"],input[type="radio"],input[type="checkbox"]{cursor:pointer;}
button,html input[type="button"],input[type="reset"],input[type="submit"]{-webkit-appearance:button;cursor:pointer;}

 
        input[type="submit"]
        {
            -moz-user-select: none;
            background-color: #F5F5F5;
            background-image: -moz-linear-gradient(center top , #F5F5F5, #F1F1F1);
            border-radius: 2px 2px 2px 2px;
            color: #666666;
            cursor: default;
            font-family: arial,sans-serif;
            font-size: 13px;
            font-weight: bold;
            line-height: 27px;
            margin: 0px 6px 11px 6px;
            
            padding: 0 8px;
            text-align: center;
    }
        p{margin:0 0 10px;}
p,h2,h3{orphans:3;widows:3;} 
p {
	margin:0px;
	padding:0px;
}
textarea{height:auto;}
textarea{overflow:auto;vertical-align:top;}
        
      textarea 
        {
            font-size: 13px;
            border: 1px solid #d9d9d9;
            padding: 0 6px;
            }
        
     
         
         body, table td, textarea{
	font-size:12px;
}
        .style5
        {
            height: 29px;
            width: 216px;
        }
        .style2
        {
            height: 29px;
        }
        
td a:link{
	font-size:12px;
	font-family:verdana, sans-serif;
	color:#2951A5;
	text-decoration:none;
}
a:link{text-decoration:none;color:#2951A5;}
a{color:#0088cc;text-decoration:none;}
a,a:visited{text-decoration:underline;} 
table{max-width:100%;background-color:transparent;border-collapse:collapse;border-spacing:0;}
tr,img{page-break-inside:avoid;} </style>
            <table class="userinfoArea" style="margin: 0;" border="0" cellspacing="0" cellpadding="0"
                width="100%">


                <tr>
                    <td class="style3">
                        关键词<asp:TextBox ID="WeTextBoxFive" runat="server" Width="156px" BorderStyle="None" 
                            Font-Size="Larger">关键词</asp:TextBox>
                        <br />
                         <asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                        创建模板 ，请按所需图文数量选择模板：<br />
                        <asp:Button ID="Button10" runat="server"  Text="1" 
                            Width="30px" />
                        <asp:Button ID="Button11" runat="server" Text="2" 
                            Width="30px" />
                        <asp:Button ID="Button12" runat="server" Text="3" 
                            Width="30px" />
                        <asp:Button ID="Button13" runat="server"  Text="4" 
                            Width="30px" />
                        <br />
                        <asp:Button ID="Button14" runat="server"    Text="5" 
                            Width="30px" />
                        <asp:Button ID="Button15" runat="server"  Text="6" 
                            Width="30px" />
                        <asp:Button ID="Button16" runat="server"  Text="7" 
                            Width="30px" />
                        <asp:Button ID="Button17" runat="server" Text="8" 
                            Width="30px" />
                        <br />
                        <asp:Button ID="Button18" runat="server"  Text="9" 
                            Width="30px" />
                        <asp:Button ID="Button19" runat="server"  Text="10" 
                            Width="38px" />
                         <asp:Button ID="Button9" runat="server" Text="保存" Width="139px" 
                               Height="37px" />
                         </td>
                    <td>
                        <p>
                            <asp:TextBox ID="WeTextBoxOne" runat="server" Width="675px" Height="271px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style2">
                              <a href="javascript:void(0);" onclick="javascript:PopUpWindow('./ImageEditor/UpLoadUserPhotoC.aspx',100,100,600,500);">点击上传照片</a>
                          
                           
                        <asp:TextBox name="txt0" id="txt0" runat="server" Width="423px"></asp:TextBox>

                        


                    </td>
                </tr>

                   <tr>
                    <td class="style3">
                          &nbsp;</td>
                    <td>
                         &nbsp;</td>
                </tr>


            </table>
        
