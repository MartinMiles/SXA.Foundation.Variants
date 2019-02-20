using System;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.RenderVariantField;
using Sitecore.Abstractions;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Web.UI.WebControls;
using Sitecore.XA.Foundation.RenderingVariants;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SXA.Foundation.Variants.Pipelines.VariantFields.ImageWithClass
{
    public class RenderImageWithClass : RenderVariantFieldProcessor
    {
        public override Type SupportedType => typeof(VariantImageWithClass);

        public override RendererMode RendererMode =>RendererMode.Html;

        public override void RenderField(RenderVariantFieldArgs args)
        {
            var variantField = args.VariantField as VariantImageWithClass;

            if (args.Item.Paths.IsMediaItem)
            {
                args.ResultControl = CreateResponsiveImage(args.Item, variantField, args.Item[Templates.Image.Fields.Alt]);
                args.Result = RenderControl(args.ResultControl);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(variantField != null ? variantField.FieldName : null))
                {
                    return;
                }

                if (PageMode.IsExperienceEditorEditing)
                {
                    args.ResultControl = new FieldRenderer()
                    {
                        Item = args.Item,
                        FieldName = variantField.FieldName,
                        DisableWebEditing = !args.IsControlEditable
                    };

                    args.Result = RenderControl(args.ResultControl);
                }
                else
                {
                    Field field1 = args.Item.Fields[variantField.FieldName];
                    if (field1 == null)
                    {
                        return;
                    }

                    ImageField field2 = FieldTypeManager.GetField(field1) as ImageField;

                    if ((field2 != null ? field2.MediaItem : null) == null)
                    {
                        return;
                    }
                    string altText = string.IsNullOrWhiteSpace(field2.Alt) ? field2.MediaItem[Templates.Image.Fields.Alt] : field2.Alt;

                    args.ResultControl = CreateResponsiveImage(field2.MediaItem, variantField, altText);
                    args.Result = RenderControl(args.ResultControl);
                }
            }
        }

        protected virtual HtmlGenericControl CreateResponsiveImage(Item mediaItem, VariantImageWithClass variantResponsiveImage, string altText)
        {
            string str = ServiceLocator.GetRequiredResetableService<BaseMediaManager>().Value.GetMediaUrl(mediaItem);
            string sourceSet = GetSourceSet(variantResponsiveImage.Widths, str);
            if (!string.IsNullOrWhiteSpace(variantResponsiveImage.DefaultSize))
            {
                str = AddWidthParam(str, variantResponsiveImage.DefaultSize);
            }

            HtmlGenericControl htmlGenericControl = new HtmlGenericControl("img");
            htmlGenericControl.Attributes.Add("src", str);

            if (!string.IsNullOrWhiteSpace(altText))
            {
                htmlGenericControl.Attributes.Add("alt", altText);
            }

            if (!string.IsNullOrWhiteSpace(variantResponsiveImage.CssClass))
            {
                htmlGenericControl.Attributes.Add("class", variantResponsiveImage.CssClass);
            }

            if (!string.IsNullOrWhiteSpace(variantResponsiveImage.Sizes))
            {
                htmlGenericControl.Attributes.Add("sizes", variantResponsiveImage.Sizes);
            }

            if (!string.IsNullOrWhiteSpace(sourceSet))
            {
                htmlGenericControl.Attributes.Add("srcset", sourceSet);
            }

            return htmlGenericControl;
        }

        protected virtual string GetSourceSet(string widthsValue, string url)
        {
            string str1 = string.Empty;

            if (string.IsNullOrWhiteSpace(url))
            {
                return str1;
            }

            string str2 = widthsValue;
            char[] separator = new char[1] { ',' };
            int num = 1;

            foreach (string str3 in str2.Split(separator, (StringSplitOptions)num))
            {
                int result;
                if (int.TryParse(str3, out result))
                {
                    if (!string.IsNullOrWhiteSpace(str1) && !str1.EndsWith(",", StringComparison.OrdinalIgnoreCase))
                    {
                        str1 += ",";
                    }

                    str1 = str1 + AddWidthParam(url, str3) + " " + str3 + "w";
                }
            }
            return str1;
        }

        protected virtual string AddWidthParam(string mediaLink, string defaultSize)
        {
            if (!string.IsNullOrWhiteSpace(defaultSize))
            {
                int length = mediaLink.IndexOf("?", StringComparison.OrdinalIgnoreCase);
                NameValueCollection nameValueCollection = length != -1 ? HttpUtility.ParseQueryString(mediaLink.Substring(length + 1)) : HttpUtility.ParseQueryString(string.Empty);

                if (((IEnumerable<string>)nameValueCollection.AllKeys).Contains("w"))
                {
                    nameValueCollection["w"] = defaultSize;
                }
                else
                {
                    nameValueCollection.Add("w", defaultSize);
                }

                mediaLink = length == -1 ? mediaLink + "?" + nameValueCollection : mediaLink.Substring(0, length) + "?" + nameValueCollection;
            }
            return ProtectAssetLink(mediaLink);
        }

        protected virtual string ProtectAssetLink(string link)
        {
            return HashingUtils.ProtectAssetUrl(link);
        }
    }
}