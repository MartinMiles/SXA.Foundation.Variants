using Sitecore.Data.Items;
using Sitecore.XA.Foundation.RenderingVariants.Fields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ScriptReferenceTag
{
    public class VariantScriptReferenceTag : RenderingVariantFieldBase
    {
        public string ScriptMedia { get; set; }

        public VariantScriptReferenceTag(Item variantItem) : base(variantItem)
        {

        }
    }
}