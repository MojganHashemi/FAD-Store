namespace Store.Domain.Model.Entities.Category
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}