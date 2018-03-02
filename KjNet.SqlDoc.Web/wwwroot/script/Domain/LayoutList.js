$(document).ready(function () {
    HidenLoading();
    ResetOrderBy();
    ResetPage();
    if ($('#table-head-fixer')) {
        $('#table-head-fixer').tableHeadFixer();
    }
    $('.paging_v2 a[title],#Search').on('click', function () {
        ShowLoading();
    });
    $('form').submit(function () {
        ShowLoading();
    })
    if ($('.grid tbody tr').length > 0) {
        $('.grid:not(.noalt) tbody tr')
            .on("dblclick",
            function (e) {
                var jTrObj = $(this);
                try {
                    if (jTrObj.find('.doubleopen').length <= 0) {
                        return;
                    }
                    jTrObj.find('.doubleopen')[0].click();
                } catch (e) { }
                return false;
            }
            )
            ;
    }
    //回车键
    document.onkeydown = function (e) {
        if (!e) e = window.event; //火狐中是 window.event
        if ((e.keyCode || e.which) == 13) {
            $("#SearchForm").submit();
        }
    }
    //分页切换
    $("#PageSize").change(function () {
        $("#SearchForm").submit();
    })
    //绑定展开与收起
    if ($("#ShowMore").val() == "1") {
        $(".filter-v2-dropdown")[0].click();
    }
    $(".filter-v2-dropdown").click(function () {
        $("#ShowMore").val(1 - $("#ShowMore").val() * 1.0);
    })

    $(".btn-reset").on("click", function () {
        //  $('#SearchForm')[0].reset();
        $(':input', '#SearchForm')
            .not(':button,:submit,:reset,:hidden')
            .val('')
            .removeAttr('checked')
            .removeAttr('selected');
    });
});

$(window).resize(function () {
    ResetPage();
});

/**
刷新页面
**/
function windowload() {
    top.tb_remove();
    top.Loading(true);
    window.location.href = window.location.href.replace('#', '');
    return false;
}

function ResetPage() {
    $('.lister_v2').height($('body').height() - $('.header_v2').outerHeight(true) - $('.filter_v2').outerHeight(true) - $('.paging_v2').outerHeight(true));
}

function OrderBy(str) {
    if ($('#OrderColumn').val() != "") {
        if ($('#OrderColumn').val().indexOf('|') > 0) {
            if ($('#OrderColumn').val().split('|')[0] == str) {
                if ($('#OrderColumn').val().split('|')[1] == 'ASC') {
                    $('#OrderColumn').val(str + "|DESC");
                } else {
                    $('#OrderColumn').val(str + "|ASC");
                }
            } else {
                $('#OrderColumn').val(str + "|ASC");
            }
        }
    } else {
        $('#OrderColumn').val(str + "|ASC");
    }
    $("#SearchForm").submit();
}

function ResetOrderBy() {
    if ($('#OrderColumn') != undefined && $('#OrderColumn').val() != undefined && $('#OrderColumn').val() != "") {
        $('.sort').remove();
        $('.sortlink').removeClass('sortlink');
        $("a[onclick=\"OrderBy('" + $('#OrderColumn').val().split('|')[0] + "')\"]").append(' <span class="sort"><img src="/Content/img/sort_' + $('#OrderColumn').val().split('|')[1] + '.png"></span>').addClass('sortlink');
    }
}
