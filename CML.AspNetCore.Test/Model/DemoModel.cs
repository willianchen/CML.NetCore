using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CML.AspNetCore.Test.Model
{
    public class DemoModel
    {
        /// <summary>
        /// AppId
        /// </summary>
        [Required(ErrorMessage = "AppId不能为空")]
        public int AppId { get; set; }

        /// <summary>
        /// 授权信息
        /// </summary>
        [Required(ErrorMessage = "授权信息不能为空")]
        public string Token { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        [Required(ErrorMessage = "时间戳不能为空")]
        public long TimeTicket { get; set; }
    }
}
