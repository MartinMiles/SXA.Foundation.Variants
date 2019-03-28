using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class VariantImageLink : BaseVariantField
    {
        public string LinkClass { get; set; }
        public string ImageClass { get; set; }
        public Item VariantItem { get; set; }
        public bool RenderLinkFromVariantItem { get; set; }
        public bool RenderImageFromVariantItem { get; set; }
        public string LinkFieldName { get; set; }
        public string MediaFieldName { get; set; }
    }
}