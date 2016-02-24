using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.Common.Util
{
    internal class CommonMethod
    {
        #region base64格式字符串
        #region 生成base64格式字符串
        /// <summary>
        /// 生成base64格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBase64Decode(string str)
        {
            var bytes = Convert.FromBase64String(str);
            return Encoding.Default.GetString(bytes);
        }
        #endregion
        #region 生成base64格式字符串
        /// <summary>
        /// 生成base64格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBase64Encode(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);

            return Convert.ToBase64String(bytes);
        }
        #endregion
        #endregion
    }
}
