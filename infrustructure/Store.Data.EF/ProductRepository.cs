using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.EF
{
    class ProductRepository : IProductRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public ProductRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        

        public Product[] GetAllByIds(IEnumerable<int> productIds)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));
            return dbContext.Products
                            .Where(product => productIds.Contains(product.Id))
                            .AsEnumerable()
                            .Select(Product.Mapper.Map)
                            .ToArray();
        }
        public Product[] GetAllByArticul(string articul)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));
            if (Product.IsCode(articul))
            {
                return dbContext.Products
                                .Where(product => product.Articul == articul)
                                .AsEnumerable()
                                .Select(Product.Mapper.Map)
                                .ToArray();
            }
            return new Product[0];
        }
        public Product[] GetAllByName(string partname)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));

            var parameter = new SqlParameter("@partname", partname);
            return dbContext.Products
                            .FromSqlRaw("SELECT * FROM Products WHERE CONTAINS((Name), @partname)",
                                        parameter)
                            .AsEnumerable()
                            .Select(Product.Mapper.Map)
                            .ToArray();

        }

        public Product GetById(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(ProductRepository));

            var dto = dbContext.Products
                               .Single(book => book.Id == id);

            return Product.Mapper.Map(dto);
        }
    }
}
