using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace BuildingBlocks.Parsers
{
    public abstract class DocumentWithCommentTagBase<TOutput> : IDocumentParser<TOutput>
    {
        protected abstract string CommentTagSelector { get; }
        protected abstract TOutput ApplyInnerDocument(IDocument document);

        public TOutput Parse(IDocument document)
        {
            var element = document.QuerySelector(CommentTagSelector);

            var comment = element?.Descendents<IComment>().FirstOrDefault();
            if (comment == null)
                return default;

            var parser = new HtmlParser();
            var innerDocument = parser.ParseDocument(comment.TextContent.Trim());

            return ApplyInnerDocument(innerDocument);
        }
    }
}