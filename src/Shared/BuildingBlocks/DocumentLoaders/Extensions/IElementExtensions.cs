using AngleSharp.Dom;

namespace BuildingBlocks.DocumentLoaders.Extensions
{
    // ReSharper disable once UnusedMember.Global
    public static class IElementExtensions
    {
        public static string GetTextContent(this IElement element, string querySelector)
        {
            return element.QuerySelector(querySelector)?.TextContent;
        }
    }
}