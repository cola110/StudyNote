using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib.device
{
    public class BaseDeviceClient : Base
    {
        #region 构造函数
        public BaseDeviceClient()
            : base()
        {
            if (string.IsNullOrEmpty(this._reqeustUrl))
            {
                this._reqeustUrl = GetRequestUrl();
            }
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
            return ConfigurationManager.AppSettings["deviceUrl"] ?? "";
        }
        #endregion
    }

}
