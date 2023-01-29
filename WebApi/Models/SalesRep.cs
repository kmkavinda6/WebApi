﻿using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class SalesRep : User
    {
        [Key]
        public int salesRepID { get; set; }

        public string area { get; set; } = string.Empty;
    }
}
