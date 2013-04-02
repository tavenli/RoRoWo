<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传文件</title>
    <link type="text/css" rel="stylesheet" href="/Content/MWeb/css/main.css" />

    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script src="/Scripts/jquery.form.js" language="javascript" type="text/javascript"></script>
    
        <script type="text/javascript">

            function submitForm() {
                $("#form1").ajaxForm({
                    url: "<%=Url.Action("SavePic", "FUpLoad")%>",
                    beforeSubmit: checkform,
                    success: function (data) { SubmitSucceed(data); },
                    error: function () { alert('服务器正忙，请稍后提交...'); }
                });
            }

            //检查客户端用户输入
            function checkform() {
                var _file = document.getElementById('File1');
                if (_file.value == "") {
                    alert("请选择文件！");
                    _file.focus();
                    return false;
                }
                $("#upload").hide();
                $("#uploading").show();
                return true;
            }

            //提交成功后回调
            function SubmitSucceed(data) {
                //alert(data);            
                if (data != "") {
                    alert("成功上传！");
                    $("#upload").show();
                    $("#uploading").hide();
                    ApendTo(data);
                    CloseMe();

                }
                else {
                    alert("提交失败。");
                }
            }


            function ApendTo(_ImageUrl) {
                var _parentDoc = $(window.parent.document);
                _parentDoc.find("#hImageUrl").val(_ImageUrl);
                _parentDoc.find("#AImageUrl").attr("src", _ImageUrl);

            }

            function CloseMe() {
                parent.DialogManager.close('idupload');
            }

    </script>
</head>
<body>
    <form id="form1">

<div id="upload">
        <input id="File1" name="imgFile" type="file" />
        <input id="Submit1" type="submit" class="btn1" value="上传" onclick="submitForm();" />
</div>

<div id="uploading" style="display:none;">
    <img src="/Content/images/progress.gif" alt="正在上传..." /><span> 正在上传...</span>
</div>

</form>
</body>
</html>
