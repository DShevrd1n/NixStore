using ProdStore;
using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Web.App
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ProductModel GetById(int id)
        {
            var product = productRepository.GetById(id);
            return Map(product);
        }
        public IReadOnlyCollection<ProductModel>  GetAllByQuery(string query)
        {
            var products = Product.IsCode(query)? productRepository.GetAllByArticul(query): productRepository.GetAllByName(query);
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
                Category=product.Category
            };
        }
    }
}
