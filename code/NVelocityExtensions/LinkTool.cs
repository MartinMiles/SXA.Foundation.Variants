using System;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace SXA.Foundation.Variants.NVelocityExtensions
{
    public class LinkTool
    {
        public static string GetItemLink(Item item, bool includeServerUrl = false)
        {
            var options = UrlOptions.DefaultOptions.Clone() as UrlOptions;

            if (includeServerUrl)
            {
                options.AlwaysIncludeServerUrl = true;
            }

            return LinkManager.GetItemUrl(item, options);
        }
        public static string GetCurrent(bool includeServerUrl = false)
        {
            var item = Sitecore.Context.Item;
            return item == null ? String.Empty : GetItemLink(item, includeServerUrl);
        }
        public static string RenderLink(Item item, string cssClass = "")
        {
            var fieldRenderer = new FieldRenderer
            {
                Item = item,
                CssClass = cssClass,
                FieldName = "Link"
            };

            return fieldRenderer.Render();
        }
    }
}