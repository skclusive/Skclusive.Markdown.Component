using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using MarkedNet;

namespace Skclusive.Markdown.Component
{
    public class Markdown : MarkdownBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var replaced = Regex.Replace(Text, @"---[\r\n]([\s\S]*)[\r\n]---", "", RegexOptions.Multiline);

            var splits = Regex.Split(replaced, @"^{{(""blazor"":[^}]*)}}$", RegexOptions.Multiline);

            int index = 0;
            foreach (var split in splits.Where(x => !Regex.IsMatch(x, @"^\s*$")))
            {
                builder.OpenRegion(index++);
                if (split.StartsWith(@"""blazor"":"))
                {
                    var start = @"""blazor"": """.Length;
                    if (split.Length > start)
                    {
                        var type = split.Substring(start, split.Length - start - 1);
                        var blazorType = Type.GetType(type);
                        builder.OpenComponent<Reflected>(1);
                        builder.AddAttribute(2, "Type", blazorType);
                        builder.CloseComponent();
                    }
                }
                else
                {
                    builder.OpenComponent<MarkdownSegment>(12);
                    builder.AddAttribute(13, "Class", _Class);
                    builder.AddAttribute(14, "Style", _Style);
                    builder.AddAttribute(15, "Text", split);
                    builder.AddAttribute(16, "Options", Options);
                    builder.AddAttribute(17, "Renderer", Renderer);
                    builder.AddAttribute(18, "Parser", Parser);
                    builder.CloseComponent();
                }
                builder.CloseRegion();
            }
        }
    }
}
