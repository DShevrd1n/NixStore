using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public interface IProductRepository
    {
        Product [] GetAllByName(string partname);
        Product[] GetAllByArticul(string articul);
        Product GetById(int id);
        Product[] GetAllByIds(IEnumerable<int> productIds);
    }
}
