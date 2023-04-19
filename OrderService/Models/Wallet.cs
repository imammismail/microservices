using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class Wallet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string Username { get; set; }
        public int Cash { get; set; }
    }
}