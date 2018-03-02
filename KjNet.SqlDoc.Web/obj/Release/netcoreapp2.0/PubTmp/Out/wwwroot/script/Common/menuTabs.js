//选项卡

    

// 关闭选项卡菜单
function closeTab() {

    var closeTabId = $(this).parents('.J_menuTab').data('id');
    var currentWidth = $(this).parents('.J_menuTab').width();

    // 当前元素处于活动状态
    if ($(this).parents('.J_menuTab').hasClass('active')) {

        // 当前元素后面有同辈元素，使后面的一个元素处于活动状态
        if ($(this).parents('.J_menuTab').next('.J_menuTab').size()) {

            var activeId = $(this).parents('.J_menuTab').next('.J_menuTab:eq(0)').data('id');
            $(this).parents('.J_menuTab').next('.J_menuTab:eq(0)').addClass('active');

            $('a.J_menuItem.active').removeClass('active');
            $("a[href='" + $(this).parents('.J_menuTab').next('.J_menuTab:eq(0)').data('id') + "']").addClass('active');

            $('.J_mainContent .J_iframe').each(function () {
                if ($(this).data('id') == activeId) {
                    $(this).show().siblings('.J_iframe').hide();
                    return false;
                }
            });

            var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));
            if (marginLeftVal < 0) {
                $('.page-tabs-content').animate({
                    marginLeft: (marginLeftVal + currentWidth) + 'px'
                }, "fast");
            }

            //  移除当前选项卡
            $(this).parents('.J_menuTab').remove();

            // 移除tab对应的内容区
            $('.J_mainContent .J_iframe').each(function () {
                if ($(this).data('id') == closeTabId) {
                    $(this).remove();
                    return false;
                }
            });


        }

        // 当前元素后面没有同辈元素，使当前元素的上一个元素处于活动状态
        if ($(this).parents('.J_menuTab').prev('.J_menuTab').size()) {
            var activeId = $(this).parents('.J_menuTab').prev('.J_menuTab:last').data('id');
            $(this).parents('.J_menuTab').prev('.J_menuTab:last').addClass('active');
            $('.J_mainContent .J_iframe').each(function () {
                if ($(this).data('id') == activeId) {
                    $(this).show().siblings('.J_iframe').hide();
                    return false;
                }
            });



            $('.nav a.active').removeClass('active');
            $("a[href='" + $(this).parents('.J_menuTab').prev('.J_menuTab:last').data('id') + "']").addClass('active');

            //  移除当前选项卡
            $(this).parents('.J_menuTab').remove();

            // 移除tab对应的内容区
            $('.J_mainContent .J_iframe').each(function () {
                if ($(this).data('id') == closeTabId) {
                    $(this).remove();
                    return false;
                }
            });
        }

    }

        // 当前元素不处于活动状态
    else {

        //  移除当前选项卡
        $(this).parents('.J_menuTab').remove();


        // 移除相应tab对应的内容区
        $('.J_mainContent .J_iframe').each(function () {
            if ($(this).data('id') == closeTabId) {
                $(this).remove();
                return false;
            }
        });
    }


    // 总宽度
    var countWidth = $(".content-tabs").width() - 80;

    // 可视区域宽度
    var visibleWidth = $('.page-tabs-content').width();

    // 移动元素的marginLeft值
    var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));

    // 可视区域的宽度大于总宽度
    if (visibleWidth > countWidth) {

        // 已到左边
        if (marginLeftVal == 0) {
            if (visibleWidth + marginLeftVal > countWidth) {
                $('.page-tabs-content').animate({
                    marginLeft: marginLeftVal + (-100) + 'px'
                }, "fast");
            }
            return
        }

        if (marginLeftVal + 100 > 0) {
            $('.page-tabs-content').animate({
                marginLeft: marginLeftVal - marginLeftVal + 'px'
            }, "fast");
            return;
        }

        // 超过左边
        if (marginLeftVal < 0) {
            if (visibleWidth > countWidth) {
                $('.page-tabs-content').animate({
                    marginLeft: marginLeftVal + (100) + 'px'
                }, "fast");
                return
            }

        }

    } else if (visibleWidth < countWidth) {
        if (marginLeftVal + 100 > 0) {
            $('.page-tabs-content').animate({
                marginLeft: marginLeftVal - marginLeftVal + 'px'
            }, "fast");
            return;
        } else {
            $('.page-tabs-content').animate({
                marginLeft: marginLeftVal + (100) + 'px'
            }, "fast");
        }
    }

    return false;
}

// 点击选项卡菜单
function activeTab() {
    if (!$(this).hasClass('active')) {
        var currentId = $(this).data('id');



        // 显示tab对应的内容区
        $('.J_mainContent .J_iframe').each(function () {
            if ($(this).data('id') == currentId) {
                $(this).show().siblings('.J_iframe').hide();
                return false;
            }
        });
        $(this).addClass('active').siblings('.J_menuTab').removeClass('active');
        //$(this).addClass('active').siblings('.J_menuTab').removeClass('active');


        $('a.J_menuItem.active').removeClass('active');
        $("a[href='" + $(this).data('id') + "']").addClass('active');



    }
}
//刷新iframe
function refreshTab() {

    var target = $('.J_iframe[data-id="' + $(this).data('id') + '"]');
    var url = target.attr('src');

    //显示loading提示
    LoadingFunc(true);
    //var loading = layer.load();

    target.attr('src', url).load(function () {

        //关闭loading提示
        //layer.close(loading);
        HidenLoading();
    });
}
$(function () {

    //通过遍历给菜单项加上data-index属性
    $(".J_menuItem").each(function (index) {
        if (!$(this).attr('data-index')) {
            $(this).attr('data-index', index);
        }
    });
    $('.J_menuTabs').on('click', '.J_menuTab i', closeTab);

    $('.J_menuTabs').on('click', '.J_menuTab', activeTab);
 
    $('.J_menuTabs').on('dblclick', '.J_menuTab', refreshTab);
    // 右移按扭
    $('.J_tabLeft').on('click', function () {
        // 移动元素的marginLeft值
        var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));

        if (marginLeftVal + 100 >= 0) {
            $('.page-tabs-content').animate({
                marginLeft: marginLeftVal - marginLeftVal + 'px'
            }, "fast");
            return;

        }
        if ((marginLeftVal + 100) < 0) {
            $('.page-tabs-content').animate({
                marginLeft: marginLeftVal + 100 + 'px'
            }, "fast");

        }
		
    });
    // 左移按扭
    $('.J_tabRight').on('click', function () {

        // 总宽度
        var countWidth = $(".content-tabs").width() - 80;

        // 可视区域宽度
        var visibleWidth = $('.page-tabs-content').width();

        // 移动元素的marginLeft值
        var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));

        // 可视区域的宽度大于总宽度
        if (visibleWidth > countWidth) {

            // 已到左边
            if (marginLeftVal == 0) {
                $('.page-tabs-content').animate({
                    marginLeft: marginLeftVal + (-100) + 'px'
                }, "fast");
            }

            // 超过左边
            if (marginLeftVal <= 0) {
                if (visibleWidth + marginLeftVal > countWidth)
                    $('.page-tabs-content').animate({
                        marginLeft: marginLeftVal + (-100) + 'px'
                    }, "fast");
            }

        }
    });

	$(".J_tabCloseAll").on("click",function(){
		$(".page-tabs-content").children("[data-id]").not(":first").each(function(){
			$('.J_iframe[data-id="'+$(this).data("id")+'"]').remove(),
			$(this).remove()
		}),
		$(".page-tabs-content").children("[data-id]:first").each(function(){
			$('.J_iframe[data-id="'+$(this).data("id")+'"]').show(),
			$(this).addClass("active")
		}),
		$(".page-tabs-content").css("margin-left","150")
	});


});



//回调
function windowload() {
    rePage();
}
function rePage() {

    var target = $('.J_iframe:visible');
    var url = target.attr('src');

    //显示loading提示
    LoadingFunc(true);
    //var loading = layer.load();

    target.attr('src', url).load(function () {

        //关闭loading提示
        //layer.close(loading);
        HidenLoading();
    });
}