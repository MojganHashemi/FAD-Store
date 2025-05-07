namespace Store.Infrastructure.Data.EFCore.Repository.Product
{
    public class ProductRepository(StoreDbContext storeDbContex) : IProductRepository
    {
        public async Task<List<ProductModel>> GetAllProductsAsync() => await storeDbContex.Products.ToListAsync();
    }
}