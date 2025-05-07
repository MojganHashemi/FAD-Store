using Store.Domain.Model.Entities.Category;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnectionString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowStoreProjectUi", policy =>
    {
        policy.WithOrigins("http://localhost:4200/")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
//app.UseCors("AllowStoreProjectUi");

app.MapGet("/categories", (ICategoryService categoryService) =>
{
    return categoryService.GetAllCategoriesAsync();
});

app.MapGet("/category", (ICategoryService categoryService, int id) =>
{
    return categoryService.GetCategoryByIdAsync(id);
});

app.MapPost("/categories", async (ICategoryService categoryService, CategoryModel categoryModel) =>
{
    await categoryService.AddCategoryAsync(categoryModel);
});

app.MapPut("/categories/{id}", async (ICategoryService categoryService, CategoryModel categoryModel, int id) =>
{
    var category = await categoryService.GetCategoryByIdAsync(id);

    if (category is null)
        return Results.NotFound($"Category with ID {id} not found.");
    else
    {
        await categoryService.EditCategoryAsync(categoryModel, id);
        return Results.Ok(categoryModel);
    }

});

app.MapDelete("/categories/{id}", async (ICategoryService categoryService, int id) =>
{
    await categoryService.RemoveCategoryAsync(id);
});

app.MapGet("/products", async (IProductService productService) =>
{
    return await productService.GetAllProductsAsync();
});

app.Run();