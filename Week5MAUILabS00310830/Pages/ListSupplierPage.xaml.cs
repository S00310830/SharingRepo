using ProductModel2026;
using System.Linq;
using Microsoft.Maui.Controls;

namespace Week5MAUILabS00310830.Pages
{
    public partial class ListSupplierPage : ContentPage
    {
        private readonly ISupplier<Supplier> _supplierDataService;

        public List<Supplier> Suppliers { get; set; }

        public ListSupplierPage(ISupplier<Supplier> supplierDataService)
        {
            _supplierDataService = supplierDataService;
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Suppliers = await _supplierDataService.GetAll();
            // Refresh bindings
            OnPropertyChanged(nameof(Suppliers));
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = e.CurrentSelection.FirstOrDefault();
            if (selection is Supplier supplier)
            {

            }
        }
    }
}
