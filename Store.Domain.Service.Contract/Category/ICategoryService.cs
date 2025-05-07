namespace Store.Domain.Service.Contract.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryModel categoryModel);
        Task EditCategoryAsync(CategoryModel categoryModel, int id);
        Task RemoveCategoryAsync(int id);
    }
}