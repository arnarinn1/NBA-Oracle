using System;
using AngleSharp.Dom;
using ValueObjects.Extensions;

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

        public static DateTime GetAttributeFromElementAsDate(this IElement element, string querySelector, string attributeName)
        {
            var value = element.GetAttributeFromElement(querySelector, attributeName);
            return ParsingMethods.ToDate(value, "yyyyMMdd");
        }

        public static int GetTextContentAsInt(this IElement element, string querySelector)
        {
            return element.ParseTextContent(querySelector, ParsingMethods.ToInt);
        }

        public static DateTime ToDate(this IElement element, string querySelector)
        {
            return element.ParseTextContent(querySelector, x => ParsingMethods.ToDate(x, "yyyy"));
        }

        private static T ParseTextContent<T>(this IElement element, string querySelector, Func<string, T> parseFunction)
        {
            return parseFunction(element.GetTextContent(querySelector));
        }
    }
}