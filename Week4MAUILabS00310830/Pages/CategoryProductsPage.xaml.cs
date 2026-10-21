using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.ViewModels;

namespace Sql_lite_EF9_Maui_sample_2026.Pages;

public partial class CategoryProductsPage : ContentPage
{
	public CategoryProductsPage(ICategory<Category> categoryDataService)
	{
        BindingContext = new CategoryViewModel(categoryDataService);
		InitializeComponent();
	}

    public CategoryViewModel CategoryViewModel
    {
        get => default;
        set
        {
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (BindingContext != null)
        {

            CategoryViewModel vm = (CategoryViewModel)this.BindingContext;
            vm.LoadProducts();
        }

        base.OnNavigatedTo(args);
    }
}