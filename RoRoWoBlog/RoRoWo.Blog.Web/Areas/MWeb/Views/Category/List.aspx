<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>
<%@ Import Namespace="Webdiyer.WebControls.Mvc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>博文分类</title>
    <link type="text/css" rel="stylesheet" href="/Content/MWeb/css/main.css" />

    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.ui.js" type="text/javascript"></script>
    <script src="/Scripts/dialog/dialog.js" type="text/javascript" id="dialog_js"></script>
    <link rel="stylesheet" type="text/css" href="/Scripts/dialog/dialog.css" />
    <script src="/Scripts/base.js" language="javascript" type="text/javascript"></script>

</head>
<body>
    
    <%
        PagedList<BlogCategory> list = ViewData["list"] as PagedList<BlogCategory>;
    %>
    
    <% Html.BeginForm("", "Category", FormMethod.Post, new { id = "form1" }); %>
   
    <div id="pnlList">
	
    <div class="mtitle">
        <div class="lbox">
            分类列表
            </div>
        <div class="rbox">
            
        </div>
    </div>
    <!--  快速转换位置按钮  -->
    <table class="tform">
        <tbody>
            <tr>                
                <td align="left">
                    <button type="button" class="btn1" onclick="location='<%=Url.Action("New", "Category")%>';">
                        新增分类</button>                    
                                 
                </td>
            </tr>
        </tbody>
    </table>
    
        <!--  搜索表单  -->    
    <table width='100%' border='0' cellpadding='1' cellspacing='1' align="center" style="margin-top: 8px;height:35px;">
        <tr bgcolor='#EEF4EA'>
            <td align='left'>
                <table border='0' cellpadding='0' cellspacing='0'>
                    <tr>
                        <td width='70' align='right'>
                            搜索列名：
                        </td>
                        <td>
                            <%= Html.DropDownList("FieldName", new List<SelectListItem>
                            {
                                (new SelectListItem() {Text = "分类名称", Value = "CateName", Selected = true})
                            })%>
                        </td>                        
                        <td width='70' align='right'>
                            关键字：
                        </td>
                        <td>
                            <input name="Keyword" type="text" id="Keyword" class="txt" />
                        </td> 
                        <td>                            
                            &nbsp;&nbsp;<input type="submit" name="btnQuery" value="查询" id="btnQuery" class="btn1" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <!--  内容列表   -->
    
    <table class="tlist" _dlist="line check">
        <thead>
            <tr>
                <td colspan="6">
                    <div class="title">
                       
                        <input type="checkbox" name="checkall" class="checkall" /> 全选/反选
                        <span class="checkbox"><input id="chkLike" type="checkbox" name="chkLike" checked="checked" /><label for="chkLike">模糊查询</label></span>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        排序字段：
                        <%= Html.DropDownList("OrderBy", new List<SelectListItem>
                        {
                            (new SelectListItem() {Text = "创建时间", Value = "CreateTime", Selected = false}),
                            (new SelectListItem() {Text = "分类ID", Value = "CateID", Selected = true})
                        })%>
                        排序方向：
                        <%= Html.DropDownList("SortType", new List<SelectListItem>
                        {
                            (new SelectListItem() {Text = "降序", Value = "DESC", Selected = true}),
                            (new SelectListItem() {Text = "升序", Value = "ASC", Selected = false})
                        })%>
                     </div>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr style="height:25px;">
                <th align="left">
                    选择
                </th>
                <th align="left">
                    分类名称
                </th>                
                <th align="left">
                    创建时间
                </th>
                <th align="left">
                    状态
                </th>                
                <th align="right">
                    操作
                </th>
            </tr>
            
            <% 
                foreach (BlogCategory a in list)
                {
                %>
            <tr onmouseover="tr_over(this);" onmouseout="tr_out(this);">
                <td class="fs_12">
                    <input type="checkbox" name="item" class="checkitem" value="<%=a.CateID %>" />                    
                </td>
                <td>
                    <img alt="" src="/Content/MWeb/Ico/Article.gif" />
                    <a href="#" target="_blank" title="<%=a.CateName %>">
                    <u>
                    <%=a.CateName %>
                    </u>
                    </a>
                                   
                </td>                
                <td title="<%=a.CreateTime %>">
                    <%=a.CreateTime.ToShortDateString() %>
                </td>
                <td>
                    <%=a.State == 1 ? "<font color=green>启用</font>" : "<font color=gray>禁用</font>"%>
                    
                </td>                
                <td class="ta_r">
                    <a href="<%=Url.Action("Edit", "Category", new { id = a.CateID })%>" target="_blank" title="新开页面进行编辑">
                    <img alt="编辑" title="编辑" src="/Content/MWeb/Ico/go2edit.gif" />
                    </a>
                    <a href="javascript:drop_confirm('您确定要删除它吗？', '<%=Url.Action("Delete", "Category", new { id = a.CateID })%>');" title="删除">
                    <img alt="删除" title="删除" src="/Content/MWeb/Ico/delete.gif" />
                    </a>
                    
                </td>
            </tr>             
            <%} %>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="6">                    
                    <input type="submit" name="btnBatch2" value="批量删除" onclick="return confirm('您确定要批量删除吗？');" id="btnBatch2" class="btn1s" />
                </td>
            </tr>
        </tfoot>
    </table>
    <div class="pagelist">
        <div class="pagelistbox">
            <!--分页显示-->
            <%=Html.Pager(list, new PagerOptions { PageIndexParameterName = "pageIndex", CssClass = "pagerItem", FirstPageText = "<<", LastPageText = ">>", PrevPageText = "<", NextPageText = ">", CurrentPagerItemWrapperFormatString = "<span class=\"redbold\">{0}</span>" })%>
        </div>
        
    </div>
    
    
</div>
 
<% Html.EndForm(); %>

</body>
</html>
