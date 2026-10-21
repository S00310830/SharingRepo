using Sql_lite_EF9_Maui_sample_2026.Pages;

namespace Week4MAUILabS00310830
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CategoriesListPage), typeof(CategoriesListPage));
            Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof(CategoryProductsPage), typeof(CategoryProductsPage));
            Routing.RegisterRoute(nameof(CategoryProductPage), typeof(Sql_lite_EF9_Maui_sample_2026.Pages.CategoryProductPage));
            InitializeComponent();
        }
    }
}
