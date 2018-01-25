using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.Dependency.AutoFac
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：AutofacExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：AutofacExtension
    /// 创建标识：cml 2017/11/27 14:42:05
    /// </summary>
    public static class AutofacExtension
    {
        /// <summary>
        /// 设置生命周期
        /// </summary>
        /// <typeparam name="TImplementer"></typeparam>
        /// <typeparam name="TActivatorData"></typeparam>
        /// <typeparam name="TRegistrationStyle"></typeparam>
        /// <param name="registrationBuilder"></param>
        /// <param name="lifeStyle"></param>
        public static void SetLifeStyle<TImplementer, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TImplementer, TActivatorData, TRegistrationStyle> registrationBuilder, LifeStyle lifeStyle = LifeStyle.Singleton)
        {
            switch (lifeStyle)
            {
                case LifeStyle.Transient:
                    registrationBuilder.InstancePerDependency();
                    break;

                case LifeStyle.Singleton:
                    registrationBuilder.SingleInstance();
                    break;

                case LifeStyle.PerLifetimeScope:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;

                default:
                    break;
            }
        }
    }
}