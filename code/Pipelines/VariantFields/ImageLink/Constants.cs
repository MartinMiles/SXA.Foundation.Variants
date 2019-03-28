using Sitecore.Data;

namespace SXA.Foundation.Variants
{
    public static partial class Constants
    {
        public static partial class RenderingVariants
        {
            public static partial class Templates
            {
                public static ID ImageLink = new ID("{37C550BE-4CB7-4F4F-BAA5-4071E3D6A185}");
            }

            public static partial class Fields
            {
                public static class ImageLink
                {
                    public static ID ImageMediaItem { get; } = new ID("{5549B5D1-3FC0-4248-A20F-53D4B1154BA8}");
                    public static ID ImageField { get; } = new ID("{F95D9F53-4629-4644-AF97-4D79C433F322}");
                    public static ID Link { get; } = new ID("{C521A788-C314-4624-AE85-D2B693DF0E31}");
                    public static ID LinkField { get; } = new ID("{21F2E5AA-D6E0-4DEE-9BE4-919C73E7F5E9}");
                    public static ID LinkClass { get; } = new ID("{ADFBD6AB-ABBC-4380-8CE6-EFB56427D3AE}");
                    public static ID ImageClass { get; } = new ID("{96E6898A-1317-4E22-9154-E884A2FF641D}");
                }
            }
        }
    }
}