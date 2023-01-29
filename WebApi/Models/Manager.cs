using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class Manager : User
    {
        [Key]
        public int managerID { get; set; }
    }
}
