<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!--This is IE DTD patch , Don't delete this line.-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>萝萝窝博客系统</title>
<!--[if IE]>
<style type="text/css" media="screen">.right{height:100%; top:0; bottom:0; border-top:66px solid #d0e6f1; border-bottom:0px solid #d0e6f1; z-index:1;}</style>
<![endif]-->
    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>    
    <script src="/Content/MWeb/css/frame.js" language="javascript" type="text/javascript"></script>
    <link href="/Content/MWeb/css/frame.css" rel="stylesheet" type="text/css" />
</head>
<body class="showmenu">
    <div class="pagemask">
    </div>
    <iframe class="iframemask"></iframe>
   
    <div class="head">
        <div class="top">
            <div class="top_logo">
                <img src="/Content/MWeb/images/admin_top_logo.gif" width="170" height="37" alt=""
                    title="萝萝窝博客系统 V1.0" />
            </div>
            <div class="top_link">
                <ul>
                    <li class="welcome">您好：Taven ，欢迎使用萝萝窝博客系统！</li>
                    <li><a href="<%=Url.Action("Welcome", "Article")%>" target="main">后台首页</a></li>
                    <li><a href="/" target="_blank">博客首页</a></li>
                    <li><a href="<%=Url.Action("LogOut", "Article")%>" target="_top">退出管理</a></li>
                </ul>
            </div>
        </div>
        <div class="topnav">
            <div class="menuact">
                <a href="#" id="togglemenu">隐藏菜单</a>
            </div>
            <div class="nav" id="nav">
                <ul>
                    <li><a class="thisclass" href="<%=Url.Action("ArticleList", "Article")%>" _for="article" target="main">博文管理</a></li>
                    <li><a href="<%=Url.Action("Welcome", "Article")%>" _for="setting" target="main">系统设置</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="left">
        <div class="menu" id="menu">
            <!-- Item 1 Begin -->
            <div id="items_article">
                <dl id='dl_items_1_1'>
                    <dt>常用操作</dt>
                    <dd>
                        <ul>
                            <li><a href='<%=Url.Action("Welcome", "Article")%>' target='main'>系统首页</a> </li>
                            <li><a href='<%=Url.Action("ArticleList", "Article")%>' target='main'>博文列表</a> </li>
                            <li><a href='<%=Url.Action("ArticleNew", "Article")%>' target='main'>撰写博文</a></li>
                            <li><a href='<%=Url.Action("List", "Category")%>' target='main'>博文分类</a> </li>
                            <li><a href='<%=Url.Action("Welcome", "Article")%>' target='main'>评论管理</a> </li>
                        </ul>
                    </dd>
                </dl>
            </div>
            <!-- Item 1 End -->
            <!-- Item 2 Begin -->
            <div id="items_setting">
                <dl id='dl_items_1_2'>
                    <dt>系统设置</dt>
                    <dd>
                        <ul>
                            <li><a href='<%=Url.Action("Welcome", "Article")%>' target='main'>配置参数</a></li>
                            <li><a href='<%=Url.Action("Welcome", "Article")%>' target='main'>博客同步</a></li>
                        </ul>
                    </dd>
                </dl>
            </div>
            <!-- Item 2 End -->
        </div>
    </div>
    <div class="right">
        <div class="main">
            <iframe id="main" name="main" frameborder="0" src="<%=Url.Action("Welcome", "Article")%>"></iframe>
        </div>
    </div>
    
</body>
</html>
