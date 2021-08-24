using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();
        public decimal AmountPrice { get; set; }
    }
}
