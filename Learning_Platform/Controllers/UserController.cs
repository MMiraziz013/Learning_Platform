using Microsoft.AspNetCore.Mvc;

namespace Learning_Platform.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}