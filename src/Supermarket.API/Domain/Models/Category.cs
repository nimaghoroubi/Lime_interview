using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Supermarket.API.Domain.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();

    }

}
