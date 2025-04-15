using API.Enums;

namespace API.DTOs;

public class SportDto
{
    public int Id {get; set; }
    public  required string Denumire {get; set; } ="sf";
    public SportLevel Level {get; set; } 
     public bool IsMain { get; set; }
}
