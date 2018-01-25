using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML.Lib.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RandomUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：随机数工具类
    /// 创建标识：cml 2017/10/25 16:35:27
    /// </summary>
    public class RandomUtil
    {
        #region 生成纯数字盐值
        /// <summary>
        /// 随机生成指定位数数字,默认生成10位数
        /// </summary>
        /// <param name="digit">位数</param>
        /// <returns>随机字符串</returns>
        public static string GetNumberRandom(int digit = 10)
        {
            int num = 0;
            string randomStr = "";
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                num = ran.Next(0, 10);
                randomStr += num.ToString();
            }
            return randomStr;
        }
        #endregion

        #region 生成数字英文字符混合盐值
        /// <summary>
        /// 随机生成数字英文字符混合盐值,默认生成10位数
        /// </summary>
        /// <param name="digit">位数</param>
        /// <returns>随机字符串</returns>
        public static string GetEnglishCharacteAndNumberRandom(int digit = 10)
        {
            //随机种子
            string[] constant ={"0","1","R","S","T","U","V","W","X","2","3","4","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                "A","B","C","D","E","F","G","H","I","J","K","L","5","6","7","8","9","M","N","O","P","Q","Y","Z"};
            string str = string.Empty;
            string randomStr = "";
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                str = constant[ran.Next(62)];
                randomStr += str;
            }
            return randomStr;
        }
        #endregion
    }
}
