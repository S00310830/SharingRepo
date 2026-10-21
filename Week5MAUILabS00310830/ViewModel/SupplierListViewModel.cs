using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductModel2026;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5MAUILabS00310830;
using Week5MAUILabS00310830.Pages;

namespace Week5MAUILabS00310830.ViewModel
{
    public partial class SuppliersListViewModel : ObservableObject
    {
        public ISupplier<Supplier> SupplierDataService { get; }
        public SuppliersListViewModel(ISupplier<Supplier> supplierDataService)
        {
            SupplierDataService = supplierDataService;
            Suppliers = new(Task.Run(() => SupplierDataService.GetAll()).Result);
        }

        [ObservableProperty]
        ObservableCollection<Supplier> suppliers = new();

        [RelayCommand]
        public async Task Goto(Supplier supplier)
        {
            // Call the Category Page with it's assocaited view
            await Shell.Current.GoToAsync(nameof(ListSupplierPage),
                new Dictionary<string, object> { { "CurrentSupplier", supplier } });
        }


    }
}
