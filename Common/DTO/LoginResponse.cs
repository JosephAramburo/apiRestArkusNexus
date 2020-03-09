using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
    }
}
