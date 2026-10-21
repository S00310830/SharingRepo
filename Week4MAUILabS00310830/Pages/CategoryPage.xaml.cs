using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.ViewModels;

namespace Sql_lite_EF9_Maui_sample_2026.Pages;

public partial class CategoryPage : ContentPage
{
	public CategoryPage(ICategory<Category> categoryDataService)
	{
        BindingContext = new CategoryViewModel(categoryDataService);
		InitializeComponent();
	}

    public CategoryViewModel CategoryViewModel
    {
        get => BindingContext as CategoryViewModel;
        set
        {
            BindingContext = value;
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

    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (BindingContext != null)
        {
            var selection = e.CurrentSelection.FirstOrDefault();
            if (selection != null)
            {
                Product product = (Product)selection;
                // navigate to edit page and pass the selected product
                await Shell.Current.GoToAsync(nameof(CategoryProductPage),
                    new Dictionary<string, object> { { "CurrentProduct", product } });

                // clear selection
                if (sender is CollectionView cv)
                    cv.SelectedItem = null;
            }
        }
    }
}