using CML.Lib.Logging.Aspect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CML.AspNetCore.Test.Trace
{
    public class TraceTest
    {
        [TraceLog]
        public static string TestTrace(string traceStr)
        {
            return traceStr;
        }
    }
}
