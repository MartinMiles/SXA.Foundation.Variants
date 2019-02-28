using Sitecore.Data;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.ParseVariantFields;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.QueryString
{
    public class ParseQueryStringField : ParseField
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.QueryString;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            variantFieldArgs.TranslatedField = new VariantQueryString(args.VariantItem)
            {
                // this property is reused under different purpose rather than named - it stores URL parameter name
                FieldName = args.VariantItem[Constants.RenderingVariants.Fields.QueryString.FieldName],

                Tag = args.VariantItem.Fields[Constants.RenderingVariants.Fields.QueryString.Tag].GetEnumValue(),
                CssClass = args.VariantItem[Constants.RenderingVariants.Fields.QueryString.CssClass],
                Prefix = args.VariantItem[Constants.RenderingVariants.Fields.QueryString.Prefix],
                Suffix = args.VariantItem[Constants.RenderingVariants.Fields.QueryString.Suffix],
                RenderIfEmpty = args.VariantItem[Constants.RenderingVariants.Fields.QueryString.RenderIfEmpty] == "1"
            };
        }
    }
}