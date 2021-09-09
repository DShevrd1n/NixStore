using ProdStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public string Category { get; set; }
    }
}
