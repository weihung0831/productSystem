using productSystem.Models;
using System.Collections.Generic;

namespace productSystem.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
