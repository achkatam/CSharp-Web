namespace Library.Server.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class BaseController : Controller
{
    protected string GetUserID()
    {
        string id = string.Empty;

        if (User != null)
        {
            id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        return id;
    }
}