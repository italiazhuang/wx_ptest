<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WeiWeiXinNet.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        关于 WeWeiXin.NET
    </h2>
    <p>
        微微信.NET 是一套完全开放源码的.NET 微信综合应用系统

        更新请联系: <a href='http://udoo123.taobao.com' target=_blank> udoo123.taobao.com </a>
    </p>


        <h2>
            更新记录 2014-6-20
    </h2>
    <p>
         [0.92v003 2014-6-19] 
         1修正了图文内容页需要验证的BUG
         2将默认的新建文件夹名称函数进行了修正 
         3添加了微网站样例模板4套
    </p>
    <p>
         [0.92v005 2014-6-20] 
         1修正了用户上传图片复制路径的BUG 2修正了用户编辑图文内容样式不能正确加载的DEBUG
    </p>


</asp:Content>
