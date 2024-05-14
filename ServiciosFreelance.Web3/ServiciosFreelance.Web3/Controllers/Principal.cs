using Microsoft.AspNetCore.Mvc;
using ServiciosFreelance.Servicio;
using ServiciosFreelance.Web3.Models;

namespace ServiciosFreelance.Web3.Controllers
{
    public class Principal : Controller
    {
        private readonly IFreelanceService _freelanceService;

        public Principal(IFreelanceService freelanceService){
        _freelanceService = freelanceService;
    }
        public IActionResult BienvenidosArtificiales()
        {
            return View();
        }

        public IActionResult CalcularServiciosFreelance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularServiciosFreelance(FreelanceModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _freelanceService.CrearServicio(model.MapToEntity());

            return RedirectToAction("Resultados");
        }

        public IActionResult Resultados()
        {
            var servicios = _freelanceService.ObtenerServicios();
            var serviciosListaModel = FreelanceModel.MapearAListaModel(servicios);
            return View(serviciosListaModel);
        }
    }
}
