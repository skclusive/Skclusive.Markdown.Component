using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using MarkedNet;

namespace Skclusive.Markdown.Component
{
    public class Markdown : EventComponentBase
    {
        [Parameter]
        public MarkdownRenderer Renderer { get; set; }

        [Parameter]
        public Options Options { get; set; }

        [Parameter]
        public MarkdownParser Parser { get; set;  }

        [Parameter]
        public string Text { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var replaced = Regex.Replace(Text, @"---[\r\n]([\s\S]*)[\r\n]---", "", RegexOptions.Multiline);

            var splits = Regex.Split(replaced, @"^{{(""demo"":[^}]*)}}$", RegexOptions.Multiline);

            int index = 0;
            foreach(var split in splits.Where(x => !Regex.IsMatch(x, @"^\s*$")))
            {
                builder.OpenRegion(index++);

                if (split.StartsWith(@"""demo"":"))
                {
                    var start = @"""demo"": """.Length;
                    var type = Type.GetType(split.Substring(start, split.Length - start - 1));
                    builder.OpenComponent<Demo>(1);
                    builder.AddAttribute(2, "Type", type);
                    builder.CloseComponent();
                } else
                {
                    builder.OpenComponent<Segment>(1);
                    builder.AddAttribute(2, "Text", split);
                    builder.AddAttribute(3, "Options", Options);
                    builder.AddAttribute(4, "Renderer", Renderer);
                    builder.AddAttribute(5, "Parser", Parser);
                    builder.CloseComponent();
                }
                builder.CloseRegion();
            }
        }
    }
}
