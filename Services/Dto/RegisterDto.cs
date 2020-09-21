using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public Department Id { get; set; }

        public string Password { get; set; }
    }
}
