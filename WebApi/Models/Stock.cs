﻿using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class Stock
    {
        [Key]
        public int batchID { get; set; }

        [Required]
        public int managerID { get; set; }

        [Required]
        public string company { get; set; } = string.Empty;

        [Required]
        public DateTime date { get; set; }

    }
}
