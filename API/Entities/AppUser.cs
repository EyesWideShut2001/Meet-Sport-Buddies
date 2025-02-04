using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities;

public class AppUser
{
 public int Id { get; set; }
 public required string UserName { get; set; }

 public required byte[] PasswordHash {get; set;}
 public required byte[] PasswordSalt {get; set;}

}