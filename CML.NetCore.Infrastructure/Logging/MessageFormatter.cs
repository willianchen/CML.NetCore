using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CML.Lib.Logging
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：MessageFormatter.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：MessageFormatter
    /// 创建标识：cml 2018/1/23 10:22:41
    /// </summary>
    public static class MessageFormatter
    {
        static readonly char DELIM_START = '{';

        /// <summary>
        ///     Performs single argument substitution for the 'messagePattern' passed as
        ///     parameter.
        ///     <p />
        ///     For example,
        ///     <p />
        ///     <pre>
        ///         MessageFormatter.Format(&quot;Hi {}.&quot;, &quot;there&quot;);
        ///     </pre>
        ///     <p />
        ///     will return the string "Hi there.".
        ///     <p />
        /// </summary>
        /// <param name="messagePattern">The message pattern which will be parsed and formatted</param>
        /// <param name="arg">The argument to be substituted in place of the formatting anchor</param>
        /// <returns>The formatted message</returns>
        public static FormattingTuple Format(string messagePattern, object arg) => ArrayFormat(messagePattern, new[] { arg });

        /// <summary>
        ///     Performs a two argument substitution for the 'messagePattern' passed as
        ///     parameter.
        ///     <p />
        ///     For example,
        ///     <p />
        ///     <pre>
        ///         MessageFormatter.Format(&quot;Hi {}. My name is {}.&quot;, &quot;Alice&quot;, &quot;Bob&quot;);
        ///     </pre>
        ///     <p />
        ///     will return the string "Hi Alice. My name is Bob.".
        /// </summary>
        /// <param name="messagePattern">The message pattern which will be parsed and formatted</param>
        /// <param name="argA">The argument to be substituted in place of the first formatting anchor</param>
        /// <param name="argB">The argument to be substituted in place of the second formatting anchor</param>
        /// <returns>The formatted message</returns>
        public static FormattingTuple Format(string messagePattern, object argA, object argB) => ArrayFormat(messagePattern, new[] { argA, argB });

        public static Exception GetThrowableCandidate(object[] argArray)
        {
            if (argArray == null || argArray.Length == 0)
            {
                return null;
            }

            return argArray[argArray.Length - 1] as Exception;
        }

        /// <summary>
        ///     Same principle as the {@link #Format(String, Object)} and
        ///     {@link #Format(String, Object, Object)} methods except that any number of
        ///     arguments can be passed in an array.
        /// </summary>
        /// <param name="messagePattern">The message pattern which will be parsed and formatted</param>
        /// <param name="argArray">An array of arguments to be substituted in place of formatting anchors</param>
        /// <returns>The formatted message</returns>
        public static FormattingTuple ArrayFormat(string messagePattern,
            object[] argArray)
        {
            Exception throwableCandidate = GetThrowableCandidate(argArray);

            if (messagePattern == null)
            {
                return new FormattingTuple(null, argArray, throwableCandidate);
            }

            if (argArray == null)
            {
                return new FormattingTuple(messagePattern);
            }

            Regex reg = new Regex("{/d}");
            Match match = reg.Match(messagePattern);
            int paraCount = match.Groups.Count;
            var sbuf = new StringBuilder();

            if (paraCount != argArray.Length)
            {
                sbuf.AppendFormat(messagePattern, FormattingTuple.GetTrimmedCopy(argArray));
                return new FormattingTuple(sbuf.ToString(), argArray, throwableCandidate);
            }
            else
            {
                sbuf.AppendFormat(messagePattern, argArray);
                return new FormattingTuple(sbuf.ToString(), argArray, null);
            }
        }
    }
}