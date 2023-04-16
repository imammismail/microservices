using System.ComponentModel.DataAnnotations;

namespace WalletServices.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int Cash { get; set; }
    }
}