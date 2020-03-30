using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MarkedNet;
using System.Text.RegularExpressions;

namespace Skclusive.Markdown.Component
{
    public class MarkdownSegment : MarkdownBase
    {
        private static readonly Options OPTIONS = new Options();

        private static readonly MarkdownRenderer RENDERER = new MarkdownRenderer();

        private static readonly MarkdownParser PARSER = new MarkdownParser(OPTIONS);

        private TokensResult TokensResult;

        public MarkdownSegment() : base("MarkdownSegment")
        {
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Options = Options ?? OPTIONS;

            Renderer = Renderer ?? RENDERER;

            Options.Renderer = Renderer;

            Parser = Parser ?? PARSER;

            var text = Regex.Replace(Text ?? "", @"---[\r\n]([\s\S]*)[\r\n]---", "", RegexOptions.Multiline);

            TokensResult = Lexer.Lex(text, Options);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<MarkdownSection>(1);
                builder.AddAttribute(2, "Class", _Class);
                builder.AddAttribute(3, "Style", _Style);
                builder.AddAttribute(3, "ChildContent", (RenderFragment)((childBuilder) =>
                {
                    Renderer.Builder = childBuilder;

                    Parser.Parse(TokensResult);
                }));
            builder.CloseComponent();
        }
    }
}
