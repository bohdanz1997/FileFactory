using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FileObmen.Models.Entities;

namespace FileObmen.Tools
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                  File file, Func<string, string> pageUrl)
        {
            var result = new StringBuilder();
            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(file.Sha));
            tag.InnerHtml = file.Name;
            result.Append(tag);

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString FileSize(this HtmlHelper html, long size)
        {
            var result = new StringBuilder();
            string data;
            if (size <= 1024)
                data = size + " Б";
            else if (size > 1024 && size < 1048576)
            {
                size /= 1024;
                data = size + " КБ";
            }
            else if (size >= 1048576 && size < 1073741824)
            {
                size /= 1048576;
                data = size + " МБ";
            }
            else
            {
                size /= 1073741824;
                data = size + " ГБ";
            }
            result.Append(data);

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString SubmitField(this HtmlHelper html, string sha)
        {
            var result = new StringBuilder();
            var input = new TagBuilder("input");
            input.MergeAttribute("type", "submit");
            input.MergeAttribute("value", "x");
            input.AddCssClass("delete-file");
            input.MergeAttribute("id", "delete" + sha);
            result.Append(input);
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString LabelField(this HtmlHelper html, string sha)
        {
            var result = new StringBuilder();
            var label = new TagBuilder("label");
            label.MergeAttribute("for", "delete" + sha);
            label.AddCssClass("delete-file");
            label.SetInnerText("[x]");
            result.Append(label);
            return MvcHtmlString.Create(result.ToString());
        }
    }
}