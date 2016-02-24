using cn.jpush.lib.Common.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.push
{
    public class PushClient : Base
    {
        #region 构造函数
        public PushClient()
        {
            if (string.IsNullOrEmpty(this._reqeustUrl))
            {
                this._reqeustUrl = GetRequestUrl();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenId">设备Id--极光的deviceId</param>
        public PushClient(string appKey, string masterSecret)
        {
            this.AppKey = appKey;
            this.MasterSecret = masterSecret;
            this.Authorization = GetAuthorization();
            this.AuthorHeader = GetHeaderAuthor();
            RequestUrl = string.Format("{0}/v3/push", RequestUrl);
        }

        #endregion

        #region 请求地址
        /// <summary>
        /// 请求地址
        /// </summary>
        private string _reqeustUrl;
        /// <summary>
        /// 接口地址
        /// </summary>
        public string RequestUrl
        {
            get { return this._reqeustUrl; }
            set { this._reqeustUrl = value; }
        }
        #endregion

        #region 获取请求地址
        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns></returns>
        private string GetRequestUrl()
        {
            return ConfigurationManager.AppSettings["pushUrl"] ?? "";
        }
        #endregion

        public string ValidataPush()
        {
            string url = "https://api.jpush.cn/v3/push/validate";



            string returnStr = HttpClient.HttpPost(url, null, AuthorHeader);

            return returnStr;
        }
    }
}
