﻿using Newtonsoft.Json;

namespace YourMoney.Standard.Core.Api.Models
{
    public class RegisterRequestModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
    }
}