using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class ParseImageLink : ParseVariantFieldProcessor
    {
        public override ID SupportedTemplateId => Constants.RenderingVariants.Templates.ImageLink;

        public override void TranslateField(ParseVariantFieldArgs args)
        {
            ParseVariantFieldArgs variantFieldArgs = args;
            var variantItem = args.VariantItem;

            var variantImageLink = new VariantImageLink
            {
                ItemName = variantItem.Name,
                LinkClass = variantItem[Constants.RenderingVariants.Fields.ImageLink.LinkClass],
                ImageClass = variantItem[Constants.RenderingVariants.Fields.ImageLink.ImageClass]
            };

            var imageMediaItemField = new Field(Constants.RenderingVariants.Fields.ImageLink.ImageMediaItem, variantItem);
            var linkDirField = new Field(Constants.RenderingVariants.Fields.ImageLink.Link, variantItem);

            var mediaDirValue = variantItem[Constants.RenderingVariants.Fields.ImageLink.ImageMediaItem];

            var linkRefValue = variantItem[Constants.RenderingVariants.Fields.ImageLink.LinkField];
            var mediaRefValue = variantItem[Constants.RenderingVariants.Fields.ImageLink.ImageField];

            variantImageLink.VariantItem = variantItem;

            if (!string.IsNullOrWhiteSpace(linkDirField.Value))
            {
                variantImageLink.RenderLinkFromVariantItem = true;
            }
            if (!string.IsNullOrWhiteSpace(mediaDirValue))
            {
                variantImageLink.RenderImageFromVariantItem = true;
            }

            variantImageLink.LinkFieldName = string.IsNullOrWhiteSpace(linkDirField.Value) ? linkRefValue : linkDirField.Name;
            variantImageLink.MediaFieldName = string.IsNullOrWhiteSpace(mediaDirValue) ? mediaRefValue : imageMediaItemField.Name;

            variantFieldArgs.TranslatedField = variantImageLink;
        }
    }
}