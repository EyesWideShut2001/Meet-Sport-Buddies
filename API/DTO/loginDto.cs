using System;

namespace API.DTO;

public class LoginDto
{
    public required string Username { get; set; }
    public string Password { get; set; }
}
