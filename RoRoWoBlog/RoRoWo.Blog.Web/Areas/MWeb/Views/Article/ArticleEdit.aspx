<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="RoRoWo.Blog.Domain.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>博文</title>
    <link type="text/css" rel="stylesheet" href="/Content/MWeb/css/main.css" />
    <link rel="stylesheet" type="text/css" href="/Content/MWeb/img/base.css" />

    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.ui.js" type="text/javascript"></script>
    <script src="/Scripts/dialog/dialog.js" type="text/javascript" id="dialog_js"></script>
    <link rel="stylesheet" type="text/css" href="/Scripts/dialog/dialog.css" />
    <script src="/Scripts/base.js" language="javascript" type="text/javascript"></script>
    
    <script type="text/javascript">
        function ShowUpload() {
            iframe_form('idupload', '上传缩略图', '<%=Url.Action("Index","FUpLoad") %>', 400, 150);
        }
 
    </script>

</head>
<body>
    
    <%
        int hID = Convert.ToInt32(ViewData["hID"]);
        BlogArticle model = ViewData["model"] as BlogArticle;
         %>
    <% Html.BeginForm("ArticleSave", "Article", FormMethod.Post, new { id = "form1" }); %>

    <div id="pnlEdit">
	
        <div class="mtitle">
            <div class="lbox">
                撰写新博文
            </div>
        </div>
        <table class="tform" style="margin-bottom: 6px;">
            <tbody>
                <tr>
                    <td align="left">
                        <img height="14" src="/Content/MWeb/img/Nav1.gif" width="20">
                        
                        <a href="<%=Url.Action("ArticleList", "Article")%>"><u>返回列表</u></a>
                        
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
                        <strong>文章基本信息</strong>
                    </th>
                </tr>
                <tr>
                    <td height="24" class="bline">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr class="tr_line">
                                <td width="90">
                                    &nbsp;博文标题：
                                </td>
                                <td>
                                    <%=Html.TextBox("Title", model.Title, new { id = "RuleTitle", @class = "articleTitle", style = "width:420px;" })%>
                                    <%=Html.Hidden("hID", hID)%>
                                </td>
                            </tr>                           
                            <tr class="">
                                <td width="90">
                                    &nbsp;分类：
                                </td>
                                <td>
                                <%=Html.DropDownList("CateID")%>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
            
            
            
        </table>
        <table class="tform" id="needset2">
            <tbody>
                <tr>
                    <th _show="no">
                        <strong>其它设置</strong>
                    </th>
                </tr>
                <tr>
                    <td height="24" class="bline">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">                            
                            <tr class="tr_line">
                                <td width="90">
                                    &nbsp;博文属性：
                                </td>
                                <td>
                                    <span class="checkbox">                                    
                                    <%=Html.CheckBox("IsTop", model.IsTop)%><label for="chkIsTop">置顶</label>
                                    </span>                                   
                                </td>
                            </tr>
                            <tr class="tr_line">
                                <td width="90" class="style1">
                                    &nbsp;缩&nbsp;略&nbsp;图：
                                </td>
                                <td class="style1"> 
                                    <img id="AImageUrl" src="<%=string.IsNullOrEmpty(model.ImageUrl)? "/Content/MWeb/img/pview.gif" : model.ImageUrl %>" style="height:100px;width:150px;border-width:0px;" />                                    
                                    <%=Html.Hidden("hImageUrl", model.ImageUrl)%>                                    
                                    <input type="button" class="np coolbg" onclick="ShowUpload();" style="margin-left: 8px;" value="上传" />
                                </td>            
                            </tr>                          
                            <tr class="tr_line">
                                <td width="90">
                                   TAG&nbsp;关&nbsp;键&nbsp;词：
                                </td>
                                <td>                                    
                                    <%=Html.TextBox("Tag", model.Tag, new { style = "width:376px;" })%>
                                    多个关键词用空格隔开 比如：生活 工作
                                </td>
                            </tr>
                            <tr>
                                <td width="90">
                                    &nbsp;内容摘要：
                                </td>
                                <td>                                    
                                    <%=Html.TextArea("Description", model.Description, 2, 20, new { style = "height:100px;width:750px;" })%>
                                </td>
                            </tr>
 
                        </table>
                    </td>
                </tr>
            </tbody>
            <tr>
              <td height="28" bgcolor="#F1F5F2" class="bline2">
                <div style='float:left;line-height:28px;'>&nbsp;<strong>文章内容：</strong></div>
                <div style='float:right;padding-right:8px'>
                
                </div>
                <div style='float:right;padding-right:8px'>
              		 
                </div>      
                </td>
            </tr>
            <tr>
              <td width="100%" height="24" class="bline">
	          <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="90">&nbsp;内容属性：</td>
 
                    <td>            	        
            	        <span class="checkbox"><input id="DownMeta" type="checkbox" name="DownMeta" checked="checked" value="true" /><label for="chkDownMeta">下载远程图片和资源</label></span>
            	        <span class="checkbox"><input id="AutoMark" type="checkbox" name="AutoMark" value="true" /><label for="chkAutoMark">自动水印</label></span>
                        <span class="checkbox"><input id="TopAsThumbnail" type="checkbox" name="TopAsThumbnail" value="true" /><label for="chkTopAsThumbnail">提取第一个图片为缩略图</label></span>
                    </td>
                  </tr>
                </table>
                </td>
            </tr>
            <tr>
            <td>
                <%=Html.TextArea("Content", model.Content, 5, 20, new { style = "height:500px;width:750px;" }) %>
            </td>
        </tr>
        </table>
        
        <table class="tform" id="adset">
          <tr>
           <td height="24" colspan="4" class="bline">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="tr_line">
                  <td width="90" height="22">&nbsp;博文状态：
                  </td>
                  <td>                    
                    <%= Html.DropDownList("State", new SelectList(new List<SelectListItem>
                        {
                            (new SelectListItem() {Text = "未审", Value = "0", Selected = false}),
                            (new SelectListItem() {Text = "已审", Value = "1", Selected = false})
                        },"Value","Text",model.State))%>
                  </td>
                </tr>
                <tr class="tr_line">
                  <td width="110" height="22">&nbsp;发布日期：
                  </td>
                  <td>                    
                    <%=Html.TextBox("PublishTime", model.PublishTime, new { style = "width:157px;" }) %>
                  </td>
                </tr>
                <tr>
                  <td width="90" height="22">&nbsp;文章点击数：
                  </td>
                  <td>
                    <%=Html.TextBox("Hits", model.Hits, new { style = "width:50px;" }) %>
                    &nbsp;
                    <input id="btnRndHits" name="btnRndHits" class="np coolbg" type="button" value="随机点击数" onclick="$('#Hits').val(Math.floor(Math.random()*300+1))">
                  </td>
                </tr>
              </table>
            </td>
          </tr>
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
    
  <script type="text/javascript" charset="utf-8" src="/Content/MWeb/Editor/kindeditor.js"></script>
  <script type="text/javascript">
      KE.show({
          id: 'Content',
          resizeMode: 1,
          cssPath: './index.css'
      });
 
  </script>
 
</body>

</html>
