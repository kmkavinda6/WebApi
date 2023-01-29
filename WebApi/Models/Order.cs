using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }

        [Required]
        public int storeID { get; set; }

        [Required]
        public int itemID { get; set; }

        public decimal totalAmount { get; set; }

        [Required]
        public int qty { get; set; }

        [Required]
        public DateTime date { get; set; }

    }

}
