using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.DataLayer;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using Sql_lite_EF9_Maui_sample_2026.ViewModels;

namespace Sql_lite_EF9_Maui_sample_2026.ViewModels
{
    [QueryProperty("CurrentProduct", "CurrentProduct")]
    public partial class CategoryProductViewModel : ObservableObject
    {
        private readonly ProductDataService _productService;

        public CategoryProductViewModel(ProductDataService productService)
        {
            _productService = productService;
        }

        // Observable property for the selected product
        [ObservableProperty]
        Product currentProduct = new();

        [RelayCommand]
        public async Task Save()
        {
            if (CurrentProduct == null)
                return;

            await _productService.Update(CurrentProduct);
            await Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        public async Task Cancel()
        {
            // navigate back without saving
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
