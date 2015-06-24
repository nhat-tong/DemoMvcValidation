using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace NewValidationMvc.Helpers
{
    /// <summary>
    /// HtmlHelper extension for Boostrap DatePicker v3
    /// see ref: https://eonasdan.github.io/bootstrap-datetimepicker/
    /// </summary>
    public static class DatePickerExtensions
    {
        private const int DefaultWidth = 3;

        #region CustomDatePickerFor

        public static MvcHtmlString CustomDatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return CustomDatePickerFor(html, expression, htmlAttributes, DefaultWidth);
        }

        public static MvcHtmlString CustomDatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes, int width)
        {
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }
            htmlAttributes.Add("class", "form-control input-sm");

            TagBuilder s = new TagBuilder("span");
            s.AddCssClass("glyphicon glyphicon-calendar");

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("input-group-addon");
            span.InnerHtml = s.ToString(TagRenderMode.Normal);

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass(string.Format("input-group col-sm-{0} date datepicker", width));
            div.InnerHtml = html.TextBoxFor(expression, htmlAttributes) + span.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
        }

        #endregion
    }
}