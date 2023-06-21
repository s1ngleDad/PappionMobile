﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Models.User
{
    public class UserCreateModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string? Location { get; set; }
        public Guid RoleId { get; set; }
        public Guid ImageId { get; set; }
    }
}