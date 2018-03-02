/* jquery 表单验证使用实例！  */
//获取Request notnull
function isRequestNotNull(obj) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj == null || obj == undefined) {
        return true;
    }
    else
        return false;
}
//验证不为空 notnull
function isNotNull(obj) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj == null || obj == undefined) {
        return true;
    }
    else
        return false;
}
//验证发布范围为员工的时候员工不能为空
function empisNotNull(obj, emp) {
    obj = $.trim(obj);
    emp = $.trim(emp);
    if (obj == "1" && emp == "") {
        return true;
    } else
        return false;
}

//验证不为空 notnull
function isNotNulldrop(obj) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj == null || obj == undefined || obj == "0") {
        return true;
    }
    else
        return false;
}

//验证数字 可为null  num
function isInteger(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[-+]?\d+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证两次密码是否相同
function ChackPwd(pw1, pw2) {
    pw1 = $.trim(pw1);
    pw2 = $.trim(pw2);
    if (pw1 == pw2) {
        return true;
    }
    else {
        return false;
    }
}

//验证大于等于0的整数;
function isP0Int(obj) {
    reg = /^[0-9]\d*$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}


//验证大于0的整数;
function isPInt(obj) {
    reg = /^[1-9]\d*$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}
//验证小于10亿的整数;
function isPInts(obj) {
    reg = /^[1-9]\d*(\.\d+)?$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        if (obj < 1000000000) {
            return true;
        }
        return false;
    }
}

//验证大于0的整数 或者空
function isPIntOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[1-9]\d*$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}


//验证大于0的数字/^[1-9]\d*(\.\d+)?$/;
function isDoubleGtz(obj) {
    reg = /^[1-9]\d*(\.\d+)?$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}
//验证大于0的数字 或者空
function isDoubleGtzOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[1-9]\d*(\.\d+)?$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//add by luoshijie on 2015.7.25
//百分比判断
function RateValid(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^0\.[0-9]*$/;
    if (controlObj == 1 || controlObj == 0) {
        return true;
    }
    if (!reg.test(obj)) {
        return false;
    }
    else {
        return true;
    }
}

//比较贷款金额和可贷金额
function compare(obj, obj1) {
    var Obj = $.trim(obj);
    var Obj1 = $.trim(obj1);
    if (parseFloat(Obj) - parseFloat(Obj1) < 0.00001) {
        return true;
    }
        //if (eval(Obj) <= eval(Obj1) && eval(Obj)>0) {

        //}
    else { return false; }
}

//验证数字 num  或者null,空
function isIntegerOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[-+]?\d+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//Email验证 email
function isEmail(obj) {
    reg = /^\w{3,}@\w+(\.\w+)+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//Email验证 email   或者null,空
function isEmailOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^\w{3,}@\w+(\.\w+)+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证只能输入英文字符串 echar
function isEnglishStr(obj) {
    reg = /^[a-z,A-Z]+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证只能输入英文字符串 echar 或者null,空
function isEnglishStrOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[a-z,A-Z]+$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否是n位数字字符串编号 nnum
function isLenNum(obj, n) {
    reg = /^[0-9]+$/;
    obj = $.trim(obj);
    if (obj.length > n)
        return false;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}



//验证是否是n位数字字符串编号 nnum或者null,空
function isLenNumOrNull(obj, n) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^[0-9]+$/;
    obj = $.trim(obj);
    if (obj.length > n)
        return false;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否是七位数的字符串 nchar
function isLenStr1(obj) {
    //reg = /^[A-Za-z0-9\u0391-\uFFE5]+$/;
    obj = $.trim(obj);
    if (obj.length < 7 || obj.length > 7)
        return false;
    else
        return true;
    //    if (!reg.test(obj)) {
    //        return false;
    //    } else {
    //        return true;
    //    }
}
function isMustLenStr(obj, n) {
    //reg = /^[A-Za-z0-9\u0391-\uFFE5]+$/;
    obj = $.trim(obj);
    if (obj.length < n || obj.length > n)
        return false;
    else
        return true;
    //    if (!reg.test(obj)) {
    //        return false;
    //    } else {
    //        return true;
    //    }
}
//验证是否小于等于n位数的字符串 nchar
function isLenStr(obj, n) {
    //reg = /^[A-Za-z0-9\u0391-\uFFE5]+$/;
    obj = $.trim(obj);
    if (obj.length == 0 || obj.length > n)
        return false;
    else
        return true;
    //    if (!reg.test(obj)) {
    //        return false;
    //    } else {
    //        return true;
    //    }
}

//验证是否小于等于n位数的字符串 nchar或者null,空
function isLenStrOrNull(obj, n) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    //reg = /^[A-Za-z0-9\u0391-\uFFE5]+$/;
    obj = $.trim(obj);
    if (obj.length > n)
        return false;
        //    if (!reg.test(obj)) {
        //        return false;
        //    } else {
        //        return true;
        //    }
    else
        return true;
}

//验证是否电话号码 phone
function isTelephone(obj) {
    reg = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否电话号码 phone或者null,空
function isTelephoneOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否手机号 mobile
function isMobile(obj) {
    reg = /^(\+\d{2,3}\-)?\d{11}$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }

    //修改人：罗世杰 修改时间：2015.7.31
    //  var telReg = !!obj.match(/^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/);
    //  return telReg;
}

//验证是否手机号 mobile或者null,空
function isMobileOrnull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^(\+\d{2,3}\-)?\d{11}$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否手机号或电话号码 mobile phone 
function isMobileOrPhone(obj) {
    reg_mobile = /^(\+\d{2,3}\-)?\d{11}$/;
    reg_phone = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;
    if (!reg_mobile.test(obj) && !reg_phone.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证是否手机号或电话号码 mobile phone或者null,空
function isMobileOrPhoneOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^(\+\d{2,3}\-)?\d{11}$/;
    reg2 = /^(\d{3,4}\-)?[1-9]\d{6,7}$/;
    if (!reg.test(obj) && !reg2.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证网址 uri
function isUri(obj) {
    reg = /^http:\/\/[a-zA-Z0-9]+\.[a-zA-Z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证网址 uri或者null,空
function isUriOrnull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    reg = /^http:\/\/[a-zA-Z0-9]+\.[a-zA-Z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
    if (!reg.test(obj)) {
        return false;
    } else {
        return true;
    }
}

//验证两个值是否相等 equals
function isEqual(obj1, controlObj) {
    if (obj1.length != 0 && controlObj.length != 0) {
        if (obj1 == controlObj)
            return true;
        else
            return false;
    }
    else
        return false;
}

//判断日期类型是否为YYYY-MM-DD格式的类型 date
function isDate(obj) {
    if (obj.length != 0) {
        reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断日期类型是否为YYYY-MM-DD格式的类型 date或者null,空
function isDateOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断日期类型是否为YYYY-MM-DD hh:mm:ss格式的类型 datetime
function isDateTime(obj) {
    if (obj.length != 0) {
        reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断日期类型是否为YYYY-MM-DD hh:mm:ss格式的类型 datetime或者null,空
function isDateTimeOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断日期类型是否为hh:mm:ss格式的类型 time
function isTime(obj) {
    if (obj.length != 0) {
        reg = /^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断日期类型是否为hh:mm:ss格式的类型 time或者null,空
function isTimeOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的字符是否为中文 cchar 
function isChinese(obj) {
    if (obj.length != 0) {
        reg = /^[\u0391-\uFFE5]+$/;
        if (!reg.test(str)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的字符是否为中文 cchar或者null,空
function isChineseOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^[\u0391-\uFFE5]+$/;
        if (!reg.test(str)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的邮编(只能为六位)是否正确 zip
function isZip(obj) {
    if (obj.length != 0) {
        reg = /^\d{6}$/;
        if (!reg.test(str)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的邮编(只能为六位)是否正确 zip或者null,空
function isZipOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^\d{6}$/;
        if (!reg.test(str)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的字符是否为双精度 double
function isDouble(obj) {
    if (obj.length != 0) {
        reg = /^[-\+]?\d+(\.\d+)?$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断输入的字符是否为双精度 double或者null,空
function isDoubleOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^[-\+]?\d+(\.\d+)?$/;
        if (!reg.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    }
}

//判断是否为身份证 idcard
function isIDCard(obj) {
    if (obj.length != 0) {
        reg = /^\d{15}(\d{2}[A-Za-z0-9;])?$/;
        if (!reg.test(obj))
            return false;
        else
            return true;
    }
}

//判断是否为身份证 idcard或者null,空
function isIDCardOrNull(obj) {
    var controlObj = $.trim(obj);
    if (controlObj.length == 0 || controlObj == null || controlObj == undefined) {
        return true;
    }
    if (obj.length != 0) {
        reg = /^\d{15}(\d{2}[A-Za-z0-9;])?$/;
        if (!reg.test(obj))
            return false;
        else
            return true;
    }
}

//判断是否为字母或数字
function isNumbserOrLetter(obj) {
    var b = /^[A-Za-z0-9]+$/;
    if (!b.test(obj))
        return false;
    else
        return true;
}





//验证脚本
//obj为当前input所在的空间容器 (例如：Div,Panel)
//脚本中 checkvalue 验证函数  err 属性表示提示【中文名称】
function JudgeValidate(obj) {
    var Validatemsg = "";
    var Validateflag = true;

    //获取当前元素中属性datacol=yes的标签并遍历
    $(obj).find("[datacol=yes]").each(
        function () {
            //当前标签属性checkexpession有值的情况
            if ($(this).attr("checkexpession") != undefined) {
                switch ($(this).attr("checkexpession"))  //empisNotNull
                {

                    case "NotNull":
                        {

                            if (isNotNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "不能为空！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "EmpNotNull":
                        {
                            if (empisNotNull($("#sAddSource").attr("value"), $("#txtEmpId").attr("value"))) {
                                Validatemsg = $(this).attr("err") + "不能为空！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "dropNotNull":
                        {

                            if (isNotNulldrop($(this).val())) {
                                Validatemsg = $(this).attr("err") + "不能为空！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Num":
                        {
                            if (!isInteger($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "DoubleGtzOrNull":
                        {
                            if (!isDoubleGtzOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为大于0的数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "DoubleGtz":
                        {
                            if (!isPInt($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为大于0的整数！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }

                    case "DoublePInt":
                        {
                            if (!isPInts($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须小于十亿！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "PIntOrNull":
                        {
                            if (!isPIntOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为大于0的整数！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }

                    case "PInt":
                        {
                            if (!isDoubleGtz($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为大于0的数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Compare":
                        {
                            if (!compare($(this).val(), $('#txtCanLoanAmount').attr("value"))) {
                                Validatemsg = $(this).attr("err") + "必须大于0且比可贷金额小！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Quota":
                        {
                            if (!compare($(this).val(), $('#txtQuota').attr("value"))) {
                                Validatemsg = $(this).attr("err") + "必须小于实际授信额度！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "NumOrNull":
                        {
                            if (!isIntegerOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "Email":
                        {
                            if (!isEmail($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为E-mail格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "EmailOrNull":
                        {
                            if (!isEmailOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为E-mail格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "EnglishStr":
                        {
                            if (!isEnglishStr($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为字符串！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "EnglishStrOrNull":
                        {
                            if (!isEnglishStrOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为字符串！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "LenNum":
                        {
                            if (!isLenNum($(this).val(), $(this).attr("length"))) {
                                Validatemsg = $(this).attr("err") + "必须为" + $(this).attr("length") + "位数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "LenNumOrNull":
                        {
                            if (!isLenNumOrNull($(this).val(), $(this).attr("length"))) {
                                Validatemsg = $(this).attr("err") + "必须为" + $(this).attr("length") + "位数字！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "LenStr":
                        {
                            if (!isLenStr($(this).val(), $(this).attr("length"))) {
                                Validatemsg = $(this).attr("err") + "必须小于等于" + $(this).attr("length") + "位字符！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "isLenStrs":
                        {
                            if (!isLenStr1($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须是七位字符！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "isMustLenStr":
                        {
                            if (!isMustLenStr($(this).val(), $(this).attr("length"))) {
                                Validatemsg = $(this).attr("err") + "必须是" + $(this).attr("length") + "位字符！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "LenStrOrNull":
                        {
                            if (!isLenStrOrNull($(this).val(), $(this).attr("length"))) {
                                Validatemsg = $(this).attr("err") + "必须小于" + $(this).attr("length") + "位字符！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Phone":
                        {
                            if (!isTelephone($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须电话格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Fax":
                        {
                            if (!isTelephoneOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为传真格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "PhoneOrNull":
                        {
                            if (!isTelephoneOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须电话格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Mobile":
                        {

                            if (!isMobile($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为手机格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "MobileOrNull":
                        {
                            if (!isMobileOrnull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为手机格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "MobileOrPhone":
                        {
                            if (!isMobileOrPhone($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为电话格式或手机格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "MobileOrPhoneOrNull":
                        {
                            if (!isMobileOrPhoneOrNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为电话格式或手机格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Uri":
                        {
                            if (!isUri($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为网址格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "UriOrNull":
                        {
                            if (!isUriOrnull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须为网址格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Equal":
                        {
                            if (!isEqual($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "不相等！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Date":
                        {
                            if (!isDate($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为日期格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "DateOrNull":
                        {
                            if (!isDateOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为日期格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "DateTime":
                        {
                            if (!isDateTime($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为日期时间格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "DateTimeOrNull":
                        {
                            if (!isDateTimeOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为日期时间格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Time":
                        {
                            if (!isTime($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为时间格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "TimeOrNull":
                        {
                            if (!isTimeOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为时间格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "ChineseStr":
                        {
                            if (!isChinese($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为中文！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "ChineseStrOrNull":
                        {
                            if (!isChineseOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为中文！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Zip":
                        {
                            if (!isZip($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为邮编格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "ZipOrNull":
                        {
                            if (!isZipOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为邮编格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "Double":
                        {
                            if (!isDouble($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "不能为空且必须为小数！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "DoubleOrNull":
                        {

                            if (!isDoubleOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为小数！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "IDCard":
                        {
                            if (!isIDCard($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为身份证格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "IDCardOrNull":
                        {
                            if (!isIDCardOrNull($(this).val(), $(this).attr("eqvalue"))) {
                                Validatemsg = $(this).attr("err") + "必须为身份证格式！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "RequestNotNull":
                        {
                            if (isNotNull($(this).val())) {
                                Validatemsg = $(this).attr("err") + "！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                        //add by luoshijie on 2015.7.25  
                    case "RateValid":
                        {
                            if (!RateValid($(this).val())) {
                                Validatemsg = $(this).attr("err") + "必须<=1\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "ChackPwdLength":
                        {
                            var v = $(this).val();
                            if (isNotNull(v) || v.length < 8 || v.length > 16 || !isNumbserOrLetter(v)) {
                                Validatemsg = "请设置正确的密码8-16位，大小写字母或数字!";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "isP0Int":
                        {
                            var sortvalues = $(this).val();
                            if (!isP0Int(sortvalues) || sortvalues > 9999) {
                                Validatemsg = "请填写正确的显示顺序，0-9999的正整数！\n";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg); return false;
                            }
                            break;
                        }
                    case "ChackPwd":
                        {
                            if (!ChackPwd($(this).val(), $("#txtNewPwd").attr("value"))) {
                                Validatemsg = $(this).attr("err") + "与新密码不一致，请重新填写！";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    case "ChackLName":
                        {
                            //必填，1-20位字母或数字，区分大小写，未填写、格式错误或超限时提示：“”；
                            var v = $(this).val();
                            if (isNotNull(v) || v.length < 1 || v.length > 20 || !isNumbserOrLetter(v)) {
                                Validatemsg = "请填写正确的登录用户名，1-20位字母或数字区分大小写!";
                                Validateflag = false;
                                ChangeCss($(this), Validatemsg);
                                return false;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
        });
    if (Validatemsg.length > 0) {
        return Validateflag;
    }
    return Validateflag;
}
//修改出错的input的外观
function ChangeCss(obj, Validatemsg) {
    $(obj).removeClass("txt");
    if ($(obj).attr('class') == 'select') {
        $(obj).addClass("tooltipinputerr");
        $(obj).css('height', '22').css('line-height', '22');
    } else {
        $(obj).addClass("tooltipinputerr");
    }
    $(obj).focus(); //焦点
    $('body').append('<table id="tipTable" class="tableTip"><tr><td  class="leftImage"></td> <td class="contenImage" align="left"></td> <td class="rightImage"></td></tr></table>');
    var X = $(obj).offset().top;
    var Y = $(obj).offset().left;
    $('#tipTable').css({ left: Y - 2 + 'px', top: X + 21 + 'px' });
    $('#tipTable').show()
    $('.contenImage').html(Validatemsg);
    $(obj).change(function () {
        if ($(obj).val() != "") {
            $(obj).removeClass("tooltipinputerr");
            $(obj).addClass("tooltipinputok");
            $('#tipTable').hide()
        }
    });
}

function ChkFCss(obj, Validatemsg) {
    $(obj).removeClass("txt");
    if ($(obj).attr('class') == 'select') {
        $(obj).addClass("tooltipinputerr");
        $(obj).css('height', '22').css('line-height', '22');
    } else {
        $(obj).addClass("tooltipinputerr");
    }
    $(obj).focus(); //焦点
    $('body').append('<table id="tipTable" class="tableTip"><tr><td  class="leftImage"></td> <td class="contenImage" align="left"></td> <td class="rightImage"></td></tr></table>');
    var X = $(obj).offset().top;
    var Y = $(obj).offset().left;
    $('#tipTable').css({ left: Y - 2 + 'px', top: X + 21 + 'px' });
    $('#tipTable').show()
    $('.contenImage').html(Validatemsg);

}

function ChkTCss(obj) {
    $(obj).removeClass("tooltipinputerr");
    $(obj).addClass("tooltipinputok");
    $('#tipTable').hide()

}