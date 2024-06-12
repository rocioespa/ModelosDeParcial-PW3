using Microsoft.AspNetCore.Mvc;
using RegistroAduanero.Servicio;
using RegistroAduaneroDeBarcos.Models;
using System.Reflection;

namespace RegistroAduaneroDeBarcos.Controllers
{
    public class BarcoController : Controller
    {
        private readonly IAduanaService _aduanaService;
        public BarcoController(IAduanaService aduanaService)
        {
            _aduanaService = aduanaService;
        }
        public IActionResult Listado()
        {
            var barcos = _aduanaService.ObtenerListadoBarcos();
            var barcosModelLista = BarcoModel.MapToListModel(barcos);
            return View(barcosModelLista);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(BarcoModel barco)
        {
            if (!ModelState.IsValid)
                return View(barco);

            _aduanaService.RegistrarBarco(barco.MapToEntity());
            return RedirectToAction("Listado");
            
        }
    }
}
