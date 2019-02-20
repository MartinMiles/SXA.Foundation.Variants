using Sitecore.Data;

namespace SXA.Foundation.Variants
{
    public static partial class Constants
    {
        public static partial class RenderingVariants
        {
            public static partial class Templates
            {
                public static ID VariantImageSection = new ID("{E50B405C-90D9-47E3-B76A-0EEAEE1AA135}");
            }

            public static partial class Fields
            {
                public static class ImageSection
                {
                    public static ID ImageField { get; } = new ID("{2629E24F-33BB-445A-8466-D7980B2D1D40}");
                    public static ID Tag { get; } = new ID("{9A127699-8E80-4DC6-8F72-2BA830FC5F06}");
                    public static ID CssClass { get; } = new ID("{72D34455-51E4-482C-BBE0-7357DFFD3F19}");
                    public static ID IsLink { get; } = new ID("{8AE340B8-4C89-4544-988E-7A994809958B}");
                }

            }
        }
    }
}