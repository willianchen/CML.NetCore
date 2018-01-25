using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreeWeb.DemoIoc
{
    public class Demo : IDemo
    {
        public int ReturnID(int retValue)
        {
            return retValue;
        }
    }
}
