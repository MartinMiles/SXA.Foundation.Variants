using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageSection
{
    public class ParseImageSection : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.VariantImageSection;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            var variantSection = new VariantImageSection(args.VariantItem);
            variantSection.ItemName = args.VariantItem.Name;
            variantSection.Tag = args.VariantItem.Fields[Constants.RenderingVariants.Fields.ImageSection.Tag].GetEnumValue();
            variantSection.CssClass = args.VariantItem[Constants.RenderingVariants.Fields.ImageSection.CssClass];
            variantSection.ImageFieldName = args.VariantItem[Constants.RenderingVariants.Fields.ImageSection.ImageField];
            variantSection.LinkField = args.VariantRootItem[Sitecore.XA.Foundation.Variants.Abstractions.Templates.IVariantDefinition.Fields.LinkField];
            variantSection.IsLink = args.VariantItem[Constants.RenderingVariants.Fields.ImageSection.IsLink] == "1";

            variantSection.SectionFields = args.VariantItem.Children.Count > 0 
                ? ((IVariantFieldParser)ServiceLocator.ServiceProvider.GetService(typeof(IVariantFieldParser))).ParseVariantFields(args.VariantItem, args.VariantRootItem, false) 
                : new List<Sitecore.XA.Foundation.Variants.Abstractions.Fields.BaseVariantField>();

            variantFieldArgs.TranslatedField = variantSection;
        }
    }
}