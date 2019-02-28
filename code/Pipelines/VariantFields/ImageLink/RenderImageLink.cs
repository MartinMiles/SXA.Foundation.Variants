using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageLink
{
    public class RenderImageLink : RenderVariantFieldProcessor
    {
        public override Type SupportedType => typeof(VariantImageLink);

        public override RendererMode RendererMode => RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantImageLink;

            if (!string.IsNullOrWhiteSpace(variantField?.ImageField))
            {
                var htmlOutput = string.IsNullOrWhiteSpace(variantField.Link)
                    ? variantField.ImageField
                    : Regex.Replace(variantField.Link, @">.*<", $">{variantField.ImageField}<");

                args.ResultControl = new LiteralControl(htmlOutput);
                args.Result = RenderControl(args.ResultControl);
            }
        }
    }
}