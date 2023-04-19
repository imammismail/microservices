namespace OrderServices.Dtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
    }
}