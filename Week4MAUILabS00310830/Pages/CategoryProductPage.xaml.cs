using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.ViewModels;
using Sql_lite_EF9_Maui_sample_2026.DataLayer;

namespace Sql_lite_EF9_Maui_sample_2026.Pages;

public partial class CategoryProductPage : ContentPage
{
    public CategoryProductPage(ProductDataService productService)
    {
        BindingContext = new CategoryProductViewModel(productService);
        InitializeComponent();
    }
}
