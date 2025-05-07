namespace Store.Domain.Service.Category
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<List<CategoryModel>> GetAllCategoriesAsync() => await categoryRepository.GetAllCategoriesAsync();

        public async Task<CategoryModel> GetCategoryByIdAsync(int id) => await categoryRepository.GetCategoryByIdAsync(id);

        public async Task AddCategoryAsync(CategoryModel categoryModel) => await categoryRepository.AddCategoryAsync(categoryModel);

        public async Task EditCategoryAsync(CategoryModel categoryModel, int id) =>
            await categoryRepository.EditCategoryAsync(categoryModel, id);

        public async Task RemoveCategoryAsync(int id) => await categoryRepository.RemoveCategoryAsync(id);
    }
}