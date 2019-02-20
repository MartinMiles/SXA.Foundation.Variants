using System.Collections.Generic;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ItemReference
{
    public class VariantItemReference : BaseVariantField
    {
        public string PassThroughItem { get; set; }

        public IEnumerable<BaseVariantField> NestedFields { get; set; }
    }
}