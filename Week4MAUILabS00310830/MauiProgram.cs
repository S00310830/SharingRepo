using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Sql_lite_EF9_Maui_sample_2026.Pages;
using Sql_lite_EF9_Maui_sample_2026.DataLayer;
using Sql_lite_EF9_Maui_sample_2026;
using ProductModel2026;
using Microsoft.EntityFrameworkCore;

namespace Week4MAUILabS00310830
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement();

            // Add Pages
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CategoriesListPage>();
            builder.Services.AddTransient<CategoryPage>();
            builder.Services.AddTransient<CategoryProductsPage>();
            builder.Services.AddTransient<CategoryProductPage>();

            // Add Services
            builder.Services.AddDbContext<MauiProductContext>(options =>
                options.UseSqlite($"Filename={Constants.DatabasePath}"));

            builder.Services.AddScoped<ICategory<Category>, CategoryDataService>();
            builder.Services.AddScoped<IProduct<Product>, ProductDataService>();
            builder.Services.AddScoped<ProductDataService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
