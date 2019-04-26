using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.Script
{
    public class RenderScript : RenderVariantField
    {
        public override Type SupportedType => typeof(VariantScript);

        public override RendererMode RendererMode => RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantScript;
            if (variantField != null)
            {
                args.ResultControl = RenderScriptField(variantField, args);
                args.Result = RenderControl(args.ResultControl);
            }
        }

        protected virtual Control RenderScriptField(VariantScript variantScript, RenderVariantFieldArgs args)
        {
            if (!string.IsNullOrWhiteSpace(variantScript.Script))
            {
                var tag = new HtmlGenericControl("script") { InnerHtml = variantScript.Script };
                tag.Attributes.Add("defer", String.Empty);
                return tag;
            }

            return new LiteralControl();
        }
    }
}