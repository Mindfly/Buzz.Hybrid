namespace Buzz.Hybrid
{
    using Umbraco.Core;
    using Umbraco.Core.Models;
    using Umbraco.Core.Persistence;
    using Umbraco.Core.Services;
    using Umbraco.Web;

    public class BaseClass
    {
        protected static Database Database
        {
            get { return ApplicationContext.Current.DatabaseContext.Database; }
        }

        protected static ServiceContext Services
        {
            get { return ApplicationContext.Current.Services; }
        }

        protected static IPublishedContent CurrentPage
        {
            get { return UmbracoContext.Current.PublishedContentRequest.PublishedContent; }
        }

        protected static UmbracoHelper Umbraco
        {
            get { return new UmbracoHelper(UmbracoContext.Current); }
        }
    }
}