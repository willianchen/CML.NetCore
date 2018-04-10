using System.Threading.Tasks;

namespace CML.Lib.Authorization
{
    /// <summary>
    /// Copyright (C) 2017 cml 版权所有。
    /// 类名：ILoginChecker.cs
    /// 类属性：接口
    /// 类功能描述：登录检查接口
    /// 创建标识：cml 2018/4/3 10:42:44
    /// </summary>
    public interface ILoginChecker
    {
        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        Task<bool> IsLogin();
        
    }
}
