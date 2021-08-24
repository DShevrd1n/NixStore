using System.Text.RegularExpressions;

namespace ProdStore
{
    public class Product
    {
        public int Id { get; }
        public string Artucil { get; }
        public string Name { get; }
        public decimal Price { get; }
        public Product(int id, string articul, string name, decimal price)
        {
            Id = id;
            Artucil = articul;
            Name = name;
            Price = price;

        }

        internal static bool IsCode(string s)
        {
            if (s == null)
                return false;
            else if (s == "")
                return false;
            return Regex.IsMatch(s, "^\\d{7}$");
        }

    }
}
