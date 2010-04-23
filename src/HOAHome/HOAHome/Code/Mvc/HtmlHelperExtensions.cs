using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace HOAHome.Code.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString EditorCombo<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression) {
            return MvcHtmlString.Create(html.LabelFor(expression).ToHtmlString() 
                + html.EditorFor(expression).ToHtmlString() 
                + html.ValidationMessage(ExpressionHelper.GetExpressionText(expression), "*"));
        }
    }
}