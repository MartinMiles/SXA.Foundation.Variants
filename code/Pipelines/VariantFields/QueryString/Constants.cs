using Sitecore.Data;

namespace SXA.Foundation.Variants
{
    public static partial class Constants
    {
        public static partial class RenderingVariants
        {
            public static partial class Templates
            {
                public static ID QueryString = new ID("{55EC1199-6A6B-49FE-9B73-12560C87C2DE}");
            }

            public static partial class Fields
            {
                public static class QueryField
                {
                    public static ID Tag { get; } = new ID("{F556DEDD-5D6B-4FFF-A904-E4C65AB0E698}");
                    public static ID CssClass { get; } = new ID("{B3B6B300-1704-493B-999C-AD21CCE58FEF}");
                    public static ID FieldName { get; } = new ID("{9D3717EF-CD09-4D98-8C4A-914299503626}");
                    public static ID Prefix { get; } = new ID("{5844C4AA-5E48-4721-8E30-91646E430C83}");
                    public static ID Suffix { get; } = new ID("{0EFAF48E-E0DD-4408-80D3-4C001101E834}");
                    public static ID RenderIfEmpty { get; } = new ID("{E14C3930-FE6C-48AC-99D8-C6867B489066}");
                }
            }
        }
    }
}