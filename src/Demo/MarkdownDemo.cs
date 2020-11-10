using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Markdown.Component
{
    public class MarkdownDemoComponent : EventComponentBase
    {
        public MarkdownDemoComponent() : base("MarkdownDemo")
        {
        }

        [Parameter]
        public RenderFragment ViewContent { set; get; }

        [Parameter]
        public RenderFragment CodeContent { set; get; }

        [Parameter]
        public string ViewStyle { set; get; }

        [Parameter]
        public string HeaderStyle { set; get; }

        [Parameter]
        public string HeaderClass { set; get; }

        [Parameter]
        public string ViewClass { set; get; }

        protected bool HasCode => CodeContent != null;

        protected bool CodeOpen { set; get; }

        protected bool DemoHovered { set; get; }

        protected virtual string _ViewStyle
        {
            get => CssUtil.ToStyle(ViewStyles, ViewStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ViewStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ViewClass
        {
            get => CssUtil.ToClass($"{Selector}-View", ViewClasses, ViewClass);
        }

        protected virtual IEnumerable<string> ViewClasses
        {
            get
            {
                yield return string.Empty;
            }
        }


        protected virtual string _HeaderStyle
        {
            get => CssUtil.ToStyle(HeaderStyles, HeaderStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> HeaderStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _HeaderClass
        {
            get => CssUtil.ToClass($"{Selector}-Header", HeaderClasses, HeaderClass);
        }

        protected virtual IEnumerable<string> HeaderClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected void OnToggleCode(EventArgs args)
        {
            CodeOpen = !CodeOpen;

            StateHasChanged();
        }

        protected void OnDemoMouseEnter(EventArgs args)
        {
            DemoHovered = true;

            StateHasChanged();
        }

        protected void OnDemoMouseLeave(EventArgs args)
        {
            DemoHovered = false;

            StateHasChanged();
        }
    }
}
