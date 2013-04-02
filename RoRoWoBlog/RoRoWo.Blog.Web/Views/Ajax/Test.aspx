<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ajax 测试页面</title>
    <script src="/Scripts/jquery-1.4.1.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript">
        function DoTest() {
            $.getJSON("<%=Url.Action("Index", "Ajax")%>", { rnd: Math.random() }, function (data) {
                //alert(data);
                var msg="";
                for(var i=0;i<data.length;i++)
                {
                    msg+=data[i].ArticleID+data[i].Title+data[i].Content+"\r\n";
                }
                alert(msg);

            });
        }
    </script>

</head>
<body>
    <div>
    <input type="button" value="测试按钮" onclick="DoTest();" />
    </div>
</body>
</html>
