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

        public static DateTime GetAttributeFromElementAndRemoveLastCharactersAsDate(this IElement element, string querySelector, string attributeName, int numberOfTrailingCharactersToRemove)
        {
            var value = element.GetAttributeFromElement(querySelector, attributeName);
            value = value.Substring(0, value.Length - numberOfTrailingCharactersToRemove);
            return ParsingMethods.ToDate(value, "yyyyMMdd");
        }

        public static string GetAttributeFromElementAndTakeLeadingCharacters(this IElement element, string querySelector, string attributeName, int numberOfLeadingCharactersToTake)
        {
            var value = element.GetAttributeFromElement(querySelector, attributeName);
            return value?.Substring(0, numberOfLeadingCharactersToTake);
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

        public static int GetTextContentAsIntAndRemoveSpecialCharacters(this IElement element, string querySelector)
        {
            var value = element.GetTextContent(querySelector);
            value = value.Replace(",", "");
            return ParsingMethods.ToInt(value);
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