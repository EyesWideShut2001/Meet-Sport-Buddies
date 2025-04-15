using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository): BaseApiController
{
    
    [HttpGet]
    public async Task < ActionResult <IEnumerable<MemberDto>> > GetUsers()
    {
        var users=  await userRepository.GetMembersAsync();
        
        return  Ok(users); // sau ok(users)
    }

    
    [HttpGet("{username}")] // /users/
    public async Task <ActionResult <MemberDto>> GetUser(string username)
    {
        var user=await userRepository.GetMemberAsync(username);

        if(user==null) return NotFound();

        return  user;// sau ok(users)
    }

        [HttpGet("sport/{sport}")] 
    public async Task < ActionResult <IEnumerable<MemberDto>> > GetUsersBySport(string sport)
    {
        var users = await userRepository.GetMembersAsync();
        // users.Where( u => u.Sports )
        // foreach (var u in users)
        // {

        // }

        return  Ok(users);
    }
}
