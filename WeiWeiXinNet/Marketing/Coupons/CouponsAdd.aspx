<%@ Page Language="C#" AutoEventWireup="true" Inherits="SubSen" Codebehind="SubSent.aspx.cs" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<title>我的会员卡</title>  
<link href="./css/style.css" rel="stylesheet" type="text/css">
</head>

<body>
<br>
<div id="container">  
  <!--//会员卡-->
  <h1>尊享会员，实事多多！</h1>
  <br>
  <div id="real">  
  <form name="form1" method="post" action="" runat="server">
    <ul id="pcl">
      <li class="bordNone"><a href="#">填写以下信息获取优惠卷</a></li>
      <li class="name"><label>姓名：</label><input name="username" id="username" type="text"></li>
      <li class="mobile"><label>手机：</label><input name="userphone" id="userphone" type="text"></li>
      <li class="mobile"><label>Q Q：</label><input name="userqq" id="userqq" type="text"></li>
      <li class="save"><input type="submit" value="提 交"></li>
    </ul>
  </form>
  </div>  
</div>
<div id="Main"> 
  <div class="Logo"><a href="http://www. .com/"><img src="images/logo.png" width="137" height="49" /></a></div>
<div class="Info"><strong> </strong><br><b>Copyright ©   2000-2013</b>  </div>
</div>

</body>
</html>

