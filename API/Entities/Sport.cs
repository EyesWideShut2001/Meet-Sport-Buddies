using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities;

[Table("Sports")]
public class Sport
{
    public int Id { get; set; }
    public required string Denumire { get; set; } = "sdfj";
    public SportLevel Level { get; set; } 

    public bool IsMain {get; set; }
    public string? PublicId {get; set; }

    //nav prop
    public int AppUserId { get; set; }

    public AppUser AppUser { get; set; } = null!;


    
   
}