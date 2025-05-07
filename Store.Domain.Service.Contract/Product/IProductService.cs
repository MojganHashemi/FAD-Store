namespace Store.Domain.Service.Contract.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProductsAsync();
    }
}