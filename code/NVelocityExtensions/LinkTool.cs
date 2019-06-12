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
                
	public static string GetTitleFromGeneralLinkField(Item item, string fieldName)
        {
            var linkField = (LinkField)item.Fields[fieldName];
            return linkField.Title ?? "";
        }
        
        public static string GetUrlFromGeneralLinkField(Item item, string fieldName)
        {
            return LinkUrl(item.Fields[fieldName]);
        }

        private static String LinkUrl(LinkField lf)
        {
            if (lf == null)
            {
            	return string.Empty;
            }
                
            switch (lf.LinkType.ToLower())
            {
                case "internal": return lf.TargetItem != null ? LinkManager.GetItemUrl(lf.TargetItem) : string.Empty;
                case "media": return lf.TargetItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem) : string.Empty;
                case "external": return lf.Url;
                case "anchor": return !string.IsNullOrEmpty(lf.Anchor) ? "#" + lf.Anchor : string.Empty;
                case "mailto": return lf.Url;
                case "javascript": return lf.Url;
                default: return lf.Url;
            }
        }
    }
}