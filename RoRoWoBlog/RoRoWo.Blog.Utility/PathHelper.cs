using System;
using System.Web;

namespace RoRoWo.Blog.Utility {
    /// <summary>
    /// Static class with path related methods. Can be useful to combine url or to retrive the server root directory.
    /// </summary>
    public static class PathHelper {
        /// <summary>
        /// If the path is absolute is return as is, otherwise is combined with AppDomain.CurrentDomain.SetupInformation.ApplicationBase
        /// The path are always server relative path.
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>字符串（本地路径）</returns>
        public static string LocateServerPath(string path) {
            if (System.IO.Path.IsPathRooted(path) == false)
                path = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);

            return path;
        }


        /// <summary>
        /// 合并相对Url和参照Url
        /// </summary>
        /// <param name="baseUrl">参照Url</param>
        /// <param name="relativeUrl">相对Url</param>
        /// <returns>字符串（Url）</returns>
        public static string CombineUrl(string baseUrl, string relativeUrl) {
            if (relativeUrl.Length == 0 || relativeUrl[0] != '/')
                relativeUrl = '/' + relativeUrl;

            if (baseUrl.Length > 0 && baseUrl[baseUrl.Length - 1] == '/')
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);

            return baseUrl + relativeUrl;
        }

        /// <summary>
        /// Get the web site application root path. Combine the request.Url.GetLeftPart(UriPartial.Authority) with request.ApplicationPath
        /// </summary>
        /// <returns>字符串（Url）</returns>
        public static string GetWebAppUrl() {
            HttpRequest request = HttpContext.Current.Request;

            return CombineUrl(request.Url.GetLeftPart(UriPartial.Authority), request.ApplicationPath);
        }
    }
}
