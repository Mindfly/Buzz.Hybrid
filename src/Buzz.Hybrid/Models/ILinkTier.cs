namespace Buzz.Hybrid.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines a link tier
    /// </summary>
    public interface ILinkTier : ILink
    {
        /// <summary>
        /// Gets or sets the children of the current tier
        /// </summary>
        List<ILinkTier> Children { get; set; }
    }
}
