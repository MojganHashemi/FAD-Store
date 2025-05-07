namespace Store.Domain.Model.Contracts.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();
    }
}