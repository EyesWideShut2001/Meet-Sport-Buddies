using System.Security.Cryptography;
using System.Text;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.data;
using API.DTO;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context):BaseApiController
{
    [HttpPost("register")] //account/register
    public async Task <ActionResult <AppUser>> Register (RegisterDto registerDto)
    {
        if (await UserExist(registerDto.Username)) return BadRequest("Username is taken!");

        using var hmac = new HMACSHA512();

        var user=new AppUser{
            UserName=registerDto.Username.ToLower(),
            PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt=hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }
    private async Task <bool> UserExist(string username)
    {
        return await context.Users.AnyAsync(x=>x.UserName.ToLower()==username.ToLower());
    }
}
