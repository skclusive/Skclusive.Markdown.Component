using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Markdown.Component
{
    public class MarkdownSectionComponent : EventComponentBase
    {
        public MarkdownSectionComponent() : base("MarkdownSection")
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
