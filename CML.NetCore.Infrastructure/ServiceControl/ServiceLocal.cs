using System;
using System.Collections.Generic;
using System.Text;

namespace CML.Lib.ServiceControl
{
    /// <summary>
    /// IServiceProvider
    /// </summary>
    public static class ServiceLocal
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static IServiceProvider Instance { get; set; }
    }
}
