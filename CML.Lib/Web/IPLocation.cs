namespace CML.Lib.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IPLocation.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IP位置
    /// 创建标识：yjq 2017/6/19 12:09:36
    /// </summary>
    public class IPLocation
    {
        private string _country;//国家
        private string _area;//区域

        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public override string ToString()
        {
            return $"{Country}{Area}";
        }
    }
}