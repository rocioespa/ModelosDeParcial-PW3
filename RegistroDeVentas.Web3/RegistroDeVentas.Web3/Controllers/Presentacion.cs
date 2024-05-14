using Microsoft.AspNetCore.Mvc;

namespace RegistroDeVentas.Web3.Controllers
{
    public class Presentacion : Controller
    {
        public IActionResult Bienvenido()
        {
            return View();
        }
    }
}
