namespace Buzz.Hybrid.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a link tier
    /// </summary>
    public class LinkTier : Link, ILinkTier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTier"/> class.
        /// </summary>
        public LinkTier()
        {
            this.Children = new List<ILinkTier>();
        }

        /// <summary>
        /// Gets or sets the children <see cref="ILinkTier"/>
        /// </summary>
        public List<ILinkTier> Children { get; set; }
    }
}