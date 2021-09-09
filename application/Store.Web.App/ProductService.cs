using ProdStore;
using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return Map(product);
        }
        public async Task<IReadOnlyCollection<ProductModel>>  GetAllByQueryAsync(string query)
        {
            var products = Product.IsCode(query)? await productRepository.GetAllByArticulAsync(query): await productRepository.GetAllByNameAsync(query);
            return products.Select(Map).ToArray();
        }
        private ProductModel Map(Product product )
        {
            return new ProductModel
            {
                Id = product.Id,
                Articul = product.Articul,
                Name=product.Name,
                Price=product.Price,
                Category=product.Category,
                Image=product.Image,
                Volume = product.Volume
            };
        }
    }
}
