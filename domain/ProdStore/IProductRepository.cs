using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdStore
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllByIdsAsync(IEnumerable<int> productIds);
        Task<Product[]> GetAllByArticulAsync(string articul);
        Task<Product[]> GetAllByNameAsync(string partname);
        Task<Product> GetByIdAsync(int id);
    }
}
