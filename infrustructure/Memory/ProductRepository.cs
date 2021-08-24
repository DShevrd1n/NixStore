using System;
using ProdStore;
using System.Linq;

namespace Memory
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] products = new[]
        {
            new Product(1,"1754844","Wine", 10.5m),
            new Product(2,"1700244", "Beer",5.5m),
            new Product(3,"1702844","Vodka",7.8m),
            new Product(4,"1137844","Viski",20),
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

        public Product GetById(int id)
        {
            return products.Single(product => product.Id == id); 
        }
    }
}
