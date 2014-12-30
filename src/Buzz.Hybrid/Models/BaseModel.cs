namespace Buzz.Hybrid.Models
{
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;

    using Umbraco.Core.Models;
    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;
    using Umbraco.Web.Models;

    /// <summary>
    /// Represents the BaseModel Class
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class BaseModel<T> : PublishedContentWrapped where T : IPublishedContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        public BaseModel()
            : base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
        {
        }

        public BaseModel(T content) : base(content) { }


        /// <summary>
        /// Gets or sets the full url, including domain.
        /// </summary>
        public string AbsoluteUrl
        {
            get { return this.GetSafeString(Content.UrlAbsolute()); }
        }

        /// <summary>
        /// Gets a value indicating whether or not this page is to be displayed in the navigation
        /// </summary>
        /// <remarks>
        /// This is umbracoNaviHide
        /// </remarks>
        public bool HiddenInNavigation
        {
            get { return !Content.IsVisible(); }
        }
    }
}