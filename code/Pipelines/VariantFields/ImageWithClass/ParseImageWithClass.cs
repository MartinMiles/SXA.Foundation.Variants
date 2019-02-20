using Sitecore.Data;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageWithClass
{
    public class ParseImageWithClass : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.VariantImageWithClass;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            var variantImageWithClass = new VariantImageWithClass();
            variantImageWithClass.ItemName = args.VariantItem.Name;
            variantImageWithClass.FieldName = args.VariantItem[Constants.RenderingVariants.Fields.ImageWithClass.FieldName];
            variantImageWithClass.CssClass = args.VariantItem[Constants.RenderingVariants.Fields.ImageWithClass.CssClass];
            variantImageWithClass.Sizes = args.VariantItem[Constants.RenderingVariants.Fields.ImageWithClass.Sizes];
            variantImageWithClass.Widths = args.VariantItem[Constants.RenderingVariants.Fields.ImageWithClass.Widths];
            variantImageWithClass.DefaultSize = args.VariantItem[Constants.RenderingVariants.Fields.ImageWithClass.DefaultSize];
            variantFieldArgs.TranslatedField = variantImageWithClass;
        }
    }
}