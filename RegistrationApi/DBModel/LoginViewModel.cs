﻿using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.DBModel
{
    public class LoginViewModel
    {
        
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
