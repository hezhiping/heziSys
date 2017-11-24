using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZ.Cache.Factory
{
    public class Cache
    {
        public static Interface.ICache CreateInstance()
        {
            return new HZ.Cache.InProc.Cache();
        }
    }
}
