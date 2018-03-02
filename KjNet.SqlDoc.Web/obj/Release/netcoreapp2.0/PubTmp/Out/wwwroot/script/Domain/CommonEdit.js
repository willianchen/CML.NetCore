$("#frmEdit").submit(function () {
    if (!$("#frmEdit").valid()) {
        return false;
    }
    AjaxRequest({
        type: this.method,
        url: this.action,
        data: $(this).serialize()
    }, function (data) {
        MessageSuccess("操作成功", function () {
            top.refreshif();
            CloseWinSelf();
        });
    }, function (errorData) {
    });
    return false;
})