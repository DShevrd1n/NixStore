using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Web.App
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Volume { get; set; }
    }
}
