using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> CreateProductByName(ProductModel model);
        Task<ProductModel> UpdateProductByName(ProductModel model);
        Task<bool> DeleteProductById(long id);
    }
}
