using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFlow.Core.DTOs.Auth
{
    public class AuthResponseDto
    {

        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
