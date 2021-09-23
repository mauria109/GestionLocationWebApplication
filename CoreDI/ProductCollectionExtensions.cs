using GestionLocationWebApplication.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GestionLocationWebApplication.CoreDI
{
    public static class ProductCollectionExtensions
    {
        public static IServiceCollection AjouterProduitServices(this IServiceCollection services)
        {
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IArticleService, ArticleService>();
            return services;
        }
    }
}