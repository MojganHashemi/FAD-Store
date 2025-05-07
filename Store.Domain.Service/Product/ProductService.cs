namespace Store.Domain.Service.Product
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<List<ProductModel>> GetAllProductsAsync() => await productRepository.GetAllProductsAsync();
    }
}
