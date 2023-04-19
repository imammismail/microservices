using System.ComponentModel.DataAnnotations;

namespace OrderServices.Dtos
{
    public class CreateOrderDto
    {
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public string UserNameOrder { get; set; }
    }
}