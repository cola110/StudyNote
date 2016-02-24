using cn.jpush.lib.Common.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.device
{
    public class DeviceClient : BaseDeviceClient // , ITest
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceClient()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenId">设备Id--极光的deviceId</param>
        public DeviceClient(string appKey, string masterSecret)
        {
            this.AppKey = appKey;
            this.MasterSecret = masterSecret;
            this.Authorization = GetAuthorization();
            this.AuthorHeader = GetHeaderAuthor();
            RequestUrl = string.Format("{0}/v3/devices", RequestUrl);
        }
        #endregion

        #region 通过设备号查询设备所拥有的tag和alias
        /// <summary>
        /// 通过设备号查询设备所拥有的tag和alias
        /// </summary>
        /// <param name="registrationId">极光注册设备Id</param>
        /// <returns></returns>
        public string QueryDeviceTagAliasById(string registrationId)
        {
            RequestUrl = string.Format("{0}/{1}", RequestUrl, registrationId);
            string result = HttpClient.HttpGet(RequestUrl, AuthorHeader);
            return result;
        }
        #endregion

        #region 更新用户设备别名分组(Alias/Tag)--Ps:该方法实现的功能有点大。最好能单独拆开做个细粒度的方法，但仍需保留该方法
        /// <summary>
        /// 更新用户设备别名分组(Alias/Tag)
        /// </summary>
        /// <param name="registrationId"></param>
        /// <param name="alias"></param>
        /// <param name="tagsToAdd"></param>
        /// <param name="tagsToRemove"></param>
        /// <returns></returns>
        public string UpdateDeviceAliasById(string registrationId, string alias, HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
        {
            JObject obj = new JObject();

            var rest = GetTagsObj(tagsToAdd, tagsToRemove);
            if (rest.Item1)
            {
                obj.Add("tags", rest.Item2);
            }

            if (null != alias)
            {
                obj.Add("alias", alias);
            }

            RequestUrl = string.Format("{0}/v3/devices/{1}", RequestUrl, registrationId);
            string returnStr = HttpClient.HttpPost(RequestUrl, obj.ToString(), AuthorHeader);
            return returnStr;
        }
        #endregion

        #region 获取添加|移除的设备数组列表
        /// <summary>
        /// 获取添加|移除的设备数组列表
        /// </summary>
        /// <param name="tagsToAdd"></param>
        /// <param name="tagsToRemove"></param>
        /// <returns></returns>
        private static Tuple<bool, JObject> GetTagsObj(HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
        {
            JObject tagObj = new JObject();
            bool isContains = false;

            if (tagsToAdd != null && tagsToAdd.Count > 0)
            {
                isContains = true;
                JArray tagsArray = JArray.FromObject(tagsToAdd);
                tagObj.Add("add", tagsArray);
            }

            if (tagsToRemove != null && tagsToRemove.Count > 0)
            {
                isContains = true;
                JArray tagsArray = JArray.FromObject(tagsToAdd);
                tagObj.Add("remove", tagsArray);
            }
            return new Tuple<bool, JObject>(isContains, tagObj);
        }
        #endregion

        #region 清空所有别名
        /// <summary>
        /// 清空设备的所有别名
        /// </summary>
        /// <param name="registrationId">极光响应的设备Id</param>
        /// <returns></returns>
        public string ClearAliasById(string registrationId)
        {
            return ClearAliasTagById(registrationId, clearAlias: true);
        }
        #endregion

        #region 清空设备的所有标签
        /// <summary>
        /// 清空所有标签
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public string ClearTagById(string registrationId)
        {
            return ClearAliasTagById(registrationId, clearTag: true);
        }
        #endregion

        #region 清空设备的所有别名和标签
        /// <summary>
        /// 清空设备的别名和标签
        /// </summary>
        /// <param name="registrationId">极光设备Id</param>
        /// <returns></returns>
        public string ClearAliasTagById(string registrationId)
        {
            return ClearAliasTagById(registrationId, true, true);
        }
        #endregion

        #region 清空设备的别名和标签
        /// <summary>
        /// 清空设备的别名和标签
        /// </summary>
        /// <param name="registrationId">极光设备号</param>
        /// <param name="clearAlias"></param>
        /// <param name="clearTag"></param>
        /// <returns></returns>
        private string ClearAliasTagById(string registrationId, bool clearAlias = false, bool clearTag = false)
        {
            JObject obj = new JObject();
            if (clearAlias)
            {
                obj.Add("alias", "");
            }
            if (clearTag)
            {
                obj.Add("tags", "");
            }

            RequestUrl = string.Format("{0}/{1}", RequestUrl, registrationId);
            string returnStr = HttpClient.HttpPost(RequestUrl, obj.ToString(), AuthorHeader);
            return returnStr;
        }
        #endregion
    }
}
