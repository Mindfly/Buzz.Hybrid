namespace Buzz.Hybrid.Events
{
    using System;
    using Models;

    /// <summary>
    /// The link tier event args.
    /// </summary>
    public class AddingLinkTierEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddingLinkTierEventArgs"/> class.
        /// </summary>
        /// <param name="root">
        /// The root (base link tier)
        /// </param>
        /// <param name="adding">
        /// The modified value - generally an addition or 
        /// </param>
        public AddingLinkTierEventArgs(ILinkTier root, ILinkTier adding)
        {
            Root = root;
            Adding = adding;
        }

        /// <summary>
        /// Gets or sets the root link tier.
        /// </summary>
        public ILinkTier Root { get; set; }

        /// <summary>
        /// Gets or sets the adding.
        /// </summary>
        public ILinkTier Adding { get; set; }
    }
}