using Buzz.Hybrid.Models;

namespace Buzz.Hybrid.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Represents the link helper
    /// </summary>
    public class LinkHelper
    {
        #region Menu Methods

        /// <summary>
        /// Builds a <see cref="ILinkTier"/>
        /// </summary>
        /// <param name="tierItem">The <see cref="IPublishedContent"/> "tier" item (the parent tier)</param>
        /// <param name="current">The current <see cref="IPublishedContent"/> in the recursion</param>
        /// <param name="excludeDocumentTypes">A collection of document type aliases to exclude</param>
        /// <param name="tierLevel">The starting "tier" level. Note this is the Umbraco node level</param>
        /// <param name="maxLevel">The max "tier" level. Note this is the Umbraco node level</param>
        /// <param name="includeContentWithoutTemplate">True or false indicating whether or not to include content that does not have an associated template</param>
        /// <returns>the <see cref="ILinkTier"/></returns>
        public ILinkTier BuildLinkTier(IPublishedContent tierItem, IPublishedContent current, string[] excludeDocumentTypes = null, int tierLevel = 0, int maxLevel = 0, bool includeContentWithoutTemplate = false)
        {
            var active = current.Path.Contains(tierItem.Id.ToString(CultureInfo.InvariantCulture));

            if (current.Level == tierItem.Level) active = current.Id == tierItem.Id;

            var tier = new LinkTier()
            {
                ContentId = tierItem.Id,
                Title = tierItem.Name,
                Url = ContentHasTemplate(tierItem) ? tierItem.Url : string.Empty,
                CssClass = active ? "active" : string.Empty
            };

            if (excludeDocumentTypes == null) excludeDocumentTypes = new string[] { };

            if (tierLevel > maxLevel && maxLevel != 0) return tier;

            foreach (var item in tierItem.Children.ToList().Where(x => x.IsVisible() && (ContentHasTemplate(x) || includeContentWithoutTemplate) && !excludeDocumentTypes.Contains(x.DocumentTypeAlias)))
            {
                tier.Children.Add(BuildLinkTier(item, current, excludeDocumentTypes, item.Level, maxLevel));
            }

            return tier;
        }


        /// <summary>
        /// Constructs a breadcrumb menu
        /// </summary>
        /// <param name="stopLevel">The "top" level at which the recursion should quit</param>
        /// <param name="current">The current content</param>
        /// <returns>List of <see cref="Link" /></returns>
        public IEnumerable<ILink> BuildBreadCrumb(int stopLevel, IPublishedContent current)
        {
            var link = new Link()
            {
                Title = current.Name,
                Target = "_self",
                Url = current.Url,
                ElementId = current.Id.ToString(CultureInfo.InvariantCulture)
            };

            var links = new List<ILink>();
            
            if (current.Level != stopLevel && current.Parent != null)
            {
                links.AddRange(BuildBreadCrumb(stopLevel, current.Parent));
            }

            links.Add(link);
            return links;
        }

        #endregion

        /// <summary>
        /// Quick fix to all for checking if a content item has a template
        /// </summary>
        /// <param name="content">The <see cref="IPublishedContent"/></param>
        /// <returns>True or false indicating whether or not the content has an associated template selected</returns>
        private static bool ContentHasTemplate(IPublishedContent content)
        {
            try
            {
                var template = content.GetTemplateAlias();
                return !string.IsNullOrEmpty(template);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}