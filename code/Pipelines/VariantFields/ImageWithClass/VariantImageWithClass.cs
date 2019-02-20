using Sitecore.XA.Foundation.Variants.Abstractions.Fields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageWithClass
{
    public class VariantImageWithClass : BaseVariantField
    {
        public string CssClass { get; set; }
        public string Sizes { get; set; }
        public string Widths { get; set; }
        public string DefaultSize { get; set; }
    }
}