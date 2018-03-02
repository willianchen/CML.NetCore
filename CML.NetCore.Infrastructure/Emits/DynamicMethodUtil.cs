using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CML.Lib.Emits
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：DynamicMethodUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：DynamicMethodUtil
    /// 创建标识：cml 2018/2/28 13:54:52
    /// </summary>
    public static class DynamicMethodUtil
    {
        #region 根据类型获取将object转为ParamList的方法

        private static ConcurrentDictionary<RuntimeTypeHandle, ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod>> _ObjectToParamListMethodCache = new ConcurrentDictionary<RuntimeTypeHandle, ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod>>();

        /// <summary>
        /// 根据类型获取将object转为ParamList的方法
        /// </summary>
        /// <typeparam name="TParam">DbParameter类型</typeparam>
        /// <param name="objType">object的类型</param>
        /// <returns>将object转为ParamList的方法</returns>
        public static DynamicMethod GetObjectToParamListMethod<TParam>(Type objType)
        {
            ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod> objectToParamListMethod;
            _ObjectToParamListMethodCache.TryGetValue(objType.TypeHandle, out objectToParamListMethod);
            if (objectToParamListMethod != null)
            {
                DynamicMethod method;
                objectToParamListMethod.TryGetValue(typeof(TParam).TypeHandle, out method);
                if (method == null)
                {
                    method = EmitUtil.CreateObjectToParamListMethod<TParam>(objType);
                    objectToParamListMethod.TryAdd(typeof(TParam).TypeHandle, method);
                    _ObjectToParamListMethodCache[objType.TypeHandle] = objectToParamListMethod;
                }
                return method;
            }
            else
            {
                objectToParamListMethod = new ConcurrentDictionary<RuntimeTypeHandle, DynamicMethod>();
                DynamicMethod method = EmitUtil.CreateObjectToParamListMethod<TParam>(objType);
                objectToParamListMethod.TryAdd(typeof(TParam).TypeHandle, method);
                _ObjectToParamListMethodCache[objType.TypeHandle] = objectToParamListMethod;
                return method;
            }
        }

        #endregion 根据类型获取将object转为ParamList的方法
    }
}
