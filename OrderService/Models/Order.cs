using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string UserNameOrder { get; set; }
    }
}