using System;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;
using System.Text.RegularExpressions;
using System.Web.UI;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class RenderImageLink : RenderVariantFieldProcessor
    {
        public override Type SupportedType => typeof(VariantImageLink);

        public override RendererMode RendererMode => RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantImageLink;

            var link = Render(variantField.RenderLinkFromVariantItem ? variantField.VariantItem : args.Item, variantField.LinkFieldName, variantField.LinkClass);
            var image = Render(variantField.RenderImageFromVariantItem ? variantField.VariantItem : args.Item, variantField.MediaFieldName, variantField.ImageClass);

            if (!string.IsNullOrWhiteSpace(image))
            {
                var htmlOutput = string.IsNullOrWhiteSpace(link)
                    ? image
                    : Regex.Replace(link, @">.*<", $">{image}<");

                args.ResultControl = new LiteralControl(htmlOutput);
                args.Result = RenderControl(args.ResultControl);
            }
        }

        private string Render(Item item, string fieldName, string cssClass)
        {
            if (item != null && !string.IsNullOrWhiteSpace(fieldName))
            {
                var fieldRenderer = new FieldRenderer
                {
                    Item = item,
                    CssClass = cssClass,
                    FieldName = fieldName
                };

                return fieldRenderer.Render();
            }

            return String.Empty;
        }
    }
}