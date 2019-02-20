using System;
using System.Web.UI.WebControls;
using Sitecore.Data;
using Sitecore.Pipelines;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ItemReference
{
    public class RenderItemReference : RenderVariantFieldProcessor
    {
        public override Type SupportedType => typeof(VariantItemReference);

        public override RendererMode RendererMode => RendererMode.Html;
      

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var control = new PlaceHolder();

            var variantItemReference = args.VariantField as VariantItemReference;
            if (!string.IsNullOrWhiteSpace(variantItemReference?.PassThroughItem))
            {
                var newContextItem = Sitecore.Context.Database.GetItem(new ID(variantItemReference.PassThroughItem));
                if (newContextItem != null)
                {
                    foreach (BaseVariantField referencedItem in variantItemReference.NestedFields)
                    {
                        RenderVariantFieldArgs variantFieldArgs = new RenderVariantFieldArgs
                        {
                            VariantField = referencedItem,
                            Item = newContextItem,
                            HtmlHelper = args.HtmlHelper,
                            IsControlEditable = args.IsControlEditable,
                            IsFromComposite = args.IsFromComposite,
                            RendererMode = args.RendererMode,
                            Model = args.Model
                        };

                        CorePipeline.Run("renderVariantField", variantFieldArgs);
                        if (variantFieldArgs.ResultControl != null)
                        {
                            control.Controls.Add(variantFieldArgs.ResultControl);
                        }
                    }
                }
            }

            args.ResultControl = control;
            args.Result = RenderControl(args.ResultControl);
        }
    }
}