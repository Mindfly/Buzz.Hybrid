namespace Buzz.Hybrid
{
    using System;
    using System.Web;
    using Models;

    /// <summary>
    /// Extension methods that require a current HttpContext
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Gets the absolute url for a link Url.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The absolute url.
        /// </returns>
        public static string AbsoluteUrl(this ILink link)
        {
            return link.AbsoluteUrl(string.Empty);
        }

        /// <summary>
        /// Gets the absolute url for a link Url.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="queryString">The query string to be added to the url</param>
        /// <returns>
        /// The absolute url.
        /// </returns>
        public static string AbsoluteUrl(this ILink link, string queryString)
        {
            return MakeAbsolutUrl(link.Url, queryString);
        }

        /// <summary>
        /// Gets the absolute url for a media file Url.
        /// </summary>
        /// <param name="mediaFile">
        /// The media file.
        /// </param>
        /// <returns>
        /// The absolute url.
        /// </returns>
        public static string AbsoluteUrl(this IMediaFile mediaFile)
        {
            return mediaFile.AbsoluteUrl(string.Empty);
        }

        /// <summary>
        /// Gets the absolute url for a media file Url.
        /// </summary>
        /// <param name="mediaFile">
        /// The media file.
        /// </param>
        /// <param name="queryString">
        /// The query string to be added to the url
        /// </param>
        /// <returns>
        /// The absolute url.
        /// </returns>
        public static string AbsoluteUrl(this IMediaFile mediaFile, string queryString)
        {
            return MakeAbsolutUrl(mediaFile.Url, queryString);
        }

        /// <summary>
        /// Gets the absolute absolut url.
        /// </summary>
        /// <param name="relativeUrl">
        /// The relative url.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The absolute url.
        /// </returns>
        /// <exception cref="NullReferenceException">
        /// Throws a null reference exception if the HttpContext is null.
        /// </exception>
        private static string MakeAbsolutUrl(string relativeUrl, string queryString)
        {
            if (relativeUrl.StartsWith("http")) return relativeUrl;

            var context = HttpContext.Current;
            if (context == null) throw new NullReferenceException("The HttpContext is null");

            var protocol = context.Request.IsSecureConnection ? "https://" : "http://";
            var host = context.Request.ServerVariables["SERVER_NAME"];
            var port = context.Request.ServerVariables["SERVER_PORT"];
            port = port == "80" ? string.Empty : string.Format(":{0}", port);

            if (!relativeUrl.StartsWith("/")) relativeUrl = string.Format("/{0}", relativeUrl);
            if (!queryString.StartsWith("?")) queryString = string.Format("?{0}", queryString);

            return string.Format("{0}{1}{2}{3}{4}", protocol, host, port, relativeUrl, queryString);
        } 
    }
}