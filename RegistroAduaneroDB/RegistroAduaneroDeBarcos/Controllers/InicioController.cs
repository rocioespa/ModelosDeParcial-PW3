using Microsoft.AspNetCore.Mvc;

namespace RegistroAduaneroDeBarcos.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Bienvenida()
        {
            return View();
        }
    }
}
