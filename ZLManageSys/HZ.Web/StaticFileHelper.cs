using System;
using System.Web;
using System.Web.Mvc;

namespace HZ.Web
{
    /// <summary>
    ///  文件服务器分离，需要得到文件服务器上文件的地址
    /// </summary>
    public static class StaticFileHelper
    {
        /// <summary>
        /// 取得静态服务器的网址
        /// 如果是https网站，跨域调用静态资源需要欺骗浏览器如：http://content..../.png 改成 //content..../.png
        /// </summary>
        /// <returns></returns>
        private static string staticServiceUri = null;
        public static string GetStaticServiceUri()
        {
            //var uri = ServiceHelper.GetStaticServiceUri();
            //if (HttpContext.Current.Request.Url.Scheme == "https")
            //    uri = uri.Substring(5);
            //return uri;

            //使用本地图片，而不做资源分离，暂时取本地地址：
            if (staticServiceUri == null)
                staticServiceUri = "http://" + HttpContext.Current.Request.Url.Authority + "/";

            return staticServiceUri;
        }

        /// <summary>
        /// 得到静态文件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string StaticFile(this UrlHelper helper, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return "";
            }

            if (path.StartsWith("~"))
                return helper.Content(path);
            else
                return GetStaticServiceUri() + path;
        }        

        /// <summary>
        /// 得到文件服务器根网址
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string StaticFile(this UrlHelper helper)
        {
            return GetStaticServiceUri();
        }
    }
}
