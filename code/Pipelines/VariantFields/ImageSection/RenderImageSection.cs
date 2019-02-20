using System;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Fields;
using Sitecore.Pipelines;
using Sitecore.Resources.Media;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageSection
{
    public class RenderImageSection : RenderRenderingVariantFieldProcessor
    {
        public override Type SupportedType => typeof(VariantImageSection);

        public override RendererMode RendererMode => RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            string styleInlineValue = String.Empty;
            var variantField = args.VariantField as VariantImageSection;

            if (!string.IsNullOrWhiteSpace(variantField?.ImageFieldName) && args.Item != null)
            {
                ImageField imgField = args.Item.Fields[variantField.ImageFieldName];
                if (imgField?.MediaItem  != null)
                {
                    string url = MediaManager.GetMediaUrl(imgField.MediaItem);
                    styleInlineValue = $"background-image: url({url})";
                }
            }

            var tag = new HtmlGenericControl(string.IsNullOrWhiteSpace(variantField.Tag) ? "div" : variantField.Tag);

            if (styleInlineValue.Length > 0)
            {
                tag.Attributes.Add("style", styleInlineValue);
            }

            AddClass(tag, variantField.CssClass);
            AddWrapperDataAttributes(variantField, args, tag);

            foreach (BaseVariantField sectionField in variantField.SectionFields)
            {
                var variantFieldArgs = new RenderVariantFieldArgs
                {
                    VariantField = sectionField,
                    Item = args.Item,
                    HtmlHelper = args.HtmlHelper,
                    IsControlEditable = args.IsControlEditable,
                    IsFromComposite = args.IsFromComposite,
                    RendererMode = args.RendererMode,
                    Model = args.Model
                };

                CorePipeline.Run("renderVariantField", variantFieldArgs);

                if (variantFieldArgs.ResultControl != null)
                {
                    tag.Controls.Add(variantFieldArgs.ResultControl);
                }
            }

            args.ResultControl = variantField.IsLink ? InsertHyperLink(tag, args.Item, variantField.LinkAttributes, variantField.LinkField, false, args.HrefOverrideFunc) : tag;
            args.Result = RenderControl(args.ResultControl);
        }
    }
}