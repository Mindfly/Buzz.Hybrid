namespace Buzz.Hybrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Html helper extensions.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// The enumerated box list for.
        /// </summary>
        /// <param name="html">
        /// The html.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="possibleValues">
        /// The possible values.
        /// </param>
        /// <param name="enumeratedElementType">
        /// The enumerated element type.
        /// </param>
        /// <typeparam name="T">
        /// The type of the list
        /// </typeparam>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        //// <remarks>
        //// http://stackoverflow.com/questions/15716564/generic-checkbox-list-view-model-in-mvc
        //// </remarks>
        public static IHtmlString EnumeratedBoxListFor<T>(
           this HtmlHelper<T> html,
           Expression<Func<T, IEnumerable<string>>> ex,
           IEnumerable<string> possibleValues,
           EnumeratedElementType enumeratedElementType = EnumeratedElementType.CheckboxList)
        {
            var metadata = ModelMetadata.FromLambdaExpression(ex, html.ViewData);
            var availableValues = (IEnumerable<string>)metadata.Model;
            var name = ExpressionHelper.GetExpressionText(ex);
            return html.EnumeratedBoxList(name, availableValues, possibleValues, enumeratedElementType);
        }

        /// <summary>
        /// Utility method to assist in list element generation
        /// </summary>
        /// <param name="html">
        /// The html.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="selectedValues">
        /// The selected values.
        /// </param>
        /// <param name="possibleValues">
        /// The possible values.
        /// </param>
        /// <param name="enumeratedElementType">
        /// The enumerated element type.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        private static IHtmlString EnumeratedBoxList(this HtmlHelper html, string name, IEnumerable<string> selectedValues, IEnumerable<string> possibleValues, EnumeratedElementType enumeratedElementType = EnumeratedElementType.CheckboxList)
        {
            var result = new StringBuilder();

            foreach (string current in possibleValues)
            {
                var label = new TagBuilder("label");
                var sb = new StringBuilder();

                var checkbox = new TagBuilder("input");
                if (enumeratedElementType == EnumeratedElementType.CheckboxList)
                {
                    checkbox.Attributes["type"] = "checkbox";
                }
                else
                {
                    checkbox.Attributes["type"] = "radio";
                }

                checkbox.Attributes["name"] = name;
                checkbox.Attributes["value"] = current;
                var enumerable = selectedValues as string[] ?? selectedValues.ToArray();
                var isChecked = enumerable.Contains(current);
                if (isChecked)
                {
                    checkbox.Attributes["checked"] = "checked";
                }

                sb.Append(checkbox.ToString());
                sb.Append(current);

                label.InnerHtml = sb.ToString();
                result.Append(label);
            }
            return new HtmlString(result.ToString());

        } 
    }
}