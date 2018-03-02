$(function () {
    InitMenu();
    iframeresize();

})

function InitMenu() {
    var config = {
        type: "Post",
        url: "/Page/GetMenu"
    }
    AjaxRequest(config, function (retData) {
        InitMenuHtml(retData.Data.PageList);
    }, function (failData) {

    });
}

/**
 * 刷新当前iframe
 */
function Refresh() {
    $('.J_iframe').each(function () {
        if ($(this).css('display') == "inline") {
            LoadingFunc(true);
            var url = $(this).attr('src');
            LoadingFunc(false);
            $(this).attr('src', url);
        }
    });
}

/**刷新页面**/
function rePage() {
    Loading(true);
    window.location.href = window.location.href.replace('#', '');
    return false;
}

/**安全退出**/
function IndexOut() {
    MessageConfirm("确定要安全退出吗？", function () {
        window.location.href = "/Home/LogOut";
    });
}

/**渲染html**/
function InitMenuHtml(data) {
    var html = createMenuHtml(data, true);
    $(".strTree_v2").html(html);
    $('.nav .recordable.open').click(function () {
        $(this).toggleClass('close');
        $(this).parent().children('ul').slideToggle('fast');
    });
    $('.nav .recordable.close').click(function () {
        $(this).toggleClass('open');
        $(this).parent().children('ul').slideToggle('fast');
    });
    $('.J_menuItem').on('click', menuItem);
}
/**构造html**/
function createMenuHtml(data, top) {
    var html = '<ul class=' + (top ? 'nav' : '') + '>';
    $.each(data, function (index, item) {
        html += '<li><a onclick="return false;" class="' + (item.FChildList.length === 0 ? ' J_menuItem ' : ('recordable open ' + (item.FParentID === 0 ? '' : 'sub'))) + '" href="' + (item.FChildList.length > 0 ? '#' : item.FPageUrl) + '">' + item.FName + '</a>';
        if (item.FChildList.length > 0) {
            html += createMenuHtml(item.FChildList, false);
        }
        html += "</li>";
    });
    html += '</ul>';
    return html;
}

function menuItem() {
    // 获取标识数据
    var dataUrl = $(this).attr('href'),
        dataIndex = $(this).data('index'),
        menuName = $.trim($(this).html()).replace(/<b class\=\"g-static\"\>(.*)<\/b\>/g, ''),
        flag = true;
    // 选项卡菜单已存在
    $('.J_menuTab').each(function () {
        if ($(this).data('id') == dataUrl) {
            if (!$(this).hasClass('active')) {
                $(this).addClass('active').siblings('.J_menuTab').removeClass('active');

                // 显示tab对应的内容区
                $('.J_mainContent .J_iframe').each(function () {
                    if ($(this).data('id') == dataUrl) {
                        $(this).show().siblings('.J_iframe').hide();
                        return false;
                    }
                });
            }
            flag = false;
            return false;
        }
    });

    // 选项卡菜单不存在
    if (flag) {
        var str = '<a href="javascript:;" class="active J_menuTab clearfix" data-id="' + dataUrl + '">' + menuName + ' <i class="fa fa-times-circle">x</i> <i class="rightbak"></i></a>';
        $('.J_menuTab').removeClass('active');

        // 添加选项卡对应的iframe
        var str1 = '<iframe class="J_iframe" name="iframe' + dataIndex + '" width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
        $('.J_mainContent').find('iframe.J_iframe').hide().parents('.J_mainContent').append(str1);

        //显示loading提示
        LoadingFunc(true);

        $('.J_mainContent iframe:visible').load(function () {
            //iframe加载完成后隐藏loading提示
            HidenLoading();
        });


        // 添加选项卡
        $('.J_menuTabs .page-tabs-content').append(str);

        // 总宽度
        var countWidth = $(".content-tabs").width() - 40;

        // 可视区域宽度
        var visibleWidth = $('.page-tabs-content').width();

        // 可视区域的宽度大于总宽度
        if (visibleWidth > countWidth) {

            //移动元素的marginLeft值
            var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));
            var areaWidth = visibleWidth - countWidth
            $('.page-tabs-content').animate({
                marginLeft: '-' + areaWidth + 'px'
            }, "fast");
        }

    }

    $('a.J_menuItem.active').removeClass('active')
    $(this).addClass('active');

    return false;
}

/**自应高度**/
function iframeresize() {
    resizeU();
    $(window).resize(resizeU);
    function resizeU() {
        var divkuangH = $(window).height();
        $("#MainContent").height(divkuangH - 48);
        //导航
        var navigationheight = $(".navigation").height();
        var navPanelheight = $("#htmlMenuPanel").height();
        var navSelectheight = $(".navSelect").height();
        $(".navPanelMini").css("height", navigationheight - navSelectheight - 49);
        $(".navPanel").css("height", navigationheight - navSelectheight - 29);
        $("#sidebarTree").css("height", divkuangH - 125);
        $("#Sidebar").css("height", divkuangH - 125);
    }
}
function Loading(bool) {
    if (bool) {
        top.$("#loading").show();
    } else {
        setTimeout(loadinghide, 800);
    }
}
function loadinghide() {
    top.$("#loading").hide();
}