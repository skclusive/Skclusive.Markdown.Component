using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using System;

namespace Skclusive.Markdown.Component
{
    public class Dynamic : EventComponentBase
    {
        [Parameter]
        public Type Type { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent(1, Type);
            builder.CloseComponent();
        }
    }
}
