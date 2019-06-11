using System;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace SXA.Foundation.Variants.NVelocityExtensions
{
    public class ItemFieldTool
    {
        public static Item GetItemReferenceItem(Item item, string fieldName)
        {
            ReferenceField field = item.Fields[fieldName];

            return field?.TargetItem;
        }
        
        public static Item GetFixedReferenceItem(string guidOrPath)
        {
            return Sitecore.Context.Database.GetItem(guidOrPath);
        }        
        
        public static string GetField(Item item, string fieldName)
        {
            ReferenceField field = item.Fields[fieldName];

            return field?.Value ?? String.Empty;
        }
    }
}