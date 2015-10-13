<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadUserPhotoC.aspx.cs" Inherits="ZoomImageDemo.UpLoadUserPhotoC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>微信图片在线处理程序</title>
    <link href="css/main.css" type="text/css" rel="Stylesheet"/>
    <script type="text/javascript" src="js/jquery1.2.6.pack.js"></script>
    <script  type="text/javascript" src="js/ui.core.packed.js" ></script>
    <script type="text/javascript" src="js/ui.draggable.packed.js" ></script>
    <script type="text/javascript" src="js/CutPicC.js"></script>
    <script type="text/javascript">
        function Step1() {
            $("#Step2Container").hide();           
        }

        function Step2() {
            $("#CurruntPicContainer").hide();
        }
        function Step3() {
            $("#Step2Container").hide();
        }

        function foo() {
            window.close();
            window.opener.document.getElementById("txt0").value = document.getElementById("txt").value
        } 


    </script>
</head>
<body>
    <form id="weweixin_form" runat="server">
    <div>
     <div class="left">
         <!--当前照片-->
         <div id="CurruntPicContainer">
            <div class="title"><b>当前图片</b></div>
            <div class="photocontainerC">
                <asp:Image ID="imgphoto" runat="server" ImageUrl="~/admin/ImageEditor/image/man280.GIF" />
            </div>
         </div>
         <!--Step 2-->
         <div id="Step2Container">
           <div class="uploadtooltip">您可以拖动图片以裁剪最佳位置</div>                              
                   <div id="Canvas" class="uploaddiv">
                   
                            <div id="ImageDragContainerC">                               
                               <asp:Image ID="ImageDrag" runat="server" ImageUrl="~/admin/ImageEditor/image/blank280.jpg" CssClass="imagePhoto" ToolTip=""/>                                                        
                            </div>
                            <div id="IconContainerC">                               
                               <asp:Image ID="ImageIcon" runat="server" ImageUrl="~/admin/ImageEditor/image/blank280.jpg" CssClass="imagePhoto" ToolTip=""/>                                                        
                            </div>                          
                    </div>
                    <div class="uploaddiv">
                       <table>
                            <tr>
                                <td id="Min">
                                        <img alt="缩小" src="/admin/ImageEditor/image/_c.gif" onmouseover="this.src='/admin/ImageEditor/image/_c.gif';" onmouseout="this.src='/admin/ImageEditor/image/_h.gif';" id="moresmall" class="smallbig" />
                                </td>
                                <td>
                                    <div id="bar">
                                        <div class="child">
                                        </div>
                                    </div>
                                </td>
                                <td id="Max">
                                        <img alt="放大" src="/admin/ImageEditor/image/c.gif" onmouseover="this.src='/admin/ImageEditor/image/c.gif';" onmouseout="this.src='/admin/ImageEditor/image/h.gif';" id="morebig" class="smallbig" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="uploaddiv">
                        <asp:Button ID="btn_Image" runat="server" Text="保存图像" 
                            OnClick="btn_Image_Click" />
                    </div>           
                    <div>
                    宽度： <asp:TextBox ID="txt_width" runat="server" Text="1" 
                            Width="30px" ></asp:TextBox> 
                    高度： <asp:TextBox ID="txt_height" runat="server" Text="1" Width="30px"></asp:TextBox> 
                    顶部： <asp:TextBox ID="txt_top" runat="server"  Text="42" Width="30px"></asp:TextBox>
                    左边： <asp:TextBox ID="txt_left" runat="server" Text="33" Width="30px"></asp:TextBox> <br />
                    框宽： <asp:TextBox ID="txt_DropWidth" 
                            runat="server"  Text="280" Width="30px"></asp:TextBox> 
                    框高： <asp:TextBox ID="txt_DropHeight" runat="server" Text="156" Width="30px"></asp:TextBox> 
                    放大： <asp:TextBox ID="txt_Zoom" runat="server" Width="30px"></asp:TextBox>
                   </div>
         </div>
     
     </div>
     <div class="right">
         <!--Step 1-->
         <div id="Step1Container">
            <div class="title"><b>更换图片</b></div>
            <div id="uploadcontainer">
                <div class="uploadtooltip">请选择新的图片文件，文件需小于1MB</div>
                <div class="uploaddiv"><asp:FileUpload ID="fuPhoto"  runat="server" ToolTip="选择照片"/></div>
                <div class="uploaddiv"><asp:Button ID="btnUpload" runat="server" Text="上 传" onclick="btnUpload_Click" />&nbsp; <input type=button value="关闭" onclick="foo();"> 
                    <input type=text name="txt" id="txt" value="123456"> </div>
            </div>
         
         </div>
     </div>
    </div>
    </form>
</body>
</html>
