/**
 * 实用操作封装。
 *
 * @author dongxiaochai@163.com
 * @since 2015-04-23
 */

/*
 * 注册模块。
 *
 * @date 2015-03-31
 * @author dongxiaochai@163.com
 */
(function(){
	var Obj = {
		/**
		 * 通用正则
		 */
		REGEXP: {
	        // 浮点数
	        decmal: /^([+-]?)\d*\.\d+$/,
	        // 正浮点数
	        decmal1: /^[1-9]\d*.\d*|0.\d*[1-9]\d*$/,
	        // 负浮点数
	        decmal2: /^-([1-9]\d*.\d*|0.\d*[1-9]\d*)$/,
	        // 浮点数
	        decmal3: /^-?([1-9]\d*.\d*|0.\d*[1-9]\d*|0?.0+|0)$/,
	        // 非负浮点数（正浮点数 + 0）
	        decmal4: /^[1-9]\d*.\d*|0.\d*[1-9]\d*|0?.0+|0$/,
	        // 非正浮点数（负浮点数 +
	        // 0）
	        decmal5: /^(-([1-9]\d*.\d*|0.\d*[1-9]\d*))|0?.0+|0$/,
	        // 整数
	        intege: /^-?[1-9]\d*$/,
	        // 正整数
	        intege1: /^[1-9]\d*$/,
	        // 负整数
	        intege2: /^-[1-9]\d*$/,
	        // 数字
	        num: /^([+-]?)\d*\.?\d+$/,
	        // 正数（正整数 + 0）
	        num1: /^[1-9]\d*|0$/,
	        // 负数（负整数 + 0）
	        num2: /^-[1-9]\d*|0$/,
	        // 仅ACSII字符
	        ascii: /^[\x00-\xFF]+$/,
	        // 仅中文
	        chinese: /^[\u4e00-\u9fa5]+$/,
	        // 颜色
	        color: /^[a-fA-F0-9]{6}$/,
	        // 日期
	        date: /^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$/,
	        // 邮件
	        email: /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/,
	        // 身份证
	        idcard: /(^\d{18}$)|(^\d{15}$)|(^\d{17}(\d|X|x)$)/,
	        // ip地址
	        ip4: /^(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)$/,
	        // 字母
	        letter: /^[A-Za-z]+$/,
	        // 小写字母
	        letter_l: /^[a-z]+$/,
	        // 大写字母
	        letter_u: /^[A-Z]+$/,
	        // 手机
	        mobile: /^0?(13|15|18|14|17)[0-9]{9}$/,
	        // 非空
	        notempty: /^\S+$/,
	        // 密码
	        password: /^.*[A-Za-z0-9\w_-]+.*$/,
	        // 数字
	        fullNumber: /^[0-9]+$/,
	        // 图片
	        picture: /(.*)\.(jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$/,
	        // QQ号码
	        qq: /^[1-9]*[1-9][0-9]*$/,
	        // 压缩文件
	        rar: /(.*)\.(rar|zip|7zip|tgz)$/,
	        // 电话号码的函数(包括验证国内区号,国际区号,分机号)
	        tel: /^[0-9\-()（）]{7,18}$/,
	        // url
	        url: /^http[s]?:\/\/([\w-]+\.)+[\w-]+([\w-./?%&=]*)?$/,
	        // 用户名
	        username: /^[A-Za-z0-9_\-\u4e00-\u9fa5]+$/,
	        // 单位名
	        deptname: /^[A-Za-z0-9_()（）\-\u4e00-\u9fa5]+$/,
	        // 邮编
	        zipcode: /^\d{6}$/,
	        // 真实姓名
	        realname: /^[A-Za-z\u4e00-\u9fa5]+$/,
	        companyname: /^[A-Za-z0-9_()（）\-\u4e00-\u9fa5]+$/
		},

		/**
		 * 将时间转换成指定格式。
		 *
		 * @param {String|Date|Number} sDateTime
		 * @param {String} sFormat 格式化字符串
		 * @return {Date}
		 */
		formatDate: function(sDateTime , sFormat) {
			if(!sDateTime){
				return "";
			}
			var dDate = null,
				sDateType = $.type(sDateTime)
			;

			if (sDateType === "date") {	// 日期对象。
				dDate = sDateTime;
			} else if (sDateType === "number") {	// 毫秒值类型。
				dDate = new Date(Number(sDateTime));
			} else if (sDateType === "string") {	// 字数串类型。
				dDate = new Date(sDateTime);
			}

		    var oFormat = {
			    "M+" : dDate.getMonth() + 1, //月份
			    "d+" : dDate.getDate(), //日
			    "h+" : dDate.getHours() % 12 == 0 ? 12 : dDate.getHours() % 12, //小时
			    "H+" : dDate.getHours(), //小时
			    "m+" : dDate.getMinutes(), //分
			    "s+" : dDate.getSeconds(), //秒
			    "q+" : Math.floor((dDate.getMonth()+3)/3), //季度
			    "S" : dDate.getMilliseconds() //毫秒
		    };
		    var oWeek = {
			    "0" : "/u65e5",
			    "1" : "/u4e00",
			    "2" : "/u4e8c",
			    "3" : "/u4e09",
			    "4" : "/u56db",
			    "5" : "/u4e94",
			    "6" : "/u516d"
		    };
		    if(/(y+)/.test(sFormat)){
		        sFormat = sFormat.replace(RegExp.$1, (dDate.getFullYear() + "").substr(4 - RegExp.$1.length));
		    }
		    if(/(E+)/.test(sFormat)){
		        sFormat = sFormat.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + oWeek[this.getDay() + ""]);
		    }
		    for(var k in oFormat){
		        if(new RegExp("("+ k +")").test(sFormat)){
		            sFormat = sFormat.replace(RegExp.$1, (RegExp.$1.length == 1) ? (oFormat[k]) : (("00" + oFormat[k]).substr(("" + oFormat[k]).length)));
		        }
		    }
		    return sFormat;
		},

		/**
		 * 四舍五入保留小数
		 * @param  {Number}  num			需要转化的数值
		 * @param  {Integer}  cutNum       	保留的小数位数
		 * @param  {Boolean} isRemoveZero 	是否移除末尾的0，默认不需要
		 * @return {Number}
		 */
		toFixed: function(num, cutNum, isRemoveZero){
			var sReturn = '0';
			num = parseFloat(num);
			if(isNaN(num)){
				num = 0;
			}
			cutNum = cutNum || 0;
			if(num.toString() == "NaN"){
				num = 0;
			} else{
				num = num.toFixed(cutNum);
			}

			sReturn = num.toString();
			if(isRemoveZero){
				while(sReturn.indexOf('.') > -1 && sReturn.endsWith('0')){
					sReturn = sReturn.substr(0, sReturn.length - 1);
				}
				if(sReturn.endsWith(".")) {
					sReturn = sReturn.substring(0, sReturn.length - 1);
				}
			}
			return sReturn;
		},

		/**
		 * 加载样式文件到 head 中。
		 * 如果某样式在 3 秒钟内未能加载成功，则会主动以超时处理，并主动调用回调函数。
		 *
		 * @param {String} sSrc
		 * @param {Function|undefined} fnSuccess 仅非 IE 浏览器仅支持较新版本的。
		 * @param {Boolean} 返回当前是 load 调用的回调还是超时主动调用的， load: true, timeout: false。
		 * @return {jQuery} 创建的 link 对象。
		 */
		getStyle: function(sSrc, fnSuccess) {
			var bIsLoad = false,
				nTimeout = setTimeout(function() {
					if (!bIsLoad) {
						fnSuccess && fnSuccess(false); // timeout 方式回调。
						bIsLoad = true;
					}
				}, 3 * 1000)
			;

			return $('<link href="' + sSrc + '" rel="stylesheet" />')
				.appendTo("head")
				// onload 事件非 IE 浏览器仅较新的版本才支持。
				.on("load", function() {
					if (!bIsLoad) {
						clearTimeout(nTimeout);
						fnSuccess && fnSuccess(true); // load 方式回调。
						bIsLoad = true;
					}
				})
			;
		},

        /**
         * 同步加载脚本。
         *
         * @param {String} sUrl 要加载的脚本地址。
         * @param {Function|undefined} fnSuccess 成功回调。
         * @param {Object|undefined} oSettings 其它配置。
         * @return {jQuery}
         */
        getScript: function(sUrl, fnSuccess, oSettings) {
            // 参数合并。
            oSettings = $.extend({
                url: sUrl,
                dataType: "script",
                async: false,
                success: fnSuccess,
                cache: true // 启用缓存功能。
            }, oSettings || {});

            return $.ajax(oSettings);
        },

        /**
         * 同步加载脚本集。
         *
         * @param {Array} asUrls 要加载的脚本地址列表。
         * @param {Function|undefined} fnSuccess 全部成功回调。
         * @param {Object|undefined} oSettings 其它配置。
         * @return {void}
         */
        getScripts: function(asUrls, fnSuccess, oSettings) {
            var oThis = this,
                abLoaded = []
            ;

            if (typeof asUrls === "string") {   // 如果是单个字符串参数，转换成数组。
                asUrls = [asUrls];
            }

            var nArrIndex = 0;
            function execSyncGetScript() {
                var sUrl = asUrls[nArrIndex];

                oThis.getScript(sUrl, function () {
                    nArrIndex++;
                    if(nArrIndex < asUrls.length) {
                        execSyncGetScript();
                    } else {
                        fnSuccess && fnSuccess();
                    }
                }, oSettings);
            }
            execSyncGetScript();
        },

		/**
		 * 将字数符反参数解决成对象。
		 * 与 $.param 相对。
		 *
		 * @method
		 * @param {String} sParams
		 * @return {Object}
		 */
		unparam: function(sParams) {
			var asParams = (sParams || "").split("&"),
				oParams = {},
				asSplitedParam = []
			;

			for (var i = asParams.length - 1; i >= 0; i--) {
				asSplitedParam = asParams[i].split("=");
				oParams[asSplitedParam[0]] = decodeURIComponent(asSplitedParam[1] || "");
			}

			return oParams;
		},

		/**
		 * 从 URL 中读取某个参数值。
		 *
		 * @method getParam
		 * @param {String} sName
		 * @param {String|undefined} sHref ({location.href})
		 * @return {String}
		 */
		getParam : function (sName, sHref) {
			if(!sHref){
				sHref = location.href;
			}
			var sVal = (this.unparam((sHref || location.href).split("?")[1] || "")[sName] || "").replace(/#*?/g, "");
		    return decodeURIComponent(sVal);
		},

		/**
		 * 拼接object为url参数（url编码）
		 * @param  {Object} obj
		 * @return {String}
		 */
		joinParam: function(obj){
			if(obj == undefined){
				return "";
			}
			for(var key in obj){
				obj[key] = obj[key];
				// obj[key] = encodeURIComponent(obj[key]);
			}
			return $.param(obj);
		},

		/**
		 * 按名称读取cookie值
		 * @param  {String} name cookie名
		 * @return {void}
		 */
		getCookie: function(name){
			var cookieValue = "";
			var search = name + "=";
			if (document.cookie.length > 0) {
				offset = document.cookie.indexOf(search);
				if (offset != -1) {
					offset += search.length;
					end = document.cookie.indexOf(";", offset);
					if (end == -1) {
						end = document.cookie.length;
					}
					cookieValue = unescape(document.cookie.substring(offset, end))
				}
			}
			return cookieValue;
		},

		/**
		 * 写cookie
		 * @param  {String} name       cookie名
		 * @param  {All} value
		 * @param  {Integer} expiredays  过期时间（单位：天，可不传，默认1天）
		 * @return {void}
		 */
		setCookie: function(name, value, expiredays){
			expiredays = expiredays || 1;
			var exdate = new Date();
			exdate.setDate(exdate.getDate() + expiredays);
			// 使设置的有效时间正确。增加toGMTString()
			document.cookie = name + "=" + escape(value) + ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString()) + ";path=/";
		},

		/**
		 * 删除cookie
		 * @param  {String} name cookie名
		 * @return {void}
		 */
		removeCookie: function(name){
			return writeCookie(name, "", -1);
		},

		/**
		 * 占位符替换工厂。
		 *
		 * @method
		 * @param {String} sContent 含占位符的字符串。
		 * 	当要被替换的内容中含未知替换数据，则会保留当前点位符。
		 * @param {Object} oData 要替换的点位符数据，依据对象的键名与点位符一一对应，功能类似 KISSY.substitute。
		 * @return {String} 返回替换后的字符串。
		 */
		substitute: function(sContent, oData) {
			if (!oData) {
				return sContent;
			}

			for (var p in oData) {
				sContent = sContent.replace(new RegExp("\\{" + p + "\\}", "g"), oData[p]);
			}

			return sContent;
		},

		/**
		 * JSON转成字符串
		 * @param  {Object} json json对象
		 * @return {String}     转化后字符串
		 */
		stringify: function(json){
			var _this = this;
			if(json === null || json === undefined){
				return json;
			}
			if(JSON && JSON.stringify){
				return JSON.stringify(json);
			} else {
				var str = "";
				if(json.length != undefined) {//数组
					for(var i in json){
						var item = json[i],
							sType = typeof(item)
						;

						if(item === undefined){
							str += null + ",";
						} else if(sType === "object"){
							str += _this.stringify(item) + ",";
						} else if(sType === "string"){
							str += "\"" + item + "\"" + ",";
						} else if(sType === "function"){
							str += null + ",";
						} else{
							str += item + ",";
						}
					}
					if(str){
						str = str.substr(0, str.length - 1);
					}
					str = "[" + str + "]";
				} else {//对象
					for(var key in json){
						var item = json[key],
							sType = typeof(item),
							sFormat = '"{key}":{val},'
						;

						if(item === undefined || sType === "function"){
							continue;
						}
						if(sType === "object"){
							item = _this.stringify(item);
						} else if(sType === "string"){
							item = '"' + item + '"';
						}
						str += _this.substitute(sFormat, {key:key,val:item});
					}
					if(str){
						str = str.substr(0, str.length - 1);
					}
					str = "{" + str + "}";
				}
				return str;
			}
		},

		/**
		 * 字符串转成json对象
		 * @param  {String} str 	要转化的字符串
		 * @return {Object}
		 */
		parseJson: function(str){
			if(!str){
				return {};
			}
			if(JSON && JSON.parse){
				return JSON.parse(str);
			} else {
				try {
					return eval("a=" + str);
				} catch(ex) {
					console.log("格式转化出错");
					return {};
				}
			}
		},

		/**
		 * 非负数值型输入框输入验证
		 * @param  {String} parentQueryStr 父级节点筛选字符串
		 * @param  {String} childQueryStr  子级节点筛选字符串
		 * @return {void}
		 */
		formatNumberInput: function(parentQueryStr, childQueryStr){
				//数值型输入框keydown
		    $(parentQueryStr)
		        .on("keydown", childQueryStr, function(e){
		            var jThis = $(this),
		                sKeyCode = e.keyCode || e.which,
		                nVal = parseFloat(jThis.val()),
		                sMinNum = jThis.data("min"),
		                sMaxNum = jThis.data("max")
		            ;
		            if(isNaN(nVal)){
						nVal = sMaxNum ? parseInt(sMinNum) : 0;
		            }
		            jThis.attr("prev-val", jThis.val());

		            // if(sKeyCode == 40) { //向下
		            //    nVal--;
		            //    if(sMinNum != undefined && nVal < sMinNum >> 0){
		            //        nVal = sMinNum;
		            //    }
		            //    jThis
		            //        .attr("prev-val", nVal)
		            //        .val(nVal)
		            //    ;
		            // } else if(sKeyCode == 38) {//向上
		            //    nVal++;
		            //    if(sMaxNum != undefined && nVal > sMaxNum >> 0){
		            //        nVal = sMaxNum;
		            //    }
		            //    jThis
		            //        .attr("prev-val", nVal)
		            //        .val(nVal)
		            //    ;
		            // }
		        })
		        // .on("keyup", childQueryStr, function(e){
		        //     var jThis = $(this),
		        //         sKeyCode = e.keyCode || e.which,
		        //         nVal = parseFloat(jThis.val()),
		        //         sPrevVal = jThis.attr("prev-val"),
		        //         sMinNum = jThis.data("min"),
		        //         sMaxNum = jThis.data("max"),
		        //         nToFixed = (jThis.data("fixed") || jThis.attr("toFixed")) >> 0,
		        //         rReg = /^\d+(\.\d*)?$/
	         //        ;

	         //        if(!rReg.test(jThis.val())){//清空完事
	         //        	jThis.val("");
	         //        	return;
	         //        }
		        //     if(sPrevVal != nVal.toString()) {
			       //      if(isNaN(nVal)){
			       //          nVal = sMaxNum ? parseInt(sMinNum) : 0;
			       //      }
		        //         if(sMinNum != undefined && nVal < sMinNum){
		        //             nVal = sMinNum;
		        //         } else if (sMaxNum != undefined && nVal > sMaxNum){
		        //             nVal = sMaxNum;
		        //         }

		        //         if(nVal.toString() != jThis.val()) {
		        //             jThis.val(nVal).select();
		        //         }
		        //     }
		        // })
		        .on("blur", childQueryStr, function(){
		            var jThis = $(this),
		                nVal = parseFloat(jThis.val()),
						sMinNum = jThis.data("min"),
						sMaxNum = jThis.data("max"),
		                nToFixed = (jThis.data("fixed") || jThis.attr("toFixed")) >> 0,
		                rReg = /^\d+(\.\d*)?$/
                	;
                	if(!rReg.test(jThis.val())){
	                	jThis.val("");
	                	return;
	                }

		            nVal = Util.toFixed(nVal, nToFixed);
					if(sMinNum && nVal < sMinNum){
						nVal = Util.toFixed(sMinNum, nToFixed);
					} else if (sMaxNum && nVal > sMaxNum){
	                    nVal = Util.toFixed(sMaxNum, nToFixed);;
	                }
	                jThis.val(nVal);
		        })
		    ;
		}
	};

	window.Util = Obj;
})();