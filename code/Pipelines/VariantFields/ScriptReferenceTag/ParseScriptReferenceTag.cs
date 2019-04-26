using Sitecore.Data;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ScriptReferenceTag
{
    public class ParseScriptReferenceTag : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId =>  Constants.RenderingVariants.Templates.ScriptReferenceTag;
        
        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            var variantHtmlTag = new VariantScriptReferenceTag(args.VariantItem) { Tag = "script" };
            variantHtmlTag.ScriptMedia = args.VariantItem[Constants.RenderingVariants.Fields.ScriptReferenceTag.ScriptMedia];
            variantFieldArgs.TranslatedField = variantHtmlTag;
        }
    }
}