namespace Buzz.Hybrid.Models
{
    using Umbraco.Core.Models;

    /// <summary>
    /// Defines an image.
    /// </summary>
    public interface IImage
    {
        /// <summary>
        /// Gets or sets the <see cref="IPublishedContent"/> that this image represents
        /// </summary>
        IPublishedContent Content { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the bytes.
        /// </summary>
        int Bytes { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        string Extension { get; set; }
    }
}