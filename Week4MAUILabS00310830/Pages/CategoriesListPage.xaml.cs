
using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.ViewModels;

namespace Sql_lite_EF9_Maui_sample_2026.Pages;

public partial class CategoriesListPage : ContentPage
{
    CategoriesListViewModel _categoriesListViewModel;
    public CategoriesListPage(ICategory<Category> categoryDataService)
	{
        CategoriesListViewModel = new CategoriesListViewModel(categoryDataService);
        BindingContext = CategoriesListViewModel;
        InitializeComponent();
	}
    public CategoriesListViewModel CategoriesListViewModel
    {
        get => _categoriesListViewModel;
        set
        {
            _categoriesListViewModel = value;
        }
    }

    private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selection = e.CurrentSelection.FirstOrDefault();
        Category category = (Category)selection;
        CategoriesListViewModel.Goto(category);
    }
}