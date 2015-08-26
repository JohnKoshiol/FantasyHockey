using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FantasyHockey.Web.HtmlHelpers
{
    /// <summary>
    /// These extension methods are used to create dropdown lists for enums
    /// </summary>
    public static class DropDownHelpers
    {
        private static readonly Dictionary<int, string> Statuses = new Dictionary<int, string>
        {
            {0, "Available"},
            {1, "Unavailable"},
            {2, "Injured"}
        };

        public static readonly Dictionary<int, string> Positions = new Dictionary<int, string>
        {
            {0, "Center"},
            {1, "Left Wing"},
            {2, "Right Wing"},
            {3, "Left Defense"},
            {4, "Right Defense"},
            {5, "Goalie"}
        }; 

        public static MvcHtmlString StatusDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return html.DropDownListFor(expression, new SelectList(Statuses, "key", "value"), "-----", htmlAttributes);
        }

        public static MvcHtmlString PositionDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return html.DropDownListFor(expression, new SelectList(Positions, "key", "value"), "-----", htmlAttributes);
        }
    }
}