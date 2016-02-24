
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.Common.Entities
{
    public enum Platform
    {
        /// <summary>
        /// 安卓平台
        /// </summary>
        [Description("android")]
        Android = 0,
        /// <summary>
        /// Ios平台
        /// </summary>
        [Description("ios")]
        Ios = 1,
        // [Description("wp")]
        // Wp = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("android,ios")]
        AndroidIos = 3,
        // AndroidWp = 4,
        // IosWp = 5,
        // AndroidIosWp = 6,
    }
}
