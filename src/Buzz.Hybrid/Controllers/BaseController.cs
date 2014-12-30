namespace Buzz.Hybrid.Controllers
{
    using System.Web.Configuration;
    using System.Web.Mvc;
    using Models;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Models;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// Represents the base surface controller
    /// </summary>
    [ExitHttpsIfNotRequiredAttribute]
    public abstract class BaseSurfaceController : SurfaceController, IRenderMvcController
    {
        /// <summary>
        /// The disable exception tracking.
        /// </summary>
        private static bool? _disableExceptionTracking;

        /// <summary>
        /// Gets a value indicating whether disable exception tracking.
        /// </summary>
        private static bool DisableExceptionTracking
        {
            get
            {
                if (!_disableExceptionTracking.HasValue)
                {
                    var configOption = WebConfigurationManager.AppSettings["Buzz.Hybrid.DisableExceptionHandling"];
                    
                    ////see if the option was specified
                    var isSet = !string.IsNullOrEmpty(configOption);
                    if (isSet)
                    {
                        _disableExceptionTracking = configOption.ToLower() == "true";
                    }
                    else
                    {
                        _disableExceptionTracking = false;
                    }
                }
                return _disableExceptionTracking.Value;
            }
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The default <see cref="ActionResult"/> which returns an Umbraco template (view)
        /// </returns>
        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        /// <summary>
        /// Returns the <see cref="BaseModel"/> used by every view
        /// </summary>
        /// <typeparam name="T">The type of the view model</typeparam>
        /// <returns>An instantiated model of type T</returns>
        protected virtual T GetModel<T>() where T : class,  IPublishedContent, new()
        {            
            return new T();
        }

        /// <summary>
        /// Checks to make sure the physical view file exists on disk.
        /// </summary>
        /// <param name="template">
        /// The Umbraco template.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool EnsurePhysicalViewExists(string template)
        {
            var result = ViewEngines.Engines.FindView(ControllerContext, template, null);
            
            if (result.View != null) return true;
            
            LogHelper.Warn<RenderMvcController>("No physical template file was found for template " + template);
            
            return false;
        }

        /// <summary>
        /// Returns an ActionResult based on the template name found in the route values and the given model.
        /// </summary>
        /// <typeparam name="T">The type of the view model</typeparam>
        /// <param name="model">The model</param>
        /// <returns>A view <see cref="ActionResult"/> with model</returns>
        /// <remarks>
        /// If the template found in the route values doesn't physically exist, then an empty ContentResult will be returned.
        /// </remarks>
        protected ActionResult CurrentTemplate<T>(T model)
        {
            var template = ControllerContext.RouteData.Values["action"].ToString();

            if (!EnsurePhysicalViewExists(template))
            {
                return Content(string.Empty);
            }

            return View(template, model);
        }       

        /// <summary>
        /// Overrides the OnException method
        /// </summary>
        /// <param name="filterContext">The <see cref="ExceptionContext"/></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (DisableExceptionTracking) return;
            
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            //// Log the exception.
            LogHelper.Error<BaseSurfaceController>(
                "An unhandled exception occurred in the application",  
                filterContext.Exception);

            //// Clear the cache if an error occurs.
            // TODO donut cache
            //// var cacheManager = new OutputCacheManager();
            //// cacheManager.RemoveItems();

            //// Show the view error.
            filterContext.Result = View("Error");

            filterContext.ExceptionHandled = true;
        }        
    }
}