<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CategoryEdit</title>
    <link type="text/css" rel="stylesheet" href="/Content/MWeb/css/main.css" />
    <link rel="stylesheet" type="text/css" href="/Content/MWeb/img/base.css" />

    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.ui.js" type="text/javascript"></script>
    <script src="/Scripts/dialog/dialog.js" type="text/javascript" id="dialog_js"></script>
    <link rel="stylesheet" type="text/css" href="/Scripts/dialog/dialog.css" />
    <script src="/Scripts/base.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    
    <%
        int hID = Convert.ToInt32(ViewData["hID"]);
        BlogCategory model = ViewData["model"] as BlogCategory;
         %>
    <% Html.BeginForm("Save", "Category", FormMethod.Post, new { id = "form1" }); %>

    <div id="pnlEdit">
	
        <div class="mtitle">
            <div class="lbox">
                分类信息
            </div>
        </div>
        <table class="tform" style="margin-bottom: 6px;">
            <tbody>
                <tr>
                    <td align="left">
                        <img height="14" src="/Content/MWeb/img/Nav1.gif" width="20">
                        
                        <a href="<%=Url.Action("List", "Category")%>"><u>返回列表</u></a>
                        
                    </td>
                    <td align="right">
                    </td>
                </tr>
            </tbody>
        </table>

        <table class="tform" id="needset">
            <tbody>
                <tr>
                    <th _show="yes">
                        <strong>基本信息</strong>
                    </th>
                </tr>
                <tr>
                    <td height="24" class="bline">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr class="tr_line">
                                <td width="90">
                                    &nbsp;分类名称：
                                </td>
                                <td>
                                    <%=Html.TextBox("CateName", model.CateName, new { @class = "articleTitle", style = "width:420px;" })%>
                                    <%=Html.Hidden("hID", hID)%>
                                </td>
                            </tr>
                                                   
                            <tr class="">
                                <td width="90">
                                    &nbsp;父级分类：
                                </td>
                                <td>
                                <%=Html.DropDownList("CateID")%>
                                    
                                </td>
                            </tr>
                            <tr class="">
                                <td width="90">
                                    &nbsp;排序号：
                                </td>
                                <td>
                                <%=Html.TextBox("SortID", model.SortID, new { @class = "articleTitle", style = "width:50px;" })%>
                                    
                                </td>
                            </tr>
                            <tr class="">
                                <td width="90">
                                    &nbsp;状态：
                                </td>
                                <td>
                                <%= Html.DropDownList("State", new SelectList(new List<SelectListItem>
                                {
                                    (new SelectListItem() {Text = "启用", Value = "1", Selected = false}),
                                    (new SelectListItem() {Text = "禁用", Value = "0", Selected = false})                                    
                                },"Value","Text",model.State))%>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>

        <table class="tform">
            <tr>
                <td>
                    <table width="214" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr height="50">
                            <td width="115">
                                <input type="submit" name="btnSave" value="保存" id="btnSave" class="btn1" />
                            </td>
                            <td width="99">
                                <button type="button" class="btn1" onclick="history.back(-1);">
                                    返回</button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
</div>

<% Html.EndForm(); %>

 
</body>
</html>
