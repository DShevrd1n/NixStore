using System.Text.RegularExpressions;

namespace ProdStore
{
    public class Product
    {
        public int Id { get; }
        public string Artucil { get; }
        public string Name { get; }
        public Product(int id, string articul, string name)
        {
            Id = id;
            Artucil = articul;
            Name = name;

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
