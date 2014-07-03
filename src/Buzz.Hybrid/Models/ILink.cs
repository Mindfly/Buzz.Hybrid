namespace Buzz.Hybrid.Models
{
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