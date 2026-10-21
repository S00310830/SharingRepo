using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026;
using Sql_lite_EF9_Maui_sample_2026.Pages;
using Sql_lite_EF9_Maui_sample_2026.DataLayer;

namespace Week5MAUILabS00310830
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

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ListSupplierPage>();

            // Add Services
            builder.Services.AddDbContext<MauiProductContext>(options =>
                options.UseSqlite($"Filename={Constants.DatabasePath}"));

            // Register supplier service and its interface for DI
            builder.Services.AddScoped<ISupplier<Supplier>, SupplierDataService>();
            builder.Services.AddScoped<SupplierDataService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
