
/**
 * 省份级联下拉框初始化
 * @param {*当前省份对象} obj 
 * @param {*关联城市对象} objCity 
 * @param {*省份选种值} currentVal 
 * @param {*城市选中值} currentCity 
 */
var GetProvinceCityList = function (obj, objCity, currentVal, currentCity) {
    var config = {
        type: "Get",
        url: "/Province/GetProvinceList"
    }
    var callback = function () {
        var selectedProvince = $(obj + " option:selected").attr("data-fprovinceid");
        if(selectedProvince!==undefined)
        GetCityList(objCity, currentCity, selectedProvince);
    };

    BindSelectOption(config, obj, "FCode", "FName", "FProvinceID", currentVal, callback, callback);
}

/**
 * 省份下拉框初始化
 * @param {*当前城市对象} obj 
 * @param {*当前选中城市值} currentVal 
 * @param {*城市对应省份值ID} selectedProvince 
 */
var GetProvinceList = function(obj, currentVal) {
    var config = {
        type: "Get",
        url: "/Province/GetProvinceList"
    }
    BindSelectOption(config, obj, "FCode", "FName", "FProvinceID", currentVal);
}

/**
 * 城市下拉框初始化
 * @param {*当前城市对象} obj 
 * @param {*当前选中城市值} currentVal 
 * @param {*城市对应省份值ID} selectedProvince 
 */
var GetCityList = function (obj, currentVal, selectedProvince) {
    var config = {
        type: "Get",
        url: "/City/GetCityList",
        data: { provinceID: selectedProvince }
    }
    BindSelectOption(config, obj, "FCode", "FName", "FCityCode", currentVal);
}

/**
 * 部门下拉框初始化
 * @param {*当前对象} obj 
 * @param {*选中值} currentVal 
 */
var GetDeptList = function (obj, currentVal) {
    var config = {
        type: "Get",
        url: "/Department/GetDeptSelect"
    }
    BindSelectOption(config, obj, "Key", "Value", "ParentId", currentVal, null, null, true);
}