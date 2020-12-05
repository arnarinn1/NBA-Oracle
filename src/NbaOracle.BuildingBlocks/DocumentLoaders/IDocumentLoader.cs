using System.Threading.Tasks;
using AngleSharp.Dom;

namespace BuildingBlocks.DocumentLoaders
{
    public interface IDocumentLoader
    {
        Task<IDocument> LoadDocument(DocumentOptions options);
    }
}