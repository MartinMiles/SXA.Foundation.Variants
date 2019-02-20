using SXA.Foundation.Variants.NVelocityExtensions;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.GetVelocityTemplateRenderers;

namespace SXA.Foundation.Variants.Pipelines.GetVelocityTemplateRenderers
{
    public class AddTemplateRenderers : IGetTemplateRenderersPipelineProcessor
    {
        public void Process(GetTemplateRenderersPipelineArgs args)
        {
            args.Context.Put("itemFieldTool", new ItemFieldTool());
            args.Context.Put("linkTool", new LinkTool());
        }
    }
}