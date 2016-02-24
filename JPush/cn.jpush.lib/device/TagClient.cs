/*
 * Tag：说明
 * 为安装了应用程序的用户，打上标签。其目的主要是方便开发者根据标签，来批量下发 Push 消息。
 * 可为每个用户打多个标签。
 * 请区别tag和alias
 */

using cn.jpush.lib.Common.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.device
{
    public class TagClient : BaseDeviceClient
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public TagClient()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenId">设备Id--极光的deviceId</param>
        public TagClient(string appKey, string masterSecret)
        {
            this.AppKey = appKey;
            this.MasterSecret = masterSecret;
            this.Authorization = GetAuthorization();
            this.AuthorHeader = GetHeaderAuthor();
            RequestUrl = string.Format("{0}/v3/tags", RequestUrl);
        }
        #endregion

        #region 设置标签与设备的绑定的关系
        /// <summary>
        /// 设置标签与设备的绑定的关系
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="addDeviceId"></param>
        /// <param name="removeDeviceId"></param>
        /// <returns></returns>
        public string SetDeviceIdTag(string tags, HashSet<string> addDeviceId,
            HashSet<string> removeDeviceId)
        {
            string requestUrl = string.Format("{0}/{1}", RequestUrl, tags);

            JObject obj = new JObject();
            var result = GetDeviceIdObj(addDeviceId, removeDeviceId);

            if (result.Item1)
            {
                obj.Add("registration_ids", result.Item2);
            }

            string returnStr = HttpClient.HttpPost(requestUrl, obj.ToString(), AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 判断设备与标签是否绑定
        /// <summary>
        /// 判断设备与标签是否绑定
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public string IsDeviceIdsBindWithTags(string tags, string deviceId)
        {
            string requestUrl = string.Format("{0}/{1}/registration_ids/{2}", RequestUrl, tags, deviceId);
            string returnStr = HttpClient.HttpGet(requestUrl, AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 获取所有标签信息
        /// <summary>
        /// 获取所有标签信息
        /// </summary>
        /// <returns></returns>
        public string GetTagList()
        {
            string returnStr = HttpClient.HttpGet(RequestUrl, AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 删除标签名称
        /// <summary>
        /// 删除标签与设备的绑定关系
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="platform">参数格式：android,ios</param>
        /// <returns></returns>
        public string DeleteTagByTagName(string tagName, string platform = "")
        {
            string requestUrl = string.Format("{0}/{1}", RequestUrl, tagName);
            if (!string.IsNullOrEmpty(platform))
            {
                requestUrl += "?platform=" + platform;
            }

            string returnStr = HttpClient.HttpDelete(requestUrl, AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 获取所需要更新标签的设备信息
        /// <summary>
        /// 获取所需要更新标签的设备信息
        /// </summary>
        /// <param name="addDeviceId"></param>
        /// <param name="removeDeviceId"></param>
        /// <returns></returns>
        private Tuple<bool, JObject> GetDeviceIdObj(HashSet<string> addDeviceId, HashSet<string> removeDeviceId)
        {
            var obj = new JObject();

            if (addDeviceId == null && removeDeviceId == null)
            {
                return new Tuple<bool, JObject>(false, null);
            }

            if (addDeviceId != null && addDeviceId.Count > 0)
            {
                JArray array = new JArray(addDeviceId);
                obj.Add("add", array);
            }

            if (removeDeviceId != null && removeDeviceId.Count > 0)
            {
                JArray array = new JArray(removeDeviceId);
                obj.Add("remove", array);
            }

            return new Tuple<bool, JObject>(true, obj);
        }
        #endregion
    }
}
