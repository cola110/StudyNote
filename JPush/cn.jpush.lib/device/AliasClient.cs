/*
 * Alias：说明
 * 为安装了应用程序的用户，取个别名来标识。以后给该用户 Push 消息时，就可以用此别名来指定。
 * 每个用户只能指定一个别名。
 * 同一个应用程序内，对不同的用户，建议取不同的别名。这样，尽可能根据别名来唯一确定用户。
 * 极光不限定一个别名只能指定一个用户。
 * 如果一个别名被指定到了多个用户，当给指定这个别名发消息时，服务器端API会同时给这多个用户发送消息。
 */

using cn.jpush.lib.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.device
{
    /// <summary>
    /// 
    /// </summary>
    public class AliasClient : DeviceClient
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public AliasClient()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenId">设备Id--极光的deviceId</param>
        public AliasClient(string appKey, string masterSecret)
        {
            this.AppKey = appKey;
            this.MasterSecret = masterSecret;
            this.Authorization = GetAuthorization();
            this.AuthorHeader = GetHeaderAuthor();
            RequestUrl = string.Format("{0}/v3/aliases", RequestUrl);
        }
        #endregion

        #region 查询当前别名下所有用户
        /// <summary>
        /// 查询当前别名下所有用户:最多输出10个用户
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="platform">平台信息 android,ios</param>
        /// <returns></returns>
        public string QueryDeviceIdInAlias(string alias, string platform)
        {
            string requestUrl = string.Format("{0}/{1}", RequestUrl, alias);
            if (!string.IsNullOrEmpty(platform))
            {
                requestUrl += "?platform=" + platform;
            }

            string returnStr = HttpClient.HttpGet(requestUrl, AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 删除别名
        /// <summary>
        /// 删除别名
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public string DeleleAliasName(string alias, string platform)
        {
            string requestUrl = string.Format("{0}/{1}", RequestUrl, alias);
            if (!string.IsNullOrEmpty(platform))
            {
                requestUrl += "?platform=" + platform;
            }

            string returnStr = HttpClient.HttpDelete(requestUrl, AuthorHeader);
            return returnStr;
        }
        #endregion

    }
}
