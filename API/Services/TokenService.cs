
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens; //SymmetricSecurityKey

namespace API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception ("Cannot acces tokenKey from appsettings" );
        if(tokenKey.Length<64) throw new Exception("Your tokenKey needs to be longer");

        var key= new SymmetricSecurityKey (Encoding.UTF8.GetBytes(tokenKey));

        var creds =new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


        var claims =new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserName)
        };

          var tokenDescriptor= new SecurityTokenDescriptor
        {
            Subject= new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials= creds
        };

        var tokenHander = new JwtSecurityTokenHandler();
        var token= tokenHander.CreateToken(tokenDescriptor);

        return tokenHander.WriteToken(token);
    }
}
