using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.spider
{
    internal class HttpClient
    {
        #region HttpPost 实现
        /// <summary>
        /// HttpPost 实现
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求数据</param>
        /// <param name="header">设置请求头</param>
        /// <returns></returns>
        public static string HttpPost(string url, string data, NameValueCollection header)
        {
            return HttpPost(url, data, 100000, header);
        }
        #endregion

        #region HttpPost 实现
        /// <summary>
        /// HttpPost 实现
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求数据</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="header">设置请求头</param>
        /// <returns></returns>
        private static string HttpPost(string url, string data, int timeOut, NameValueCollection header = null)
        {
            string result = null;
            string error = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] reqData = null;
                if (!string.IsNullOrEmpty(data))
                {
                    reqData = Encoding.GetEncoding("UTF-8").GetBytes(data);
                    request.ContentLength = reqData.Length;
                }

                if (timeOut <= 10)
                {
                    timeOut = 100000;
                }
                request.Timeout = timeOut;

                if (header != null)
                {
                    request.Headers.Add(header);
                }

                if (reqData != null)
                {
                    using (var reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(reqData, 0, reqData.Length);
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var resStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = (HttpWebResponse)ex.Response;
                    HttpStatusCode code = response.StatusCode;
                    string statusDes = response.StatusDescription;
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = stream.ReadToEnd();
                    }
                    error = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result = error = ex.Message;
            }
            return result;
        }
        #endregion

        #region HttpGet 实现
        /// <summary>
        /// HttpGet 实现
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="header">请求头信息</param>
        /// <returns></returns>
        public static string HttpGet(string url, NameValueCollection header)
        {
            return GetHttpResponse(url, null, 100000, header);
        }
        #endregion

        #region HttpGet 实现
        /// <summary>
        /// HttpGet 实现
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="header">请求头信息</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            return GetHttpResponse(url, null, 100000, null);
        }
        #endregion

        #region HttpDelete 实现
        /// <summary>
        /// HttpDelete 实现
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="header">请求头信息</param>
        /// <returns></returns>
        public static string HttpDelete(string url, NameValueCollection header)
        {
            return GetHttpResponse(url, null, 100000, header, "DELETE");
        }
        #endregion

        #region HttpGet 实现
        /// <summary>
        /// HttpGet 实现
        /// </summary>
        /// <param name="url">请求url</param>
        /// <param name="data">请求数据</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="header">设置请求头</param>
        /// <returns></returns>
        private static string GetHttpResponse(string url, string data, int timeOut, NameValueCollection header = null, string method = "GET")
        {
            string result = null;
            string error = null;

            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    url = string.Format("{0}?{1}", url, data);
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.Accept = "application/json";

                if (timeOut <= 10)
                {
                    timeOut = 100000;
                }
                request.Timeout = timeOut;

                if (header != null)
                {
                    request.Headers.Add(header);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var resStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = (HttpWebResponse)ex.Response;
                    HttpStatusCode code = response.StatusCode;
                    string statusDes = response.StatusDescription;
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = stream.ReadToEnd();
                    }
                    error = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result = error = ex.Message;
            }
            return result;
        }
        #endregion
    }
}
