$(function () {
    //文本框Style
    $(".txt").mouseover(function () {
        $(this).addClass("txt_o");
    }).mouseout(function () {
        $(this).removeClass("txt_o");
    }).focus(function () {
        $(this).addClass("txt_s");
    }).blur(function () {
        $(this).removeClass("txt_s");
    });

    //表格折叠
    $(".tform").find("tbody tr th[_show]").each(function (i) {
        //加入折叠提示
        if ($(this).attr("_show") == "no") {
            $(this).append(" <button type=\"button\" class=\"tbody_up\"></button>");
        } else {
            $(this).append(" <button type=\"button\" class=\"tbody_down\"></button>");
        }
        //折叠动作
        $(this).click(function () {
            if ($(this).find("button[class^='tbody_']").attr("class") == "tbody_up") {
                $(this).find("button[class^='tbody_']").attr("class", "tbody_down");
                $(this).parent("tr").parent("tbody").find("tr").not($(this).parent("tr")).hide();
            } else if ($(this).find("button[class^='tbody_']").attr("class") == "tbody_down") {
                $(this).find("button[class^='tbody_']").attr("class", "tbody_up");
                $(this).parent("tr").parent("tbody").find("tr").not($(this).parent("tr")).show();
            }
        }).mouseover(function () {
            $(this).addClass("mouseon");
        }).mouseout(function () {
            $(this).removeClass("mouseon");
        }).click();
    });

    //列表行高亮
    $("table[_dlist*='light']").children("tbody").children("tr").mouseover(function () {
        if ($(this).attr("_nolight") != "yes") $(this).addClass("t_on");
    }).mouseout(function () {
        $(this).removeClass("t_on");
    });

    /**/


});

function framejump(url) {
    alert(url);
}

function drop_confirm(msg, url) {
    if (confirm(msg)) {
        if (url == undefined) {
            return true;
        }
        window.location = url;
    } else {
        if (url == undefined) {
            return false;
        }
    }
}

$(function () {
    /* 全选 */
    $('.checkall').click(function () {
        $('.checkitem').attr('checked', this.checked)
    });


});

function tr_over(obj) {
    $(obj).css({ background: "#F1F5E9" });
}

function tr_out(obj) {
    $(obj).css({ background: "#FFFFFF" });
}

function AjaxPublishIndex() {

    ajax_notice('idPublish', '生成首页', 'Tool/PublishHtml.aspx?action=index', 400);
}

function CommonUpload(InputID) {
    iframe_form('idcommonupload', '上传文件', 'CommonUpload.aspx?putid=' + InputID, 400, 150);
}
