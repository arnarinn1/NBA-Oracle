using AngleSharp.Dom;

namespace BuildingBlocks.Parsers
{
    public interface IDocumentParser<out TOutput>
    {
        TOutput Parse(IDocument document);
    }

    public interface IDocumentParser<out TOutput, in TInput>
    {
        TOutput Parse(IDocument document, TInput input);
    }
}