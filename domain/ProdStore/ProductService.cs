using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product[] GetAllByQuery(string query)
        {
            if (Product.IsCode(query))
                return productRepository.GetAllByArticul(query);
            return productRepository.GetAllByName(query);
        }
    }
}
