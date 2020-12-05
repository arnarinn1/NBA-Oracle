using AngleSharp.Dom;

namespace NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Extensions
{
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    public static class IDocumentExtensions
    {
        public static bool IsSuccessStatusCode(this IDocument document)
        {
            var statusCode = document.StatusCode;
            return (int) statusCode >= 200 && (int) statusCode <= 299;
        }
    }
}