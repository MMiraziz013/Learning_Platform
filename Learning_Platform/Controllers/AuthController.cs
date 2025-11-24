using Microsoft.AspNetCore.Mvc;

namespace Learning_Platform.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}