using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/users")]
[ApiController]
public class UserController : Controller
{
    [HttpGet]
    public ActionResult<List<UserModel>> FindAll()
    {
        return Json("teste");
    }
}