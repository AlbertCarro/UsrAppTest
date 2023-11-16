using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Otras acciones para diferentes vistas o funcionalidades
}
