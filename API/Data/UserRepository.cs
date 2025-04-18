using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
         return await context.Users
          .Include(x => x.Photos)
          .Include(x => x.Sports)
         .SingleOrDefaultAsync(x => x.UserName==username);
    }

    public async Task<IEnumerable<AppUser>> GetUserAsync()
    {
        return await context.Users
        .Include(x => x.Photos)
        .Include(x => x.Sports)
        .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return  await context.SaveChangesAsync()>0;
    }

    public void Update(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context.Users
            .Include(u => u.Photos)
            .Include(u => u.Sports) // 👈 This was missing!
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<MemberDto?> GetMemberAsync(string username)
    {
        return await context.Users
            .Include(u => u.Photos)
            .Include(u => u.Sports) // 👈 This was missing!
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}