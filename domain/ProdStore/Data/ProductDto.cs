using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Volume { get; set; }
        public string Category { get; set; }
    }
}
