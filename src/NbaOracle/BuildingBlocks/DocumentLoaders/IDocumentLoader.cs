using System.Threading.Tasks;
using AngleSharp.Dom;

namespace NbaOracle.Providers.BuildingBlocks.DocumentLoaders
{
    public interface IDocumentLoader
    {
        Task<IDocument> LoadDocument(DocumentOptions options);
    }
}