using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    class ProductRepository : IProductRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public ProductRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public async Task<Product[]> GetAllByIdsAsync(IEnumerable<int> productIds)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));
            var dtos= await dbContext.Products
                                     .Where(product => productIds.Contains(product.Id))
                                     .ToArrayAsync();
            return dtos.Select(Product.Mapper.Map)
                       .ToArray();
        }
        public async Task<Product[]> GetAllByArticulAsync(string articul)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));
            if (Product.IsCode(articul))
            {
                var dtos = await dbContext.Products
                                               .Where(product => product.Articul == articul)
                                               .ToArrayAsync();

                return  dtos.Select(Product.Mapper.Map)
                            .ToArray();
            }
            return new Product[0];
        }
        public async Task<Product[]> GetAllByNameAsync(string partname)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));
            var parameter = new SqlParameter("@partname", partname);
            var dtos = await dbContext.Products
                                      .FromSqlRaw("SELECT * FROM Products WHERE CONTAINS((Name), @partname)",
                                        parameter)
                                      .ToArrayAsync();
            return dtos.Select(Product.Mapper.Map)
                       .ToArray();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));

            var dto = await dbContext.Products
                               .SingleAsync(book => book.Id == id);

            return Product.Mapper.Map(dto);
        }

    }
}
