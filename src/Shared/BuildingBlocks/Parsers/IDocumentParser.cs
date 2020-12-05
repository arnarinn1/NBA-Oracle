using AngleSharp.Dom;

namespace BuildingBlocks.Parsers
{
    public interface IDocumentParser<out TOutput>
    {
        TOutput Parse(IDocument document);
    }
}