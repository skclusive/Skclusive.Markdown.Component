using Skclusive.Core.Component;

namespace Skclusive.Markdown.Component
{
    public class MarkdownStyleProvider : StyleTypeProvider
    {
        public MarkdownStyleProvider() : base
        (
            typeof(MarkdownSectionStyle),
            typeof(MarkdownTitleStyle),
            typeof(MarkdownAnchorStyle),
            typeof(MarkdownDemoStyle),
            typeof(MarkdownCodeStyle)
        )
        {
        }
    }
}