using Sitecore.Data;

namespace SXA.Foundation.Variants
{
    public static partial class Constants
    {
        public static partial class RenderingVariants
        {
            public static partial class Templates
            {
                //public static ID QueryString = new ID("{55EC1199-6A6B-49FE-9B73-12560C87C2DE}");
                //public static ID VariantImageWithClass = new ID("{0D60FB5C-8EA0-475C-BC95-3250E3BDBAAB}");
                //public static ID VariantImageSection = new ID("{E50B405C-90D9-47E3-B76A-0EEAEE1AA135}");
                //public static ID ItemReference = new ID("{496C9E4E-777D-4831-9F39-D0EBB1022606}");
                public static ID Script = new ID("{D3B88DCE-771D-42E9-B4F7-B12778EBEBAE}");
            }

            public static partial class Fields
            {
                public static class Script
                {
                    public static ID ScriptField { get; } = new ID("{1E32365D-51ED-4908-8CA3-8CB0B8014C45}");
                }
            }
        }
    }
}