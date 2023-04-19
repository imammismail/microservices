using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}