﻿namespace Buzz.Hybrid.Controllers
{
    using System.Web.Mvc;

    using DevTrends.MvcDonutCaching;

    using Umbraco.Core.Logging;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    public abstract class SurfaceRenderMvcController : SurfaceController, IRenderMvcController
    {
        #region Render MVC

        /// <summary>
        /// Checks to make sure the physical view file exists on disk.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        protected bool EnsurePhsyicalViewExists(string template)
        {
            var result = ViewEngines.Engines.FindView(this.ControllerContext, template, null);
            if (result.View == null)
            {
                LogHelper.Warn<SurfaceRenderMvcController>("No physical template file was found for template " + template);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns an ActionResult based on the template name found in the route values and the given model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// If the template found in the route values doesn't physically exist, then an empty ContentResult will be returned.
        /// </remarks>
        protected ActionResult CurrentTemplate<T>(T model)
        {
            var template = this.ControllerContext.RouteData.Values["action"].ToString();
            if (!this.EnsurePhsyicalViewExists(template))
            {
                return this.HttpNotFound();
            }
            return this.View(template, model);
        }

        /// <summary>
        /// The default action to render the front-end view.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ActionResult Index(RenderModel model)
        {
            return this.CurrentTemplate(model);
        }

        #endregion

        #region Override

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            //Log the exception.
            LogHelper.Error<SurfaceRenderMvcController>("Buzz Error: ", filterContext.Exception);

            //Clear the cache if an error occurs.
            var cacheManager = new OutputCacheManager();
            cacheManager.RemoveItems();

            //Show the view error.
            filterContext.Result = this.View("Error");
            filterContext.ExceptionHandled = true;
        }

        #endregion
    }
}