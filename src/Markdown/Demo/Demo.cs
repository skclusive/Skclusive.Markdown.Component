using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Markdown.Component
{
    public class Demo : EventComponentBase
    {
        public Demo() : base("MarkdownDemo")
        {
        }

        [Parameter]
        public Type Type { set; get; }

        [Parameter]
        public string LinkStyle { set; get; }

        [Parameter]
        public string LinkClass { set; get; }

        protected virtual string _LinkStyle
        {
            get => CssUtil.ToStyle(LinkStyles, LinkStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> LinkStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _LinkClass
        {
            get => CssUtil.ToClass($"{Selector}-Link", LinkClasses, LinkClass);
        }

        protected virtual IEnumerable<string> LinkClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "style", _Style);
            builder.AddAttribute(2, "class", _Class);
            builder.OpenComponent<Dynamic>(4);
            builder.AddAttribute(5, "Type", Type);
            builder.CloseComponent();
            builder.CloseElement();
        }
    }
}
