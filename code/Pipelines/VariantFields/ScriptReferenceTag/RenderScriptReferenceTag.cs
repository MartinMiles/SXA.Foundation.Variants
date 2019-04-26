using System;
using Sitecore.Data;
using System.Web.UI.HtmlControls;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ScriptReferenceTag
{
    public class RenderScriptReferenceTag : RenderVariantField
    {
        public override Type SupportedType => typeof(VariantScriptReferenceTag);

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantScriptReferenceTag;
            if (variantField != null)
            {
                var id = variantField?.ScriptMedia;
                if (string.IsNullOrWhiteSpace(id))
                {
                    return;
                }

                var scriptItem = Context.Database.GetItem(new ID(id));
                if(scriptItem == null)
                {
                    return;
                }

                var url = MediaManager.GetMediaUrl(scriptItem);

                var tag = new HtmlGenericControl(variantField.Tag);
                tag.Attributes.Add("type", "text/javascript");
                tag.Attributes.Add("defer", String.Empty);
                tag.Attributes.Add("src", url);

                args.ResultControl = tag;
                args.Result = RenderControl(args.ResultControl);
            }
        }
    }
}