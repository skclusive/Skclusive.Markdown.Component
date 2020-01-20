using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Markdown.Component
{
    public class SectionComponent : EventComponentBase
    {
        public SectionComponent() : base("MarkdownSection")
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
