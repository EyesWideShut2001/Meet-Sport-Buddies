using System.Transactions;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Entities;

public class AppUser
{
 public int Id { get; set; }
 public required string UserName { get; set; }

 public  byte[] PasswordHash {get; set;} = [];
 public  byte[] PasswordSalt {get; set;} = [];

 public  DateOnly DateOfBirth { get; set; }

 public required string KnownAs { get; set; }

public  DateTime Created { get; set; }  = DateTime.UtcNow;

public  DateTime LastActive { get; set; }  = DateTime.UtcNow;

public required string Gender { get; set; } 

public string? Introduction {get; set; }

public List <Sport> Sports {get; set; } = [];

public required string City {get; set; }

public required string Country {get; set; }

public List <Photo> Photos {get; set; } =[];



