namespace OrderServices.Dtos
{
    public class ReadOrderDto
    {
        public string UserNameOrder { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}