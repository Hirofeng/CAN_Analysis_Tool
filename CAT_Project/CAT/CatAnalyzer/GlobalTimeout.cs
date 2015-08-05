using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fengyuan.CatAnalyzer
{
    public enum PlatformType
    {
        SVW_MQB,
        SVW_PQ25,
        SVW_PQ35
    }
    public class GlobalTimeoutMonitor
    {
        public string Platform
        {
            get;
            set;
        }

        public string Channel
        {
            get;
            set;
        }
    }
}
