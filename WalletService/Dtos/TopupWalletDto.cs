using System.ComponentModel.DataAnnotations;

namespace WalletServices.Dtos
{
    public class TopupWalletDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Cash { get; set; }
    }
}