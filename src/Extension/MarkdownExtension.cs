using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Script.Prism;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Icon;
using Skclusive.Material.Button;

namespace Skclusive.Markdown.Component
{
    public static class MarkdownExtension
    {
        public static void TryAddMarkdownServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPrismServices(config);

            services.TryAddIconServices(config);

            services.TryAddButtonServices(config);

            services.TryAddStyleTypeProvider<MarkdownStyleProvider>();
        }
    }
}
