using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace CML.Lib.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ObjectConvertExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：类型转换扩展类
    /// 创建标识：yjq 2017/7/12 18:26:43
    /// </summary>
    public static class ObjectConvertExtension
    {
        #region 将object安全的转为int类型

        /// <summary>
        /// 将object安全的转为int类型
        /// </summary>
        /// <param name="o">要转换的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>int值</returns>
        public static int ToSafeInt32(this object o, int defaultValue)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()) && Regex.IsMatch(o.ToString().Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                int num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (int.TryParse(s, out num))
                {
                    return num;
                }
            }
            return defaultValue;
        }

        #endregion 将object安全的转为int类型

        #region 将object安全的转为int?类型

        /// <summary>
        /// 将object安全的转为int?类型
        /// </summary>
        /// <param name="o">要转换的值</param>
        /// <returns>int?值</returns>
        public static int? ToSafeInt32(this object o)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                int num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (int.TryParse(s, out num))
                {
                    return num;
                }
            }
            return null;
        }

        #endregion 将object安全的转为int?类型

        public static long ToSafeInt64(this object o, int defaultValue)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                long num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (long.TryParse(s, out num))
                {
                    return num;
                }
            }
            return defaultValue;
        }

        public static long? ToSafeInt64(this object o)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                long num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (long.TryParse(s, out num))
                {
                    return num;
                }
            }
            return null;
        }

        public static float ToSafeFloat(this object o, float defValue)
        {
            if (o == null || string.IsNullOrWhiteSpace(o.ToString()))
            {
                return defValue;
            }
            float result = defValue;
            if ((o != null) && Regex.IsMatch(o.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                float.TryParse(o.ToString(), out result);
            }
            return result;
        }

        public static float? ToSafeFloat(this object o)
        {
            if (o != null && !string.IsNullOrWhiteSpace(o.ToString()) && Regex.IsMatch(o.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                float result;
                float.TryParse(o.ToString().Trim(), out result);
                return result;
            }
            return null;
        }

        public static decimal ToSafeDecimal(this object o, decimal defValue)
        {
            if (o == null || string.IsNullOrWhiteSpace(o.ToString()))
            {
                return defValue;
            }
            decimal result = defValue;
            if ((o != null) && Regex.IsMatch(o.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                decimal.TryParse(o.ToString(), out result);
            }
            return result;
        }


        public static decimal? ToSafeDecimal(this object o)
        {
            if (o != null && !string.IsNullOrWhiteSpace(o.ToString()) && Regex.IsMatch(o.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                decimal result;
                decimal.TryParse(o.ToString().Trim(), out result);
                return result;
            }
            return null;
        }

        public static bool ToSafeBool(this object o, bool defValue)
        {
            if (o != null)
            {
                if (string.Compare(o.ToString(), "1") == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString(), "0") == 0)
                {
                    return false;
                }
                if (string.Compare(o.ToString().Trim(), "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static bool? ToSafeBool(this object o)
        {
            if (o != null)
            {
                if (string.Compare(o.ToString(), "1") == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString(), "0") == 0)
                {
                    return false;
                }
                if (string.Compare(o.ToString().Trim(), "true", true) == 0 || o.ToString().Trim() == "1")
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "false", true) == 0 || o.ToString().Trim() == "0")
                {
                    return false;
                }
            }
            return null;
        }

        public static DateTime ToSafeDateTime(this object obj, DateTime defaultValue)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
                return defaultValue;
            DateTime result;
            return DateTime.TryParse(obj.ToString(), out result) ? result : defaultValue;
        }

        /// <summary>
        /// 当前日期下一天
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToNextDay(this object obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
                return null;
            return ((DateTime)obj).AddDays(1);
        }

        public static DateTime? ToSafeDateTime(this object obj, string format = "")
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
                return null;

            DateTime result;
            try
            {
                if (!DateTime.TryParse(obj.ToString(), out result))
                {
                    return null;
                }
                if (!string.IsNullOrWhiteSpace(format))
                {
                    result = DateTime.Parse(result.ToString(format));
                }
            }
            catch
            {
                return null;
            }

            return result;
        }

        #region object ToString转化

        /// <summary>
        /// object ToString转化
        /// </summary>
        /// <param name="dataColumn">object</param>
        /// <returns></returns>
        public static string ToSafeString(this object obj)
        {
            if (obj == null) return string.Empty;
            return obj.ToString();
        }

        /// <summary>
        /// object 转换为自定义格式的字符串
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <param name="format">自定义格式</param>
        /// <param name="defaultValue">object为null时的默认输出</param>
        /// <returns></returns>
        public static string ToFormatedString(this object obj, string format, string defaultValue = "")
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return defaultValue;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                return obj.ToString();
            }

            decimal tmpDecimal = 0;
            //优先尝试数字格式
            if (decimal.TryParse(obj.ToString(), out tmpDecimal))
            {
                return tmpDecimal.ToString(format, null);
            }
            else
            {
                var formattableObj = obj as IFormattable;
                if (formattableObj == null)
                {
                    return obj.ToString();
                }
                else
                {
                    return formattableObj.ToString(format, null);
                }
            }
        }

        /// <summary>
        /// object 转换为指定的隐藏字符串
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <param name="frontLen">前面保留显示位数</param>
        /// <param name="endLen">后面保留显示位数</param> 
        /// <param name="spaceModNum">每隔多少个字符增加一个空格，默认为4个字符</param> 
        /// <param name="hideFormatStr">隐藏符，默认为“*”号</param> 
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ToHideString(this object obj, int frontLen, int endLen, int spaceModNum = 4, string hideFormatStr = "*", string defaultValue = "")
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return defaultValue;
            }

            string targetStr = obj.ToString().Trim();
            if (targetStr.Length <= frontLen + endLen)
            {
                return targetStr;
            }
            else
            {
                StringBuilder strBuilder = new StringBuilder();
                var hideStr = (string.IsNullOrWhiteSpace(hideFormatStr) ? "*" : hideFormatStr);

                for (int i = 0; i < targetStr.Length; i++)
                {
                    if ((i < frontLen)  // 如果当前是前面需要保留的字符位置
                        || (i >= (targetStr.Length - endLen)))   //如果当前已经是后面需要保留的字符位置
                    {
                        if (i != 0 && i % spaceModNum == 0)
                        {
                            strBuilder.Append(" ");
                            strBuilder.Append(targetStr[i]);
                        }
                        else
                        {
                            strBuilder.Append(targetStr[i]);
                        }
                    }
                    else
                    {
                        if (i != 0 && i % spaceModNum == 0)
                        {
                            strBuilder.Append(" ");
                            strBuilder.Append(hideStr);
                        }
                        else
                        {
                            strBuilder.Append(hideStr);
                        }
                    }
                }
                return strBuilder.ToString();
            }
        }

        #endregion object ToString转化

        /// <summary>
        /// 获取列值
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="filedName"></param>
        /// <returns></returns>
        public static string FieldToString(this DataRow dr, string filedName)
        {
            if (dr == null) return string.Empty;
            if (dr[filedName] != null && dr[filedName].ToString() != "")
            {
                return dr[filedName].ToString();
            }
            return string.Empty;
        }


        /// <summary>
        /// 如果对象为空，则返回 "--"
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NullToBar(this object obj,string replaceString= "——")
        {
            if (obj == null) return replaceString;
            if (string.IsNullOrWhiteSpace(obj.ToString()))
            {
                return replaceString;
            }
            return obj.ToSafeString();
        }

    }
}