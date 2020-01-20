using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using MarkedNet;

namespace Skclusive.Markdown.Component
{
    public class Segment : EventComponentBase
    {
        [Parameter]
        public MarkdownRenderer Renderer { get; set; }

        [Parameter]
        public Options Options { get; set; }

        [Parameter]
        public MarkdownParser Parser { get; set;  }

        [Parameter]
        public string Text { set; get; }

        private TokensResult TokensResult;

        public Segment() : base("MarkdownSegment")
        {
        }

        protected override void OnInitialized()
        {
            Options = Options ?? new Options();

            Renderer = Renderer ?? new MarkdownRenderer();

            Options.Renderer = Renderer;

            Parser = Parser ?? new MarkdownParser(Options);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            TokensResult = Lexer.Lex(Text, Options);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Section>(1);
            builder.AddAttribute(2, "ChildContent", (RenderFragment)((childBuilder) =>
            {
                Renderer.Builder = childBuilder;

                Parser.Parse(TokensResult);
            }));
            builder.CloseComponent();
        }
    }
}
