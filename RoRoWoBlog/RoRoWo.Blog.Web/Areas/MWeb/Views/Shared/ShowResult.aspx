<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Model" %>
<%@ Import Namespace="RoRoWo.Blog.Repository" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%
    ShowResultModel ShowMsg = ViewData["ShowMsg"] as ShowResultModel;

 %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%=ShowMsg.PageTitle%></title>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
    <base target='_self'/>
    <style>div{line-height:160%;}</style>
</head>
<body leftmargin='0' topmargin='0'>
<center>
<script>
    var pgo = 0;
    function JumpUrl() {
        if (pgo == 0) {
            location = '<%=ShowMsg.ReDirectUrl %>'; pgo = 1;
        }
    }
    setTimeout('JumpUrl()', <%=ShowMsg.Delay %>);
 </script>
 <br />
 <div style='width:450px;padding:0px;border:1px solid #D1DDAA;'>
 <div style='padding:6px;font-size:12px;border-bottom:1px solid #D1DDAA;background:#DBEEBD';'>
 <b><%=ShowMsg.PageTitle%></b>
 </div>
 <div style='height:130px;font-size:10pt;background:#ffffff'>
 <br /><%=ShowMsg.TipMsg%><br />
 <a href='<%=ShowMsg.ReDirectUrl %>'>正在转向指定页面，如果浏览器没反应请点击这里...</a>
 <br/>
 </div>
 </div>
 </center>
 </body>
</html>
