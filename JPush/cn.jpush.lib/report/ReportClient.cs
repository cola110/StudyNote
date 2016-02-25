using cn.jpush.lib.Common.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.report
{
    public class ReportClient : Base
    {
        #region 构造函数
        public ReportClient()
            : base()
        {
            this._reqeustUrl = GetRequestUrl();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenId">设备Id--极光的deviceId</param>
        public ReportClient(string appKey, string masterSecret)
        {
            this.AppKey = appKey;
            this.MasterSecret = masterSecret;
            this.Authorization = GetAuthorization();
            this.AuthorHeader = GetHeaderAuthor();
            RequestUrl = string.Format("{0}/v3/received", GetRequestUrl());
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
            return ConfigurationManager.AppSettings["reportUrl"] ?? "";
        }
        #endregion

        #region 去获取该 msg_id 的送达统计数据
        /// <summary>
        /// 去获取该 msg_id 的送达统计数据
        /// </summary>
        /// <returns></returns>
        public string GetRecevicedCount(List<string> msg_ids)
        {
            string url = string.Format("{0}?msg_ids={1}", RequestUrl, string.Join(",", msg_ids));

            string returnStr = HttpClient.HttpGet(url, AuthorHeader);

            return returnStr;
        }
        #endregion
    }
}
