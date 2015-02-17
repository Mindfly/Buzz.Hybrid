namespace Buzz.Hybrid.Models
{
    using Umbraco.Core.Models;

    /// <summary>
    /// Defines a link
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// Gets or sets Umbraco content id if applicable
        /// </summary>
        int ContentId { get; set; }

        /// <summary>
        /// Gets or sets Umbraco content node, if applicable
        /// </summary>
        IPublishedContent ContentNode { get; set; }

        /// <summary>
        /// Gets or sets the content type alias.
        /// </summary>
        string ContentTypeAlias { get; set; }

        /// <summary>
        /// Gets or sets title of the link
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets Url of the link
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets Target of the link
        /// </summary>
        string Target { get; set; }

        /// <summary>
        /// Gets or sets id attribute for the link
        /// </summary>
        string ElementId { get; set; }

        /// <summary>
        /// Gets or sets CSS class of the link
        /// </summary>
        string CssClass { get; set; }
    }
}