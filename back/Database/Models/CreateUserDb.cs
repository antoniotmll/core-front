using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Database.Models
{
    public class CreateUserDb
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set;}
        public string? Email { get; set;}
        public string? Password { get; set;}
    }
}