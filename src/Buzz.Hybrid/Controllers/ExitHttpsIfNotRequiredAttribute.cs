namespace Buzz.Hybrid.Controllers
{
 using System;
    using System.Web.Mvc;

    /// <summary>
    /// Designates that requests should only be made over non secured connections unless overriden by the <see cref="RequireHttpsAttribute"/>.
    /// </summary>
    /// <remarks>
    /// http://www.primaryobjects.com/CMS/Article140.aspx
    /// </remarks>
    public class ExitHttpsIfNotRequiredAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Responsible for redirecting to non https connections when the <see cref="RequireHttpsAttribute"/> is not present on a controller or method.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        /// <exception cref="NullReferenceException">
        /// Throws if the <see cref="AuthorizationContext"/> is null
        /// </exception>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null) throw new NullReferenceException("filterContext was null");

            // Return if the connection is already not secure or this is a child action request
            if (!filterContext.HttpContext.Request.IsSecureConnection || filterContext.IsChildAction) return;

            // Return if this is a form post as this should only be valid for get requests
            if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            // Return if a controller defines a RequireHttpsAttribute
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(RequireHttpsAttribute), true).Length > 0) return;
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(RequireHttpsAttribute), true).Length > 0)
                return;

            // Redirect to the non https version
            var url = "http://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
            filterContext.Result = new RedirectResult(url);
        }
    }
}