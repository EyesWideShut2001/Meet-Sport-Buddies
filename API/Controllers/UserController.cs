using API.data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] // /api/users
public class UsersController(DataContext context): ControllerBase
{

    [HttpGet]
    public async Task < ActionResult <IEnumerable<AppUser>> > GetUsers()
    {
        var users=  await context.Users.ToListAsync();

        return  users; // sau ok(users)
    }

    
    [HttpGet("{id:int}")] // /users/id
    public async Task <ActionResult <AppUser>> GetUser(int id)
    {
        var user=await context.Users.FindAsync(id);

        if(user==null) return NotFound();

        return  user; // sau ok(users)
    }
}
