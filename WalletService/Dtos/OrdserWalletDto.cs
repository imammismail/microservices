using System.ComponentModel.DataAnnotations;

namespace WalletServices.Dtos
{
    public class OrderWalletDto
    {
        [Required]
        public int Cash { get; set; }
    }
}