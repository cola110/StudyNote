using cn.jpush.lib.Common.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.lib
{
    public class Base
    {
        #region 字段属性
        private string _appKey;
        /// <summary>
        /// AppKey
        /// </summary>
        public string AppKey
        {
            get { return this._appKey; }
            set { this._appKey = value; }
        }

        private string _masterSecret;
        /// <summary>
        /// MasterSecret
        /// </summary>
        public string MasterSecret
        {
            get { return this._masterSecret; }
            set { this._masterSecret = value; }
        }

        private string _authorization;
        /// <summary>
        /// Authorization
        /// </summary>
        public string Authorization
        {
            get { return this._authorization; }
            set { this._authorization = value; }
        }


        private NameValueCollection _authorHeader;
        /// <summary>
        /// AuthorHeader
        /// </summary>
        public NameValueCollection AuthorHeader
        {
            get { return this._authorHeader; }
            set { this._authorHeader = value; }
        }
        #endregion

        #region 构造函数
        public Base()
        {
            this._appKey = GetAppKey();
            this._masterSecret = GetMasterSecret();
            this._authorization = GetAuthorization();
            this._authorHeader = GetHeaderAuthor();
        }
        #endregion

        #region 获取 AppKey
        /// <summary>
        /// 获取 AppKey
        /// </summary>
        /// <returns></returns>
        private string GetAppKey()
        {
            return ConfigurationManager.AppSettings["AppKey"] ?? "";
        }
        #endregion

        #region 获取 MasterSecret
        /// <summary>
        /// 获取 MasterSecret
        /// </summary>
        /// <returns></returns>
        private string GetMasterSecret()
        {
            return ConfigurationManager.AppSettings["MasterSecret"] ?? "";
        }
        #endregion

        #region 获取授权64位字串
        /// <summary>
        /// 获取授权64位字串
        /// </summary>
        /// <returns></returns>
        public string GetAuthorization()
        {
            string origin = this.AppKey + ":" + this.MasterSecret;
            return CommonMethod.GetBase64Encode(origin);
        }
        #endregion

        #region 获取请求header信息
        /// <summary>
        /// 获取请求header信息
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetHeaderAuthor()
        {
            NameValueCollection nameValue = new NameValueCollection();
            nameValue.Add("Authorization", "Basic " + Authorization);
            return nameValue;
        }
        #endregion
    }
}
