using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace KjNet.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ValidateCodeUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：验证码工具类
    /// 创建标识：yjq 2017/7/22 13:39:24
    /// </summary>
    public sealed class ValidateCodeUtil
    {
        private static readonly Random _Random = new Random();

        /// <summary>
        /// 初始化<see cref="ValidateCoder"/>类的新实例
        /// </summary>
        public ValidateCodeUtil()
        {
            FontNames = new List<string> { "Arial", "Batang", "Buxton Sketch", "David", "SketchFlow Print" };
            FontNamesForHanzi = new List<string> { "宋体", "幼圆", "楷体", "仿宋", "隶书", "黑体" };
            FontSize = 20;
            FontWidth = FontSize;
            BgColor = Color.FromArgb(240, 240, 240);
            RandomPointPercent = 0;
        }

        #region 属性

        /// <summary>
        /// 获取或设置 字体名称集合
        /// </summary>
        public List<string> FontNames { get; set; }

        /// <summary>
        /// 获取或设置 汉字字体名称集合
        /// </summary>
        public List<string> FontNamesForHanzi { get; set; }

        /// <summary>
        /// 获取或设置 字体大小
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 获取或设置 字体宽度
        /// </summary>
        public int FontWidth { get; set; }

        /// <summary>
        /// 获取或设置 图片高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 获取或设置 背景颜色
        /// </summary>
        public Color BgColor { get; set; }

        /// <summary>
        /// 获取或设置 是否有边框
        /// </summary>
        public bool HasBorder { get; set; }

        /// <summary>
        /// 获取或设置 是否随机位置
        /// </summary>
        public bool RandomPosition { get; set; }

        /// <summary>
        /// 获取或设置 是否随机字体颜色
        /// </summary>
        public bool RandomColor { get; set; }

        /// <summary>
        /// 获取或设置 是否随机倾斜字体
        /// </summary>
        public bool RandomItalic { get; set; }

        /// <summary>
        /// 获取或设置 随机干扰点百分比（百分数形式）
        /// </summary>
        public double RandomPointPercent { get; set; }

        /// <summary>
        /// 获取或设置 随机干扰线数量
        /// </summary>
        public int RandomLineCount { get; set; }

        #endregion 属性

        #region 公共方法

        /// <summary>
        /// 获取指定长度的验证码字符串
        /// </summary>
        public string GetCode(int length, ValidateCodeType codeType = ValidateCodeType.NumberAndLetter)
        {
            length.GreaterThan(0, "验证码长度必须大于0");

            switch (codeType)
            {
                case ValidateCodeType.Number:
                    return GetRandomNums(length);

                case ValidateCodeType.ChineseCharacter:
                    return GetRandomHanzis(length);

                default:
                    return GetRandomNumsAndLetters(length);
            }
        }

        /// <summary>
        /// 获取指定字符串的验证码图片
        /// </summary>
        public Bitmap CreateImage(string code, ValidateCodeType codeType)
        {
            code.NotNullAndNotEmptyWhiteSpace("验证码不能为空");

            int width = FontWidth * code.Length + FontWidth;
            int height = FontSize + FontSize / 2;
            const int flag = 255 / 2;
            bool isBgLight = (BgColor.R + BgColor.G + BgColor.B) / 3 > flag;
            Bitmap image = new Bitmap(width, height);
            Graphics grap = Graphics.FromImage(image);
            grap.Clear(BgColor);
            Brush brush = new SolidBrush(Color.FromArgb(255 - BgColor.R, 255 - BgColor.G, 255 - BgColor.B));
            int x, y = 3;
            if (HasBorder)
            {
                grap.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            }

            //绘制干扰线
            for (int i = 0; i < RandomLineCount; i++)
            {
                x = _Random.Next(image.Width);
                y = _Random.Next(image.Height);
                int m = _Random.Next(image.Width);
                int n = _Random.Next(image.Height);
                Color lineColor = !RandomColor
                    ? Color.FromArgb(90, 90, 90)
                    : isBgLight
                        ? Color.FromArgb(_Random.Next(130, 200), _Random.Next(130, 200), _Random.Next(130, 200))
                        : Color.FromArgb(_Random.Next(70, 150), _Random.Next(70, 150), _Random.Next(70, 150));
                Pen pen = new Pen(lineColor, 2);
                grap.DrawLine(pen, x, y, m, n);
            }

            //绘制干扰点
            for (int i = 0; i < (int)(image.Width * image.Height * RandomPointPercent / 100); i++)
            {
                x = _Random.Next(image.Width);
                y = _Random.Next(image.Height);
                Color pointColor = isBgLight
                    ? Color.FromArgb(_Random.Next(30, 80), _Random.Next(30, 80), _Random.Next(30, 80))
                    : Color.FromArgb(_Random.Next(150, 200), _Random.Next(150, 200), _Random.Next(150, 200));
                image.SetPixel(x, y, pointColor);
            }

            //绘制文字
            for (int i = 0; i < code.Length; i++)
            {
                x = FontWidth / 4 + FontWidth * i;
                if (RandomPosition)
                {
                    x = _Random.Next(FontWidth / 4) + FontWidth * i;
                    y = _Random.Next(image.Height / 5);
                }
                PointF point = new PointF(x, y);
                if (RandomColor)
                {
                    int r, g, b;
                    if (!isBgLight)
                    {
                        r = _Random.Next(255 - BgColor.R);
                        g = _Random.Next(255 - BgColor.G);
                        b = _Random.Next(255 - BgColor.B);
                        if ((r + g + b) / 3 < flag)
                        {
                            r = 255 - r;
                            g = 255 - g;
                            b = 255 - b;
                        }
                    }
                    else
                    {
                        r = _Random.Next(BgColor.R);
                        g = _Random.Next(BgColor.G);
                        b = _Random.Next(BgColor.B);
                        if ((r + g + b) / 3 > flag)
                        {
                            r = 255 - r;
                            g = 255 - g;
                            b = 255 - b;
                        }
                    }
                    brush = new SolidBrush(Color.FromArgb(r, g, b));
                }
                string fontName = codeType == ValidateCodeType.ChineseCharacter
                    ? FontNamesForHanzi[_Random.Next(FontNamesForHanzi.Count)]
                    : FontNames[_Random.Next(FontNames.Count)];
                Font font = new Font(fontName, FontSize, FontStyle.Bold);
                if (RandomItalic)
                {
                    grap.TranslateTransform(0, 0);
                    Matrix transform = grap.Transform;
                    transform.Shear(Convert.ToSingle(_Random.Next(2, 9) / 10d - 0.5), 0.001f);
                    grap.Transform = transform;
                }
                grap.DrawString(code.Substring(i, 1), font, brush, point);
                grap.ResetTransform();
            }

            return image;
        }

        /// <summary>
        /// 获取指定长度的验证码图片
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <param name="codeType">验证码类型</param>
        /// <returns>item1为验证码内容，item2为验证码字节数组</returns>
        public Tuple<string, byte[]> CreateImage(int length, ValidateCodeType codeType = ValidateCodeType.NumberAndLetter)
        {
            length.GreaterThan(0, "验证码长度必须大于0");
            string code;
            switch (codeType)
            {
                case ValidateCodeType.Number:
                    code = GetRandomNums(length);
                    break;

                case ValidateCodeType.ChineseCharacter:
                    code = GetRandomHanzis(length);
                    break;

                default:
                    code = GetRandomNumsAndLetters(length);
                    break;
            }
            if (code.Length > length)
            {
                code = code.Substring(0, length);
            }
            var codeImage = CreateImage(code, codeType);
            byte[] imageBytes = null;
            using (MemoryStream stream = new MemoryStream())
            {
                codeImage.Save(stream, ImageFormat.Png);
                imageBytes = stream.ToArray();
            }
            return Tuple.Create(code, imageBytes);
        }

        #endregion 公共方法

        #region 私有方法

        /// <summary>
        /// 获取数字验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns>验证码内容</returns>
        private static string GetRandomNums(int length)
        {
            int[] ints = new int[length];
            for (int i = 0; i < length; i++)
            {
                ints[i] = _Random.Next(0, 9);
            }
            return string.Join("", ints);
        }

        /// <summary>
        /// 获取数字和文字的验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns>验证码内容</returns>
        private static string GetRandomNumsAndLetters(int length)
        {
            const string allChar = "2,3,4,5,6,7,8,9," +
                "A,B,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,T,U,V,W,X,Y,Z," +
                "a,b,c,d,e,f,g,h,k,m,n,p,q,r,s,t,u,v,w,x,y,z";
            string[] allChars = allChar.Split(',');
            StringBuilder result = new StringBuilder();
            while (result.Length < length)
            {
                int index = _Random.Next(allChars.Length);
                string c = allChars[index];
                result.Append(c);
            }
            return result.ToString();
        }

        /// <summary>
        /// 获取汉字验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns>验证码内容</returns>
        private static string GetRandomHanzis(int length)
        {
            //汉字编码的组成元素，十六进制数
            string[] baseStrs = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f".Split(',');
            Encoding encoding = Encoding.GetEncoding("GB2312");
            string result = null;

            //每循环一次产生一个含两个元素的十六进制字节数组，并放入bytes数组中
            //汉字由四个区位码组成，1、2位作为字节数组的第一个元素，3、4位作为第二个元素
            for (int i = 0; i < length; i++)
            {
                Random rnd = _Random;
                int index1 = rnd.Next(11, 14);
                string str1 = baseStrs[index1];

                int index2 = index1 == 13 ? rnd.Next(0, 7) : rnd.Next(0, 16);
                string str2 = baseStrs[index2];

                int index3 = rnd.Next(10, 16);
                string str3 = baseStrs[index3];

                int index4 = index3 == 10 ? rnd.Next(1, 16) : (index3 == 15 ? rnd.Next(0, 15) : rnd.Next(0, 16));
                string str4 = baseStrs[index4];

                //定义两个字节变量存储产生的随机汉字区位码
                byte b1 = Convert.ToByte(str1 + str2, 16);
                byte b2 = Convert.ToByte(str3 + str4, 16);
                byte[] bs = { b1, b2 };

                result += encoding.GetString(bs);
            }
            return result;
        }

        #endregion 私有方法
    }

    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ValidateCodeType.cs
    /// 类属性：枚举
    /// 类功能描述：验证码类型
    /// 创建标识：yjq 2017/6/10 10:26:58
    /// </summary>
    public enum ValidateCodeType
    {
        /// <summary>
        /// 数字
        /// </summary>
        [Description("数字")]
        Number = 0,

        /// <summary>
        /// 数字和字母
        /// </summary>
        [Description("数字和字母")]
        NumberAndLetter = 1,

        /// <summary>
        /// 汉字
        /// </summary>
        [Description("汉字")]
        ChineseCharacter = 2
    }
}