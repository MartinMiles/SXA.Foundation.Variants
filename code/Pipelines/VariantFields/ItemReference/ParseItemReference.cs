using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ItemReference
{
    public class ParseItemReference : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.ItemReference;


        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            var reference = new VariantItemReference();
            reference.ItemName = args.VariantItem.Name;
            reference.PassThroughItem = args.VariantItem[Constants.RenderingVariants.Fields.ItemReference.Item];

            reference.NestedFields = args.VariantItem.Children.Count > 0
                ? ((IVariantFieldParser)ServiceLocator.ServiceProvider.GetService(typeof(IVariantFieldParser))).ParseVariantFields(args.VariantItem, args.VariantRootItem, false)
                : new List<BaseVariantField>();

            variantFieldArgs.TranslatedField = reference;
        }
    }
}