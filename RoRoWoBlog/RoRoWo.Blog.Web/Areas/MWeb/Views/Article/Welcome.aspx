<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>欢迎使用萝萝窝博客系统</title>
    <base target="_self">
    <link type="text/css" rel="stylesheet" href="/Content/MWeb/css/main.css" />
    <link rel="stylesheet" type="text/css" href="/Content/MWeb/img/indexbody.css" />

    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.ui.js" type="text/javascript"></script>
    <script src="/Scripts/dialog/dialog.js" type="text/javascript" id="dialog_js"></script>
    <script src="/Scripts/base.js" language="javascript" type="text/javascript"></script>

    
</head>
<body>

    <table _dlist="line" class="tlist">
        <tr>
            <td>
                <div style='float: left'>
                    <img height="14" src="/Content/MWeb/img/book.gif" width="20" />&nbsp; 欢迎使用萝萝窝博客系统！
                </div>
                <div style='float: right; padding-right: 8px;'>
                    <!--  //保留接口  -->
                </div>
            </td>
        </tr>
        <tr>
            <td height="1" background="/Content/MWeb/img/sp_bg.gif" style='padding: 0px'>
            </td>
        </tr>
    </table>  
   
    <table _dlist="line" class="tlist" style="margin-bottom: 8px">
        <tr>
            <td colspan="2" bgcolor="#F7FAF3" class='title'>
                <div style='float: left'>
                    <span>快捷操作</span></div>
                <div style='float: right; padding-right: 10px;'>
                    
                </div>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="30" colspan="2" align="center" valign="bottom">
                <table width="100%" border="0" cellspacing="1" cellpadding="1">
                    <tr>
                        
                        <td valign="bottom">
                            <div class='icoitem'>
                                <div class='ico'>
                                    <img src='/Content/MWeb/Ico/1.gif' width='16' height='16' /></div>
                                <div style='float: left'>
                                    <a href='#'><u>快捷菜单1</u></a></div>
                            </div>
                            <div class='icoitem'>
                                <div class='ico'>
                                    <img src='/Content/MWeb/Ico/2.gif' width='16' height='16' /></div>
                                <div style='float: left'>
                                    <a href='#'><u>快捷菜单2</u></a></div>
                            </div>
                            <div class='icoitem'>
                                <div class='ico'>
                                    <img src='/Content/MWeb/Ico/3.gif' width='16' height='16' /></div>
                                <div style='float: left'>
                                    <a href='#'><u>快捷菜单3</u></a></div>
                            </div>
                            <div class='icoitem'>
                                <div class='ico'>
                                    <img src='/Content/MWeb/Ico/4.gif' width='16' height='16' /></div>
                                <div style='float: left'>
                                    <a href='#'><u>快捷菜单4</u></a></div>
                            </div>
                            <div class='icoitem'>
                                <div class='ico'>
                                    <img src='/Content/MWeb/Ico/5.gif' width='16' height='16' /></div>
                                <div style='float: left'>
                                    <a href='#' onclick=""><u>快捷菜单5</u></a></div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table _dlist="line" class="tlist" style="margin-bottom: 8px">
        <tr bgcolor="#EEF4EA">
            <td colspan="2" class='F7FAF3'>
                <span>系统基本信息</span>
            </td>
        </tr>              
        <tr bgcolor="#FFFFFF">
            <td width="25%" bgcolor="#FFFFFF">
                软件版本信息：
            </td>
            <td>
                版本名称：RoRoWoBlog &nbsp; 版本号：V1.0 Beta
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td width="25%">
                开发团队：
            </td>
            <td width="75%">
                萝萝窝 开源项目组
            </td>
        </tr>
    </table>
    
    <p align="center">
        <br />
        Copyright &copy; 2010 RoRoWo.com. 萝萝窝 版权所有
        <br />
    </p>
        

</body>
</html>
