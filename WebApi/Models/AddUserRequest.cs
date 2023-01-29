﻿using System.ComponentModel.DataAnnotations;

namespace Agenzilla.Models
{
    public class AddUserRequest
    {
       


        public string userName { get; set; } = string.Empty;

        public string fName { get; set; } = string.Empty;

        public string Lname { get; set; } = string.Empty;

        public string address { get; set; } = string.Empty;

        public string phoneNo { get; set; } = string.Empty;

        [Required]
        public string userType { get; set; }

        public string nic { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string email { get; set; } = string.Empty;

        public enum UserType
        {

            Admin, Manager, SalesRep
        }
    }
}
