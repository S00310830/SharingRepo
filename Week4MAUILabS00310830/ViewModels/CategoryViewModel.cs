using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using ProductModel2026;
//using rad301_2023_week3_mauiApp.DataLayer;
using Sql_lite_EF9_Maui_sample_2026.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;

namespace Sql_lite_EF9_Maui_sample_2026.ViewModels
{
    [QueryProperty("CurrentCategory", "CurrentCategory")]
    public partial class CategoryViewModel : ObservableObject
    {
        public ICategory<Category> CategoryDataService { get; }
        public CategoryViewModel(ICategory<Category> categoryDataService) {
            CategoryDataService = categoryDataService;
            // ensure the collection is initialized so bindings and collection-changed work
            CategoryProducts = new ObservableCollection<Product>();
            CategoryProducts.CollectionChanged += (_, __) =>
            {
                productCount = CategoryProducts?.Count ?? 0;
                OnPropertyChanged("ProductCount");
            };

            WeakReferenceMessenger.Default.Register<ProductUpdatedMessage>(this, (r, m) =>
            {
                if (CurrentCategory != null && CurrentCategory.CategoryID == m.CategoryID)
                {
                    LoadProducts();
                }
            });
        }

        [ObservableProperty]
        Category currentCategory = new();

        [ObservableProperty]
        ObservableCollection<Product> categoryProducts = new();

        [ObservableProperty]
        int productCount = 0;

        [RelayCommand]
        public async void Tap(Product product)
        {
            // Call the Patient sessions 
            await Shell.Current.GoToAsync(nameof(CategoryProductsPage),
                new Dictionary<string, object> { { "CurrentProduct", product} });
        }

        public void LoadProducts()
        {
            if (CurrentCategory?.Products != null)
            {
                CategoryProducts.Clear();
                foreach (var p in CurrentCategory.Products)
                    CategoryProducts.Add(p);

                productCount = CategoryProducts.Count;
                OnPropertyChanged("ProductCount");
            }
        }



    }
}
