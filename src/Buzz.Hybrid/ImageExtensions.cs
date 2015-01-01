namespace Buzz.Hybrid
{
    using System.Diagnostics.CodeAnalysis;

    using Buzz.Hybrid.Models;

    using Umbraco.Core;
    using Umbraco.Web;
    using Umbraco.Web.Models;

    /// <summary>
    /// The media extensions.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Gets the ImageProcessor Url by the crop alias (from the "umbracoFile" property alias) on the <see cref="IImage"/>
        /// </summary>
        /// <param name="image">
        /// The <see cref="IImage"/>
        /// </param>
        /// <param name="cropAlias">
        /// The crop alias.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> Url
        /// </returns>
        public static string GetCropUrl(this IImage image, string cropAlias)
        {
            return image.Content.GetCropUrl(cropAlias);
        }

        /// <summary>
        /// Gets the ImageProcessor Url by the crop alias (from the "umbracoFile" property alias) on the <see cref="IImage"/>
        /// </summary>
        /// <param name="image">
        /// The <see cref="IImage"/>
        /// </param>
        /// <param name="propertyAlias">
        /// The property Alias or the Cropper data type
        /// </param>
        /// <param name="cropAlias">
        /// The crop alias.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> Url
        /// </returns>
        public static string GetCropUrl(this IImage image, string propertyAlias, string cropAlias)
        {
            return image.Content.GetCropUrl(propertyAlias, cropAlias);
        }

        /// <summary>
        /// Gets the ImageProcessor Url from the IPublishedContent item.
        /// </summary>
        /// <param name="image">The <see cref="IImage"/></param>
        /// <param name="width">
        /// The width of the output image.
        /// </param>
        /// <param name="height">
        /// The height of the output image.
        /// </param>
        /// <param name="propertyAlias">
        /// Property alias of the property containing the Json data.
        /// </param>
        /// <param name="cropAlias">
        /// The crop alias.
        /// </param>
        /// <param name="quality">
        /// Quality percentage of the output image.
        /// </param>
        /// <param name="imageCropMode">
        /// The image crop mode.
        /// </param>
        /// <param name="imageCropAnchor">
        /// The image crop anchor.
        /// </param>
        /// <param name="preferFocalPoint">
        /// Use focal point, to generate an output image using the focal point instead of the predefined crop
        /// </param>
        /// <param name="useCropDimensions">
        /// Use crop dimensions to have the output image sized according to the predefined crop sizes, this will override the width and height parameters>.
        /// </param>
        /// <param name="cacheBuster">
        /// Add a serialised date of the last edit of the item to ensure client cache refresh when updated
        /// </param>
        /// <param name="furtherOptions">
        /// The further options.
        /// </param>
        /// <param name="ratioMode">
        /// Use a dimension as a ratio
        /// </param>  
        /// <param name="upScale">
        /// If the image should be upscaled to requested dimensions
        /// </param>         
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public static string GetCropUrl(
            this IImage image, 
            int? width = null, 
            int? height = null,
            string propertyAlias = Constants.Conventions.Media.File, 
            string cropAlias = null, 
            int? quality = null,
            ImageCropMode? imageCropMode = null, 
            ImageCropAnchor? imageCropAnchor = null, 
            bool preferFocalPoint = false,
            bool useCropDimensions = false, 
            bool cacheBuster = true, 
            string furtherOptions = null,
            ImageCropRatioMode? ratioMode = null, 
            bool upScale = true)
        {
            return image.Content.GetCropUrl(width, height, propertyAlias, cropAlias, quality, imageCropMode, imageCropAnchor, preferFocalPoint, useCropDimensions, cacheBuster, furtherOptions, ratioMode, upScale);
        }
    }
}