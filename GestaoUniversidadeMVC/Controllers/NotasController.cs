using Microsoft.AspNetCore.Mvc;

namespace GestaoUniversidadeMVC.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
