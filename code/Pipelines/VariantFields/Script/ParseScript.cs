using Sitecore.Data;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.ParseVariantFields;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.Script
{
    public class ParseScript : ParseField
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.Script;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            variantFieldArgs.TranslatedField = new VariantScript
            {
                Script = args.VariantItem[Constants.RenderingVariants.Fields.Script.ScriptField]
            };
        }
    }
}