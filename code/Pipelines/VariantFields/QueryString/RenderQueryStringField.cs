using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Sitecore.XA.Foundation.RenderingVariants.Fields;
using Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.QueryString
{
    public class RenderQueryStringField : RenderVariantField
    {
        public override Type SupportedType => typeof(VariantQueryString);

        public override RendererMode RendererMode => RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantQueryString;
            if (variantField != null)
            {
                args.ResultControl = RenderQueryStringValue(variantField, args);
                args.Result = RenderControl(args.ResultControl);
            }
        }

        protected virtual Control RenderQueryStringValue(VariantField variantField, RenderVariantFieldArgs args)
        {
            var queryString = HttpContext.Current.Request.QueryString;

            if (!string.IsNullOrEmpty(variantField.FieldName) && !string.IsNullOrWhiteSpace(variantField.Tag))
            {
                if (queryString.HasKeys() && queryString[variantField.FieldName] != null)
                {
                    var tag = new HtmlGenericControl(variantField.Tag);
                    AddClass(tag, (variantField.CssClass + " " + GetFieldCssClass(variantField.FieldName)).Trim());
                    tag.InnerText = queryString[variantField.FieldName];
                    return tag;
                }

                if (args.IsControlEditable && PageMode.IsExperienceEditorEditing)
                {
                    return GetVariantFieldNameLiteral(variantField.FieldName);
                }
            }

            return new LiteralControl();
        }

        protected virtual HtmlGenericControl GetVariantFieldNameLiteral(string parameterName)
        {
            var missingField = new HtmlGenericControl("span");
            missingField.Attributes.Add("class", "missing-field-hint");
            missingField.InnerText = $"[{parameterName}] URL paramenter";
            return missingField;
        }
    }
}