using AngleSharp.Dom;

namespace BuildingBlocks.DocumentLoaders.Extensions
{
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    public static class IElementExtensions
    {
        public static string GetTextContent(this IElement element, string querySelector)
        {
            return element.QuerySelector(querySelector)?.TextContent;
        }

        public static string GetAttributeFromElement(this IElement element, string querySelector, string attributeName)
        {
            return element.QuerySelector(querySelector)?.GetAttribute(attributeName);
        }
    }

}