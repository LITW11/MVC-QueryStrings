using System.Collections.Generic;

namespace WebApplication8.Models
{
    public class ProductsSearchViewModel
    {
        public List<Product> Products { get; set; }
        public string SearchText { get; set; }
    }

}