namespace Store.Infrastructure.Data.EFCore.Repository.Category
{
    public class CategoryRepository(StoreDbContext storeDbContext) : ICategoryRepository
    {
        public async Task<List<CategoryModel>> GetAllCategoriesAsync() => await storeDbContext.Categories.ToListAsync();

        public async Task<CategoryModel> GetCategoryByIdAsync(int id) => await storeDbContext.Categories.FindAsync(id);

        public async Task AddCategoryAsync(CategoryModel categoryModel)
        {
            storeDbContext.Add(categoryModel);
            await storeDbContext.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(CategoryModel categoryModel, int id)
        {
            var category = await GetCategoryByIdAsync(id);
            category.Title = categoryModel.Title;
            await storeDbContext.SaveChangesAsync();
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            storeDbContext.Categories.Remove(category);
            await storeDbContext.SaveChangesAsync();
        }
    }
}