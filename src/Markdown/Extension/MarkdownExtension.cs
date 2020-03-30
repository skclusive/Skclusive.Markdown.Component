using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.Prism;

namespace Skclusive.Markdown.Component
{
    public static class MarkdownExtension
    {
        public static void TryAddMarkdownServices(this IServiceCollection services)
        {
            services.TryAddPrismServices();
        }
    }
}
