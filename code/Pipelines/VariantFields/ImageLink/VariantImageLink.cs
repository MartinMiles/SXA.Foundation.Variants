using Sitecore.XA.Foundation.Variants.Abstractions.Fields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class VariantImageLink : BaseVariantField
    {
        public string ImageField { get; set; }
        public string Link { get; set; }
        public string LinkClass { get; set; }
        public string ImageClass { get; set; }
    }
}