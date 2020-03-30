using MarkedNet;

namespace Skclusive.Markdown.Component
{
    public class MarkdownParser : Parser
    {
        private Options _options;

        private bool _quoteInProgress;

        private bool _listInProgress;

        private Token _token;


        public MarkdownParser(Options options) : base(options)
        {
            _options = options;
        }

        protected override Token Next()
        {
            return _token = base.Next();
        }

        protected virtual void MarkProgress()
        {
            switch (_token.Type)
            {
                case "blockquote_start":
                    _quoteInProgress = true;
                    break;
                case "blockquote_end":
                    _quoteInProgress = false;
                    break;
                case "list_start":
                    _listInProgress = true;
                    break;
                case "list_end":
                    _listInProgress = false;
                    break;
            }

            if (_options?.Renderer is MarkdownRenderer markDownRenderer)
            {
                markDownRenderer.QuoteInProgress = _quoteInProgress;

                markDownRenderer.ListInProgress = _listInProgress;
            }
        }

        protected override string Tok()
        {
            MarkProgress();

            string result = base.Tok();

            MarkProgress();

            return result;
        }
    }
}
