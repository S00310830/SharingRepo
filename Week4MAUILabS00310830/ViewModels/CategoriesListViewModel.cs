using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using ProductModel2026;
using Sql_lite_EF9_Maui_sample_2026.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_lite_EF9_Maui_sample_2026.ViewModels
{
    public partial class CategoriesListViewModel : ObservableObject
    {
        public ICategory<Category> CategoryDataService { get; }
        public CategoriesListViewModel(ICategory<Category> categoryDataService) {
            CategoryDataService = categoryDataService;
            Categories = new(Task.Run(() => CategoryDataService.GetAll()).Result);
        }

        [ObservableProperty]
        ObservableCollection<Category> categories = new();

        [RelayCommand]
        public async void Goto(Category category)
        {
            await Shell.Current.GoToAsync(nameof(CategoryPage),
                new Dictionary<string, object> { { "CurrentCategory", category} });
        }


    }
}
