namespace Buzz.Hybrid.Models
{
    /// <summary>
    /// Represents a hyperlink
    /// </summary>
    public class Link : ILink
    {
        #region ILink Members

        /// <summary>
        /// Gets or sets the Umbraco Content Id
        /// </summary>
        public int ContentId { get; set; }

        /// <summary>
        /// Gets or sets the content type alias.
        /// </summary>
        public string ContentTypeAlias { get; set; }

        /// <summary>
        /// Gets or sets the link title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the link target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the link element id
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// Gets or sets the link's CSS class
        /// </summary>
        public string CssClass { get; set; }

        #endregion
    }
}