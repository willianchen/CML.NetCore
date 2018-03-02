function setPage(page, PageCount, RecordCount, id) {
    var p = '';
    if (page != undefined) {
        if (PageCount <= 0) return p;
        p += '总:' + RecordCount + '条  ';
        p += '<span class="paging">';
        if (page > 1) {
            p += ' <a href="#1|' + id + '">&lt;&lt;</a> ';
            p += ' <a href="#' + ((page <= 1) ? 1 : page - 1) + '|' + id + '">&lt;</a> ';
        } else {
            p += ' &lt;&lt; ';
            p += ' &lt; ';
        }
        p += page + '/' + PageCount;
        if (page < PageCount) {
            p += ' <a href="#' + ((page >= PageCount) ? PageCount : page + 1) + '|' + id + '">&gt;</a> ';
            p += ' <a href="#' + PageCount + '|' + id + '">&gt;&gt;</a> ';
        } else {
            p += ' &gt; ';
            p += ' &gt;&gt; ';
        }

        p += '</span>';
    } else {
        p = '有错误';
    }
    return p;
}
function getdata(t, page) {
    $('#' + t).html('loading.....');
    var u = $('[data-id="' + t + '"]').data('list').replace('#', '');
    setTimeout(function () {
        var pageUrl;
        if (u.indexOf('?') > 0) {
            pageUrl = u + '&nowtime=' + new Date().getTime() + '&page=' + page;
        } else {
            pageUrl = u + '?nowtime=' + new Date().getTime() + '&page=' + page;
        }
        $.getJSON(pageUrl, null).done(function (data) {
            var h = "无数据";
            var p = "0";
            if (data && data.error != "") {
                h = decodeURIComponent((data.error));
            } else if (data && data.data != "" & data.data.length > 0) {
                h = '<div class="gridTableBox"><table class="gridTable" cellspacing="0" cellpadding="0" border="0">';
                $.each(data.data, function (key1, val1) {
                    if (key1 == 0) {
                        h += '<thead><tr><th></th>';
                        $.each(val1, function (key2, val2) {
                            h += '<th>' + key2 + '</th>';
                        });
                        h += '</tr></thead><tbody>';
                    }
                    h += '<tr><td>' + key1 + '</td>';
                    $.each(val1, function (key2, val2) {
                        h += '<td>' + val2 + '</td>';
                    });
                    h += '</tr>';
                });
                h += '</tbody></table>';
                h += '<div class="page">' + setPage(data.pageIndex, data.pageCount, data.recordCount, t) + '</div>';
            }

            $('#' + t).html(h);
            $('#' + t + ' .gridTableBox').height($('.mainBot .content-main').height() - 20);
            $('#' + t + ' .gridTable').jTableScroll();
        }).fail(function (jqxhr, textStatus, error) {
            alert("操作异常：" + error);
        });
    }, 100);
}
function getdatahtml(t) {
    $('#' + t).html('loading.....');
    var u = $('[data-id="' + t + '"]').data('html').replace('#', '');
    $.get(u, null).done(function (data) {
        var h = "无数据";
        var h = '<div class="gridTableBox">' + data + '</div>';
        $('#' + t).html(h);
    }).fail(function (jqxhr, textStatus, error) {
        alert("操作异常：" + error);
    });
}
function setHeight() {
    var iframe_h = 0;
    if ($(window.parent.$("#TB_window iframe")).length > 0) {
        iframe_h = $(window.parent.$("#TB_window iframe")).height();
    } else {
        iframe_h = $("body").height();
    }
    //$('.mainBot .content-main').height(iframe_h - 40);
}
$(function () {
    //setHeight();
    $('.content .content-tabs a').click(function () {
        if ($(this).hasClass('active')) return;
        $(this).parent().children('a').removeClass('active');
        $(this).addClass('active');
        var targetId = $(this).data('id');
        $(this).parent().parent().find('.content-main').hide();
        $('#' + targetId).show();

        if ($(this).is("[data-list]")) {
            var jThis = $(this);
            var s = jThis.data('id').replace('#', '');
            if ($('#' + s).html() == "" || $('#' + s).html() == "loading") {
                getdata(s, 1);
            }
        }
    });
    $("body").on("click", ".paging a", function () {
        var s = $(this).attr('href').replace('#', '').split('|');
        getdata(s[1], s[0]);
        return false;
    });
    $("body").on("click", "[data-html]", function () {
        var s = $(this).data('id').replace('#', '');
        if ($('#' + s).html() == "" || $('#' + s).html() == "loading") {
            getdatahtml(s);
        }
    });
    $("body").on("click", "[data-iframe]", function () {
        var s = $(this).data('id').replace('#', '');
        if ($('#' + s).html() == "" || $('#' + s).html() == "loading") {
            var u = $('[data-id="' + s + '"]').data('iframe').replace('#', '');
            $('#' + s).height('200px');
            $('#' + s).html('<iframe frameborder="0" hspace="0" src="' + u + '"  style="width: 100%;height: 100%;"></iframe>');
        }
    });
});