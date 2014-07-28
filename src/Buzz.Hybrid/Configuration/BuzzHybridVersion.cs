namespace Buzz.Hybrid.Configuration
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The Buzz Hybrid version.
    /// </summary>
    public class BuzzHybridVersion
    {
        /// <summary>
        /// The version.
        /// </summary>
        private static readonly Version Version = new Version("1.3.11");

        /// <summary>
        /// Gets the current version of Buzz Hybrid.
        /// Version class with the specified major, minor, build (Patch), and revision numbers.
        /// </summary>
        public static Version Current
        {
            get { return Version; }
        }

        /// <summary>
        /// Gets the version comment (like beta or RC).
        /// </summary>
        /// <value>The version comment.</value>
        public static string CurrentComment
        {
            get { return "0"; }
        }

        //// Get the version of the umbraco.dll by looking at a class in that dll
        //// Had to do it like this due to medium trust issues, see: http://haacked.com/archive/2010/11/04/assembly-location-and-medium-trust.aspx

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public static string AssemblyVersion
        {
            get { return new AssemblyName(typeof(BuzzHybridVersion).Assembly.FullName).Version.ToString(); }
        }
    }
}
