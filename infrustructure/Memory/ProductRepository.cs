using System;
using ProdStore;
using System.Linq;

namespace Memory
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] products = new[]
        {
            new Product(1,"1754844","Wine"),
            new Product(2,"1700244", "Beer"),
            new Product(3,"1702844","Vodka"),
            new Product(4,"1137844","Viski"),
        };

        public Product[] GetAllByArticul(string articul)
        {
            return products.Where(product => product.Artucil == articul)
                           .ToArray();
        }
        public Product[] GetAllByName(string partname)
        {
            return products.Where(product => product.Name.Contains(partname))
                            .ToArray();
        }
    }
}
