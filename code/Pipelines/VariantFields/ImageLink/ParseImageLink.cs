using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class ParseImageLink : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.ImageLink;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;

            var imageMediaItem = new Field(Constants.RenderingVariants.Fields.ImageLink.ImageMediaItem, args.VariantItem);
            var linkField = new Field(Constants.RenderingVariants.Fields.ImageLink.Link, args.VariantItem);

            var variantImageLink = new VariantImageLink { ItemName = args.VariantItem.Name };

            var linkClass = args.VariantItem[Constants.RenderingVariants.Fields.ImageLink.LinkClass];
            var imageClass = args.VariantItem[Constants.RenderingVariants.Fields.ImageLink.ImageClass];

            var mediaField = args.VariantItem[Constants.RenderingVariants.Fields.ImageLink.ImageMediaItem];
            var contextItemFieldName = args.VariantItem[Constants.RenderingVariants.Fields.ImageLink.ImageField];

            variantImageLink.Link = Render(args.VariantItem, linkField.Name, linkClass);

            variantImageLink.ImageField = string.IsNullOrWhiteSpace(mediaField)
                ? Render(Sitecore.Context.Item, contextItemFieldName, imageClass)
                : Render(args.VariantItem, imageMediaItem.Name, imageClass);

            variantFieldArgs.TranslatedField = variantImageLink;
        }

        private string Render(Item item, string fieldName, string cssClass)
        {
            var fieldRenderer = new FieldRenderer
            {
                Item = item,
                CssClass = cssClass,
                FieldName = fieldName
            };

            return fieldRenderer.Render();
        }
    }
}