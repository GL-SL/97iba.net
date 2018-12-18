using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DI.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        [JsonRequired]
        public string Email { get; set; }

        [JsonRequired]
        public string Password { get; set; }

    }
}
