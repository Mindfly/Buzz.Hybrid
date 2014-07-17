namespace Buzz.Hybrid.Models
{
    /// <summary>
    /// The related link.
    /// </summary>
    internal class RelatedLink
    {
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether new window.
        /// </summary>
        public bool NewWindow { get; set; }

        /// <summary>
        /// Gets or sets the Umbraco Content Id 
        /// </summary>
        public int Internal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is internal.
        /// </summary>
        public bool IsInternal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether edit.
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// Gets or sets the internal name.
        /// </summary>
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}