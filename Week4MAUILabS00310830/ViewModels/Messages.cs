namespace Sql_lite_EF9_Maui_sample_2026.ViewModels
{
    public sealed class ProductUpdatedMessage
    {
        public int CategoryID { get; }
        public ProductUpdatedMessage(int categoryId) => CategoryID = categoryId;
    }
}
