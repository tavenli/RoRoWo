<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>博文阅读</title>
    <link rel="stylesheet" rev="stylesheet" href="/Content/Themes/Qeeke/style/Qeeke.css" type="text/css" media="screen" />
</head>

<%
    BlogArticle model = ViewData["model"] as BlogArticle;    
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
                    <div class="PostHead">
                        <div class="PostHeadTop">
                        </div>
                        <div id="vote-wrap-8890" class="vote-wrap">
                            <img src="/Content/Themes/Qeeke/style/Qeeke/Novo_Dangos_001.gif" />
                        </div>
                        <h1>
                            <%=model.Title %>
                        </h1>
                        <span class="submitted">发布:Taven | 发布时间: <%=model.PublishTime %></span></div>
                    <div class="PostContent">
                        <%=model.Content %>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="tags">
                        <p>
                            标签:</p>
                        <ul class="links inline">
                            <li class="first last taxonomy_term_6"><a href="#">
                                WCF</a>&nbsp;&nbsp;<a href="#">Silverlight</a>&nbsp;&nbsp;</li></ul>
                    </div>
                    <div class="tools">
                        发布:admin | 分类:技术博文 | 评论:0 | 引用:0 | 浏览:<span id="spn111">11</span>
                        
                    </div>
                </div>
                <ul class="msg mutuality">
                    <li class="tbname">相关文章:</li>
                    <li class="msgarticle">
                        <p>
                            <a href="#">集团解决方案</a>&nbsp;&nbsp;(2010-5-16 16:56:21)</p>
                    </li>
                </ul>
                <div style="display: none;" id="divAjaxComment">
                </div>
                <div id="Comments">
                    <div class="box">
                        <div class="FormTop">
                        </div>
                        <h2 class="title">
                            <a name="comment">发表评论</a></h2>
                        <div class="content">
                            <form id="frmSumbit" target="_self" method="post" action="#">
                            <input type="hidden" name="inpId" id="inpId" value="2" />
                            <input type="hidden" name="inpArticle" id="inpArticle" value="" />
                            <input type="hidden" name="inpLocation" id="inpLocation" value="" />
                            <p>
                                <input type="text" name="inpName" id="inpName" class="text" value="" size="28" tabindex="1" />
                                <label for="inpName">
                                    名称(*)</label></p>
                            <p>
                                <input type="text" name="inpEmail" id="inpEmail" class="text" value="" size="28"
                                    tabindex="2" />
                                <label for="inpEmail">
                                    邮箱</label></p>
                            <p>
                                <input type="text" name="inpHomePage" id="inpHomePage" class="text" value="" size="28"
                                    tabindex="3" />
                                <label for="inpHomePage">
                                    网站链接</label></p>
                            <div class="form-item">
                                <p>
                                </p>
                                <p>
                                    <input type="text" name="inpVerify" id="inpVerify" class="text" value="" size="28"
                                        tabindex="4" />                                    
                                    <img style="cursor: pointer;" src="/Blog/VerifyImage" id="VerifyImage" title="看不清？点击换一个"
                                    align="absmiddle" onclick="javascript:document.getElementById('VerifyImage').src='/Blog/VerifyImage/'+Math.random();return false;">
                                        </p>
                            </div>
                            <br>
                            <p>
                                <label for="txaArticle">
                                    正文(*)(留言最长字数:1000)</label></p>
                            <br>
                            <p>
                                <textarea name="txaArticle" id="txaArticle" onchange="GetActiveText(this.id);" onclick="GetActiveText(this.id);"
                                    onfocus="GetActiveText(this.id);" class="text" cols="50" rows="4" tabindex="5"></textarea></p>
                            <br>
                            <p>
                                <input name="btnSumbit" type="submit" tabindex="6" value="提交" class="button" />
                                <input type="checkbox" name="chkRemember" value="1" id="chkRemember" />
                                <label for="chkRemember">
                                    记住我,下次回复时不用重新输入个人信息</label></p>
                            <br>
                            
                            </form>
                            <p class="postbottom">
                                ◎欢迎参与讨论，请在这里发表您的看法、交流您的观点。</p>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div id="SideBar">
                <!-- <div class="AdZone"><div class="AdZoneTop"></div></div> -->
                <div id="searchblock">
                    <h3>
                        搜索内容</h3>
                    <div id="right_search_form">
                        <form action="http://localhost:81/Search" accept-charset="UTF-8" method="post"
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
                        <ul id="ulPrevious">
                        <li>
                        <a title="《返璞归真-UNIX技术内幕》书评" href="#">
                        <span class="article-date">[08/22]</span>
                        《返璞归真-UNIX技术内幕》书评
                        </a>
                        </li>
                        <li><a title="我眼中的Visual Studio 2010架构工具" href="#">
                        <span class="article-date">[07/30]</span>我眼中的Visual Studio 2010架构工具</a></li>                        
                        </ul>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
                <div class="diggwrapper" id="divComments">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div class="inner-wrapper">
                        <h3>
                            最新评论及回复</h3>
                        <ul id="ulComments">
                        <li>
                        <a title="2010-8-12 14:25:25 post by manghost" href="#">真的很有用，在网上找了这...</a>
                        </li>
                        <li>
                        <a title="2010-8-11 16:15:35 post by zdnet" href="#">您好!去年8月您参加过我...</a>
                        </li>                        
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
                        <ul id="ulGuestcomments">
                        <li>
                        <a title="2009-11-14 2:12:10 post by Gsanidt" href="#">来瞧瞧！</a>
                        </li>
                        <li>
                        <a title="2009-11-11 23:20:34 post by 思舍" href="#">你博客真不错，大家有空常...</a>
                        </li>                        
                        </ul>
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
