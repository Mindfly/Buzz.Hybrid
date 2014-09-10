namespace Buzz.Hybrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models;
    using Newtonsoft.Json;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;

    /// <summary>
    /// Extension methods for BrambleBerry.Base models
    /// </summary>
    public static class ContentExtensions
    {
        /// <summary>
        /// Checks if the model has a property and a value for the property
        /// </summary>
        /// <param name="model">The <see cref="RenderModel"/></param>
        /// <param name="propertyAlias">The Umbraco property alias on the model</param>
        /// <returns>A value indicating whether or not the property exists on the model and has a value</returns>
        public static bool WillWork(this RenderModel model, string propertyAlias)
        {
            return model.Content.WillWork(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property
        /// </summary>
        /// <param name="model">
        /// The <see cref="IPublishedContent"/> to inspect
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias on the <see cref="IPublishedContent"/>
        /// </param>
        /// <returns>
        /// A value indicating whether or not the property exists on the <see cref="IPublishedContent"/> and has a value
        /// </returns>
        public static bool WillWork(this IPublishedContent model, string propertyAlias)
        {
            return model.HasProperty(propertyAlias) && model.HasValue(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or an empty string
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias
        /// </param>
        /// <returns>
        /// The property value as a string or an empty string
        /// </returns>
        public static string GetSafeString(this RenderModel model, string propertyAlias)
        {
            return model.Content.GetSafeString(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or an empty string
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/> that should contain the property
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSafeString(this IPublishedContent content, string propertyAlias)
        {
            return content.GetSafeString(propertyAlias, string.Empty);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/> that should contain the property
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSafeString(this IPublishedContent content, string propertyAlias, string defaultValue)
        {
            return content.WillWork(propertyAlias) ? content.GetPropertyValue<string>(propertyAlias) : defaultValue;
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the Guid representation
        /// of the property or the default value
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public static Guid GetSafeGuid(this RenderModel model, string propertyAlias)
        {
            return model.Content.GetSafeGuid(propertyAlias, Guid.Empty);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the Guid representation
        /// of the property or the default value
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>.
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public static Guid GetSafeGuid(this IPublishedContent content, string propertyAlias)
        {
            return content.GetSafeGuid(propertyAlias, Guid.Empty);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the Guid representation
        /// of the property or the default value
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>.
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultValue">
        /// The default Value.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public static Guid GetSafeGuid(this IPublishedContent content, string propertyAlias, Guid defaultValue)
        {
            return content.WillWork(propertyAlias)
                ? new Guid(content.GetPropertyValue<string>(propertyAlias))
                : defaultValue;
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of 0
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetSafeIntenger(this RenderModel model, string propertyAlias)
        {
            return model.Content.GetSafeInteger(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of 0
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetSafeInteger(this IPublishedContent content, string propertyAlias)
        {
            return content.GetSafeInteger(propertyAlias, 0);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of 0
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultValue">
        /// The default Value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetSafeInteger(this IPublishedContent content, string propertyAlias, int defaultValue)
        {
            return content.WillWork(propertyAlias) ? content.GetPropertyValue<int>(propertyAlias) : defaultValue;
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of false
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetSafeBoolean(this RenderModel model, string propertyAlias)
        {
            return model.Content.GetSafeBoolean(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of false
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetSafeBoolean(this IPublishedContent content, string propertyAlias)
        {
            return content.GetSafeBoolean(propertyAlias, false);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the string representation
        /// of the property or the default value of false
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultValue">
        /// The default Value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetSafeBoolean(this IPublishedContent content, string propertyAlias, bool defaultValue)
        {
            var value = content.GetSafeString(propertyAlias).ToLowerInvariant();
            if (string.IsNullOrEmpty(value)) return defaultValue;
            return value == "yes" || value == "1" || value == "true";
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IHtmlString"/> representation
        /// of the property or an empty <see cref="IHtmlString"/>
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        public static IHtmlString GetSafeHtmlString(this RenderModel model, string propertyAlias)
        {
            return model.Content.GetSafeHtmlString(propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IHtmlString"/> representation
        /// of the property or an empty <see cref="IHtmlString"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/> that should contain the property
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        public static IHtmlString GetSafeHtmlString(this IPublishedContent content, string propertyAlias)
        {
            return content.GetSafeHtmlString(propertyAlias, string.Empty);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IHtmlString"/> representation
        /// of the property or the default <see cref="IHtmlString"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/> that should contain the property
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        public static IHtmlString GetSafeHtmlString(this IPublishedContent content, string propertyAlias, string defaultValue)
        {
            return content.WillWork(propertyAlias)
                       ? content.GetPropertyValue<IHtmlString>(propertyAlias)
                       : MvcHtmlString.Create(defaultValue);
        }

        #region IImage

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IImage"/> representation
        /// of the property or the default <see cref="IImage"/>
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IImage"/>.
        /// </returns>
        public static IImage GetSafeImage(this RenderModel model, UmbracoHelper umbraco, string propertyAlias)
        {
            return model.Content.GetSafeImage(umbraco, propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IImage"/> representation
        /// of the property or the default <see cref="IImage"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IImage"/>.
        /// </returns>
        public static IImage GetSafeImage(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias)
        {
            return content.GetSafeImage(umbraco, propertyAlias, null);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IImage"/> representation
        /// of the property or the default <see cref="IImage"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultImage">
        /// The default image.
        /// </param>
        /// <returns>
        /// The <see cref="IImage"/>.
        /// </returns>
        public static IImage GetSafeImage(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias, IImage defaultImage)
        {
            return content.GetSafeImages(umbraco, propertyAlias, defaultImage).FirstOrDefault();
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IImage"/> representation
        /// of the property or the default <see cref="IImage"/>s
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/> which has the media picker property
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias of the media picker
        /// </param>        
        /// <returns>
        /// A collection of <see cref="IImage"/>.
        /// </returns>
        public static IEnumerable<IImage> GetSafeImages(this RenderModel model, UmbracoHelper umbraco, string propertyAlias)
        {
            return model.Content.GetSafeImages(umbraco, propertyAlias, null);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IImage"/> representation
        /// of the property or the default <see cref="IImage"/>s
        /// </summary>
        /// <param name="content">
        /// The content which has the media picker property
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias of the media picker
        /// </param>
        /// <param name="defaultImage">
        /// A default image to return if there are no results
        /// </param>
        /// <returns>
        /// A collection of <see cref="IImage"/>.
        /// </returns>
        public static IEnumerable<IImage> GetSafeImages(this IPublishedContent content, UmbracoHelper umbraco,string propertyAlias, IImage defaultImage)
        {
            var mediaContent = content.GetSafeMntpPublishedContent(umbraco, propertyAlias, true).ToArray();

            return mediaContent.Any()
                ? mediaContent.Select(x => x.ToImage())
                : new List<IImage>() { defaultImage };
        }

        #endregion

        #region IMediaFile

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IMediaFile"/> representation
        /// of the property or the default <see cref="IMediaFile"/>
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IMediaFile"/>.
        /// </returns>
        public static IMediaFile GetSafeMediaFile(this RenderModel model, UmbracoHelper umbraco, string propertyAlias)
        {
            return model.Content.GetSafeMediaFile(umbraco, propertyAlias);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IMediaFile"/> representation
        /// of the property or the default <see cref="IMediaFile"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <returns>
        /// The <see cref="IMediaFile"/>.
        /// </returns>
        public static IMediaFile GetSafeMediaFile(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias)
        {
            return content.GetSafeMediaFile(umbraco, propertyAlias, null);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IMediaFile"/> representation
        /// of the property or the default <see cref="IMediaFile"/>
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property alias.
        /// </param>
        /// <param name="defaultImage">
        /// The default image.
        /// </param>
        /// <returns>
        /// The <see cref="IMediaFile"/>.
        /// </returns>
        public static IMediaFile GetSafeMediaFile(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias, IImage defaultImage)
        {
            return content.GetSafeMediaFiles(umbraco, propertyAlias, defaultImage).FirstOrDefault();
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IMediaFile"/> representation
        /// of the property or the default <see cref="IMediaFile"/>s
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/> which has the media picker property
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias of the media picker
        /// </param>        
        /// <returns>
        /// A collection of <see cref="IMediaFile"/>.
        /// </returns>
        public static IEnumerable<IMediaFile> GetSafeMediaFiles(this RenderModel model, UmbracoHelper umbraco, string propertyAlias)
        {
            return model.Content.GetSafeMediaFiles(umbraco, propertyAlias, null);
        }

        /// <summary>
        /// Checks if the model has a property and a value for the property and returns either the <see cref="IMediaFile"/> representation
        /// of the property or the default <see cref="IMediaFile"/>s
        /// </summary>
        /// <param name="content">
        /// The content which has the media picker property
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias of the media picker
        /// </param>
        /// <param name="defaultFile">
        /// The default File.
        /// </param>
        /// <returns>
        /// A collection of <see cref="IMediaFile"/>.
        /// </returns>
        public static IEnumerable<IMediaFile> GetSafeMediaFiles(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias, IImage defaultFile)
        {
            var mediaContent = content.GetSafeMntpPublishedContent(umbraco, propertyAlias, true).ToArray();

            return mediaContent.Any()
                ? mediaContent.Select(x => x.ToMediaFile())
                : new List<IMediaFile>() { defaultFile };
        }

        #endregion

        /// <summary>
        /// Gets a content Id from a content picker and renders it as <see cref="IPublishedContent"/>.
        /// </summary>
        /// <param name="model">
        /// The current <see cref="RenderModel"/>.
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/> from the content picker.
        /// </returns>
        public static IPublishedContent GetSafeContent(this RenderModel model, string propertyAlias, UmbracoHelper umbraco)
        {
            return model.Content.GetSafeContent(propertyAlias, umbraco);
        }

        /// <summary>
        /// Gets a content Id from a content picker and renders it as <see cref="IPublishedContent"/>.
        /// </summary>
        /// <param name="content">
        /// The current <see cref="IPublishedContent"/>.
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/> from the content picker.
        /// </returns>
        public static IPublishedContent GetSafeContent(this IPublishedContent content, string propertyAlias, UmbracoHelper umbraco)
        {
            return content.WillWork(propertyAlias)
                       ? umbraco.TypedContent(content.GetPropertyValue(propertyAlias))
                       : null;
        }
        
        #region MNTP

        /// <summary>
        /// Creates a collection of <see cref="IPublishedContent"/> of either content or media based on values saved by an Umbraco MultiNodeTree Picker DataType
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property Alias.
        /// </param>
        /// <param name="isMedia">
        /// True or false indicating whether or not the property is an Umbraco media item
        /// </param>
        /// <returns>
        /// The collection of <see cref="IPublishedContent"/>.
        /// </returns>
        public static IEnumerable<IPublishedContent> GetSafeMntpPublishedContent(this RenderModel model, UmbracoHelper umbraco, string propertyAlias, bool isMedia = false)
        {
            return model.Content.GetSafeMntpPublishedContent(umbraco, propertyAlias, isMedia);
        }

        /// <summary>
        /// Creates a collection of <see cref="IPublishedContent"/> of either content or media based on values saved by an Umbraco MultiNodeTree Picker DataType
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The Umbraco property Alias.
        /// </param>
        /// <param name="isMedia">
        /// True or false indicating whether or not the property is an Umbraco media item
        /// </param>
        /// <returns>
        /// The collection of <see cref="IPublishedContent"/>.
        /// </returns>
        public static IEnumerable<IPublishedContent> GetSafeMntpPublishedContent(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias, bool isMedia = false)
        {
            if (!content.WillWork(propertyAlias)) return new List<IPublishedContent>();

            var ids = content.GetPropertyValue<string>(propertyAlias).Split(',');

            return isMedia ? umbraco.TypedMedia(ids) : umbraco.TypedContent(ids);
        }

        #endregion

        #region Related Links

        /// <summary>
        /// Gets a collection of <see cref="ILink"/> from a related links picker.
        /// </summary>
        /// <param name="model">
        /// The <see cref="RenderModel"/> containing the related links picker.
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <returns>
        /// A collection of <see cref="ILink"/>.
        /// </returns>
        public static IEnumerable<ILink> GetSafeRelatedLinks(this RenderModel model, UmbracoHelper umbraco, string propertyAlias)
        {
            return model.Content.GetSafeRelatedLinks(umbraco, propertyAlias);
        }

        /// <summary>
        /// Gets a collection of <see cref="ILink"/> from a related links picker.
        /// </summary>
        /// <param name="content">
        /// The <see cref="IPublishedContent"/> containing the related links picker.
        /// </param>
        /// <param name="umbraco">
        /// The <see cref="UmbracoHelper"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <returns>
        /// A collection of <see cref="ILink"/>.
        /// </returns>
        public static IEnumerable<ILink> GetSafeRelatedLinks(this IPublishedContent content, UmbracoHelper umbraco, string propertyAlias)
        {
            var links = new List<ILink>();

            if (!content.WillWork(propertyAlias)) return links;

            var relatedLinks = JsonConvert.DeserializeObject<IEnumerable<RelatedLink>>(content.GetProperty(propertyAlias).Value.ToString());


            foreach (var relatedLink in relatedLinks)
            {
                var rl = new Link()
                {
                    Title = relatedLink.Title,
                    Target = relatedLink.NewWindow ? "_blank" : "_self"
                };

                // internal or external link
                if (relatedLink.IsInternal)
                {
                    var source = umbraco.TypedContent(relatedLink.Internal);
                    rl.Url = source.Url;
                }
                else
                {
                    rl.Url = relatedLink.Link;
                }

                links.Add(rl);
            }

            return links;
        }

        #endregion

        /// <summary>
        /// Creates a collection of <see cref="IImage"/> from a list of <see cref="IPublishedContent"/> (media)
        /// </summary>
        /// <param name="contents">
        /// The collection of <see cref="IPublishedContent"/>
        /// </param>
        /// <returns>
        /// The collection of <see cref="IImage"/>.
        /// </returns>
        public static IEnumerable<IImage> ToImages(this IEnumerable<IPublishedContent> contents)
        {
            return contents.ToList().Select(x => x.ToImage());
        }

        /// <summary>
        /// Utility extension to convert <see cref="IPublishedContent"/> to an <see cref="IImage"/>
        /// </summary>W
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <returns>
        /// The <see cref="IImage"/>.
        /// </returns>
        public static IImage ToImage(this IPublishedContent content)
        {
            return new Image()
            {
                Content = content,
                Id = content.Id,
                Bytes = content.GetSafeInteger("umbracoBytes", 0),
                Extension = content.GetSafeString("umbracoExtension"),
                Url = content.Url,
                Name = content.Name
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="IMediaFile"/> from a list of <see cref="IPublishedContent"/> (media)
        /// </summary>
        /// <param name="contents">
        /// The collection of <see cref="IPublishedContent"/>
        /// </param>
        /// <returns>
        /// The collection of <see cref="IMediaFile"/>.
        /// </returns>
        public static IEnumerable<IMediaFile> ToMediaFiles(this IEnumerable<IPublishedContent> contents)
        {
            return contents.ToList().Select(x => x.ToMediaFile());
        }

        /// <summary>
        /// Utility extension to convert <see cref="IPublishedContent"/> to an <see cref="IMediaFile"/>
        /// </summary>W
        /// <param name="content">
        /// The <see cref="IPublishedContent"/>
        /// </param>
        /// <returns>
        /// The <see cref="IMediaFile"/>.
        /// </returns>
        public static IMediaFile ToMediaFile(this IPublishedContent content)
        {
            return new MediaFile()
            {
                Content = content,
                Id = content.Id,
                Bytes = content.GetSafeInteger("umbracoBytes", 0),
                Extension = content.GetSafeString("umbracoExtension"),
                Url = content.Url,
                Name = content.Name
            };
        }
    }
}