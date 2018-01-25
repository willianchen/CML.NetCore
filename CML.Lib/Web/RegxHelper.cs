using System.Text;
using System.Text.RegularExpressions;
using CML.Lib.Extensions;

namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RegxHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RegxHelper
    /// 创建标识：cml 2017/11/1 10:46:35
    /// </summary>
    public sealed class RegxHelper
    {
        /// <summary>
        /// 获取中文字符串的首字母
        /// </summary>
        /// <param name="strText">中文字符串</param>
        /// <returns></returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                if (IsChina(strText.Substring(i, 1)))
                    myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>
        /// 获取单个中文的首字母
        /// </summary>
        /// <param name="cnChar">中文字符</param>
        /// <returns></returns>
        private static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };

                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25)
                    {
                        max = areacode[i + 1];
                    }
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(97 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }

        /// <summary>
        /// 检测字符是否为中文
        /// </summary>
        /// <param name="CString">单个字符</param>
        /// <returns></returns>
        public static bool IsChina(string CString)
        {
            Regex rx = new Regex("^[\u4e00-\u9fa5]$");
            if (rx.IsMatch(CString))
                return true;
            else
                return false;

        }

        /// <summary>
        /// 检测字符是否包含中文
        /// </summary>
        /// <param name="CString">字符串</param>
        /// <returns></returns>
        public static bool IsChinaStr(string CString)
        {
            bool IsC = false;
            for (int i = 0; i < CString.Length; i++)
            {
                Regex rx = new Regex("^[\u4e00-\u9fa5]$");
                if (rx.IsMatch(CString[i].ToString()))
                    IsC = true;
            }
            return IsC;
        }

        /// <summary>
        /// 获取字符串中包含的汉字数
        /// </summary>
        /// <param name="CString">单个字符</param>
        /// <returns></returns>
        public static int GetChinaCharactersNum(string CString)
        {
            if (string.IsNullOrWhiteSpace(CString))
            {
                return 0;
            }
            Regex rx = new Regex("[\u4e00-\u9fa5]");
            if (rx.IsMatch(CString))
            {
                return rx.Matches(CString).Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 正则验证输入字符串是否包含特殊字符(除去小括号)
        /// </summary>
        /// <param name="inputStr">输入字符串</param>
        /// <returns>true:包含特殊字符， false:不包含特殊字符或者为空</returns>
        public static bool ContainsSpecialCharactor(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return false;

            string pattern = "((?=[\x21-\x7e]+)[^A-Za-z0-9-\x28-\x29])";
            Regex reg = new Regex(pattern);
            if (reg.IsMatch(inputStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 正则验证输入字符串是否以特殊字符(或者中文标点符号)开始
        /// </summary>
        /// <param name="ignoreNum">是否忽略数字，true：是，false：否</param> 
        /// <param name="inputStr">输入字符串</param>
        /// <returns>true:包含特殊字符或者中文标点符号， false:不包含特殊字符或者中文标点符号或者为空</returns>
        public static bool StartWithSpecialCharactor(bool ignoreNum, string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return false;

            string pattern = string.Empty;
            if (ignoreNum)
            {
                pattern = @"^((?=[\x21-\x7e]+)[^A-Za-z0-9])|^[\（\）\《\》\｛\｝\【\】\—\；\，\。\、\“\”\<\>\！\？\：\￥\……\…\‘\’]";
            }
            else
            {
                pattern = @"^((?=[\x21-\x7e]+)[^A-Za-z])|^[\（\）\《\》\｛\｝\【\】\—\；\，\。\、\“\”\<\>\！\？\：\￥\……\…\‘\’]";
            }

            Regex reg = new Regex(pattern);
            if (reg.IsMatch(inputStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 正则验证输入字符串是否只包含字母(空格不是英文字符)
        /// </summary>
        /// <param name="ignoreNum">是否忽略数字，true：是，false：否</param> 
        /// <param name="inputStr">输入字符串</param>
        /// <returns>true:只包含字母， false:包含除字母以外的字符或者为空</returns>
        public static bool OnlyContainsEnglishCharactor(bool ignoreNum, string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return false;

            string pattern = string.Empty;
            if (ignoreNum)
            {
                pattern = "^[A-Za-z0-9]+$";
            }
            else
            {
                pattern = "^[A-Za-z]+$";
            }
            Regex reg = new Regex(pattern);
            if (reg.IsMatch(inputStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否身份证号码
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns>true:是正确的身份证号码，false：不是正确的身份证号码</returns>
        public static bool IsIDcard(string idCard)
        {
            if (string.IsNullOrWhiteSpace(idCard))
            {
                return false;
            }

            //15位/18位身份证号正则
            string pattern = @"^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$";

            return Regex.IsMatch(idCard, pattern);
        }

        /// <summary>
        /// 验证是否手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return false;
            }

            //手机号
            string pattern = @"^1[34578]\d{9}$";

            return Regex.IsMatch(mobile, pattern);
        }

        /// <summary>
        /// 正则验证输入字符串只包含字母或数字
        /// </summary>
        /// <param name="inputStr">输入字符串</param>
        /// <param name="minlength">限制字符串最小位数</param>
        /// <param name="maxlength">限制字符串最大位数</param>
        /// <returns></returns>
        public static bool IsLetterOrNumber(string inputStr, int minlength = -1, int maxlength = -1)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return false;
            if (minlength != -1 && maxlength != -1)
            {
                if (inputStr.Trim().Length < minlength || inputStr.Trim().Length > maxlength)
                {
                    return false;
                }
            }
            //手机号
            string pattern = @"^[a-zA-Z0-9]$";
            return Regex.IsMatch(inputStr, pattern);


        }

        /// <summary>
        /// 验证输入字符串位数是否在指定区域 一个汉字两个字符 
        /// </summary>
        /// <param name="inputStr">输入字符串</param>
        /// <param name="minlength">限制字符串最小位数</param>
        /// <param name="maxleng">限制字符串最大位数</param>
        /// <returns></returns>
        public static bool IsRegion(string inputStr, int minlength = -1, int maxlength = -1)
        {
            int inputStrCharactersNum = RegxHelper.GetChinaCharactersNum(inputStr);
            if (inputStr.IsNullOrEmptyWhiteSpace()
                || inputStr.Length < minlength || (inputStrCharactersNum + inputStr.Length) < minlength
                || inputStr.Length > maxlength || (inputStrCharactersNum + inputStr.Length) > maxlength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
