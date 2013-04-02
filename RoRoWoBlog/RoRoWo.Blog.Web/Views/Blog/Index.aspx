<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>
<%@ Import Namespace="Webdiyer.WebControls.Mvc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>萝萝窝博客系统</title>
    <link rel="stylesheet" rev="stylesheet" href="/Content/Themes/Qeeke/style/Qeeke.css" type="text/css" media="screen" />
</head>
<%
    
    PagedList<BlogArticle> pList = ViewData["pList"] as PagedList<BlogArticle>;
%>

<body id="section-homepage">
    <div id="Container">
        
        <% Html.RenderAction("BlogHeader", "PartialView"); %>
        
        <div id="MainBody">
            <div id="MainBodyTop">
            </div>
            <!-- start center -->
            <div id="content">
                <div id="node-8890" class="Post">
                    <%foreach (BlogArticle a in pList)
                      { %>
                    <div class="PostHead">
                        <div class="PostHeadTop">
                        </div>
                        <div id="vote-wrap-8890" class="vote-wrap">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/Novo_Dangos_001.gif" />
                        </div>
                        <h1>
                            <a href="/Blog/PostView/<%=a.ArticleID %>" rel="bookmark"><%=a.Title %></a></h1>
                        <span class="submitted">发布:Taven | 发布时间: <%=a.PublishTime.ToShortDateString() %></span></div>
                    <div class="PostContent">
                        <%=a.Content %>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="tags">
                        <p>
                            标签:</p>
                        <ul class="links inline">
                            <li class="first last taxonomy_term_6">
                            <a href="?tags=WCF">WCF</a>&nbsp;&nbsp;
                            <a href="?tags=Silverlight">Silverlight</a>&nbsp;&nbsp;
                            </li>
                        </ul>
                    </div>
                    <div class="tools">
                        <div class="links">
                            <ul class="links inline">
                                <li class="first comment_add">
                                <a href="/Blog/PostView/<%=a.ArticleID %>" title="在本页添加新的评论" class="comment_add">
                                添加新评论
                                </a>
                                </li>
                                <li class="last statistics_counter">
                                    <span class="statistics_counter">阅读次数：</span>
                                    <span id="spn<%=a.ArticleID %>"><%=a.Hits %></span>
                                </li>
                            </ul>
                        </div>
                        
                    </div>
                    <%} %>
                    
                    <!--分页开始-->                    
                    <%=Html.Pager(pList, new PagerOptions { PageIndexParameterName = "pageIndex", CssClass = "pager", FirstPageText = "<<", LastPageText = ">>", PrevPageText = "<", NextPageText = ">", CurrentPagerItemWrapperFormatString = "<span class=\"now-page\">{0}</span>" })%>
                    <!--分页结束-->

                </div>
            </div>
            <div id="SideBar">
                <!-- <div class="AdZone"><div class="AdZoneTop"></div></div> -->
                <div id="searchblock">
                    <h3>
                        搜索内容</h3>
                    <div id="right_search_form">
                        <form action="?act=Search" accept-charset="UTF-8" method="post"
                        id="search-theme-form">
                        <div>
                            <input name="edtSearch" id="edit-search_theme_form_keys" type="text" value="请输入关键词"
                                onblur="if(this.value=='') this.value='请输入关键词';" onfocus="if(this.value=='请输入关键词') this.value='';"
                                class="form-text" />
                            <input type="submit" name="op" id="edit-submit" class="btn_search_small" value="" />
                            <input type="hidden" name="form_id" id="edit-search-theme-form" value="search_theme_form" />
                            <input type="hidden" name="form_token" id="a-unique-id" value="74d8642ef8483ddbd2f6220363ffe47e" />
                        </div>
                        </form>
                    </div>
                </div>
                <div class="diggwrapper" id="divArchives">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            最近发表</h3>
                        <ul>
                            <li><a href="/2.html" title="开发WCF/Silverlight须知"><span class="article-date">
                                [05/16]</span>开发WCF/Silverlight须知</a></li><li><a href="/1.html"
                                    title="集团解决方案"><span class="article-date">[05/16]</span>集团解决方案</a></li></ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper" id="divComments">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>最新评论及回复</h3>
		                <ul>
                        <li><a href="/post/2010/03/95.html#cmt145" title="2010-6-11 10:46:55 post by Bigun">我们单位最近也在做一个类...</a></li>
                        <li><a href="/post/2010/05/102.html#cmt144" title="2010-6-9 20:18:24 post by 张逸">采用依赖注入方式将Rep...</a></li>
                        <li><a href="/post/2009/03/Builder-in-Practice.html#cmt143" title="2010-6-2 23:10:33 post by a.c">不错的好文</a></li>
                        <li><a href="/post/2010/05/102.html#cmt142" title="2010-6-1 9:56:17 post by 江">也在看一些DDD的资料，...</a></li>
                        <li><a href="/post/2010/05/102.html#cmt141" title="2010-5-27 16:21:23 post by basil">希望多些一些测试的文章</a></li>
                        <li><a href="/post/2010/05/103.html#cmt140" title="2010-5-24 0:01:44 post by jisen"> 不错，我们所有的软件从...</a></li>
                        <li><a href="/post/2010/03/90.html#cmt138" title="2010-5-19 2:24:37 post by 郭俊">张老师真平易近人，给我们...</a></li>
                        <li><a href="/post/2010/05/100.html#cmt137" title="2010-5-13 12:30:41 post by 路过......">没有注释，在我眼中绝对不...</a></li>
                        <li><a href="/post/2010/03/95.html#cmt135" title="2010-4-28 14:24:11 post by jisen">这个项目不小！</a></li>
                        </ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper" id="divGuestComments">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            最近留言</h3>
                        <ul>
                        <li><a href="/post/2010/03/95.html#cmt145" title="2010-6-11 10:46:55 post by Bigun">我们单位最近也在做一个类...</a></li>
                        <li><a href="/post/2010/05/102.html#cmt144" title="2010-6-9 20:18:24 post by 张逸">采用依赖注入方式将Rep...</a></li>
                        <li><a href="/post/2009/03/Builder-in-Practice.html#cmt143" title="2010-6-2 23:10:33 post by a.c">不错的好文</a></li>
                        <li><a href="/post/2010/05/102.html#cmt142" title="2010-6-1 9:56:17 post by 江">也在看一些DDD的资料，...</a></li>
                        <li><a href="/post/2010/05/102.html#cmt141" title="2010-5-27 16:21:23 post by basil">希望多些一些测试的文章</a></li>
                        <li><a href="/post/2010/05/103.html#cmt140" title="2010-5-24 0:01:44 post by jisen"> 不错，我们所有的软件从...</a></li>
                        <li><a href="/post/2010/03/90.html#cmt138" title="2010-5-19 2:24:37 post by 郭俊">张老师真平易近人，给我们...</a></li>
                        <li><a href="/post/2010/05/100.html#cmt137" title="2010-5-13 12:30:41 post by 路过......">没有注释，在我眼中绝对不...</a></li>
                        <li><a href="/post/2010/03/95.html#cmt135" title="2010-4-28 14:24:11 post by jisen">这个项目不小！</a></li>
                        </ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            站点统计</h3>
                        <ul>
                            <li>文章总数:2</li><li>评论总数:0</li><li>引用总数:0</li><li>浏览总数:3</li><li>留言总数:0</li><li>当前主题:Qeeke</li><li>
                                当前样式:Qeeke</li></ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper" id="divFavorites">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            网站收藏</h3>
                        <ul>
                            <li><a href="http://bbs.rainbowsoft.org/" target="_blank">ZBlogger社区</a></li>
                            <li><a href="http://download.rainbowsoft.org/" target="_blank">菠萝的海</a></li>
                            <li><a href="http://wiki.rainbowsoft.org/" target="_blank">Z-Wiki</a></li></ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper" id="divLinkage">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            友情链接</h3>
                        <ul>
                            <li><a href="http://www.dbshost.cn/" target="_blank" title="独立博客服务 萝萝窝官方主机">DBS主机</a></li>
                            <li><a href="http://www.dutory.com/blog/" target="_blank">Dutory官方博客</a></li></ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
            </div>
        </div>
        
        <% Html.RenderPartial("BlogFooter"); %>

    </div>
</body>
</html>
