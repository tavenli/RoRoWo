<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>萝萝窝博客系统-后台登录</title>
    <link href="/Content/MWeb/css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!
        -- body
        {
            background-color: #F4FBF4;
            margin: 0;
            padding: 0;
        }
        input
        {
            color: #000;
            font-family: Tahoma, SimSun, Arial;
            font-size: 12px;
        }
        input[type="text"], input[type="password"]
        { *margin:-1px5px05px;border:1pxsolid#999;background-repeat:no-repeat;background-position:lefttop;margin:-1px5px0;padding:2px;
        }
        .text
        { *margin:-1px5px05px;border:1pxsolid#999;background-repeat:no-repeat;background-position:lefttop;margin:-1px5px0;padding:2px;background-image:url(/Content/MWeb/images/input.gif);
        }
        ul
        {
            list-style-image: none;
            list-style-position: outside;
            list-style-type: none;
        }
        .theme li
        {
            height: 20px;
            line-height: 20px;
            margin-bottom: 15px;
        }
        .theme span
        {
            color: #000;
            display: block;
            float: left;
            text-align: right;
            width: 19%;
        }
        .center
        {
            margin: 0 auto;
        }
        .loginbody
        {
            margin-top: 50px;
            height: 391px;
            width: 100%;
            background-attachment: scroll;
            background-image: url(/Content/MWeb/images/lor_bg.jpg);
            background-repeat: repeat-x;
            background-position: 0 0;
        }
        .lgCon
        {
            width: 363px;
            height: 391px;
            background-color: #F4FBF4;
        }
        .sdLeft
        {
            width: 7px;
            background-attachment: scroll;
            background-image: url(/Content/MWeb/images/sd_left_bg.jpg);
            background-repeat: no-repeat;
            background-position: 0 0;
            float: left;
            height: 391px;
        }
        .sdCon
        {
            float: left;
            width: 345px;
            height: 391px;
        }
        .sdTop
        {
            background-attachment: scroll;
            background-image: url(/Content/MWeb/images/sd_top_bg.jpg);
            background-repeat: repeat-x;
            background-position: 0 0;
            height: 7px;
            font-size: 0px;
            line-height: 0px;
        }
        .sdbImg
        {
            background-attachment: scroll;
            background-image: url(/Content/MWeb/images/login_t_img.gif);
            background-repeat: no-repeat;
            background-position: 0 0;
            height: 115px;
            width: 345px;
        }
        .ver
        {
            color: #FFF;
            float: right;
            margin-top: 5px;
            margin-right: 5px;
        }
        .sdRight
        {
            float: right;
            height: 391px;
            width: 11px;
            background-attachment: scroll;
            background-image: url(/Content/MWeb/images/sd_right_bg.jpg);
            background-repeat: no-repeat;
            background-position: 0 0;
        }
        .sdButtom
        {
            background-image: url(/Content/MWeb/images/sd_buttom.jpg);
            height: 11px;
            width: 345px;
            background-attachment: scroll;
            background-repeat: repeat-x;
            background-position: 0 0;
        }
        .login
        {
            height: 225px;
            background-color: #FFF;
            padding-bottom: 12px;
        }
        .dfmsg
        {
            font-weight: 700;
            color: red;
            line-height: 20px;
            width: 321px;
            background-color: #FFF;
            padding: 12px;
        }
        .tosite
        {
            text-align: center;
            margin-top: 32px;
        }
        .loginBtn
        {
            border: 0px none;
            background: transparent url(/Content/MWeb/images/lg_buttom.gif) repeat scroll 0% 0%;
            -moz-background-clip: border;
            -moz-background-origin: padding;
            -moz-background-inline-policy: continuous;
            width: 70px;
            height: 26px;
            cursor: pointer;
            font-size: 12px;
            float: right;
            margin-right: 150px;
        }
        -- ></style>
</head>
<body>
    <% Html.BeginForm("Index", "Login", FormMethod.Post, new { id = "form1" }); %>
    <div class="loginbody">
        <div class="lgCon center">
            <div class="sdLeft">
            </div>
            <div class="sdCon">
                <div class="sdTop">
                </div>
                <div class="sdbImg">
                    <div class="ver">
                        <a href="http://www.rorowo.com" target="_blank" style="color: #FFF">版本：1.0 Beta</a></div>
                </div>
                <div class="dfmsg">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <font color='gray'>
                    <b>
                        记录你每天的生活点滴！                    
                    </b>
                    </font></div>
                <div class="login">
                    <div class="theme">
                        <ul>
                            <li><span>用户名：</span>                                
                                <%=Html.TextBox("UserAccount", "", new { @class = "text", style = "width:150px;" })%>
                            </li>
                            <li><span>密&nbsp;&nbsp;&nbsp;码：</span>                                
                                <%=Html.Password("UserPassWord", "", new { @class = "text", style = "width:150px;" })%>
                                
                            </li>
                            <li><span>验证码：</span>                                
                                <%=Html.TextBox("ImgeCode", "", new { @class = "text", style = "width:80px;" })%>
                                <img style="cursor: pointer;" src="Login/VerifyImage" id="VerifyImage" title="看不清？点击换一个"
                                    align="absmiddle" onclick="javascript:document.getElementById('VerifyImage').src='Login/VerifyImage/'+Math.random();return false;">
                            </li>
                            <li style="padding-top: 10px;"><span></span>
                                
                                <input type="submit" class="loginBtn" value="登录" />
                            </li>
                        </ul>
                    </div>
                    <div class="tosite">
                        <a href="http://www.rorowo.com" target="_blank">萝萝窝博客系统</a></div>
                </div>
                <div class="sdButtom">
                </div>
            </div>
            <div class="sdRight">
            </div>
        </div>
    </div>
    <% Html.EndForm(); %>
</body>
</html>
