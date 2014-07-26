namespace Buzz.Hybrid.Models
{
    using Umbraco.Core.Models;

    /// <summary>
    /// Represents a file.
    /// </summary>
    public class MediaFile : IMediaFile
    {
        /// <summary>
        /// Gets or sets the <see cref="IPublishedContent"/> that this file represents
        /// </summary>
        public IPublishedContent Content { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the bytes.
        /// </summary>
        public int Bytes { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the full url, including domain.
        /// </summary>
        public string AbsoluteUrl { get; set; }
    }
}
