﻿namespace PortfolioBackend.Entities.DTOs.Auth
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
