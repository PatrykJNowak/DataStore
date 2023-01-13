using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UserAuthenticationServices.Controllers;

[ApiController]
[Route("userAuthenticationController/1.0/")]
public class UserAuthenticationController : ControllerBase
{
    [HttpGet("Get")]
    public async Task<string> GetUserData()
    {
        return "SomeDefaultData";
    }
}