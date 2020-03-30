using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using MarkedNet;

namespace Skclusive.Markdown.Component
{
    public class MarkdownBase : EventComponentBase
    {
        public MarkdownBase(string selector = "") : base(selector)
        {
        }

        [Parameter]
        public MarkdownRenderer Renderer { get; set; }

        [Parameter]
        public Options Options { get; set; }

        [Parameter]
        public MarkdownParser Parser { get; set;  }

        [Parameter]
        public string Text { set; get; }
    }
}
