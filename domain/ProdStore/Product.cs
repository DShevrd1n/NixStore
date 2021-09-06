using ProdStore.Data;
using System;
using System.Text.RegularExpressions;

namespace ProdStore
{
    public class Product
    {
        private readonly ProductDto dto;
        public int Id => dto.Id;
        public string Articul 
        {
            get => dto.Articul;
            set => dto.Articul = value;
        }
        public string Name
        {
            get => dto.Name;
            set => dto.Name = value;
        }
        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }
        public string Category
        {
            get => dto.Category;
            set => dto.Category = value;
        } 
       internal Product(ProductDto dto)
        {
            this.dto = dto;
        }

        public static bool IsCode(string s)
        {
            if (s == null)
                return false;
            else if (s == "")
                return false;
            return Regex.IsMatch(s, "^\\d{7}$");
        }
        public static class DtoFactory
        {
            public static ProductDto Create(string articul, string name, decimal price, string category)
            {
                if (!Product.IsCode(articul))
                    throw new ArgumentException(nameof(articul));
                return new ProductDto
                {
                    Articul = articul,
                    Name = name.Trim(),
                    Price = price,
                    Category = category.Trim(),
                };
            }
        }
        public static class Mapper
        {
            public static Product Map(ProductDto dto) => new Product(dto);
            public static ProductDto Map(Product domain) => domain.dto;
        }
    }
   
    
}
