$(function () {
    var isneedTopOpen = $("#IsTop").val();
    if (isneedTopOpen == "1") {
        if (window != top) {
            top.window.location.href = location.href;
        }
    }
    $("#UserName").focus();
    $(".form-control").focus(function () {
        $(this).addClass("login-text-focus");
    }).blur(function () {
        $(this).removeClass("login-text-focus");
    });

    $("#loginForm").submit(function () {
        if ($("#loginForm").valid()) {
            AjaxRequest({
                type: this.method,
                url: this.action,
                data: $(this).serialize()
            }, function (successData) {
                MessageSuccess("登录成功", function () {
                    location.href = successData.Data.BackUrl;
                });
            }, function (failData) {
                $("#Code").focus();
                ToggleCode("codeImg", '/Home/ValidateCode');
            });
        }
        return false;
    });
});

//=============================切换验证码======================================
function ToggleCode(obj, codeurl) {
    $("#Code").val("");
    $("#" + obj).attr("src", codeurl + "?time=" + Math.random());
}