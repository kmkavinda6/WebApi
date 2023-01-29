using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class Admin : User
    {
        [Key]
        public int adminID { get; set; }
        
    }
}
