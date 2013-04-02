<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>
<%

List<BlogCategory> cList = ViewData["cList"] as List<BlogCategory>;

%>
<div id="ContainerTop">
        </div>
        <div id="Header">
            <div id="HeaderTop">
            </div>
            <div id="HeadLeft">
                <h1>
                    <a href="/" title="你的Blog名称首页">你的Blog名称</a></h1>
                <div id="MenuTop">
                    <ul>
                        <li><a href="/MWeb">管理</a></li>
                    </ul>
                </div>
                <div id="navigation">
                    欢迎使用萝萝窝，有问题或意见请到社区反馈，谢谢您的参与使用。</div>
            </div>
            <div id="HeadRight">
                <div id="HeadRightTop">
                </div>
                <div id="topnavbox">
                    <ul id="navheader">
                        <li><a href="/">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu1.gif" alt="" /><br />
                            网站首页</a></li>
                        <li><a href="#">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu3.gif" alt="" /><br />
                            所有标签</a></li>
                        <li><a href="#" title="sitemaps">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu4.gif" alt="" /><br />
                            网站地图</a></li>
                        <li><a href="#">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu2.gif" alt="" /><br />
                            内容搜索</a></li>
                        <li><a href="#">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu5.gif" alt="" /><br />
                            联系我们</a></li>
                        <li><a href="#">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/menu6.gif" alt="" /><br />
                            内容订阅</a></li>
                    </ul>
                </div>
                <div id="Submissions">
                    <h3>
                        关于本博客</h3>
                    <p>
                        这里可以添加公告之类的东西。</p>
                </div>
            </div>
        </div>
        <div id="MainMenu">
            <div id="MainMenuTop">
            </div>
            <ul style="border-bottom: 1px solid rgb(60, 65, 74);">
                <%foreach (BlogCategory c in cList)
                  { %>
                <li>
                <span class="feed-icon">
                <a href="/Blog/rss/<%=c.CateID %>" target="_blank">
                    <img title="rss" width="20" height="12" src="/Content/Images/rss.png" border="0" alt="rss" />
                </a>&nbsp;
                </span>
                
                <a href="/Blog/Cate/<%=c.CateID %>"><%=c.CateName %><span class="article-nums"> (1)</span></a>
                
                </li>
                <%} %>
            </ul>
        </div>