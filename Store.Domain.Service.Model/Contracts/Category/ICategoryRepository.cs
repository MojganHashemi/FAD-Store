namespace Store.Domain.Model.Contracts.Category
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel categoryModel);
        Task EditCategoryAsync(CategoryModel categoryModel, int id);
        Task RemoveCategoryAsync(int id);
    }
}