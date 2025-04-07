using API.data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class BuggyController(DataContext context) :BaseApiController
{
    [Authorize]
    [HttpGet("auth")]       
    public ActionResult <string> GetAuth ()                //401 Unauthorize
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult <AppUser> GetNotFound ()               //404 Not Found 
    {
        var thing = context.Users.Find(-1);
        if (thing== null)
            return NotFound();
        return thing;
    }

        [HttpGet("server-error")]
    public ActionResult <AppUser> GetServerError ()          // 500 Server Error
    {
         var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing had happened! ");
        return thing;
    }

        [HttpGet("bad-request")]
    public ActionResult <string> GetBadRequest ()          //400 Bad Request
    {
        return BadRequest("This was not a good request! ");
    }

}