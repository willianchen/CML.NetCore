$(function () {
    InitPageMudule();
    $("#dnd-Tree").treetable({ expandable: true });
    // 选中行高亮
    $("#dnd-Tree tbody").on("mousedown", "tr", function () {
        $(".selected").not(this).removeClass("selected");
        $(this).toggleClass("selected");
        if ($(this).hasClass("selected"))
            $("#sID").val($(this).attr("data-tt-id"));
        else
            $("#sID").val(0);
    });
})

//编辑'@ViewBag.webSiteId'
function Edit(webSiteId) {
    if (webSiteId == "" || webSiteId <= 0) {
        MessageFailed("站点无效，无法修改！");
    }
    if (CheckSelected()) {
        var sID = $("#sID").val();
        var openUrl = "/Page/PageEdit?id=" + sID + "&webSiteId=" + webSiteId + "&w=800&h=600";
        OpenWin("编辑菜单", openUrl);
    }
}

//删除
function Delete() {
    if (CheckSelected()) {
        MessageConfirm("确定要删除此菜单吗？", function () {
            var keyId = $("#sID").val();
            AjaxRequest("/Page/DeletePage?id=" + keyId, function (successData) {
                MessageSuccess("删除成功");
                ReloadSelf();
            }, function (failData) { });
        });
    }
}
//确认选中记录
function CheckSelected() {
    var sID = $("#sID").val();
    if (sID == 0) {
        MessageFailed("请选择一行记录");
        return false;
    }
    return true;
}