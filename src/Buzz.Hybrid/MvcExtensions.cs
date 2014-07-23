namespace Buzz.Hybrid
{
    using System;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.WebPages;

    public static class MvcExtensions
    {
        /// <summary>
        /// From http://haacked.com/archive/2011/03/05/defining-default-content-for-a-razor-layout-section.aspx/
        /// Allows section declarations like @this.RenderSection("Footer", @<span>This is the default!</span>) to apply inline defaults.
        /// </summary>
        /// <param name="webPage"></param>
        /// <param name="name"></param>
        /// <param name="defaultContents"></param>
        /// <returns></returns>
        public static HelperResult RenderSection(this WebPageBase webPage, string name, Func<dynamic, HelperResult> defaultContents)
        {
            if (webPage.IsSectionDefined(name))
            {
                return webPage.RenderSection(name);
            }
            return defaultContents(null);
        }

        public static string RenderViewToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}